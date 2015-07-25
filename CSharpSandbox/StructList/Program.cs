using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructList
{
    struct StructItem
    {
        public string Str { get; set; }
        public StructSubItem Sub { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + Str + " Hash=" + GetHashCode().ToString("x")
                + " " + Sub.ToString();
        }
    }

    struct StructSubItem
    {
        public string Str { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + Str + " Hash=" + GetHashCode().ToString("x");
        }
    }

    class ClassItem
    {
        public string Str { get; set; }
        public ClassSubItem Sub { get; set; }

        public ClassItem() { }

        public override string ToString()
        {
            if (Sub == null)
            {
                return base.ToString() + " " + Str + " Hash=" + GetHashCode().ToString("x")
                    + " Sub is null.";
            }

            return base.ToString() + " " + Str + " Hash=" + GetHashCode().ToString("x")
                + " " + Sub.ToString();
        }
    }

    class ClassSubItem
    {
        public string Str { get; set; }

        public ClassSubItem() { }

        public override string ToString()
        {
            return base.ToString() + " " + Str + " Hash=" + GetHashCode().ToString("x");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            structItemTest();
            classItemTest();

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        static void structItemTest()
        {
            var structItems = new List<StructItem>();

            StructSubItem sub = new StructSubItem();
            sub.Str = "SubItem";
            StructSubItem sub2 = new StructSubItem();
            sub2.Str = "SubItem";
            structItems.Add(new StructItem() { Str = "Item1", Sub = sub });
            structItems.Add(new StructItem() { Str = "Item2", Sub = sub });
            structItems.Add(new StructItem() { Str = "Item3", Sub = sub2 });
            structItems.Add(new StructItem() { Str = "Item4", });
            structItems.Add(new StructItem() { Str = "Item5", });

            foreach (var item in structItems)
            {
                //これはコンパイルエラー
                //item.Str = "NewText";
            }

            foreach (var item in structItems)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void classItemTest()
        {
            var classItems = new List<ClassItem>();

            ClassSubItem sub = new ClassSubItem();
            sub.Str = "SubItem";
            ClassSubItem sub2 = new ClassSubItem();
            sub2.Str = "SubItem";
            classItems.Add(new ClassItem() { Str = "Item1", Sub = sub });
            classItems.Add(new ClassItem() { Str = "Item2", Sub = sub });
            classItems.Add(new ClassItem() { Str = "Item3", Sub = sub2});
            classItems.Add(new ClassItem() { Str = "Item4", });
            classItems.Add(new ClassItem() { Str = "Item5", });


            foreach (var item in classItems)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
