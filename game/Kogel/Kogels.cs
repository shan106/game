using game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Kogel
{
    public class Kogels
    {
        public Vector2 Position;

        public Vector2 Direction;

        public float LinearVelocity;

        public Kogels Parent;

        public float LifeSpan;

        public bool IsRemoved;

        public Rectangle enemybullet;

        public virtual void Update(GameTime gameTime, List<Kogels> sprites, SpriteEffects effects, ITransform trans) { }

        public virtual void Draw(SpriteBatch spriteBatch, Texture2D _texture)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
