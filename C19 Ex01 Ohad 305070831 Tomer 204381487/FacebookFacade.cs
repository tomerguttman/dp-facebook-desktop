using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public class FacebookFacade
    {
        private User m_LoggedInUser;
        private LoginResult m_LoginResult;
        private Settings m_UserSettings;
        private bool m_IsLoggedIn = false;

        public bool IsLoggedIn { get { return m_IsLoggedIn; } set { m_IsLoggedIn = value; } }

        public FacebookFacade()
        {
            LoadSettingsFromFile();
            if (!string.IsNullOrEmpty(m_UserSettings.UserAccessToken))
            {
                ConnectToFacebook();
            }

        }

        public void UpdateRemeberMeSettings()
        {
            m_UserSettings.IsRememberMeChecked = true;
        }

        public void ConnectToFacebook()
        {
            if (m_UserSettings.IsRememberMeChecked)
            {
                m_LoginResult = FacebookService.Connect(m_UserSettings.UserAccessToken);
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                IsLoggedIn = true;
            }
        }

        private void LoadSettingsFromFile()
        {
           m_UserSettings = Settings.LoadSettingsFromFile();
        }

        public bool IsRememberMeChecked()
        {
            return m_UserSettings.IsRememberMeChecked;
        }

        public bool LoginToFacebook()
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
                IsLoggedIn = true;
            }

            return IsLoggedIn;
        }

        public string GetBirthday()
        {
            return m_LoggedInUser.Birthday;

        }

        public string GetName()
        {
            return m_LoggedInUser.Name;
        }

        public Image GetProfileImage()
        {
            return m_LoggedInUser.ImageNormal;
        }

        public FacebookObjectCollection<Post> GetPosts()
        {
            return m_LoggedInUser.Posts ;
        }

        public FacebookObjectCollection<Post> GetWallPosts()
        {
            return m_LoggedInUser.WallPosts;
        }

        public string GetID()
        {
            return m_LoggedInUser.Id;
        }

        public FacebookObjectCollection<User> GetFriends()
        {
            return m_LoggedInUser.Friends;
        }

        public FacebookObjectCollection<Event> GetEvents()
        {
            return m_LoggedInUser.Events;
        }

        public Image GetCoverImage()
        {
            return m_LoggedInUser.Albums[0].Photos[0].ImageNormal;
        }

        public void Logout()
        {
            FacebookService.Logout(new Action(voidFunction));
        }

        private void voidFunction()
        {
            // this method is empty according to the Logout method needs.
        }

        public void SaveSettingToFile()
        {
            m_UserSettings.SaveSettingToFile();
        }

        public void deleteXmlFile()
        {
            m_UserSettings.deleteXmlFile();
        }
    }  
}
