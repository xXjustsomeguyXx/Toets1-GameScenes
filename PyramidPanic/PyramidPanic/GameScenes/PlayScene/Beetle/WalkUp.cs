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
    public class WalkUp : IBeetleState
    {
        //fields
        private Beetle beetle;

        //Constructor
        public WalkUp(Beetle beetle)
        {
            this.beetle = beetle;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {

        }
    }
}
