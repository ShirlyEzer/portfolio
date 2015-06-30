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
    public class SadEmotionManager : EmotionManager
    {
        public SadEmotionManager()
        {
            this.Quote = "Everyone wants happiness, no one wants pain, but you can't make a rainbow without a little rain.";
        }

        protected override void OpenEmotionalSong()
        {
            Process.Start("https://www.youtube.com/watch?v=ovP1XkecXrk");
        }

        protected override Bitmap GetSmileyImage()
        {
            return Properties.Resources.SadSmiley;
        }
    }
}
