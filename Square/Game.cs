using SFML.Graphics;
using SFML.Window;
using System;

namespace SquareGame
{
    public class Game
    {
        public SquaresList squares;

        public static int scores;
        public static bool isLost;

        public Game()
        {
            squares = new SquaresList();

            squares.SpawnPlayerSquare();
            squares.SpawnEnemySquare();
            squares.SpawnBonusSquare();
        }

        private void Reset()
        {
            squares.Reset();
            scores = 0;
            isLost = false;

            squares.SpawnPlayerSquare();
            squares.SpawnEnemySquare();
            squares.SpawnBonusSquare();
        }

        public void ChangingSizeEnemySquareOnBonusSquareClick()
        {
            for (int i = 0; i < squares.Count; i++)
            {

            }
        }

        public void Update(RenderWindow win)
        {
            if(isLost == true)
            {
                if(Keyboard.IsKeyPressed(Keyboard.Key.R) == true)
                {
                    Reset();
                }
            }

            if(isLost == false)
            {
                squares.Update(win);

                if (squares.SquareHasRemove == true)
                {
                    if (squares.RemovedSquare is PlayerSquare)
                    {
                        squares.SpawnPlayerSquare();
                    }
                }
            }
            Console.WriteLine(scores);
        }
    }
}
