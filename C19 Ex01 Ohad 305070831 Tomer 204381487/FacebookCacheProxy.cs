using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Xml.Serialization;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public class FacebookCacheProxy
    {
        private static LoginResult m_LoginResult = null;
        private static CachedUser m_CachedUser = new CachedUser();

        public static CachedUser FacebookLogin()
        {
            m_LoginResult = FacebookWrapper.FacebookService.Login("1450160541956417",
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

            m_CachedUser.M_AccessToken = m_LoginResult.AccessToken;
            m_CachedUser.M_CachedUser = m_LoginResult.LoggedInUser;

            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                cacheUser();
            }

            return m_CachedUser;
        }

        internal static CachedUser FacebookConnect(string i_UserAccessToken)
        {
            m_LoginResult = FacebookService.Connect(i_UserAccessToken);
            m_CachedUser.M_AccessToken = m_LoginResult.AccessToken;
            m_CachedUser.M_CachedUser = m_LoginResult.LoggedInUser;

            if (string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                loadCachedUser();
            }

            return m_CachedUser;
        }

        private static void cacheUser()
        {
            using (Stream stream = new FileStream("User Cache.xml", FileMode.Create))
            {
                bool i = typeof(CachedUser).IsSerializable; 
                XmlSerializer serializer = new XmlSerializer(typeof(CachedUser));
                serializer.Serialize(stream, m_CachedUser);
            }
        }

        private static void loadCachedUser()
        {
            if (File.Exists("User Cache.xml"))
            {
                using (Stream stream = new FileStream("User Cache.xml", FileMode.Open))
                {
                    stream.Position = 0;
                    XmlSerializer serializer = new XmlSerializer(typeof(CachedUser));
                    m_CachedUser = serializer.Deserialize(stream) as CachedUser;
                }
            }
        }

        internal static void Logout()
        {
            FacebookService.Logout(new Action(voidFunction));
            deleteCache();
        }

        private static void deleteCache()
        {
            if (File.Exists("User Cache.xml"))
            {
                File.Delete("User Cache.xml");
            }
        }

        private static void voidFunction()
        {
            // this method is empty according to the Logout method needs.
        }

    }
}
