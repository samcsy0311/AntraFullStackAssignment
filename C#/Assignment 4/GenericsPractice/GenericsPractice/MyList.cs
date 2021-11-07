using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPractice
{
     class MyList<T>
     {
          private T[] items;
          private int count;

          public MyList () {
               items = new T[0];
               count = 0;
          }
          public void Add(T element)
          {
               T[] newItem = new T[count + 1];
               for (int i = 0; i < count; ++i)
               {
                    newItem[i] = items[i];
               }
               newItem[count + 1] = element;
               count++;
               items = (T[])newItem.Clone();
          }
          public T Remove(int index)
          {
               T[] newItem = new T[count - 1];
               T removeItem = items[index];

               for (int i = 0; i < count; i++)
               {
                    if (i != index)
                    {
                         newItem[i] = items[i];
                    }
               }
               count--;
               items = (T[])newItem.Clone();
               return removeItem;
          }

          public bool Contains(T element)
          {
               for (int i = 0; i < count; i++)
               {
                    if (items[i].Equals(element))
                    {
                         return true;
                    }
               }
               return false;
          }

          public void Clear()
          {
               items = new T[0];
          }

          public void InsertAt(T element, int index)
          {
               T[] newItem = new T[count + 1];
               for (int i = 0; i < count + 1; ++i)
               {
                    if (i != index)
                         newItem[i] = items[i];
                    else
                         newItem[i] = element;
               }
               count++;
               items = (T[])newItem.Clone();
          }

          // I am not sure what's the difference between this and remove
          public void DeleteAt (int index)
          {
               Remove(index);
          }

          public T Find(int index)
          {
               return items[index];
          }
     }
}
