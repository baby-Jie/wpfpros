using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainingBoard.Models
{
    public interface IPaintingBoard
    {
        /**
         * 切换模式
         */
        void SwitchPaintingMode(PaintingMode mode);

        /// <summary>
        /// 设置画笔的颜色
        /// </summary>
        /// <param name="colorStr"></param>
        void SetPenColor(string colorStr);

        /// <summary>
        /// 设置画笔粗细
        /// </summary>
        /// <param name="width"></param>
        void SetPenWidth(double width);

        /// <summary>
        /// 清除所有
        /// </summary>
        void ClearAll();
    }
}
