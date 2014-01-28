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
    public class Explorer : IAnimatedSprite
    {
        //Fields methode van de Explorer class
        private PyramidPanic game;
        private IEntityState state;
        private Texture2D texture;
        private int speed = 2;
        private Vector2 position;

        //Maak van iedere toestand (state) een field
        //private ExplorerWalkUp walkUp;
        private ExplorerWalkUp walkUp;
        private ExplorerWalkDown walkDown;
        private ExplorerWalkLeft walkLeft;
        private ExplorerWalkRight walkRight;
        private ExplorerIdle idle;
        private ExplorerIdleWalk idelWalk;

        //properties methode van de explorer class
        
        public ExplorerWalkUp WalkUp
        {
            // Getter van de Walkup class
            get { return this.walkUp; }
        }
        
        public ExplorerWalkDown WalkDown
        {
            // getter van de walkDown class
            get { return this.walkDown; }
        }
        public ExplorerWalkLeft WalkLeft
        {
            // getter van de walkleft class
            get { return this.walkLeft; }
        }
        public ExplorerWalkRight WalkRight
        {
            // getter van de walkright class
            get { return this.walkRight;}
        }
        public ExplorerIdle Idle
        {
            // getter van de Exploreridle
            get { return this.idle; }
        }
        public ExplorerIdleWalk IdleWalk
        {
            // getter van de ExplorerIdleWalk
            get { return this.idelWalk; }
        }
        public Vector2 Position
        {
            // Getter en Setter van de Vector2
            get { return this.position; }
            set { 
                    this.position = value;
                    this.state.Initialize();
                }
        }
        public IEntityState State
        {
            // Setter van de IEntityState
            set { 
                this.state = value;
                this.state.Initialize();
                }
        }
        public PyramidPanic Game
        {
            //Getter van de PyramidPanic
            get { return this.game; }
        }
        public int Speed
        {
            //Getter van de field speed, om mee te bepalen hoesnel je kan gaan.
            get { return this.speed; }
        }
        public Texture2D Texture
        {
            //Getter van de Texture2D
            get { return this.texture; }
        }
        
        //Constructor methode van de Explorer class
        public Explorer(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(@"Explorer\Explorer");
            // De Constructor van de class Walkup
            this.walkUp = new ExplorerWalkUp(this);
            // De Constructor van de class WalkDown
            this.walkDown = new ExplorerWalkDown(this);
            // De Constructor van de class WalkLeft
            this.walkLeft = new ExplorerWalkLeft(this);
            // De Constructor van de class WalkRight
            this.walkRight = new ExplorerWalkRight(this);
            this.idelWalk = new ExplorerIdleWalk(this);
            this.idle = new ExplorerIdle(this);
            this.state = this.idle;
        }

        //Update methode van de Explorer class
        public void Update(GameTime gameTime)
        {
           this.state.Update(gameTime);
        }

        //Draw Methode van de explorer class
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);                   
        }
    }
}
