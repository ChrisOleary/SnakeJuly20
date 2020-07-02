using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Data.Common;

namespace Snake20200629
{
    class Egg
    {
        private Vector2 eggPos = new Vector2(100,300);
        public int radius = 5;
        public bool eaten = false;



        public Vector2 EggPos
        {
            get { return eggPos; }
            set { eggPos = value; }
        }


        public void Update()
        {
            Random rand = new Random();
            eggPos = new Vector2(rand.Next(100, 500), rand.Next(100, 500));
            Game1.score++;
            
        }

    }
}
