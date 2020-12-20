using System.IO;
using Microsoft.VisualBasic;
using System;

namespace Lab4
{
    public class BackupFile
    {
        private FileInfo BackupFileInfo {get; set; }
        private string Name {get; set; }
        private string DirectoryName {get; set; }
        public string FullName { get; private set; }
        public  long Size { get; private set; }
        private DateTime CreationTime {get; set; }
        private DateTime LastUpdate { get; set; }
        public bool Changed { get; private set; }

        public BackupFile(string filePath)
        {
            BackupFileInfo = new FileInfo(filePath);
            Name = BackupFileInfo.Name;
            DirectoryName = BackupFileInfo.DirectoryName;
            FullName = DirectoryName + '/' + Name;
            Size = BackupFileInfo.Length;
            CreationTime = BackupFileInfo.CreationTime;
            LastUpdate = File.GetLastWriteTime(FullName);
            Changed = false;
        }
        
        public BackupFile(BackupFile originFile)
        {
            BackupFileInfo = new FileInfo(originFile.FullName);
            Name = BackupFileInfo.Name;
            DirectoryName = originFile.DirectoryName;
            FullName = originFile.FullName;
            Size = originFile.Size;
            CreationTime = originFile.CreationTime;
            LastUpdate = originFile.LastUpdate;
            Changed = originFile.Changed;
        }

        public void Update()
        {
            Changed = false || LastUpdate != File.GetLastWriteTime(FullName);
            LastUpdate = File.GetLastWriteTime(FullName);
            BackupFileInfo = new FileInfo(FullName);
        }
        
        public long CurrentSize()
        {
            return BackupFileInfo.Length;
        }

        public void UpdateSize()
        {
            Size = CurrentSize();
        }

        /*public BackupFile GetCopy()
        {
            var fileCopy = new BackupFile(FullName);
            fileCopy.Changed = Changed;
            return fileCopy;
        }*/

        public void Info()
        {
            Console.WriteLine("        " + Name);
            //\Console.WriteLine("        " + DirectoryName);
            Console.WriteLine("        Size: " + Size + " байт");
            Console.WriteLine("        CreationTime: " + CreationTime);
            Console.WriteLine("        LastUpdate: " + LastUpdate);
            Console.WriteLine("        Changed: " + Changed);
        }
    }
}