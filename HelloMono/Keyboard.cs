using Microsoft.Xna.Framework.Input;

namespace HelloMono
{
    public class CKeyboard
    {

        public CKeyboard()
        {
            
        }

        public bool GetInput()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Space);
        }
        
        
    }
}