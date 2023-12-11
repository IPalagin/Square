using SFML.Graphics;
using SFML.System;
using System;

namespace SquareGame
{
    internal class BonusSquare : Square
    {
        private static Color[] colors = new Color[] { Color.Yellow, Color.Blue, Color.Magenta };
        private static Random random = new Random();

        public BonusSquare(Vector2f position, float movementSpeed, IntRect movementBounds) : base(position, movementSpeed, movementBounds)
        {
            shape.FillColor = GetRandomColor();
        }

        protected override void OnClick()
        {
            if (shape.FillColor == colors[0])
            {

            }

            UpdateMovementTarget();
            shape.Position = movementTarget;

            shape.FillColor = GetRandomColor();
        }
        private Color GetRandomColor()
        {
            int randomIndex = random.Next(colors.Length);
            return colors[randomIndex];
        }
    }
}
