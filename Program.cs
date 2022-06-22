using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hw4._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            int playerX;
            int playerY;

            Console.CursorVisible = false;

            char[,] map = ReadMap("map", out playerY, out playerX);

            DrawMap(map);
            //Console.SetCursorPosition(24, 7);
            //Console.WriteLine("&");

            while(isPlaying)
            {
                Move(map, ref playerY, ref playerX);
            }
        }

        static char[,] ReadMap(string nameMap, out int playerY, out int playerX)
        {
            playerX = 0;
            playerY = 0;

            string[] fileMap = File.ReadAllLines($"map/{nameMap}.txt"); 
            char[,] map = new char[fileMap.Length, fileMap[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = fileMap[i][j];

                    if (map[i,j] == '@')
                    {
                        playerX = j;
                        playerY = i;
                        map[i,j] = ' ';
                    }
                }
            }

            return map;
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i,j]);
                }

                Console.WriteLine();
            }
        }

        static void Move(char[,] map, ref int playerY, ref int playerX)
        {
            ConsoleKeyInfo move = Console.ReadKey();

            Console.SetCursorPosition( playerX, playerY);
            //Console.WriteLine(" ");

            switch (move.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[playerY - 1, playerX] != '#')
                    {
                        playerY--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (map[playerY + 1, playerX] != '#')
                    {
                        playerY++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (map[playerY, playerX - 1] != '#')
                    {
                        playerX--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (map[playerY, playerX + 1] != '#')
                    {
                        playerX++;
                    }
                    break;
            }

            Console.SetCursorPosition(playerX, playerY);
            Console.WriteLine("!");
        }
    }
}
