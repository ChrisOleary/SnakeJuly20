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

        public bool collided = false;
        public static List<SnakeBody> snakeBodies = new List<SnakeBody>();
        
        // Constructors
        public SnakeBody()
        {

        }
        public SnakeBody(Vector2 newPos)
        {
            position = newPos;
            previousPosition = newPos;
            distanceBetweenParts = (radius * Game1.bodyCount);
        }

        // Methods
        public void Update(Vector2 playerPosition)
        {
            if (Game1.score == 1 && Game1.bodyCount == 0)
            {
                SnakeBody.snakeBodies.Add(new SnakeBody(new Vector2(playerPosition.X, playerPosition.Y)));
                // previousPosition = new Vector2(playerPosition.X, playerPosition.Y);
            }
            if (Game1.score > Game1.bodyCount && Game1.bodyCount != 0) // when the score gets increaed and bodypart already exists
            {
                SnakeBody.snakeBodies.Add(new SnakeBody(new Vector2(snakeBodies[1 - Game1.bodyCount].Position.X, snakeBodies[1 - Game1.bodyCount].Position.Y)));
            }
        }

    }
}
