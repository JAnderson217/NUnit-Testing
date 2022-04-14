using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Circle : IShape
    {
        public double radius { get; set; }
        public double Area()
        {
            return Math.PI * Math.Pow(radius, 2); 
        }
        public double perimeter()
        {
            return 2 * Math.PI * radius;
        }
    }
}
