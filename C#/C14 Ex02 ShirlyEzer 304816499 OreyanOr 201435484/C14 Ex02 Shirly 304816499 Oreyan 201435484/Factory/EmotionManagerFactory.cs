using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C14_Ex02_Shirly_304816499_Oreyan_201435484
{ 
    /// <summary>
    /// Design Pattern - Factory Methods
    /// This class is the Creator
    /// </summary>
    public static class EmotionMangerFactory
    {
        public static EmotionManager Create(eEmotionManager i_EmotionManager)
        {
            EmotionManager emotionMangaer = null;

            switch (i_EmotionManager)
            {
                case eEmotionManager.AngeryEmotion:
                    emotionMangaer = new AngryEmotionManager();
                    break;
                case eEmotionManager.HappyEmotion:
                    emotionMangaer = new HappyEmotionManager();
                    break;
                case eEmotionManager.SadEmotion:
                    emotionMangaer = new SadEmotionManager();
                    break;
            }

            return emotionMangaer;
        }
    }
}
