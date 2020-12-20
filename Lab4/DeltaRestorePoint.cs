using System.Collections.Generic;
using System;
namespace Lab4
{
    public class DeltaRestorePoint : RestorePoint
    {
        public DeltaRestorePoint(List<BackupFile> filesToSave) : base(filesToSave){}

        protected override long GetSize()
        {
            long size = 0;
            foreach (var f in Files)
                if (f.Changed)
                    size += Math.Abs(f.CurrentSize() - f.Size);
                else
                    size += f.Size;
            return size;
        }

        public override void Info()
        {
            Console.WriteLine("DeltaRestorePoint Info:");
            Console.WriteLine("    Size: " + Size);
            foreach (var f in Files)
                f.Info();
        }
    }
}