using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;


namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public partial class FacebookForm : Form
    {
        private User m_LoggedInUser;

        public FacebookForm()
        {
            InitializeComponent();
        }

        private void FacebookLoginButton_Click(object sender, EventArgs e)
        {
            //Our appid:415704425731459
            LoginResult loginResult = FacebookService.Login("1450160541956417", "public_profile",
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
            
            if (!string.IsNullOrEmpty(loginResult.AccessToken))
            {
                m_LoggedInUser = loginResult.LoggedInUser;
                updateFormData();
            }
            else
            {
                MessageBox.Show(loginResult.ErrorMessage);
            }
        }

        private void updateFormData()
        {
            this.ProfilePictureBox.BackgroundImage = m_LoggedInUser.ImageNormal;
            this.Text = m_LoggedInUser.Name;
            this.CoverPhotoPictureBox.BackgroundImage = m_LoggedInUser.Albums[0].Photos[0].ImageNormal;
            addFriendsToListBox();
            addPostsToListBox();
        }

        private void addPostsToListBox()
        {
            foreach (Post post in m_LoggedInUser.Posts)
            {
                PostsListBox.Items.Add(post);
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
                    MessageBox.Show("Oh Oh! Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

            else
            {
                MessageBox.Show("Please login first!");
            }
        }

        private void PostsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //implement a method that finds a specific post from the list of posts! and then prints all the comments!bye.
            int postIndex;
            Form commentsForm = new Form();
            ListBox postCommentsListBox = new ListBox();
            commentsForm.Controls.Add(postCommentsListBox);
            commentsForm.Height = 460;
            commentsForm.Width = 260;
            postIndex = 3;
            postCommentsListBox = sender as ListBox;
            postCommentsListBox.Height = 450;
            postCommentsListBox.Width = 250;


            
            List<Post> userPostList = m_LoggedInUser.Posts.ToList<Post>();
            Post currentPost = userPostList[postIndex];

            foreach (Comment comment in currentPost.Comments)
            {
                postCommentsListBox.Items.Add(comment.Message);
            }

            commentsForm.ShowDialog();

            
          
        }
    }
}
