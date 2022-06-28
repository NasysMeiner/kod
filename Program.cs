using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Draw drawPlayer = new Draw();
            Player player = new Player(10, 20);

            drawPlayer.DrawPlayer(player.X, player.Y);
            Console.ReadLine();
        }
    }

    class Player
    {
        public Player(int positionX, int positionY)
        {
            X = positionX;
            Y = positionY;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }

    class Draw
    {
        public void DrawPlayer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("%");
        }
    }
}
