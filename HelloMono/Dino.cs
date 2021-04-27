using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloMono
{
    public class CDino
    {
        

        Vector2 position;
        Rectangle drawRec;
        Vector2 origin = new Vector2(0, 0);


        readonly float alpha = 1.0f;
        readonly float rotation = 0.0f;
        readonly float scale = 3f;
        readonly SpriteEffects spriteEffect = SpriteEffects.None;
        readonly float zDepth = 0.1f;
        private Texture2D Mytexture;

        public CDino(Texture2D texture)
        {
            drawRec = new Rectangle(0, 0, 16 + 1, 19 + 1);

            Mytexture = texture;
            drawRec = new Rectangle(0, 0, 16 + 1, 19 + 1);
            position = new Vector2(20, 20);
            origin = new Vector2(20, 20);
        }



        public void Update()    //ET: keyboard oustside
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(   Mytexture, 
                position,
                drawRec,
                Color.White * alpha,
                rotation,
                origin,
                scale,
                spriteEffect,
                zDepth);

        }
    }
}



