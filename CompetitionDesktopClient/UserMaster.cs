using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using UserDomain.ControlModule;
using UserDomain.ControlModule.Interfaces;
using UserDomain.model;
using UserDomain.Model;
using UserDomain.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace CompetitionDesktopClient
{
    public partial class UserMaster : Form
    {
        IUserManager userMaster = new UserManager();
        PrimeUser? currentUser;
        List<UserImage> userImages = new List<UserImage>();

        public UserMaster()
        {
            InitializeComponent();
            ButtonStatus(false);
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bLookup_Click(object sender, EventArgs e)
        {
            string codeToCheck = tbCode.Text.Trim();

            Button caller = (Button)sender;
            string? callType = (caller.Tag == null) ? String.Empty : caller.Tag as string;

            currentUser = null;

            switch (callType)
            {
                case "code":
                    currentUser = userMaster.GetUserFromCode(codeToCheck).Result;
                    break;
                case "tag":
                    currentUser = userMaster.GetUserFromTag(codeToCheck).Result;
                    break;
            }


            if (currentUser != null) PopulateUserFields(currentUser);
            else
            {
                ClearAllContent(true);
                MessageBox.Show("User not found", "Load Error", MessageBoxButtons.OK);
            }
        }



        private void PopulateUserFields(PrimeUser currUser)
        {
            ClearAllContent(true);
            tbId.Text = currUser.Id.ToString();
            tbName.Text = currUser.Name;
            tbCode.Text = currUser.Code;
            tbTag.Text = currUser.Tag;
            if (!string.IsNullOrEmpty(currUser.ThumbnailUrl))
            {
                pbThumbnail.ImageLocation = currUser.ThumbnailUrl;
            }

            // try to load images
            LoadCurrentUserImages();
        }

        private void BuildCurrentUser()
        {
            currentUser = new PrimeUser();
            currentUser.Name = tbName.Text;
            currentUser.Code = tbCode.Text;
            currentUser.Tag = tbTag.Text;
            currentUser.Status = USER_STATUS.ACTIVE;
            Guid newId = Guid.NewGuid();
            currentUser.Id = newId;
            tbId.Text = newId.ToString();
            pbThumbnail.ImageLocation = "";
            userImages = new List<UserImage>();// clear
            pbImage.ImageLocation = "";

        }

        private void LoadCurrentUserImages()
        {
            Task<List<UserImage>> userImagesFound = userMaster.GetUserImages(currentUser.Id);

            if (userImagesFound?.Result != null && userImagesFound?.Result.Count > 0) userImages = userImagesFound.Result;
            else return;

            if (ddlImageType.SelectedItem == null) ddlImageType.SelectedIndex = 1;

            UserImage? usrImage = null;

            switch (ddlImageType.SelectedIndex)
            {
                case 0:
                    usrImage = null;// clear image
                    break;
                case 1:
                    usrImage = userImages.FirstOrDefault(x => x.ImageType == UserDomain.Properties.IMAGE_TYPE.MAIN);
                    break;
                case 2:
                    usrImage = userImages.FirstOrDefault(x => x.ImageType == UserDomain.Properties.IMAGE_TYPE.HORIZONTAL);
                    break;
                case 3:
                    usrImage = userImages.FirstOrDefault(x => x.ImageType == UserDomain.Properties.IMAGE_TYPE.VERTICAL);
                    break;
            }

            if (usrImage != null)
            {
                pbImage.ImageLocation = usrImage.ImageUrl;
                bSaveImage.Enabled = true;
                bDeleteImage.Enabled = true;
            }
            else
            {
                bSaveImage.Enabled = false;
                bDeleteImage.Enabled = false;
            }

        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ClearAllContent(false);
        }

        private void ClearAllContent(bool enableButtons)
        {
            tbId.Clear();
            tbName.Clear();
            tbCode.Clear();
            tbTag.Clear();
            pbThumbnail.ImageLocation = null;
            pbImage.ImageLocation = null;


            ButtonStatus(enableButtons);


        }

        private void ButtonStatus(bool enable)
        {
            bSave.Enabled = enable;
            bClear.Enabled = enable;
            bSaveImage.Enabled = enable;
            bDeleteImage.Enabled = enable;
            bGetImage.Enabled = enable;
            bDelete.Enabled = enable;
            bArchive.Enabled = enable;

            bLookup.Enabled = true;// always available
        }

        private void ValidateButtonsStatus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCode.Text) == false
                && string.IsNullOrEmpty(tbTag.Text) == false
                && string.IsNullOrEmpty(tbName.Text) == false)
            {
                bSave.Enabled = true;
                bClear.Enabled = true;
            }
            else
            {
                bSave.Enabled = false;
                bClear.Enabled = false;
            }
        }



        private void ButtonEnabledChanged(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;

            // tag for button control
            switch (currentButton.Tag)
            {
                case "Save":
                    bSave.ForeColor = currentButton.Enabled == false ? Color.IndianRed : Color.Black;
                    bSave.BackColor = currentButton.Enabled == false ? Color.DarkGray : Color.LightSteelBlue;
                    break;
                case "Clear":
                    bClear.ForeColor = currentButton.Enabled == false ? Color.IndianRed : Color.Black;
                    bClear.BackColor = currentButton.Enabled == false ? Color.DarkGray : Color.LightSteelBlue;
                    break;
                case "Lookup":
                    bLookup.ForeColor = currentButton.Enabled == false ? Color.IndianRed : Color.Black;
                    bLookup.BackColor = currentButton.Enabled == false ? Color.DarkGray : Color.LightSteelBlue;
                    break;
                case "Delete":
                    bDelete.ForeColor = currentButton.Enabled == false ? Color.IndianRed : Color.Black;
                    bDelete.BackColor = currentButton.Enabled == false ? Color.DarkGray : Color.LightSteelBlue;
                    break;
                case "Archive":
                    bArchive.ForeColor = currentButton.Enabled == false ? Color.IndianRed : Color.Black;
                    bArchive.BackColor = currentButton.Enabled == false ? Color.DarkGray : Color.LightSteelBlue;
                    break;
            }

        }

        private void ButtonPaints(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            var solidBrush = new SolidBrush(btn.ForeColor);
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            switch (btn.Tag)
            {
                case "Save":
                    e.Graphics.DrawString("Save", btn.Font, solidBrush, e.ClipRectangle, stringFormat);
                    break;
                case "Clear":
                    e.Graphics.DrawString("Clear", btn.Font, solidBrush, e.ClipRectangle, stringFormat);
                    break;
                case "Lookup":
                    e.Graphics.DrawString("Lookup All", btn.Font, solidBrush, e.ClipRectangle, stringFormat);
                    break;
                case "Delete":
                    e.Graphics.DrawString("Delete", btn.Font, solidBrush, e.ClipRectangle, stringFormat);
                    break;
                case "Archive":
                    e.Graphics.DrawString("Archive", btn.Font, solidBrush, e.ClipRectangle, stringFormat);
                    break;
            }

            solidBrush.Dispose();
            stringFormat.Dispose();
        }



        private void bGetImage_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new();
            dlg.Title = "Open Image";
            dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = dlg.FileName;
                bSaveImage.Enabled = true;
                bDeleteImage.Enabled = true;
            }
            else
            {
                bSaveImage.Enabled = false;
                bDeleteImage.Enabled = false;
            }

        }

        private void bSaveImage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pbImage.ImageLocation))
            {
                int indx = ddlImageType.SelectedIndex;
                IMAGE_TYPE choice = IMAGE_TYPE.MAIN;

                if (indx >= 0)
                {
                    choice = (IMAGE_TYPE)ddlImageType.SelectedIndex;
                }

                UserImage newUserImage = new()
                {
                    Id = currentUser.Id,
                    Name = currentUser.Name,
                    ImageUrl = pbImage.ImageLocation,
                    ImageType = choice,
                };

                userMaster.SaveUserImage(newUserImage);
            }



        }

        private void bDeleteImage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pbImage.ImageLocation))
            {
                UserImage existingUserImage = new()
                {
                    Id = currentUser.Id,
                    Name = currentUser.Name,
                    ImageUrl = pbImage.ImageLocation,
                    ImageType = (IMAGE_TYPE)ddlImageType.SelectedIndex,
                };

                userMaster.DeleteUserImage(existingUserImage);
            }
        }

        private void moveCurrentUser(object sender, EventArgs e)
        {
            Button caller = (Button)sender;
            string? callType = (caller.Tag == null) ? String.Empty : caller.Tag as string;

            // load user collection
            Task<PrimeUserCollection> allUsersTask = userMaster.GetAllActiveUsers();

            if (allUsersTask?.Result != null)
            {
                PrimeUserCollection allUsers = allUsersTask.Result;

                switch (callType)
                {
                    case "first":
                        currentUser = allUsers.OrderBy(x => x.Code).First();

                        break;
                    case "last":
                        currentUser = allUsers.OrderBy(x => x.Code).Last();
                        break;
                    case "previous":
                        List<PrimeUser> orderedUsersDesc = allUsers.OrderBy(x => x.Code).ToList();
                        for (int i = orderedUsersDesc.Count - 1; i > 0; i--)
                        {
                            if (orderedUsersDesc[i].Code == currentUser.Code)
                            {
                                if (i >= 1) currentUser = orderedUsersDesc[i - 1];
                                break;
                            }
                        }
                        break;
                    case "next":
                        List<PrimeUser> orderedUsersAsc = allUsers.OrderBy(x => x.Code).ToList();
                        for (int i = 0; i < orderedUsersAsc.Count; i++)
                        {
                            if (orderedUsersAsc[i].Code == currentUser.Code && orderedUsersAsc.Count > i + 1)
                            {
                                currentUser = orderedUsersAsc[i + 1];
                                break;
                            }
                        }
                        break;
                }

                if (currentUser != null)
                {
                    PopulateUserFields(currentUser);

                    if (currentUser != null) PopulateUserFields(currentUser);
                    else
                    {
                        ClearAllContent(true);
                        MessageBox.Show("User not found", "Load Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Error building User", "Load Error", MessageBoxButtons.OK);
                }
            }


        }

        private void bSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WAGOO");
            // create a new user
            BuildCurrentUser();
            if (currentUser != null)
            {
                Task<string> res = userMaster.CreateUser(currentUser);

                if (res.Result == String.Empty)
                {
                    currentUser = userMaster.GetUserFromCode(currentUser.Code).Result;

                    if (currentUser != null) PopulateUserFields(currentUser);
                    else
                    {
                        ClearAllContent(true);
                        MessageBox.Show("User not found", "Load Error", MessageBoxButtons.OK);
                    }

                }
            }

        }

        private void bLookup_Click_1(object sender, EventArgs e)
        {
            UserLookup userLookup = new UserLookup();
            DialogResult response = userLookup.ShowDialog(this);

            
            switch (response)
            {
                
                case DialogResult.OK:
                    currentUser = userLookup.selectedUser;
                    PopulateUserFields(currentUser);
                    break;

                case DialogResult.Cancel:
                default:

                    break;
            }
        }
    }
}
