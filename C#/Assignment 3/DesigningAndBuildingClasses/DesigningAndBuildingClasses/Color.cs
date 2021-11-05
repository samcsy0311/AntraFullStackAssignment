using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningAndBuildingClasses
{
     class Color
     {
          private byte red { get; set; }
          private byte green { get; set; }
          private byte blue { get; set; }
          private byte alpha { get; set; }

          public Color (byte red, byte green, byte blue, byte alpha)
          {
               this.red = red;
               this.green = green;
               this.blue = blue;
               this.alpha = alpha;
          }

          public Color (byte red, byte green, byte blue)
          {
               this.red = red;
               this.green = green;
               this.blue = blue;
               alpha = 255;
          }

          public double getGrayScale ()
          {
               return (red + green + blue) / 3;
          }
     }
}
