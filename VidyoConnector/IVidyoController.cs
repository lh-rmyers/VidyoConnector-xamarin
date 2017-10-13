using System;
using Xamarin.Forms;

namespace VidyoConnector
{
    public interface IVidyoController
    {
        // App lifecycle events
        string OnAppStart();
        void OnAppSleep();
        void OnAppResume();

        // Provide the native view
        void GetNativeView(Controls.NativeView videoView);
        VidyoConnectorState ConnectorState { get; set; }

        // Events triggered by button clicks from UI
        bool Connect(string host, string token, string displayName, string resourceId);
        void Disconnect();
        void SetMicrophonePrivacy(bool privacy);
        void SetCameraPrivacy(bool privacy);
        void CycleCamera();

        // Orientation has changed
        void OnOrientationChange();
	}
}
