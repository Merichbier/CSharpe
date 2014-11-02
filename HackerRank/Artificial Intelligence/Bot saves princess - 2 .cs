using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank.BotSavesPrincessMinusTwo
{
    class BotSavesPrincessMinus2
    {

        static void Main(String[] args)
        {
            int n;

            n = int.Parse(Console.ReadLine());
            String pos;
            pos = Console.ReadLine();
            String[] position = pos.Split(' ');
            int[] bot_pos = new int[2];
            bot_pos[0] = Convert.ToInt32(position[0]);
            bot_pos[1] = Convert.ToInt32(position[1]);
            String[] grid = new String[n];
            for (int i = 0; i < n; i++)
            {
                grid[i] = Console.ReadLine();
            }

            nextMove(n, bot_pos[0], bot_pos[1], grid);

        }

        static void nextMove(int n, int r, int c, String[] grid)
        {
            int[] princess_pos = new int[2];
            findCharacter(grid, out princess_pos[0], out princess_pos[1]);
            int[] bot_pos = {c,r};
            Console.WriteLine(computeMove(bot_pos,princess_pos));
        }

        static void findCharacter(String[] grid, out int princess_posX, out int princess_posY)
        {
            for (int i = 0; i < grid.Length; ++i)
            {
                if (grid.ElementAt(i).Contains("p"))
                {
                    princess_posY = i;
                    for (int j = 0; j<grid.ElementAt(i).Length;++j)
                    {
                        if (grid.ElementAt(i).ElementAt(j) != '-')
                        {
                            princess_posX = j; 
                            return;
                        }
                    }
                }
            }
            princess_posX = -1;
            princess_posY = -1;
        }

        static string computeMove(int[] bot, int[] princess)
        {
            int x = princess[0] - bot[0];
            if (x < 0)
            {
                return "LEFT";
            }
            else if (x > 0)
            {
                return "RIGHT";
            }
            int y = princess[1] - bot[1];
            if (y < 0)
            {
                return "UP";
            }
            else if (y > 0)
            {
                return "DOWN";
            }
            return "";
        }
    }
}
