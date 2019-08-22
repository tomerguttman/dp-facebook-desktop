using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    [Serializable]
    public class CachedUser
    {
        private string m_AccessToken;
        private UserData m_UserData;

        public void InitializeCachedUser(User i_UserToCache, string i_AccessToken)
        {
            m_AccessToken = i_AccessToken;
            m_UserData = new UserData();
            m_UserData.InitializeUserData(i_UserToCache.Name, i_UserToCache.PictureNormalURL, i_UserToCache.Albums[0].Photos[0].PictureNormalURL);
            m_UserData.AddListsToUserData(i_UserToCache.Posts, i_UserToCache.Friends);
        }

        public string AccessToken { get { return m_AccessToken; } set { m_AccessToken = value; } }

        public UserData UserData { get { return m_UserData; } set { m_UserData = value; } }
    }
}
