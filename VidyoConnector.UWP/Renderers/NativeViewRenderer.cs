using Windows.UI.Xaml;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.Xaml.Controls;
using System;

[assembly: ExportRenderer(typeof(VidyoConnector.Controls.NativeView), typeof(VidyoConnector.UWP.Renderers.NativeViewRenderer))]

namespace VidyoConnector.UWP.Renderers
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

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            var panelHwnd = new IntPtr(); //(HwndSource)System.Windows.PresentationSource.FromVisual(_uiView);
            if (panelHwnd != null)
            {
                VidyoController vidyoController = VidyoController.GetInstance();
                //this sets the _videoView's handle and calls appStart
                //vidyoController.SetNativeHandle(panelHwnd.Handle);
                vidyoController.OnAppStart();
            }
        }
    }
}