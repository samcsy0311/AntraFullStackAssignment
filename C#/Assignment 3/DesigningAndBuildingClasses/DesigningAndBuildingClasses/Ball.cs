using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningAndBuildingClasses
{
     class Ball
     {
          private Color color;
          private double size;
          private int numOfThrows;

          public Ball (Color color, double size)
          {
               this.color = color;
               this.size = size;
               this.numOfThrows = 0;
          }

          public Ball (double size)
          {
               this.color = new Color(0, 0, 0);
               this.size = size;
               this.numOfThrows = 0;
          }

          public void Pop ()
          {
               this.size = 0;
          }

          public void ThrowBall ()
          {
               if (size != 0)
               {
                    numOfThrows++;
               }
          }

          public int getNumOfThrows ()
          {
               return numOfThrows;
          }
     }
}
