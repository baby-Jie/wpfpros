using RecordLib.CommonTools;
using RecordLib.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace RecordLib.Views
{
    /// <summary>
    /// RecordSaveWin.xaml 的交互逻辑
    /// </summary>
    public partial class RecordSaveWin : Window
    {
        #region  Fields

        //private MainWindow RecorderHelper;

        #endregion Fields

        #region Properties
        #endregion Properties

        #region Events
        #endregion Events

        #region Constructors

        public RecordSaveWin()
        {
            InitializeComponent();

            SourceInitialized += (sender, args) =>
            {
                WindowHiddenFromTabHelper.HiddenWindowFromTab(this);
            };
        }

        #endregion Constructors

        #region Methods
        #region Private Methods

        private static MethodResult SaveRecordFile(string microCourseName)
        {
            MethodResult mr = new MethodResult();
            mr.Status = 0;
            mr.Message = "sucess";

            string recordFullFileName = RecorderHelper.GetRecordFilePath();
            if (string.IsNullOrWhiteSpace(recordFullFileName))
            {
                mr.Status = 2;
                mr.Message = "recordFullFileName is empty";
                return mr;
            }

            if (!AppUtils.FileExists(recordFullFileName))
            {
                mr.Status = 3;
                mr.Message = string.Format("{0} is not exist", recordFullFileName);
                return mr;
            }

            try
            {
                string recordVideoPath = AppUtils.GetRecordVideoPath();

                AppUtils.MoveFile(recordFullFileName, System.IO.Path.Combine(recordVideoPath, RecorderHelper.StartRecordTime.ToString("微课-yyyyMMddHHmmss") + ".mp4"));
            }
            catch (Exception ex)
            {
                mr.Status = 99;
                mr.Message = ex.ToString();
                //Log.Write(ex);
            }
            finally
            {
            }

            return mr;
        }

        private void CloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private static void DeleteRecordFile()
        {
            string recordFilePath = RecorderHelper.GetRecordFilePath();
            if (!string.IsNullOrWhiteSpace(recordFilePath))
            {
                if (System.IO.File.Exists(recordFilePath))
                {
                    System.IO.File.Delete(recordFilePath);
                }
            }
        }

        #endregion Private Methods	

        #region Public Methods
        #endregion Public Methods
        #endregion Methods

        #region EventHandlers

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OkBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string microCourseName = SaveFileNameTbox.Text;

            SaveRecordFile(microCourseName);
            DeleteRecordFile();

            this.Close();
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DeleteRecordFile();

            this.Close();
        }

        public static void SaveRecordAndDeleteFile(string microCourseName)
        {
            SaveRecordFile(microCourseName);
            DeleteRecordFile();
        }

        public void SaveRecordAndDeleteFile()
        {
            string microCourseName = SaveFileNameTbox.Text;
            SaveRecordAndDeleteFile(microCourseName);
        }

        #endregion EventHandlers
    }
}
