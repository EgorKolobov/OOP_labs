using System;
using System.ComponentModel;

namespace Lab4
{
    public class NumberLimit : Limit
    {
        private int MaxPoints;

        public NumberLimit(int maxPoints)
        {
            MaxPoints = maxPoints;
        }
        
        public int GetLimit(Backup myBackup)
        {
            var extra = myBackup.RestorePoints.Count - MaxPoints;
            if (extra <= 0)
                return 0;
            
            while (extra > 0 && myBackup.RestorePoints[extra].GetType() == typeof(DeltaRestorePoint))
                extra--;
            
            if(extra < myBackup.RestorePoints.Count - MaxPoints)
                throw new UserException("Number Limit: Can't leave delta point without restore point.");
            
            return extra;
        }
    }
}