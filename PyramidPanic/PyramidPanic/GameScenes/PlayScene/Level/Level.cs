// Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class Level
    {
        // Fields
        private PyramidPanic game;
        private int levelIndex;
        private Stream stream;
        private List<String> lines;
        private Block[,] blocks;
        private Image background;
        private Explorer explorer;
        private List<Scorpion> scorpions;
        private Panel panel;
        private ILevel state;
        private LevelPause pause;
        private LevelPlay play;
        private LevelGameOver gameOver;

        // In deze list worden de beetles opgeslagen
        private List<Beetle> beetles;

        // In deze list worden de treasures opgeslagen. Het zijn Image-objecten
        private List<Image> treasures;

        // Properties
        // Maak een property voor de Explorer
        public Explorer Explorer
        {
            get { return this.explorer; }
        }

        // Maak een property voor de state field
        public ILevel State
        {
            get { return this.state;  }
            set { this.state = value; }
        }
        public LevelPause Pause
        {
            get { return this.pause; }
            set { this.pause = value; }
        }
        public LevelPlay Play
        {
            get { return this.play; }
            set { this.play = value; }
        }
        public LevelGameOver GameOver
        {
            get { return this.gameOver; }
        }

        public List<Image> Treasures
        {
            get { return this.treasures; }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public int LevelIndex
        {
            get { return this.levelIndex; }
        }
        public List<Scorpion> Scorpions
        {
            get { return this.scorpions; }
        }
        public List<Beetle> Beetles
        {
            get { return this.beetles; }
        }
        public Block[,] Blocks
        {
            get { return this.blocks; }
        }


        // Constructor
        public Level(PyramidPanic game, int levelIndex)
        {
            this.game = game;
            this.levelIndex = levelIndex;
            this.pause = new LevelPause(this);
            this.play = new LevelPlay(this);
            this.gameOver = new LevelGameOver(this);
            this.state = this.play;
            this.Initialize(levelIndex);
        }

        public void Initialize(int levelIndex)
        {
            //Laad het textbestand met behulp van een stream object
            this.stream = TitleContainer.OpenStream(@"Content\Level\" +levelIndex + "0.txt");
            this.LoadAssets();
        }

        // Update
        public void Update(GameTime gameTime)
        {
            if (Score.Lives == 0)
            {
                this.state = this.gameOver;
            }
            this.state.Update(gameTime);
        }


        // Draw
        public void Draw(GameTime gameTime)
        {
            // Teken eerst de achtergrond.
            this.background.Draw(gameTime);
            
            // Het blocks-array wordt getekend
            for (int row = 0; row < this.blocks.GetLength(1); row++)
            {
                for (int column = 0; column < this.blocks.GetLength(0); column++)
                {
                    this.blocks[column, row].Draw(gameTime);
                }
            }
            // Teken het panel
            this.panel.Draw(gameTime);
           
            // Teken alle Image objecten in de treasureslist
            foreach (Image treasure in this.treasures)
            {
                treasure.Draw(gameTime);
            }

            // Teken de scorpions
            foreach (Scorpion scorpion in this.scorpions)
            {
                scorpion.Draw(gameTime);
            }

            // Teken de beetles
            foreach (Beetle beetle in this.beetles)
            {
                beetle.Draw(gameTime);
            }

            // De explorer wordt getekend
            this.explorer.Draw(gameTime);
            this.state.Draw(gameTime);
        }

        private void LoadAssets()
        {
            // Maak een list<Scorpion> waarin we scorpion-objecten in kunnen opslaan.
            this.scorpions = new List<Scorpion>();

            // Maak een list<Beetle> waarin we beetle-objecten in kunnen opslaan.
            this.beetles = new List<Beetle>();

            // Maak een list<Image> waarin we de treasures in op kunnen slaan.
            this.treasures = new List<Image>();

            // Deze list van strings slaat elke regel van 0.txt op
            this.lines = new List<string>();
            
            // Het readerobject kan lezen wat er in het tekstbestand staat.
            StreamReader reader = new StreamReader(this.stream);

            // Lees de eerste regel uit het tekstbestand in
            string line = reader.ReadLine();

            // Bepaal hoeveel tekens een regel lang is (blijkt 20 te zijn)
            int lineWidth = line.Length;

            // De while lus leest alle regels uit het tekstbestand en zet deze 
            // in de list<String> this.lines
            while (line != null)
            {
                // Stop de uitgelezen regel in de List<String> this.lines
                this.lines.Add(line);
                // Lees de volgende regel uit het tekstbestand met reader.Readline()
                line = reader.ReadLine();
            }

            // Bepaal uit hoeveel regels het tekstbestand bestaat (blijken 15 regels te zijn)
            int amountOfLines = this.lines.Count;
            
            // Vernietig het reader object. Niet meer nodig. Het bestand is uitgelezen
            reader.Close();
            // Vernietig het stream object. Niet meer nodig. Het bestand is uitgelezen.
            this.stream.Close(); 

            // Dit tweedimensionale array bevat block-objecten
            this.blocks = new Block[lineWidth, amountOfLines];

            //We gaan het blocks-array doorlopen met een dubbele for-lus
            for (int row = 0; row < amountOfLines; row++)
            {
                for (int column = 0; column < lineWidth; column++)
                {
                    //We lezen iedere letter uit de lines-list uit in een char variabele
                    char blockElement = this.lines[row][column];
                    this.blocks[column, row] = this.LoadBlock(blockElement, column * 32, row * 32);
                }
            }

            ScorpionManager.Level = this;
            BeetleManager.Level = this;
            ExplorerManager.Level = this;
            ExplorerManager.Explorer = this.explorer;
        }

        public Block LoadBlock(char blockElement, int x, int y)
        {
            switch (blockElement)
            {
                case 's':
                    this.scorpions.Add(new Scorpion(this.game, new Vector2(x + 16f, y + 16f)));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true, '.');
                case 'b':
                    this.beetles.Add(new Beetle(this.game, new Vector2(x + 16f, y + 16f)));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true, '.');
                case 'c':
                    this.treasures.Add(new Image(this.game, @"Treasures\Cat", new Vector2(x, y), 'c'));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true, '.');
                case 'a':
                    this.treasures.Add(new Image(this.game, @"Treasures\Ankh", new Vector2(x, y), 'a'));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true, '.');
                case 'S':
                    this.treasures.Add(new Image(this.game, @"Treasures\Scarab", new Vector2(x, y), 'S'));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true, '.');
                case 'p':
                    this.treasures.Add(new Image(this.game, @"Treasures\potion", new Vector2(x, y), 'p'));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true, '.');
                case 'E':
                    this.explorer = new Explorer(this.game, new Vector2(x + 16f, y + 16f));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true, '.');                
                case 'x':
                    return new Block(this.game, @"Block\Block", new Vector2(x, y), false, 'x');
                case 'y':
                    return new Block(this.game, @"Block\Wall1", new Vector2(x, y), false, 'y');
                case 'z':
                    return new Block(this.game, @"Block\Wall2", new Vector2(x, y), false, 'z');
                case 'v':
                    return new Block(this.game, @"Block\Block_hor", new Vector2(x, y), false, 'v');
                case 'w':
                    return new Block(this.game, @"Block\Block_vert", new Vector2(x, y), false, 'w');
                case 'u':
                    return new Block(this.game, @"Block\Door", new Vector2(x, y), false, 'u');
                case '@':
                    this.background = new Image(this.game, @"Background\Background2", new Vector2(x, y), '@');
                    return new Block(this.game, @"Block\Block", new Vector2(x, y), false, 'x');
                case 'P':
                    this.panel = new Panel(this.game, new Vector2(x, y));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true, '.');
                case '.':
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true, '.');
                default:
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true, '.');
            }
        }
    }
}
