// 快速排序法

using System;
using System.Collections.Generic;
using System.Linq;

namespace QS
{ 
    class Program
    {
        static void Main(string[] args)
        {
            List<int> s = new List<int>();

            s.Add(391);
            s.Add(43);
            s.Add(74);
            s.Add(32);
            s.Add(94);
            s.Add(563);
            s.Add(54);
            s.Add(726);
            s.Add(84);
            s.Add(55);
            s.Add(96);
            s.Add(132);
            s.Add(531);
            s.Add(652);
            s.Add(456);

            
            QuickSort qs=new QuickSort(s);
            IEnumerable<int> t= qs.Sort();
            foreach (var item in t)
            {
                Console.WriteLine("{0:000}", item);
            }
            Console.ReadLine();
        }
    }

    public class QuickSort
    {
        private IEnumerable<int> _num = null;

        public QuickSort(IEnumerable<int> num)
        {
            this._num = num;
        }
        public IEnumerable<int> Sort()
        {
            int[] result = this._num.ToArray();
            SortInternal(ref result, 0, this._num.Count() - 1);
            return result;
        }
        public void SortInternal(ref int[] s, int P_left, int P_Right)
        {
            if (P_left < P_Right)
            {
                int num = P_left;
                int num2 = P_Right + 1;
                while (true)
                {
                    while (num + 1 < s.Length && s[++num] < s[P_left])
                    {
                    }
                    while (num2 - 1 > -1 && s[--num2] > s[P_left])
                    {
                    }
                    if (num >= num2)
                    {
                        break;
                    }
                    this.Swap(ref s[num], ref s[num2]);
                }
                this.Swap(ref s[P_left], ref s[num2]);
                this.SortInternal(ref s, P_left, num2 - 1);
                this.SortInternal(ref s, num2 + 1, P_Right);
            }
        }

        public void Swap(ref int X, ref int Y)
        {
            int num = Y;
            Y = X;
            X = num;
        }
    }
}