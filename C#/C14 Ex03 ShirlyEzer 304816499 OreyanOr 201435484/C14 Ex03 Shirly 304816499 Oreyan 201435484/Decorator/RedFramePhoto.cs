using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace C14_Ex03_Shirly_304816499_Oreyan_201435484
{
    public class RedFramePhoto : PhotoDecorator
    {
        public RedFramePhoto(IPhotoDecorated i_IPhotoDecorated)
            : base(i_IPhotoDecorated)
        {
        }

        public override Bitmap DecoratePhoto()
        {
            Bitmap bitmap = m_PhotoDecorated.DecoratePhoto();
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawRectangle(new Pen(Brushes.Red, 5), new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            }
            
            return bitmap;
        }
    }
}
