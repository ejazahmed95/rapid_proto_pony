using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Ponyform.Game
{
    public class SoundManager
    {

        ContentManager content;

        // Music
        public Song song;
        
        // Sound Effects
        
        
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
        }

        private void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            MediaPlayer.Play(song);
        }
    }
}