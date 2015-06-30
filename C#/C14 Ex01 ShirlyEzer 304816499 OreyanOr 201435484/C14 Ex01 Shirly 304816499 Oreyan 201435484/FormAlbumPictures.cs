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
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace C14_Ex01_Shirly_304816499_Oreyan_201435484
{
    public class FormAlbumPictures : Form
    {
        private Label labelChoosePicture;
        private ListBox listBoxPictures;
        private PictureBox pictureBoxPictureFromAlbum;
        private Button buttonOK;
        private Button buttonCancel;
        private Photo m_ChoosenPhoto = null;

        public Photo ChoosenPhoto
        {
            get { return m_ChoosenPhoto; }
        }

        public User UserLoggedIn { get; set; }
        
        public Album AlbumName { get; set; }

        public FormAlbumPictures()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.labelChoosePicture = new System.Windows.Forms.Label();
            this.listBoxPictures = new System.Windows.Forms.ListBox();
            this.pictureBoxPictureFromAlbum = new System.Windows.Forms.PictureBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxPictureFromAlbum).BeginInit();
            this.SuspendLayout(); 
            //// labelChoosePicture
            this.labelChoosePicture.AutoSize = true;
            this.labelChoosePicture.Location = new System.Drawing.Point(32, 26);
            this.labelChoosePicture.Name = "labelChoosePicture";
            this.labelChoosePicture.Size = new System.Drawing.Size(108, 17);
            this.labelChoosePicture.TabIndex = 0;
            this.labelChoosePicture.Text = "Choose Picture:";
            //// listBoxPictures
            this.listBoxPictures.FormattingEnabled = true;
            this.listBoxPictures.ItemHeight = 16;
            this.listBoxPictures.Location = new System.Drawing.Point(35, 52);
            this.listBoxPictures.Name = "listBoxPictures";
            this.listBoxPictures.Size = new System.Drawing.Size(296, 436);
            this.listBoxPictures.TabIndex = 1;
            this.listBoxPictures.SelectedIndexChanged += new System.EventHandler(this.listBoxPictures_SelectedIndexChanged);
            //// pictureBoxPictureFromAlbum
            this.pictureBoxPictureFromAlbum.Location = new System.Drawing.Point(406, 57);
            this.pictureBoxPictureFromAlbum.Name = "pictureBoxPictureFromAlbum";
            this.pictureBoxPictureFromAlbum.Size = new System.Drawing.Size(436, 431);
            this.pictureBoxPictureFromAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPictureFromAlbum.TabIndex = 2;
            this.pictureBoxPictureFromAlbum.TabStop = false;
            //// buttonOK
            this.buttonOK.Location = new System.Drawing.Point(768, 508);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(74, 33);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            //// buttonCancel
            this.buttonCancel.Location = new System.Drawing.Point(688, 508);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(74, 33);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            //// FormAlbumPictures
            this.ClientSize = new System.Drawing.Size(875, 565);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.pictureBoxPictureFromAlbum);
            this.Controls.Add(this.listBoxPictures);
            this.Controls.Add(this.labelChoosePicture);
            this.Name = "FormAlbumPictures";
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxPictureFromAlbum).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public void fetchPhotosFromAlbum()
        {
            listBoxPictures.DisplayMember = "UpdateTime";
            foreach (Photo photo in AlbumName.Photos)
            {
                listBoxPictures.Items.Add(photo);
            }
        }

        private void listBoxPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedPhoto();
        }

        private void displaySelectedPhoto()
        {
            Photo selectedPhoto = null;

            if (listBoxPictures.SelectedItems.Count == 1)
            {
                selectedPhoto = listBoxPictures.SelectedItem as Photo;
                if (selectedPhoto.PictureNormalURL != null)
                {
                    pictureBoxPictureFromAlbum.LoadAsync(selectedPhoto.PictureNormalURL);
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (listBoxPictures.SelectedItem != null)
            {
                m_ChoosenPhoto = listBoxPictures.SelectedItem as Photo;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
