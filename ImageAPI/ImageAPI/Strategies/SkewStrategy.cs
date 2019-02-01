using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ImageAPI.Strategies;
using QuadrilateralDistortion;
using System.IO;

namespace ImageAPI.Strategies
{
    internal class SkewStrategy:IEditStrategy
    {

        private int x1, x2, x3, x4, y1, y2, y3, y4;

        public SkewStrategy(int x1, int x2, int x3, int x4, int y1, int y2, int y3, int y4)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.y1 = y1;
            this.y2 = y2;
            this.y3 = y3;
            this.y4 = y4;
        }

        public void Edit(string sourcePath, string destinationPath)
        {
            //Skewing strategy
            //By using 4(X,Y) Points from user input it distorts the image with those coordinates 
            //using the QuadDistort additional class
            //This class uses source(string), 4 Points(int X, int Y) and destinationPath(string) as user inputs 

            try
            {
                
                Point topLeft = new Point(x1 , y1);
                Point topRight = new Point(x2, y2);
                Point bottomLeft = new Point(x3, y3);
                Point bottomRight = new Point(x4, y4);

                //Transofrming image to a Bitmap to use QuadDistort function
                Image imgPhoto = Image.FromFile(sourcePath);
                Bitmap transitionBmp = (Bitmap)imgPhoto;

                //Additional function that distorts image 
                Bitmap bmp = QuadDistort.Distort(transitionBmp, topLeft, topRight, bottomLeft, bottomRight);
                bmp.Save(destinationPath);
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("The specified file could not be found!");
                Console.WriteLine();
            }
            catch (FileLoadException)
            {
                Console.WriteLine("File could not be loaded!");
                Console.WriteLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry, that is not a valid format!");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("File name is too long!");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong...");
            }
        }

    }
}
