using System.Collections.Generic;

namespace Geon
{
    public class GeoRangeComparer : IComparer<GeoRange>
    {
        public int Compare(GeoRange x, GeoRange y)
        {
            if (x.To < y.From)
                return -1;

            if (x.From > y.To)
                return 1;

            return 0;
        }
    }
}