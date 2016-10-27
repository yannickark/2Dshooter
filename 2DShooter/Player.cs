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
   public class Player
    {
        public Texture2D texture;
        public Vector2 position;
        public int speed;

        // Variables for collisions
        public Rectangle boundingBox;
        public bool isColliding;

        public Player()
        {
            texture = null;
            position = new Vector2(300, 300);
            speed = 10;
            isColliding = false;
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("ship");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Update(GameTime gameTime)
        { }
    }
}
