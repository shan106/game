using game.Screens;
using game.Screens.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private State cstate;
        private State nstate;
        private SoundEffect gamesound;

        public void State(State s)
        {
            nstate = s;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
            gamesound = Content.Load<SoundEffect>("Geluid/gamesound");
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            cstate = new Menu(this, GraphicsDevice, Content, false);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gamesound.Play();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)

        {
            if (nstate != null)
            {
                cstate = nstate;
                // terug resetten //
                nstate = null;
            }

            cstate.Update(gameTime);
            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            cstate.Draw(gameTime, _spriteBatch);
            base.Draw(gameTime);

            
        }

      
    }
}
