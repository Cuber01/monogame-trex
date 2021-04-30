using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloMono
{
    public class CDino
    {
        
        readonly float rotation = 0.0f;
        readonly SpriteEffects spriteEffect = SpriteEffects.None;
        readonly float zDepth = 0.2f;
        private Texture2D Mytexture;
        
        public static Vector2 position;
        public static Rectangle drawRec;
        Vector2 origin;
        
        int anim_i;
        int anim_t;
        
        private float defPosY;
        private float velocity;
        
        private CKeyboard Input;
        
        int[,] animation_frames = 
        {
             {1, 1, 15, 19},
             {17, 2, 15, 18},
             {34, 2, 15, 18},
             {50, 1, 15, 19}
        };
        
        
        public CDino(Texture2D texture, Vector2 _position)
        {
            
            Mytexture = texture;
            position = _position;
            defPosY = _position.Y;
            origin = new Vector2(Mytexture.Width/2, Mytexture.Height/2);
            
        }



        public void Update()   
        {
            if (CKeyboard.GetInput())
            {
                if (position.Y == defPosY)
                {
                    position.Y -= 1f;
                    velocity += 5;
                }
            }

            Gravity();
            Animate();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(   Mytexture, 
                position,
                drawRec,
                Color.White,
                rotation,
                origin,
                Game1.scale,
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

        private void Gravity()
        {
            velocity -= 0.1f;
            //Console.WriteLine(position.Y);
           // Console.WriteLine( defPosY);
            if (position.Y > defPosY && position.Y < defPosY+5)
            {
                velocity = 0;
                position.Y = defPosY;
            }


            position.Y -= velocity;
        }
    }
}



