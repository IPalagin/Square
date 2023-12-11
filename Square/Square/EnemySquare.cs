using SFML.Graphics;
using SFML.System;
using System.Security.Policy;

namespace SquareGame
{
    internal class EnemySquare : Square
    {
        private static Color color = new Color(230, 50, 50);
        private static float maxMovementSpeed = 3;
        private static float movementStep = 0.05f;
        private static float maxSize = 150;
        private static float sizeStep = 10;
        private static float minSize = 50;

        public EnemySquare(Vector2f position, float movementSpeed, IntRect movementBounds) : base(position, movementSpeed, movementBounds)
        {
            shape.FillColor = color;
        }

        protected override void OnClick()
        {
            Game.isLost = true;
        }

        protected override void OnReachedTarget()
        {
            if(movementSpeed < maxMovementSpeed) movementSpeed += movementStep;
            if (shape.Size.X < maxSize) shape.Size += new Vector2f(sizeStep, sizeStep);
        }
    }
}
