using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DelMe
{
    class Enemies
    {
        public Texture2D texture;
        public Vector2 location;
        public Vector2 velocity;
        public bool isVisible = true;

        Random random = new Random();
        int randX, randY;

        public Enemies(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            location = newPosition;
            randY = random.Next(-4, 4);
            randX = random.Next(-4, -1);
            velocity = new Vector2(randX, randY);

        }

        public void Update(GraphicsDevice graphics)
        {
            location += velocity;

            if (location.Y <= 0 || location.Y >= graphics.Viewport.Height - texture.Height)
                velocity.Y = -velocity.Y;

            if (location.X < 0 - texture.Width)
                isVisible = false;
        }
      

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture,location,Color.WhiteSmoke);

        }
    }
}
