using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Snake20200629
{
    class SnakeHead
    {
        private Vector2 position = new Vector2(100, 100);
        private int speed = 2;
        public int radius = 25;
        public bool isAlive = false; // make false so player starts game still
        public Direction direction = Direction.Right;
        public int bodyHeadDistance = 30;


        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }


        public void Update()
        {
            // Get key presses
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
            {
                isAlive = true;
                direction = Direction.Up;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                isAlive = true;
                direction = Direction.Down;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                isAlive = true;
                direction = Direction.Left;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                isAlive = true;
                direction = Direction.Right;
            }

            // move the player
            if (isAlive)
            {
                switch (direction)
                {
                    case Direction.Up:
                        position.Y -= speed;
                        break;
                    case Direction.Down:
                        position.Y += speed;
                        break;
                    case Direction.Left:
                        position.X -= speed;
                        break;
                    case Direction.Right:
                        position.X += speed;
                        break;
                    default:
                        break;
                }
            }
            
            

        }




    }
}
