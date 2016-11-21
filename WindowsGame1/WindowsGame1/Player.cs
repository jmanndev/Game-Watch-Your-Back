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
    class Player : Sprite
    {
        Keys keyLeft = Keys.A;
        Keys keyRight = Keys.D;
        Keys keyUp = Keys.W;
        Keys keyDown = Keys.S;

        public Vector2 direction = Vector2.Zero;

        float speed = 5.0f;

        public Player(Game game, SpriteBatch spriteBatch, Texture2D texture, Vector2 position, int height, int width, Color color)
            : base(spriteBatch, texture, position, height, width, color)
        {

        }

        public void Update(GameTime gameTime)
        {
            UpdateKeys();
            UpdatePosition();

            base.Update();
        }

        void UpdateKeys()
        {
            if (Keyboard.GetState().IsKeyDown(keyLeft))
            {
                direction = Vector2.UnitX * -1;
            }

            if (Keyboard.GetState().IsKeyDown(keyRight))
            {
                direction = Vector2.UnitX;
            }

            if (Keyboard.GetState().IsKeyDown(keyUp))
            {
                direction = Vector2.UnitY * -1;
            }

            if (Keyboard.GetState().IsKeyDown(keyDown))
            {
                direction = Vector2.UnitY;
            } 
        }

        void UpdatePosition()
        {
            position = position + (speed * direction);
        }

    }
}
