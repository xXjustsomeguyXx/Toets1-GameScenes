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
       // fields
       private List<Image> images;
       private SpriteFont arial;

       public Panel(PyramidPanic game, Vector2 position)
       {
           //maak een instantie van de List<Image>
           this.images = new List<image>();


       }
    }
}
