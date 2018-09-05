using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasapiCapture = CSCore.SoundIn.WasapiCapture;
using CSCore.Codecs.WAV;

namespace AV_RECORDER_LIB
{
    public class AudioRecorder
    {
        private string _outputWaveName;
        private WasapiCapture capture = null;
        private WaveWriter w = null;

        public AudioRecorder()
        {
            
        }

        public void RecSoundStart(string outputWaveName)
        {
            _outputWaveName = outputWaveName;
            capture = new CSCore.SoundIn.WasapiLoopbackCapture();
            capture.Initialize();
            w = new WaveWriter(_outputWaveName, capture.WaveFormat);
            capture.DataAvailable += (s, capData) =>
            {
                w.Write(capData.Data, capData.Offset, capData.ByteCount);
            };
            capture.Start();
            // LogIt(string.Format("Recording {0} started{1}", _outputWaveName, endLine));
        }
        public string RecSoundStop()
        {

            if (w != null && capture != null)
            {
                capture.Stop();
                w.Dispose();
                w = null;
                capture.Dispose();
                capture = null;
                //    LogIt(string.Format("Recording {0} stopped{1}", _outputWaveName, endLine));
                return _outputWaveName;
            }
            return null;
        }
    }
}
