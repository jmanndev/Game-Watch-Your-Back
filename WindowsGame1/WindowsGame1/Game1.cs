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

    /// <summary>
    /// General Idea of Game:
    /// - lots of enemies
    /// - player always moving
    /// - if player isn't looking at enemies the enemies will move towards player
    /// - similar idea to the Boos in Super Mario Bros
    /// - make objectives on each level (key, door, traps to avoid, treasure, etc)
    /// 
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Random rand = new Random();

        int windowHeight = 960;
        int windowWidth = 640;

        /// <summary>
        /// BOARD
        /// BOARD
        /// BOARD
        /// </summary>
        
        Board board;
        Vector2 topLeft = Vector2.Zero;
        Vector2 topRight = new Vector2(640,0);
        Vector2 bottomLeft = new Vector2(0,960);
        Vector2 bottomRight = new Vector2(640,960);
        Texture2D tileTexture;
        int tileHeight = 64;
        int tileWidth = 64;


        /// <summary>
        /// PLAYER
        /// PLAYER
        /// PLAYER
        /// </summary>
        Player player;
        Texture2D playerTexture;
        Vector2 playerPosition = new Vector2(480, 320);
        int playerHeight = 64;
        int playerWidth = 64;
        Color playerColor = Color.White;


        /// <summary>
        /// ENEMY
        /// ENEMY
        /// ENEMY
        /// </summary>
        int numberOfEnemies = 10;
        List<Enemy> enemyList = new List<Enemy>();
        Texture2D enemyTexture;
        int enemyHeight = 16;
        int enemyWidth = 16;
        Color enemyColor = Color.White;

        

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.PreferredBackBufferWidth = windowWidth;
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerTexture = Content.Load<Texture2D>("player");
            enemyTexture = Content.Load<Texture2D>("enemy");
            tileTexture = Content.Load<Texture2D>("tile");

            player = new Player(this, spriteBatch, playerTexture, playerPosition, playerHeight, playerWidth, playerColor);
            board = new Board(spriteBatch, windowHeight, windowWidth, tileTexture, tileHeight, tileWidth);
            generateEnemies();

        }

        private void generateEnemies()
        {
            Enemy tempEnemy;
            Vector2 tempEnemyPosition;

            for (int i = 0; i < numberOfEnemies; i++)
            {
                tempEnemyPosition = new Vector2(rand.Next((int)topLeft.X + 5, (int)topRight.X - 5), rand.Next((int)topLeft.Y + 5, (int)bottomLeft.Y - 5));
                tempEnemy = new Enemy(spriteBatch, enemyTexture, tempEnemyPosition, enemyHeight, enemyWidth, enemyColor);
                enemyList.Add(tempEnemy);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            UpdateEnemy();
            player.Update(gameTime);
            base.Update(gameTime);
        }

        void UpdateEnemy()
        {
            foreach (Enemy enemy in enemyList)
            {
                enemy.Update();
                enemy.ChasePlayer(player);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (Enemy enemy in enemyList)
                enemy.Draw();

            player.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
