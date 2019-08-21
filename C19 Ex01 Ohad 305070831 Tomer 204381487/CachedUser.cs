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
        private User m_CachedUser;

        public string M_AccessToken { get { return m_AccessToken; } set { m_AccessToken = value; } }
        public User M_CachedUser { get { return m_CachedUser; } set { m_CachedUser = value; } }



    }
}
