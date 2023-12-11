using SFML.Graphics;
using SFML.System;

namespace SquareGame
{
    internal class PlayerSquare : Square
    {
        private static Color color = new Color(50, 50, 50);
        private static float sizeStep = 10;
        private static float minSize = 30;
        public PlayerSquare(Vector2f position, float movementSpeed, IntRect movementBounds) : base(position, movementSpeed, movementBounds)
        {
            shape.FillColor = color;
        }

        protected override void OnClick()
        {
            Game.scores++;

            shape.Size -= new Vector2f(sizeStep, sizeStep);

            if (shape.Size.X < minSize)
            {
                IsActive = false;
                return;
            }

            UpdateMovementTarget();
            shape.Position = movementTarget;
        }
    }
}
