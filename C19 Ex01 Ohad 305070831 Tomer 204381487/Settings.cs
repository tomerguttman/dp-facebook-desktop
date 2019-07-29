using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public class Settings
    {
        private string m_UserAccessToken;
        private bool m_IsRememberMeChecked;

        private Settings()
        {
            m_IsRememberMeChecked = false;
            m_UserAccessToken = "";
        }

        public string UserAccessToken { get; set; }
        public bool IsRememberMeChecked { get; set; }

        public void SaveSettingToFile()
        {
            using (Stream stream = new FileStream("App Settings.xml", FileMode.CreateNew))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }

        public static Settings LoadSettingsFromFile()
        {
            Settings settings = new Settings();

            if (File.Exists("App Settings.xml"))
            {
                using (Stream stream = new FileStream("App Settings.xml", FileMode.CreateNew))
                {
                    stream.Position = 0;
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    settings = serializer.Deserialize(stream) as Settings;
                }
            }
            
            return settings;
        }
    }
}

