using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPractice
{
     class MyStack<T>
     {
          private int count;
          private LinkedList<T> item;
          int Count()
          {
               return count;
          }

          T Pop()
          {
               T firstItem = item.First.Value;
               item.RemoveFirst();
               count--;
               return firstItem;
          }
          void Push(T newItem)
          {
               item.AddFirst(newItem);
               count++;
          }
     }
}
