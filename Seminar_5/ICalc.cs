using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_5;

    internal interface ICalc
    {
    event EventHandler<EventArgs> GotResult;
    void Sum(int value);
    void Substuct(int value);
    void Multiply(int value);
    void Divide(int value);
    void CancelLast();
    int SumNums(List<int> list, Func<int, int, int> operation);

    }

