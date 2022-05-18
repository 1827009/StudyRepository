using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace datadrivenTest.GameOctopus
{
    class SoundManager
    {
        Song bgm;
        List<SoundEffect> sounds = new List<SoundEffect>();

        public SoundManager(ContentManager content)
        {
            bgm = content.Load<Song>("Sounds/output_bgm");
            MediaPlayer.IsRepeating = true;
            
            MediaPlayer.Play(bgm);
        }
    }
}
