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
        private static int scarabs = 0;
        private static int lives = 3;

        //maak een static method genaamt initialize() die potions = 0 en scarabs = 0
        //en lives =3initialiseerd. deze method roep je static aan: Score.initialize();

        public static void initialize()
        {
            points = 0;
            scarabs = 0;
            lives = 3;
        }



        // Properties
        public static int Points
        {
            get { return points; }
            set { points = value; }
        }
        public static int Scarabs
        {
            get { return scarabs; }
            set { scarabs = value; }
        }
        public static int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
    }
}
