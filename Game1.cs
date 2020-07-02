using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Snake20200629
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        Texture2D snakeHead_right;
        Texture2D snakeHead_left;
        Texture2D snakeHead_up;
        Texture2D snakeHead_down;
        Texture2D egg_sprite;
        Texture2D snake_body;

        SnakeHead snakeHead = new SnakeHead();
        SnakeBody snakeBody = new SnakeBody();
        Egg egg = new Egg();

        // score text
        SpriteFont font;

        public static int bodyCount = 0;
        public static int score = 0;
        public bool firstBodyAdded = false;

       

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // game window size
            _graphics.PreferredBackBufferWidth = 750;
            _graphics.PreferredBackBufferHeight = 750;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            // reset();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            snakeHead_right = Content.Load<Texture2D>("right");
            snakeHead_left = Content.Load<Texture2D>("left");
            snakeHead_up = Content.Load<Texture2D>("up");
            snakeHead_down = Content.Load<Texture2D>("down");
            egg_sprite = Content.Load<Texture2D>("egg");
            font = Content.Load<SpriteFont>("Impact12");
            snake_body = Content.Load<Texture2D>("snakeBody");
            
        }

     

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            snakeHead.Update();

            // snakehead and egg collision 
            int sum = egg.radius + snakeHead.radius;
            if (Vector2.Distance(snakeHead.Position, egg.EggPos) < sum) // if snake and egg collide
            {
                egg.Update(); // move egg to new position and increase score
            }



            foreach (SnakeBody body in SnakeBody.snakeBodies)
            {
                snakeBody.Update(gameTime);
            }

           

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            base.Draw(gameTime);        
            spriteBatch.Begin();

            // snake  HEAD direction
            if (!snakeHead.isAlive)
            {
                spriteBatch.Draw(snakeHead_right, new Vector2(snakeHead.Position.X - snakeHead.radius, snakeHead.Position.Y - snakeHead.radius), Color.White);
            }
            if (snakeHead.isAlive)
            {
                switch (snakeHead.direction)
                {
                    case Direction.Up:
                        spriteBatch.Draw(snakeHead_up, new Vector2(snakeHead.Position.X - snakeHead.radius, snakeHead.Position.Y - snakeHead.radius), Color.White);
                        break;
                    case Direction.Down:
                        spriteBatch.Draw(snakeHead_down, new Vector2(snakeHead.Position.X - snakeHead.radius, snakeHead.Position.Y - snakeHead.radius), Color.White);
                        break;
                    case Direction.Left:
                        spriteBatch.Draw(snakeHead_left, new Vector2(snakeHead.Position.X - snakeHead.radius, snakeHead.Position.Y - snakeHead.radius), Color.White);
                        break;
                    case Direction.Right:
                        spriteBatch.Draw(snakeHead_right, new Vector2(snakeHead.Position.X - snakeHead.radius, snakeHead.Position.Y - snakeHead.radius), Color.White);
                        break;
                    default:
                        break;
                }
            }
           

            // egg
            spriteBatch.Draw(egg_sprite, new Vector2(egg.EggPos.X - egg.radius, egg.EggPos.Y - egg.radius), Color.White);

            // score
            spriteBatch.DrawString(font, "Eggs eaten: " + score, new Vector2(3, 3), Color.White);

            // snake body
            foreach (SnakeBody body in SnakeBody.snakeBodies)
            { 
                if (snakeHead.isAlive)
                {
                    // when a body part is added, it needs to be drawn behind the previous one
                    // if the head = x, then body part 1 needs to be x - body distance. body part 2 needs to be x - (body distance * 2)
                    spriteBatch.Draw(snake_body, new Vector2(body.Position.X - body.radius, body.Position.Y - body.radius), Color.White);
                }
            }


            spriteBatch.End();

        }
    }
}
