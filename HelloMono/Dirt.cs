using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace HelloMono
{
    public class CDirt
    {
        // random init
        private static Random random = new Random();
        
        // sprite drawing options
        readonly float rotation = 0.0f;
        readonly float scale = 3f;
        readonly SpriteEffects spriteEffect = SpriteEffects.None;
        private int zDepth;

        
        // "properties"
        private int hasTree;
        private int hasCane;
        private int hasSpike;
        private int dirtSpriteNumber = random.Next(0,3);

        // decor rects
        private Rectangle treeRect = new Rectangle(40,16,8,8);
        private Rectangle caneRect = new Rectangle(32,16,8,8);
        
        // dirt rects
        private static readonly Rectangle dirt1Rect = new Rectangle(0,0,16,8);
        private static readonly Rectangle dirt2Rect = new Rectangle(16,0,16,8);
        private static readonly Rectangle dirt3Rect = new Rectangle(32,0,16,8);

        private Rectangle[] dirt = {dirt1Rect, dirt2Rect, dirt3Rect};
        
        // texture
        private readonly Texture2D spriteSheet;
        private Rectangle drawRec;
       
        // vector info 
        Vector2 position;
        Vector2 origin;
        
 

        public CDirt(Texture2D texture, Vector2 _position)
        {

            spriteSheet = texture;
            position = _position;

            drawRec = dirt[dirtSpriteNumber];
            Console.WriteLine(dirt[dirtSpriteNumber]);

            // TODO count if has flower is true
            // TODO count if has cane is true

        }
        
        
        
        public void Update()
        {
            //position.X -= 1;
        }

        
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, 
                position,
                drawRec,
                Color.White, 
                rotation,
                origin,
                scale,
                spriteEffect,
                zDepth);
            
            // TODO draw cane and flower
            

        }


    }
}

