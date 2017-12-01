# VidyoConnector-xamarin

## Clone Repository
git clone https://github.com/Vidyo/VidyoConnector-xamarin.git

## Overview
VidyoConnector-xamarin is a Xamarin Forms cross platform application which contains three projects:
1. VidyoConnector         : Portable Class Library (PCL) containing shared code that can be used in Xamarin.iOS and Xamarin.Android (and more).
2. VidyoConnector.iOS     : iOS application which leverages the VidyoConnector PCL in building it's UI.
3. VidyoConnector.Android : Android application which leverages the VidyoConnector PCL in building it's UI.

## Acquire VidyoClient iOS and Android SDKs
1. Download the latest Vidyo.io iOS SDK package: https://static.vidyo.io/latest/package/VidyoClient-iOSSDK.zip
2. Move the unzipped VidyoClient-iOSSDK folder to the VidyoConnector-xamarin directory.
3. Download the latest Vidyo.io Android SDK package: https://static.vidyo.io/latest/package/VidyoClient-AndroidSDK.zip
4. Move the unzipped VidyoClient-AndroidSDK folder to the VidyoConnector-xamarin directory.

> Note: SDK version 4.1.18.8 or later is required

## Build and Run Application
1. Open VidyoConnector.sln in either Visual Studio or Xamarin Studio version 6.3 or later.
2. Set either VidyoConnector.iOS or VidyoConnector.Android as the Startup Project, depending on which type of device you want to load the application to.
3. Connect an iOS or Android device to the computer via USB.
4. Select the iOS or Android device as the build target of the application.
5. Build and run the application on the iOS or Android device.

