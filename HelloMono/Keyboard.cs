using Microsoft.Xna.Framework.Input;

namespace HelloMono
{
    public class CKeyboard
    {

        public CKeyboard()
        {
            
        }

        public static bool GetInput()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Space);
        }
        
        
    }
}