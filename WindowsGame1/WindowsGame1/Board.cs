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
    class Board
    {
        SpriteBatch spriteBatch;

        public static Board CurrentBoard;
        public Tile[,] tileGrid;

        Texture2D tileTexture;
        int tileHeight;
        int tileWidth;

        public Board(SpriteBatch sp, int windowHeight, int windowWidth, Texture2D tileTex, int tileHeight, int tileWidth)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.tileTexture = tileTex;
            this.spriteBatch = sp;
            GenerateBoard(windowHeight, windowWidth);
            CurrentBoard = this;
        }

        void GenerateBoard(int windowHeight, int windowWidth)
        {

        }

        void CreateBoard(int up, int across)
        {
            for (int y = 0; y < up; y++)
            {
                for (int x = 0; x < across; x++)
                {
                    Vector2 tilePosition = new Vector2(x * tileWidth, y * tileHeight);
                    tileGrid[y, x] = new Tile(spriteBatch, tileTexture, tilePosition, tileHeight, tileWidth, Color.White, false);

                }
            }
        }

        void CreateTopBlocks()
        {

        }


        public void Draw()
        {
            foreach (var tile in tileGrid)
            {
                tile.Draw();
            }
        }

        public bool checkTileCollision(Rectangle recToCheck)
        {
            foreach (var tile in tileGrid)
            {
                if (recToCheck.Intersects(tile.rectangle) && tile.isBlocked)
                    return true;
            }

            return false;
        }
    }
}