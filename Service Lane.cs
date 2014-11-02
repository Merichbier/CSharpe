using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Service_Lane
    {
        static void Main(String[] args)
        {
            String[] firstLine = Console.ReadLine().Split(' ');
            int roadLenght = Int32.Parse(firstLine.ElementAt(0));
            int nbTest = Int32.Parse(firstLine.ElementAt(1));
            String[] serviceLane = Console.ReadLine().Split(' ');
            for (int test = 0; test < nbTest; ++test)
            {
                String[] roadPartStr = Console.ReadLine().Split(' ');
                int start = Int32.Parse(roadPartStr.ElementAt(0));
                int end = Int32.Parse(roadPartStr.ElementAt(1));
                solve(start, end, serviceLane);
            }
        }

        private static void solve(int start, int end, string[] serviceLane)
        {
            int largestVehicle = 3;
            for (int segment = start; segment <= end; ++segment)
            {
                int segmentWidth = Int32.Parse(serviceLane.ElementAt(segment));
                if (segmentWidth < largestVehicle) largestVehicle = segmentWidth;
            }
            Console.WriteLine(largestVehicle);
        }
    }
}
