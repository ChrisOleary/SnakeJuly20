using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Snake20200629
{
    class SnakeBody
    {
        private Vector2 position;
        public static List<SnakeBody> snakeBodies = new List<SnakeBody>();
        public int bodyCount = 0;
        public int speed = 2;
        public int radius = 25;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public SnakeBody()
        {
        }

        public SnakeBody(Vector2 pos)
        {
            position = pos;
        }
      
        public void Update(Vector2 playerPos, GameTime gameTime, Direction dir)
        {
            if (bodyCount > 0)
            {
                float dt = (float)gameTime.ElapsedGameTime.TotalSeconds; // get delta time

                Vector2 moveDir = playerPos - position;
                moveDir.Normalize(); // Normalize reduces the number to 1
                position += (moveDir * speed * dt);
            }
            
        }

        

    }
}
