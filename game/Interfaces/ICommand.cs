using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Interfaces
{
    public interface ICommand
    {
        void Execute(GameTime gameTime, ITransform transform, Vector2 richting, SoundEffect spring);

        public Vector2 snelheid { get; set; }
        public bool spring { get; set; }
    }
}
