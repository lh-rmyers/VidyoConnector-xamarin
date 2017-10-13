using System;
using System.Collections.Generic;
using VidyoClient;

namespace VidyoConnector
{
	public class Testing : Connector.IRegisterRemoteCameraEventListener,
    Connector.IRegisterRemoteWindowShareEventListener, Connector.IRegisterNetworkInterfaceEventListener,

    Connector.IRegisterLocalWindowShareEventListener, Connector.IRegisterLocalMonitorEventListener,
    Connector.IConnect, Connector.IRegisterParticipantEventListener, Connector.IRegisterMessageEventListener, Connector.IRegisterLocalCameraEventListener, Connector.IRegisterLocalMicrophoneEventListener, Connector.IRegisterLocalSpeakerEventListener
    {

		IntPtr videoHandle = IntPtr.Zero;
		Connector _connector;
        public Testing()
        {

            ConnectorPKG.Initialize();

			_connector = new Connector(videoHandle,
						   Connector.ConnectorViewStyle.ConnectorviewstyleDefault,
						   15,
						   "info@VidyoClient info@VidyoConnector warning",
						   "",
						   0);
            _connector.ShowViewAt(videoHandle, 0, 0, 100, 100);
            _connector.Connect("","","","",this);

            _connector.RegisterParticipantEventListener(this);

			_connector.RegisterMessageEventListener(this);
			_connector.SendChatMessage("abc");

			_connector.CycleCamera();
			_connector.CycleMicrophone();
			_connector.CycleSpeaker();

			_connector.RegisterLocalCameraEventListener(this);
			_connector.RegisterLocalMicrophoneEventListener(this);
			_connector.RegisterLocalSpeakerEventListener(this);

			_connector.SelectDefaultCamera();
			_connector.SelectDefaultMicrophone();
			_connector.SelectDefaultSpeaker();

			_connector.RegisterLocalWindowShareEventListener(this);
			_connector.RegisterLocalMonitorEventListener(this);

			_connector.RegisterRemoteCameraEventListener(this);
			_connector.RegisterRemoteWindowShareEventListener(this);

            _connector.RegisterNetworkInterfaceEventListener(this);

			_connector.SelectDefaultNetworkInterfaceForSignaling();
			_connector.SelectDefaultNetworkInterfaceForMedia();
            _connector.SetCertificateAuthorityList("List as a string in PEM format");


        }

        public void OnChatMessageReceived(Participant participant, ChatMessage chatMessage)
        {
            throw new NotImplementedException();
        }

        public void OnDisconnected(Connector.ConnectorDisconnectReason reason)
        {
            throw new NotImplementedException();
        }

        public void OnDynamicParticipantChanged(List<Participant> participants, List<RemoteCamera> remoteCameras)
        {
            throw new NotImplementedException();
        }

        public void OnFailure(Connector.ConnectorFailReason reason)
        {
            throw new NotImplementedException();
        }

        public void OnLocalCameraAdded(LocalCamera localCamera)
        {
            throw new NotImplementedException();
        }

        public void OnLocalCameraRemoved(LocalCamera localCamera)
        {
            throw new NotImplementedException();
        }

        public void OnLocalCameraSelected(LocalCamera localCamera)
        {
            throw new NotImplementedException();
        }

        public void OnLocalCameraStateUpdated(LocalCamera localCamera, Device.DeviceState state)
        {
            throw new NotImplementedException();
        }

        public void OnLocalMicrophoneAdded(LocalMicrophone localMicrophone)
        {
            throw new NotImplementedException();
        }

        public void OnLocalMicrophoneRemoved(LocalMicrophone localMicrophone)
        {
            throw new NotImplementedException();
        }

        public void OnLocalMicrophoneSelected(LocalMicrophone localMicrophone)
        {
            throw new NotImplementedException();
        }

        public void OnLocalMicrophoneStateUpdated(LocalMicrophone localMicrophone, Device.DeviceState state)
        {
            throw new NotImplementedException();
        }

        public void OnLocalMonitorAdded(LocalMonitor localMonitor)
        {
            throw new NotImplementedException();
        }

        public void OnLocalMonitorRemoved(LocalMonitor localMonitor)
        {
            throw new NotImplementedException();
        }

        public void OnLocalMonitorSelected(LocalMonitor localMonitor)
        {
            throw new NotImplementedException();
        }

        public void OnLocalMonitorStateUpdated(LocalMonitor localMonitor, Device.DeviceState state)
        {
            throw new NotImplementedException();
        }

        public void OnLocalSpeakerAdded(LocalSpeaker localSpeaker)
        {
            throw new NotImplementedException();
        }

        public void OnLocalSpeakerRemoved(LocalSpeaker localSpeaker)
        {
            throw new NotImplementedException();
        }

        public void OnLocalSpeakerSelected(LocalSpeaker localSpeaker)
        {
            throw new NotImplementedException();
        }

        public void OnLocalSpeakerStateUpdated(LocalSpeaker localSpeaker, Device.DeviceState state)
        {
            throw new NotImplementedException();
        }

        public void OnLocalWindowShareAdded(LocalWindowShare localWindowShare)
        {
            throw new NotImplementedException();
        }

        public void OnLocalWindowShareRemoved(LocalWindowShare localWindowShare)
        {
            throw new NotImplementedException();
        }

        public void OnLocalWindowShareSelected(LocalWindowShare localWindowShare)
        {
            throw new NotImplementedException();
        }

        public void OnLocalWindowShareStateUpdated(LocalWindowShare localWindowShare, Device.DeviceState state)
        {
            throw new NotImplementedException();
        }

        public void OnLoudestParticipantChanged(Participant participant, bool audioOnly)
        {
            throw new NotImplementedException();
        }

        public void OnNetworkInterfaceAdded(NetworkInterface networkInterface)
        {
            _connector.SelectNetworkInterfaceForSignaling(networkInterface);
			_connector.SelectNetworkInterfaceForMedia(networkInterface); 
        }

        public void OnNetworkInterfaceRemoved(NetworkInterface networkInterface)
        {
            throw new NotImplementedException();
        }

        public void OnNetworkInterfaceSelected(NetworkInterface networkInterface, NetworkInterface.NetworkInterfaceTransportType transportType)
        {
            throw new NotImplementedException();
        }

        public void OnNetworkInterfaceStateUpdated(NetworkInterface networkInterface, NetworkInterface.NetworkInterfaceState state)
        {
            throw new NotImplementedException();
        }

        public void OnParticipantJoined(Participant participant)
        {
            throw new NotImplementedException();
        }

        public void OnParticipantLeft(Participant participant)
        {
            throw new NotImplementedException();
        }

        public void OnRemoteCameraAdded(RemoteCamera remoteCamera, Participant participant)
        {
            throw new NotImplementedException();
        }

        public void OnRemoteCameraRemoved(RemoteCamera remoteCamera, Participant participant)
        {
            throw new NotImplementedException();
        }

        public void OnRemoteCameraStateUpdated(RemoteCamera remoteCamera, Participant participant, Device.DeviceState state)
        {
            throw new NotImplementedException();
        }

        public void OnRemoteWindowShareAdded(RemoteWindowShare remoteWindowShare, Participant participant)
        {
            _connector.AssignViewToRemoteWindowShare(videoHandle, remoteWindowShare, true, true);
			_connector.ShowViewAt(videoHandle, 0, 0, 100, 100);
        }

        public void OnRemoteWindowShareRemoved(RemoteWindowShare remoteWindowShare, Participant participant)
        {
            throw new NotImplementedException();
        }

        public void OnRemoteWindowShareStateUpdated(RemoteWindowShare remoteWindowShare, Participant participant, Device.DeviceState state)
        {
            throw new NotImplementedException();
        }

        public void OnSuccess()
        {
            throw new NotImplementedException();
        }
    }
}
