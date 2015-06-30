using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace C14_Ex03_Shirly_304816499_Oreyan_201435484
{
    public class EmotionalPictureCreator
    {
        public Bitmap CreatePicture(Bitmap i_SmileyBitmap, Bitmap i_VideoBitmap)
        {
            int outputImageWidth = 0;
            int outputImageHeight = 0;
            Bitmap outputImage = null;

            if (i_VideoBitmap != null)
            {
                outputImageWidth = i_SmileyBitmap.Width > i_VideoBitmap.Width ? i_SmileyBitmap.Width : i_VideoBitmap.Width;
                outputImageHeight = i_SmileyBitmap.Height + i_VideoBitmap.Height + 1;
                outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                using (Graphics graphics = Graphics.FromImage(outputImage))
                {
                    graphics.DrawImage(
                        i_SmileyBitmap, 
                        new Rectangle(new Point(), i_SmileyBitmap.Size), 
                        new Rectangle(new Point(), i_SmileyBitmap.Size), 
                        GraphicsUnit.Pixel);
                    graphics.DrawImage(
                        i_VideoBitmap, 
                        new Rectangle(new Point(0, i_SmileyBitmap.Height + 1), i_VideoBitmap.Size),
                        new Rectangle(new Point(), i_VideoBitmap.Size),
                        GraphicsUnit.Pixel);
                }
            }
            else
            {
                outputImage = i_SmileyBitmap;
            }

            return outputImage;
        }
    }
}
