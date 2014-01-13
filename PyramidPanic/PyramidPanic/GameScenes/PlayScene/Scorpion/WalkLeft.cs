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
    //dit is een toestands class (dus moet hij de interface interface implementeren)
    //Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)
    public class WalkLeft : AnimatedSprite, IEntityState
    {
        //fields
        private Scorpion scorpion;

        //Constructor
        public WalkLeft(Scorpion scorpion)
            : base(beetle)
        {
            this.scorpion = scorpion;
            this.effect = SpriteEffects.FlipHorizontally;
            this.destinationRectangle = new Rectangle((int)this.scorpion.Position.X,
                                                      (int)this.scorpion.Position.Y,
                                                       32,
                                                       32);
        }

        public new void Update(GameTime gameTime)
        {
            if (this.scorpion.Position.X < 0)
            {
                //breng de beetle in de toestand walkdown
                this.scorpion.State = new WalkRight(this.scorpion);
            }
            this.scorpion.Position -= new Vector2(this.scorpion.Speed, 0f);
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
