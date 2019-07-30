using System.ComponentModel;

namespace VidyoConnector
{
    public class ViewModel : INotifyPropertyChanged
    {
        private static ViewModel _instance = new ViewModel();
        public static ViewModel GetInstance() { return _instance; }

        private TokenGenerator _tokenGenerator;

        private ViewModel()
        {
            this.DisplayDiagnostics = false;
            CameraSwitchImage = _cameraSwitchImage;
            VidyoLogoImage = _vidyoLogoImage;
            GearImage = _gearImage;
            _tokenGenerator = new TokenGenerator("1d5e6027ba264867a681984412ab2900", "101b49.vidyo.io", DisplayName, 5000);
            _token = _tokenGenerator.GenerateToken();
            Token = _token;
        }

        public event PropertyChangedEventHandler PropertyChanged;

#if WINDOWS_WPF
        const string _cameraOnImage      = @"Assets\camera_on.png";
        const string _cameraOffImage     = @"Assets\camera_off.png";
        const string _microphoneOnImage  = @"Assets\microphone_on.png";
        const string _microphoneOffImage = @"Assets\microphone_off.png";
        const string _callStartImage     = @"Assets\call_start.png";
        const string _callEndImage       = @"Assets\call_end.png";
        static string _gearImage          = @"Assets\gear.png";
        static string _cameraSwitchImage  = @"Assets\camera_switch.png";
        static string _vidyoLogoImage     = @"Assets\vidyo_io.png";
#else
        const string _cameraOnImage = "camera_on.png";
        const string _cameraOffImage = "camera_off.png";
        const string _microphoneOnImage = "microphone_on.png";
        const string _microphoneOffImage = "microphone_off.png";
        const string _callStartImage = "call_start.png";
        const string _callEndImage = "call_end.png";
        const string _gearImage = "gear.png";
        static string _cameraSwitchImage = "camera_switch.png";
        static string _vidyoLogoImage = "vidyo_io.png";
#endif
        string _cameraPrivacyImage = _cameraOnImage;
        string _microphonePrivacyImage = _microphoneOnImage;
        string _callImage = _callStartImage;
        bool _cameraPrivacy = false;
        bool _microphonePrivacy = false;
        string _host = "prod.vidyo.io";
        string _token;
        string _displayName = "XamarinUser";
        string _resourceId = "DemoRoom";
        string _toolbarStatus = "Ready to Connect";
        string _clientVersion = "v 0.0.00.x";
        VidyoCallAction _callAction = VidyoCallAction.VidyoCallActionConnect;

        public bool ToggleCameraPrivacy()
        {
            _cameraPrivacy = !_cameraPrivacy;
            CameraPrivacyImage = _cameraPrivacy ? _cameraOffImage : _cameraOnImage;
            return _cameraPrivacy;
        }

        public bool ToggleMicrophonePrivacy()
        {
            _microphonePrivacy = !_microphonePrivacy;
            MicrophonePrivacyImage = _microphonePrivacy ? _microphoneOffImage : _microphoneOnImage;
            return _microphonePrivacy;
        }

        public VidyoCallAction ToggleCallAction()
        {
            CallAction = _callAction == VidyoCallAction.VidyoCallActionConnect ?
                          VidyoCallAction.VidyoCallActionDisconnect : VidyoCallAction.VidyoCallActionConnect;
            return _callAction;
        }

        public VidyoCallAction CallAction
        {
            set
            {
                _callAction = value;
                CallImage = _callAction == VidyoCallAction.VidyoCallActionConnect ? _callStartImage : _callEndImage;
            }
            get { return _callAction; }
        }

        public string Host
        {
            get { return _host; }
            set
            {
                if (_host != value)
                {
                    _host = value;
                    OnPropertyChanged("Host");
                }
            }
        }

        public string Token
        {
            get { return _token; }
            set
            {
                if (_token != value)
                {
                    _token = value;
                    OnPropertyChanged("Token");
                }
            }
        }

        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                    OnPropertyChanged("DisplayName");
                    _tokenGenerator.UserName = _displayName;
                    Token = _tokenGenerator.GenerateToken();
                }
            }
        }

        public string ResourceId
        {
            get { return _resourceId; }
            set
            {
                if (_resourceId != value)
                {
                    _resourceId = value;
                    OnPropertyChanged("ResourceId");
                }
            }
        }

        public string ToolbarStatus
        {
            get { return _toolbarStatus; }
            set
            {
                if (_toolbarStatus != value)
                {
                    _toolbarStatus = value;
                    OnPropertyChanged("ToolbarStatus");
                }
            }
        }

        public string ClientVersion
        {
            get { return _clientVersion; }
            set
            {
                if (_clientVersion != value)
                {
                    _clientVersion = value;
                    OnPropertyChanged("ClientVersion");
                }
            }
        }

        public string CallImage
        {
            get { return _callImage; }
            set
            {
                if (_callImage != value)
                {
                    _callImage = value;
                    OnPropertyChanged("CallImage");
                }
            }
        }

        public string CameraPrivacyImage
        {
            get { return _cameraPrivacyImage; }
            set
            {
                if (_cameraPrivacyImage != value)
                {
                    _cameraPrivacyImage = value;
                    OnPropertyChanged("CameraPrivacyImage");
                }
            }
        }

        public string CameraSwitchImage
        {
            get { return _cameraSwitchImage; }
            set
            {
                if (_cameraSwitchImage != value)
                {
                    _cameraSwitchImage = value;
                    OnPropertyChanged("CameraSwitchImage");
                }
            }
        }

        public string VidyoLogoImage
        {
            get { return _vidyoLogoImage; }
            set
            {
                if (_vidyoLogoImage != value)
                {
                    _vidyoLogoImage = value;
                    OnPropertyChanged("VidyoLogoImage");
                }
            }
        }

        public string GearImage
        {
            get { return _gearImage; }
            set
            {
                if (_gearImage != value)
                {
                    _gearImage = value;
                    OnPropertyChanged("GearImage");
                }
            }
        }

        public bool DisplayDiagnostics { get; set; }

        public string MicrophonePrivacyImage
        {
            get { return _microphonePrivacyImage; }
            set
            {
                if (_microphonePrivacyImage != value)
                {
                    _microphonePrivacyImage = value;
                    OnPropertyChanged("MicrophonePrivacyImage");
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}