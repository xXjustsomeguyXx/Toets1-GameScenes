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
    public class ExplorerManager
    {
        // Fields
        // Leg de level instantie vast
        private static Level level;

        // Leg de explorer instantie vast
        private static Explorer explorer;

        // Properties
        public static Level Level
        {
            set { level = value; }
        }
        public static Explorer Explorer
        {
            set { explorer = value; }
        }


        // Constructor
        public ExplorerManager()
        {

        }

        // Methods
        // CollisionDetection tussen muren en explorer
        public static bool CollisionDectectionExplorerWalls()
        {
           // Doorloop het tweedimensionale Blocksarray en ....
           // eerst de rijen ( getLength(0) geeft het aantal rijen)
            for (int i = 0; i < level.Blocks.GetLength(0); i++)
            {
                // voor iedere rij wil je alle kolommen doorlopen
                // getLength(1) geeft het aantal kolommen
                for (int j = 0; j < level.Blocks.GetLength(1); j++)
                {
                    // Onderzoek voor ieder Blockelement in het array of de property
                    // Passable de waarde true heeft.
                    if ( level.Blocks[i, j].Passable == false )
                    {
                        // Onderzoek of de rectangles van het BlockElement en de Explorer
                        // elkaar overlappen. Geef dan de waarde true terug anders false
                        if (explorer.CollisionRect.Intersects(level.Blocks[i, j].Rectangle))
                        {
                            //Console.WriteLine("Ik raak een muur element i = " + i + " j = " + j);
                            return true;
                        }
                    }
                }
            } 
            return false;
        }

        // CollisionDetection tussen treasures en explorer
        public static void CollisionDetectTreasures()
        {
            foreach (Image image in level.Treasures)
            {
                if (explorer.CollisionRect.Intersects(image.Rectangle))
                {
                    level.Treasures.Remove(image);
                    switch(image.Character)
                    {
                        case 'c':
                            Score.Points += 100;
                        break;

                        case 'a':
                            Score.Points += 10;
                        break;

                        case 'S':
                            Score.Points += 50;
                            Score.Scarab += 1;
                        break;

                        case 'p':
                            Score.Lives += 1;
                        break;


                    }
                    break;
                }
            }
        }

        // CollisionDetection tussen de explorer en de Scorpions

        public static void CollisionDetectionScorpions()
        {
            foreach( Scorpion Scorpion in level.Scorpions)
            {
                if (explorer.CollisionRect.Intersects(Scorpion.CollisionRect))
                {
                    level.Scorpions.Remove(Scorpion);
                    Score.Lives--;
                    explorer.Position = new Vector2(10 * 32f - 16, 7 * 32f - 16);
                    break;
                }
            }

        }

        //collision detection tussen de explorer en de beetles

        public static void CollisionDetectionBeetles()
        {
            foreach (Beetle Beetle in level.Beetles)
            {
                if (explorer.CollisionRect.Intersects(Beetle.CollisionRect))
                {
                    level.Beetles.Remove(Beetle);
                    Score.Lives--;
                    explorer.Position = new Vector2(10 * 32f - 16, 7 * 32f - 16);
                    break;
                }
            }

        }
    }
}
