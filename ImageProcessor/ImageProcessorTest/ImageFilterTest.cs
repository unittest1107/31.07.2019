using System;
using System.Collections.Generic;
using ImageProcessor;
using ImageProcessorTest.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageProcessorTest
{
    [TestClass]
    public class ImageFilterTest
    {
        [TestMethod]
        public void ImageFilter_Add_PredifenedData()
        {
            IFilterImage filter = new ImageFilter();

            //long sum = filter.Sum(3, 4);

            //Assert.AreEqual(sum, 7);

            List<ImageFilter_Sum> results =  ImageFilterDAO.GetDataForImageFilter_Sum();

            foreach (var r in results)
            {
                long sum = filter.Sum(r.A, r.B);

                Assert.AreEqual(sum, r.Sum);
            }

        }
    }
}
