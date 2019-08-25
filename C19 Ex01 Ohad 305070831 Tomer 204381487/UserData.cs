using System.Collections.Generic;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public class UserData
    {
        private string m_UserName = null;
        private List<string> m_UserPostsList = new List<string>();
        private List<string> m_UserFriendsList = new List<string>();
        private string m_UserProfileImageURL;
        private string m_UserCoverImageURL;

        public void InitializeUserData(string i_UserName, string i_UserProfileImage, string i_UserCoverImage)
        {
            m_UserName = i_UserName;
            m_UserProfileImageURL = i_UserProfileImage;
            m_UserCoverImageURL = i_UserCoverImage;
        }

        public string UserName
        {
            get
            {
                return m_UserName;
            }

            set
            {
                m_UserName = value;
            }
        }

        public string UserProfileImage
        {
            get
            {
                return m_UserProfileImageURL;
            }

            set
            {
                m_UserProfileImageURL = value;
            }
        }

        public string UserCoverImage
        {
            get
            {
                return m_UserCoverImageURL;
            }

            set
            {
                m_UserCoverImageURL = value;
            }
        }

        public List<string> UserPostsList
        {
            get
            {
                return m_UserPostsList;
            }

            set
            {
                m_UserPostsList = value;
            }
        }

        public List<string> UserFriendsList
        {
            get
            {
                return m_UserFriendsList;
            }

            set
            {
                m_UserFriendsList = value;
            }
        }

        public void AddListsToUserData(FacebookObjectCollection<Post> i_UserPostList, FacebookObjectCollection<User> i_UserFriendsList)
        {
            generateStringList<Post>(i_UserPostList);
            generateStringList<User>(i_UserFriendsList);
        }

        private void generateStringList<T>(FacebookObjectCollection<T> i_CollectionToConvert)
            where T : FacebookObject
        {
            List<string> newList = new List<string>();

            if (i_CollectionToConvert.FirstOrDefault() is Post)
            {
                foreach (T post in i_CollectionToConvert)
                {
                    newList.Add((post as Post).Message);
                }

                m_UserPostsList = newList;
            }
            else if (i_CollectionToConvert.FirstOrDefault() is User)
            {
                foreach(T user in i_CollectionToConvert)
                {
                    newList.Add((user as User).Name);
                }

                m_UserFriendsList = newList;
            }
        }
    }
}
