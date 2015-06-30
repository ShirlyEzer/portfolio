using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace C14_Ex02_Shirly_304816499_Oreyan_201435484
{
    /// <summary>
    /// Design Pattern - Factory Methods
    /// This class is the Concrete Product
    /// </summary>
    public class AngryEmotionManager : EmotionManager
    {
        public AngryEmotionManager()
        {
            this.Quote = "Anger doesn't solve anything. it builds nothing, but it can destroy everything.";
        }

        protected override void OpenEmotionalSong()
        {
            Process.Start("https://www.youtube.com/watch?v=4kQMDSw3Aqo");
        }

        protected override Bitmap GetSmileyImage()
        {
            return Properties.Resources.AngrySmiley;
        }
    }
}
