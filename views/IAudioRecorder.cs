using System;

using Xamarin.Forms;

namespace SalesApp.views
{
    public interface IAudioRecorder
    {
        void StartRecording();
        void StopRecording();
        void PlayRecording();
        // string RecordAudio ();

        string OutputString();

    }
}

