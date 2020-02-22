using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace WhyYouGay
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> File = new List<string[]>();
            Dictionary<string,List<string[]>> AllFiles = new Dictionary<string, List<string[]>>();

            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Neo\source\repos\WhyYouGay\WhyYouGay\Input");
            var files =
                from n in dir.GetFiles("*.csv")
                select n;
            foreach (var item in files)
            {
                Console.WriteLine(item.Name);
            }
            foreach (var item in files)
            {
                //File.Add(item);
                using (StreamReader fileIn = new StreamReader(item.FullName))
                {
                    string[] Line;

                    while (!fileIn.EndOfStream)
                    {
                       
                        Line = fileIn.ReadLine().Split(';');

                        File.Add(Line);

                        //ProductsAll.Add(new Item(Line[0], Convert.ToInt32(Line[1]), Line[2], Line[3]));
                    }
                    List<string[]> temp = new List<string[]>();
                    foreach (var itemSecond in File)
                    {                    
                        temp.Add(itemSecond);
                    }
                    AllFiles.Add(item.Name, temp);
                    File.Clear();
                }
            }
            using (StreamWriter outFile = new StreamWriter("../../../ScanReport.csv")) 
            {
                int i = 0;
                foreach (var item in AllFiles)
                {
                  
                    var Line = item.Value;

                    foreach (var itemSecond in Line)
                    {
                     
                        outFile.Write($"{item.Key[..^4]};");
                        var Array = Line[i++];
                        foreach (var itemThree in Array)
                        {
                            outFile.Write($"{itemThree};");
                        }
                        outFile.WriteLine();
                    }
                    i = 0;
                  
                }
              
            }
        }
    }
}

