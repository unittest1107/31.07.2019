using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor
{
    public class ImageFilter : IFilterImage
    {
        public long Sum(long a, long b)
        {
            return a + b;
        }
        
        public long Mul(long a, long b, long c)
        {
            return a * b * c;
        }
    }
}
