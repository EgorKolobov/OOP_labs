using System;

namespace Lab4
{
    public class TimeLimit : Limit
    {
        private DateTime LastTime;

        public TimeLimit(DateTime lastTime)
        {
            LastTime = lastTime;
        }

        public int GetLimit(Backup myBackup)
        {
            int extra1 = 0;
            foreach (var rp in myBackup.RestorePoints)
                if (DateTime.Compare(rp.CreationTime, LastTime) <= 0)
                    extra1++;
            var extra2 = extra1;
            while (extra2 > 0 && myBackup.RestorePoints[extra2].GetType() == typeof(DeltaRestorePoint))
                extra2--;
            if(extra2<extra1)
                throw new UserException("Time Limit: Can't leave delta point without restore point.");
            return extra2;
        }
    }
}