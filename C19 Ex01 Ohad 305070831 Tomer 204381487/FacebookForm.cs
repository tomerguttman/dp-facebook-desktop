using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using FacebookWrapper.ObjectModel;


namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public partial class FacebookForm : Form
    {
        private const int k_BestFriendsLimit = 10;
        private FacebookFacade m_Facade = null;
        //private User m_LoggedInUser;
       // private Settings m_UserSettings;
       // private LoginResult m_LoginResult;

        public FacebookForm()
        {
            try
            {
                //m_UserSettings = Settings.LoadSettingsFromFile();
                m_Facade = new FacebookFacade();
                InitializeComponent();
                this.RememberMeCheckbox.Checked = m_Facade.IsRememberMeChecked();
            }
            catch
            {
                MessageBox.Show("There was a problem initializing the application.", "Initializing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FacebookLoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                //LoginToFacebook returns whether or not the login was successful.
                if (m_Facade.LoginToFacebook())
                {
                    updateFormData();
                    this.FacebookLoginButton.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("There was a problem connecting to Facebook", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateFormData()
        {
            int userAge = 0;
            string loggedInUserBirthday = m_Facade.GetBirthday();

            if (loggedInUserBirthday != null && loggedInUserBirthday.Length == 10)
            {
                if (int.TryParse(loggedInUserBirthday.Remove(0, 6), out userAge))
                {
                    userAge = DateTime.Today.Year - userAge;
                    FriendAgeLabelCompareTab.Text = string.Format("{0}", userAge);
                }
            }
            else
            {
                FriendAgeLabelCompareTab.Text = "Unknown";
            }

            this.ProfilePictureBox.Image = this.UserPictureBoxCompareTab.Image = m_Facade.GetProfileImage();
            this.Text = this.UserNameLabelCompareTab.Text = m_Facade.GetName();
            this.UserAgeLabelCompareTab.Text = string.Format("{0}", userAge);
            this.UserBDAYLabelCompareTab.Text = loggedInUserBirthday;

            // this.UserHomeTownLabelCompareTab.Text = m_LoggedInUser.Hometown.Name;  Throwing an exception - data cannot be retrieved.
            this.CoverPhotoPictureBox.BackgroundImage = m_Facade.GetCoverImage();
            addFriendsToListBox();
            //addPostsToListBox();

            postBindingSource.DataSource = m_Facade.GetPosts();///////////////////////////////
        }

        //private void addPostsToListBox()
        //{
        //    foreach (Post post in m_LoggedInUser.Posts)
        //    {
        //        PostsListBox.Items.Add(string.Format("{0} {1}", post.Message, post.CreatedTime.Value.ToShortDateString()));
        //    }
        //}

        private void addFriendsToListBox()
        {
            foreach (User friend in m_Facade.GetFriends())
            {
                FriendsListBox.Items.Add(friend.Name);
                FriendsListBoxCompareTab.Items.Add(friend.Name);
            }
        }

        private void MonthCalander_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateChoseListBox.Items.Clear();
            DateTime currentDate = e.Start;
            string shortCurrentDate = currentDate.ToShortDateString().Remove(0, 5);
            string loggedInUserBirthday = null;
            FacebookObjectCollection<Event> loggedInUserEvents = null;
            FacebookObjectCollection<User> loggedInUserFriends = null;

            if (m_Facade.IsLoggedIn)
            {
                try
                {
                    loggedInUserBirthday = m_Facade.GetBirthday();
                    loggedInUserEvents = m_Facade.GetEvents();
                    loggedInUserFriends = m_Facade.GetFriends();

                    if (shortCurrentDate == loggedInUserBirthday.Remove(0, 5))
                    {
                        DateChoseListBox.Items.Add("Happy Birthday to YOU!!");
                    }

                    updateListBoxes(shortCurrentDate, loggedInUserEvents, loggedInUserFriends);

                    if (DateChoseListBox.Items.Count == 0)
                    {
                        DateChoseListBox.Items.Add(string.Format("There are no events on {0}", currentDate.ToShortDateString()));
                    }
                }
                catch
                {
                    MessageBox.Show("The information couldn't be retrieved!", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please login first.", "Login Violation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateListBoxes(string i_ShortCurrentDate, FacebookObjectCollection<Event> i_UserEvents, FacebookObjectCollection<User> i_UserFriends)
        {
            foreach (Event currentEvent in i_UserEvents)
            {
                if (currentEvent.StartTime.Value.ToShortDateString().Remove(0, 5) == i_ShortCurrentDate)
                {
                    this.DateChoseListBox.Items.Add(currentEvent.Name);
                }
            }

            foreach (User friend in i_UserFriends)
            {
                if (friend.Birthday.Remove(0, 5) == i_ShortCurrentDate)
                {
                    this.DateChoseListBox.Items.Add(friend.Name + "'s Birthday");
                }
            }
        }

        private void PostsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchCommentsFromSelectedPost(sender);
        }

        private void fetchCommentsFromSelectedPost(object i_Sender)
        {
            List<Post> userPostList = m_Facade.GetPosts().ToList<Post>();
            int postIndex = 0;
            postIndex = getIndexOfPostInPostsList((i_Sender as ListBox).SelectedItem as string);
            Post currentPost = userPostList[postIndex];
            Form commentsForm = new Form();
            ListBox postCommentsListBox = new ListBox();
            postCommentsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Right |
                AnchorStyles.Bottom | AnchorStyles.Left;
            commentsForm.ShowInTaskbar = false;
            postCommentsListBox.Height = 450;
            postCommentsListBox.Width = 250;
            commentsForm.Height = 460;
            commentsForm.Width = 260;
            commentsForm.MinimumSize = new Size(260, 200);
            commentsForm.Text = "Comments";
            commentsForm.StartPosition = FormStartPosition.CenterScreen;

            foreach (Comment comment in currentPost.Comments)
            {
                postCommentsListBox.Items.Add(comment.Message);
            }

            if (postCommentsListBox.Items.Count == 0)
            {
                postCommentsListBox.Items.Add("There are no comments on this post.");
            }

            commentsForm.Controls.Add(postCommentsListBox);
            commentsForm.ShowDialog();
        }

        private int getIndexOfPostInPostsList(string i_StringPost)
        {
            int o_OutputIndex = 0;
            string temporaryString = null;
            FacebookObjectCollection<Post> loggedInUserPosts = m_Facade.GetPosts();

            try
            {
                foreach (Post currentPost in loggedInUserPosts)
                {
                    temporaryString = currentPost.Message + " " + currentPost.CreatedTime.Value.ToShortDateString();

                    if (temporaryString.Contains(i_StringPost))
                    {
                        break;
                    }

                    o_OutputIndex += 1;
                }
            }
            catch
            {
                MessageBox.Show("The information couldn't be retrieved!", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return o_OutputIndex;
        }

        private int getIndexOfUserInFriendList(string i_StringUserName)
        {
            int o_OutputIndex = 0;
            FacebookObjectCollection<User> loggedInUserFriends = m_Facade.GetFriends();

            try
            {
                foreach (User currentFriend in loggedInUserFriends)
                {
                    if (currentFriend.Name.Equals(i_StringUserName))
                    {
                        break;
                    }

                    o_OutputIndex += 1;
                }
            }
            catch
            {
                MessageBox.Show("The information couldn't be retrieved!", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return o_OutputIndex;
        }

        private void FriendsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            friendsListBox_SelectedIndexChangedGeneralMethod(sender, e, "General Data Tab");
        }

        private void friendsListBox_SelectedIndexChangedGeneralMethod(object sender, EventArgs e, string i_StringNameOfTabToUpdate)
        {
            List<User> friendsList = null;
            int postIndex = 0;
            User currentFriend = null;

            try
            {
                friendsList = m_Facade.GetFriends().ToList<User>();
                postIndex = getIndexOfUserInFriendList((sender as ListBox).SelectedItem as string);
                currentFriend = friendsList[postIndex];

                if (i_StringNameOfTabToUpdate.Equals("General Data Tab"))
                {
                    pickedFriendPictureBox.Image = currentFriend.ImageLarge;
                }
                else
                {
                    updateCompareTabDetails(currentFriend);
                    this.ExportToFileCompareTabButton.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("There was a problem retrieving the data", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateCompareTabDetails(User i_CurrentFriend)
        {
            int friendAge = 0;
            if (i_CurrentFriend.Birthday != null && i_CurrentFriend.Birthday.Length == 10 )
            {
                if (int.TryParse(i_CurrentFriend.Birthday.Remove(0, 6), out friendAge))
                {
                    friendAge = DateTime.Today.Year - friendAge;
                    FriendAgeLabelCompareTab.Text = string.Format("{0}", friendAge);
                }
            }
            else
            {
                FriendAgeLabelCompareTab.Text = "Unknown";
            }

            FriendPictureBoxCompareTab.Image = i_CurrentFriend.ImageLarge;
            FriendNameLabelCompareTab.Text = i_CurrentFriend.Name;
            FriendBDAYLabelCompareTab.Text = i_CurrentFriend.Birthday;

            // FriendHomeTownLabelCompareTab.Text = i_CurrentFriend.Hometown.Name; Throwing an exception - data cannot be retrieved.
        }

        protected override void OnShown(EventArgs e)
        {
            try
            {
                base.OnShown(e);

                if (m_Facade.IsLoggedIn)
                {
                    updateFormData();
                    this.FacebookLoginButton.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("There was a problem connecting to Facebook", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                closingSequnce();
            }
            catch
            {
                MessageBox.Show("There was a problem upon exit", "Exit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closingSequnce()
        {
            if (this.RememberMeCheckbox.Checked)
            {
                m_Facade.UpdateRemeberMeSettings();
                m_Facade.SaveSettingToFile();
            }
            else
            {
                m_Facade.deleteXmlFile();

                if (m_Facade.IsLoggedIn)
                {
                     m_Facade.Logout();
                }
            }
        }

        private void FetchBestFriendsPhotosButton_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(tenBestFriendsAlgorithm);
                thread.Start();
                this.FetchBestFriendsPhotosButton.Enabled = false;
            }
            catch
            {
                MessageBox.Show("There was a problem fetching your best friends", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tenBestFriendsAlgorithm()
        {
            updatePicturesInTenBestFriendsTab(TenBestFriendsAlgorithm.Instance.BestFriendsAlgorithm(m_Facade));
            this.BestFriendsInformationLabel.Font = new Font(BestFriendsInformationLabel.Font.FontFamily, 8f, FontStyle.Bold | FontStyle.Italic);
            this.BestFriendsInformationLabel.Text = "According to our calculations those are your ten best friends";
        }

        private void updatePicturesInTenBestFriendsTab(List<UserRating> i_UsersRatingSortedList)
        {
            PictureBox temporaryPictureBox = null;
            int index = 1;

            foreach (UserRating userRating in i_UsersRatingSortedList)
            {
                temporaryPictureBox = this.Controls.Find(string.Format("UserPictureBox{0}", index), true)[0] as PictureBox;
                temporaryPictureBox.Image = userRating.User.ImageNormal;
                index += 1;

                if (index > k_BestFriendsLimit)
                {
                    break;
                }
            }
        }

        private void FriendsListBoxCompareTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            friendsListBox_SelectedIndexChangedGeneralMethod(sender, e, "Compare Tab");
        }

        private void ExportToFileCompareTabButton_Click(object sender, EventArgs e)
        {
            exportToTextFile();
        }

        private void exportToTextFile()
        {
            string compareData = null;
            StreamWriter comparisonStreamWriter = null;

            compareData = string.Format(
@"-------Comparison with {1}------- 
{0} [Full Name] {1}
{2} [Age] {3}
{4} [Birthday] {5}
{6} [Hometown] {7}",
this.UserNameLabelCompareTab.Text,
this.FriendNameLabelCompareTab.Text,
this.UserAgeLabelCompareTab.Text,
this.FriendAgeLabelCompareTab.Text,
this.UserBDAYLabelCompareTab.Text,
this.FriendBDAYLabelCompareTab.Text,
this.UserHomeTownLabelCompareTab.Text,
this.FriendHomeTownLabelCompareTab.Text);

            try
            {
                comparisonStreamWriter = File.AppendText("Comparison To Friend.txt");
            }
            catch
            {
                MessageBox.Show("There was an error with the file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            using (comparisonStreamWriter)
            {
                comparisonStreamWriter.WriteLine(compareData);
                comparisonStreamWriter.Close();
            }
        }
    }
}
