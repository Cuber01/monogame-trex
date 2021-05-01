using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;

namespace HelloMono
{
    
    public class CSoundManager
    {
        static List<SoundEffect> soundEffects;

        public CSoundManager(List<SoundEffect> sfx)
        {
            soundEffects = sfx;
        }

        public static void PlaySound(int number)
        {
            soundEffects[number].Play();
        }

    }
}