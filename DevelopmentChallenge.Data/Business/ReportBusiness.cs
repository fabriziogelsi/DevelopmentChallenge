using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Enums;

namespace DevelopmentChallenge.Data.Business
{
    public static class ReportBusiness
    {
        /// <summary>
        /// Recibe un listado de formas para generar el reporte en base al idioma recibido
        /// </summary>
        /// <param name="Shapes">Listado de formas</param>
        /// <param name="Language">Language de impresión</param>
        /// <returns>Reporte como string</returns>
        public static string Print(List<GeometricShape> Shapes, Language Language)
        {
            SetCurrentCultureInfo(Language);
            StringBuilder Sb = new StringBuilder();

            if (!Shapes.Any())
            {
                Sb.Append("<h1>" + Resources.ListaVacia + "</h1>");
            }
            else
            {
                Sb.Append("<h1>" + Resources.ReporteFormas + "</h1>");

                Dictionary<Shape, int> shapeCounts = new Dictionary<Shape, int>();
                Dictionary<Shape, decimal> shapeAreas = new Dictionary<Shape, decimal>();
                Dictionary<Shape, decimal> shapePerimeters = new Dictionary<Shape, decimal>();

                foreach (var shape in Shapes)
                {
                    if (!shapeCounts.ContainsKey(shape.SHAPE))
                    {
                        shapeCounts[shape.SHAPE] = 0;
                        shapeAreas[shape.SHAPE] = 0m;
                        shapePerimeters[shape.SHAPE] = 0m;
                    }

                    shapeCounts[shape.SHAPE]++;
                    shapeAreas[shape.SHAPE] += shape.CalculateArea();
                    shapePerimeters[shape.SHAPE] += shape.CalculatePerimeter();
                }

                foreach (Shape shape in shapeCounts.Keys)
                {
                    Sb.Append(ObtenerLinea(shapeCounts[shape], shapeAreas[shape], shapePerimeters[shape], shape));
                }

                // FOOTER
                Sb.Append(Resources.Total + "<br/>");
                Sb.Append(shapeCounts.Values.Sum() + " " + Resources.Formas + " ");
                Sb.Append(Resources.Perimetro + " " + shapePerimeters.Values.Sum().ToString("#.##") + " ");
                Sb.Append("Area " + shapeAreas.Values.Sum().ToString("#.##"));
            }

            return Sb.ToString();
        }

        private static string ObtenerLinea(int sumOfShapes, decimal area, decimal perimeter, Shape type)
        {
            return sumOfShapes > 0
                ? $"{sumOfShapes} {TraducirForma(type, sumOfShapes)} | " + Resources.Area + $" {area:#.##} | " + Resources.Perimetro + $" {perimeter:#.##} <br/>"
                : string.Empty;
        }

        private static string TraducirForma(Shape type, int sumOfShapes)
        {
            switch (type)
            {
                case Shape.SQUARE:
                    return sumOfShapes == 1 ? Resources.Cuadrado : Resources.Cuadrados;
                case Shape.CIRCLE:
                    return sumOfShapes == 1 ? Resources.Circulo : Resources.Circulos;
                case Shape.TRIANGLE:
                    return sumOfShapes == 1 ? Resources.Triangulo : Resources.Triangulos;
                case Shape.TRAPEZE:
                    return sumOfShapes == 1 ? Resources.Trapecio : Resources.Trapecios;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Setea la cultureInfo para seleccionar el idioma.
        /// IMPORTANTE: Este helper se construyó sólo a modo de ejemplo, porque el proyecto original es acotado
        /// y para no alargar mucho la tarea, pero digamos que en algo que estuvieramos haciendo real, tal vez utilizaría
        /// un approach de por ejemplo, mediante el middleware identificar el idioma de quien nos está realizando la solicitud
        /// y en base a eso directamente ya se usa el resource correspondiente.
        /// </summary>
        /// <param name="Language">Idioma a establecer para el culture</param>
        private static void SetCurrentCultureInfo(Language Language)
        {
            switch (Language)
            {
                case Language.SPANISH:
                    CultureInfo.CurrentCulture = new CultureInfo("es-AR");
                    CultureInfo.CurrentUICulture = new CultureInfo("es-AR");
                    break;
                case Language.ENGLISH:
                    CultureInfo.CurrentCulture = new CultureInfo("es-AR"); //Sino sale . en lugar de , en cálculos (números)
                    CultureInfo.CurrentUICulture = new CultureInfo("en-US");
                    break;
                case Language.ITALIAN:
                    CultureInfo.CurrentCulture = new CultureInfo("it-IT");
                    CultureInfo.CurrentUICulture = new CultureInfo("it-IT");
                    break;
                default:
                    CultureInfo.CurrentCulture = new CultureInfo("en-US");
                    CultureInfo.CurrentUICulture = new CultureInfo("en-US");
                    break;
            }
        }
    }
}
