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
    class Enemy : Sprite
    {
        float speed = 1.5f;

        public Enemy(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, int height, int width, Color color)
            : base(spriteBatch, texture, position, height, width, color)
        {
            
        }

        public void ChasePlayer(Player player)
        {
            if (player.rectangle.Right < centre.X && player.direction.X == -1)
            {
                position.X -= speed;
            }

            if (player.rectangle.Left > centre.X && player.direction.X == 1)
            {
                position.X += speed;
            }

            if (player.rectangle.Bottom < centre.Y && player.direction.Y == -1)
            {
                position.Y -= speed;
            }

            if (player.rectangle.Top > centre.Y && player.direction.Y == 1)
            {
                position.Y += speed;
            }

        }
    }
}
