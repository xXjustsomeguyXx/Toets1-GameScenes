// Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
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

namespace PyramidPanic
{
    public class LevelGameOver : ILevel
    {
        // Fields
        private Level level;
        private Image gameOver;
        private float timer = 0f;

        // Properties

        // Constructor
        public LevelGameOver(Level level)
        {
            this.level = level;
            this.gameOver = new Image(level.Game, @"GameOver\GameOver", Vector2.Zero, '.');
            //this.overlay.Color = new Color(0f, 0f, 0f, 0.5f);
        }

        // Update
        public void Update(GameTime gameTime)
        {
            if (Input.MousePosition().X > 280 &&
                 Input.MousePosition().X < 360 &&
                 Input.MousePosition().Y > 250 &&
                 Input.MousePosition().Y < 275 &&
                 Input.EdgeDetectMousePressLeft() || Input.EdgeDetectKeyDown(Keys.Enter))
            {
                Score.initialize();
                level.Game.IState = level.Game.StartScene;
            }           
        }
        
        // Draw
        public void Draw(GameTime gameTime)
        {
            this.gameOver.Draw(gameTime);
        }
    }
}
