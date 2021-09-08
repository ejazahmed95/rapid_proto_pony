using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Ponyform.Game
{
    public class SoundManager
    {

        ContentManager content;

        // Music
        public Song song;

        // Sound Effects
        public Dictionary<string, SoundEffect> soundEffects;


        public SoundManager(ContentManager content)
        {
            this.content = content;
        }

        public void LoadAssets()
        {
            // throw new System.NotImplementedException();
            song = content.Load<Song>("Sounds/Music");
            MediaPlayer.Play(song);
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;

            soundEffects = new Dictionary<string, SoundEffect>();
            soundEffects.Add("Drinking", content.Load<SoundEffect>("Sounds/Horse_drinking_01"));
            soundEffects.Add("Eating", content.Load<SoundEffect>("Sounds/Horse_Eating_01"));
            soundEffects.Add("Neigh", content.Load<SoundEffect>("Sounds/Horse_Neigh_01"));
            soundEffects.Add("Snort", content.Load<SoundEffect>("Sounds/Horse_Snort"));
            soundEffects.Add("Menu_Select_01", content.Load<SoundEffect>("Sounds/Menu_Select_01"));
            soundEffects.Add("Menu_Select_02", content.Load<SoundEffect>("Sounds/Menu_Select_02"));
            soundEffects.Add("UI_Select_01", content.Load<SoundEffect>("Sounds/UI_Select_01"));
            soundEffects.Add("UI_Select_02", content.Load<SoundEffect>("Sounds/UI_Select_02"));

        }

        private void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            MediaPlayer.Play(song);
        }
    }
} 