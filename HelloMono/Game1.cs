﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloMono
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        

        Texture2D texture;

        
        readonly float alpha = 1.0f;
        readonly float rotation = 0.0f;
        readonly float scale = 3f;
        readonly SpriteEffects spriteEffect = SpriteEffects.None;
        readonly float zDepth = 0.1f;

        private readonly Color bg_color_day = new Color(66, 76, 110, 255);
        
        //private Array dino_frames = [0,1];

        private CDino Dino;

        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        protected override void Initialize()
        {
          base.Initialize();
          
          Window.Title = "My First Game";
          this.IsMouseVisible = true;
          Window.AllowUserResizing = true;

          _graphics.PreferredBackBufferWidth = 600;
          _graphics.PreferredBackBufferHeight = 500;   
          _graphics.ApplyChanges();

          Dino = new CDino(texture);

        }
        

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            
            texture = Content.Load<Texture2D>("dino_run");
           // drawRec = new Rectangle(0, 0, 16 + 1, 19 + 1);
            //position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            //origin = new Vector2(texture.Width/2, texture.Height/2);


            
        }
        
        protected override void UnloadContent() {}

        protected override void Update(GameTime gameTime)
        {
 
            Dino.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(bg_color_day);
            
            
            
            // This can be bad later, because I don't know what it does. SamplerState.PointClamp makes resized pixel art sharp and the rest is hopefully default.
            _spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null);

            Dino.Draw(_spriteBatch);

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}















        
