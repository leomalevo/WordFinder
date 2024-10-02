using System;
using System.Collections;
using System.Collections.Generic;

namespace WordFinder
{
    /// <summary>
    /// Class that will contain the matrix and the methods that handle the data
    /// </summary>
    public class Matrix
    {
        private char[,] _matrix;
        private int _rows;
        private int _columns;

        /// <summary>
        /// Constructor that receives a list of words. Then it creates a matrix of type char[]
        /// </summary>
        /// <param name="matrix"></param>
        /// <exception cref="Exception"></exception>
        public Matrix(IEnumerable<string> matrix)
        {
            var matrixArray = matrix.ToArray();
            int rows = matrixArray.Length;
            int columns = matrixArray.Max(s => s.Length);

            if(columns != matrixArray.Length)
                throw new Exception("Invalid matrix size");

            if (columns<1 || columns>64)
                throw new Exception("Invalid matrix size");

            _matrix = new char[rows, columns];
            _rows = rows;
            _columns = columns;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrixArray[i].Length; j++)
                {
                    _matrix[i, j] = matrixArray[i][j];
                }
            }
        }
        /// <summary>
        /// Returns matrix row length
        /// </summary>
        public int Rows
        {
            get { return _rows; }
        }

        /// <summary>
        /// Returns matrix column length
        /// </summary>
        public int Columns
        {
            get { return _columns; }
        }

       /// <summary>
       /// Returns the row of index "rowIndex" as string
       /// </summary>
       /// <param name="rowIndex"></param>
       /// <returns></returns>
       /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string GetRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= Rows)
                throw new ArgumentOutOfRangeException(nameof(rowIndex), "Row index is out of range.");

            char[] rowData = new char[Columns];
            for (int i = 0; i < Columns; i++)
            {
                rowData[i] = _matrix[rowIndex, i];
            }
            return new String(rowData);
        }
        /// <summary>
        /// Returns the column of index "columnIndex" as string
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string GetColumn(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= Columns)
                throw new ArgumentOutOfRangeException(nameof(columnIndex), "Column index is out of range.");

            char[] columnData = new char[Rows];
            for (int i = 0; i < Rows; i++)
            {
                columnData[i] = _matrix[i, columnIndex];
            }
            return new String(columnData);
        }

    }

}
