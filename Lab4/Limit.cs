using System.Reflection.Metadata;

namespace Lab4
{
    public abstract class Limit
    {
        //protected Limit() {}
        public abstract int GetLimit(Backup myBackup); // amount of restore points that we need to delete

        public int CleanDeltas(Backup myBackup, int extra1)
        {
            int extra2 = extra1; 
            while (extra2 > 0 && myBackup.RestorePoints[extra2].GetType() == typeof(DeltaRestorePoint))
                extra2--;
            if(extra2<extra1)
                throw new UserException("Memory Limit: Can't leave delta point without restore point.");
            return extra2;
        }
    }
}