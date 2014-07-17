using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCSharp
{
    public static class Combinatorics
    {
        /// <summary>
        /// Calculate the possibilities of N elements in groups of R.
        /// Considering that elements cannot be repeated.
        /// </summary>
        public static int Combine(int n, int r)
        {
            return Math.Fat(n) / (Math.Fat(r) * Math.Fat(n - r));
        }

        public static int CombineWithFixedSize(int x, int y, int totalLenght, int xLenght)
        {
            return Combine(x, xLenght) * Combine(y, totalLenght - xLenght);
        }

        /// <summary>
        /// Calculate the possibilities of X elements of type A combined with Y elements of type B
        /// considering that there will be at least XMin elements of type A.
        /// </summary>
        /// <param name="r">Combined elements group size</param>
        public static int CombineTwoElementsWithMinimum(int x, int y, int r, int xMin)
        {
            return CombineTwoElementsWithMinimumMaximum(x, y, r, xMin, r);
        }

        /// <summary>
        /// Calculate the possibilities of X elements of type A combined with Y elements of type B
        /// considering that there will be at least XMin elements of type A and at most XMax.
        /// </summary>
        /// <param name="r">Combined elements group size</param>
        public static int CombineTwoElementsWithMinimumMaximum(int x, int y, int r, int xMin, int xMax)
        {
            int possibilities = 0;
            for (int xLenght = xMin; xLenght <= xMax; xLenght++)
            {
                possibilities += CombineWithFixedSize(x, y, r, xLenght);
            }
            return possibilities;
        }

        public static int CombineElementsIntoGroups(int elementsQuantity, int groupSize, int groupQuantity)
        {
            int possibilities = 1;
            int remainingElements = elementsQuantity;
            for (int groupIndex = 0; groupIndex < groupQuantity; groupIndex++)
            {
                possibilities *= Combine(remainingElements, groupSize);
                remainingElements -= groupSize;
            }
            return possibilities;
        }
    }
}
