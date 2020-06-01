using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ZFTqgv
{

    //[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    //public class LOGFONT
    //{
    //    public int lfHeight;
    //    public int lfWidth;
    //    public int lfEscapement;
    //    public int lfOrientation;
    //    public int lfWeight;
    //    public byte lfItalic;
    //    public byte lfUnderline;
    //    public byte lfStrikeOut;
    //    public byte lfCharSet;
    //    public byte lfOutPrecision;
    //    public byte lfClipPrecision;
    //    public byte lfQuality;
    //    public byte lfPitchAndFamily;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
    //    public string lfFaceName;
    //}

    public class TFL
    {

        //public const int POSITION_TOP_LEFT =      0;
        //public const int POSITION_TOP =           1;
        //public const int POSITION_TOP_RIGHT =     2;
        //public const int POSITION_RIGHT =         3;
        //public const int POSITION_BOTTOM_RIGHT =  4;
        //public const int POSITION_BOTTOM =        5;
        //public const int POSITION_BOTTOM_LEFT =   6;
        //public const int POSITION_LEFT =          7;
        //public const int POSITION_CENTER =        8;

        //public const int WEBCAM_VIEW_PADDING =    0;
        //public const int WEBCAM_VIEW_CROPPING =   1;
        //public const int WEBCAM_VIEW_STRETCHING = 2;

        private const string DLL_NAME = "RecLib.dll";


        /// <summary>
        /// ScnLib_About
        /// </summary>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_Ccqvv();

        /// <summary>
        /// ScnLib_SetLicenseW
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern bool TeoNjd_UfvMkdgoufY(string Name, string Email, string Key);

        /// <summary>
        /// ScnLib_GetErrorMessageW
        /// </summary>
        /// <param name="ErrMsg"></param>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern void TeoNjd_IfvFtsqsOfutchgX(StringBuilder ErrMsg); // ErrMsg >= 2048 Chars

        /// <summary>
        /// ScnLib_CheckComponents
        /// </summary>
        /// <returns></returns>
	    [DllImport(DLL_NAME)] public static extern bool TeoNjd_EigdmDqnrppfpuu();

        /// <summary>
        /// ScnLib_Initialize
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_Kokukbnjzf();

        /// <summary>
        /// ScnLib_Uninitialize
        /// </summary>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_Wokokukbnjzf();

        /// <summary>
        /// ScnLib_LoadSettingsW
        /// </summary>
        /// <param name="RegKey"></param>
        /// <param name="SubKey"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern bool TeoNjd_NpceUfvukoitY(IntPtr RegKey, string SubKey);

        /// <summary>
        /// ScnLib_SaveSettingsW
        /// </summary>
        /// <param name="RegKey"></param>
        /// <param name="SubKey"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern bool TeoNjd_UbxfUfvukoitY(IntPtr RegKey, string SubKey);

        /// <summary>
        /// ScnLib_DeleteSettingsW
        /// </summary>
        /// <param name="RegKey"></param>
        /// <param name="SubKey"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern bool TeoNjd_FfnfvfUfvukoitY(IntPtr RegKey, string SubKey);

        /// <summary>
        /// ScnLib_ConfigureSettings
        /// </summary>
        /// <param name="ParentWnd"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_EppgkhwsgTguvjphu(IntPtr ParentWnd);

        /// <summary>
        /// ScnLib_SetVideoPathW
        /// </summary>
        /// <param name="Path"></param>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern void TeoNjd_UfvWkegpRbviY(string Path);

        /// <summary>
        /// ScnLib_GetVideoPathW
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Saved"></param>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern void TeoNjd_IfvWkegpRbviY(StringBuilder Path, bool Saved); // Path >= 260 Chars

        /// <summary>
        /// ScnLib_SetAudioPathW
        /// </summary>
        /// <param name="Path"></param>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern void TeoNjd_UfvBwekpRbviY(string Path);

        /// <summary>
        /// ScnLib_GetAudioPathW
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Saved"></param>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern void TeoNjd_IfvBwekpRbviY(StringBuilder Path, bool Saved); // Path >= 260 Chars

        /// <summary>
        /// ScnLib_SetStreamingUrlW
        /// </summary>
        /// <param name="URL"></param>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern void TeoNjd_UfvTvsgbojphWsnX(string URL);

        /// <summary>
        /// ScnLib_GetStreamingUrlW
        /// </summary>
        /// <param name="URL"></param>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern void TeoNjd_IfvTvsgbojphWsnX(StringBuilder URL); // URL >= 2048 Chars

        /// <summary>
        /// ScnLib_TakeScreenshotW
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern bool TeoNjd_VbmfUdtfgouiquY(StringBuilder Path, int left, int top, int right, int bottom); // Path >= 260 Chars

        /// <summary>
        /// ScnLib_SetCaptureRegion
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvDcqvvtfTfijqo(int left, int top, int right, int bottom);

        /// <summary>
        /// ScnLib_GetCaptureRegion
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_IfvDcqvvtfTfijqo(ref int left, ref int top, ref int right, ref int bottom);

        /// <summary>
        /// ScnLib_SelectCaptureRegion
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_UfnfeuEbruwsgSghkpp(ref int left, ref int top, ref int right, ref int bottom);

        /// <summary>
        /// ScnLib_ShowCaptureRegionFrame
        /// </summary>
        /// <param name="Enable"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UiqxEbruwsgSghkppGtbof(bool Enable);

        /// <summary>
        /// ScnLib_GetCaptureRegionFrameWnd
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern IntPtr TeoNjd_IfvDcqvvtfTfijqoHscngXpe();

        /// <summary>
        /// ScnLib_EnableGPUAcceleration
        /// </summary>
        /// <param name="Enable"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_GoccnfIQWBedgmgscukpp(bool Enable);

        /// <summary>
        /// ScnLib_IsGPUAccelerationEnabled
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_KtIQWBedgmgscukppFpbdmge();

        /// <summary>
        /// ScnLib_ShowCountdownBox
        /// </summary>
        /// <param name="Seconds"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_UiqxEpwoveqxpCqy(int Seconds);

        /// <summary>
        /// ScnLib_StartRecording
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_UucsvSgdqsfjph();

        /// <summary>
        /// ScnLib_PauseRecording
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_RbwtgSgdqsfjph();

        /// <summary>
        /// ScnLib_ResumeRecording
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_TfuvofTfeptekoi();

        /// <summary>
        /// ScnLib_StopRecording
        /// </summary>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UuqqTfeptekoi();

        /// <summary>
        /// ScnLib_IsRecording
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_KtTfeptekoi();

        /// <summary>
        /// ScnLib_IsPaused
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_KtRbwtge();

        /// <summary>
        /// ScnLib_GetRecTime
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern uint TeoNjd_IfvSgdVjof();

        /// <summary>
        /// ScnLib_GetRecTimeW
        /// </summary>
        /// <param name="Time"></param>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern void TeoNjd_IfvSgdVjofY(StringBuilder Time); // Time >= 11 Chars

        /// <summary>
        /// ScnLib_ZoomInScreen
        /// </summary>
        /// <param name="Ratio"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_ZpqnKoUdtfgo(double Ratio);

        /// <summary>
        /// ScnLib_GetZoomRatio
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern double TeoNjd_IfvZqpoScukp();

        /// <summary>
        /// ScnLib_SetZoomSpeed
        /// </summary>
        /// <param name="Speed"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvZqpoTrfge(double Speed);

        /// <summary>
        /// ScnLib_GetZoomSpeed
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern double TeoNjd_IfvZqpoTrfge();

        /// <summary>
        /// ScnLib_PreviewVideo
        /// </summary>
        /// <param name="Enable"></param>
        /// <param name="Wnd"></param>
        /// <param name="Padding"></param>
        /// <param name="BkColor"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_RsgwkfyWkegp(bool a, IntPtr b, bool c, uint d);

        /// <summary>
        /// ScnLib_GetVideoPreviewWnd
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern IntPtr TeoNjd_IfvWkegpRsgwkfyXpe();

        /// <summary>
        /// ScnLib_SetVideoResolution
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvWkegpTfupnvvjqo(int Width, int Height);

        /// <summary>
        /// ScnLib_GetVideoResolution
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_IfvWkegpTfupnvvjqo(ref int Width, ref int Height);

        /// <summary>
        /// ScnLib_SetVideoFrameRate
        /// </summary>
        /// <param name="FPS"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvWkegpHscngScug(double FPS);

        /// <summary>
        /// ScnLib_GetVideoFrameRate
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern double TeoNjd_IfvWkegpHscngScug();

        /// <summary>
        /// ScnLib_SetVideoKeyFrameInterval
        /// </summary>
        /// <param name="Seconds"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvWkegpMfyGtbofKovftwcm(double Seconds);

        /// <summary>
        /// ScnLib_GetVideoKeyFrameInterval
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern double TeoNjd_IfvWkegpMfyGtbofKovftwcm();

        /// <summary>
        /// ScnLib_EnableVideoVariableFrameRate
        /// </summary>
        /// <param name="Enable"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_GoccnfXjffqWcskbdmgGtbofTbvf(bool Enable);

        /// <summary>
        /// ScnLib_IsVideoVariableFrameRateEnabled
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_KtXjffqWcskbdmgGtbofTbvfGoccnff();

        /// <summary>
        /// ScnLib_ConfigureVideoCodec
        /// </summary>
        /// <param name="ParentWnd"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_EppgkhwsgWkegpEpffe(IntPtr ParentWnd);

        /// <summary>
        /// ScnLib_SetVideoCodecExtraArgsW
        /// </summary>
        /// <param name="Args"></param>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern void TeoNjd_UfvWkegpEpffeFzutbCsitY(string Args);

        /// <summary>
        /// ScnLib_GetVideoCodecExtraArgsW
        /// </summary>
        /// <param name="Args"></param>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern void TeoNjd_IfvWkegpEpffeFzutbCsitY(StringBuilder Args); // Args >= 1024 Chars

        /// <summary>
        /// ScnLib_SetVideoQuality
        /// </summary>
        /// <param name="CRF"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvWkegpSvcmkuy(int CRF);

        /// <summary>
        /// ScnLib_GetVideoQuality
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern int TeoNjd_IfvWkegpSvcmkuy();

        /// <summary>
        /// ScnLib_SetVideoBitrate
        /// </summary>
        /// <param name="Kbps"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvWkegpDjvscug(int Kbps);

        /// <summary>
        /// ScnLib_GetVideoBitrate
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern int TeoNjd_IfvWkegpDjvscug();

        /// <summary>
        /// ScnLib_SetAudioBitrate
        /// </summary>
        /// <param name="Kbps"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvBwekpDjvscug(int Kbps);

        /// <summary>
        /// ScnLib_GetAudioBitrate
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern int TeoNjd_IfvBwekpDjvscug();

        /// <summary>
        /// ScnLib_SetStreamingBitrate
        /// </summary>
        /// <param name="Kbps"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvTvsgbojphDjvscug(int Kbps);

        /// <summary>
        /// ScnLib_GetStreamingBitrate
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern int TeoNjd_IfvTvsgbojphDjvscug();

        /// <summary>
        /// ScnLib_GetAudioSourceDeviceCount
        /// </summary>
        /// <param name="Playback"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern int TeoNjd_IfvBwekpUpwsefFfxjefEpwov(bool Playback);

        /// <summary>
        /// ScnLib_GetAudioSourceDeviceW
        /// </summary>
        /// <param name="Playback"></param>
        /// <param name="Index"></param>
        /// <param name="Device"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern bool TeoNjd_IfvBwekpUpwsefFfxjefY(bool Playback, int Index, StringBuilder Device); // Device >= 260 Chars

        /// <summary>
        /// ScnLib_SelectAudioSourceDevice
        /// </summary>
        /// <param name="Playback"></param>
        /// <param name="Index"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfnfeuCvfjqTqvtdgEgwkdg(bool Playback, int Index);

        /// <summary>
        /// ScnLib_GetSelectedAudioSourceDevice
        /// </summary>
        /// <param name="Playback"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern int TeoNjd_IfvTgmgdvffBwekpUpwsefFfxjef(bool Playback);

        /// <summary>
        /// ScnLib_ConfigureAudioSourceDevices
        /// </summary>
        /// <param name="Playback"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_EppgkhwsgBwekpUpwsefFfxjefu(bool Playback);

        /// <summary>
        /// ScnLib_RecordAudioSource
        /// </summary>
        /// <param name="Playback"></param>
        /// <param name="Enable"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_TfepteCvfjqTqvtdg(bool Playback, bool Enable);

        /// <summary>
        /// ScnLib_IsRecordAudioSource
        /// </summary>
        /// <param name="Playback"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_KtTfepteCvfjqTqvtdg(bool Playback);

        /// <summary>
        /// ScnLib_SetAudioSourceVolume
        /// </summary>
        /// <param name="Playback"></param>
        /// <param name="Volume"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvBwekpUpwsefXpnvof(bool Playback, int Volume);

        /// <summary>
        /// ScnLib_GetAudioSourceVolume
        /// </summary>
        /// <param name="Playback"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern int TeoNjd_IfvBwekpUpwsefXpnvof(bool Playback);

        /// <summary>
        /// ScnLib_MonitorVolumeLevel
        /// </summary>
        /// <param name="Enable"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_OppjvptWqmwngMgwgm(bool Enable);

        /// <summary>
        /// ScnLib_IsMonitoringVolumeLevel
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_KtOppjvptjphXpnvofNfxfn();

        /// <summary>
        /// ScnLib_GetAudioSourceVolumeLevel
        /// </summary>
        /// <param name="Playback"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern int TeoNjd_IfvBwekpUpwsefXpnvofNfxfn(bool Playback);

        /// <summary>
        /// ScnLib_SetMicrophoneDelay
        /// </summary>
        /// <param name="Milliseconds"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvNkdtpriqogEgmcz(int Milliseconds);

        /// <summary>
        /// ScnLib_GetMicrophoneDelay
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern int TeoNjd_IfvNkdtpriqogEgmcz();

        /// <summary>
        /// ScnLib_GetWebcamDeviceCount
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern int TeoNjd_IfvXgceboEgwkdgDqvpu();

        /// <summary>
        /// ScnLib_GetWebcamDeviceW
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Device"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern bool TeoNjd_IfvXgceboEgwkdgX(int Index, StringBuilder Device); // Device >= 260 Chars

        /// <summary>
        /// ScnLib_SelectWebcamDevice
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_UfnfeuYfddcnFfxjef(int Index);

        /// <summary>
        /// ScnLib_GetSelectedWebcamDevice
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern int TeoNjd_IfvTgmgdvffXgceboEgwkdg();

        /// <summary>
        /// ScnLib_PreviewWebcam
        /// </summary>
        /// <param name="Enable"></param>
        /// <param name="Wnd"></param>
        /// <param name="Padding"></param>
        /// <param name="BkColor"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_RsgwkfyXgcebo(bool a, IntPtr b, bool c, uint d);

        /// <summary>
        /// ScnLib_GetWebcamPreviewWnd
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern IntPtr TeoNjd_IfvXgceboQtfxjgxYof();

        /// <summary>
        /// ScnLib_RecordWebcamOnly
        /// </summary>
        /// <param name="Enable"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_TfepteYfddcnQonz(bool Enable);

        /// <summary>
        /// ScnLib_IsRecordWebcamOnly
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_KtTfepteYfddcnQonz();

        /// <summary>
        /// ScnLib_InputWebcamFrame
        /// </summary>
        /// <param name="RGB"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="BitCount"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_KorvvXgceboGtbof(IntPtr a, int b, int c, int d);

        /// <summary>
        /// ScnLib_SetWebcamResolution
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvXgceboSgtqmwukpp(int Width, int Height);

        /// <summary>
        /// ScnLib_GetWebcamResolution
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_IfvXgceboSgtqmwukpp(ref int Width, ref int Height);

        /// <summary>
        /// ScnLib_SetWebcamDirection
        /// </summary>
        /// <param name="Mirroring"></param>
        /// <param name="Flipping"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvXgceboEksgdvjqo(bool a, bool b);

        /// <summary>
        /// ScnLib_GetWebcamDirection
        /// </summary>
        /// <param name="Mirroring"></param>
        /// <param name="Flipping"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_IfvXgceboEksgdvjqo(ref bool a, ref bool b);

        /// <summary>
        /// ScnLib_SetWebcamViewMode
        /// </summary>
        /// <param name="ViewMode"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvXgceboWkfyNqeg(int ViewMode);

        /// <summary>
        /// ScnLib_GetWebcamViewMode
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern int TeoNjd_IfvXgceboWkfyNqeg();

        /// <summary>
        /// ScnLib_SetWebcamPosition
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="MarginX"></param>
        /// <param name="MarginY"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvXgceboQqtkukpp(int a, int b, int c);

        /// <summary>
        /// ScnLib_GetWebcamPosition
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="MarginX"></param>
        /// <param name="MarginY"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_IfvXgceboQqtkukpp(ref int a, ref int b, ref int c);

        /// <summary>
        /// ScnLib_SetWebcamViewSize
        /// </summary>
        /// <param name="ViewWidth"></param>
        /// <param name="ViewHeight"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvXgceboWkfyTkzg(int ViewWidth, int ViewHeight);

        /// <summary>
        /// ScnLib_GetWebcamViewSize
        /// </summary>
        /// <param name="ViewWidth"></param>
        /// <param name="ViewHeight"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_IfvXgceboWkfyTkzg(ref int ViewWidth, ref int ViewHeight);

        /// <summary>
        /// ScnLib_IsLogoVisible
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_KtNpipXjujdmg();

        /// <summary>
        /// ScnLib_SetLogoImageW
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern bool TeoNjd_UfvMqhqJobifY(string Path);

        /// <summary>
        /// ScnLib_GetLogoImageW
        /// </summary>
        /// <param name="Path"></param>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern void TeoNjd_IfvMqhqJobifY(StringBuilder Path); // Path >= 260 Chars

        /// <summary>
        /// ScnLib_UpdateLogoImage
        /// </summary>
        /// <param name="RGB"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="BitCount"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_WqfbvfNpipKnchg(IntPtr a, int b, int c, int d);

        /// <summary>
        /// ScnLib_SetLogoTextW
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Color"></param>
        /// <param name="Shadow"></param>
        /// <returns></returns>
        //[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern bool TeoNjd_UfvMqhqUgyvX(string Text, [MarshalAs(UnmanagedType.LPStruct)]LOGFONT Font, uint Color, bool Shadow);

        /// <summary>
        /// ScnLib_GetLogoTextW
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Color"></param>
        /// <param name="Shadow"></param>
        //[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern void TeoNjd_IfvMqhqUgyvX(StringBuilder Text, [MarshalAs(UnmanagedType.LPStruct)]LOGFONT Font, ref uint Color, ref bool Shadow); // Text >= 1024 Chars

        /// <summary>
        /// ScnLib_SetLogoPosition
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="MarginX"></param>
        /// <param name="MarginY"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvMqhqQqtkukpp(int a, int b, int c);

        /// <summary>
        /// ScnLib_GetLogoPosition
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="MarginX"></param>
        /// <param name="MarginY"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_IfvMqhqQqtkukpp(ref int a, ref int b, ref int c);

        /// <summary>
        /// ScnLib_SetLogoOpacity
        /// </summary>
        /// <param name="Opacity"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvMqhqPrbejvz(double Opacity);

        /// <summary>
        /// ScnLib_GetLogoOpacity
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern double TeoNjd_IfvMqhqPrbejvz();

        /// <summary>
        /// ScnLib_RecordCursor
        /// </summary>
        /// <param name="Enable"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_TfepteEvttqs(bool Enable);

        /// <summary>
        /// ScnLib_IsRecordCursor
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_KtTfepteEvttqs();

        /// <summary>
        /// ScnLib_SetCursorOriginalSize
        /// </summary>
        /// <param name="Enable"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvDwsuptPtjijpbnTkzg(bool Enable);

        /// <summary>
        /// ScnLib_IsCursorOriginalSize
        /// </summary>
        /// <returns></returns>
		[DllImport(DLL_NAME)] public static extern bool TeoNjd_KtEvttqsQskhkocmUjzf();

        /// <summary>
        /// ScnLib_AddCursorEffects
        /// </summary>
        /// <param name="Highlight"></param>
        /// <param name="ClickEffects"></param>
        /// <param name="Track"></param>
        /// <param name="ClickSound"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_CefDwsuptFhggdvt(bool a, bool b, bool c, bool d);

        /// <summary>
        /// ScnLib_GetCursorEffects
        /// </summary>
        /// <param name="Highlight"></param>
        /// <param name="ClickEffects"></param>
        /// <param name="Track"></param>
        /// <param name="ClickSound"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_IfvDwsuptFhggdvt(ref bool a, ref bool b, ref bool c, ref bool d);

        /// <summary>
        /// ScnLib_SetCursorEffectsColors
        /// </summary>
        /// <param name="HighlightColor"></param>
        /// <param name="LeftClickColor"></param>
        /// <param name="RightClickColor"></param>
        /// <param name="TrackColor"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_UfvDwsuptFhggdvtEpnptt(uint a, uint b, uint c, uint d);

        /// <summary>
        /// ScnLib_GetCursorEffectsColors
        /// </summary>
        /// <param name="HighlightColor"></param>
        /// <param name="LeftClickColor"></param>
        /// <param name="RightClickColor"></param>
        /// <param name="TrackColor"></param>
		[DllImport(DLL_NAME)] public static extern void TeoNjd_IfvDwsuptFhggdvtEpnptt(ref uint a, ref uint b, ref uint c, ref uint d);

        /// <summary>
        /// ScnLib_AddMP4BookmarkW
        /// </summary>
        /// <param name="Bookmark"></param>
        /// <returns></returns>
		[DllImport(DLL_NAME, CharSet = CharSet.Unicode)] public static extern bool TeoNjd_CefNR5DpqlobtlY(string Bookmark);  // Bookmark <= 1023 Chars

    }
}
