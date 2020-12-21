using System;

namespace Lab4
{
    public class MemoryLimit : Limit
    {
        private long MaxMemory;

        public MemoryLimit(long maxMemory)
        {
            MaxMemory = maxMemory;
        }

        public override int GetLimit(Backup myBackup)
        {
            int extra1 = myBackup.RestorePoints.Count-1;
            long totalSize = 0;
            for (int i = myBackup.RestorePoints.Count - 1; i > -1; i--)
            {
                totalSize += myBackup.RestorePoints[i].Size;
                if (totalSize > MaxMemory)
                {
                    extra1 = i + 1;
                    break;
                }
            }
            if (totalSize <= MaxMemory || extra1 <=0)
                return 0;

            return CleanDeltas(myBackup, extra1);
        }
    }
}