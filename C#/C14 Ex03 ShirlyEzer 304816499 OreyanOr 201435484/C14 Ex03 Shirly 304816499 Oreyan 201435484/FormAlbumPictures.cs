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

namespace C14_Ex03_Shirly_304816499_Oreyan_201435484
{
    public class FormAlbumPictures : Form
    {
        private Label labelChoosePicture;
        private ListBox listBoxPictures;
        private PictureBox pictureBoxPictureFromAlbum;
        private Button buttonOK;
        private Button buttonCancel;
        private BindingSource photoBindingSource;
        private IContainer components;
        private GroupBox groupBoxPhotoDetails;
        private Label labelCurrentPhotoPlaceName;
        private BindingSource tagsBindingSource;
        private Label labelCurrentPhotoCreatedTime;
        private Label labelCurrentPhotoHeight;
        private Label labelCurrentPhotoName;
        private Label labelCurrentPhotoUpdateTime;
        private Label labelCurrentPhotoWidth;
        private DataGridView tagsDataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn User;
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label labelCreatedTime;
            System.Windows.Forms.Label labelHeight;
            System.Windows.Forms.Label labelPhotoName;
            System.Windows.Forms.Label labelUpdateTime;
            System.Windows.Forms.Label labelWidth;
            System.Windows.Forms.Label labelPlaceName;
            this.labelChoosePicture = new System.Windows.Forms.Label();
            this.listBoxPictures = new System.Windows.Forms.ListBox();
            this.photoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBoxPictureFromAlbum = new System.Windows.Forms.PictureBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxPhotoDetails = new System.Windows.Forms.GroupBox();
            this.tagsDataGridView = new System.Windows.Forms.DataGridView();
            this.tagsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelCurrentPhotoPlaceName = new System.Windows.Forms.Label();
            this.labelCurrentPhotoCreatedTime = new System.Windows.Forms.Label();
            this.labelCurrentPhotoHeight = new System.Windows.Forms.Label();
            this.labelCurrentPhotoName = new System.Windows.Forms.Label();
            this.labelCurrentPhotoUpdateTime = new System.Windows.Forms.Label();
            this.labelCurrentPhotoWidth = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            labelCreatedTime = new System.Windows.Forms.Label();
            labelHeight = new System.Windows.Forms.Label();
            labelPhotoName = new System.Windows.Forms.Label();
            labelUpdateTime = new System.Windows.Forms.Label();
            labelWidth = new System.Windows.Forms.Label();
            labelPlaceName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)this.photoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxPictureFromAlbum).BeginInit();
            this.groupBoxPhotoDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.tagsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.tagsBindingSource).BeginInit();
            this.SuspendLayout();
            //// labelCreatedTime
            labelCreatedTime.AutoSize = true;
            labelCreatedTime.Location = new System.Drawing.Point(19, 33);
            labelCreatedTime.Name = "labelCreatedTime";
            labelCreatedTime.Size = new System.Drawing.Size(97, 17);
            labelCreatedTime.TabIndex = 0;
            labelCreatedTime.Text = "Created Time:";
            //// labelHeight
            labelHeight.AutoSize = true;
            labelHeight.Location = new System.Drawing.Point(19, 102);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new System.Drawing.Size(53, 17);
            labelHeight.TabIndex = 2;
            labelHeight.Text = "Height:";
            //// labelPhotoName
            labelPhotoName.AutoSize = true;
            labelPhotoName.Location = new System.Drawing.Point(19, 79);
            labelPhotoName.Name = "labelPhotoName";
            labelPhotoName.Size = new System.Drawing.Size(88, 17);
            labelPhotoName.TabIndex = 4;
            labelPhotoName.Text = "Photo name:";
            //// labelUpdateTime
            labelUpdateTime.AutoSize = true;
            labelUpdateTime.Location = new System.Drawing.Point(19, 56);
            labelUpdateTime.Name = "labelUpdateTime";
            labelUpdateTime.Size = new System.Drawing.Size(93, 17);
            labelUpdateTime.TabIndex = 6;
            labelUpdateTime.Text = "Update Time:";
            //// labelWidth
            labelWidth.AutoSize = true;
            labelWidth.Location = new System.Drawing.Point(19, 125);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new System.Drawing.Size(48, 17);
            labelWidth.TabIndex = 8;
            labelWidth.Text = "Width:";
            //// labelPlaceName
            labelPlaceName.AutoSize = true;
            labelPlaceName.Location = new System.Drawing.Point(19, 149);
            labelPlaceName.Name = "labelPlaceName";
            labelPlaceName.Size = new System.Drawing.Size(86, 17);
            labelPlaceName.TabIndex = 12;
            labelPlaceName.Text = "Place name:";
            //// labelChoosePicture
            this.labelChoosePicture.AutoSize = true;
            this.labelChoosePicture.Location = new System.Drawing.Point(32, 26);
            this.labelChoosePicture.Name = "labelChoosePicture";
            this.labelChoosePicture.Size = new System.Drawing.Size(108, 17);
            this.labelChoosePicture.TabIndex = 0;
            this.labelChoosePicture.Text = "Choose Picture:";
            //// listBoxPictures
            this.listBoxPictures.DisplayMember = "Name";
            this.listBoxPictures.FormattingEnabled = true;
            this.listBoxPictures.ItemHeight = 16;
            this.listBoxPictures.Location = new System.Drawing.Point(35, 52);
            this.listBoxPictures.Name = "listBoxPictures";
            this.listBoxPictures.Size = new System.Drawing.Size(296, 276);
            this.listBoxPictures.TabIndex = 1;
            this.listBoxPictures.SelectedIndexChanged += new System.EventHandler(this.listBoxPictures_SelectedIndexChanged);
            //// photoBindingSource
            this.photoBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Photo);
            //// pictureBoxPictureFromAlbum
            this.pictureBoxPictureFromAlbum.Location = new System.Drawing.Point(406, 57);
            this.pictureBoxPictureFromAlbum.Name = "pictureBoxPictureFromAlbum";
            this.pictureBoxPictureFromAlbum.Size = new System.Drawing.Size(436, 431);
            this.pictureBoxPictureFromAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPictureFromAlbum.TabIndex = 2;
            this.pictureBoxPictureFromAlbum.TabStop = false;
            //// buttonOK
            this.buttonOK.Location = new System.Drawing.Point(768, 653);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(74, 33);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            //// buttonCancel
            this.buttonCancel.Location = new System.Drawing.Point(674, 653);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(74, 33);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            //// groupBoxPhotoDetails
            this.groupBoxPhotoDetails.Controls.Add(this.tagsDataGridView);
            this.groupBoxPhotoDetails.Controls.Add(labelPlaceName);
            this.groupBoxPhotoDetails.Controls.Add(this.labelCurrentPhotoPlaceName);
            this.groupBoxPhotoDetails.Controls.Add(labelCreatedTime);
            this.groupBoxPhotoDetails.Controls.Add(this.labelCurrentPhotoCreatedTime);
            this.groupBoxPhotoDetails.Controls.Add(labelHeight);
            this.groupBoxPhotoDetails.Controls.Add(this.labelCurrentPhotoHeight);
            this.groupBoxPhotoDetails.Controls.Add(labelPhotoName);
            this.groupBoxPhotoDetails.Controls.Add(this.labelCurrentPhotoName);
            this.groupBoxPhotoDetails.Controls.Add(labelUpdateTime);
            this.groupBoxPhotoDetails.Controls.Add(this.labelCurrentPhotoUpdateTime);
            this.groupBoxPhotoDetails.Controls.Add(labelWidth);
            this.groupBoxPhotoDetails.Controls.Add(this.labelCurrentPhotoWidth);
            this.groupBoxPhotoDetails.Location = new System.Drawing.Point(35, 343);
            this.groupBoxPhotoDetails.Name = "groupBoxPhotoDetails";
            this.groupBoxPhotoDetails.Size = new System.Drawing.Size(340, 343);
            this.groupBoxPhotoDetails.TabIndex = 5;
            this.groupBoxPhotoDetails.TabStop = false;
            this.groupBoxPhotoDetails.Text = "Photo detailes:";
            //// tagsDataGridView
            this.tagsDataGridView.AutoGenerateColumns = false;
            this.tagsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tagsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] 
            {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.User 
            });
            this.tagsDataGridView.DataSource = this.tagsBindingSource;
            this.tagsDataGridView.Location = new System.Drawing.Point(22, 175);
            this.tagsDataGridView.Name = "tagsDataGridView";
            this.tagsDataGridView.RowTemplate.Height = 24;
            this.tagsDataGridView.Size = new System.Drawing.Size(300, 150);
            this.tagsDataGridView.TabIndex = 13;
            //// tagsBindingSource
            this.tagsBindingSource.DataMember = "Tags";
            this.tagsBindingSource.DataSource = this.photoBindingSource;
            //// labelCurrentPhotoPlaceName
            this.labelCurrentPhotoPlaceName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.photoBindingSource, "Place.Name", true));
            this.labelCurrentPhotoPlaceName.Location = new System.Drawing.Point(122, 149);
            this.labelCurrentPhotoPlaceName.Name = "labelCurrentPhotoPlaceName";
            this.labelCurrentPhotoPlaceName.Size = new System.Drawing.Size(100, 23);
            this.labelCurrentPhotoPlaceName.TabIndex = 13;
            this.labelCurrentPhotoPlaceName.Text = "-";
            //// labelCurrentPhotoCreatedTime
            this.labelCurrentPhotoCreatedTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.photoBindingSource, "CreatedTime", true));
            this.labelCurrentPhotoCreatedTime.Location = new System.Drawing.Point(122, 33);
            this.labelCurrentPhotoCreatedTime.Name = "labelCurrentPhotoCreatedTime";
            this.labelCurrentPhotoCreatedTime.Size = new System.Drawing.Size(100, 23);
            this.labelCurrentPhotoCreatedTime.TabIndex = 1;
            this.labelCurrentPhotoCreatedTime.Text = "-";
            //// labelCurrentPhotoHeight
            this.labelCurrentPhotoHeight.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.photoBindingSource, "Height", true));
            this.labelCurrentPhotoHeight.Location = new System.Drawing.Point(122, 102);
            this.labelCurrentPhotoHeight.Name = "labelCurrentPhotoHeight";
            this.labelCurrentPhotoHeight.Size = new System.Drawing.Size(100, 23);
            this.labelCurrentPhotoHeight.TabIndex = 3;
            this.labelCurrentPhotoHeight.Text = "-";
            //// labelCurrentPhotoName
            this.labelCurrentPhotoName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.photoBindingSource, "Name", true));
            this.labelCurrentPhotoName.Location = new System.Drawing.Point(122, 79);
            this.labelCurrentPhotoName.Name = "labelCurrentPhotoName";
            this.labelCurrentPhotoName.Size = new System.Drawing.Size(100, 23);
            this.labelCurrentPhotoName.TabIndex = 5;
            this.labelCurrentPhotoName.Text = "-";
            //// labelCurrentPhotoUpdateTime
            this.labelCurrentPhotoUpdateTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.photoBindingSource, "UpdateTime", true));
            this.labelCurrentPhotoUpdateTime.Location = new System.Drawing.Point(122, 56);
            this.labelCurrentPhotoUpdateTime.Name = "labelCurrentPhotoUpdateTime";
            this.labelCurrentPhotoUpdateTime.Size = new System.Drawing.Size(100, 23);
            this.labelCurrentPhotoUpdateTime.TabIndex = 7;
            this.labelCurrentPhotoUpdateTime.Text = "-";
            //// labelCurrentPhotoWidth
            this.labelCurrentPhotoWidth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.photoBindingSource, "Width", true));
            this.labelCurrentPhotoWidth.Location = new System.Drawing.Point(122, 125);
            this.labelCurrentPhotoWidth.Name = "labelCurrentPhotoWidth";
            this.labelCurrentPhotoWidth.Size = new System.Drawing.Size(100, 23);
            this.labelCurrentPhotoWidth.TabIndex = 9;
            this.labelCurrentPhotoWidth.Text = "-";
            //// dataGridViewTextBoxColumn1
            this.dataGridViewTextBoxColumn1.DataPropertyName = "XCoord";
            this.dataGridViewTextBoxColumn1.HeaderText = "XCoord";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            //// dataGridViewTextBoxColumn2
            this.dataGridViewTextBoxColumn2.DataPropertyName = "YCoord";
            this.dataGridViewTextBoxColumn2.HeaderText = "YCoord";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            //// User
            this.User.DataPropertyName = "User";
            this.User.HeaderText = "User";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            //// FormAlbumPictures
            this.ClientSize = new System.Drawing.Size(853, 696);
            this.Controls.Add(this.groupBoxPhotoDetails);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.pictureBoxPictureFromAlbum);
            this.Controls.Add(this.listBoxPictures);
            this.Controls.Add(this.labelChoosePicture);
            this.Name = "FormAlbumPictures";
            ((System.ComponentModel.ISupportInitialize)this.photoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxPictureFromAlbum).EndInit();
            this.groupBoxPhotoDetails.ResumeLayout(false);
            this.groupBoxPhotoDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.tagsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.tagsBindingSource).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public void FetchPhotosFromAlbum()
        {
            var allPhotosFromAlbum = AlbumName.Photos;

            listBoxPictures.Invoke(new Action(() =>
            {
                listBoxPictures.DisplayMember = "UpdateTime";
                foreach (Photo photo in AlbumName.Photos)
                {
                    listBoxPictures.Items.Add(photo);
                }

                this.listBoxPictures.DataSource = this.photoBindingSource;
                photoBindingSource.DataSource = allPhotosFromAlbum;
            }));
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
