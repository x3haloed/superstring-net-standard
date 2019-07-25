using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreUnitTests.Helpers
{
    public class PointHelpers
    {
        public readonly (double row, double column ) INFINITY_POINT = (row: double.PositiveInfinity, column: double.PositiveInfinity);

        public short compare(Point a, Point b)
        {
            if (a.row == b.row)
            {
                return compareNumbers(a.column, b.column);
            }
            else
            {
                return compareNumbers(a.row, b.row);
            }
        }

        private short compareNumbers(long a, long b)
        {
            if (a < b)
            {
                return -1;
            }
            else if (a > b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
