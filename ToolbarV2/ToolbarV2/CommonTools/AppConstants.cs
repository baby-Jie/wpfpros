using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolbarV2.CommonTools
{
    public class AppConstants
    {

        public const double PEN_WIDTH_SLIM = 3;
        public const double PEN_WIDTH_MIDDLE = 5;
        public const double PEN_WIDTH_THICK = 7;

        #region Global Toolbar Message

        public const string MSG_GLOBAL_SETPENCOLOR = "MSG_GLOBAL_SETPENCOLOR"; // 新全局工具栏 设置画笔颜色

        public const string MSG_GLOBAL_SETPENWIDTH = "MSG_GLOBAL_SETPENWIDTH"; // 设置画笔粗细

        public const string MSG_GLOBAL_SETERASERWIDTH = "MSG_GLOBAL_SETERASERWIDTH"; // 设置橡皮擦粗细

        public const string MSG_GLOBAL_WORKBENCHPAGECHANGED = "MSG_GLOBAL_WORKBENCHPAGECHANGED"; // 批注或者白板 页信息发生变化

        public const string MSG_GLOBAL_GETPENSETTINGS = "MSG_GLOBAL_GETPENSETTINGS"; // 获取画笔设置信息

        public const string MSG_GLOBAL_GETERASERSETTINGS = "MSG_GLOBAL_GETERASERSETTINGS"; // 获取橡皮擦设置信息

        public const string MSG_GLOBAL_SWITCHPENMODE = "MSG_GLOBAL_SWITCHPENMODE"; // 画板 切换画笔模式

        public const string MSG_GLOBAL_SWITCHERASERMODE = "MSG_GLOBAL_SWITCHERASERMODE"; // 画板 切换成橡皮擦模式

        public const string MSG_GLOBAL_RECORDSTATECHANGED = "MSG_GLOBAL_RECORDSTATECHANGED"; // 录屏状态发生变化

        public const string MSG_GLOBAL_POPUPSETPARENT = "MSG_GLOBAL_POPUPSETPARENT"; // 弹窗设置父窗口

        public const string MSG_GLOBAL_WORKBENCHEXIT = "MSG_GLOBAL_WORKBENCHEXIT"; // 批注或者白板 退出

        public const string MSG_GLOBAL_UNDO = "MSG_GLOBAL_UNDO"; // 撤销

        #endregion Global Toolbar Message	
    }
}
