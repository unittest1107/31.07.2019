using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessorTest.DAO
{
    public static class ImageFilterDAO
    {
        public static List<ImageFilter_Sum> GetDataForImageFilter_Sum()
        {
            List<ImageFilter_Sum> records = new List<ImageFilter_Sum>();

            var location = System.IO.Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            // connect to the Data Base
            using (SQLiteConnection con =
                new SQLiteConnection($"Data Source = {location}\\db\\filter.test.db; Version = 3;"))
            {

                // open the connection
                con.Open();

                // create a query (suign the connection)
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * From ImageFilter_Sum ", con))
                {

                    // execut4e the query into the reader
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        // use the reader to read all of the results of the query
                        while (reader.Read())
                        {

                            // pull out the data result using GetValue for dield number
                            //Console.WriteLine(
                            //$"{reader.GetValue(0)} {reader.GetValue(1)} {reader.GetValue(2)} {reader.GetValue(3)} {reader.GetValue(4)}");
                            records.Add(new ImageFilter_Sum
                            {
                                A = (long)reader.GetValue(1), // A
                                B = (long)reader.GetValue(2), // B
                                Sum = (long)reader.GetValue(3) // SUm
                            });

                        }
                    }

                }

                Console.WriteLine();
            }
            return records;
        }

        public static List<ImageFilter_Mul> GetDataForImageFilter_Mul()
        {
            List<ImageFilter_Mul> records = new List<ImageFilter_Mul>();

            var location = System.IO.Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            // connect to the Data Base
            using (SQLiteConnection con =
                new SQLiteConnection($"Data Source = {location}\\db\\filter.test.db; Version = 3;"))
            {

                // open the connection
                con.Open();

                // create a query (suign the connection)
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * From ImageFilter_Mul ", con))
                {

                    // execut4e the query into the reader
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        // use the reader to read all of the results of the query
                        while (reader.Read())
                        {

                            // pull out the data result using GetValue for dield number
                            //Console.WriteLine(
                            //$"{reader.GetValue(0)} {reader.GetValue(1)} {reader.GetValue(2)} {reader.GetValue(3)} {reader.GetValue(4)}");
                            records.Add(new ImageFilter_Mul
                            {
                                A = (long)reader.GetValue(1), // A
                                B = (long)reader.GetValue(2), // B
                                C = (long)reader.GetValue(3), // C
                                Result = (long)reader.GetValue(4) // Result
                            });

                        }
                    }

                }

                Console.WriteLine();
            }
            return records;
        }

        public static List<object> GetDataForImageFilter_Generic(Action<SQLiteDataReader, List<object>> action,
            string tableName)
        {
            List<object> records = new List<object>();

            var location = System.IO.Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            // connect to the Data Base
            using (SQLiteConnection con =
                new SQLiteConnection($"Data Source = {location}\\db\\filter.test.db; Version = 3;"))
            {

                // open the connection
                con.Open();

                // create a query (suign the connection)
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * From {tableName} ", con))
                {

                    // execut4e the query into the reader
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        // use the reader to read all of the results of the query
                        while (reader.Read())
                        {

                            // pull out the data result using GetValue for dield number
                            action.Invoke(reader, records);

                        }
                    }

                }

                Console.WriteLine();
            }
            return records;
        }
    }

    

    public class ImageFilter_Sum
    {
        public long A { get; set; }
        public long B { get; set; }
        public long Sum { get; set; }
    }

    public class ImageFilter_Mul
    {
        public long A { get; set; }
        public long B { get; set; }
        public long C { get; set; }
        public long Result { get; set; }
    }
    
}
