using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace C14_Ex03_Shirly_304816499_Oreyan_201435484
{
    public class AngryEmotionStrategy : IEmotionStrategy
    {
        public string GetQuote()
        {
            return "Anger doesn't solve anything. it builds nothing, but it can destroy everything.";
        }

        public void OpenEmotionalSong()
        {
            Process.Start("https://www.youtube.com/watch?v=4kQMDSw3Aqo");
        }

        public Bitmap GetSmileyImage()
        {
            return Properties.Resources.AngrySmiley;
        }
    }
}
