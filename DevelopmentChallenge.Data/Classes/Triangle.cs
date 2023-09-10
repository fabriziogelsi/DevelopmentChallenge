using Enums;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Triangle : GeometricShape
    {
        private readonly decimal Side;

        public Triangle(decimal side)
        {
            Side = side;
            SHAPE = Shape.TRIANGLE;
        }

        public override decimal CalculateArea()
        {
            return (decimal)Math.Sqrt(3) / 4 * Side * Side;
        }

        public override decimal CalculatePerimeter()
        {
            return Side * 3;
        }
    }
}
