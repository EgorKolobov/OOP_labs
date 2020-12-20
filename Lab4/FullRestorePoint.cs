using System.Collections.Generic;
using System.Linq;
using System;

namespace Lab4
{
    public class FullRestorePoint : RestorePoint
    {
        public FullRestorePoint(List<BackupFile> filesToSave) : base(filesToSave){}

        protected override long GetSize()
        {
            /*long totalSize = 0;
            foreach (var f in Files)
                totalSize += f.Size;
            return totalSize;*/
            return Files.Sum(f => f.CurrentSize());
        }

        public override void Info()
        {
            Console.WriteLine("FullRestorePoint Info:");
            Console.WriteLine("    Size: " + Size);
            foreach (var f in Files)
                f.Info();
        }
    }
}