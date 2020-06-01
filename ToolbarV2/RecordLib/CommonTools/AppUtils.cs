using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecordLib.CommonTools
{
    public class AppUtils
    {
        public static Window Owner { get; set; }

        #region DriveInfo

        private static DriveInfo _recordDriveInfo;

        public static DriveInfo RecordDriveInfo
        {
            get
            {
                if (_recordDriveInfo == null)
                {
                    _recordDriveInfo = GetRecordDriveInfo();
                }
                return _recordDriveInfo;
            }
        }

        public static long RecordDriveInfoTotalFreeSpace
        {
            get
            {
                long totalFreeSapce = -1;
                var driveInfo = RecordDriveInfo;
                if (driveInfo != null)
                {
                    try
                    {
                        totalFreeSapce = driveInfo.TotalFreeSpace;
                    }
                    catch (Exception ex)
                    {
                        //Log.Write(ex);
                    }
                }
                return totalFreeSapce;
            }
        }

        private static DriveInfo GetRecordDriveInfo()
        {
            try
            {
                string recordPath = GetRecordVideoPath();
                string rootPath = Directory.GetDirectoryRoot(recordPath);
                DriveInfo[] allDirves = DriveInfo.GetDrives();
                var DriveInfos = from driveinfo in allDirves where driveinfo.DriveType == DriveType.Fixed && driveinfo.Name.Equals(rootPath, StringComparison.CurrentCultureIgnoreCase) select driveinfo;
                if (DriveInfos.Any())
                {
                    return DriveInfos.ElementAtOrDefault(0);
                }
            }
            catch (Exception ex)
            {
                //Log.Write(ex);
            }

            return null;
        }

        /// <summary>
        /// 检查
        /// </summary>
        public static bool CheckDisk()
        {
            if (RecordDriveInfo != null)
            {
                // 1.点击录课检测如果<300M：磁盘空间严重不足（还剩191M），无法进行录课！;
                long totalFreeSapce = RecordDriveInfoTotalFreeSpace;
                if (totalFreeSapce >= 0 && totalFreeSapce <= AppConstants.RECORD_CHECK_SIZE)
                {
                    System.Windows.MessageBox.Show(null, string.Format("磁盘空间严重不足（还剩{0}），无法进行录课！", FormatSizeString(totalFreeSapce)), "提示",
                        MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }

        #endregion DriveInfo

        /// <summary>
        /// 返回文件是否存在
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否存在</returns>
        public static bool FileExists(string filename)
        {
            return System.IO.File.Exists(filename);
        }

        public static void MoveFile(string sourceFileName, string destFileName)
        {
            System.IO.File.Move(sourceFileName, destFileName);
        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="FileName">文件名或含路径的文件名</param>
        /// <returns></returns>
        public static long GetFileSizeSafe(string FileName)
        {
            try
            {
                return GetFileSize(FileName);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="FileName">文件名或含路径的文件名</param>
        /// <returns></returns>
        public static long GetFileSize(string FileName)
        {
            return new System.IO.FileInfo(FileName).Length;
        }

        /// <summary>
        /// 获取录课存放的目录
        /// </summary>
        /// <returns></returns>
        public static string GetRecordVideoPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        /// <summary>
        /// 获取录课存放的路径 
        /// </summary>
        /// <returns></returns>
        public static string GetRecordVideoFilePath()
        {
            DateTime now = DateTime.Now;
            string foldPath = GetRecordVideoPath();
            return Path.Combine(foldPath, now.ToString("yyyyMMddHHmmss") + ".mp4");
        }

        public static string GetVideoFormatName()
        {
            return string.Format("微课-{0}.mp4", DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        }

        public static string FormatSizeString(long byteSize)
        {
            if (byteSize < 1024)
                return String.Format("{0}B", byteSize);
            else if (byteSize < 1048576)
                return String.Format("{0:0}KB", (double)byteSize / 1024);
            else if (byteSize < 1073741824)
                return String.Format("{0:0}MB", (double)byteSize / 1048576);
            else if (byteSize < 1099511627776)
                return String.Format("{0:0.0}GB", (double)byteSize / 1073741824);
            else
                return String.Format("{0:0.0}PB", (double)byteSize / 1099511627776);
        }
    }
}
