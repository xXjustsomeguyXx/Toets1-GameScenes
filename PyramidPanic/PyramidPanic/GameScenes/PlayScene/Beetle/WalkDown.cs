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
    // Dit is een toestands class (dus moet hij de interface implementeren)
    // Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)
    
    public class WalkDown : AnimatedSprite, IEntityState
    {
        //Fields methode Van de walkdown class
        private Beetle beetle;
        private Vector2 velocity;

        //Contstructor methode van de walkdown class
        public WalkDown(Beetle beetle) : base(beetle)
        {
            this.beetle = beetle;
            this.effect = SpriteEffects.FlipVertically;
            this.destinationRectangle = new Rectangle((int)this.beetle.Position.X,
                                                      (int)this.beetle.Position.Y,
                                                      32,
                                                      32);
            this.velocity = new Vector2(0f, this.beetle.Speed);
        }
        // de initialize methode van de Walkdown class
        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.beetle.Position.X;
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
        }
        // Update methode van de WalkDown class
        public new void Update(GameTime gameTime)
        {
            if (this.beetle.Position.Y > 480 - 32)
            {
                // Brengt de beetle in de walkUp class.
                this.beetle.State = new WalkUp(this.beetle);
                this.beetle.WalkUp.Initialize();
            }
            this.beetle.Position += this.velocity;
            this.destinationRectangle.X = (int)this.beetle.Position.X;
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
            base.Update(gameTime);
        }

        // Draw methode van de Walkdownclass
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
