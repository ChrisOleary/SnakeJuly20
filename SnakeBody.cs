using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Snake20200629
{
    class SnakeBody
    {
        private Vector2 position;
        public int radius = 30;
        private Vector2 previousPosition;
        public int distanceBetweenParts;
        public bool collided = false;
        public static List<SnakeBody> snakeBodies = new List<SnakeBody>();

        public int dirX;
        public int dirY;
     

        public Vector2 PreviousPosition
        {
            get { return previousPosition; }
            set { previousPosition = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

   
        
        // Constructors
        public SnakeBody()
        {

        }
        public SnakeBody(Vector2 newPos)
        {
            position = newPos;
        }

        // Methods
        public void Update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                this.dirX = 0;
                this.dirY = -1;
            }
            else if (kstate.IsKeyDown(Keys.Down))
            {
                this.dirX = 0;
                this.dirY = 1;
            }            
            else if (kstate.IsKeyDown(Keys.Left))
            {
                this.dirX = -1;
                this.dirY = 0;
            }            
            else if (kstate.IsKeyDown(Keys.Right))
            {
                this.dirX = 1;
                this.dirY = 0;
            }
        }

    }
}
