
using System.Diagnostics;

namespace interview_assist {
    internal class Ffmpeg {
        private Process ffmpeg;
        private string ffmpegPath;

        public Ffmpeg(string path) {
            if (File.Exists(path)) {
                ffmpegPath = path;
            } else {
                throw new Exception("Invalid ffmpeg path");
            }
            ffmpeg = new Process();
        }

        public void Start(string args) {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ffmpegPath;
            startInfo.Arguments = args;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = true;

            ffmpeg.StartInfo = startInfo;
            ffmpeg.Start();
            ffmpeg.WaitForExit();            
        }

        public static string CreateArgs(string codec, string bitrate, string input, string output) {
            return String.Format("-i \"{0}\" -c:a {1} -ar 16000 -ac 1 -b:a {2} \"{3}\"", input, codec, bitrate, output);
        }
    }
}
