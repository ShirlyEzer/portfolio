using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace C14_Ex03_Shirly_304816499_Oreyan_201435484
{
    public class HappyEmotionStrategy : IEmotionStrategy
    {
        public string GetQuote()
        {
            return "Keep smiling and one day life will get tired of upsetting you.";
        }

        public void OpenEmotionalSong()
        {
            Process.Start("https://www.youtube.com/watch?v=y6Sxv-sUYtM");
        }

        public Bitmap GetSmileyImage()
        {
            return Properties.Resources.HappySmiley;
        }
    }
}
