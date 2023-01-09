using game.Animation;
using game.Collision;
using game.Command;
using game.Input;
using game.Interfaces;
using game.Kogel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Spelers
{
    public class Speler : ITransform, IColision
    {
        public Vector2 positie { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public List<Kogels> kogels;
        private Rectangle _collisionRectangle;
        private Colision colli;
        private IInputlezer inputReader = new Toetsenbord();
        private ICommand Movecommand = new BeweegCommand();
        private IEntityAnimation walk;
        private Texture2D kogel;
        private int backgroundsize = 1798;

        public Speler(Texture2D texture, List<Rectangle> blokken, ContentManager content)
        {
            // basis pos //
            positie = new Vector2(70, 1595);
            walk = new LoopAnimation(texture, this);
            // Read input for my hero class
            _collisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, 66, 86);
            colli = new Colision(this, blokken);
            kogels = new List<Kogels>()
            {
            new SchietCommand()
            {
            Bullet = new Bullet(),
            },
            };
            InitializeContent(content);
        }

        private void InitializeContent(ContentManager content)
        {
            kogel = content.Load<Texture2D>("Hero/kogel");
        }

        public void Update(GameTime gameTime, SoundEffect spring)
        {
            walk.Update(gameTime);

            Movecommand.Execute(gameTime, this, inputReader.LeesInput(), spring);

            _collisionRectangle.X = (int)positie.X;
            _collisionRectangle.Y = (int)positie.Y;
            CollisionRectangle = _collisionRectangle;

            colli.Update(gameTime, CollisionRectangle, backgroundsize, Movecommand);

            foreach (var sprite in kogels.ToArray())
                sprite.Update(gameTime, kogels, walk.sprite, this);

            DeleteBullet();
        }

        public void DeleteBullet()
        {
            for (int i = 0; i < kogels.Count; i++)
            {
                if (kogels[i].IsRemoved)
                {
                    kogels.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            walk.Draw(spriteBatch);
            foreach (var sprite in kogels)
                if (sprite.LinearVelocity != 0)
                    sprite.Draw(spriteBatch, kogel);
        }
    }
}
