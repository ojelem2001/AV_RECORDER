using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasapiCapture = CSCore.SoundIn.WasapiCapture;
using CSCore.Codecs.WAV;
using System.IO;
using NA = NAudio.Wave;
using NAudio.Lame;
using System.Threading;
using System.Windows.Forms;

namespace AV_RECORDER_LIB
{
    public class AudioRecorder
    {
        public Label scoreboard;
        private string _outputWaveName;
        private string _outputMp3Name;
        private WasapiCapture capture = null;
        private WaveWriter w = null;
        public delegate void EventLogHandler(object sender, string e);
        public event EventLogHandler OnSomthingChanged;
        private TimeSpan timeCounter;
        private DateTime initial_time;
        private ManualResetEvent stopWorkEvent;


        public AudioRecorder()
        {

        }
        public void RecSoundStart(string audioOutputWavFile, string audioOutputMp3File)
        {
            _outputWaveName = audioOutputWavFile;
            _outputMp3Name = audioOutputMp3File;
            capture = new CSCore.SoundIn.WasapiLoopbackCapture();
            capture.Initialize();
            w = new WaveWriter(_outputWaveName, capture.WaveFormat);
            capture.DataAvailable += (s, capData) =>
            {
                w.Write(capData.Data, capData.Offset, capData.ByteCount);
            };
            capture.Start();
            OnSomthingChanged?.Invoke(this, string.Format("Recording {0} started", _outputWaveName));
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
                OnSomthingChanged?.Invoke(this, string.Format("Recording {0} stopped", _outputWaveName));
                ConvertWavToMp3(_outputWaveName);
                return _outputWaveName;
            }
            return null;
        }
        public string InitializeTimeCount(IProgress<string> progress)
        {
            stopWorkEvent = new ManualResetEvent(false);
            initial_time = DateTime.Now;
            string timeTick;
            do
            {
                timeTick = timer_Tick();
                progress.Report(timeTick);
            }
            while (WaitHandle.WaitAny(new WaitHandle[] { stopWorkEvent }, 1) != 0);

            return timeTick;
        }
        public void DeInitializeTimeCount()
        {
            stopWorkEvent.Set();
        }
        private void ConvertWavToMp3(string fileName)
        {
            OnSomthingChanged?.Invoke(this, "Converting to mp3");
            byte[]  wavFile =  File.ReadAllBytes(fileName);
            using (var retMs = new MemoryStream())
            using (var ms = new MemoryStream(wavFile))
            using (var rdr = new NA.WaveFileReader(ms))
            using (var wtr = new LameMP3FileWriter(retMs, rdr.WaveFormat, 128))
            {
                rdr.CopyTo(wtr);
                wtr.Flush();
                File.WriteAllBytes(_outputMp3Name, retMs.ToArray());
            }
            OnSomthingChanged?.Invoke(this, string.Format("Converting finished to {0}", _outputMp3Name));
        } 

       
      
        private string timer_Tick()
        {
            DateTime current_time = DateTime.Now;
            timeCounter = current_time - initial_time;
            return timeCounter.Hours.ToString("D2") + ":" + timeCounter.Minutes.ToString("D2") + ":" + timeCounter.Seconds.ToString("D2");
        }

    }
}
