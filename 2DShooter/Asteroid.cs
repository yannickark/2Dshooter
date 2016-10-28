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
    public class Asteroid
    {
        public Rectangle boundingBox;
        public Texture2D texture;
        public Vector2 position;
        public Vector2 origin;
        public float rotationAngle;
        public int speed;
        public bool isColliding, destroyed;

        public Asteroid()
        {
            position = new Vector2(400, -50);
            texture = null;
            speed = 4;
            isColliding = false;
            destroyed = false;
        }

        public void loadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("asteroid");
            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;
        }

        public void Update(GameTime gameTime)
        {
            // Collision bounding box
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            // Asteroid movement
            position.Y = position.Y + speed;
            if (position.Y >= 950)
                position.Y = -50;

            // Asteroid rotation
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            rotationAngle += elapsed;
            float circle = MathHelper.Pi * 2;
            rotationAngle = rotationAngle % circle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!destroyed)
                spriteBatch.Draw(texture, position, null, Color.White, rotationAngle, origin, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
