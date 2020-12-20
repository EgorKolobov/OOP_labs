using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Lab4
{
    public class Archive
    {
        private List<RestorePoint> RestorePoints;

        public Archive()
        {
            RestorePoints = new List<RestorePoint>();
        }

        public void Save(List<RestorePoint> data)
        {
            RestorePoints = data.ToList();
        }
        
        public List<RestorePoint> Unzip()
        {
            return RestorePoints;
        }
    }
}