using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_2;

internal class Collection<T> : IIndexable<T>
{
    private T[] array;
    public T this[int index]
    {
        get => array[index];
        set => array[index] = value;
    }

    public Collection(int size)
    {
        array = new T[size];
    }
}
public class Matrix<T> : IMatrix<T>
{
    private T[,] matrix;
    public T this[int column, int row]
    {
        get => matrix[column, row]; 
        set => matrix[column, row] = value;
    }
    public Matrix(int column, int row)
    {
        matrix = new T[column, row];
    }
    public void PrintMatrix()
    {
        for (int i = 0; i < matrix.GetLongLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLongLength(1); j++)
            {
                Console.Write(matrix[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
}

