using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Lab4
{
    public abstract class RestorePoint
    {
        public int Id = 228;
        protected List<BackupFile> Files;
        public int FilesCount { get; set; }
        public long Size { get; private set; }
        public DateTime CreationTime { get; private set; }

        protected RestorePoint(List<BackupFile> filesToSave)
        {
            Files = new List<BackupFile>();
            foreach (var f in filesToSave)
                Files.Add(new BackupFile(f));
            FilesCount = Files.Count;
            Size = GetSize();
            foreach (var file in Files)
                file.UpdateSize();
            CreationTime = DateTime.Now;
        }

        protected abstract  long GetSize();

        public abstract void Info();
    }
}