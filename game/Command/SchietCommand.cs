using game.Input;
using game.Interfaces;
using game.Kogel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Command
{
    class SchietCommand : Kogels
    {
        public Bullet Bullet;
        private IInputlezer input = new Toetsenbord();

        public override void Update(GameTime gameTime, List<Kogels> sprites, SpriteEffects effect, ITransform trans)
        {
            Direction = new Vector2((float)Math.Cos(0), (float)Math.Sin(0));
            // naar rechts //
            if (input.LeesInput().Y == 1 && effect == SpriteEffects.None)
            {
                LinearVelocity = 4f;
                Position = new Vector2(trans.positie.X + 78, trans.positie.Y + 40);
                AddBullet(sprites);
            }
            // naar links //
            if (input.LeesInput().Y == 1 && effect == SpriteEffects.FlipHorizontally)
            {
                LinearVelocity = -4f;
                Position = new Vector2(trans.positie.X - 2, trans.positie.Y + 40);
                AddBullet(sprites);
            }
            LinearVelocity = 0;
        }

        public void AddBullet(List<Kogels> sprites)
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Direction = this.Direction;
            bullet.Position = this.Position;
            // afstand tussen bullets //
            bullet.LinearVelocity = this.LinearVelocity * 2;
            bullet.LifeSpan = 2f;
            bullet.Parent = this;
            sprites.Add(bullet);
        }
    }
}
