using System.Reflection.Metadata;

namespace Lab4
{
    public interface Limit
    {
        public int GetLimit(Backup myBackup); // amount of restore points that we need to delete
    }
}