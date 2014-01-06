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
    public class Scorpion : AnimatedSprite
    {
        //Fields
        private PyramidPanic game;
        private Texture2D texture;
        private int speed = 2;

        //Constructor
        public Scorpion(PyramidPanic game) : base(game)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(@"Scorpion\Scorpion");
        }
        //update
        public void Update(GameTime gameTime)
        {
            if (this.destinationRectangle.X > (640 - 32) ||
                this.destinationRectangle.X < 0)
            {

                if (this.speed > 0)
                {
                    this.effect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    this.effect = SpriteEffects.None;
                }
               this.speed = this.speed * -1;      
            }
            this.destinationRectangle.X += this.speed;
            base.Update(gameTime);
        }


        //Draw

        public void Draw(GameTime gameTime)
        {
            base.Draw(gameTime, this.texture);
        }
    }
}
