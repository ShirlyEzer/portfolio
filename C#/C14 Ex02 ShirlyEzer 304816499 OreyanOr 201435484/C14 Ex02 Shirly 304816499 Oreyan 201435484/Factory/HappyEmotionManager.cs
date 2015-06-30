using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;

namespace C14_Ex02_Shirly_304816499_Oreyan_201435484
{
    /// <summary>
    /// Design Pattern - Factory Methods
    /// This class is the Concrete Product
    /// </summary>
    public class HappyEmotionManager : EmotionManager
    {
        public HappyEmotionManager()
        {
            this.Quote = "Keep smiling and one day life will get tired of upsetting you.";
        }

        protected override void OpenEmotionalSong()
        {
            Process.Start("https://www.youtube.com/watch?v=y6Sxv-sUYtM");
        }

        protected override Bitmap GetSmileyImage()
        {
            return Properties.Resources.HappySmiley;
        }
    }
}
