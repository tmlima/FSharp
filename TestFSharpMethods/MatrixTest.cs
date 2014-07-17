using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.FSharp.Math;

namespace TestFSharpMethods
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void TestProduct()
        {
            MathCSharp.Matrix matrix = new MathCSharp.Matrix();

            int[][] matrixA = MatrixA();
            int[][] matrixB = MatrixB();
            int[][] matrixC = MatrixC();
            int[][] matrixD = MatrixD();

            int[][] resultAxB = matrix.Product(matrixA, matrixB);
            int[][] resultBxA = matrix.Product(matrixB, matrixA);
            int[][] resultCxD = matrix.Product(matrixC, matrixD);

            Matrix<double> matrixAFSharp = MatrixModule.ofArray2D(ConvertoToDouble2DArray(matrixA));
            Matrix<double> matrixBFSharp = MatrixModule.ofArray2D(ConvertoToDouble2DArray(matrixB));
            Matrix<double> resultFSharpAxB = Matrix.product(matrixAFSharp, matrixBFSharp);
            Matrix<double> resultFSharpBxA = Matrix.product(matrixBFSharp, matrixAFSharp);

            if (!MatrixModule.ofArray2D(ConvertoToDouble2DArray(resultAxB)).Equals(resultFSharpAxB)
                || !MatrixModule.ofArray2D(ConvertoToDouble2DArray(resultBxA)).Equals(resultFSharpBxA))
            {
                Assert.Fail();
            }

            Assert.IsTrue(CompareArray(resultAxB, AxBResult()));
            Assert.IsTrue(CompareArray(resultBxA, BxAResult()));
            Assert.IsTrue(CompareArray(resultCxD, CxDResult()));
        }

        private double[,] ConvertoToDouble2DArray(int[][] arrayJagged)
        {
            double[,] array2D = new double[arrayJagged.Length, arrayJagged[0].Length];
            for (int i = 0; i < arrayJagged.Length; i++)
            {
                for (int j = 0; j < arrayJagged[0].Length; j++)
                {
                    array2D[i, j] = (double)arrayJagged[i][j];
                }
            }

            return array2D;
        }

        private int[][] MatrixA()
        {
            int[][] m = new int[2][];
            m[0] = new int[2];
            m[1] = new int[2];

            m[0][0] = 1;
            m[0][1] = 2;
            m[1][0] = 3;
            m[1][1] = 4;

            return m;
        }

        private int[][] MatrixB()
        {
            int[][] m = new int[2][];
            m[0] = new int[2];
            m[1] = new int[2];

            m[0][0] = 2;
            m[0][1] = 0;
            m[1][0] = 1;
            m[1][1] = 2;

            return m;
        }

        private int[][] AxBResult()
        {
            int[][] result = new int[2][];
            result[0] = new int[2];
            result[1] = new int[2];

            result[0][0] = 4;
            result[0][1] = 4;
            result[1][0] = 10;
            result[1][1] = 8;

            return result;
        }

        private int[][] BxAResult()
        {
            int[][] result = new int[2][];
            result[0] = new int[2];
            result[1] = new int[2];

            result[0][0] = 2;
            result[0][1] = 4;
            result[1][0] = 7;
            result[1][1] = 10;

            return result;
        }

        private int[][] CxDResult()
        {
            int[][] result = new int[2][];
            result[0] = new int[2];
            result[1] = new int[2];

            result[0][0] = 0;
            result[0][1] = -5;
            result[1][0] = -6;
            result[1][1] = -7;

            return result;
        }

        private int[][] MatrixC()
        {
            int[][] m = new int[2][];
            m[0] = new int[3];
            m[1] = new int[3];

            m[0][0] = 1;
            m[0][1] = 0;
            m[0][2] = -2;
            m[1][0] = 0;
            m[1][1] = 3;
            m[1][2] = -1;

            return m;
        }

        private int[][] MatrixD()
        {
            int[][] m = new int[3][];
            m[0] = new int[2];
            m[1] = new int[2];
            m[2] = new int[2];

            m[0][0] = 0;
            m[0][1] = 3;
            m[1][0] = -2;
            m[1][1] = -1;
            m[2][0] = 0;
            m[2][1] = 4;

            return m;
        }

        private bool CompareArray(int[][] a, int[][] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[0].Length; j++)
                {
                    if (a[i][j] != b[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
