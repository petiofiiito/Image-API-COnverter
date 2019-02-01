using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAPI.Strategies
{
    internal class ConvertPNGStrategy:IEditStrategy
    {
        //The convert strategy takes an image from sourcePath and by using the System.Drawing library
        //coverts the type of the image to the desired one 
        //This class uses sourcePath and destinationPath  

        public void Edit(string sourcePath, string destinationPath)
        {

            try
            {

                // Load the image.
                Image image1 = Image.FromFile(sourcePath);
                image1.Save(destinationPath, ImageFormat.Png);
                Console.WriteLine("Converting to PNG...");

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
