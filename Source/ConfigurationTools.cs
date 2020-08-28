using System.Windows.Forms;

namespace FileInfoExtractor
{
    public static class ConfigurationTools
    {
        /// <summary>
        /// 화면 요소 Text 설정
        /// </summary>
        /// <param name="rootControl">컨트롤 객체 집합</param>
        /// <param name="settings">설정 객체</param>
        public static void LoadUIText(this Control.ControlCollection rootControl, System.Configuration.ApplicationSettingsBase settings)
        {
            if ((rootControl != null) && (settings != null))
            {
                //TODO: 사용자 설정 PropertyValues 생성
                if (settings.PropertyValues.Count == 0)
                {
                    using (System.Windows.Forms.PropertyGrid pg = new PropertyGrid())
                    {
                        pg.SelectedObject = settings;
                    }
                }

                foreach (System.Configuration.SettingsProperty p in settings.Properties)
                {
                    string name = string.Copy(p.Name);
                    string value = string.Empty;
                    if (settings.PropertyValues.Count > 0)
                    {
                        value = settings.PropertyValues[name].PropertyValue.ToString();
                    }
                    else
                    {
                        value = p.DefaultValue.ToString();
                    }

                    foreach (Control control in rootControl)
                    {
                        if (LoadUIText(control, name, value))
                        {
                            break;
                        }
                    }
                }
            }
        }

        public static bool LoadUIText(this Control control, string name, string value)
        {
            bool find = false;

            if (control != null)
            {
                if (control.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                {
                    control.Text = value;
                    find = true;
                }
                else if (control is DataGridView grid)
                {
                    if (grid.Columns.Contains(name))
                    {
                        grid.Columns[name].HeaderText = value;
                        find = true;
                    }
                }

                foreach (Control child in control.Controls)
                {
                    if (LoadUIText(child, name, value))
                    {
                        find = true;
                        break;
                    }
                }
            }

            return find;
        }

        public static void LoadUIText(this Form form, System.Configuration.ApplicationSettingsBase settings)
        {
            if (form != null)
            {
                LoadUIText(form.Controls, settings);
            }
        }

        public static void SetDefaultValue(Control control, string value)
        {
            if ((control != null) && (!string.IsNullOrEmpty(control.Text) == false))
            {
                control.Text = value;
            }
        }
    }
}
