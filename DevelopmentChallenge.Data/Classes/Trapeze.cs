using Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapeze : GeometricShape
    {
        private readonly decimal MayorBase;
        private readonly decimal MinorBase;
        private readonly decimal Side1;
        private readonly decimal Side2;

        public Trapeze(decimal mayorBase, decimal minorBase, decimal side1, decimal side2)
        {
            MayorBase = mayorBase;
            MinorBase = minorBase;
            Side1 = side1;
            Side2 = side2;
            SHAPE = Shape.TRAPEZE;
        }

        public override decimal CalculateArea()
        {
            return (decimal)0.5 * (MayorBase + MinorBase) * Side1;
        }


        public override decimal CalculatePerimeter()
        {
            return MayorBase + MinorBase + Side1 + Side2;
        }
    }
}
