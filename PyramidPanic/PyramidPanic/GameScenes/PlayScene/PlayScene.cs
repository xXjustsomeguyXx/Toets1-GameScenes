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
   public class PlayScene : IState

    {
        //FieldAccessException van decimal class PlayScene
        private PyramidPanic game;
        private Beetle beetle;
       

        // Constructor van PlayScene-class krijgt een object game mee van het type PyramidPanic
        public PlayScene(PyramidPanic game)
        {
            this.game = game;
            this.initialize();
        }
        
        //initialize methode. Deze methode initialiseert (geeft startwaarden aan variabelen)
        //void wil zeggen dat er niets teruggegeven wordt.
        public void initialize()
        {
            this.LoadContent();
        }

        //loadcontent methode. Deze methode maakt nieuwe objecten aan van de verschillende
        //classes.
        public void LoadContent()
        {
            this.beetle = new Beetle(this.game, new Vector2(100f, 300f));
        }

        //update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        //en update alle variabelen, methods enz...
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                this.game.IState = this.game.StartScene;
            }
            this.beetle.Update(gameTime);
        }

        //draw methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en 
        // tekent de textures op het canvas
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Black);
            this.beetle.Draw(gameTime);
        }
    }
}
