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

        public MicRecorder()
        {

        }
        public void RecMicStart()
        {
            try
            {
                waveIn = new NAudio.Wave.WaveIn();
                waveIn.DeviceNumber = 0;
                waveIn.WaveFormat = new NAudio.Wave.WaveFormat(8000, 1);

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
              //  LogIt(ex.Message);
            }
        }
        public void RecMicStop()
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
                //  LogIt(string.Format("Recording {0} stopped{1}", outputMicName, endLine));
            }
        }
        private void wi_DataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
            // writer.Write(e.Buffer, 0, e.BytesRecorded);

        }

    }
}
