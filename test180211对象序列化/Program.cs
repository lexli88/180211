using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace test180211对象序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            //5.声明一个人，继承人类
            Person mmm = new Person();
            mmm.Name = "大MM";
            mmm.Age = 16;
            mmm.Email = "mmm@163.com";
            mmm.MyCar = new Car("QQ"); //给mmm加一辆车，这辆车的品牌是“QQ”，因为Car中1个构造函数，

            //6.对象序列化的步骤
            BinaryFormatter bf = new BinaryFormatter(); //声明一个对象序列化器

            //创建一个文件流
            using (FileStream fs = new FileStream("person.bin", FileMode.Create))
            {
                //7.开始执行序列化 将对象mmm序列化二进制文件流中，最终保存到person.bin文件中
                bf.Serialize(fs, mmm);
            }
            Console.WriteLine("ok");
            Console.ReadLine();

        }
        //Person类型要想被序列化
        //1.必须标记[Serializable]为可序列化

        //创建生物类
        [Serializable]
        public class ShenWu
        {
            public void Say()
            {
                Console.WriteLine("新陈代谢！");
            }
        }

        [Serializable]
        public class Person : ShenWu  //人类继承自生物类
        {
            //2.建议，在使用序列化的时候尽量避免使用自动属性，因为自动属性，每次编译的时候自动生成的不一样
            private string _name;
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
            private int _age;
            public int Age
            {
                get
                {
                    return _age;
                }
                set
                {
                    _age = value;
                }
            }
            private string _email;
            public string Email
            {
                get
                {
                    return _email;
                }
                set
                {
                    _email = value;
                }
            }
            //4.创建车的属性，必须先创建车类，这里才能给人类加个私有车的属性
            private Car _myCar;   //使用车类，声明一个属性为车类
            public Car MyCar      //可以表示有车类这个属性，可以接收传入的参数
            {
                get { return _myCar; }
                set { _myCar = value; }
            }
        }

        //2.创建Car类
        [Serializable]
        public class Car
        {
            //4.创建构造函数
            public Car(string brand)  //传入一个品牌名称
            {
                this.Brand = brand;
            }
            //3.创建属性
            private string _brand;
            public string Brand
            {
                get
                {
                    return _brand;
                }
                set
                {
                    _brand = value;
                }
            }
        }
    }
}
