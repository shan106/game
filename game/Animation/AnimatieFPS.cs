using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Animation
{
    class AnimatieFPS
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimatieFPS(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }
    }
}
