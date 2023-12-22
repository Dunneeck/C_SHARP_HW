using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_5
{
    internal class Calculator : ICalc
    {
        public event EventHandler<EventArgs> GotResult;
        public int Result = 0;
        private Stack<int> Results = new Stack<int>();

        public void Divide(int value)
        {
            Results.Push(Result);
            Result /= value;
            RaiseEvent();
        }

        public void Multiply(int value)
        {
            Results.Push(Result);
            Result *= value;
            RaiseEvent();
        }

        public void Substuct(int value)
        {
            Results.Push(Result);
            Result -= value;
            RaiseEvent();
        }

        public void Sum(int value)
        {
            Results.Push(Result);
            Result += value;
            RaiseEvent();
        }
        public void CancelLast()
        {
            if( Results.Count > 0 ) {
                Result = Results.Pop();
                RaiseEvent();               
            }
            
        }
        public int SumNums(List<int> list, Func<int,int,int> operation)
        {
            int sum = 0;
            foreach( int item in list )
            {
                sum = operation(item, sum);
            }
            return sum;
        }
        private void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }

    }
}
