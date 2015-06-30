using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace C14_Ex03_Shirly_304816499_Oreyan_201435484
{
    public class SadEmotionStrategy : IEmotionStrategy
    {
        public string GetQuote()
        {
            return "Everyone wants happiness, no one wants pain, but you can't make a rainbow without a little rain.";
        }

        public void OpenEmotionalSong()
        {
            Process.Start("https://www.youtube.com/watch?v=ovP1XkecXrk");
        }

        public Bitmap GetSmileyImage()
        {
            return Properties.Resources.SadSmiley;
        }
    }
}
