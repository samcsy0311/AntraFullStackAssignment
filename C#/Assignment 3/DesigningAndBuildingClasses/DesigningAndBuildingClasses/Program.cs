using System;

namespace DesigningAndBuildingClasses
{
     class Program
     {
          static void Main(string[] args)
          {
               BallAndColor();

               CustomerAndOrder();
          }

          static void BallAndColor ()
          {
               Ball ball1 = new Ball(3.0);
               Ball ball2 = new Ball(4.0);
               Ball ball3 = new Ball(5.0);

               for (int i = 0; i <= 4; ++i)
               {
                    ball1.ThrowBall();
                    if (i % 2 == 0)
                    {
                         ball2.ThrowBall();
                    }
                    else
                    {
                         ball3.ThrowBall();
                    }
               }

               ball1.Pop();
               ball1.ThrowBall();

               Console.WriteLine("Number of throws for Ball 1: " + ball1.getNumOfThrows());
               Console.WriteLine("Number of throws for Ball 2: " + ball2.getNumOfThrows());
               Console.WriteLine("Number of throws for Ball 3: " + ball3.getNumOfThrows());
          }

          static void CustomerAndOrder()
          {
               Customer c1 = new Customer("Sam", "Smith", "samsmith@gmail.com");
               Order o1 = new Order(new Guid());
               Order o2 = new Order(new Guid(), "Happy meal", 2, DateTime.Today);
               c1.addOrder(o1);
               c1.addOrder(o2);

               Console.WriteLine("Prininting customer " + c1.getName() + "'s history");
               c1.printHistory();
               c1.addOrder(null);

               Console.WriteLine("Order date of " + o2.OrderDetails + ": " + o2.OrderDate);
               o1.setOrderDate(DateTime.Today.AddDays(10));
               o1.OrderDetails = "Hello";
               Console.WriteLine("Order date of " + o1.OrderDetails + ": " + o1.OrderDate);
          }
     }
}
