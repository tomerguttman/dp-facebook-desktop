using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public partial class FacebookForm : Form
    {
        private const int k_BestFriendsLimit = 10;
        private readonly object r_TenBestFriendsAlgorithmContext = new object();
        private User m_LoggedInUser;
        private Settings m_UserSettings;
        private LoginResult m_LoginResult;

        public FacebookForm()
        {
            try
            {
                m_UserSettings = Settings.LoadSettingsFromFile();
                InitializeComponent();
                this.RememberMeCheckbox.Checked = m_UserSettings.IsRememberMeChecked;
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
                // Our appid:415704425731459
                m_LoginResult = FacebookService.Login(
                    "1450160541956417",
                    "public_profile",
                    "email",
                    "publish_to_groups",
                    "user_birthday",
                    "user_age_range",
                    "user_gender",
                    "user_link",
                    "user_tagged_places",
                    "user_videos",
                    "publish_to_groups",
                    "groups_access_member_info",
                    "user_friends",
                    "user_events",
                    "user_likes",
                    "user_location",
                    "user_photos",
                    "user_posts",
                    "user_hometown");

                if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
                {
                    m_LoggedInUser = m_LoginResult.LoggedInUser;
                    m_UserSettings.UserAccessToken = m_LoginResult.AccessToken;
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

            if (m_LoggedInUser.Birthday != null && m_LoggedInUser.Birthday.Length == 10)
            {
                if (int.TryParse(m_LoggedInUser.Birthday.Remove(0, 6), out userAge))
                {
                    userAge = DateTime.Today.Year - userAge;
                    FriendAgeLabelCompareTab.Text = string.Format("{0}", userAge);
                }
            }
            else
            {
                FriendAgeLabelCompareTab.Text = "Unknown";
            }

            this.ProfilePictureBox.Image = m_LoggedInUser.ImageNormal;
            this.UserPictureBoxCompareTab.Image = m_LoggedInUser.ImageNormal;
            this.UserNameLabelCompareTab.Text = m_LoggedInUser.Name;
            this.UserAgeLabelCompareTab.Text = string.Format("{0}", userAge);
            this.UserBDAYLabelCompareTab.Text = m_LoggedInUser.Birthday;

            // this.UserHomeTownLabelCompareTab.Text = m_LoggedInUser.Hometown.Name;  Throwing an exception - data cannot be retrieved.
            this.Text = m_LoggedInUser.Name;
            this.CoverPhotoPictureBox.BackgroundImage = m_LoggedInUser.Albums[0].Photos[0].ImageNormal;
            addFriendsToListBox();
            addPostsToListBox();
        }

        private void addPostsToListBox()
        {
            foreach (Post post in m_LoggedInUser.Posts)
            {
                PostsListBox.Items.Add(string.Format("{0} {1}", post.Message, post.CreatedTime.Value.ToShortDateString()));
            }
        }

        private void addFriendsToListBox()
        {
            foreach (User friend in m_LoggedInUser.Friends)
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

            if (m_LoggedInUser != null )
            {
                try
                {
                    if (shortCurrentDate == m_LoggedInUser.Birthday.Remove(0, 5))
                    {
                        DateChoseListBox.Items.Add("Happy Birthday to YOU!!");
                    }

                    foreach (Event currentEvent in m_LoggedInUser.Events)
                    {
                        if (currentEvent.StartTime.Value.ToShortDateString().Remove(0, 5) == shortCurrentDate)
                        {
                            this.DateChoseListBox.Items.Add(currentEvent.Name);
                        }
                    }

                    foreach (User friend in m_LoggedInUser.Friends)
                    {
                        if (friend.Birthday.Remove(0, 5) == shortCurrentDate)
                        {
                            this.DateChoseListBox.Items.Add(friend.Name + "'s Birthday");
                        }
                    }

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

        private void PostsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchCommentsFromSelectedPost(sender);
        }

        private void fetchCommentsFromSelectedPost(object sender)
        {
            List<Post> userPostList = m_LoggedInUser.Posts.ToList<Post>();
            int postIndex = 0;
            postIndex = getIndexOfPostInPostsList((sender as ListBox).SelectedItem as string);
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

            try
            {
                foreach (Post currentPost in m_LoggedInUser.Posts)
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

            try
            {
                foreach (User currentFriend in m_LoggedInUser.Friends)
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
                friendsList = m_LoggedInUser.Friends.ToList<User>();
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

                if (m_UserSettings.IsRememberMeChecked && !string.IsNullOrEmpty(m_UserSettings.UserAccessToken))
                {
                    m_LoginResult = FacebookService.Connect(m_UserSettings.UserAccessToken);
                    m_UserSettings.UserAccessToken = m_LoginResult.AccessToken;
                    m_LoggedInUser = m_LoginResult.LoggedInUser;
                    updateFormData();

                    if(m_LoggedInUser != null)
                    {
                        this.FacebookLoginButton.Enabled = false;
                    }
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
                m_UserSettings.IsRememberMeChecked = true;
                m_UserSettings.SaveSettingToFile();
            }
            else
            {
                this.deleteXmlFile();

                if (m_LoggedInUser != null)
                {
                     FacebookService.Logout(new Action(voidFunction));
                }
            }
        }

        private void voidFunction()
        {
            // this method is empty according to the Logout method needs.
        }

        private void deleteXmlFile()
        {
            if (File.Exists("App Settings.xml"))
            {
                File.Delete("App Settings.xml");
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
            if (!TenBestFriendsAlgorithm.WasAlgorithmActivated)
            {
                lock (r_TenBestFriendsAlgorithmContext)
                {
                    if (!TenBestFriendsAlgorithm.WasAlgorithmActivated)
                    {
                        updatePicturesInTenBestFriendsTab(TenBestFriendsAlgorithm.BestFriendsAlgorithm(m_LoggedInUser));
                        this.BestFriendsInformationLabel.Font = new Font(BestFriendsInformationLabel.Font.FontFamily, 8f, FontStyle.Bold | FontStyle.Italic);
                        this.BestFriendsInformationLabel.Text = "According to our calculations those are your ten best friends";
                    }
                }
            }
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
            ExportToTextFile();
        }

        private void ExportToTextFile()
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
