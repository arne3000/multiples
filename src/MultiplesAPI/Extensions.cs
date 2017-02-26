using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI
{
    public static class Extensions
    {
        public static bool IsMultiple(this int value, int multiple)
        {
            return (value % multiple) == 0;
        }

        public static IEnumerable<int> CreateSquenceFromStartEnd(int start, int end)
        {
            if (end <= start)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = start; i <= end; i++)
            {
                yield return i;
            }
        }
    }
}
