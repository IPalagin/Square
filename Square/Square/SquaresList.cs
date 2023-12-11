using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using SFML.System;

namespace SquareGame
{
    public class SquaresList
    {
        public List<Square> squares;
        public bool SquareHasRemove;
        public Square RemovedSquare;

        public SquaresList() 
        {
            squares = new List<Square>();
        }

        public void Reset()
        {
            SquareHasRemove = false;
            RemovedSquare = null;

            squares.Clear();
        }

        public void Update(RenderWindow win)
        {
            SquareHasRemove = false;
            RemovedSquare = null;

            if(Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {
                for(int i = 0; i < squares.Count; i++)
                {
                    squares[i].CheckMousePosition(Mouse.GetPosition(win));
                }
            }

            for(int i = 0;i < squares.Count; i++)
            {
                squares[i].Move();
                squares[i].Draw(win);

                if (squares[i].IsActive == false)
                {
                    RemovedSquare = squares[i];
                    squares.Remove(squares[i]);
                    SquareHasRemove = true;
                }
            }
        }

        public void SpawnPlayerSquare()
        {
            squares.Add(new PlayerSquare(new Vector2f(Mathf.random.Next(0, 800), (Mathf.random.Next(0, 600))), 10, new IntRect(0, 0, 800, 600)));
        }

        public void SpawnEnemySquare()
        {
            squares.Add(new EnemySquare(new Vector2f(Mathf.random.Next(0, 800), (Mathf.random.Next(0, 600))), 10, new IntRect(0, 0, 800, 600)));
        }

        public void SpawnBonusSquare()
        {
            squares.Add(new BonusSquare(new Vector2f(Mathf.random.Next(0, 800), (Mathf.random.Next(0, 600))), 10, new IntRect(0, 0, 800, 600)));
        }


    }
}
