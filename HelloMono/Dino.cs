using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


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

        private bool OnGround = true;
        
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
            
        }



        public void Update()   
        {
            if (CKeyboard.SpacePressed())
            {
                if (position.Y == defPosY)
                {
                    position.Y -= 1f;
                    velocity += 5;
                    OnGround = false;
                    CSoundManager.PlaySound(0);
                }
            }

            Gravity();

            if (velocity < 0 && CKeyboard.DownArrowPressed() && OnGround == false)
            {
                velocity -= 0.3f;
            }
            
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

            if (position.Y >= defPosY)
            {
                velocity = 0;
                position.Y = defPosY;
                OnGround = true;
            }


            position.Y -= velocity;
        }
    }
}



