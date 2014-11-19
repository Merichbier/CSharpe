using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Artificial_Intelligence
{
    class BotClean
    {
     
        static private bool IsClean(String[] board)
        {
            foreach (String row in board)
            {
                foreach (Char cell in row)
                {
                    if (cell.Equals('d')) return false;
                }
            }
            return true;
        }

        static private List<Vertex> allVertices(String[] board)
        {
            List<Vertex> vertices = new List<Vertex>();
            for(int y=0; y < board.Length; ++y) {
                for(int x=0; x < board[y].Length ; ++x) 
                {
                    if (board[y].ElementAt(x) == 'd')
                    {
                        vertices.Add(new Vertex(x, y));
                    }
                    
                }
            }
            return vertices;
        }

        static private Dictionary<Vertex, List<Edge>> ConstructGraph(List<Vertex> vertices)
        {
            Dictionary<Vertex, List<Edge>> map = new Dictionary<Vertex, List<Edge>>();
            foreach (Vertex v in vertices)
            {
                var others = from vert in vertices where vert != v select vert;
                List<Edge> edges = new List<Edge>();
                foreach (Vertex vOthers in others)
                {
                    edges.Add(new Edge(v, vOthers));
                }
                map.Add(v, edges);
            }
            return map;
        }

        static private List<Vertex> solver(Vertex Start, Dictionary<Vertex, List<Edge>> map) 
        {
            List<Vertex> shortestPath = new List<Vertex>();
            var toVisit = map.Keys.ToList().OrderBy(vertex => vertex.step);
            Start.step = 0;
            Vertex actualVisited = Start;
            while (toVisit.Count() != 0)
            {
                List<Edge> edges;
                if(map.TryGetValue(actualVisited,out edges)) {
                    foreach (var destination in toVisit)
                    {
                        if (actualVisited.Equals(destination)) continue;
                        Edge edgeToDestination = edges.Find(edge => edge.Destination.Equals(destination));
                        destination.step = actualVisited.step + edgeToDestination.Cost;
                    }
                }
                var others = toVisit.ToList(); 
                toVisit = toVisit.Skip(1).OrderBy(vertex => vertex.step).ThenByDescending(vertex => vertex.distanceToOthers(others));
                shortestPath.Add(actualVisited);
                if (toVisit.Count() != 0)
                {
                    actualVisited = toVisit.ElementAt(0);
                }

            }

            return shortestPath.OrderBy(vertex => vertex.step).ToList();
        }


        static void next_move(int posr, int posc, String[] board)
        {
            if (board[posr].ElementAt(posc) == 'd'){
                Console.WriteLine("CLEAN"); 
                return;
            }else {
                List<Vertex> vertices = allVertices(board);
            Vertex start = new Vertex(posc, posr);
            vertices.Add(start);
            //vertices.ForEach(v => Console.Write("{0} --> ", v));
            Dictionary<Vertex, List<Edge>> graph = ConstructGraph(vertices);
            List<Vertex> pathToFollow = solver(start, graph);
            Console.WriteLine(computeMove(pathToFollow.ElementAt(0), pathToFollow.ElementAt(1)));
            }
            

        }

        static string computeMove(Vertex bot, Vertex destination)
        {
            int x = destination.colomn - bot.colomn;
            if (x < 0)
            {
                return "LEFT";
            }
            else if (x > 0)
            {
                return "RIGHT";
            }
            int y = destination.row - bot.row;
            if (y < 0)
            {
                return "UP";
            }
            else if (y > 0)
            {
                return "DOWN";
            }
            return "CLEAN";
        }

        static void Main(String[] args)
        {
            String temp = Console.ReadLine();
            String[] position = temp.Split(' ');
            int[] pos = new int[2];
            String[] board = new String[5];
            for (int i = 0; i < 5; i++)
            {
                board[i] = Console.ReadLine();
            }
            for (int i = 0; i < 2; i++) pos[i] = Convert.ToInt32(position[i]);
            next_move(pos[0], pos[1], board);
            Console.Read();
        }

         
        private class Vertex
        {
            private Tuple<Int32, Int32> position;
            private int stepToG;

            public Vertex(int x, int y)
            {
                position = new Tuple<int, int>(x, y);
                stepToG = Int32.MaxValue;
            }

            public double distanceTo(Vertex other)
            {
                return Math.Sqrt(Math.Pow(row - other.row,2) + Math.Pow(colomn - other.colomn,2));
            }

            public double distanceToOthers(List<Vertex> others)
            {
                double d = 0;
                others.ForEach(vertex => d += distanceTo(vertex));
                return d;
            }

            public override bool Equals(object obj)
            {   
                if(obj is Vertex) {
                    Vertex other = obj as Vertex;
                    return position.Item1 == other.position.Item1 && position.Item2 == other.position.Item2;
                }
                else
                {
                    return base.Equals(obj);
                }
                
            }
            public override int GetHashCode()
            {
                return (position.Item1 + position.Item2).GetHashCode();
            }
            public override string ToString()
            {
                return position.ToString();
            }

            public int row
            {
                get { return position.Item2; }
            }

            public int colomn
            {
                get { return position.Item1; }
            }

            public int step
            {
                get { return stepToG; }
                set { stepToG = value; }
            }
        }

        private class Edge
        {
            private Vertex destination;
            private int cost;

            public Edge(Vertex start, Vertex destination)
            {
                this.destination = destination;
                cost = Math.Abs(start.row - destination.row) + Math.Abs(start.colomn - destination.colomn);
            }

            public Vertex Destination
            {
                get { return destination; }
            }

            public int Cost
            {
                get { return cost; }
            }
        }
    }
}
