using System;
using System.Collections.Generic;
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
        private string outputFileName;
        private string prefixWav = ".wav";
        private string prefixMp3 = ".mp3";
        private bool isBtnStartBlocked = false;
        private AudioRecorder AudioRecClass;
        private MicRecorder MicRecClass;
        private delegate void SetTextCallback(string Message);
        private List<Task> TaskList = new List<Task>();

        public AudioVideoForm()
        {
            InitializeComponent();
            AudioRecClass = new AudioRecorder();
            MicRecClass = new MicRecorder();
            AudioRecClass.OnSomthingChanged += LogIt;
            MicRecClass.OnSomthingHappened  += LogIt;
        }

        private  void LogIt(object sender, string e)
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
            if (isBtnStartBlocked)
            {
                LogIt(this, "Please, just wait until the end!");

                return;
            }
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
            Block_startButton(false, true);

            outputDir = lbOutputDir.Text;
            outputFileName = lbOutputFileName.Text;
            if (outputFileName != null) {
                outputFileName = string.Concat('_', outputFileName);
            }
            startdate = DateTime.Now.ToString("yyyyMMddHHmmss");
            audioOutputWavFile = string.Concat(outputDir, startdate, outputFileName, prefixWav);
            audioOutputMp3File = string.Concat(outputDir, startdate, outputFileName, prefixMp3);
            lbOutFile.Text = audioOutputWavFile;
            AudioRecClass.RecSoundStart(audioOutputWavFile, audioOutputMp3File);
            StartTimeCounter();//Start time counter

            if (chkMic.Checked)
            {
                MicRecClass.RecMicStart();
            }           
        }
       
        private void Stop_recording()
        {
            //  button_start.Enabled = false;
            Block_startButton(true);

            Task timeCounterTask = Task.Factory.StartNew(() => AudioRecClass.DeInitializeTimeCount());//Stop time counter
            Task soundStopTask = Task.Factory.StartNew(() => AudioRecClass.RecSoundStop(chkRemoveWav.Checked));
            Task micStopTask = Task.Factory.StartNew(() => MicRecClass.RecMicStop());//mic

            // Task.WaitAll(soundStopTask);
            soundStopTask.ContinueWith(t => Block_startButton(false, false));
        }

        private void Block_startButton(bool isBlockButton, bool recording = false)
        {
            isBtnStartBlocked = isBlockButton;
            
            if (!recording & !isBlockButton)
            {
                button_start.BackColor = Color.ForestGreen;
                button_start.Text = "Record";
            }
            if (recording & !isBlockButton)
            {
                button_start.BackColor = Color.Red;
                button_start.Text = "Stop";
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

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            statusBox.Text = "";
        }

        private void chkMic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMic.Checked)
                LogIt(this, "microphone recording is ON");
            else
                LogIt(this, "microphone recording is OFF");

        }

        private void chkRemoveWav_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRemoveWav.Checked)
                LogIt(this, "after converting to mp3, source wav file will be removed");
            else
                LogIt(this, "we will save source wav file for you");
        }
    }
}
