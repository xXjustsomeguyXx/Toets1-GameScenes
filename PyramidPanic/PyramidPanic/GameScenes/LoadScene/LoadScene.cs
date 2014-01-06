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
   public class LoadScene : IState
    {
        //FieldAccessException van decimal class StartScene
        private PyramidPanic game;

        //Maak een variabele (reference) aan van de Menu class genaamd menu


        // Constructor van StartScene-class krijgt een object game mee van het type PyramidPanic
        public LoadScene(PyramidPanic game)
        {
            this.game = game;

            //roep de initialize method aan
            this.initialize();
        }
        
        //initialize methode. Deze methode initialiseert (geeft startwaarden aan variabelen)
        //void wil zeggen dat er niets teruggegeven wordt.
        public void initialize()
        {
            //roep de loadcontent method aan
            this.LoadContent();
        }

        //loadcontent methode. Deze methode maakt nieuwe objecten aan van de verschillende
        //classes.
        public void LoadContent()
        {
          
        }

        //update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        //en update alle variabelen, methods enz...
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                this.game.IState = this.game.StartScene;
            }
        }

        //draw methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en 
        // tekent de textures op het canvas
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.DarkOrange);
        }
    }
}
