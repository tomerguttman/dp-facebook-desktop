using System;
using FacebookWrapper.ObjectModel;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    class UserRating
    {
        private User m_User;
        private int m_UserRating;

        public User User { get; set; }
        public int Rating { get; set; }

        public UserRating(User i_User)
        {
            m_UserRating = 0;
            m_User = i_User;
        }

    }
}
