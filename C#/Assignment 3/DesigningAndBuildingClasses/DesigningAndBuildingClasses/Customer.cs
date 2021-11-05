using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningAndBuildingClasses
{
     class Customer
     {
          private string firstName { set; get; }
          private string lastName { set; get; }
          private readonly string name;
          private string email { set; get; }
          private List<Order> history { set; get; }

          public Customer (string firstName, string lastName, string email)
          {
               this.firstName = firstName;
               this.lastName = lastName;
               this.email = email;
               this.name = firstName + " " + lastName;
               history = new List<Order>();
          }

          public string getName()
          {
               return name;
          }

          public void addOrder(Order o)
          {
               if (o == null)
               {
                    throw new ArgumentNullException("object is null");
               }
               history.Add(o);
          }

          public void printHistory()
          {
               foreach(Order o in history)
               {
                    o.printDetails();
               }
          }
     }
}
