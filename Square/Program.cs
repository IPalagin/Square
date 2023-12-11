using SFML.Graphics;
using System;
using SFML.Window;

namespace SquareGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Game");
            win.Closed += Win_Closed;
            win.SetFramerateLimit(60);

            Game game = new Game();

            while (win.IsOpen == true)
            {
                win.Clear(new Color(230, 230, 230));

                win.DispatchEvents();

                game.Update(win);

                win.Display();
            }
        }

        static void Win_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}
