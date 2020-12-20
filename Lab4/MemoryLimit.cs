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

        public int GetLimit(Backup myBackup)
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
            var extra2 = extra1;
            if (totalSize <= MaxMemory || extra2 <=0)
                return 0;
            
            while (extra2 > 0 && myBackup.RestorePoints[extra2].GetType() == typeof(DeltaRestorePoint))
                extra2--;
            if(extra2<extra1)
                throw new UserException("Memory Limit: Can't leave delta point without restore point.");
            return extra2;
        }
    }
}