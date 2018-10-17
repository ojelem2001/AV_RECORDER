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
        private  void LogIt(string message)
        {
            //  await Task.Factory.StartNew(() => OnSomthingChanged?.Invoke(this, message), TaskCreationOptions.LongRunning);
            OnSomthingChanged?.Invoke(this, message);
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
            LogIt(string.Format("recording {0} started", _outputWaveName));
            // OnSomthingChanged?.Invoke(this, string.Format("Recording {0} started", _outputWaveName));
        }
        public void RecSoundStop(bool isDeleteWav)
        {
 
            if (w != null && capture != null)
            {
                capture.Stop();
                w.Dispose();
                w = null;
                capture.Dispose();
                capture = null;

                LogIt("began converting to mp3");               
                Task task1 = Task.Factory.StartNew(()=> ConvertToMP3(_outputWaveName));
                task1.Wait();
                LogIt(string.Format("converting finished to {0}", _outputMp3Name));

                if (isDeleteWav)
                {
                    File.Delete(_outputWaveName);
                    LogIt(string.Format("File {0} deleted", _outputWaveName));
                }
                LogIt(string.Format("recording {0} stopped", _outputWaveName));
            }
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
        private void ConvertToMP3(string fileName)
        {
            byte[] wavFile = File.ReadAllBytes(fileName);
            using (var retMs = new MemoryStream())
            using (var ms = new MemoryStream(wavFile))
            using (var rdr = new NA.WaveFileReader(ms))
            using (var wtr = new LameMP3FileWriter(retMs, rdr.WaveFormat, 128))
            {
                rdr.CopyTo(wtr);
                wtr.Flush();
                File.WriteAllBytes(_outputMp3Name, retMs.ToArray());
            }
            Thread.Sleep(10000);
         }




        private string timer_Tick()
        {
            DateTime current_time = DateTime.Now;
            timeCounter = current_time - initial_time;
            return timeCounter.Hours.ToString("D2") + ":" + timeCounter.Minutes.ToString("D2") + ":" + timeCounter.Seconds.ToString("D2");
        }

    }
}
