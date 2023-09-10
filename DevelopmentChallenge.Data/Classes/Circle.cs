using Enums;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circle : GeometricShape
    {
        private readonly decimal Radius;

        public Circle(decimal radius)
        {
            Radius = radius;
            SHAPE = Shape.CIRCLE;
        }

        public override decimal CalculateArea()
        {
            return (decimal)Math.PI * (Radius / 2) * (Radius / 2);
        }

        public override decimal CalculatePerimeter()
        {
            return (decimal)Math.PI * Radius;
        }
    }
}
