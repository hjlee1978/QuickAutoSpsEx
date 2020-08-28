using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FileInfoExtractor
{
    static public class ToolTipUtils
    {
        private static readonly Dictionary<string, ToolTip> ToolTipCollection = new Dictionary<string, ToolTip>();

        public static Color BackColor { get; set; } = SystemColors.Info;

        public static Color ForeColor { get; set; } = SystemColors.InfoText;

        public static Color BackColorWarning { get; set; } = Color.Orange;

        public static Color ForeColorWarning { get; set; } = Color.Black;

        public static Color BackColorError { get; set; } = Color.Red;

        public static Color ForeColorError { get; set; } = Color.Black;

        public static int ShowTime { get; set; } = 3000;

        public static int WarningShowTime { get; set; } = 3000;

        public static int ErrorShowTime { get; set; } = 3000;

        public static void LoadToolTips(ToolTip toolTip, Control.ControlCollection rootControl, System.Configuration.ApplicationSettingsBase target)
        {
            if (target != null)
            {
                //TODO: 사용자 설정 PropertyValues 생성
                if (target.PropertyValues.Count == 0)
                {
                    using (System.Windows.Forms.PropertyGrid pg = new PropertyGrid())
                    {
                        pg.SelectedObject = target;
                    }
                }

                foreach (System.Configuration.SettingsProperty p in target.Properties)
                {
                    string name = string.Copy(p.Name);
                    string value = string.Empty;
                    if (target.PropertyValues.Count > 0)
                    {
                        value = target.PropertyValues[name].PropertyValue.ToString();
                    }
                    else
                    {
                        value = p.DefaultValue.ToString();
                    }

                    if (rootControl != null)
                    {
                        foreach (Control control in rootControl)
                        {
                            if (LoadToolTips(toolTip, control, name, value))
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        public static bool LoadToolTips(ToolTip toolTip, Control control, string name, string value)
        {
            bool find = false;

            if ((toolTip != null) && (control != null))
            {
                if (control.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                {
                    toolTip.SetToolTip(control, value);
                    find = true;
                }
                else if (control is DataGridView grid)
                {
                    if (grid.Columns.Contains(name))
                    {
                        grid.Columns[name].ToolTipText = value;
                        find = true;
                    }
                }

                foreach (Control child in control.Controls)
                {
                    if (LoadToolTips(toolTip, child, name, value))
                    {
                        find = true;
                        break;
                    }
                }
            }

            return find;
        }

        public static bool LoadToolTips(ToolTip toolTip, Control control, string tips)
        {
            bool find = false;

            if ((toolTip != null) && (control != null) && (string.IsNullOrEmpty(tips) == false))
            {
                toolTip.SetToolTip(control, tips);
                find = true;
            }

            return find;
        }

        public static ToolTip GetToolTip(string key)
        {
            ToolTip toolTip = null;

            try
            {
                if (string.IsNullOrEmpty(key) == false)
                {
                    key = key.ToUpper();
                    if (ToolTipCollection.ContainsKey(key) == false)
                    {
                        ToolTipCollection[key] = new ToolTip();
                    }

                    toolTip = ToolTipCollection[key];
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                toolTip = null;
            }

            return toolTip;
        }

        public static void ShowToolTip(string key, string text, IWin32Window window, int delayMilliseconds, Color backColor, Color foreColor, ToolTipIcon toolTipIcon, string toolTipTitle)
        {
            try
            {
                ShowToolTip(GetToolTip(key), text, window, delayMilliseconds, backColor, foreColor, toolTipIcon, toolTipTitle);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public static void ShowToolTipInfo(string key, string text, IWin32Window window, int delayMilliseconds, Color backColor, Color foreColor)
        {
            try
            {
                ShowToolTip(GetToolTip(key), text, window, delayMilliseconds, backColor, foreColor, ToolTipIcon.Info, string.Empty);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public static void ShowToolTip(string key, string text, IWin32Window window, int delayMilliseconds, Color backColor, Color foreColor)
        {
            try
            {
                ShowToolTip(GetToolTip(key), text, window, delayMilliseconds, backColor, foreColor);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public static void ShowToolTip(string key, string text, IWin32Window window, int delayMilliseconds)
        {
            ShowToolTip(key, text, window, delayMilliseconds, BackColor, ForeColor);
        }

        public static void ShowToolTip(string key, string text, IWin32Window window)
        {
            ShowToolTip(key, text, window, ShowTime);
        }

        public static void ShowToolTip(string text, IWin32Window window, int delayMilliseconds, Color backColor, Color foreColor, ToolTipIcon toolTipIcon, string toolTipTitle)
        {
            if (window is Control control)
            {
                ShowToolTip(GetToolTip(control.Name), text, window, delayMilliseconds, backColor, foreColor, toolTipIcon, toolTipTitle);
            }
        }

        public static void ShowToolTip(string text, IWin32Window window, int delayMilliseconds, Color backColor, Color foreColor)
        {
            ShowToolTip(text, window, delayMilliseconds, backColor, foreColor, ToolTipIcon.None, string.Empty);
        }

        public static void ShowToolTip(string text, IWin32Window window, Color backColor, Color foreColor)
        {
            ShowToolTip(text, window, ShowTime, backColor, foreColor);
        }

        public static void ShowToolTipInfo(string text, IWin32Window window, int delayMilliseconds, Color backColor, Color foreColor)
        {
            ShowToolTip(text, window, delayMilliseconds, backColor, foreColor, ToolTipIcon.Info, string.Empty);
        }

        public static void ShowToolTipInfo(string text, IWin32Window window, Color backColor, Color foreColor)
        {
            ShowToolTipInfo(text, window, ShowTime, backColor, foreColor);
        }

        public static void ShowToolTip(string text, IWin32Window window, int delayMilliseconds)
        {
            ShowToolTip(text, window, delayMilliseconds, BackColor, ForeColor);
        }

        public static void ShowToolTip(string text, IWin32Window window)
        {
            ShowToolTip(text, window, ShowTime, BackColor, ForeColor);
        }

        public static void ShowToolTipWarning(string key, string text, IWin32Window window, int delayMilliseconds)
        {
            ShowToolTip(GetToolTip(key), text, window, delayMilliseconds, BackColorWarning, ForeColorWarning);
        }

        public static void ShowToolTipWarning(string key, string text, IWin32Window window)
        {
            ShowToolTipWarning(key, text, window, WarningShowTime);
        }

        public static void ShowToolTipWarning(string text, IWin32Window window, int delayMilliseconds)
        {
            if (window is Control control)
            {
                ShowToolTip(GetToolTip(control.Name), text, window, delayMilliseconds, BackColorWarning, ForeColorWarning);
            }
        }

        public static void ShowToolTipWarning(string text, IWin32Window window)
        {
            ShowToolTipWarning(text, window, WarningShowTime);
        }

        public static void ShowToolTipError(string key, string text, IWin32Window window, int delayMilliseconds)
        {
            ShowToolTip(GetToolTip(key), text, window, delayMilliseconds, BackColorError, ForeColorError);
        }

        public static void ShowToolTipError(string key, string text, IWin32Window window)
        {
            ShowToolTipError(key, text, window, ErrorShowTime);
        }

        public static void ShowToolTipError(string text, IWin32Window window, int delayMilliseconds)
        {
            if (window is Control control)
            {
                ShowToolTip(GetToolTip(control.Name), text, window, delayMilliseconds, BackColorError, ForeColorError);
            }
        }

        public static void ShowToolTipError(string text, IWin32Window window)
        {
            ShowToolTipError(text, window, ErrorShowTime);
        }

        /// <summary>
        /// 툴팁 전시
        /// </summary>
        /// <param name="toolTip">컨트롤</param>
        /// <param name="text">내용</param>
        /// <param name="window">전시 위치 기준 컨트롤</param>
        /// <param name="delayMilliseconds">전시 시간[ms]</param>
        /// <param name="backColor">배경색</param>
        /// <param name="foreColor">전경색</param>
        public static void ShowToolTip(ToolTip toolTip, string text, IWin32Window window, int delayMilliseconds, Color backColor, Color foreColor, ToolTipIcon toolTipIcon, string toolTipTitle)
        {
            try
            {
                if (toolTip != null)
                {
                    toolTip.BackColor = backColor;
                    toolTip.ForeColor = foreColor;
                    toolTip.ToolTipIcon = toolTipIcon;
                    toolTip.ToolTipTitle = string.IsNullOrEmpty(toolTipTitle) ? string.Empty : toolTipTitle;
                    toolTip.Show(text, window, 0, 0, delayMilliseconds);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 툴팁 전시
        /// </summary>
        /// <param name="toolTip">컨트롤</param>
        /// <param name="text">내용</param>
        /// <param name="window">전시 위치 기준 컨트롤</param>
        /// <param name="delayMilliseconds">전시 시간[ms]</param>
        /// <param name="backColor">배경색</param>
        /// <param name="foreColor">전경색</param>
        public static void ShowToolTip(ToolTip toolTip, string text, IWin32Window window, int delayMilliseconds, Color backColor, Color foreColor)
        {
            ShowToolTip(toolTip, text, window, delayMilliseconds, backColor, foreColor, ToolTipIcon.None, string.Empty);
        }

        public static void ShowToolTipInfo(ToolTip toolTip, string text, IWin32Window window, int delayMilliseconds, Color backColor, Color foreColor)
        {
            ShowToolTip(toolTip, text, window, delayMilliseconds, backColor, foreColor, ToolTipIcon.Info, string.Empty);
        }

        public static void ShowToolTipInfo(ToolTip toolTip, string text, IWin32Window window, Color backColor, Color foreColor)
        {
            ShowToolTipInfo(toolTip, text, window, ShowTime, backColor, foreColor);
        }

        public static void ShowToolTipWarning(ToolTip toolTip, string text, IWin32Window window, int delayMilliseconds)
        {
            if (toolTip != null)
            {
                ShowToolTip(toolTip, text, window, delayMilliseconds, BackColorWarning, ForeColorWarning, ToolTipIcon.Warning, string.Empty);
            }
        }

        public static void ShowToolTipWarning(ToolTip toolTip, string text, IWin32Window window)
        {
            ShowToolTipWarning(toolTip, text, window, WarningShowTime);
        }

        public static void ShowToolTipError(ToolTip toolTip, string text, IWin32Window window, int delayMilliseconds)
        {
            if (toolTip != null)
            {
                ShowToolTip(toolTip, text, window, delayMilliseconds, BackColorError, ForeColorError, ToolTipIcon.Error, string.Empty);
            }
        }

        public static void ShowToolTipError(ToolTip toolTip, string text, IWin32Window window)
        {
            ShowToolTipError(toolTip, text, window, ErrorShowTime);
        }

        public static void Hide(IWin32Window window)
        {
            if (window is Control control)
            {
                GetToolTip(control.Name).Hide(window);
            }
        }

        public static void Clear()
        {
            try
            {
                foreach (KeyValuePair<string, ToolTip> pair in ToolTipCollection)
                {
                    pair.Value.RemoveAll();
                    pair.Value.Dispose();
                }

                ToolTipCollection.Clear();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
