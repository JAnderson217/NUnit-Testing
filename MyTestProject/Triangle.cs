using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Triangle
    {
        public double sideOne { get; set; }
        public double sideTwo { get; set; }
        public double sideThree { get; set; }
        public double Area() { 
            return Math.Sqrt(perimeter()/2 * (perimeter() / 2 - sideOne) * (perimeter() / 2 - sideTwo) * (perimeter() / 2 - sideThree)); ; 
        }
        public double perimeter() { return sideOne+sideTwo+sideThree; }
    }
}
