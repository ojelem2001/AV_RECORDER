using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace AV_RECORDER_LIB
{
    public class MicRecorder
    {
        private BufferedWaveProvider bwp;
        private WaveIn waveIn;
        private WaveOut wo;
        public delegate void EventLogHandler(object sender, string e);
        public event EventLogHandler OnSomthingHappened;

        public MicRecorder()
        {
        }
        private async void LogIt(string message)
        {
            OnSomthingHappened?.Invoke(this, message);
        }
        public void RecMicStart()
        {
            try
            {
                waveIn = new NAudio.Wave.WaveIn();
                waveIn.DeviceNumber = 0;
                waveIn.WaveFormat = new NAudio.Wave.WaveFormat(8000, 1);
                LogIt("microphone recording added");
                wo = new WaveOut();
                waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(wi_DataAvailable);
                bwp = new BufferedWaveProvider(waveIn.WaveFormat);
                bwp.DiscardOnBufferOverflow = true;
                wo.Init(bwp);
                wo.Play();
                waveIn.StartRecording();
            }
            catch (Exception ex)
            {
                OnSomthingHappened?.Invoke(this, ex.Message);
            }
        }
        public void RecMicStop()
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
            }
        }
        private void wi_DataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

    }
}
