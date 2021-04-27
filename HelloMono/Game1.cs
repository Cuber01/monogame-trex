using System;
using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloMono
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        MyClass myNewClass;

        Texture2D texture;
        Vector2 position;
        Rectangle drawRec;
        float alpha = 1.0f;
        float rotation = 0.0f;
        Vector2 origin = new Vector2(0,0);
        float scale = 3f;
        SpriteEffects spriteEffect = SpriteEffects.None;
        float zDepth = 0.1f;

        private Color bg_color_day = new Color(66, 76, 110, 255);

        
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
          
        }
        

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            
            texture = Content.Load<Texture2D>("dino_run");
            drawRec = new Rectangle(0, 0, 16+1, 19+1);
            position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            origin = new Vector2(texture.Width/2, texture.Height/2);

            myNewClass = new MyClass();
            Console.WriteLine("My Class name is: " + myNewClass.name);

            myNewClass.ChangeName("Bob");
            Console.WriteLine("My Class name is: " + myNewClass.name);
            
        }
        
        protected override void UnloadContent() {}

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position.Y -= 2;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                position.Y += 2;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 2;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 2;
            }


                

            // TODO: Add your update logic here

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

                _spriteBatch.Draw(   texture, 
                    position,
                    drawRec,
                    Color.White * alpha,
                    rotation,
                    origin,
                    scale,
                    spriteEffect,
                    zDepth);

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}









        
