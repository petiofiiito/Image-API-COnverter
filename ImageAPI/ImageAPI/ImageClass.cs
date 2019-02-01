using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAPI
{
    public class ImageClass
    {
        //Image class
        //Helper class for input and storage of the image variables in case of format exceptions

        public string Source { get; set; }
        public string DestinationPath { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Type { get; set; }

    }
}
