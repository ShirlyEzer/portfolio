using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace C14_Ex03_Shirly_304816499_Oreyan_201435484
{
    public class EmotionManager
    {
        private EmotionalPictureCreator m_PictureCreator;
        private MessageCreator m_MessageCreator;
        private IEmotionStrategy m_IEmotionStrategy;

        public User LoggedIn { get; set; }

        public Bitmap VideoImage { get; set; }

        public string Quote { get; protected set; }

        public EmotionManager(IEmotionStrategy i_IEmotionStrategy)
        {
            m_IEmotionStrategy = i_IEmotionStrategy;
            m_PictureCreator = new EmotionalPictureCreator();
            m_MessageCreator = new MessageCreator();
        }

        private void postEmotionPicture()
        {
            Bitmap smileyBmp = m_IEmotionStrategy.GetSmileyImage();
            Bitmap outputImage = m_PictureCreator.CreatePicture(smileyBmp, VideoImage);
            outputImage.Save(@"C:\Users\Public\Documents\Image.Jpeg");
            LoggedIn.PostPhoto(@"C:\Users\Public\Documents\Image.Jpeg", this.Quote);
        }

        public void PostEmotionalState()
        {
            Quote = m_IEmotionStrategy.GetQuote();
            postEmotionPicture();
            m_IEmotionStrategy.OpenEmotionalSong();
            m_MessageCreator.CreateMessage(this.Quote);
        }
    }
}
