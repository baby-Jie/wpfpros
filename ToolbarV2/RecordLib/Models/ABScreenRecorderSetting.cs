using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordLib.Models
{
    public class ABScreenRecorderSetting : ScreenRecorderSetting
    {
        protected string _saveRecordFilePath = string.Empty;

        #region Override

        public override string SaveRecordFilePath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_saveRecordFilePath))
                {
                    _saveRecordFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), DateTime.Now.ToString("yyyyMMddHHmmss") + ".mp4");
                }

                return _saveRecordFilePath;
            }
            set { _saveRecordFilePath = value; }
        }

        public override VideoType SaveRecordFileType { get; set; }

        #endregion Override

        #region Private Methods

        private string GetMaxFreeSizeDrive()
        {
            DriveInfo[] allDirves = DriveInfo.GetDrives();

            var DriveInfos = from driveinfo in allDirves where driveinfo.DriveType == DriveType.Fixed select driveinfo;
            DriveInfos = DriveInfos.OrderByDescending(new Func<DriveInfo, long>(CompareDriveSize));


            var driveinfo2 = DriveInfos.ElementAtOrDefault(0);
            return driveinfo2.Name;
        }

        private long CompareDriveSize(DriveInfo driveInfo)
        {
            return driveInfo.TotalFreeSpace;
        }

        #endregion Private Methods
    }
}
