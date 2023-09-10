using Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class GeometricShape
    {
        private Shape Shape;
        
        /// <summary>
        /// La propiedad Shape se utiliza para determinar el tipo de figura geométrica que es
        /// </summary>
        public Shape SHAPE
        {
            get { return Shape; }
            set { Shape = value; }
        }

        /// <summary>
        /// Calcula el área de la forma y la retorna como decimal
        /// </summary>
        /// <returns>Área</returns>
        public abstract decimal CalculateArea();

        /// <summary>
        /// Calcula el perímetro de la forma y lo retorna como decimal
        /// </summary>
        /// <returns>Perímetro</returns>
        public abstract decimal CalculatePerimeter();
    }
}
