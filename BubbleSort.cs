//泡沫排序法
 
using System.Collections.Generic;

namespace BSort
{
    public class BubbleSort : ISortable<int>
    {
        private List<int> list = new List<int>();

        public BubbleSort(IEnumerable<int> List)
        {
            this.list=new List<int>(List);
        }
      
        public void Sort()
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (list[j] > list[i])
                    {
                        int temp = list[j];
                        list[j]=list[i];
                        list[i] = temp;
                    }
                }
            }
        }

        public IEnumerable<int> ToList()
        {
            return list;
        }
    }
}