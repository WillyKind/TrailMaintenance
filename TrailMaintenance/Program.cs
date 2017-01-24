using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace TrailMaintenance
{
    public  class Program
    {
        static void Main(string[] args)
        {
            const int amountOfNodes = 4;
            const int amountOfWeeks = 6;

            var kruskalTrails = new List<Trail>();
            var wildAnimalTrails = SetUp(amountOfNodes);
            for (var i = 1; i <= amountOfWeeks; i++)
            {
                kruskalTrails.Add(wildAnimalTrails[i-1]);
               
                if (Kruskal.ListContainsAllNodes(amountOfNodes, kruskalTrails) && kruskalTrails.Count >= amountOfNodes-1)
                {
                    Print(Kruskal.Start(kruskalTrails));
                }
            }
        }

        public static void Print(List<Trail> printList)
        {
            var sum = 0;
            foreach (var trail in printList)
            {
                trail.Start.IsVisited = false;
                trail.End.IsVisited = false;
                Console.WriteLine($"{trail.Start.Value} - {trail.End.Value} = {trail.Weight}");
                sum += trail.Weight;
            }
            Console.WriteLine($"Total weight = {sum} \n");
        }

        //Change input here!
        private static List<Trail> SetUp(int amountOfNodes)
        {
            var nodes = new List<Node>();

            for (int i = 1; i <= amountOfNodes; i++)
            {
                nodes.Add(new Node(i));
            }
            
            return new List<Trail>
            {
                new Trail(nodes[0], nodes[1], 10),
                new Trail(nodes[0], nodes[2], 8),
                new Trail(nodes[2], nodes[1], 3),
                new Trail(nodes[0], nodes[3], 3),
                new Trail(nodes[0], nodes[2], 6),
                new Trail(nodes[1], nodes[0], 2)
            };
        }
    }
}
