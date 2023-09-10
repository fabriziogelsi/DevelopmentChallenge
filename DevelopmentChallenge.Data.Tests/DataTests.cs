using System.Collections.Generic;
using DevelopmentChallenge.Data.Business;
using DevelopmentChallenge.Data.Classes;
using Enums;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ReportBusiness.Print(new List<GeometricShape>(), Language.SPANISH));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ReportBusiness.Print(new List<GeometricShape>(), Language.ENGLISH));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                ReportBusiness.Print(new List<GeometricShape>(), Language.ITALIAN));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            List<GeometricShape> cuadrados = new List<GeometricShape> { new Square(5) };

            string resumen = ReportBusiness.Print(cuadrados, Language.SPANISH);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            List<GeometricShape> cuadrados = new List<GeometricShape>
            {
                new Square(5),
                new Square(1),
                new Square(3)
            };

            string resumen = ReportBusiness.Print(cuadrados, Language.ENGLISH);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapeziosRectangulosEnIngles()
        {
            List<GeometricShape> cuadrados = new List<GeometricShape>
            {
                new Trapeze(5,4,3,3.2m),
                new Trapeze(5,4,3,3.2m)
            };

            string resumen = ReportBusiness.Print(cuadrados, Language.ENGLISH);

            Assert.AreEqual("<h1>Shapes report</h1>2 Trapezoids | Area 27 | Perimeter 30,4 <br/>TOTAL:<br/>2 shapes Perimeter 30,4 Area 27", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            List<GeometricShape> formas = new List<GeometricShape>
            {
                new Square(5),
                new Circle(3),
                new Triangle(4),
                new Square (2),
                new Triangle(9),
                new Circle(2.75m),
                new Triangle(4.2m),
                new Trapeze(5,4,3,3.2m)
            };

            string resumen = ReportBusiness.Print(formas, Language.SPANISH);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>1 Trapecio | Area 13,5 | Perimetro 15,2 <br/>TOTAL:<br/>8 formas Perimetro 112,86 Area 105,15",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnIngles()
        {
            List<GeometricShape> formas = new List<GeometricShape>
            {
                new Square(5),
                new Circle(3),
                new Triangle(4),
                new Square(2),
                new Triangle(9),
                new Circle(2.75m),
                new Triangle(4.2m),
                new Trapeze(5,4,3,3.2m)
            };

            string resumen = ReportBusiness.Print(formas, Language.ENGLISH);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>1 Trapezoid | Area 13,5 | Perimeter 15,2 <br/>TOTAL:<br/>8 shapes Perimeter 112,86 Area 105,15",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            List<GeometricShape> formas = new List<GeometricShape>
            {
                new Square(5),
                new Circle(3),
                new Triangle(4),
                new Square (2),
                new Triangle(9),
                new Circle(2.75m),
                new Triangle(4.2m),
                new Trapeze(5,4,3,3.2m)
            };

            string resumen = ReportBusiness.Print(formas, Language.ITALIAN);

            Assert.AreEqual(
                "<h1>Rapporto sui moduli</h1>2 Piazze | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>1 Trapezio | Area 13,5 | Perimetro 15,2 <br/>TOTAL:<br/>8 forma Perimetro 112,86 Area 105,15",
                resumen);
        }
    }
}
