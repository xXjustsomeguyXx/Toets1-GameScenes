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
    
    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
       private GraphicsDeviceManager graphics;
       private SpriteBatch spriteBatch;

       //Maak een variabele aan van het type StartScene, PlayScene, HelpScene, GameOverScene, LoadScene
       private StartScene startScene;
       private PlayScene playScene;
       private HelpScene helpScene;
       private GameOverScene gameOverScene;
       private LoadScene loadscene;
       private ScoreScene scorescene;
       private QuitScene quitscene;
       
       //maak een variabele iState aan van het type interface IState
       private IState iState;

       #region Yolo
       //properties
       //maak de interface variabele iState beschikbaar buiten de class D.M.V
       //een property IState
       public IState IState
       {
           get { return this.iState; }
           set { this.iState = value; }
       }

       //maak het field this.startScene beschikbaar buiten de class d.m.v een
       //Property StartScene

       public StartScene StartScene
       {
           get { return this.startScene; }
       }
       //maak het field this.PlayScene beschikbaar buiten de class d.m.v een
       //Property StartScene
       public PlayScene PlayScene
       {
           get { return this.playScene; }
       }
       //maak het field this.HelpScene beschikbaar buiten de class d.m.v een
       //Property StartScene
       public HelpScene HelpScene
       {
           get { return this.helpScene; }
       }
       //maak het field this.GameoverScene beschikbaar buiten de class d.m.v een
       //Property StartScene
       public GameOverScene GameOverScene
       {
           get { return this.gameOverScene; }
       }

       //maak het field this.GameoverScene beschikbaar buiten de class d.m.v een
       //Property QuitScene
       public QuitScene QuitScene
       {
           get { return this.quitscene; }
       }
       
        //Maak het field this.spritebatch beschikbaar buiten de class.
       public SpriteBatch SpriteBatch
       {
           get { return this.spriteBatch; }
       }

       //maak het field this.HelpScene beschikbaar buiten de class d.m.v een
       //Property LoadScene
       public LoadScene LoadScene
       {
           get { return this.loadscene; }
       }

       public ScoreScene ScoreScene
       {
           get { return this.scorescene; }
       }
       #endregion


        //Dit is de constructor. heeft altijd dezelfde naam als class
        public PyramidPanic()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

    
        protected override void Initialize()
        {
            // Verander de titel van het canvas
            Window.Title = "Pyramid Panic Beta 00.00.00.01";

            //Maakt de muis zichtbaar
            IsMouseVisible = true;
            
            //Verandert de breedte van het canvas
            
            this.graphics.PreferredBackBufferWidth = 640;
            
            //verandert de hoogte van het canvas

            this.graphics.PreferredBackBufferHeight= 480;

            //Past de nieuwe hoogt en breedte toe.

            this.graphics.ApplyChanges();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Een spritebatch is nodig voor het tekenen van textures op het canvas
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //We maken nu het object/instantie aan van het type startScene. Dit doe je door
            //De constructor aan te roepen van de StartScene, PlayScene, HelpScene, GameOverScene, LoadScene, ScoreScene
            this.startScene = new StartScene(this);
            this.playScene = new PlayScene(this);
            this.helpScene = new HelpScene(this);
            this.gameOverScene = new GameOverScene(this);
            this.loadscene = new LoadScene(this);
            this.scorescene = new ScoreScene(this);
            this.quitscene = new QuitScene(this);

            this.iState = this.startScene;
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            // Zorgt dat het spel stopt wanneer je op de gamepad button back indrukt.
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();
            //De update method van de static Input class wordt aangeroepen
            Input.Update();
            // De update methode van het object dat toegewezen is aan het interface object
            // this.iState wordt aangeroepen.
            this.iState.Update(gameTime);
            
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
           
            //geef de achtergrond en kleur
            GraphicsDevice.Clear(Color.Aqua);
            
            //Voor een spritebatch instantie iets kan tekenen moet de begin() methode
            //aangeroepen worden
            this.spriteBatch.Begin();

            //De Draw methode van het object dat toegewezen is aan het interface-object 
            //this.iState wordt aangeroepen.
            this.iState.Draw(gameTime);

            //Nadat de spritebatch.draw() is aangeroepen moet de end() methode van de
            //Sprite class worden aangeroepen
            this.spriteBatch.End();
            
            base.Draw(gameTime);


        }
    }
}
