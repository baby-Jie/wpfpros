﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ToolbarV2.ViewModels
{
    public class GlobalToolbarViewModel : ViewModelBase
    {
        #region Constructors

        public GlobalToolbarViewModel()
        {
            Initial();
        }

        #endregion Constructors

        #region Properties

        #region Full Properties

        #endregion Full Properties

        #region MVVMProperties

        #region MVVMProperty IsWhiteBoardMode 是否是白板模式

        private bool _isWhiteBoardMode;

        public bool IsWhiteBoardMode
        {
            get { return _isWhiteBoardMode; }
            set { Set(ref _isWhiteBoardMode, value); }
        }

        #endregion	MVVMProperty IsWhiteBoardMode

        #region MVVMProperty IsExpandSubMenu 子菜单是否显示

        private bool _isExpandSubMenu;

        public bool IsExpandSubMenu
        {
            get { return _isExpandSubMenu; }
            set { Set(ref _isExpandSubMenu, value); }
        }

        #endregion	MVVMProperty IsExpandSubMenu

        #region MVVMProperty IsCollapsed 是否收缩

        private bool _isCollapsed;

        public bool IsCollapsed
        {
            get { return _isCollapsed; }
            set { Set(ref _isCollapsed, value); }
        }

        #endregion	MVVMProperty IsCollapsed

        #region MVVMProperty DockPosition 全局工具栏的位置(左右上下，默认在下)

        #endregion	MVVMProperty DockPosition

        #region MVVMProperty IsPenSettingPopOpen 画笔设置弹出框是否显示

        private bool _isPenSettingPopOpen;

        public bool IsPenSettingPopOpen
        {
            get { return _isPenSettingPopOpen; }
            set { Set(ref _isPenSettingPopOpen, value); }
        }

        #endregion	MVVMProperty IsPenSettingPopOpen

        #region MVVMProperty IsEraserSettingPopOpen 橡皮设置弹出框是否显示

        private bool _isEraserSettingPopOpen;

        public bool IsEraserSettingPopOpen
        {
            get { return _isEraserSettingPopOpen; }
            set { Set(ref _isEraserSettingPopOpen, value); }
        }

        #endregion	MVVMProperty IsEraserSettingPopOpen

        #region MVVMProperty IsLessoning 是否正在上课

        private bool _isLessoning = true;

        public bool IsLessoning
        {
            get { return _isLessoning; }
            set { Set(ref _isLessoning, value); }
        }

        #endregion	MVVMProperty IsLessoning

        #endregion MVVMProperties

        #region CommandPropertes 

        #region CommandProperty SwitchCollapseCmd 展开和收起 工具栏

        private RelayCommand _switchCollapseCmd;

        public RelayCommand SwitchCollapseCmd
        {
            get
            {
                _switchCollapseCmd = _switchCollapseCmd ?? new RelayCommand(() => { IsCollapsed = !IsCollapsed; });
                return _switchCollapseCmd;
            }
        }

        #endregion

        #region CommandProperty ExpandSubMenuCmd 展开子菜单

        private RelayCommand _expandSubMenuCmd;

        public RelayCommand ExpandSubMenuCmd
        {
            get
            {
                return (_expandSubMenuCmd = _expandSubMenuCmd ?? new RelayCommand(() =>
                {
                    IsExpandSubMenu = !IsExpandSubMenu;
                }));
            }
        }

        #endregion

        #region CommandProperty ShowPenSettingPopCmd 展开 画笔设置 弹出框

        private RelayCommand _showPenSettingPopCmd;

        public RelayCommand ShowPenSettingPopCmd
        {
            get
            {
                return (_showPenSettingPopCmd = _showPenSettingPopCmd ?? new RelayCommand(() =>
                {
                    IsPenSettingPopOpen = !IsPenSettingPopOpen;
                }));
            }
        }

        #endregion

        #region CommandProperty ShowEraserSettingPopCmd 展开 橡皮擦设置 弹出框

        private RelayCommand _showEraserSettingPopCmd;

        public RelayCommand ShowEraserSettingPopCmd
        {
            get
            {
                return (_showEraserSettingPopCmd = _showEraserSettingPopCmd ?? new RelayCommand(() =>
                {
                    IsEraserSettingPopOpen = !IsEraserSettingPopOpen;
                }));
            }
        }

        #endregion


        #endregion CommandPropertes 

        #endregion Properties

        #region Methods

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initial()
        {
        }

        #endregion Methods

        #region EventHandlers

        #endregion EventHandlers
    }
}
