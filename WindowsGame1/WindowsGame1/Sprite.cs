using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Watch_Your_Back
{
    class Sprite
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        public Vector2 position;
        public Vector2 centre;
        public Rectangle rectangle;
        int height;
        int width;

        Color color;

        public Sprite(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, int height, int width, Color color)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.position = position;
            this.height = height;
            this.width = width;
            this.color = color;

        }

        public virtual void Update()
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            centre = new Vector2(rectangle.Center.X, rectangle.Center.Y);
        }

        public virtual void Draw()
        {
            spriteBatch.Draw(texture, position, color);
        }
    }
}
