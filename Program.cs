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
            Player player = new Player(10, 20);
            player.DrawPlayer();
            Console.ReadLine();
        }
    }

    class Player
    {
        private int _positionX;
        private int _positionY;

        public Player(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }

        public void DrawPlayer()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.WriteLine("%");
        }
    }
}
