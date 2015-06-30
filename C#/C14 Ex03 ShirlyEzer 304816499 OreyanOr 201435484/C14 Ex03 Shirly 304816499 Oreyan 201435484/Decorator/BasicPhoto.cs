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
    public class BasicPhoto : IPhotoDecorated
    {
        public BasicPhoto(Bitmap i_Bitmap)
        {
            DecoratedPhoto = i_Bitmap;
        }

        public Bitmap DecoratedPhoto { get; set; }

        public Bitmap DecoratePhoto()
        {
            return DecoratedPhoto;
        }
    }
}
