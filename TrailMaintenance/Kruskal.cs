using System;
using System.Collections.Generic;
using System.Linq;

namespace TrailMaintenance
{
    public static class Kruskal
    {
        
        public static List<Trail> Start(List<Trail> kruskaList)
        {
            var printList = new List<Trail>();
            var orderedTrails = kruskaList.OrderBy(x => x.Weight);
            foreach (var orderedTrail in orderedTrails)
            {
                if (orderedTrail.Start.IsVisited == true && orderedTrail.End.IsVisited == true && printList.Count >=3)
                {
                    continue;
                }
                else
                {
                    orderedTrail.Start.IsVisited = true;
                    orderedTrail.End.IsVisited = true;
                    printList.Add(orderedTrail);
                }
            }
            return printList;
        }

        public static bool ListContainsAllNodes(int amountOfNodes, IEnumerable<Trail> kruskalTrails)
        {
            var nodelist = new List<int>();
            foreach (var trail in kruskalTrails)
            {
                for (int i = 1; i <= amountOfNodes; i++)
                {
                    if (trail.Start.Value != i && trail.End.Value != i) continue;
                    nodelist.Add(i);
                    nodelist = nodelist.Distinct().ToList();
                }
            }
            return nodelist.Count == amountOfNodes;
        }
    }
}