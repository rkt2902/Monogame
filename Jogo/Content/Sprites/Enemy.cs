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

                if(Rectangle.Left <= 0)
                {
                    IsRemoved = true;
                }

            }

        foreach(var aviao in avioes)
            {
                if (aviao is Enemy)
                    continue;
                {
                    if (aviao.Rectangle.Intersects(this.Rectangle) && fire == true)
                    {
                       IsRemoved = true;
                        if(aviao is nave)
                        {
                            var nave = aviao as nave;
                            nave.IsRemoved = true;
                            nave.Morto = true;
                            
                        }
                    }
                }
            }
                
        }

    }
}
