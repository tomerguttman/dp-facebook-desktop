using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using System.IO;
using FacebookWrapper;


namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public partial class FacebookForm : Form
    {
        private User m_LoggedInUser;
        private Settings m_UserSettings;
        private LoginResult m_LoginResult;

        public FacebookForm()
        {
            InitializeComponent();
            m_UserSettings = Settings.LoadSettingsFromFile();
        }

        private void FacebookLoginButton_Click(object sender, EventArgs e)
        {
            //Our appid:415704425731459 , 
            m_LoginResult = FacebookService.Login("1450160541956417", "public_profile",
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
            else
            {
                MessageBox.Show(m_LoginResult.ErrorMessage);
            }
        }

        private void updateFormData()
        {
            this.ProfilePictureBox.Image = m_LoggedInUser.ImageNormal;
            this.Text = m_LoggedInUser.Name;
            this.CoverPhotoPictureBox.BackgroundImage = m_LoggedInUser.Albums[0].Photos[0].ImageNormal;
            addFriendsToListBox();
            addPostsToListBox();
        }

        private void addPostsToListBox()
        {
            foreach (Post post in m_LoggedInUser.Posts)
            {
                PostsListBox.Items.Add(post.Message + " " + post.CreatedTime.Value.ToShortDateString());
            }
        }

        private void addFriendsToListBox()
        {
            foreach (User friend in m_LoggedInUser.Friends)
            {
                FriendsListBox.Items.Add(friend.Name);
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
                catch(Exception exception)
                {
                    MessageBox.Show("The information couldn't be retrieved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

            else
            {
                MessageBox.Show("Please login first!");
            }
        }

        private void PostsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchCommentsFromSelectedPost(sender);
        }

        private void fetchCommentsFromSelectedPost(object sender)
        {
            List<Post> userPostList = m_LoggedInUser.Posts.ToList<Post>();
            int postIndex = getIndexOfPostInPostsList((sender as ListBox).SelectedItem as string);
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
            
            if(postCommentsListBox.Items.Count == 0 )
            {
                postCommentsListBox.Items.Add("There are no comments on this post.");
            }

            commentsForm.Controls.Add(postCommentsListBox);
            commentsForm.ShowDialog();
        }

        private int getIndexOfPostInPostsList(string i_stringPost)
        {
            int outputIndex = 0;
            string temporaryString = null;

            foreach (Post currentPost in m_LoggedInUser.Posts)
            {
                temporaryString = currentPost.Message + " " + currentPost.CreatedTime.Value.ToShortDateString();

                if ( temporaryString.Contains(i_stringPost))
                {
                    break;
                }

                outputIndex += 1;
            }

            return outputIndex;
        }

        private int getIndexOfUserInFriendList(string i_stringUserName)
        {
            int outputIndex = 0;

            foreach (User currentFriend in m_LoggedInUser.Friends)
            {
                if (currentFriend.Name.Equals(i_stringUserName))
                {
                    break;
                }
                outputIndex += 1;
            }

            return outputIndex;
        }

        private void FriendsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<User> friendsList = m_LoggedInUser.Friends.ToList<User>();
            int postIndex = getIndexOfUserInFriendList((sender as ListBox).SelectedItem as string);
            User currentFriend = friendsList[postIndex];
            pickedFriendPictureBox.Image = currentFriend.ImageLarge;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (m_UserSettings.IsRememberMeChecked && !string.IsNullOrEmpty(m_UserSettings.UserAccessToken))
            {
                m_LoginResult = FacebookService.Connect(m_UserSettings.UserAccessToken);
                m_UserSettings.UserAccessToken = m_LoginResult.AccessToken;
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                updateFormData();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (this.RememberMeCheckbox.Checked)
            {
                m_UserSettings.IsRememberMeChecked = true;
                m_UserSettings.SaveSettingToFile();
            }
            else
            {
                if (File.Exists("App Settings.xml"))
                {
                    File.Delete("App Settings.xml");
                }
            }

        }

    }
}
