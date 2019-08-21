﻿using System.Drawing;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public class FacebookFacade
    {
        private User m_LoggedInUser;
        private Settings m_UserSettings;
        private CachedUser m_CashedUser;
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
                m_CashedUser = FacebookCacheProxy.FacebookConnect(m_UserSettings.UserAccessToken);//FacebookService.Connect(m_UserSettings.UserAccessToken);
                m_LoggedInUser = m_CashedUser.M_CachedUser;
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
            m_CashedUser = FacebookCacheProxy.FacebookLogin();

            if (!string.IsNullOrEmpty(m_CashedUser.M_AccessToken))
            {
                m_LoggedInUser = m_CashedUser.M_CachedUser;
                m_UserSettings.UserAccessToken = m_CashedUser.M_AccessToken;
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
            FacebookCacheProxy.Logout();
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
