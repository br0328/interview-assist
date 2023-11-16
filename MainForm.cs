
using NAudio.CoreAudioApi;
using System.Text;

namespace interview_assist {
    public partial class MainForm : Form {
        public static MainForm instance = null;

        private bool listening = false;
        private Listener listener;
        private ChatGPTClient client = new ChatGPTClient();

        private delegate void onListenedDelegate(string text);

        public MainForm() {
            InitializeComponent();
            instance = this;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            if (!G.initialize()) {
                G.alertError("Initialization failed. Please make sure you have model directory.");
                Close();
                return;
            }
            if (Environment.OSVersion.Version.Major < 6) {
                G.alertWarning("The current Windows version does not support speaker output capturing.\n\n" +
                    "The assistant is unable to listen to the interviewer.");

                butStartStop.Enabled = false;
            }
            MMDeviceEnumerator devEnum = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            MMDeviceCollection devColl = devEnum.EnumerateAudioEndPoints(DataFlow.Render, NAudio.CoreAudioApi.DeviceState.Active);

            if (devColl.Count > 0) {
                foreach (MMDevice d in devColl) {
                    cboDevice.Items.Add(d.FriendlyName);
                }
                cboDevice.SelectedIndex = 0;
            } else {
                G.alertWarning("No audio output device found.\n\n" +
                    "The assistant is unable to listen to the interviewer.");

                butStartStop.Enabled = false;
            }
        }

        private void butStartStop_Click(object sender, EventArgs e) {
            txtQuestion.Clear();

            if (!listening) {
                MMDevice currentDevice = null;

                foreach (MMDevice d in new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)) {
                    if (d.FriendlyName == cboDevice.Text) {
                        currentDevice = d;
                        break;
                    }
                }
                listener = new Listener(currentDevice);
                                
                listener.Start();
                listening = true;

                butStartStop.Text = "Stop";
                lblQuestion.Text = "Question : (Listening ...)";
            } else {
                listener.Stop(true);
                listening = false;

                butStartStop.Text = "Start";
                lblQuestion.Text = "Question :";
            }
            butResponse.Focus();
        }

        public void onListened(string text) {
            if (txtQuestion.InvokeRequired) {
                txtQuestion.Invoke(new onListenedDelegate(onListened), new object[] { text });
            } else {
                txtQuestion.Text += text + " ";
            }
        }

        private void butClear_Click(object sender, EventArgs e) {
            txtQuestion.Text = "";
        }

        private void butResponse_Click(object sender, EventArgs e) {
            lblQuestion.Text = "Question :";
            lblAnswer.Text = "Answer : (Thinking ...)";
            
            if (listening) listener.Stop();

            string prompt = "You are a job seeker who is having a technical interview now.\n"
                + "The following text delimited by three backticks is the interviewer's question.\n"
                + "The question text is transcribed by Speech-To-Text AI, so it might be messy and have some errors.\n"
                + "Please provide the response to the question so that you can showcase your experience, expertise, talents, humanity and honesty.\n"
                + "```\n"
                + txtQuestion.Text
                + "```";
            txtAnswer.Text = client.SendMessage(prompt);

            lblQuestion.Text = "Question : (Listening ...)";
            lblAnswer.Text = "Answer :";
            txtQuestion.Text = "";

            if (listening) listener.Start();
        }
    }
}
