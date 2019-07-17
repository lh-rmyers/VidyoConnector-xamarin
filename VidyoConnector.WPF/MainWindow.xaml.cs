using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace VidyoConnector.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();
            Forms.Init();
            LoadApplication(new VidyoConnector.App(VidyoController.GetInstance()));
        }
    }
}
