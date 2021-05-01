using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        private CSoundManager SoundManager;
        List<CDirt> Dirts = new List<CDirt>();
        
        //scale
        public static readonly float scale = 3;
        
        //score
        private SpriteFont font;
        public static int score;
        
        //sfx
        List<SoundEffect> soundEffects;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            soundEffects = new List<SoundEffect>();
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

          Dino = new CDino(dinoTexture, new Vector2(110,200));
          SoundManager = new CSoundManager(soundEffects);

          for( int i = 0; i < 13; i++ )
          {
              Dirts.Add(new CDirt(spriteSheet, new Vector2(72+((16*3)*i),250), false));
          }


        }

        protected override void LoadContent()
        {
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            dinoTexture = Content.Load<Texture2D>("dino_run");
            spriteSheet = Content.Load<Texture2D>("tiles");
            
            font = Content.Load<SpriteFont>("Score");
            
            soundEffects.Add(Content.Load<SoundEffect>("jump"));
            soundEffects.Add(Content.Load<SoundEffect>("damage"));
            
        }
        
        protected override void UnloadContent() {}
        
        private int generationCounter = 0;
        protected override void Update(GameTime gameTime)
        {

            score += 1;
            
            Dino.Update();

            foreach (CDirt Dirt in Dirts)
            {
                Dirt.Update();
            }

            generationCounter += 1;

            if (generationCounter >= (16 * 3))
            {
                Dirts.Add(new CDirt(spriteSheet, new Vector2(600, 250), true));
                Dirts.Add(new CDirt(spriteSheet, new Vector2(600+16*scale, 250), true));
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
            
            
            _spriteBatch.DrawString(font, "Score: " + score, new Vector2(400, 100), Color.White);

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
        

        
    }
    
    


}















        
