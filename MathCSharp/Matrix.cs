using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCSharp
{
    public class Matrix
    {
        public int[][] Product(int[][] a, int[][] b)
        {
            int[][] result = BuildResultMatrix(a, b);
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length; j++)
                {
                    result[i][j] = ProductElement(a[i], GetColumn(b, j));
                }
            }
            return result;
        }

        private int[][] BuildResultMatrix(int[][] a, int[][] b)
        {
            int smallestDimension = 0;
            if (a.Length <= a[0].Length)
            {
                smallestDimension = a.Length;
            }
            else
            {
                smallestDimension = a[0].Length;
            }

            int[][] result = new int[smallestDimension][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[smallestDimension];
            }
            return result;
        }

        private int[] GetColumn(int[][] matrix, int columnIndex)
        {
            int[] column = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                column[i] = matrix[i][columnIndex];
            }
            return column;
        }

        private int ProductElement(int[] aLine, int[] bColumn)
        {
            int sum = 0;
            for (int i = 0; i < aLine.Length; i++)
            {
                sum += aLine[i] * bColumn[i];
            }
            return sum;
        }
    }
}
