using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningAndBuildingClasses
{
     class Order
     {
          private readonly Guid orderNumber;
          private string orderDetails;
          private int quantity { set; get; }
          private DateTime orderDate;

          public Order (Guid orderNumber)
          {
               this.orderNumber = orderNumber;
               this.orderDetails = "";
               this.quantity = 1;
               this.orderDate = DateTime.Today;
          }
          public Order(Guid orderNumber, string orderDetails, int quantity, DateTime orderDate)
          {
               this.orderNumber = orderNumber;
               this.orderDetails = orderDetails;
               this.quantity = quantity;
               this.orderDate = orderDate;
          }

          public string OrderDetails
          {
               get { return orderDetails; }
               set { orderDetails = value; }
          }

          public DateTime OrderDate
          {
               get { return orderDate; }
               set { orderDate = value; }
          }

          public Guid getId ()
          {
               return orderNumber;
          }

          public void printDetails()
          {
               Console.WriteLine("Number: " + orderNumber + "\t Details: " + orderDetails);
               Console.WriteLine("Quantity: " + quantity + "\t Order date: " + orderDate);
               Console.WriteLine();
          }

          public void replace (string details, int quantity, DateTime date)
          {
               this.orderDetails = details;
               this.quantity = quantity;
               this.orderDate = orderDate;
          }

          public void setOrderDate (DateTime date)
          {
               if (date <= DateTime.Today)
               {
                    this.orderDate = date;
               }
          }
     }
}
