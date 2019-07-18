using AVFoundation;
using AppKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(VidyoConnector.Controls.NativeView), typeof(VidyoConnector.MacOS.NativeViewRenderer))]

namespace VidyoConnector.MacOS
{
    public class NativeViewRenderer : Xamarin.Forms.Platform.MacOS.ViewRenderer<Controls.NativeView, NSView>
    {
        NSView _nsView;

        protected override async void OnElementChanged(Xamarin.Forms.Platform.MacOS.ElementChangedEventArgs<Controls.NativeView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                // Instantiate the native control and assign it to the Control property with
                // the SetNativeControl method
                _nsView = new NSView();
                SetNativeControl(_nsView);
            }

            if (e.OldElement != null)
            {
                // Unsubscribe from event handlers and cleanup any resources
                VidyoController.GetInstance().Cleanup();
            }

            if (e.NewElement != null)
            {
                // Configure the control and subscribe to event handlers
                e.NewElement.Handle = this.Control.Handle;
                await this.AuthorizeMediaUse();
            }
        }

        async System.Threading.Tasks.Task AuthorizeMediaUse()
        {
            var authorizationStatus = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);

            if (authorizationStatus != AVAuthorizationStatus.Authorized)
            {
                await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Video);
            }

            authorizationStatus = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Audio);
            if (authorizationStatus != AVAuthorizationStatus.Authorized)
            {
                await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Audio);
            }
        }
    }
}
