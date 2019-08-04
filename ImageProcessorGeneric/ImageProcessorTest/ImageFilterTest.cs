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

        [TestMethod]
        public void ImageFilter_Mul_PredifenedData()
        {
            IFilterImage filter = new ImageFilter();

            //long sum = filter.Sum(3, 4);

            //Assert.AreEqual(sum, 7);

            //List<ImageFilter_Mul> results = ImageFilterDAO.GetDataForImageFilter_Mul();

            var results = ImageFilterDAO.GetDataForImageFilter_Generic(
                (reader, records) =>
                {
                    records.Add(new
                    {
                        A = (long)reader.GetValue(1), // A
                        B = (long)reader.GetValue(2), // B
                        C = (long)reader.GetValue(3), // C
                        Result = (long)reader.GetValue(4) // Result
                    });
                }, "ImageFilter_Mul");

            foreach (var r in results)
            {
                long a = ((dynamic)r).A;
                long b = ((dynamic)r).B;
                long c = ((dynamic)r).C;
                long expectedResult = ((dynamic)r).Result;
                long result = filter.Mul(a, b, c);

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}
