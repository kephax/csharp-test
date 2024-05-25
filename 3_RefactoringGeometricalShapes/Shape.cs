/**
* Refactor the Shape class to respect object orientation principles. What happens if a new language needs to be supported
* such as French, or if we need to support more shapes?
*
* You can make any change you see fit, in code or tests.
*/

using System;
using System.Collections.Generic;

namespace RefactoringGeometricalShapes
{
  public class Shape
  {
        //TODO add more shapes if needed
        public static Dictionary<string, int> shapes_list = new Dictionary<string, int>()
        {
            { "SQUARE", 1 },
            { "CIRCLE", 2 },
            { "EQUILATERAL_TRIANGLE",3 }
        };

    //public const int SQUARE = 1;
    //public const int CIRCLE = 2;
    //public const int EQUILATERAL_TRIANGLE = 3;

    public static int EN = 1;
    public static int IT = 2;

    /**
   * The shape's immutable width.
   */
    private readonly double width;
    public int type = -1;

    /**
   * Constructs a new Shape with the specified width
   *
   * @param type the type of the shape (SQUARE/CIRCLE/EQUILATERAL_TRIANGLE).
   * @param width the width of the shape
   */

    public Shape(int type, double width)
    {
      this.type = type;
      this.width = width;
    }

    /**
   * This method generates a HTML string used to be displayed as a web page
   * The generated string depends on the language of the user
   *
   * @param shapes
   * @param userLanguage
   * @return html
   *
   */

    public static String prettyPrint(List<Shape> shapes, int userLanguage)
    {
            String returnString = "";

            if(shapes.Count == 0 )
            {
                // test list is empty

                // default is dutch
                returnString = "<h1>Lege lijst van vormen!</h1>";
                if (userLanguage == EN)
                {
                    returnString = "<h1>Empty list of shapes!</h1>";
                }
                else if (userLanguage == IT)
                {
                    returnString = "<h1>Lista vuota</h1>";
                }

                return returnString;
            }

            //we have shapes
            //header

            // default is dutch
            returnString += "<h1>Samenvatting vormen</h1><br/>";

            if (userLanguage == EN)
            {
                returnString += "<h1>Shapes report</h1><br/>";
            }
            else if( userLanguage == IT )
            {
                returnString += "<h1>Sintesi forme</h1><br/>";
            }

            int numberSquares = 0;
            int numberCircles = 0;
            int numberTriangles = 0;

            double areaSquares = 0;
            double areaCircles = 0;
            double areaTriangles = 0;

            double perimeterSquares = 0;
            double perimeterCircles = 0;
            double perimeterTriangles = 0;

            //compute numbers
            for (int i = 0; i < shapes_list.Count; i++)
            {
                var x = shapes_list["SQUARE"];
                if (shapes[i].type == shapes_list["SQUARE"])
                {
                    numberSquares++;
                    areaSquares += shapes[i].getArea();
                    perimeterSquares += shapes[i].getPerimeter();
                }
                if (shapes[i].type == shapes_list["CIRCLE"])
                {
                numberCircles++;
                areaCircles += shapes[i].getArea();
                perimeterCircles += shapes[i].getPerimeter();
                }
                if (shapes[i].type == shapes_list["EQUILATERAL_TRIANGLE"])
                {
                numberTriangles++;
                areaTriangles += shapes[i].getArea();
                perimeterTriangles += shapes[i].getPerimeter();
                }
            }

            //let`s print this
            returnString += getLine(numberSquares, areaSquares, perimeterSquares, shapes_list["SQUARE"], userLanguage);
            returnString += getLine(numberCircles, areaCircles, perimeterCircles, shapes_list["CIRCLE"], userLanguage);
            returnString += getLine(numberTriangles, areaTriangles, perimeterTriangles, shapes_list["EQUILATERAL_TRIANGLE"], userLanguage);

            //footer
            returnString += "TOTAL:<br/>";
            returnString += (numberCircles + numberSquares + numberTriangles) + " " +
                            (userLanguage == EN ? "shapes" : "vormen") + " ";
            returnString += (userLanguage == EN ? "Perimeter " : "Omtrek ") +
                            (perimeterCircles + perimeterSquares + perimeterTriangles).ToString("#.##") + " ";
            returnString += (userLanguage == EN ? "Area " : "Oppervlakte ") +
                            (areaCircles + areaSquares + areaTriangles).ToString("#.##");


      return returnString;
    }

    private static String getLine(int numberShapes, double area, double perimeter, int type, int userLanguage)
    {
      if (numberShapes > 0)
      {
        if (userLanguage == EN)
        {
          return numberShapes + " " + translateShape(type, numberShapes, userLanguage) + " Area " + area.ToString("#.##") +
                 " Perimeter " + perimeter.ToString("#.##") + "<br/>";
        }
        return numberShapes + " " + translateShape(type, numberShapes, userLanguage) + " Oppervlakte " + area.ToString("#.##") +
               " Omtrek " + perimeter.ToString("#.##") + "<br/>";
      }
      return "";
    }

    private static String translateShape(int type, int numberShapes, int userLanguage)
    {
        if( shapes_list["SQUARE"] == type)
        {
            if (userLanguage == EN)
            {
                return numberShapes == 1 ? "Square" : "Squares";
            }
            else
            {
                return numberShapes == 1 ? "Vierkant" : "Vierkanten";
            }
        }

        if (shapes_list["CIRCLE"] == type)
        {
            if (userLanguage == EN)
            {
                return numberShapes == 1 ? "Circle" : "Circles";
            }
            else
            {
                return numberShapes == 1 ? "Cirkel" : "Cirkels";
            }
        }

        if (shapes_list["EQUILATERAL_TRIANGLE"] == type)
        {
            if (userLanguage == EN)
            {
                return numberShapes == 1 ? "Triangle" : "Triangles";
            }
            else
            {
                return numberShapes == 1 ? "Driehoek" : "Driehoeken";
            }
        }

        return "";
    }

    /**
   * Returns the width of this Shape in double precision.
   *
   * @return the width of this Shape.
   */

    public double getWidth()
    {
      return width;
    }

        /**
       * Returns the area of this Shape in double precision.
       *
       * @return the area of this Shape.
       */

    public double getArea()
    {
        if (shapes_list["SQUARE"] == type)
        {
            return width * width;
        }

        if (shapes_list["CIRCLE"] == type)
        {
            return Math.PI * (width / 2) * (width / 2);
        }

        if (shapes_list["EQUILATERAL_TRIANGLE"] == type)
        {
            return (Math.Sqrt(3) / 4) * width * width;
        }
        throw new SystemException("Can`t compute area of unknown shape");
    }

        /**
       * Returns the perimeter of this Shape in double precision.
       *
       * @return the perimeter of this Shape.
       */

        public double getPerimeter()
        {
            if (shapes_list["SQUARE"] == type)
            {
                return 4 * width;
            }
            if (shapes_list["CIRCLE"] == type)
            {
                return Math.PI * width;
            }
            if (shapes_list["EQUILATERAL_TRIANGLE"] == type)
            {
                return 3 * width;
            }
              throw new SystemException("Can`t compute area of unknown shape");
    }
  }
}