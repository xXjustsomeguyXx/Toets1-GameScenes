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
    public class Beetle : IAnimatedSprite
    {
        //Fields
        private PyramidPanic game;
        private IEntityState state;
        private Texture2D texture;
        private int speed = 2;
        private Vector2 position;
        private int bottomBorder;
        private int topBorder;

        //Maak van iedere toestand (state) een field
        private WalkUp walkUp;
        private WalkDown walkDown;

        private Rectangle collisionRect;

        //properties
        public WalkUp WalkUp
        {
            get { return this.walkUp; }
        }
        public WalkDown WalkDown
        {
            get { return this.walkDown; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public IEntityState State
        {
            set { this.state = value; }
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
        public int BottomBorder
        {
            get { return this.bottomBorder; }
            set { this.bottomBorder = value; }
        }
        public int TopBorder
        {
            get { return this.topBorder; }
            set { this.topBorder = value; }
        }
        public Rectangle CollisionRect
        {
            get
            {
                this.collisionRect.Y = (int)this.position.Y - 16;
                return this.collisionRect; 
            }
        }


        //Constructor
        public Beetle(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.collisionRect = new Rectangle((int)this.position.X - 16,
                                               (int)this.position.Y - 16,
                                               32,
                                               32);
            this.texture = game.Content.Load<Texture2D>(@"Beetle\Beetle");
            this.walkUp = new WalkUp(this);
            this.walkDown = new WalkDown(this);
            this.state = this.walkUp;
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
