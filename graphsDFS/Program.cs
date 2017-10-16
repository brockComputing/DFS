using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphsDFS
{
    class Program
    {

        class aNode
        {
            private List<int> _adjList = new List<int>();
            public List<int> adjList { get { return _adjList; } set { _adjList = value; } }
            public void addNeighbour(int neighbour)
            {
                _adjList.Add(neighbour);
            }
        }
        // i would not use globals but recurison requires it!!
        static aNode[] graph = new aNode[100];
        static Stack<int> aStack = new Stack<int>();
        static bool[] Discovered = new bool[100];
        static bool[] CompletelyExplored = new bool[100];

        static void Main(string[] args)
        {
            int V = 1, EndV = 7; int numberOFNodes = 8; // this is + 1 as being 1 based
            for (int i = 0; i < numberOFNodes; i++)
            {
                graph[i] = new aNode();
            }
            makeGraph();
            DFS(V, EndV);
            Console.ReadLine();
        }

        static  void DFS(int V, int EndV)
        {


            bool Found = false;
            aStack.Push(V);
            Discovered[V] = true;
            if (V == EndV)
            {
                Found = true;
                while (aStack.Count != 0)
                {
                    Console.WriteLine(aStack.Pop());
                }
            }
            foreach (var U in graph[V].adjList)
            {
                if (Discovered[U] == false)
                {
                    DFS(U, EndV);
                    if (aStack.Count != 0)
                    {
                        aStack.Pop();
                    }
                }
            }
            CompletelyExplored[V] = true;
        }



        static private void makeGraph()
        {
            graph[1].addNeighbour(2);
            graph[2].addNeighbour(1);
            graph[2].addNeighbour(3);
            graph[2].addNeighbour(4);
            graph[3].addNeighbour(2);
            graph[4].addNeighbour(2);
            graph[4].addNeighbour(5);
            graph[5].addNeighbour(4);
            graph[5].addNeighbour(6);
            graph[5].addNeighbour(7);
            graph[6].addNeighbour(5);
            graph[7].addNeighbour(5);
        }
    }
}
