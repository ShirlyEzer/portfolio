using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace C14_Ex02_Shirly_304816499_Oreyan_201435484
{
    public enum eEmotionManager
    {
        SadEmotion,
        HappyEmotion,
        AngeryEmotion
    }

    /// <summary>
    /// Design Pattern - Factory Methods
    /// This class is the Product
    /// </summary>
    public abstract class EmotionManager
    {
        private EmotionalPictureCreator m_PictureCreator;
        private MessageCreator m_MessageCreator;

        public User LoggedIn { get; set; }

        public Bitmap VideoImage { get; set; }

        public string Quote { get; protected set; }

        public EmotionManager()
        {
            m_PictureCreator = new EmotionalPictureCreator();
            m_MessageCreator = new MessageCreator();
        }

        protected virtual Bitmap GetSmileyImage()
        {
            return null;
        }

        private void postEmotionPicture()
        {
            Bitmap smileyBmp = GetSmileyImage();
            Bitmap outputImage = m_PictureCreator.CreatePicture(smileyBmp, VideoImage);
            outputImage.Save(@"C:\Users\Public\Documents\Image.Jpeg");
            LoggedIn.PostPhoto(@"C:\Users\Public\Documents\Image.Jpeg", this.Quote);
        }

        protected virtual void OpenEmotionalSong()
        {
        }

        public void PostEmotionalState()
        {
            postEmotionPicture();
            OpenEmotionalSong();
            m_MessageCreator.CreateMessage(this.Quote);
        }
    }
}
