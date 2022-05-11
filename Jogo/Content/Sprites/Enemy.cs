using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo.Content.Sprites
{
   public class Enemy : aviao
    {
        public Enemy(Texture2D texture)
            :base(texture)
        {
            Position = new Vector2(Game1.Random.Next(700, Game1.ScreenWidth - _texture.Width), Game1.Random.Next(0, Game1.ScreenHeight- _texture.Height));
            speed = Game1.Random.Next(3,10);

        }
        public override void Update(GameTime gameTime, List<aviao> avioes)
        {
            if (Rectangle.Bottom <= Game1.ScreenWidth)
            {
                Position.X -= speed / 2;

                if(Rectangle.Bottom >= Game1.ScreenWidth)
                {
                    IsRemoved = true;
                }

            }

        foreach(var balas in avioes)
            {
                if (balas is Enemy)
                    continue;
                {
                    if (balas.Rectangle.Intersects(this.Rectangle))
                    {
                        IsRemoved = true;
                    }
                }
            }
                
        }

    }
}
