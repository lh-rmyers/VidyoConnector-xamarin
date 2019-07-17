
using Xamarin.Forms.Platform.WPF;
using System.Windows.Interop;

[assembly: ExportRenderer(typeof(VidyoConnector.Controls.NativeView), typeof(VidyoConnector.WPF.NativeViewRenderer))]

namespace VidyoConnector.WPF
{
    public class NativeViewRenderer : Xamarin.Forms.Platform.WPF.ViewRenderer<VidyoConnector.Controls.NativeView, System.Windows.Controls.Canvas>
    {
        System.Windows.Controls.Canvas _uiView;
        public NativeViewRenderer() { }
        protected override void OnElementChanged(Xamarin.Forms.Platform.WPF.ElementChangedEventArgs<VidyoConnector.Controls.NativeView> e)
        {

            base.OnElementChanged(e);

            if (Control == null)
            {
                _uiView = new System.Windows.Controls.Canvas();

                SetNativeControl(_uiView);
            }

            if (e.NewElement.Handle != null)
            {

                Control.Loaded += Control_Loaded;
                //Control.DataContext

                //e.NewElement.Handle = panelHwnd.Handle;

            }

        }

        private void Control_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            HwndSource panelHwnd = (HwndSource)HwndSource.FromVisual(_uiView);
            if (panelHwnd != null)
                VidyoController.GetInstance().SetNativeHandle(panelHwnd.Handle); //this sets the _videoView's handle and calls appStart

        }
    }
}