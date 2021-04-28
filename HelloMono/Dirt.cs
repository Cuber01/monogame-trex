using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace HelloMono
{
    public class CDirt
    {
        //Random random = new Random();
        
        private readonly float alpha = 1.0f;
        readonly float rotation = 0.0f;
        readonly float scale = 3f;
        readonly SpriteEffects spriteEffect = SpriteEffects.None;
        
        
        private int hasFlower;
        private int hasCane;
        private int hasSpike;
        private int spriteNumber;

        private int zDepth;

        private Texture2D CaneTexture;
        private Texture2D FlowerTexture;
        private Texture2D MyTexture;
        Vector2 position;
        Rectangle drawRec;
        Vector2 origin;

        public CDirt(Texture2D _CaneTexture, Texture2D _FlowerTexure, Texture2D _MyTexture, Rectangle _drawRec, Vector2 _position)
        {

            CaneTexture = _CaneTexture;
            FlowerTexture = _FlowerTexure;
            MyTexture = _MyTexture;
            drawRec = _drawRec;
            position = _position;

        }
        
        //spriteNumber = random.Next(4);
        

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(MyTexture, 
                position,
                drawRec,
                Color.White, // this *may* cause problems
                rotation,
                origin,
                scale,
                spriteEffect,
                zDepth);
            

        }

        public void Update()
        {

        }
    }
}

