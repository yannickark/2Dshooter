using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DShooter
{
    public class Starfield
    {
        public Texture2D texture;
        public Vector2 bPos1, bPos2;
        public int speed;

        public Starfield()
        {
            texture = null;

            // 2 backgrounds (1 out of bounds and comes in)
            bPos1 = new Vector2(0, 0);
            bPos2 = new Vector2(0, -950);

            speed = 5;
        }

        public void loadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("space");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bPos1, Color.White);
            spriteBatch.Draw(texture, bPos2, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //Background speed and scrolling background
            bPos1.Y = bPos1.Y + speed;
            bPos2.Y = bPos2.Y + speed;

            if (bPos1.Y >= 950)
            {
                bPos1.Y = 0;
                bPos2.Y = -950;
            }
        }
      
    }
}
