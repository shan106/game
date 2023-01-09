using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Screens
{
    public abstract class State
    {
        public Game1 gamee;

        public ContentManager content;

        public GraphicsDevice graphicsDevice;

        public State(Game1 game, GraphicsDevice graphics, ContentManager content)
        {
            this.gamee = game;

            this.graphicsDevice = graphics;

            this.content = content;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch sprite);

        public abstract void Update(GameTime gameTime);
    }
}
