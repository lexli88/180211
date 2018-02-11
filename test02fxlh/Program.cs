using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using test01xlh;

namespace test02fxlh
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("person.bin", FileMode.Open))
            {
                Person per = (Person)bf.Deserialize(fs);
                Console.WriteLine("Name:{0}，Age：{1}，Email：{2}",per.Name,per.Age,per.Email);

            }
            Console.WriteLine("OK");
            Console.ReadLine();
        }
    }
}
