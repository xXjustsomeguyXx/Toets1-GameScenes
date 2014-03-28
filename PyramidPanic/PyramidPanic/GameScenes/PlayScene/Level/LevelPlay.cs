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
    public class LevelPlay : ILevel
    {
        // Fields
        private Level level;

        // Properties

        // Constructor
        public LevelPlay(Level level)
        {
            this.level = level;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            // We roepen de Update-method aan van de Scorpion-objecten
            foreach (Scorpion scorpion in level.Scorpions)
            {
                scorpion.Update(gameTime);
            }

            // We roepen de Update-method aan van de Beetle-class
            foreach (Beetle beetle in level.Beetles)
            {
                beetle.Update(gameTime);
            }

            // We roepen de Update method aan van de explorer zodat hij gaat bewegen
            level.Explorer.Update(gameTime);
        }

        // Draw
        public void Draw(GameTime gameTime)
        {

        }
    }
}
