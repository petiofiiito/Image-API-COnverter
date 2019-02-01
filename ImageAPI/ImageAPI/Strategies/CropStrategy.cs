using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAPI.Strategies
{
    internal class CropStrategy:IEditStrategy
    {

        private int width, height;

        public CropStrategy( int width, int height)
        {
            this.width = width;
            this.height = height;
        }


        public void Edit (string sourcePath, string destinationPath)
        {

            //Cropping image strategy
            //Uses an image from  sourcePath
            //Crops the image and creates a new image 
            //Using the graphics library it does a high quality cropping
            //This class uses sourcePath(string), width(int), height(int) and destinationPath(string)


            try
            {
                //ImageClass img = new ImageClass();
                ////Must provide full path with picture name and extension (e.g C:/Desktop/image.jpg)
                //Console.WriteLine("Enter source path: ");
                //img.Source = Console.ReadLine();
                ////Width and height are simple integers, px not needed after the digit
                //Console.WriteLine("Enter desired width: ");
                //int width = int.Parse(Console.ReadLine());
                //Console.WriteLine("Enter desired height: ");
                //int height = int.Parse(Console.ReadLine());
                ////Must provide full path with picture name and extension (e.g C:/Desktop/image.jpg)
                //Console.WriteLine("Enter desired location to store file: ");
                //img.DestinationPath = Console.ReadLine();




                //Creating a new bitmap
                Bitmap bmp = new Bitmap(sourcePath);
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);

                //Setting the desired width and height for the new image
                destImage.SetResolution(width, height);

                //High image quality resizing
                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(bmp, destRect, 0, 0, width, height, GraphicsUnit.Pixel, wrapMode);
                    }
                }

                destImage.Save(destinationPath);
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
