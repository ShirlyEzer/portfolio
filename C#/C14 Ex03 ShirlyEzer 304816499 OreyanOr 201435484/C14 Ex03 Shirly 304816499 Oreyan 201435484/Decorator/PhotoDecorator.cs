using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FacebookWrapper.ObjectModel;
using Facebook;

namespace C14_Ex03_Shirly_304816499_Oreyan_201435484
{
    public abstract class PhotoDecorator : IPhotoDecorated
    {
        protected IPhotoDecorated m_PhotoDecorated;

        public PhotoDecorator(IPhotoDecorated i_IPhotoDecorated)
        {
            m_PhotoDecorated = i_IPhotoDecorated;
        }

        public virtual Bitmap DecoratePhoto()
        {
            return m_PhotoDecorated.DecoratePhoto();
        }
    }
}
