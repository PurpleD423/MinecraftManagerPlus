using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MinecraftManagerPlus.Properties;
using MinecraftManagerPlus.Utility;
using DataModel = MinecraftManagerPlus.App_Data.DataModelContainer;

namespace MinecraftManagerPlus
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private readonly App_Data.User _editUser;
        private readonly FormMinecraft _mainForm = null;

        public bool SaveCompleted;

        public UserForm(FormMinecraft callingForm, App_Data.User aUser = null)
        {
            _mainForm = callingForm as FormMinecraft;
            InitializeComponent();

            this.lv_Avatar.LargeImageList = UserImages;

            for (int i = 0; i < UserImages.Images.Count; i++)
            {
                var image = UserImages.Images[i] as Bitmap;
                var name = UserImages.Images.Keys[i];

                name = Regex.Replace(name, "(.*?)\\.(.*)", "$1");
                if (image != null)
                    this.lv_Avatar.Items.Add(new ListViewItem(name, i));
            }

            if (aUser != null)
            {
                _editUser = aUser;
                _editUser.Setting = aUser.Setting;
                Username = _editUser.Username;
                Avatar = _editUser.ImageIndex;
            }
        }

        public ImageList UserImages
        {
            get { return _mainForm.UserImages; }
        }

        public String Username
        {
            get { return txt_Username.Text; }
            set { txt_Username.Text = value; }
        }

        public int Avatar
        {
            get
            {
                if (lv_Avatar.SelectedItems.Count == 1)
                    return lv_Avatar.SelectedItems[0].Index;
                return -1;
            } 
            set
            {
                if (lv_Avatar.Items[value] != null)
                {
                    lv_Avatar.Items[value].Selected = true;
                }
            }
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Username))
            {
                MessageBox.Show(Resources.UserForm_BtnSaveClick_You_must_choose_a_Username_);
                return;
            }
            if (Avatar == -1)
            {
                MessageBox.Show(Resources.UserForm_BtnSaveClick_You_must_choose_an_Avatar_);
                return;
            }

            if (_editUser != null)
            {
                _editUser.Username = Username;
                _editUser.ImageIndex = Avatar;
                _mainForm.SaveSettings(false, _editUser);
            }
            else
            {
                using (var model = new DataModel())
                {
                    var newUser = new App_Data.User();
                    newUser.LoadDefaults();
                    newUser.Username = Username;
                    newUser.ImageIndex = Avatar;
                    model.Users.AddObject(newUser);
                    model.SaveChanges();
                    SaveCompleted = true;
                }
            }
            if (!SaveCompleted) return;
            _mainForm.LoadUserList();
            _mainForm.LoadUser(Username);
            _mainForm.LoadUserSettings();
            Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void LvAvatarLeave(object sender, EventArgs e)
        {
            if (_editUser == null) return;
            foreach (ListViewItem item in lv_Avatar.Items)
            {
                if (item.Index == _editUser.ImageIndex)
                {
                    item.EnsureVisible();
                    item.BackColor = Color.LightGray;
                }
                else
                {
                    item.BackColor = Color.White;
                }
            }
        }

        private void LvAvatarMouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Do something here.
        }

        private void LvAvatarSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_editUser == null) return;
            if (((ListView)sender).SelectedItems.Count == 1)
            {
                var item = ((ListView)sender).SelectedItems[0];
                if (item == null) return;
                 _editUser.ImageIndex = item.Index;
                LvAvatarLeave(new object(), new EventArgs());
            }
        }
    }
}
