using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo.Content.Sprites
{
    public class balas : aviao
    {
        private float _timer;

        public balas(Texture2D texture)
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<aviao> avioes)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(_timer >  LifeSpan)
            IsRemoved = true;
            Position += Direction * LinearVelocity;

        }
    }
}
