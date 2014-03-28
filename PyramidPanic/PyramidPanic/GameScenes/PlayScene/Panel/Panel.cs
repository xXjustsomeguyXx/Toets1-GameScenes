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
    public class Panel
    {
        // Fields
        private List<Image> images;
        private SpriteFont arial;
        private SpriteFont comicSansMS;
        private PyramidPanic game;
        private Vector2 position;

        public Panel(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            // Maak een instantie van de List<Image>
            this.images = new List<Image>();

            this.images.Add(new Image(game, @"Panel\Panel", position, 'P'));
            this.images.Add(new Image(game, @"Panel\Scarab", position + new Vector2(8 * 32f, 0f), 'P'));
            this.images.Add(new Image(game, @"Panel\Lives", position + new Vector2(3 * 32f, 0f), 'P'));

            this.arial = game.Content.Load<SpriteFont>(@"Fonts\Arial");
            this.comicSansMS = game.Content.Load<SpriteFont>(@"Fonts\ComicSansMS");
            
        }

        public void Draw(GameTime gameTime)
        {
            // Teken de this.images list
            foreach (Image image in this.images)
            {
                image.Draw(gameTime);
            }
            this.game.SpriteBatch.DrawString(this.arial,
                                             Score.Lives.ToString(),
                                             this.position + new Vector2(4.3f * 32f, 0f),
                                             Color.Yellow);
            this.game.SpriteBatch.DrawString(this.arial,
                                             Score.Scarabs.ToString(),
                                             this.position + new Vector2(9.3f * 32f, 0f),
                                             Color.Yellow);
            this.game.SpriteBatch.DrawString(this.arial,
                                             Score.Points.ToString(),
                                             this.position + new Vector2(17.3f * 32f, 0f),
                                             Color.Yellow);
        }
    }
}
