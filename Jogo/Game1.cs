using Jogo.Content.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Jogo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static Random Random;
        private List<aviao> _avioes;
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        private float _timer;
        private bool _hasStarted = false;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            IsMouseVisible = true;
            Random = new Random();

            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
     
        }

        protected override void LoadContent()
        {
            Restart();

            // TODO: use this.Content to load your game content here
        }

        private void Restart()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var navetexture = Content.Load<Texture2D>("nave");

            _avioes = new List<aviao>()
            {

                new nave(navetexture)
                {
                    Position = new Vector2 (100, 100),
                    Origin = new Vector2(navetexture.Width / 2, navetexture.Height / 2),
                    balas = new balas(Content.Load<Texture2D>("bala")),
                    speed = 2f,
                }

            };
            _hasStarted = false;
        }

        protected override void Update(GameTime gameTime)
        {

          if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _hasStarted = true;
            }

            if (!_hasStarted) return; 

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var aviao in _avioes.ToArray())
                aviao.Update(gameTime, _avioes);


            if (_timer > 0.55f)
            {
                _timer = 0;
                _avioes.Add(new Enemy(Content.Load<Texture2D>("enemyyy")));
            }
            PostUpdate();



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        private void PostUpdate()
        {
            for (int i = 0; i < _avioes.Count; i++)
            {
                var sprite = _avioes[i];
                if (sprite.IsRemoved)
                {
                    _avioes.RemoveAt(i);
                    i--;
                }

                if (sprite is nave)
                {
                    var nave = sprite as nave;
                    if (nave.Morto)
                    {
                        Restart();
                    }
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (var aviao in _avioes)
                aviao.Draw(_spriteBatch);
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
