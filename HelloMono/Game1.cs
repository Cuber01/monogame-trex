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
        float scale = 2.0f;
        SpriteEffects spriteEffect = SpriteEffects.None;
        float zDepth = 0.1f;

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
            
            
            texture = Content.Load<Texture2D>(@"dino_run");
            drawRec = new Rectangle(0, 0, texture.Width, texture.Height);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin();
            
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









        
