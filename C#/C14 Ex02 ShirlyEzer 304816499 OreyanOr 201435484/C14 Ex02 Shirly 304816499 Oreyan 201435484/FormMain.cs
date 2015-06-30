using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace C14_Ex02_Shirly_304816499_Oreyan_201435484
{
    public partial class FormMain : Form
    {
        private User LoggedInUser;
        private WebCamImageCapturer m_WebCamImageCapturer;
        private Color m_Paintcolor;
        private bool m_IsDraw = false;
        private int m_StartPositionX = 0;
        private int m_StartPositionY = 0;
        private bool m_IsTabFeature1Selected = false;
        private eItem m_CurrentItem;
        private FormAlbumPictures formAlbumPictures = null;
        private Bitmap m_DrawArea;
        private EmotionManager m_EmotionManger = null;

        public FormMain()
        {
            Graphics graphic;

            InitializeComponent();
            m_DrawArea = new Bitmap(pictureBoxUserPaint.Size.Width, pictureBoxUserPaint.Size.Height);
            graphic = Graphics.FromImage(m_DrawArea);
            graphic.Clear(Color.White);
        }

        public enum eItem
        {
            Rectangle,
            Ellipse,
            Line,
            Pencil,
            Eraser,
            Smiley
        }

        private void loginAndInit()
        {
            LoginResult result = FacebookService.Login(
                "1426551137587886", 
                "user_about_me", 
                "user_friends", 
                "friends_about_me", 
                "publish_stream", 
                "user_events", 
                "read_stream",
                "user_status", 
                "user_photos");

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                LoggedInUser = result.LoggedInUser;
                new Thread(fetchUserInfo).Start();
            }
            else
            {
                MessageBox.Show("Login failed! please try again.");
            }
        }

        private void fetchUserInfo()
        {
            picture_smallPictureBox.Invoke(new Action(() => picture_smallPictureBox.LoadAsync(LoggedInUser.PictureNormalURL)));
            
            textBoxStatus.Invoke(new Action(() =>
                {
                    if (LoggedInUser.Statuses.Count > 0)
                    {
                        textBoxStatus.Text = LoggedInUser.Statuses[0].Message;
                    }
                }));
            
            listBoxAlbumsNames.Invoke(new Action(() =>
                {
                    listBoxAlbumsNames.DisplayMember = "Name";
                    foreach (Album album in LoggedInUser.Albums)
                    {
                        listBoxAlbumsNames.Items.Add(album);
                    }
                }));
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void buttonSetStatus_Click(object sender, EventArgs e)
        {
            if (LoggedInUser != null)
            {
                LoggedInUser.PostStatus(textBoxStatus.Text);
            }
            else
            {
                MessageBox.Show("Log in to your Facebook account");
            }
        }

        private void linkNewsFeed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Thread(() =>
            {
                if (LoggedInUser != null)
                {
                    fetchNewsFeed();
                }
                else
                {
                    MessageBox.Show("Log in to your Facebook account");
                }
            }).Start();
        }

        private void fetchNewsFeed()
        {
            foreach (Post post in LoggedInUser.NewsFeed)
            {
                listBoxNewsFeed.Invoke(new Action(() =>
                    {
                        if (post.Message != null)
                        {
                            listBoxNewsFeed.Items.Add(post.Message);
                        }
                        else
                        {
                            if (post.Caption != null)
                            {
                                listBoxNewsFeed.Items.Add(post.Caption);
                            }
                            else
                            {
                                listBoxNewsFeed.Items.Add(string.Format("[{0}]", post.Type));
                            }
                        }
                    }));
            }  
        }

        private void linkFriends_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Thread(() =>
                {
                    if (LoggedInUser != null)
                    {
                        fetchFriends();
                    }
                    else
                    {
                        MessageBox.Show("Log in to your Facebook account");
                    }
                }).Start();
        }

        private void fetchFriends()
        {
            listBoxFriends.Invoke(new Action(() =>
                    {
                        listBoxFriends.DisplayMember = "Name";
                        foreach (User friend in LoggedInUser.Friends)
                        {
                            listBoxFriends.Items.Add(friend);
                        }
                    }));
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            new Thread(() =>
                {
                    if (LoggedInUser != null)
                    {
                        displaySelectedFriend();
                    }
                    else
                    {
                        MessageBox.Show("Log in to your Facebook account");
                    }
                }).Start();
        }

        private void displaySelectedFriend()
        {
            pictureBoxFriend.Invoke(new Action(() =>
                {
                    if (listBoxFriends.SelectedItems.Count == 1)
                    {
                        User selectedFriend = listBoxFriends.SelectedItem as User;
                        if (selectedFriend.PictureNormalURL != null)
                        {
                            pictureBoxFriend.LoadAsync(selectedFriend.PictureNormalURL);
                        }
                        else
                        {
                            picture_smallPictureBox.Image = picture_smallPictureBox.ErrorImage;
                        }
                    }
                }));
        }

        private void labelEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LoggedInUser != null)
            {
                fetchEvents();
            }
            else
            {
                MessageBox.Show("Log in to your Facebook account");
            }      
        }

        private void fetchEvents()
        {
            foreach (Event fbEvent in LoggedInUser.Events)
            {
                listBoxEvents.Items.Add(fbEvent.Name);
            }
        }

        private void linkCheckins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Thread(() =>
                {
                    if (LoggedInUser != null)
                    {
                        fetchCheckins();
                    }
                    else
                    {
                        MessageBox.Show("Log in to your Facebook account");
                    }
                }).Start();
        }

        private void fetchCheckins()
        {
            listBoxFriends.Invoke(new Action(() =>
            {
                foreach (Checkin checkin in LoggedInUser.Checkins)
                {
                    listBoxCheckins.Items.Add(string.Format("checked in at {0} (on {1})", checkin.Place.Name, checkin.CreatedTime));
                }
            }));
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            m_WebCamImageCapturer = WebCamImageCapturer.Instance;
            m_WebCamImageCapturer.InitializeWebCam(ref this.pictureBoxImageVideo);
            m_WebCamImageCapturer.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            m_WebCamImageCapturer.Stop();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            m_WebCamImageCapturer.Continue();
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            pictureBoxImageCapture.Image = pictureBoxImageVideo.Image;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            WebCamImageCapturer.SaveImageCapture(pictureBoxImageCapture.Image);
        }

        private void buttonPostPicture_Click(object sender, EventArgs e)
        {
            if (LoggedInUser != null)
            {
                if (pictureBoxImageCapture.Image != null)
                {
                    pictureBoxImageCapture.Image.Save(@"C:\Users\Public\Documents\Image.Jpeg", ImageFormat.Jpeg);
                    LoggedInUser.PostPhoto(@"C:\Users\Public\Documents\Image.Jpeg", textBoxPictureDescription.Text);
                    File.Delete(@"C:\Users\Public\Documents\Image.Jpeg");
                    MessageBox.Show("Image uploaded successfully");
                }
                else
                {
                    MessageBox.Show("Please take a picture");
                }
            }
            else
            {
                MessageBox.Show("Log in to your Facebook account");
            }
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            Graphics graphic = null;

            pictureBoxUserPaint.Refresh();
            pictureBoxUserPaint.Image = null;
            m_DrawArea = new Bitmap(pictureBoxUserPaint.Width, pictureBoxUserPaint.Height);
            graphic = Graphics.FromImage(m_DrawArea);
            graphic.Clear(Color.White);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBoxUserPaint.Width, pictureBoxUserPaint.Height);
            Graphics graphic = Graphics.FromImage(bmp);
            Rectangle rect = pictureBoxUserPaint.RectangleToScreen(pictureBoxUserPaint.ClientRectangle);
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            graphic.CopyFromScreen(rect.Location, Point.Empty, pictureBoxUserPaint.Size);
            graphic.Dispose();
            saveFileDialog.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    File.Delete(saveFileDialog.FileName);
                }

                if (saveFileDialog.FileName.Contains(".jpg"))
                {
                    bmp.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                }
                else
                {
                    if (saveFileDialog.FileName.Contains(".png"))
                    {
                        bmp.Save(saveFileDialog.FileName, ImageFormat.Png);
                    }
                    else
                    {
                        if (saveFileDialog.FileName.Contains(".bmp"))
                        {
                            bmp.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                        }
                    }
                }
            }
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBoxUserPaint.Image = Image.FromFile(openFileDialog.FileName).Clone() as Image;
            }
        }

        private void pictureBoxColors_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBoxColors.Width, pictureBoxColors.Height);
            Graphics graphic = Graphics.FromImage(bmp);
            Rectangle rect = pictureBoxColors.RectangleToScreen(pictureBoxColors.ClientRectangle);

            graphic.CopyFromScreen(rect.Location, Point.Empty, pictureBoxColors.Size);
            graphic.Dispose();
            m_Paintcolor = bmp.GetPixel(e.X, e.Y);
            pictureBoxChoosenColor.BackColor = m_Paintcolor;
            bmp.Dispose();
        }

        private void toolStripButtonDrawRectangle_Click(object sender, EventArgs e)
        {
            m_CurrentItem = eItem.Rectangle;
        }

        private void toolStripButtonEllipse_Click(object sender, EventArgs e)
        {
            m_CurrentItem = eItem.Ellipse;
        }

        private void toolStripButtonDrawLine_Click(object sender, EventArgs e)
        {
            m_CurrentItem = eItem.Line;
        }

        private void toolStripButtonEraser_Click(object sender, EventArgs e)
        {
            m_CurrentItem = eItem.Eraser;
        }

        private void toolStripButtonDrawPencil_Click(object sender, EventArgs e)
        {
            m_CurrentItem = eItem.Pencil;
        }

        private void pictureBoxUserPaint_MouseDown(object sender, MouseEventArgs e)
        {
            m_StartPositionX = e.X;
            m_StartPositionY = e.Y;
            m_IsDraw = m_CurrentItem == eItem.Eraser || m_CurrentItem == eItem.Pencil || m_CurrentItem == eItem.Rectangle;
        }

        private void pictureBoxUserPaint_MouseUp(object sender, MouseEventArgs e)
        {
            m_IsDraw = false;
            drawGraphicOnUserPaint(e.X, e.Y);
        }

        private void pictureBoxUserPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_IsDraw)
            {
                drawGraphicOnUserPaint(e.X, e.Y);
            }
        }

        private void buttonPostPic_Click(object sender, EventArgs e)
        {
            if (LoggedInUser != null)
            {
                if (pictureBoxUserPaint.Image != null)
                {
                    Bitmap bmp = new Bitmap(pictureBoxUserPaint.Width, pictureBoxUserPaint.Height);
                    Graphics graphic = Graphics.FromImage(bmp);
                    Rectangle rect = pictureBoxUserPaint.RectangleToScreen(pictureBoxUserPaint.ClientRectangle);

                    graphic.CopyFromScreen(rect.Location, Point.Empty, pictureBoxUserPaint.Size);
                    bmp.Save(@"C:\Users\Public\Documents\Image.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    formAlbumPictures.AlbumName.UploadPhoto(@"C:\Users\Public\Documents\Image.Jpeg", textBoxPictureDescription.Text);
                    File.Delete(@"C:\Users\Public\Documents\Image.Jpeg");
                    graphic.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Log in to your Facebook account");
            }
        }

        private void buttonOpenAlbum_Click(object sender, EventArgs e)
        {
            if (LoggedInUser != null)
            {
                formAlbumPictures = new FormAlbumPictures();
                formAlbumPictures.AlbumName = listBoxAlbumsNames.SelectedItem as Album;
                formAlbumPictures.UserLoggedIn = LoggedInUser;
                new Thread(formAlbumPictures.FetchPhotosFromAlbum).Start();
                formAlbumPictures.ShowDialog();
                if (formAlbumPictures.DialogResult == DialogResult.OK)
                {
                    m_DrawArea = formAlbumPictures.ChoosenPhoto.ImageNormal as Bitmap;
                    pictureBoxUserPaint.Image = m_DrawArea;
                }
                else
                {
                    MessageBox.Show("Please choose photo from one of your albums.");
                }
            }
            else
            {
                MessageBox.Show("Log in to your Facebook account");
            }
        }

        private void drawGraphicOnUserPaint(int i_X, int i_Y)
        {
            Graphics graphic = Graphics.FromImage(m_DrawArea);

            switch (m_CurrentItem)
            {
                case eItem.Rectangle:
                    graphic.FillRectangle(new SolidBrush(m_Paintcolor), m_StartPositionX, m_StartPositionY, i_X - m_StartPositionX, i_Y - m_StartPositionY);
                    break;
                case eItem.Pencil:
                    graphic.FillEllipse(new SolidBrush(m_Paintcolor), i_X, i_Y, 5, 5);
                    break;
                case eItem.Eraser:
                    graphic.FillEllipse(new SolidBrush(Color.White), i_X, i_Y, 5, 5);
                    break;
                case eItem.Line:
                    graphic.DrawLine(new Pen(new SolidBrush(m_Paintcolor)), new Point(m_StartPositionX, m_StartPositionY), new Point(i_X, i_Y));
                    break;
                case eItem.Ellipse:
                    graphic.FillEllipse(new SolidBrush(m_Paintcolor), m_StartPositionX, m_StartPositionY, i_X - m_StartPositionX, i_Y - m_StartPositionY);
                    break;
                case eItem.Smiley:
                    graphic.DrawImage(Properties.Resources.Smiley, m_StartPositionX, m_StartPositionY);
                    break;
            }

            pictureBoxUserPaint.Image = m_DrawArea;
            graphic.Dispose();  
        }

        private void toolStripButtonDrawSmiley_Click(object sender, EventArgs e)
        {
            m_CurrentItem = eItem.Smiley;
        }

        private void tabFacebookDesktopApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabFacebookDesktopApplication.SelectedIndex == 2 || tabFacebookDesktopApplication.SelectedIndex == 0)
            {
                if (m_IsTabFeature1Selected)
                {
                    pictureBoxUserPaint.Image.Save(@"C:\Users\Public\Documents\LastImage.Jpeg", ImageFormat.Jpeg);
                }
            }

            if (tabFacebookDesktopApplication.SelectedIndex == 1)
            {
                if (m_IsTabFeature1Selected)
                {
                    pictureBoxUserPaint.LoadAsync(@"C:\Users\Public\Documents\LastImage.Jpeg");
                }

                m_IsTabFeature1Selected = true;
            }
        }

        private void buttonPostAngryState_Click(object sender, EventArgs e)
        {
            m_EmotionManger = EmotionMangerFactory.Create(eEmotionManager.AngeryEmotion);
            PostEmotionalState();
        }

        private void buttonPostHappyState_Click(object sender, EventArgs e)
        {
            m_EmotionManger = EmotionMangerFactory.Create(eEmotionManager.HappyEmotion);
            PostEmotionalState();
        }

        private void buttonPostSadState_Click(object sender, EventArgs e)
        {
            m_EmotionManger = EmotionMangerFactory.Create(eEmotionManager.SadEmotion);
            PostEmotionalState();
        }

        private void PostEmotionalState()
        {
            if (LoggedInUser != null)
            {
                m_EmotionManger.LoggedIn = LoggedInUser;
                m_EmotionManger.VideoImage = (Bitmap)pictureBoxImageVideo.Image;
                m_EmotionManger.PostEmotionalState();
            }
        }
    }
}