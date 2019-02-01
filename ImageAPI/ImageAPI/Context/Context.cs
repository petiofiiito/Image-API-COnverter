using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using ImageAPI.Strategies;

namespace ImageAPI
{
    public class Context
    {
        //Beginning point of the dll
        //The context class switches between strategies ,based on the given function
        
        private string sourcePath;
        private string destinationPath;
        private string function;

        //--Start of variables used by SkewStrategy for Point
        private int x1;
        private int x2;
        private int x3;
        private int x4;
        private int y1;
        private int y2;
        private int y3;
        private int y4;
        //-- End of varuables used by SkewStrategy


        private int width;
        private int height;

        //Constructor for ConvertPNGStrategy, ConvertJPGStrategy, ConvertGIFStrategy
        public Context(string sourcePath, string destinationPath, string function)
        {
            this.sourcePath = sourcePath;
            this.destinationPath = destinationPath;
            this.function = function;
        }


        //Constructor For CropStrategy and ResieKARStrategy
        public Context(string sourcePath, string destionationPath, string function, int width, int height)
        {
            this.sourcePath = sourcePath;
            this.destinationPath = destionationPath;
            this.function = function;
            this.width = width;
            this.height = height;
        }

        //Constructor For SkewStrategy
        public Context(string sourcePath, string destionationPath, string function, int x1, int x2, int x3, int x4, int y1, int y2, int y3, int y4, int width, int height)
        {
            this.sourcePath = sourcePath;
            this.destinationPath = destionationPath;
            this.function = function;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.y1 = y1;
            this.y2 = y2;
            this.y3 = y3;
            this.y4 = y4;
            this.width = width;
            this.height = height;
        }

        public void Initialize()
        {
            switch (function)
            {

                case "Resize":
                    //this.strategy = new ResizedStrategy(this.x, this.y, this.width, this.height);
                    ResizeKARStrategy rs = new ResizeKARStrategy(this.width, this.height);
                    rs.Edit(this.sourcePath, this.destinationPath);
                    Console.WriteLine("Done!");
                    Console.WriteLine();
                    break;

                case "PNG":
                    ConvertPNGStrategy cs1 = new ConvertPNGStrategy();
                    cs1.Edit(this.sourcePath, this.destinationPath);
                    Console.WriteLine("Done!");
                    Console.WriteLine();
                    break;

                case "JPEG":
                    ConvertJPGStrategy cs2 = new ConvertJPGStrategy();
                    cs2.Edit(this.sourcePath, this.destinationPath);
                    Console.WriteLine("Done!");
                    Console.WriteLine();
                    break;

                case "GIF":
                    ConvertGIFStrategy cs3 = new ConvertGIFStrategy();
                    cs3.Edit(this.sourcePath, this.destinationPath);
                    Console.WriteLine("Done!");
                    Console.WriteLine();
                    break;

                case "Skew":
                    SkewStrategy ss = new SkewStrategy(this.x1, this.x2, this.x3, this.x4, this.y1, this.y2, this.y3, this.y4);
                    ss.Edit(this.sourcePath, this.destinationPath);
                    Console.WriteLine("Done!");
                    Console.WriteLine();
                    break;

                case "Crop":
                    CropStrategy crs = new CropStrategy(this.width, this.height);
                    crs.Edit(this.sourcePath, this.destinationPath);
                    Console.WriteLine("Done!");
                    Console.WriteLine();
                    break;
            }
        }






    }
	
}
