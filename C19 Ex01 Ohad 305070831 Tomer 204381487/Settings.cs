using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    class Settings
    {
        private string m_UserAccessToken = null;
        private bool m_IsRememberMeChecked = false;

        public string UserAccessToken { get; set; }
        public bool IsRememberMeChecked { get; set; }

        public void SaveSettingToFile()
        {
            using (Stream stream = new FileStream(@"D:\appSettings.xml", FileMode.OpenOrCreate)
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());

            }
        }
    }
}

