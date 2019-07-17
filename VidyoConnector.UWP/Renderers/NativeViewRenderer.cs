//using Windows.UI.Xaml.Controls;
//using Windows.UI.Xaml.Media;
//using Xamarin.Forms.Platform.UWP;


//[assembly: ExportRenderer(typeof(VidyoConnector.Controls.NativeView), typeof(VidyoConnector.UWP.NativeViewRenderer))]

//namespace VidyoConnector.UWP
//{
//    public class NativeViewRenderer : ViewRenderer<Controls.NativeView, Windows.UI.Xaml.Controls.Panel>
//    {
//        CaptureElement _captureElement;
//        bool _isPreviewing;

//        public NativeViewRenderer() { }

//        protected override void OnElementChanged(ElementChangedEventArgs<Controls.NativeView> e)
//        {
//            base.OnElementChanged(e);

//            if (Control == null)
//            {
//                // Instantiate the native control and assign it to the Control property with
//                // the SetNativeControl method
//                _captureElement = new CaptureElement();
//                _captureElement.Stretch = Stretch.UniformToFill;

//                //SetupCamera();
//                SetNativeControl(_captureElement);
//            }

//            if (e.OldElement != null)
//            {
//                // Unsubscribe from event handlers and cleanup any resources
//                VidyoController.GetInstance().Cleanup();
//            }

//            if (e.NewElement != null)
//            {
//                // Configure the control and subscribe to event handlers

//                e.NewElement.Handle = this.Control.Handle;
//            }
//        }
//    }
//}
