using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Snake20200629
{
    public class SnakeHead : Component                                
    {
        #region MEMBERS

        public float _layer { get; set; }
        public Vector2 _origin { get; set; }
        protected Vector2 _position { get; set; }
        protected float _rotation { get; set; }
        protected Texture2D _texture { get; set; }

        private int speed = 2;
        public int radius = 25;
        public bool isAlive = false; // make false so player starts game still

        #endregion

        #region PROPERTIES
        public Color Color { get; set; }

        /// <summary>
        /// the sprite we want to follow
        /// </summary>
        public SnakeHead FollowTarget { get; set; }

        /// <summary>
        /// How close we want to be to our target
        /// </summary>
        public float FollowDistance { get; set; }

        public Vector2 Direction { get; set; }

        public float RotationVelocity = 3f;

        /// <summary>
        /// How fast sprite moves to follow sprite its follwoing
        /// </summary>
        public float LinearVelocity = 4;

        public float Layer
        {
            get { return _layer; }
            set { _layer = value; }
        }

        public Vector2 Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Rectangle Rectangle
        {
            get // create a rectangle around our sprite
            { 
                return new Rectangle((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, _texture.Width,_texture.Height);
            }
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }
        #endregion


        #region METHODS
        public override void Update(GameTime gameTime)
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

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException(); 
        }
        #endregion


    }
}
