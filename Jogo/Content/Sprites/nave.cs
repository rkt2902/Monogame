using Jogo.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo.Content.Sprites
{
    public class nave : aviao
    {
        public balas balas;


        public bool Morto = false;
        public nave(Texture2D texture)
             : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<aviao> avioes)
        {
            Mover(avioes);

            foreach (var aviao in avioes)
            {
                if (aviao is nave)
                    continue;
               if (aviao.Rectangle.Intersects(this.Rectangle))
                {
               this.Morto = true;
                }
            }
            
            Position += Velocity;
            Position.X = MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - Rectangle.Width);
            Position.Y = MathHelper.Clamp(Position.Y, 0, Game1.ScreenHeight - Rectangle.Height);
            Velocity = Vector2.Zero;
        }

        private void Mover(List<aviao> avioes)
        {
           

            previousKey = currentKey;
            currentKey = Keyboard.GetState();

            if (currentKey.IsKeyDown(Keys.A))
            {
                Velocity.X = Velocity.X - LinearVelocity / 2;
            }
            if (currentKey.IsKeyDown(Keys.D))
            {
                Velocity.X = Velocity.X + LinearVelocity / 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Velocity.Y = Velocity.Y - LinearVelocity;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Velocity.Y = Velocity.Y + LinearVelocity;
            }
            if ((currentKey.IsKeyDown(Keys.Space)) && (previousKey.IsKeyUp(Keys.Space)))
            {
                Disparo(avioes);
            }

            Direction = new Vector2(1, 0);
        }

        private void Disparo(List<aviao> avioes)
        {
            var Balas = balas.Clone() as balas;
            Balas.Direction = this.Direction;
            Balas.Position.X = this.Position.X +75 ;
            Balas.Position.Y = this.Position.Y -10 ;
            Balas.LinearVelocity = this.LinearVelocity * 2;
            Balas.LifeSpan = 2f;
            Balas.Parent = this;

            avioes.Add(Balas);
        }
    }
    }
