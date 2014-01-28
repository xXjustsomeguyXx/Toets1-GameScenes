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
    public class Beetle : IAnimatedSprite
    {
        //Fields methode van de class Beetle
        private PyramidPanic game;
        private IEntityState state;
        private Texture2D texture;
        private int speed = 2;
        private Vector2 position;

        //Maak van iedere toestand (state) een field
        private WalkUp walkUp;
        private WalkDown walkDown;

        //properties methode van de beetle class
        public WalkUp WalkUp
        {
            // Getter van Walkupclass
            get { return this.walkUp; }
        }
        public WalkDown WalkDown
        {
            // Getter van WalkDownclass
            get { return this.walkDown; }
        }
        public Vector2 Position
        {
            // Getter en Setter van de field Vector2
            get { return this.position; }
            set { this.position = value; }
        }
        public IEntityState State
        {
            // Setter van de IEntityState
            set { this.state = value; }
        }
        public PyramidPanic Game
        {
            // Getter van de Pyramidpanic Game (Hoofdclass)
            get { return this.game; }
        }
        public int Speed
        {
            // Getter van de field Speed om te bepalen hoesnel de beetle kan.
            get { return this.speed; }
        }
        public Texture2D Texture
        {
            // Getter van de field Texture2D 
            get { return this.texture; }
        }
        
        //Constructor methode van de Beetle class
        public Beetle(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(@"Beetle\Beetle");
            // De Constructor van de class Walkup
            this.walkUp = new WalkUp(this);
            // De Constructor van de class WalkDown
            this.walkDown = new WalkDown(this);
            this.state = this.walkUp;
        }

        //Update methode van de beetle class
        public void Update(GameTime gameTime)
        {
           this.state.Update(gameTime);
        }

        //Draw methode van de Beetle class
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);                   
        }
    }
}
