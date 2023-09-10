using Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Square : GeometricShape
    {
        private readonly decimal Side;

        public Square(decimal side)
        {
            Side = side;
            SHAPE = Shape.SQUARE;
        }

        public override decimal CalculateArea()
        {
            return Side * Side;
        }

        public override decimal CalculatePerimeter()
        {
            return Side * 4;
        }
    }
}
