using System;
using System.Collections.Generic;
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
        readonly SpriteEffects spriteEffect = SpriteEffects.None;
        private float zDepth = 1;
        

        // spike class
        List<CSpike> Spikes = new List<CSpike>();
        
        // "properties"
        private int hasTree = random.Next(0,5);
        private int hasCane = random.Next(0,4);
        private int hasSpike = random.Next(0, 3);
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
        
 

        public CDirt(Texture2D texture, Vector2 _position, bool _PotentialllyDangerous)
        {

            spriteSheet = texture;
            position = _position;

            drawRec = dirt[dirtSpriteNumber];

            if (hasSpike == 1 && _PotentialllyDangerous)
            {
                Spikes.Add(new CSpike(spriteSheet, new Vector2(position.X,position.Y)));
                hasCane = 0;
                hasTree = 0;
            }

        }
        
        
        
        public void Update()
        {
            position.X -= 2;
            
            foreach (CSpike spike in Spikes)
            {
                spike.Update(position);
            }

        }

        int placement = random.Next(0, 2);
        
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
            
            
            foreach (CSpike spike in Spikes)
            {
                spike.Draw(spriteBatch);
            }
            
            if (hasCane == 1)
            {
                Vector2 canePos = new Vector2(position.X - (8*Game1.scale)*placement, position.Y - 8*Game1.scale); 
                
                spriteBatch.Draw(spriteSheet, 
                    canePos,
                    caneRect,
                    Color.White, 
                    rotation,
                    origin,
                    Game1.scale,
                    spriteEffect,
                    0.1f);
            }
            else if (hasTree == 1)
            {
                Vector2 treePos = new Vector2(position.X - (8*Game1.scale)*placement, position.Y - 8*Game1.scale); 
                
                spriteBatch.Draw(spriteSheet, 
                    treePos,
                    treeRect,
                    Color.White, 
                    rotation,
                    origin,
                    Game1.scale,
                    spriteEffect,
                    0.1f);
            }
            
            

        }


    }
}

