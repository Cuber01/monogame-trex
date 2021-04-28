using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloMono
{
    public class CDino
    {

        readonly float alpha = 1.0f;
        readonly float rotation = 0.0f;
        readonly float scale = 3f;
        readonly SpriteEffects spriteEffect = SpriteEffects.None;
        readonly float zDepth = 0.1f;
        private Texture2D Mytexture;
        
        
        Vector2 position;
        Rectangle drawRec;
        Vector2 origin;

        
        int anim_i;
        int anim_t;
        
        int[,] animation_frames = 
        {
             {1, 1, 15, 19},
             {17, 2, 15, 18},
             {34, 2, 15, 18},
             {50, 1, 15, 19}
        };
        


        
        public CDino(Texture2D texture)
        {


            Mytexture = texture;
            position = new Vector2(100, 100);
            origin = new Vector2(Mytexture.Width/2, Mytexture.Height/2);
            
        }



        public void Update()    // TODO Make a keyboard class
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
            
            Animate();

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

        private void Animate()
        {
            
            anim_t += 1;
            
            if (anim_t > 3)
            {
                if (anim_i <= 3)
                {


                    // TODO How do I use the whole array from a dimensional one in C#?
                    drawRec = new Rectangle(animation_frames[anim_i, 0], animation_frames[anim_i, 1], animation_frames[anim_i, 2] , animation_frames[anim_i, 3]);
                    anim_i += 1;
                }
                else
                {
                    anim_i = 0;
                }

                anim_t = 0;
            }
        }
    }
}



