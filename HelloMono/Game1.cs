using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloMono
{
    public class Game1 : Game
    {
        // load libraries
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        // load textures
        Texture2D dinoTexture;
        Texture2D spriteSheet;

        // bg color
        private readonly Color bg_color = new Color(14, 7, 27, 255);

        // load classes
        private CDino Dino;
        private CDirt Dirt;

        
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

          Dino = new CDino(dinoTexture);
          Dirt = new CDirt(spriteSheet, new Vector2(100,100));

        }
        

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            
            dinoTexture = Content.Load<Texture2D>("dino_run");
            spriteSheet = Content.Load<Texture2D>("tiles");

            //position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            //origin = new Vector2(texture.Width/2, texture.Height/2);


            
        }
        
        protected override void UnloadContent() {}

        protected override void Update(GameTime gameTime)
        {
 
            Dino.Update();
            Dirt.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(bg_color);
            
            
            
            // This can be bad later, because I don't know what it does. SamplerState.PointClamp makes resized pixel art sharp and the rest is hopefully default.
            _spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null);

            Dino.Draw(_spriteBatch);
            Dirt.Draw(_spriteBatch);

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }


}















        
