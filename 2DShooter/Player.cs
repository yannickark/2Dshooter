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
        public Texture2D texture, bulletTexture;
        public Vector2 position;
        public int speed;
        public float bulletDelay;
        public Rectangle boundingBox;
        public bool isColliding;
        public List<Bullet> bulletList;

        public Player()
        {
            bulletList = new List<Bullet>();
            texture = null;
            position = new Vector2(300, 300);
            bulletDelay = 20;
            speed = 10;
            isColliding = false;
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("ship");
            bulletTexture = Content.Load<Texture2D>("playerbullet");

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);

            foreach (Bullet b in bulletList)
                b.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            //Controls
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                position.Y = position.Y - speed;

            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
                position.X = position.X - speed;

            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                position.Y = position.Y + speed;

            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
                position.X = position.X + speed;

            //Fire controls
            if (keyState.IsKeyDown(Keys.Space))
            {
                Shoot();
            }
            UpdateBullets();

            // Make sure ship stays inbounds

            if (position.X <= 0)
                position.X = 0;

            if (position.X >= 800 - texture.Width)
                position.X = 800 - texture.Width;

            if (position.Y <= 0)
                position.Y = 0;

            if (position.Y >= 950 - texture.Height)
                position.Y = 950 - texture.Height;
        }

        public void Shoot()
        {
            if (bulletDelay >= 0)
                bulletDelay--;
                
            if (bulletDelay <= 0)
            {
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(position.X + 32 - newBullet.texture.Width / 2, position.Y + 30);

                newBullet.isVisible = true;

                if (bulletList.Count() < 20)
                    bulletList.Add(newBullet);
            }

            if (bulletDelay == 0)
                bulletDelay = 20;    
        }

        public void UpdateBullets()
        {
            foreach (Bullet b in bulletList)
            {
                b.position.Y = b.position.Y - b.speed;

                if (b.position.Y <= 0)
                    b.isVisible = false;
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                if (!bulletList[i].isVisible)
                {
                    bulletList.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
