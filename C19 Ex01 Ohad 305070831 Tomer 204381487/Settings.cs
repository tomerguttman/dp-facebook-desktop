using System.IO;
using System.Xml.Serialization;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public class Settings
    {
        private string m_UserAccessToken;
        private bool m_IsRememberMeChecked;

        private Settings()
        {
            m_IsRememberMeChecked = false;
            m_UserAccessToken = string.Empty;
        }

        public static Settings LoadSettingsFromFile()
        {
            Settings o_appSettings = new Settings();

            if (File.Exists("App Settings.xml"))
            {
                using (Stream stream = new FileStream("App Settings.xml", FileMode.Open))
                {
                    stream.Position = 0;
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    o_appSettings = serializer.Deserialize(stream) as Settings;
                }
            }

            return o_appSettings;
        }

        public string UserAccessToken
        {
            get
            {
                return m_UserAccessToken;
            }

            set
            {
                m_UserAccessToken = value;
            }
        }

        public bool IsRememberMeChecked
        {
            get
            {
                return m_IsRememberMeChecked;
            }

            set
            {
                m_IsRememberMeChecked = value;
            }
        }

        public void SaveSettingToFile()
        {
                using (Stream stream = new FileStream("App Settings.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(this.GetType());
                    serializer.Serialize(stream, this);
                }
        }

        public void deleteXmlFile()
        {
            if (File.Exists("App Settings.xml"))
            {
                File.Delete("App Settings.xml");
            }
        }

    }
}