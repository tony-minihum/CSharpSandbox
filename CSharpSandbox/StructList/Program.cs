using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructList
{
    struct Item
    {
        public string Str { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + Str + " " + GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dataList = new List<Item>();

            dataList.Add(new Item() { Str = "Item1" });
            dataList.Add(new Item() { Str = "Item2" });
            dataList.Add(new Item() { Str = "Item3" });
            dataList.Add(new Item() { Str = "Item4" });

            foreach (var item in dataList)
            {
                //item.Str = "NewText";
            }

            foreach (var item in dataList)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
