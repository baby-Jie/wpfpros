﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using ToolbarV2.Views;

namespace ToolbarV2.CommonTools
{
    public class AppUtils
    {

        private static PaintingBoardWin _paintingBoardWin;
        private static readonly object PaintBoardWinLock = new object();

        /// <summary>
        /// 采用懒汉式单例模式，获取透明画板窗口实例
        /// </summary>
        /// <returns></returns>
        public static PaintingBoardWin GetPaintingBoardWinInstance()
        {
            if (_paintingBoardWin == null)
            {
                lock (PaintBoardWinLock)
                {
                    if (_paintingBoardWin == null)
                    {
                        _paintingBoardWin = new PaintingBoardWin();
                    }
                }
            }

            return _paintingBoardWin;
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

        #region MVVMLight

        /// <summary>
        /// 发送事件消息和数据 泛型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="objectToken"></param>
        public static void SendMessage<T>(T message, string strToken)
        {
            Messenger.Default.Send(message, strToken);
        }

        /// <summary>
        /// 注册接收事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="token"></param>
        /// <param name="handler"></param>
        public static void RegisterEvents<T>(object recipient, string token, Action<T> handler)
        {
            Messenger.Default.Register(recipient, token, handler);
        }

        /// <summary>
        /// 注销事件
        /// </summary>
        /// <param name="recipient"></param>
        public static void UnRegisterEvents(object recipient)
        {
            Messenger.Default.Unregister(recipient);
        }

        #endregion MVVMLight
    }
}
