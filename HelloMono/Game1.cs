using System;
using System.Collections.Generic;
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
        List<CDirt> Dirts = new List<CDirt>();
        
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
          base.Initialize();
          
          Window.Title = "Monogame TRex Runner";
          this.IsMouseVisible = true;
          Window.AllowUserResizing = true;

          _graphics.PreferredBackBufferWidth = 600;
          _graphics.PreferredBackBufferHeight = 500;   
          _graphics.ApplyChanges();

          Dino = new CDino(dinoTexture, new Vector2(110,226));

          for( int i = 0; i < 13; i++ )
          {
              Dirts.Add(new CDirt(spriteSheet, new Vector2(72+((16*3)*i),250)));
          }


        }
        

        protected override void LoadContent()
        {
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            dinoTexture = Content.Load<Texture2D>("dino_run");
            spriteSheet = Content.Load<Texture2D>("tiles");
            
        }
        
        protected override void UnloadContent() {}
        
        private int generationCounter = 0;
        protected override void Update(GameTime gameTime)
        {
            
            Dino.Update();

            foreach (CDirt Dirt in Dirts)
            {
                Dirt.Update();
            }

            generationCounter += 1;

            if (generationCounter >= (16 * 3))
            {
                Dirts.Add(new CDirt(spriteSheet, new Vector2(600, 250)));
                Dirts.Add(new CDirt(spriteSheet, new Vector2(600+16*3, 250)));
                generationCounter = 0;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            _spriteBatch.Begin(SpriteSortMode.BackToFront, // sort mode
                BlendState.AlphaBlend,
                SamplerState.PointClamp, // resizing algorithm?
                DepthStencilState.None,
                RasterizerState.CullNone,
                null);

            GraphicsDevice.Clear(bg_color);

            Dino.Draw(_spriteBatch);
            
            foreach (CDirt Dirt in Dirts)
            {
                Dirt.Draw(_spriteBatch);
            }
            

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }


}















        
