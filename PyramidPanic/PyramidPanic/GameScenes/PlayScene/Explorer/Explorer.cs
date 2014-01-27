﻿// Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
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
        //Fields
        private PyramidPanic game;
        private IEntityState state;
        private Texture2D texture;
        private int speed = 2;
        private Vector2 position;

        //Maak van iedere toestand (state) een field
        //private ExplorerWalkUp walkUp;
        private ExplorerWalkDown walkDown;
        private ExplorerWalkLeft walkLeft;
        private ExplorerWalkRight walkRight;
        private ExplorerIdle idle;
        private ExplorerIdleWalk idelWalk;

        //properties
        /*
        public ExplorerWalkUp WalkUp
        {
            get { return this.walkUp; }
        }
        */
        public ExplorerWalkDown WalkDown
        {
            get { return this.walkDown; }
        }
        public ExplorerWalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }
        public ExplorerWalkRight WalkRight
        {
            get { return this.walkRight;}
        }
        public ExplorerIdle Idle
        {
            get { return this.idle; }
        }
        public ExplorerIdleWalk IdleWalk
        {
            get { return this.idelWalk; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set { 
                    this.position = value;
                    this.state.Initialize();
                }
        }
        public IEntityState State
        {
            set { 
                this.state = value;
                this.state.Initialize();
                }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public int Speed
        {
            get { return this.speed; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        
        //Constructor
        public Explorer(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(@"Explorer\Explorer");
            //this.walkUp = new ExplorerWalkUp(this);
            this.walkDown = new ExplorerWalkDown(this);
            this.walkLeft = new ExplorerWalkLeft(this);
            this.walkRight = new ExplorerWalkRight(this);
            this.idelWalk = new ExplorerIdleWalk(this);
            this.idle = new ExplorerIdle(this);
            this.state = this.idle;
        }

        //Update
        public void Update(GameTime gameTime)
        {
           this.state.Update(gameTime);
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);                   
        }
    }
}
