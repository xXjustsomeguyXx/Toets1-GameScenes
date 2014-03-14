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
   public class Score
    {
       //Fields
       private static int points = 0;
       private static int scarab = 0;
       private static int lives = 3;


       //Properties
       public static int Points
       {
           get { return points; }
           set { points = value; }
       }
       public static int Scarab
       {
           get { return scarab; }
           set { scarab = value; }
       }
       public static int Lives
       {
           get { return lives; }
           set { lives = value; }
       }
    }
}
