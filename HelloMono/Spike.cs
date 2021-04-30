using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HelloMono
{
    public class CSpike
    {
        
        // sprite drawing options
        readonly float rotation = 0.0f;
        readonly SpriteEffects spriteEffect = SpriteEffects.None;
        private float zDepth = 1;

        
        private static Random random = new Random();
        private int SpriteNumber = random.Next(0,3);

        // rects
        private static readonly Rectangle spike1Rect = new Rectangle(1,14,5,10);
        private static readonly Rectangle spike2Rect = new Rectangle(11,11,5,13);
        private static readonly Rectangle spike3Rect = new Rectangle(21,16,4,8);

        private Rectangle[] spikes = {spike1Rect, spike2Rect, spike3Rect};
        
        // texture
        private readonly Texture2D spriteSheet;
        private Rectangle drawRec;
       
        // vector info 
        Vector2 position;
        Vector2 origin;

        public CSpike(Texture2D _texture, Vector2 _position)
        {
            
            spriteSheet = _texture;
            position = _position;
            drawRec = spikes[SpriteNumber];

            position.Y -= spikes[SpriteNumber].Height*Game1.scale;

        }

        public void Update(Vector2 _position)
        {

            position.X = _position.X;
            
            if (position.X >= CDino.position.X && position.X <= CDino.position.X + CDino.drawRec.Width && 
                position.Y >= CDino.position.Y && position.Y <= CDino.position.Y + CDino.drawRec.Height)
            {
                Console.Write("Collsion!!!!");
            }
            
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, 
                position,
                drawRec,
                Color.White,
                rotation,
                origin,
                Game1.scale,
                spriteEffect,
                zDepth);
            
        }

    }
}