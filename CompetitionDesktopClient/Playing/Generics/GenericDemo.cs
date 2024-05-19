using Cave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionDesktopClient.Playing.Generics
{
    public class Person
    {
        public string Name { get; set; }
        public bool Alive { get; set; }

        public Person() { Name = ""; Alive = true; }
    }

    public class DataLog
    {
        public string Data { get; set; }
        public DateTime Recorded { get; set; }

        public DataLog() { Data = ""; Recorded = DateTime.Now; }
    }

    public class FileExtra
    {
        public string FileLocation { get; set; }
        public string Directory { get; set; }

        public FileExtra() { FileLocation = "default.txt"; Directory = "C:/Working"; }

    }
    public class GenericDemo
    {
        public void RunTest()
        {
            List<Person> list = new List<Person>();
            List<DataLog> log = new List<DataLog>();
            FileExtra personFile = new FileExtra { FileLocation = @"C:\Working\person.csv", Directory = @"C:\WORKING\" };
            FileExtra logFile = new FileExtra { FileLocation = @"C:\Working\log.csv", Directory = @"C:\WORKING\" };

            list = LoadData<Person, FileExtra>(personFile.FileLocation);
            log =  LoadData<DataLog, FileExtra>(logFile.FileLocation);
        }

        public List<T> LoadData<T, U>(string fileName) where T : class, new() where U : FileExtra
        {
            if (!System.IO.File.Exists(fileName))
            {
                // warning back out, use delegate as called from outside?
                return null;
            }
            var data = System.IO.File.ReadAllText( fileName);
            // get columns using reflection
            T incoming = new T();
            var cols = incoming.GetType().GetProperties();
            

            foreach(var col in cols)
            {
                string colName = col.Name;

                // build list to load

            }

            List<T> list = new List<T>();
            return list;

        }
    }


}
