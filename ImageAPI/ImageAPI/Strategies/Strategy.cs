using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAPI.Strategies
{
    //Strategy interface that every strategy implements
    //It has a void function Edit(); that every class should implement also
    public interface IEditStrategy
    {
        void Edit(string sourcePath, string destinationPath);
    }
}
