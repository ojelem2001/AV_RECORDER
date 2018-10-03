using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AV_RECORDER_LIB;

namespace AV_RECORDER
{
    public partial class AudioVideoForm : Form
    {
        private string outputDir;
        private string startdate;
        private string audioOutputWavFile;
        private string audioOutputMp3File;
        private string prefixWav = ".wav";
        private string prefixMp3 = ".mp3";
        private AudioRecorder AudioRecClass;
        private MicRecorder MicRecClass;
        private delegate void SetTextCallback(string Message);

        public AudioVideoForm()
        {
            InitializeComponent();
            AudioRecClass = new AudioRecorder();
            MicRecClass = new MicRecorder();
            AudioRecClass.OnSomthingChanged += LogIt;
            MicRecClass.OnSomthingHappened  += LogIt;
        }

        private void LogIt(object sender, string e)
        {
            SetText(string.Concat(e, "\r\n"));
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
            
            startdate = DateTime.Now.ToString("yyyyMMddHHmmss");
            audioOutputWavFile = string.Concat(outputDir, startdate, prefixWav);
            audioOutputMp3File = string.Concat(outputDir, startdate, prefixMp3);
            lbOutFile.Text = audioOutputWavFile;
            AudioRecClass.RecSoundStart(audioOutputWavFile, audioOutputMp3File);
            StartTimeCounter();//Start time counter

            if (chkMic.Checked)
            {
                MicRecClass.RecMicStart();
            }
           
             button_start.Text = "Stop";
        }

        private void Stop_recording()
        {
            button_start.BackColor = Color.ForestGreen;
            AudioRecClass.DeInitializeTimeCount();//Stop time counter
            audioOutputWavFile = AudioRecClass.RecSoundStop();
            MicRecClass.RecMicStop();//mic
            button_start.Text = "Record";
            if (chkRemoveWav.Checked)
            {
                File.Delete(audioOutputWavFile);
                LogIt(this, string.Format("File {0} deleted", audioOutputWavFile));
                lbOutFile.Text = audioOutputMp3File;
            }
        }
        private async void StartTimeCounter()
        {
            var progress = new Progress<string>(s => lbTimeCounter.Text = s);

            string result = await Task.Factory.StartNew<string>(
                                                     () => AudioRecClass.InitializeTimeCount(progress),
                                                     TaskCreationOptions.LongRunning);
            lbTimeCounter.Text = result;
        }
          
    }
}
