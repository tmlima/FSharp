using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsApp
{
    public partial class Form1 : Form
    {
        private const int ROWS = 5;
        private const int COLUMNS = 5;
        private const int MAX_VALUE = 100;

        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            int[][] matrixA = GenerateMatrix();
            int[][] matrixB = GenerateMatrix();

            dataGridView1.DataSource = BuildDataTable(matrixA);
            dataGridView2.DataSource = BuildDataTable(matrixB);
            dataGridView3.DataSource = BuildDataTable(new MathCSharp.Matrix().Product(matrixA, matrixB));
        }

        private DataTable BuildDataTable(int[][] matrix)
        {
            DataTable dataTable = new DataTable();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                dataTable.Columns.Add();
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                DataRow row = dataTable.NewRow();
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    row[j] = matrix[i][j];
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private int[][] GenerateMatrix()
        {
            int[][] matrix = new int[ROWS][];
            for (int i = 0; i < ROWS; i++)
            {
                matrix[i] = new int[COLUMNS];
                for (int j = 0; j < COLUMNS; j++)
                {
                    matrix[i][j] = random.Next(MAX_VALUE);
                }
            }
            return matrix;
        }
    }
}
