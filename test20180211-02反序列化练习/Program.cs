using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using test180211对象序列化;


namespace test20180211_02反序列化练习
{
    class Program
    {
        static void Main(string[] args)
        {
            //反序列化步骤：
            //1.创建二进制序列化器（格式化器）
            BinaryFormatter bf = new BinaryFormatter();
            //2.创建文件流
            using (FileStream fs = new FileStream("person.bin", FileMode.Open))
            {
                //3.开始执行反序列化
              
               Person per = (Person)bf.Deserialize(fs);
             //  object obj = bf.Deserialize(fs);

                 Console.WriteLine("Name:{0},Age:{1},Car:{2}",per.Name,per.Age,per.MyCar.Brand);

               

            }
            Console.WriteLine("ok");
            Console.ReadLine();
        }
    }
}
