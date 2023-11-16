
using NAudio.Wave;
using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;
using System.Threading.Channels;
using static OpenAI.GPT3.ObjectModels.Models;
using Newtonsoft.Json.Converters;
using Vosk;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace interview_assist {
    internal class Listener {
        private WasapiLoopbackCapture capture;
        private VoskRecognizer rec;
        WaveFileWriter waveWriter;

        private bool listening = false;
        private int sampleRate = 16000;

        public Listener(NAudio.CoreAudioApi.MMDevice device) {
            capture = new WasapiLoopbackCapture(device);
            capture.DataAvailable += onCaptured;

            Vosk.Model model = new Vosk.Model(G.modelPath);

            rec = new VoskRecognizer(model, (float) sampleRate);
            rec.SetMaxAlternatives(0);
            rec.SetWords(true);
        }

        void onCaptured(object sender, WaveInEventArgs e) {
            if (listening) {                
                waveWriter.Write(e.Buffer, 0, e.BytesRecorded);                
            }
        }

        public void Start() {
            File.Delete("tmp.wav");
            File.Delete("out.wav");

            waveWriter = new WaveFileWriter("tmp.wav", capture.WaveFormat);

            rec.Reset();
            capture.StartRecording();
            
            listening = true;            
        }

        public void Stop(bool forced = false) {
            listening = false;
            capture.StopRecording();

            waveWriter.Flush();
            waveWriter.Close();

            if (!forced) { 
                Ffmpeg encoder = new Ffmpeg(G.appPath + "\\" + "ffmpeg.exe");
                encoder.Start(Ffmpeg.CreateArgs("pcm_s16le", "256k", "tmp.wav", "out.wav"));

                rec.SetMaxAlternatives(0);
                rec.SetWords(true);

                using (Stream source = File.OpenRead("out.wav")) {
                    byte[] buffer = new byte[4096];
                    int bytesRead = 0;
                    string text = "";

                    while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0) {
                        if (rec.AcceptWaveform(buffer, bytesRead)) {
                            try {
                                text = getText(rec.Result());
                                if (text.Trim().Length > 0) MainForm.instance.onListened(text);
                            } catch (Exception) {
                            }
                        }
                    }
                    text = getText(rec.FinalResult());
                    if (text.Trim().Length > 0) MainForm.instance.onListened(text);
                }
            }
            File.Delete("tmp.wav");
            File.Delete("out.wav");
        }

        private string getText(string result) {
            JsonNode jo = JsonObject.Parse(result);
            return jo["text"].ToString();
        }
    }
}
