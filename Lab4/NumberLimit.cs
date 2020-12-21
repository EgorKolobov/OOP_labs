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
        
        public override int GetLimit(Backup myBackup)
        {
            var extra1 = myBackup.RestorePoints.Count - MaxPoints;
            if (extra1 <= 0)
                return 0;
            
            return CleanDeltas(myBackup, extra1);
        }
    }
}