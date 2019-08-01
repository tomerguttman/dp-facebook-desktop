using System;
using FacebookWrapper.ObjectModel;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public class UserRating
    {
        private User m_User;
        private int m_UserRating;

        public User User
        {
            get
            {
                return m_User;
            }
            set
            {
                m_User = value;
            }
        }

        public int Rating
        {
            get
            {
                return m_UserRating;
            }
            set
            {
                m_UserRating = value;
            }
        }

        public UserRating(User i_User)
        {
            m_UserRating = 0;
            m_User = i_User;
        }

    }
}
