
namespace interview_assist {
    public static class G {
        public static string appTitle = "Interview Assist";
        public static string appPath = "";
        public static string modelPath = "";
        public static string apiKey = "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";

        public static bool initialize() {
            appPath = Application.StartupPath;            
            if (appPath[appPath.Length - 1] != '\\') appPath += "\\";

            modelPath = appPath + "models\\en";
            
            if (!Directory.Exists(modelPath)) {
                modelPath = appPath + "..\\..\\..\\models\\en";

                if (!Directory.Exists(modelPath)) return false;
            }
            return true;
        }

        public static void alertMsg(string msg) {
            MessageBox.Show(msg, appTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void alertError(string msg) {
            MessageBox.Show(msg, appTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void alertWarning(string msg) {
            MessageBox.Show(msg, appTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
