using SFML.Graphics;
using SFML.System;
using System;

namespace SquareGame
{
    public class Square
    {
        public static Vector2f defaultSize = new Vector2f(100, 100);

        public bool IsActive = true;

        protected RectangleShape shape;
        protected float movementSpeed;
        protected Vector2f movementTarget;
        protected IntRect movementBounds;

        public Square(Vector2f position, float movementSpeed, IntRect movementBounds)
        {
            shape = new RectangleShape(defaultSize);
            shape.Position = position;

           this.movementSpeed = movementSpeed;
           this.movementBounds = movementBounds;

            UpdateMovementTarget();
        }

        public void Move()
        {
            shape.Position = Mathf.MoveTowards(shape.Position, movementTarget, movementSpeed);

            if (shape.Position == movementTarget)
            {
                OnReachedTarget();

                UpdateMovementTarget();
            }
        }

        public void Draw(RenderWindow win)
        {
            if (IsActive == false) return;

            win.Draw(shape);
        }

        public void CheckMousePosition(Vector2i mousePos)
        {
            if (IsActive == false) return;

            if(mousePos.X > shape.Position.X && mousePos.X < shape.Position.X + shape.Size.X &&
                mousePos.Y > shape.Position.Y && mousePos.Y < shape.Position.Y + shape.Size.Y)
                OnClick();
        }

        protected void UpdateMovementTarget()
        {
            Random rnd = new Random();

            movementTarget.X = Mathf.random.Next(movementBounds.Left, movementBounds.Left + movementBounds.Width);
            movementTarget.Y = Mathf.random.Next(movementBounds.Top, movementBounds.Top + movementBounds.Height);
        }

        protected virtual void OnClick() { }
        protected virtual void OnReachedTarget() { }
    }

}
