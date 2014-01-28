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
    
    public class ExplorerIdleWalk : AnimatedSprite, IEntityState
    {
        //Fields methode van de ExploreridleWalk class
        private Explorer explorer;
        private Vector2 velocity;
        private int imageNumber = 1;
       
        //properties methode van de ExploreridleWalk class
        public SpriteEffects Effect
        {
            //Setter van de SpriteEffects
            set { this.effect = value; }
        }

        public float Rotation
        {
            // Setter van de Float
            set { this.rotation = value; }
        }

        //Constructor methode van de explorerIdleWalk
        public ExplorerIdleWalk(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X,
                                                      (int)this.explorer.Position.Y,
                                                      32,
                                                      32);
            this.sourceRectangle = new Rectangle(this.imageNumber * 32, 0, 32, 32);
            this.velocity = new Vector2(0f, 0f);
        }

        //Initialize methode van de explorerIdleWalk
        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }

        //Update methode van de explorerIdleWalk
        public new void Update(GameTime gameTime)
        {
            //Bij het indrukken van de Right knop moet de toestand van de explorer veranderen in
            // ExplorerWalkRight
            if (Input.EdgeDetectKeyUp(Keys.Right))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = 0f;
            }
            else if (Input.EdgeDetectKeyUp(Keys.Left))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.FlipHorizontally;
                this.explorer.Idle.Rotation = 0f;
            }
            else if (Input.EdgeDetectKeyUp(Keys.Down))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = (float)Math.PI / 2;
            }
            else if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.FlipVertically;
                this.explorer.Idle.Rotation = -(float)Math.PI / 2;
            }
            //zorgt voor de animatie. roept de update(GameTime gameTime) method aan van 
            // de animatedSprite class
            base.Update(gameTime);
        }

        //Draw methode van de explorerIdleWalk
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
