using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_2
{
    public interface IIndexable<T>
    {
        T this[int index] { get; set;  }
    }
    public interface IMatrix<T>
    {
        T this[int column, int row] { get; set; }

        void PrintMatrix();

    }
   
}
