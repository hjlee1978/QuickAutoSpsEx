//Copyright (c) 2017-present, Firstec, Inc.

//This library is free software; you can redistribute it and/or
//modify it under the terms of the GNU Lesser General Public
//License as published by the Free Software Foundation; either
//version 2.1 of the License, or (at your option) any later version.

//This library is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//Lesser General Public License for more details.

//You should have received a copy of the GNU Lesser General Public
//License along with this library; if not, write to the Free Software
//Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301
//USA

using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

#pragma warning disable CA1031 // 일반적인 예외 형식을 catch하지 마세요.
#pragma warning disable CA1304 // CultureInfo를 지정하세요.
#pragma warning disable CA1305 // IFormatProvider를 지정하세요.
#pragma warning disable CA1307 // StringComparison을 지정하세요.

namespace FileInfoExtractor
{
    public partial class QuickAutoSpsForm : Form
    {
        /// <summary>
        /// 확장자 설정 파일
        /// </summary>
        const string classByExtensionPath = ".\\Data\\classByExtension.txt";
        /// <summary>
        /// 포함 문자열 설정 파일
        /// </summary>
        const string classBySubStringPath = ".\\Data\\classBySubString.txt";
        /// <summary>
        /// 제외 확장자 설정 파일
        /// </summary>
        const string excludeExtensionFilePath = ".\\Data\\excludeExtensions.txt";
        /// <summary>
        /// 소스코드 확장자 설정 파일
        /// </summary>
        const string sourceExtensionFilePath = ".\\Data\\SourceFileExtension.txt";
        /// <summary>
        /// 프로젝트 확장자 설정 파일
        /// </summary>
        const string projectExtensionFilePath = ".\\Data\\ProjectFileExtension.txt";
        /// <summary>
        /// 라인수 체크 확장자 설정 파일
        /// </summary>
        const string lineExtensionFilePath = ".\\Data\\lineFileExtension.txt";
        /// <summary>
        /// 제외 디렉토리 설정 파일
        /// </summary>
        const string excludeDirectoriesFilePath = ".\\Data\\excludeDirectories.txt";

        /// <summary>
        /// 실행파일 확장자 설정 파일
        /// </summary>
        const string executeFileExtesionPath = @".\Data\executeFileExtension.txt";

        /// <summary>
        /// 라이브러리 확장자 설정 파일
        /// </summary>
        const string libraryFileExtesionPath = @".\Data\libraryFileExtension.txt";

        /// <summary>
        /// 확장자 설정 목록
        /// </summary>
        Dictionary<string, string> extensionMapToClass = new Dictionary<string, string>();
        /// <summary>
        /// 포함 문자열 설정 목록
        /// </summary>
        Dictionary<string, string> subStringMapToClass = new Dictionary<string, string>();
        
        /// <summary>
        /// 제외 파일 확장자 목록
        /// </summary>
        List<string> ExcludeExtensions = new List<string>();

        /// <summary>
        /// 소스코드 파일 확장자 목록
        /// </summary>
        List<string> SourceExtensions = new List<string>();

        /// <summary>
        /// 프로젝트 파일 확장자 목록
        /// </summary>
        List<string> ProjectExtensions = new List<string>();

        /// <summary>
        /// 라인수 체크 확장자 목록
        /// </summary>
        List<string> LineExtensions = new List<string>();
        
        /// <summary>
        /// 제외 디렉토리 목록
        /// </summary>
        List<string> ExcludeDirectories = new List<string>();

        /// <summary>
        /// 실행파일 확장자 목록
        /// </summary>
        List<string> ExecuteExtensions = new List<string>();

        /// <summary>
        /// 라이브러리 파일 확장자 목록
        /// </summary>
        List<string> LibraryExtensions = new List<string>();

        private readonly Crc32 _crc32 = new Crc32();

        private readonly String exeFilePath = "sps_auto_temp1231231231.hwp";
        private readonly String scrFilePath = "sps_auto_temp1231231232.hwp";
        private readonly String projectFilePath = "sps_auto_temp1231231233.hwp";

        private readonly CultureInfo defaultCultureInfo = new CultureInfo("en-us");

        public QuickAutoSpsForm()
        {
            InitializeComponent();

            //프로그램 버전 전시
            this.Text = $"{System.Windows.Forms.Application.ProductName} v{System.Windows.Forms.Application.ProductVersion}";
        }

        private void ExtractDirPath_Click(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;

                if ((string.IsNullOrEmpty(tbExtractPath.Text) == false) &&
                    Directory.Exists(tbExtractPath.Text))
                {
                    dialog.InitialDirectory = tbExtractPath.Text;
                }
                else if((string.IsNullOrEmpty(Properties.LastInfo.Default.strSrcPath) == false) &&
                        Directory.Exists(Properties.LastInfo.Default.strSrcPath))
                {
                    dialog.InitialDirectory = Properties.LastInfo.Default.strSrcPath;
                }

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    tbExtractPath.Text = dialog.FileName;
                    Properties.LastInfo.Default.strSrcPath = tbExtractPath.Text;

                    //파일경로 삭제문자열 자동 설정
                    tbPathDel.Text = tbExtractPath.Text;
                    Properties.LastInfo.Default.strTrimPath = tbPathDel.Text;

                    Properties.LastInfo.Default.Save();
                }
            }
        }

        private static bool DirectoryExists(string path)
        {
            bool exist = false;

            if((string.IsNullOrEmpty(path) == false) &&
                Directory.Exists(path))
            {
                exist = true;
            }

            return exist;
        }

        /// <summary>
        /// 결과 저장 경로 선택
        /// </summary>
        private void ResultDirPath_Click(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;

                if ((string.IsNullOrEmpty(tbResultPath.Text) == false) &&
                    Directory.Exists(tbResultPath.Text))
                {
                    dialog.InitialDirectory = tbResultPath.Text;
                }
                else if ((string.IsNullOrEmpty(Properties.LastInfo.Default.strDstPath) == false) &&
                        Directory.Exists(Properties.LastInfo.Default.strDstPath))
                {
                    dialog.InitialDirectory = Properties.LastInfo.Default.strDstPath;
                }

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    tbResultPath.Text = dialog.FileName;
                    Properties.LastInfo.Default.strDstPath = tbResultPath.Text;
                    Properties.LastInfo.Default.Save();
                }
            }
        }

        /// <summary>
        /// 결과 엑셀 출력
        /// </summary>
        private void ExtractExcel(IEnumerable<FileSystemInfo> infos)
        {
            try
            {
                string checkSumCode = "";
                StringBuilder itemContents = new StringBuilder();

                int i = 1;
                int row = 1;

                extractDirPath.Enabled = false;
                resultDirPath.Enabled = false;
                startExtract.Enabled = false;
                buttonClose.Enabled = false;
                btDisplayResult.Visible = false;

                pbProgress.Visible = true;
                lbFile.Text = "";
                lbFile.Visible = true;

                string resultPath = Path.Combine(new string[] { tbResultPath.Text, tbResultName.Text });

                if (System.IO.File.Exists(resultPath))
                {
                    System.IO.File.Delete(resultPath);
                }

                Excel.Application oXL;
                Excel._Workbook oWB;
                Excel._Worksheet oSheet;

                //Start Excel and get Applicatio  n object.
                oXL = new Excel.Application
                {
                    DisplayAlerts = false
                };

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add());
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                if (rbSrcTypeExe.Checked == true)
                {
                    oSheet.Cells[row, 1] = "저장위치";
                    oSheet.Cells[row, 2] = "구 분";
                    oSheet.Cells[row, 3] = "순번";
                    oSheet.Cells[row, 4] = "파일명";
                    oSheet.Cells[row, 5] = "버전";
                    oSheet.Cells[row, 6] = "크기\n(Byte)";
                    oSheet.Cells[row, 7] = "첵섬";
                    oSheet.Cells[row, 8] = "수정일";
                    oSheet.Cells[row, 9] = "부품번호";
                    oSheet.Cells[row, 10] = "기능 설명";

                    //oSheet.Cells[0, 7].EntireColumn.NumberFormat = "@";
                }
                else
                {
                    oSheet.Cells[row, 1] = "저장위치";
                    oSheet.Cells[row, 2] = "순번";
                    oSheet.Cells[row, 3] = "파일명";
                    oSheet.Cells[row, 4] = "버전";
                    oSheet.Cells[row, 5] = "크기\n(Byte)";
                    oSheet.Cells[row, 6] = "첵섬";
                    oSheet.Cells[row, 7] = "생성일자";
                    oSheet.Cells[row, 8] = "라인수";
                    oSheet.Cells[row, 9] = "기능 설명";
                }

                row++;

                //저장위치(FullPath)
                string lastDirectoryName = "";
                //저장위치
                string lastDirectoryNameShort = "";
                int exeNumberIndex = 1;
                int libNumberIndex = 1;
                int dataNumberIndex = 1;

                string path = string.Empty;

                foreach (FileSystemInfo info in infos)
                {
                    
                    if (info.Attributes.HasFlag(FileAttributes.Directory) || info.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        continue;
                    }

                    FileInfo fileInfo = new FileInfo(info.FullName);

                    // 상태바에 처리 데이터 이름 출력
                    lbFile.Text = info.Name;

                    // 경로 변경 시 경로 정보
                    if (fileInfo.DirectoryName != lastDirectoryName)
                    {
                        string pathGroup = GetPathHead(fileInfo.DirectoryName);

                        oSheet.Cells[row, 2] = pathGroup;

                        //저장위치 병합
                        if (rbSrcTypeExe.Checked == true)
                        {
                            oSheet.Range[oSheet.Cells[row, 2], oSheet.Cells[row, 10]].Merge(true);
                        }
                        else
                        {
                            oSheet.Range[oSheet.Cells[row, 2], oSheet.Cells[row, 9]].Merge(true);
                        }

                        Excel.Range PathLine = (Excel.Range)oSheet.Rows[row + 1];
                        PathLine.Insert();

                        row++;

                        lastDirectoryName = fileInfo.DirectoryName;
                        lastDirectoryNameShort = pathGroup;
                    }


                    // 체크섬
                    StringBuilder hashCodeString = new StringBuilder();

                    byte[] srcContents = File.ReadAllBytes(info.FullName);

                    byte[] hashCode = _crc32.ComputeHash(srcContents);

                    for (int index = 0; index < hashCode.Length; index++)
                    {
                        hashCodeString.Append(hashCode[index].ToString("X2", defaultCultureInfo));
                    }

                    checkSumCode = hashCodeString.ToString();

                    // 생성일자


                    // 라인 수(소스코드, 프로젝트 파일 등)
                    string[] lines = null;
                    if (LineExtensions.Contains(info.Extension, StringComparer.OrdinalIgnoreCase))
                    {
                        lines = File.ReadAllLines(info.FullName);
                    }

                    // 조립
                    if (rbSrcTypeExe.Checked == true)
                    {
                        oSheet.Cells[row, 1] = path;
                        oSheet.Cells[row, 2] = GetFileClassName(fileInfo);
                        oSheet.Cells[row, 3] = i;
                        oSheet.Cells[row, 4] = info.Name;
                        oSheet.Cells[row, 5] = string.Format("'"+tbVersion.Text);
                        oSheet.Cells[row, 6] = string.Format("{0:n0}", fileInfo.Length);
                        oSheet.Cells[row, 7].NumberFormat = "@";
                        oSheet.Cells[row, 7].Value = checkSumCode;
                        oSheet.Cells[row, 8] = string.Format("{0:0000}.{1:00}.{2:00}", info.LastWriteTime.Year, info.LastWriteTime.Month, info.LastWriteTime.Day);

                        if (IsContains(ExecuteExtensions, fileInfo.Extension))
                        {
                            oSheet.Cells[row, 9] = string.Format("{0:D}{1:D3}", tbExeNumberbase.Text, exeNumberIndex++);
                        }
                        if (IsContains(LibraryExtensions, fileInfo.Extension))
                        {
                            oSheet.Cells[row, 9] = string.Format("{0:D}{1:D3}", tbLibNumberBase.Text, libNumberIndex++);
                        }
                        else
                        {
                            oSheet.Cells[row, 9] = string.Format("{0:D}{1:D3}", tbEtcNumberBase.Text, dataNumberIndex++);
                        }

                        oSheet.Cells[row, 10] = "-";
                    }
                    else
                    {
                        oSheet.Cells[row, 1] = path;
                        oSheet.Cells[row, 2] = i;
                        oSheet.Cells[row, 3] = info.Name;
                        oSheet.Cells[row, 4] = string.Format("'" + tbVersion.Text);
                        oSheet.Cells[row, 5] = string.Format("{0:n0}", fileInfo.Length);
                        oSheet.Cells[row, 6].NumberFormat = "@";
                        oSheet.Cells[row, 6].Value = checkSumCode;
                        oSheet.Cells[row, 7] = string.Format("{0:0000}.{1:00}.{2:00}", info.LastWriteTime.Year.ToString().Substring(2), info.LastWriteTime.Month, info.LastWriteTime.Day);
                        oSheet.Cells[row, 8] = (lines == null ? "-" : string.Format("{0}", lines.Length + 1));
                        oSheet.Cells[row, 9] = "-";
                    }


                    Excel.Range Line = (Excel.Range)oSheet.Rows[row + 1];
                    Line.Insert();

                    checkSumCode = "";
                    i++;
                    row++;

                    System.Windows.Forms.Application.DoEvents();
                }

                oWB.SaveAs(resultPath, Excel.XlFileFormat.xlWorkbookNormal);
                oWB.Close();
                oXL.Quit();

                pbProgress.Visible = false;
                lbFile.Visible = false;
                btDisplayResult.Visible = true;
                MessageBox.Show((IWin32Window)this, "추출 완료");

                if (cbAutoRun.Checked)
                    btDisplayResult.PerformClick();

            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
            finally
            {
                extractDirPath.Enabled = true;
                resultDirPath.Enabled = true;
                startExtract.Enabled = true;
                buttonClose.Enabled = true;

                pbProgress.Visible = false;
                lbFile.Visible = false;
            }


        }

        private static string[] FileReadAllLines(string filename)
        {
            string[] lines;

            try
            {
                lines = File.ReadAllLines(filename);
            }
            catch (Exception ex)
            {
                lines = null;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return lines;
        }

        private bool IsExcludeDirectory(FileInfo fileInfo, string rootPath)
        {
            bool exclude = false;
            
            var rootDir = fileInfo.DirectoryName.Remove(0, rootPath.Length);
            var dirs = rootDir.Split(Path.DirectorySeparatorChar);
            foreach (var dir in dirs)
            {
                if (ExcludeDirectories.Exists(x => x.Equals(dir, StringComparison.OrdinalIgnoreCase)))
                {
                    exclude = true;
                    continue;
                }
            }

            return exclude;
        }

        private string GetPathHead(string directoryName)
        {
            string path;

            // 경로에 사용자가 삭제할 경로문자가 존재하는 경우
            if ((string.IsNullOrEmpty(tbPathDel.Text) == false) &&
                (directoryName.IndexOf(tbPathDel.Text, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                path = string.Format(tbPathHead.Text + directoryName.Replace(tbPathDel.Text, ""));
            }
            else
            {
                path = string.Format(tbPathHead.Text + directoryName);
            }

            if (cbUseLower.Checked)
            {
                path = path.ToLower();
            }
            else
            {
                path = path.ToUpper();
            }

            return path;
        }

        private static bool IsContains(List<string> list, string data)
        {
            bool result = false;

            if(list != null)
            {
                result = list.Contains(data, StringComparer.OrdinalIgnoreCase);
            }

            return result;
        }

        private void ExtractHwp(IEnumerable<FileSystemInfo> infos)
        {
            try
            {
                String[] hwpInsertText = new String[9];

                String[] hwpInsertTextCode = new String[8];

                string checkSumCode = "";
                StringBuilder itemContents = new StringBuilder();

                int i = 1;

                extractDirPath.Enabled = false;
                resultDirPath.Enabled = false;
                startExtract.Enabled = false;
                buttonClose.Enabled = false;
                btDisplayResult.Visible = false;

                pbProgress.Visible = true;
                lbFile.Text = "";
                lbFile.Visible = true;

                string resultPath = Path.Combine(new string[] { tbResultPath.Text, tbResultName.Text });

                if (System.IO.File.Exists(resultPath))
                {
                    System.IO.File.Delete(resultPath);
                }

                ResourceCopy();// c# 리소스에서 한글 템플릿 파일 복사,  temp1,hwp,  temp2.hwp
                
                if (rbSrcTypeExe.Checked == true)
                {
                    axHwpCtrl.Open(exeFilePath);
                }
                else if(rbSrcTypeSrc.Checked == true)
                {
                    axHwpCtrl.Open(scrFilePath);
                }
                else
                {
                    axHwpCtrl.Open(projectFilePath);
                }

                axHwpCtrl.MoveToField("table1_field1");

                string lastDirectoryName = "";
                int exeNumberIndex = 1;
                int libNumberIndex = 1;
                int dataNumberIndex = 1;

                foreach (FileSystemInfo info in infos)
                {
                    if (info.Attributes.HasFlag(FileAttributes.Directory) || info.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        continue;
                    }

                    FileInfo fileInfo = new FileInfo(info.FullName);

                    // 상태바에 처리 데이터 이름 출력
                    lbFile.Text = info.Name;

                    // 경로 변경 시 경로 정보
                    if (fileInfo.DirectoryName.Equals(lastDirectoryName, StringComparison.OrdinalIgnoreCase) == false)
                    {
                        string path = GetPathHead(fileInfo.DirectoryName);

                        Hwp_insertPath(path);

                        lastDirectoryName = fileInfo.DirectoryName;
                    }

                    // 체크섬
                    StringBuilder hashCodeString = new StringBuilder();

                    byte[] srcContents = File.ReadAllBytes(info.FullName);

                    byte[] hashCode = _crc32.ComputeHash(srcContents);

                    for (int index = 0; index < hashCode.Length; index++)
                    {
                        hashCodeString.Append(hashCode[index].ToString("X2"));
                    }

                    checkSumCode = hashCodeString.ToString();

                    // 생성일자


                    // 라인 수(소스코드, 프로젝트 파일 등)
                    string[] lines = null;
                    if (LineExtensions.Contains(info.Extension, StringComparer.OrdinalIgnoreCase))
                    {
                        lines = File.ReadAllLines(info.FullName);
                    }

                    // 조립
                    if (rbSrcTypeExe.Checked == true)
                    {
                        hwpInsertText[0] = GetFileClassName(fileInfo);
                        hwpInsertText[1] = i.ToString();
                        hwpInsertText[2] = info.Name;
                        hwpInsertText[3] = tbVersion.Text;
                        hwpInsertText[4] = string.Format("{0:n0}", fileInfo.Length);
                        hwpInsertText[5] = checkSumCode;
                        hwpInsertText[6] = string.Format("{0:0000}.{1:00}.{2:00}", info.LastWriteTime.Year, info.LastWriteTime.Month, info.LastWriteTime.Day);

                        if(IsContains(ExecuteExtensions, fileInfo.Extension))
                        {
                            hwpInsertText[7] = string.Format("{0:D}{1:D3}", tbExeNumberbase.Text, exeNumberIndex++);
                        }
                        else if (IsContains(LibraryExtensions, fileInfo.Extension))
                        {
                            hwpInsertText[7] = string.Format("{0:D}{1:D3}", tbLibNumberBase.Text, libNumberIndex++);
                        }
                        else
                        {
                            hwpInsertText[7] = string.Format("{0:D}{1:D3}", tbEtcNumberBase.Text, dataNumberIndex++);
                        }
                        hwpInsertText[8] = "-";
           

                        Hpw_insertData(hwpInsertText);
                    }
                    else
                    {
                        hwpInsertTextCode[0] = i.ToString();
                        hwpInsertTextCode[1] = info.Name;
                        hwpInsertTextCode[2] = tbVersion.Text;
                        hwpInsertTextCode[3] = string.Format("{0:n0}", fileInfo.Length);
                        hwpInsertTextCode[4] = checkSumCode;
                        hwpInsertTextCode[5] = string.Format("{0:0000}.{1:00}.{2:00}", info.LastWriteTime.Year.ToString().Substring(2), info.LastWriteTime.Month, info.LastWriteTime.Day);
                        hwpInsertTextCode[6] = (lines == null ? "-" : string.Format("{0}", lines.Length + 1));
                        hwpInsertTextCode[7] = "-";

                        Hpw_insertData(hwpInsertTextCode);
                    }

                    checkSumCode = "";
                    i++;
        

                    System.Windows.Forms.Application.DoEvents();
                }

                //표의 마지막 라인 삭제
                Hwp_end();
                
                if(cbTableHeaderSet.Checked)
                {
                    Hwp_setHeaderCell(); // 제목 셀 반복 설정
                }

                //커서 위치 이동
                axHwpCtrl.MoveToField("table1_field1");
                
                //한글 세이브
                axHwpCtrl.SaveAs(resultPath);

                //한글 파일 닫기
                axHwpCtrl.Clear();

                //임시파일 삭제
                FileDelete(exeFilePath);
                FileDelete(scrFilePath);
                FileDelete(projectFilePath);

                pbProgress.Visible = false;
                lbFile.Visible = false;
                btDisplayResult.Visible = true;
                MessageBox.Show((IWin32Window)this, "추출 완료");

                if (cbAutoRun.Checked)
                    btDisplayResult.PerformClick();

            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
            finally
            {
                extractDirPath.Enabled = true;
                resultDirPath.Enabled = true;
                startExtract.Enabled = true;
                buttonClose.Enabled = true;

                pbProgress.Visible = false;
                lbFile.Visible = false;
            }
        }

        private static void FileDelete(string filename)
        {
            try
            {
                File.Delete(filename);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void StartExtract_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbExtractPath.Text))
            {
                return;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(tbExtractPath.Text);
            IEnumerable<FileSystemInfo> infos = dirInfo.EnumerateFileSystemInfos("*", SearchOption.AllDirectories);

            infos = CheckExcludeDirectoryList(infos, dirInfo.FullName);

            if (rbSrcTypeSrc.Checked)
            {
                //소스코드
                infos = CheckExtensionsList(SourceExtensions, infos);
            }
            else if (rbSrcTypeProject.Checked)
            {
                //프로젝트
                infos = CheckExtensionsList(ProjectExtensions, infos);
            }
            else if(rbSrcTypeExe.Checked)
            {
                //실행파일
                //infos = CheckExtensionsList(ExecuteExtensions, infos);
            }

            //실행파일
            //배제 확장자 검사
            infos = CheckExcludeExtensionsList(infos);

            //확장자별 정렬
            //infos = SortByClass(infos);

            //디렉토리별 그룹화
            //infos = ClusterByDir(infos);

            if (rbRetTypeHwp.Checked)
            {
                ExtractHwp(infos);
            }
            else
            {
                ExtractExcel(infos);
            }


            Properties.LastInfo.Default.strHeadPath = tbPathHead.Text;
            Properties.LastInfo.Default.strTrimPath = tbPathDel.Text;
            Properties.LastInfo.Default.strSrcPath = tbExtractPath.Text;
            Properties.LastInfo.Default.strDstPath = tbResultPath.Text;
            Properties.LastInfo.Default.strDstFile = tbResultName.Text;
            Properties.LastInfo.Default.bSrcTypeExe = rbSrcTypeExe.Checked;
            Properties.LastInfo.Default.strExeNumberBase = tbExeNumberbase.Text;
            Properties.LastInfo.Default.strLibNumberBase = tbLibNumberBase.Text;
            Properties.LastInfo.Default.strEtcNumberBase = tbEtcNumberBase.Text;
            Properties.LastInfo.Default.bRstTypeHwp = rbRetTypeHwp.Checked;
            Properties.LastInfo.Default.strVersion = tbVersion.Text;
            Properties.LastInfo.Default.bResultAutoRun = cbAutoRun.Checked;
            Properties.LastInfo.Default.Save();
        }

        private void QuickAutoSpsForm_Shown(object sender, EventArgs e)
        {
            tbExtractPath.Text = Properties.LastInfo.Default.strSrcPath;
            tbPathDel.Text = Properties.LastInfo.Default.strTrimPath;

            if (string.IsNullOrEmpty(Properties.LastInfo.Default.strHeadPath) == false)
            {
                tbPathHead.Text = Properties.LastInfo.Default.strHeadPath;
            }

            if (Properties.LastInfo.Default.bSrcTypeExe == true)
            {
                rbSrcTypeExe.Select();
            }
            else
            {
                rbSrcTypeSrc.Select();
            }


            if (Properties.LastInfo.Default.bRstTypeHwp == true)
            {
                rbRetTypeHwp.Select();   
            }
            else
            {
                rbRetTypeExl.Select();
            }

            tbResultName.Text = string.IsNullOrEmpty(Properties.LastInfo.Default.strDstFile)
                ? "Result"
                : Properties.LastInfo.Default.strDstFile;

            if (Properties.LastInfo.Default.bRstTypeHwp == true)
            {
                tbResultName.Text = Path.ChangeExtension(tbResultName.Text, "hwp");
            }
            else
            {
                tbResultName.Text = Path.ChangeExtension(tbResultName.Text, "xls");
            }


            if (string.IsNullOrEmpty(Properties.LastInfo.Default.strDstPath))
            {
                tbResultPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                tbResultPath.Text = Properties.LastInfo.Default.strDstPath;
            }

            if (string.IsNullOrEmpty(Properties.LastInfo.Default.strExeNumberBase) == false)
            {
                tbExeNumberbase.Text = Properties.LastInfo.Default.strExeNumberBase;
            }

            if (string.IsNullOrEmpty(Properties.LastInfo.Default.strLibNumberBase) == false)
            {
                tbLibNumberBase.Text = Properties.LastInfo.Default.strLibNumberBase;
            }

            if (string.IsNullOrEmpty(Properties.LastInfo.Default.strEtcNumberBase) == false)
            {
                tbEtcNumberBase.Text = Properties.LastInfo.Default.strEtcNumberBase;
            }

            //strVersion
            if ( string.IsNullOrEmpty(Properties.LastInfo.Default.strVersion) )
            {
                tbVersion.Text = Properties.Settings.Default.DefaultVersion;
            }
            else
            {
                tbVersion.Text = Properties.LastInfo.Default.strVersion;
            }

            if(  Properties.LastInfo.Default.bResultAutoRun )
            {
                cbAutoRun.Checked = true;
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtDisplayResult_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fi = new FileInfo(tbResultPath.Text + @"\" + tbResultName.Text);
                if (fi.Exists)
                {
                    System.Diagnostics.Process.Start(tbResultPath.Text + @"\" + tbResultName.Text);
                }
            }
            catch (Exception ex )
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, ex.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, ex.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }

        #region 한글컨트롤
        void Hwp_insertTable()
        {
            HWPCONTROLLib.DHwpAction act = (HWPCONTROLLib.DHwpAction)axHwpCtrl.CreateAction("TableAppendRow");

            HWPCONTROLLib.DHwpParameterSet pset = (HWPCONTROLLib.DHwpParameterSet)act.CreateSet();

            act.GetDefault(pset);

            act.Execute(pset);

            Hwp_colBegin();
        }

        void Hwp_moveDonw()
        {
            HWPCONTROLLib.DHwpAction act1 = (HWPCONTROLLib.DHwpAction)axHwpCtrl.CreateAction("MoveDown");

            HWPCONTROLLib.DHwpParameterSet pset1 = (HWPCONTROLLib.DHwpParameterSet)act1.CreateSet();

            act1.GetDefault(pset1);

            act1.Execute(pset1);
        }

        void Hwp_moveUp()
        {
            HWPCONTROLLib.DHwpAction act1 = (HWPCONTROLLib.DHwpAction)axHwpCtrl.CreateAction("MoveUp");

            HWPCONTROLLib.DHwpParameterSet pset1 = (HWPCONTROLLib.DHwpParameterSet)act1.CreateSet();

            act1.GetDefault(pset1);

            act1.Execute(pset1);
        }

        void Hwp_colMerge()
        {
            axHwpCtrl.Run("TableCellBlock");
            axHwpCtrl.Run("TableColBegin");
            axHwpCtrl.Run("TableCellBlockExtend");
            axHwpCtrl.Run("TableColEnd");
            axHwpCtrl.Run("TableMergeCell");
        }

        void Hwp_colBegin()
        {
            axHwpCtrl.Run("TableCellBlock");
            axHwpCtrl.Run("TableColBegin");
            axHwpCtrl.Run("Cancel");
        }

        void Hwp_insertTableData(String[] data)
        {
            HWPCONTROLLib.DHwpAction act = (HWPCONTROLLib.DHwpAction)axHwpCtrl.CreateAction("InsertText");

            HWPCONTROLLib.DHwpParameterSet text = (HWPCONTROLLib.DHwpParameterSet)act.CreateSet();

            for (int i = 0; i < data.Length; i++)
            {
                text.SetItem("Text", data[i]);

                act.Execute(text);

                if (i + 1 != data.Length)
                    axHwpCtrl.Run("MoveRight"); // axHwpCtrl1.Run("TableRightCell");
            }
        }

        void Hwp_TextLeft()
        {
            axHwpCtrl.Run("ParagraphShapeAlignLeft");
        }

        void Hwp_init()
        {
            axHwpCtrl.Open("execute.hwp");

            axHwpCtrl.MoveToField("table1_field1");
        }

        void Hwp_end()
        {
            HWPCONTROLLib.DHwpAction act = (HWPCONTROLLib.DHwpAction)axHwpCtrl.CreateAction("TableDeleteRow");

            HWPCONTROLLib.DHwpParameterSet pset = (HWPCONTROLLib.DHwpParameterSet)act.CreateSet();

            act.GetDefault(pset);

            act.Execute(pset);

            Hwp_colBegin();
        }


        void Hwp_tabClose()
        {
            HWPCONTROLLib.DHwpAction act = (HWPCONTROLLib.DHwpAction)axHwpCtrl.CreateAction("TabClose");

            HWPCONTROLLib.DHwpParameterSet pset = (HWPCONTROLLib.DHwpParameterSet)act.CreateSet();

            act.GetDefault(pset);

            act.Execute(pset);

            Hwp_colBegin();
        }

        void Hwp_insertPath(String data)
        {
            Hwp_insertTable();

            Hwp_moveUp();

            Hwp_colMerge();

            String[] path = new String[1];

            path[0] = data;

            Hwp_insertTableData(path);


            Hwp_TextLeft();

            Hwp_moveDonw();

            Hwp_colBegin();
        }

        void Hpw_insertData(String[] data)
        {
            Hwp_insertTableData(data);
            Hwp_insertTable();
        }

        void Hwp_setHeaderCell()
        {
            axHwpCtrl.MoveToField("table1_field2");// 제목셀로 지정된 셀로 이동

            HWPCONTROLLib.DHwpAction act = (HWPCONTROLLib.DHwpAction)axHwpCtrl.CreateAction("TablePropertyDialog");

            HWPCONTROLLib.DHwpParameterSet aa = (HWPCONTROLLib.DHwpParameterSet)axHwpCtrl.CreateSet("Table");

            act.GetDefault(aa);

            HWPCONTROLLib.DHwpParameterSet bb = (HWPCONTROLLib.DHwpParameterSet)aa.CreateItemSet("Cell", "Cell");

            bb.SetItem("Header", 1);

            act.Execute(aa);
        } 
        #endregion

        private void RbRetTypeHwp_CheckedChanged(object sender, EventArgs e)
        {
            tbResultName.Text = Path.ChangeExtension(tbResultName.Text, "hwp");

            if (rbRetTypeHwp.Checked)
            {
                MessageBox.Show("작업 중인 한글 파일을(HWP) 모두 닫아 주세요.\n 한글 파일 생성 중 오류가 발생 할 수 있음.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void RbRetTypeExl_CheckedChanged(object sender, EventArgs e)
        {
            tbResultName.Text = Path.ChangeExtension(tbResultName.Text, "xls");
        }

        private void LbDelText_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox box)
            {
                // 경로에 사용자가 삭제할 경로문자가 존재하는 경우
                if ((string.IsNullOrEmpty(box.Text)) == true ||
                    (tbExtractPath.Text.IndexOf(box.Text, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    lbDelText.Visible = false;
                }
                else
                {
                    lbDelText.Visible = true;
                }
            }
        }

        /// <summary>
        /// 아래한글 임시 템플릿 파일 복제 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="filename"></param>
        private static void ResourceCopy(byte[] resource, string filename)
        {
            try
            {
                if ((resource != null) && (resource.Length > 0) && (string.IsNullOrEmpty(filename) == false))
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Create))
                    {
                        fs.Write(resource, 0, resource.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private  void ResourceCopy()
        {
            //실행 파일 목록 템플릿 복사
            ResourceCopy(Properties.Resources.execute, exeFilePath);

            //소스코드 파일 목록 템플릿 복사
            ResourceCopy(Properties.Resources.source, scrFilePath);

            //프로젝트 파일 목록 템플릿 복사
            ResourceCopy(Properties.Resources.projet, projectFilePath);
        }

        private void QuickAutoSpsForm_Load(object sender, EventArgs e)
        {
            ToolTipUtils.LoadToolTips(this.toolTip, this.Controls, Properties.ToolTips.Default);

            extensionMapToClass = LoadFileClassRule(classByExtensionPath);
            subStringMapToClass = LoadFileClassRule(classBySubStringPath);
            ExcludeExtensions = LoadFileExtensions(excludeExtensionFilePath);
            ExcludeDirectories = LoadDirectories(excludeDirectoriesFilePath);
            SourceExtensions = LoadFileExtensions(sourceExtensionFilePath);
            ProjectExtensions = LoadFileExtensions(projectExtensionFilePath);
            LineExtensions = LoadFileExtensions(lineExtensionFilePath);
            ExecuteExtensions = LoadFileExtensions(executeFileExtesionPath);
            LibraryExtensions = LoadFileExtensions(libraryFileExtesionPath);
        }

        private string GetFileClassName(FileInfo fileInfo)
        {
            string fileClass = null;
            bool bDone = false;

            foreach (string subStringKey in subStringMapToClass.Keys)
            {
                if (fileInfo.FullName.Contains(subStringKey))
                {
                    fileClass = subStringMapToClass[subStringKey] as string;
                    bDone = true;
                    break;
                }
            }

            if (bDone == false)
            {
                if (extensionMapToClass?.TryGetValue(fileInfo.Extension, out fileClass) == false)
                {
                    // 정의되지 않은 확장자 또는 확장자가 없는 파일.
                    fileClass = "";
                }
            }

            return fileClass;
        }

        private static Dictionary<string, string> LoadFileClassRule(string filePath)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            try
            {
                string[] linesDirty = File.ReadAllLines(filePath, Encoding.UTF8);
                string[] lines = linesDirty.Where(line => !String.IsNullOrWhiteSpace(line) && !line.StartsWith("//", StringComparison.OrdinalIgnoreCase)).ToArray();
                dictionary = lines.Select(s => s.Split(new char[] { '=' })).ToDictionary(s => s[0].Trim(), s => s[1].Trim());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return dictionary;
        }

        private static void SaveFileClassRule(Dictionary<string, string> list, string filePath)
        {
            try
            {
                if( (list != null) &&
                    (string.IsNullOrEmpty(filePath) == false))
                {
                    using(StreamWriter writer = new StreamWriter(filePath))
                    {
                        list.ToList().ForEach(line =>
                        {
                            if((string.IsNullOrEmpty(line.Key) == false) &&
                               (string.IsNullOrWhiteSpace(line.Key) == false) &&
                               (string.IsNullOrEmpty(line.Value) == false) &&
                               (string.IsNullOrWhiteSpace(line.Value) == false))
                            {
                                writer.WriteLine($"{line.Key}={line.Value}");
                            }
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 파일 확장자 목록 읽기
        /// </summary>
        private static List<string> LoadFileExtensions(string filePath)
        {
            try
            {
                List<string> fileExtensions = new List<string>();
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        while (sr.ReadLine() is string line)
                        {
                            if (string.IsNullOrEmpty(line) == false)
                            {
                                line = line.Trim();
                                if ((line.Trim().StartsWith(";") == false) && (line.Trim().StartsWith(".")))
                                    fileExtensions.Add(line);
                            }
                        }
                    }
                }

                return fileExtensions;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// 확장파 목록 파일 저장
        /// </summary>
        /// <param name="list"></param>
        /// <param name="filename"></param>
        private static void SaveFileExtensions(List<string> list, string filename)
        {
            try
            {
                if ((list != null) &&
                    (string.IsNullOrEmpty(filename) == false))
                {
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        list.ForEach(line =>
                        {
                            if ((string.IsNullOrEmpty(line) == false) &&
                               (string.IsNullOrWhiteSpace(line) == false))
                            {
                                writer.WriteLine(line);
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 디렉토리 목록 읽기
        /// </summary>
        private static List<string> LoadDirectories(string filePath)
        {
            List<string> fileExtensions = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (sr.ReadLine() is string line)
                    {
                        //';'으로 시작하면 주석 줄
                        if (string.IsNullOrEmpty(line) == false)
                        {
                            line = line.Trim();
                            if (line.StartsWith(";") == false)
                            {
                                fileExtensions.Add(line);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return fileExtensions;
        }

        private static IEnumerable<FileSystemInfo> CheckExtensionsList(List<string> extensions, IEnumerable<FileSystemInfo> infos)
        {
            List<FileSystemInfo> list = new List<FileSystemInfo>();

            if ((extensions != null) && (infos != null))
            {
                foreach (FileSystemInfo info in infos)
                {
                    if (extensions.Exists(x => x.Equals(".*") || x.Equals(info.Extension, StringComparison.OrdinalIgnoreCase)))
                    {
                        list.Add(info);
                    }
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// 파일 목록에서 제외 확장자 파일 제거
        /// </summary>
        private IEnumerable<FileSystemInfo> CheckExcludeExtensionsList(IEnumerable<FileSystemInfo> infos)
        {
            List<FileSystemInfo> list = new List<FileSystemInfo>();

            foreach (FileSystemInfo info in infos)
            {
                if (ExcludeExtensions.Exists(x => x.Equals(info.Extension, StringComparison.OrdinalIgnoreCase)) == false)
                {
                    list.Add(info);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// 제외 경로에 포함된 팡리 제거
        /// </summary>
        /// <param name="infos">파일 목록</param>
        /// <param name="rootPath">검색 시작 위치</param>
        /// <returns></returns>
        private IEnumerable<FileSystemInfo> CheckExcludeDirectoryList(IEnumerable<FileSystemInfo> infos, string rootPath)
        {
            List<FileSystemInfo> list = new List<FileSystemInfo>();

            int rootPathLength = rootPath?.Length ?? 0;

            foreach (FileSystemInfo fsInfo in infos)
            {
                FileInfo info = new FileInfo(fsInfo.FullName);

                string dir = info.FullName.Remove(0, rootPathLength);

                bool skip = false;
                for(int index = 0; index < ExcludeDirectories.Count; ++index)
                {
                    string exclude = ExcludeDirectories[index];
                    if (exclude.StartsWith("\\"))
                    {
                        //전체 경로 검색
                        if (dir.StartsWith(exclude, StringComparison.OrdinalIgnoreCase))
                        {
                            skip = true;
                            break;
                        }
                    }
                    else
                    {
                        //경로 이름 포함 검색
                        if(dir.IndexOf(exclude, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            skip = true;
                            break;
                        }
                    }

                }

                if (skip)
                {
                    continue;
                }
                else
                {
                    list.Add(fsInfo);
                }
            }

            return list.ToArray();
        }

        private IEnumerable<FileSystemInfo> SortByClass(IEnumerable<FileSystemInfo> infos)
        {
            //정렬완료된 리스트
            List<FileSystemInfo> sortedInfos = new List<FileSystemInfo>();

            ///확장자별 2차원 리스트
            ///exe { , , }
            ///ini {, , }
            /// ....
            ///미분류 {, ,}
            List<List<FileSystemInfo>> sortList = new List<List<FileSystemInfo>>(extensionMapToClass.Keys.Count+1);
            for (int idx = 0; idx < sortList.Capacity; idx++)
                sortList.Add(new List<FileSystemInfo>());

            //분류 확장자 리스트
            List<string> extensionList = extensionMapToClass.Keys.ToList();

            //확장자별 분류
            foreach (FileSystemInfo info in infos)
            {
                int index;
                if((index = extensionList.IndexOf(info.Extension)) > -1)
                {
                    sortList[index].Add(info);
                }
                else
                {
                    sortList[extensionList.Count - 1].Add(info);
                }
            }

            foreach(List<FileSystemInfo> list in sortList)
            {
                sortedInfos.AddRange(list);
            }

            return sortedInfos;
        }

        private static IEnumerable<FileSystemInfo> ClusterByDir(IEnumerable<FileSystemInfo> infos)
        {
            List<FileSystemInfo> clusteredInfo = new List<FileSystemInfo>();
            Dictionary<string, List<FileSystemInfo>> dirDic = new Dictionary<string, List<FileSystemInfo>>();

            foreach (FileSystemInfo info in infos)
            {
                string dirName = Path.GetDirectoryName(info.FullName);

                if (!dirDic.ContainsKey(dirName))
                    dirDic.Add(dirName, new List<FileSystemInfo>());

                dirDic[dirName].Add(info);
            }
            
            //디렉토리 길이기준으로 오름차순 정렬
            List<string> dirNames = dirDic.Keys.ToList();
            IEnumerable<string> sortedDir = from dir in dirNames orderby dir.Length ascending select dir;

            //정렬된 디렉토리 리스트로 파일정보 가져오기
            foreach (string dir in sortedDir)
            {
                if (dirDic[dir] != null)
                {
                    clusteredInfo.AddRange(dirDic[dir]);
                }
            }

            return clusteredInfo;
        }

        private void ButtonConfig_Click(object sender, EventArgs e)
        {
            using (ConfigForm configForm = new ConfigForm())
            {
                configForm.ActionLoadExtensionList = () =>
                {
                    extensionMapToClass = LoadFileClassRule(classByExtensionPath);
                    subStringMapToClass = LoadFileClassRule(classBySubStringPath);
                    configForm.SetExtensionList(extensionMapToClass);
                };
                configForm.ActionSaveExtensionList = () =>
                {
                    extensionMapToClass = configForm.GetExtensionMap();
                    SaveFileClassRule(extensionMapToClass, classByExtensionPath);
                };
                configForm.ActionLoadExcludeExtensions = () =>
                {
                    ExcludeExtensions = LoadFileExtensions(excludeExtensionFilePath);
                    configForm.SetExcludeExtensions(ExcludeExtensions);
                };
                configForm.ActionSaveExcludeExtensions = () =>
                {
                    ExcludeExtensions = configForm.GetExcludeExtensions();
                    SaveFileExtensions(ExcludeExtensions, excludeExtensionFilePath);
                };
                configForm.ActionLoadExcludeDirectories = () =>
                {
                    ExcludeDirectories = LoadDirectories(excludeDirectoriesFilePath);
                    configForm.SetExcludeDirectories(ExcludeDirectories);
                };
                configForm.ActionSaveExcludeDirectories = () =>
                {
                    ExcludeDirectories = configForm.GetExcludeDirectories();
                    SaveFileExtensions(ExcludeDirectories, excludeDirectoriesFilePath);
                };
                configForm.ActionLoadSourceExtensions = () =>
                {
                    SourceExtensions = LoadFileExtensions(sourceExtensionFilePath);
                    configForm.SetSourceExtensions(SourceExtensions);
                };
                configForm.ActionSaveSourceExtensions = () =>
                {
                    SourceExtensions = configForm.GetSourceExtensions();
                    SaveFileExtensions(SourceExtensions, sourceExtensionFilePath);
                };
                configForm.ActionLoadProjectExtensions = () =>
                {
                    ProjectExtensions = LoadFileExtensions(projectExtensionFilePath);
                    configForm.SetProjectExtensions(ProjectExtensions);
                };
                configForm.ActionSaveProjectExtensions = () =>
                {
                    ProjectExtensions = configForm.GetProjectExtensions();
                    SaveFileExtensions(ProjectExtensions, projectExtensionFilePath);
                };
                configForm.ActionLoadLineExtensions = () =>
                {
                    LineExtensions = LoadFileExtensions(lineExtensionFilePath);
                    configForm.SetLineExtensions(LineExtensions);
                };
                configForm.ActionSaveLineExtensions = () =>
                {
                    LineExtensions = configForm.GetLineExtensions();
                    SaveFileExtensions(LineExtensions, lineExtensionFilePath);
                };

                configForm.ActionLoadExtensionList?.Invoke();
                configForm.ActionLoadExcludeExtensions?.Invoke();
                configForm.ActionLoadExcludeDirectories?.Invoke();
                configForm.ActionLoadSourceExtensions?.Invoke();
                configForm.ActionLoadProjectExtensions?.Invoke();
                configForm.ActionLoadLineExtensions?.Invoke();

                configForm.ShowDialog();
            }
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabel.LinkVisited = true;
                System.Diagnostics.Process.Start(linkLabel.Text);
            }
            catch (Exception)
            {
            }
        }
    }
}

#pragma warning restore CA1031 // 일반적인 예외 형식을 catch하지 마세요.
#pragma warning restore CA1304 // CultureInfo를 지정하세요.
#pragma warning restore CA1305 // IFormatProvider를 지정하세요.
#pragma warning restore CA1307 // StringComparison을 지정하세요.