using Xamarin.Forms.Platform.WPF;
using System.Windows.Interop;
using System.Windows.Controls;

[assembly: ExportRenderer(typeof(VidyoConnector.Controls.NativeView), typeof(VidyoConnector.WPF.Renderers.NativeViewRenderer))]

namespace VidyoConnector.WPF.Renderers
{
    public class NativeViewRenderer : ViewRenderer<Controls.NativeView, Canvas>
    {
        private Canvas _uiView;

        protected override void OnElementChanged(ElementChangedEventArgs<Controls.NativeView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                _uiView = new Canvas();

                SetNativeControl(_uiView);
            }

            Control.Loaded += Control_Loaded;
        }

        private void Control_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var panelHwnd = (HwndSource)System.Windows.PresentationSource.FromVisual(_uiView);
            if (panelHwnd != null)
            {
                VidyoController vidyoController = VidyoController.GetInstance();
                //this sets the _videoView's handle and calls appStart
                vidyoController.SetNativeHandle(panelHwnd.Handle);
                ViewModel thisModel = ViewModel.GetInstance();
                thisModel.ClientVersion = "v " + vidyoController.OnAppStart();
            }
        }
    }
}