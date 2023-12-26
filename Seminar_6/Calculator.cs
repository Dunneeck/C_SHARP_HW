using Seminar_6;
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
        public double result = 0;
        private Stack<double> results = new Stack<double>();
        private Stack <CalcActionLog> actions = new Stack<CalcActionLog>();

        public void Divide(int value)
        {
            if(value == 0)
            {
                actions.Push(new CalcActionLog(CalcAction.Divide, value));
                throw new CalculatorDivideByZeroException("деление на 0", actions);
            }
            else
            {
                results.Push(result);
                result /= value;
                RaiseEvent();
            }

            
        }
        public void Divide(double value)
        {
            if (value == 0)
            {
                actions.Push(new CalcActionLog(CalcAction.Divide, value));
                throw new CalculatorDivideByZeroException("деление на 0", actions);
            }
            else
            {
                results.Push(result);
                result /= value;
                RaiseEvent();
            }


        }

        public void Multiply(int value)
        {
            try
            {
                actions.Push(new CalcActionLog(CalcAction.Multiply, value));
                double tmp = checked(result * value);
                results.Push(result);
                result *= value;
                RaiseEvent();
            }
            catch (OverflowException e) {
                throw new CalculateOperationCauseOverflowException("Превышен лимит " + e.Message, actions);
            }
            
        }
        public void Multiply(double value)
        {
            try
            {
                actions.Push(new CalcActionLog(CalcAction.Multiply, value));
                double tmp = checked(result * value);
                results.Push(result);
                result *= value;
                RaiseEvent();
            }
            catch (OverflowException e)
            {
                throw new CalculateOperationCauseOverflowException("Превышен лимит " + e.Message, actions);
            }

        }

        public void Substuct(int value)
        {
            try
            {
                actions.Push(new CalcActionLog(CalcAction.Multiply, value));
                double tmp = checked(result - value);
                results.Push(result);
                result -= value;
                RaiseEvent();
            }
            catch (OverflowException e)
            {
                throw new CalculateOperationCauseOverflowException("Превышен лимит " + e.Message, actions);
            }
        }
        public void Substuct(double value)
        {
            try
            {
                actions.Push(new CalcActionLog(CalcAction.Multiply, value));
                double tmp = checked(result - value);
                results.Push(result);
                result -= value;
                RaiseEvent();
            }
            catch (OverflowException e)
            {
                throw new CalculateOperationCauseOverflowException("Превышен лимит " + e.Message, actions);
            }
        }

        public void Sum(int value)
        {
            try
            {
                actions.Push(new CalcActionLog(CalcAction.Multiply, value));
                double tmp = checked(result + value);
                results.Push(result);
                result += value;
                RaiseEvent();
            }
            catch (OverflowException e)
            {
                throw new CalculateOperationCauseOverflowException("Превышен лимит " + e.Message, actions);
            }
        }
        public void Sum(double value)
        {
            try
            {
                actions.Push(new CalcActionLog(CalcAction.Multiply, value));
                double tmp = checked(result + value);
                results.Push(result);
                result += value;
                RaiseEvent();
            }
            catch (OverflowException e)
            {
                throw new CalculateOperationCauseOverflowException("Превышен лимит " + e.Message, actions);
            }
        }
        public void CancelLast()
        {
            if( results.Count > 0 ) {
                result = results.Pop();
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
