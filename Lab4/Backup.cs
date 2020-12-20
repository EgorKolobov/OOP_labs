using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;

namespace Lab4
{
    public class Backup
    {
        private int Id {get; set;}
        private List<BackupFile> BackupFiles;
        public List<RestorePoint> RestorePoints {get; private set; }
        private Archive ArchiveStorage { get; set; }
        public long Size { get; private set; }
        private List<Limit> Limits;
        private bool MinLimit = true;
        private bool MaxLimit = false;
        
        public Backup()
        {
            Id = 1488;
            BackupFiles = new List<BackupFile>(); // original files
            RestorePoints = new List<RestorePoint>();
            Size = 0;
            Limits = new List<Limit>();
            ArchiveStorage = new Archive();
        }

        public Backup(List<BackupFile> dataFiles)
        {
            Id = 1488;
            BackupFiles = new List<BackupFile>(dataFiles);
            RestorePoints = new List<RestorePoint>();
            Size = 0;
            Limits = new List<Limit>();
            ArchiveStorage = new Archive();
            MakeFullRestorePoint();
        }
        
        public void Add(BackupFile newFile)
        {
            if(!BackupFiles.Contains(newFile))
                BackupFiles.Add(newFile);
        }
        
        public void Add(string filePath)
        {
            var newFile = new BackupFile(filePath);
            if(!BackupFiles.Contains(newFile))
                BackupFiles.Add(newFile);
        }

        public void Remove(string filePath)
        {
            var fileToRemove = BackupFiles.SingleOrDefault(r => r.FullName == filePath);
            if (fileToRemove != null)
                BackupFiles.Remove(fileToRemove);
        }

        private void UpdateFiles()
        {
            foreach (var file in BackupFiles)
                file.Update();
        }

        private void UpdateFilesSize()
        {
            foreach (var file in BackupFiles)
                file.UpdateSize();
        }
        
        public void MakeFullRestorePoint()
        {
            UpdateFiles();
            var newRestorePoint = new FullRestorePoint(BackupFiles);
            RestorePoints.Add(newRestorePoint);
            Size += newRestorePoint.Size;
            UpdateFilesSize();
            PushItToTheLimit();
        }
        
        public void MakeDeltaRestorePoint()
        {
            UpdateFiles();
            var newRestorePoint = new DeltaRestorePoint(BackupFiles);
            RestorePoints.Add(newRestorePoint);
            Size += newRestorePoint.Size;
            UpdateFilesSize();
            PushItToTheLimit();
        }

        public void SaveAllToArchive()
        {
            ArchiveStorage.Save(RestorePoints);
        }

        public List<RestorePoint> UnzipArchive()
        {
            return ArchiveStorage.Unzip();
        }
        
        public void AddLimit(Limit lim)
        {
            Limits.Add(lim);
        }

        public void SetMaxLimit()
        {
            MaxLimit = true;
            MinLimit = false;
        }
        
        public void SetMinLimit()
        {
            MaxLimit = false;
            MinLimit = true;
        }
        
        public void PushItToTheLimit()
        {
            int extra = 0;
            if(Limits.Count != 0)
            {
                if (MinLimit)
                {
                    extra = RestorePoints.Count;
                    foreach (var l in Limits)
                        extra = Math.Min(extra, l.GetLimit(this));
                }
                else
                {
                    foreach (var l in Limits)
                        extra = Math.Max(extra, l.GetLimit(this));
                }
            }
            for (int i = 0; i < extra; i++)
                Size -= RestorePoints[i].Size;
            RestorePoints.RemoveRange(0, extra);
        }

        public void Info()
        {
            Console.WriteLine("<<<<< BACKUP INFO >>>>>");
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Size: " + Size);
            Console.WriteLine("RestorePoints:");
            foreach (var point in RestorePoints)
                point.Info();
        }
        
    }
}