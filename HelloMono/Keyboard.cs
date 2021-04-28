using Microsoft.Xna.Framework.Input;

namespace HelloMono
{
    public class CKeyboard
    {

        public void GetInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
             //    position.Y -= 2;
            }
                        
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
              //  position.Y += 2;
            }
                        
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
             //  position.X -= 2;
            }
                        
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
               //position.X += 2;
            }
        }
        
        
    }
}