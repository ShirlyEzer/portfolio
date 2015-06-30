using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using WebCam_Capture;

namespace C14_Ex03_Shirly_304816499_Oreyan_201435484
{
    public class WebCamImageCapturer
    {
        private WebCamCapture m_WebCam = null;
        private PictureBox pictureBoxFrameImage;
        private int m_FrameNumber = 30;

        private WebCamImageCapturer()
        {
            this.m_WebCam = new WebCamCapture();
        }

        public static WebCamImageCapturer Instance
        {
            get { return Singleton<WebCamImageCapturer>.Instance; }
        }

        public static void SaveImageCapture(Image i_Image)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string filename = null;
            FileStream fstream = null;

            saveFileDialog.FileName = "Image";
            saveFileDialog.DefaultExt = ".Jpg";
            saveFileDialog.Filter = "Image (.jpg)|*.jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;
                fstream = new FileStream(filename, FileMode.Create);
                i_Image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                fstream.Close();
            }
        }

        public void InitializeWebCam(ref PictureBox io_ImageControl)
        {
            m_WebCam.FrameNumber = (ulong)0ul;
            m_WebCam.TimeToCapture_milliseconds = m_FrameNumber;
            m_WebCam.ImageCaptured += new WebCamCapture.WebCamEventHandler(webcam_ImageCaptured);
            pictureBoxFrameImage = io_ImageControl;
        }

        private void webcam_ImageCaptured(object source, WebcamEventArgs e)
        {
            pictureBoxFrameImage.Image = e.WebCamImage;
        }

        public void Start()
        {
            m_WebCam.TimeToCapture_milliseconds = m_FrameNumber;
            m_WebCam.Start(m_WebCam.FrameNumber);
        }

        public void Stop()
        {
            m_WebCam.Stop();
        }

        public void Continue()
        {
            m_WebCam.TimeToCapture_milliseconds = m_FrameNumber;
            m_WebCam.Start(this.m_WebCam.FrameNumber);
        }

        public void ResolutionSetting()
        {
            m_WebCam.Config();
        }

        public void AdvanceSetting()
        {
            m_WebCam.Config2();
        }
    }
}
