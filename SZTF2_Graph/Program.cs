using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF2_Graf
{
    class Program
    {
        public static void ExternalProcessor(string item)
        {
            Console.WriteLine(item);
        }

        static void EdgeAdded(object source, Graph<string>.GraphEventArgs<string> gears)
        {
            Console.WriteLine("[ÚJ ÉL FELVÉVE]  " + gears.A + " és " + gears.B + " csúcsok közt egy új él lett felvéve. ");
        }

        static void Main(string[] args)
        {
            Graph<string> g = new Graph<string>();
            Console.WriteLine("Új élek hozzáadva: ");
            g.EdgeAdded += EdgeAdded;

            Person marge = new Person("Marge");
            Person gerald = new Person("Gerald");
            Person janet = new Person("Janet");
            Person stew = new Person("Stew");
            Person peter = new Person("Peter");
            Person zack = new Person("Zack");
            Person joseph = new Person("Joseph");

            g.AddNode(marge.ToString());
            g.AddNode(gerald.ToString());
            g.AddNode(janet.ToString());
            g.AddNode(stew.ToString());
            g.AddNode(peter.ToString());
            g.AddNode(zack.ToString());
            g.AddNode(joseph.ToString());

            g.AddEdge("Joseph", "Stew");
            g.AddEdge("Joseph", "Marge");
            g.AddEdge("Joseph", "Zack");
            g.AddEdge("Joseph", "Gerald");

            g.AddEdge("Peter", "Zack");
            g.AddEdge("Peter", "Janet");

            g.AddEdge("Marge", "Stew");
            g.AddEdge("Gerald", "Zack");

            Console.WriteLine("\n");

            Console.WriteLine("BFS");
            g.BFS("Janet", ExternalProcessor);

            Console.WriteLine("\n");

            Console.WriteLine("DFS");
            g.DFS("Janet", ExternalProcessor);



            Console.ReadKey();
        }
    }
}
