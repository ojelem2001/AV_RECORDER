using System;
using System.Drawing;
using System.Windows.Forms;
using RECORDER_LIB;


namespace AV_RECORDER
{
    public partial class AudioVideoForm : Form
    {
        private string outputDir;
        private string startdate;
        private string audioOutputFile;
        private string prefixWav = "wav";
        private AudioRecorder AudioRecClass;
        private MicRecorder MicRecClass;
        private delegate void SetTextCallback(string Message);


        public AudioVideoForm()
        {
            InitializeComponent();
            AudioRecClass = new AudioRecorder();
            MicRecClass = new MicRecorder();
            AudioRecClass.OnSomthingChanged += LogIt;
        }
        private void LogIt(string Message)
        {
            SetText(Message);
        }
        private void SetText(string Message)
        {
            if (statusBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { Message });
            }
            else
            {
                statusBox.Text += Message;
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (button_start.BackColor == Color.Red)
            {
                Stop_recording();
            }
            else
            {
                Start_recording();
            }
        }
        private void Start_recording()
        {
            button_start.BackColor = Color.Red;
            outputDir = lbOutputDir.Text;
            lbOutFile.Text = null;

            startdate = DateTime.Now.ToString("yyyyMMddHHmmss");
            audioOutputFile = string.Concat(outputDir, startdate, ".out.", prefixWav);
            AudioRecClass.RecSoundStart(audioOutputFile);
            if (chkMic.Checked)
            {
                MicRecClass.RecMicStart();
            }
            button_start.Text = "Stop";
        }

        private void Stop_recording()
        {
            button_start.BackColor = Color.ForestGreen;
            audioOutputFile = AudioRecClass.RecSoundStop();
            lbOutFile.Text = audioOutputFile;
            MicRecClass.RecMicStop();//mic
            button_start.Text = "Record";
        }
    }
}
