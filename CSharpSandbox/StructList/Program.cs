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
        public ClassSubItem ClassSub { get; set; }

        public override string ToString()
        {
            if (ClassSub == null)
            {
                return base.ToString() + " " + Str + " hc=" + GetHashCode().ToString("x")
                    + " " + Sub.ToString();
            }
            return base.ToString() + " " + Str + " hc=" + GetHashCode().ToString("x")
                + " " + Sub.ToString() + " " + ClassSub.ToString();
        }
    }

    struct StructSubItem
    {
        public string Str { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + Str + " hc=" + GetHashCode().ToString("x");
        }

    }

    class ClassItem
    {
        public string Str { get; set; }
        public ClassSubItem Sub { get; set; }

        public ClassItem() { }
        ~ClassItem()
        {
            Console.WriteLine("---- destractor : " + this.ToString());
        }

        public override string ToString()
        {
            if (Sub == null)
            {
                return base.ToString() + " " + Str + " hc=" + GetHashCode().ToString("x")
                    + " Sub is null.";
            }

            return base.ToString() + " " + Str + " hc=" + GetHashCode().ToString("x")
                + " " + Sub.ToString();
        }


    }

    class ClassSubItem
    {
        public string Str { get; set; }

        public ClassSubItem() { }
        ~ClassSubItem()
        {
            Console.WriteLine("---- destractor : " + this.ToString());
        }

        public override string ToString()
        {
            return base.ToString() + " " + Str + " hc=" + GetHashCode().ToString("x");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            {
                var item = structItemTest();

                gc();

                classItemTest(item);
            }

            gc();

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        static void gc()
        {
            Console.WriteLine("****            ****");
            Console.WriteLine("**** GC.Collect ****");
            Console.WriteLine("****            ****");
            GC.Collect();
        }

        static ClassSubItem structItemTest()
        {
            var structItems = new List<StructItem>();

            StructSubItem sub = new StructSubItem() { Str = "SubItem" };
            StructSubItem sub2 = new StructSubItem() { Str = "SubItem" };
            ClassSubItem cSub = new ClassSubItem() { Str = "ClassSubInStruct" };
            ClassSubItem cSub2 = new ClassSubItem() { Str = "ClassSubInStruct2" };

            structItems.Add(new StructItem() { Str = "Item1", Sub = sub, ClassSub = cSub});
            structItems.Add(new StructItem() { Str = "Item2", Sub = sub, ClassSub = cSub });
            structItems.Add(new StructItem() { Str = "Item3", Sub = sub2, ClassSub = cSub2 });
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

            return cSub;
        }

        static void classItemTest(ClassSubItem cSub)
        {
            var classItems = new List<ClassItem>();

            ClassSubItem sub = new ClassSubItem() { Str = "SubItem" };
            ClassSubItem sub2 = new ClassSubItem() { Str = "SubItem" };

            classItems.Add(new ClassItem() { Str = "Item1", Sub = sub });
            classItems.Add(new ClassItem() { Str = "Item2", Sub = sub });
            classItems.Add(new ClassItem() { Str = "Item3", Sub = sub2});
            classItems.Add(new ClassItem() { Str = "Item4", Sub = cSub});
            classItems.Add(new ClassItem() { Str = "Item5", });


            foreach (var item in classItems)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
