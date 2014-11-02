using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class BotCleanStochastic
    {
        static void Main(String[] args)
        {
            String pos = Console.ReadLine();
            String[] position = pos.Split(' ');
            int[] bot_pos = new int[2];
            bot_pos[0] = Convert.ToInt32(position[0]);
            bot_pos[1] = Convert.ToInt32(position[1]);
            String[] grid = new String[5];
            for (int i = 0; i < 5; i++)
            {
                grid[i] = Console.ReadLine();
            }

                nextMove(bot_pos, grid);

        }

        static void nextMove(int[] bot, String[] grid)
        {
            int[] princess_pos = new int[2];
            findCharacter('d', grid, out princess_pos[0], out princess_pos[1]);
            findCharacter('b', grid, out bot[0], out bot[1]);
            //Console.WriteLine("bot : {0},{1} and cell : {2},{4}", bot[0], bot[1], princess_pos[0], princess_pos[1]);
            Console.WriteLine(computeMove(bot, princess_pos));
        }

        static void findCharacter(char character, String[] grid, out int princess_posX, out int princess_posY)
        {
            for (int i = 0; i < grid.Length; ++i)
            {
                if (grid.ElementAt(i).Contains(character))
                {
                    princess_posY = i;
                    for (int j = 0; j < grid.ElementAt(i).Length; ++j)
                    {
                        if (grid.ElementAt(i).ElementAt(j).Equals(character))
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

        static string computeMove(int[] bot, int[] cell)
        {
            if (bot[0] == -1 && bot[1] == -1)
            {
                return "CLEAN";
            }
            int x = cell[0] - bot[0];
            if (x < 0)
            {
                bot[0] -= 1;
                return "LEFT";
            }
            else if (x > 0)
            {
                bot[0] += 1;
                return "RIGHT";
            }
            int y = cell[1] - bot[1];
            if (y < 0)
            {
                bot[1] -= 1;
                return "UP";
            }
            else if (y > 0)
            {
                bot[1] += 1;
                return "DOWN";
            }
            return "";
        }

    }
}


