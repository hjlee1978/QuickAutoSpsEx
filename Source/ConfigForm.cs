using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

#pragma warning disable CA1031 // 일반적인 예외 형식을 catch하지 마세요.
#pragma warning disable CA1305 // IFormatProvider를 지정하세요.
#pragma warning disable CA1304 // CultureInfo를 지정하세요.

namespace FileInfoExtractor
{
    public partial class ConfigForm : Form
    {
        /// <summary>
        /// 확장자 정의 읽기 Action
        /// </summary>
        public Action ActionLoadExtensionList { get; set; }
        /// <summary>
        /// 확장자 정의 저장 Action
        /// </summary>
        public Action ActionSaveExtensionList { get; set; }
        /// <summary>
        /// 제외 확장자 저장 Action
        /// </summary>
        public Action ActionLoadExcludeExtensions { get; set; }
        /// <summary>
        /// 제외 확장자 저장 Action
        /// </summary>
        public Action ActionSaveExcludeExtensions { get; set; }
        /// <summary>
        /// 제외 디렉토리 읽기 Action
        /// </summary>
        public Action ActionLoadExcludeDirectories { get; set; }
        /// <summary>
        /// 제외 디렉토리 저장 Action
        /// </summary>
        public Action ActionSaveExcludeDirectories { get; set; }
        /// <summary>
        /// 소스코드 확장자 읽기 Action
        /// </summary>
        public Action ActionLoadSourceExtensions { get; set; }
        /// <summary>
        /// 소스코드 확장자 저장 Action
        /// </summary>
        public Action ActionSaveSourceExtensions { get; set; }
        /// <summary>
        /// 프로젝트 확장자 읽기 Action
        /// </summary>
        public Action ActionLoadProjectExtensions { get; set; }
        /// <summary>
        /// 프로젝트 확장자 저장 Action
        /// </summary>
        public Action ActionSaveProjectExtensions { get; set; }

        public ConfigForm()
        {
            InitializeComponent();
        }

        public void SetExtensionList(Dictionary<string, string> list)
        {
            SetDataGridViewData(dataGridViewExtension, list);
        }

        public void SetExcludeExtensions(List<string> list)
        {
            if (list != null)
            {
                StringBuilder builer = new StringBuilder();
                foreach (var line in list)
                {
                    builer.AppendLine(line);
                }
                textBoxExcludeExtensions.Text = builer.ToString(); 
            }
        }

        /// <summary>
        /// 제외 확장자 목록 반환
        /// </summary>
        public List<string> GetExcludeExtensions()
        {
            return GetList(textBoxExcludeExtensions);
        }

        public void SetExcludeDirectories(List<string> list)
        {
            if (list != null)
            {
                StringBuilder builer = new StringBuilder();
                foreach (var line in list)
                {
                    builer.AppendLine(line);
                }
                textBoxExcludeDirectories.Text = builer.ToString();
            }
        }

        /// <summary>
        /// 제외 디렉토리 목록 반환
        /// </summary>
        public List<string> GetExcludeDirectories()
        {
            return GetList(textBoxExcludeDirectories);
        }

        public void SetSourceExtensions(List<string> list)
        {
            SetList(textBoxSourceExtensions, list);
        }

        public List<string> GetSourceExtensions()
        {
            return GetList(textBoxSourceExtensions);
        }

        public void SetProjectExtensions(List<string> list)
        {
            SetList(textBoxProjectExtensions, list);
        }

        private static void SetList(TextBox box, List<string> list)
        {
            try
            {
                if ((box != null) && (list != null))
                {
                    StringBuilder builer = new StringBuilder();
                    foreach (var line in list)
                    {
                        builer.AppendLine(line);
                    }
                    box.Text = builer.ToString();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private static List<string> GetList(TextBox box)
        {
            List<string> list = new List<string>();

            try
            {
                if (box != null)
                {
                    list = box.Lines.ToList();
                    list.RemoveAll(x => string.IsNullOrEmpty(x) || string.IsNullOrWhiteSpace(x));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return list;
        }

        public static void SetDataGridViewData(DataGridView view, Dictionary<string, string> list)
        {
            if (view != null)
            {
                view.SuspendLayout();
                view.Rows.Clear();
                if (list != null)
                {
                    foreach (KeyValuePair<string, string> pair in list)
                    {
                        view.Rows.Add(pair.Key, pair.Value);
                    }
                }
                view.ResumeLayout();
            }
        }

        private void ButtonExtensionSave_Click(object sender, EventArgs e)
        {
            ActionSaveExtensionList?.Invoke();
            //SaveDataGridViewData(dataGridViewExtension, "classByExtension");
        }

        public Dictionary<string, string> GetExtensionMap()
        {
            return GetDataGridViewData(dataGridViewExtension);
        }

        private static Dictionary<string, string> GetDataGridViewData(DataGridView view)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();

            if (view != null)
            {
                for (int row = 0; row < view.Rows.Count; ++row)
                {
                    var key = view.Rows[row].Cells[0].Value;
                    var value = view.Rows[row].Cells[1].Value;
                    if ((key != null) && (value != null) &&
                        (string.IsNullOrEmpty(key.ToString()) == false))
                    {
                        list[key.ToString()] = value.ToString();
                    }
                }
            }

            return list;
        }

        private void ButtonExtensionLoad_Click(object sender, EventArgs e)
        {
            ActionLoadExtensionList?.Invoke();
        }

        private void ButtonExcludeExtensionLoad_Click(object sender, EventArgs e)
        {
            ActionLoadExcludeExtensions?.Invoke();
        }

        private void ButtonExcludeExtensionSave_Click(object sender, EventArgs e)
        {
            ActionSaveExcludeExtensions?.Invoke();
        }

        private void ButtonExcludeDirectoriesLoad_Click(object sender, EventArgs e)
        {
            ActionLoadExcludeDirectories?.Invoke();
        }

        private void ButtonExcludeDirectoriesSave_Click(object sender, EventArgs e)
        {
            ActionSaveExcludeDirectories?.Invoke();
        }

        private void ButtonSourceExtensionsLoad_Click(object sender, EventArgs e)
        {
            ActionLoadSourceExtensions?.Invoke();
        }

        private void ButtonSourceExtensionsSave_Click(object sender, EventArgs e)
        {
            ActionSaveSourceExtensions?.Invoke();
        }

        private void ButtonProjectExtensionLoad_Click(object sender, EventArgs e)
        {
            ActionLoadProjectExtensions?.Invoke();
        }

        private void ButtonProjectExtensionSave_Click(object sender, EventArgs e)
        {

        }
    }
}

#pragma warning restore CA1031 // 일반적인 예외 형식을 catch하지 마세요.
#pragma warning restore CA1305 // IFormatProvider를 지정하세요.
#pragma warning restore CA1304 // CultureInfo를 지정하세요.