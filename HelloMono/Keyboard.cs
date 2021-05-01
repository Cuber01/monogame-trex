using Microsoft.Xna.Framework.Input;

namespace HelloMono
{
    public class CKeyboard
    {

        public CKeyboard()
        {
            
        }

        public static bool SpacePressed()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Space);
        }
        
        public static bool DownArrowPressed()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Down);
        }
        
        
    }
}