using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rect = System.Drawing.Rectangle;

namespace RecordLib.Models
{
    public abstract class ScreenRecorderSetting
    {
        #region Public Properties

        public bool IsAduioEnable { get; set; }

        #region FullProperty AudioMode
        private AudioMode _audioMode = AudioMode.Speaker;

        public AudioMode AudioMode
        {
            get { return _audioMode; }
            set { _audioMode = value; }
        }
        #endregion	FullProperty AudioMode

        #region FullProperty ScreenCaptureMode
        private ScreenCaptureMode _screenCaptureMode;

        public ScreenCaptureMode ScreenCaptureMode
        {
            get { return _screenCaptureMode; }
            set { _screenCaptureMode = value; }
        }
        #endregion	FullProperty ScreenCaptureMode

        #region FullProperty CaptureRect
        private Rect _CaptureRect;

        public Rect CaptureRect
        {
            get { return _CaptureRect; }
            set { _CaptureRect = value; }
        }
        #endregion	FullProperty CaptureRect

        #region FullProperty ScreenIndex
        private int _screenIndex = 0;

        public int ScreenIndex
        {
            get { return _screenIndex; }
            set { _screenIndex = value; }
        }
        #endregion	FullProperty ScreenIndex

        #region FullProperty RecordQuality
        private RecordQuality _recordQuality = RecordQuality.Standard;

        public RecordQuality RecordQuality
        {
            get { return _recordQuality; }
            set { _recordQuality = value; }
        }
        #endregion	FullProperty RecordQuality


        #endregion Public Properties

        #region Public Members

        public abstract string SaveRecordFilePath { get; set; }

        public abstract VideoType SaveRecordFileType { get; set; }

        #endregion Public Members

    }
}
