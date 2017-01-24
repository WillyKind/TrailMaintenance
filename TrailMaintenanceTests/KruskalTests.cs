using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrailMaintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailMaintenance.Tests
{
    [TestClass()]
    public class KruskalTests
    {
        [TestMethod()]
        public void AllNodesIsVisited()
        {
            var trails = new List<Trail>
            {
                new Trail(new Node(1),new Node(2),5),
                new Trail(new Node(3),new Node(4),5),
                new Trail(new Node(5),new Node(6),5)
            };
            var list = Kruskal.Start(trails);
            Assert.IsTrue(list.TrueForAll(x => x.Start.IsVisited && x.End.IsVisited));
        }

        [TestMethod()]
        public void ListContainsAllNodesTest()
        {
            const int amount = 6;
            var trails = new List<Trail>
            {
                new Trail(new Node(1),new Node(2),5),
                new Trail(new Node(3),new Node(4),5),
                new Trail(new Node(5),new Node(6),5)
            };
            var result = Kruskal.ListContainsAllNodes(amount, trails);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void RightAmountOfTrails()
        {
            var one = new Node(1);
            var two = new Node(2);
            var three = new Node(3);
            var four = new Node(4);
            var trails = new List<Trail>
            {
                new Trail(one, two, 10),
                new Trail(one, three, 8),
                new Trail(three, two, 3),
                new Trail(one, four, 3),
                new Trail(one, three, 6),
                new Trail(two, one, 2)
            };
            var expected = 3;
            var result = Kruskal.Start(trails);
            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void ListDoesNotContainAllNodes()
        {
            var one = new Node(1);
            var two = new Node(2);
            var three = new Node(3);
            var trails = new List<Trail>
            {
                new Trail(one, two, 10),
                new Trail(one, three, 8),
                new Trail(three, two, 3),
            };
            var result = Kruskal.ListContainsAllNodes(4, trails);
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void ReturnsTheSmallestWeight()
        {
            var one = new Node(1);
            var two = new Node(2);
            var three = new Node(3);
            var four = new Node(4);
            var trails = new List<Trail>
            {
                new Trail(one, two, 10),
                new Trail(one, three, 8),
                new Trail(three, two, 3),
                new Trail(one, four, 3),
                new Trail(one, three, 6),
                new Trail(two, one, 2)
            };
            var expected = 8;
            var kruskalList = Kruskal.Start(trails);
            var result = kruskalList.Sum(trail => trail.Weight);
            Assert.AreEqual(expected, result);
        }
    }
}