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
    public class WalkRight : AnimatedSprite, IEntityState
    {
        //fields
        private Scorpion scorpion;

        //Constructor
        public WalkRight(Scorpion scorpion) : base(scorpion)
        {
            this.scorpion = scorpion;
            this.destinationRectangle = new Rectangle((int)this.scorpion.Position.X,
                                                      (int)this.scorpion.Position.Y,
                                                       32,
                                                       32);
        }
        public void initialize()
        {
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
        }


        public new void Update(GameTime gameTime)
        {
            if (this.scorpion.Position.X > 640-32) 
            if (this.scorpion.Position.X > 640-17) 
            {
                //breng de beetle in de toestand walkdown
                this.scorpion.State = new WalkLeft(this.scorpion);
                this.scorpion.WalkRight.initialize();
            }
            this.scorpion.Position += new Vector2(this.scorpion.Speed, 0f);
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