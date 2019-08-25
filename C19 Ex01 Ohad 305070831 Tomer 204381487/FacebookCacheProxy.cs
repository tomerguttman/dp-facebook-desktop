using System;
using System.IO;
using System.Xml.Serialization;
using System.Net.NetworkInformation;
using System.Text;
using System.Net;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public class FacebookCacheProxy
    {
        private static LoginResult m_LoginResult = new LoginResult();
        private static CachedUser m_CachedUser = null;

        public static User FacebookLogin(out CachedUser o_CachedUser)
        {
            if (PingNetwork())
            {
                m_LoginResult = FacebookWrapper.FacebookService.Login(
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
            }

            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                m_CachedUser = new CachedUser();
                m_CachedUser.InitializeCachedUser(m_LoginResult.LoggedInUser, m_LoginResult.AccessToken);
                cacheUser();
            }

            o_CachedUser = m_CachedUser;
            return m_LoginResult.LoggedInUser;
        }

        private static bool PingNetwork()
        {
            bool pingStatus = false;

            using (Ping p = new Ping())
            {
                string data = "Check Internet Connection";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;

                try
                {
                    PingReply reply = p.Send(@"google.com", timeout, buffer);
                    pingStatus = reply.Status == IPStatus.Success;
                }
                catch (Exception)
                {
                    pingStatus = false;
                }
            }

            return pingStatus;
        }

        internal static User FacebookConnect(string i_UserAccessToken, out CachedUser o_CachedUser)
        {
            if(PingNetwork())
            {
                m_LoginResult = FacebookService.Connect(i_UserAccessToken);

                if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
                {
                    m_CachedUser = new CachedUser();
                    m_CachedUser.InitializeCachedUser(m_LoginResult.LoggedInUser, m_LoginResult.AccessToken);
                    cacheUser();
                }
            }
            else
            {
                loadCachedUser();
            }

            o_CachedUser = m_CachedUser;
            return m_LoginResult.LoggedInUser;
        }

        private static void cacheUser()
        {
            using (Stream stream = new FileStream("User Cache.xml", FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CachedUser));
                serializer.Serialize(stream, m_CachedUser);
            }

            saveUserImage(m_CachedUser.UserData.UserProfileImage, "User Profile Image.jpg");
            saveUserImage(m_CachedUser.UserData.UserCoverImage, "User Cover Image.jpg");
        }

        private static void saveUserImage(string i_ImageURL, string i_ImageName)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(new Uri(i_ImageURL), i_ImageName);
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
            //// this method is empty according to the Logout method needs.
        }
    }
}
