using ImageAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_API_Executable
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Start...");

            //Must provide full path with picture name and extension (e.g C:\\User\\username\\Desktop\\image.jpg)
            Context ctx = new Context("C:\\Users\\pc\\Desktop\\gal.jpg", "C:\\Users\\pc\\Desktop\\galresized.jpg", "Resize", 800, 600);
            ctx.Initialize();
            Console.WriteLine("Function completed succesfully!");
            Console.WriteLine("**********");
            Console.WriteLine();

            Context ctx2 = new Context("C:\\Users\\pc\\Desktop\\gal.jpg", "C:\\Users\\pc\\Desktop\\galPNG.png", "PNG");
            ctx2.Initialize();
            Console.WriteLine("Function completed succesfully!");
            Console.WriteLine("**********");
            Console.WriteLine();

            //Context ctx3 = new Context("C:\\Users\\pc\\Desktop\\gal.jpg", "C:\\Users\\pc\\Desktop\\galresized.jpg", "Crop", 800, 600);
            //ctx3.Initialize();

            //Context ctx4 = new Context("C:\\Users\\pc\\Desktop\\gal.jpg", "C:\\Users\\pc\\Desktop\\galresized.jpg", "Skew", 0, 1, 2, 3, 4, 5, 6, 7,8);
            //ctx4.Initialize();

        }
    }
}
