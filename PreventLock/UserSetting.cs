using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace PreventLock {
    class UserSetting {

        private String SETTING_URL = @"Data\Setting.xml";
        private String TAG_USERSETTINGS = "UserSetting";
        public static String TAG_ENABLE_ANCHOR_POSITION = "Enable_Anchor_Position";
        public static String TAG_POSITON_LEFT = "Anchor_Position_Left";
        public static String TAG_POSITON_TOP = "Anchor_Position_Top";

        private Hashtable mFeatureList;
        private static UserSetting instance = null;
        public static UserSetting getInstance() {
            if(instance == null)
                instance = new UserSetting();
            return instance;
        }

        public UserSetting() {
            mFeatureList = new Hashtable();
            Thread threadReadSettingXML = new Thread(loadUserSettingsFromXMLFile);
            threadReadSettingXML.Start();
        }

        private void loadUserSettingsFromXMLFile( object obj ) {
            XmlTextReader reader = null;
            try {
                reader = new XmlTextReader(SETTING_URL);
                string key = "";
                string value = "";
                while(reader.Read()) {
                    switch(reader.NodeType) {
                        case XmlNodeType.Element:
                            key = reader.Name;
                            break;
                        case XmlNodeType.Text:
                            value = reader.Value;
                            break;
                        case XmlNodeType.EndElement:
                            if(!reader.Name.Equals(TAG_USERSETTINGS)) {
                                setString(key, value);
                            }
                            break;
                    }
                }
                reader.Close();
            } catch(Exception e) {
                if(reader != null)
                    reader.Close();
            }
        }

        public void save() {
            Thread threadSaveXML = new Thread(writeUserSettingsToXML);
            threadSaveXML.Start();
        }

        private void writeUserSettingsToXML() {
            XmlTextWriter xmlWriter = null;
            try {
                xmlWriter = new XmlTextWriter(SETTING_URL, Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(TAG_USERSETTINGS);
                ICollection keys = mFeatureList.Keys;
                foreach(string key in keys) {
                    xmlWriter.WriteElementString(key, getString(key, ""));
                }
                xmlWriter.WriteEndElement();
                xmlWriter.Flush();
                xmlWriter.Close();
            } catch(Exception e1) {
                if(xmlWriter != null)
                    xmlWriter.Close();
            }
        }

        public void setString( string tag, string value ) {
            try {
                if(mFeatureList.ContainsKey(tag)) {
                    mFeatureList[tag] = value;
                } else {
                    mFeatureList.Add(tag, value);
                }
            } catch(Exception e) {
                
            }
        }

        public string getString( string tag, string defaultValue ) {
            try {
                string value = (string)mFeatureList[tag];
                if(value == null) {
                    value = defaultValue;
                }
                return value;
            } catch(Exception e1) {
                return defaultValue;
            }
        }

        //private string encryptString( string input ) {
        //    string output = "";
        //    for(int i = 0; i < input.Length; i++) {
        //        string encryptChar = "" + ((int)input[i] + 13 + i);
        //        while(encryptChar.Length < 4) {
        //            encryptChar = "0" + encryptChar;
        //        }
        //        output = output + encryptChar;
        //    }
        //    return output;
        //}
        //private string deCryptString( string input ) {
        //    string output = "";
        //    if(input == null || input.Equals(""))
        //        return output;
        //    string encryptChar = "";
        //    int k = 0;
        //    for(int i = 0; i < input.Length; i++) {
        //        encryptChar += input[i];
        //        if((i + 1) % 4 == 0) {
        //            string decryptChar = "" + (char)(Int32.Parse(encryptChar) - 13 - k++);
        //            output = output + decryptChar;
        //            encryptChar = "";
        //        }
        //    }
        //    return output;
        //}
    }
}
