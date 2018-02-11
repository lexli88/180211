using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace test01xlh
{
    class Program
    {
        static void Main(string[] args)
        {
            Person mmm = new Person();
            mmm.Name = "MMM";
            mmm.Age = 18;
            mmm.Email = "mmm@163.com";
            mmm.MyCar = new Car("QQ");

            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream("person.bin", FileMode.Create))
            {
                bf.Serialize(fs, mmm);
            }
            Console.WriteLine("ok");
            Console.WriteLine(mmm.Name);
            Console.Read();
        }
    }
    [Serializable]
    public class ShenWu
    {
        public void Say()
        {
            Console.WriteLine("新陈代谢");
        }
    }
    [Serializable]
    public class Person : ShenWu
    {
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
            get { return _age; }
            set { _age = value; }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private Car _myCar;
        public Car MyCar
        {
            get { return _myCar; }
            set { _myCar = value; }
        }
    }
    [Serializable]
    public class Car
    {
        public Car(string brand)
        {
            this.Brand = brand;
        }
        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
    }

}
