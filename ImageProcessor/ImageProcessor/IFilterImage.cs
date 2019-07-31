using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor
{
    public interface IFilterImage
    {
        long Sum(long a, long b);
    }
}
