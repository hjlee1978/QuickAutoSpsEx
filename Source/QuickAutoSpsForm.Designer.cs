namespace FileInfoExtractor
{
    partial class QuickAutoSpsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();

                if (_crc32 != null)
                {
                    _crc32.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickAutoSpsForm));
            this.startExtract = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.lbFile = new System.Windows.Forms.Label();
            this.btDisplayResult = new System.Windows.Forms.Button();
            this.cbAutoRun = new System.Windows.Forms.CheckBox();
            this.panelTopic = new System.Windows.Forms.Panel();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.tbEtcNumberBase = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbTableHeaderSet = new System.Windows.Forms.CheckBox();
            this.lbDelText = new System.Windows.Forms.Label();
            this.cbUseUpper = new System.Windows.Forms.CheckBox();
            this.tbPathDel = new System.Windows.Forms.TextBox();
            this.tbPathHead = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelPathHead = new System.Windows.Forms.Label();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLibNumberBase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbExeNumberbase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbSrcTypeProject = new System.Windows.Forms.RadioButton();
            this.rbSrcTypeExe = new System.Windows.Forms.RadioButton();
            this.rbSrcTypeSrc = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbRetTypeHwp = new System.Windows.Forms.RadioButton();
            this.rbRetTypeExl = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbResultName = new System.Windows.Forms.TextBox();
            this.resultDirPath = new System.Windows.Forms.Button();
            this.tbResultPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.extractDirPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbExtractPath = new System.Windows.Forms.TextBox();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.axHwpCtrl = new AxHWPCONTROLLib.AxHwpCtrl();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelTopic.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axHwpCtrl)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // startExtract
            // 
            this.startExtract.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startExtract.Location = new System.Drawing.Point(417, 9);
            this.startExtract.Name = "startExtract";
            this.startExtract.Size = new System.Drawing.Size(75, 23);
            this.startExtract.TabIndex = 0;
            this.startExtract.Text = "추출 시작";
            this.startExtract.UseVisualStyleBackColor = true;
            this.startExtract.Click += new System.EventHandler(this.StartExtract_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(498, 9);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "닫기";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // lbFile
            // 
            this.lbFile.AutoSize = true;
            this.lbFile.Location = new System.Drawing.Point(76, 597);
            this.lbFile.Name = "lbFile";
            this.lbFile.Size = new System.Drawing.Size(9, 12);
            this.lbFile.TabIndex = 13;
            this.lbFile.Text = " ";
            this.lbFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btDisplayResult
            // 
            this.btDisplayResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btDisplayResult.Location = new System.Drawing.Point(9, 9);
            this.btDisplayResult.Name = "btDisplayResult";
            this.btDisplayResult.Size = new System.Drawing.Size(75, 23);
            this.btDisplayResult.TabIndex = 14;
            this.btDisplayResult.Text = "결과 보기";
            this.btDisplayResult.UseVisualStyleBackColor = true;
            this.btDisplayResult.Visible = false;
            this.btDisplayResult.Click += new System.EventHandler(this.BtDisplayResult_Click);
            // 
            // cbAutoRun
            // 
            this.cbAutoRun.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbAutoRun.AutoSize = true;
            this.cbAutoRun.Location = new System.Drawing.Point(269, 13);
            this.cbAutoRun.Margin = new System.Windows.Forms.Padding(1);
            this.cbAutoRun.Name = "cbAutoRun";
            this.cbAutoRun.Size = new System.Drawing.Size(132, 16);
            this.cbAutoRun.TabIndex = 15;
            this.cbAutoRun.Text = "결과 파일 자동 실행";
            this.cbAutoRun.UseVisualStyleBackColor = true;
            // 
            // panelTopic
            // 
            this.panelTopic.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTopic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopic.Controls.Add(this.linkLabel);
            this.panelTopic.Controls.Add(this.label12);
            this.panelTopic.Controls.Add(this.labelInfo);
            this.panelTopic.Controls.Add(this.label9);
            this.panelTopic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopic.Location = new System.Drawing.Point(5, 5);
            this.panelTopic.Margin = new System.Windows.Forms.Padding(5);
            this.panelTopic.Name = "panelTopic";
            this.panelTopic.Size = new System.Drawing.Size(584, 115);
            this.panelTopic.TabIndex = 17;
            // 
            // linkLabel
            // 
            this.linkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(48, 91);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(268, 12);
            this.linkLabel.TabIndex = 5;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "https://github.com/hjlee1978/QuickAutoSpsEx";
            this.linkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(8, 91);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Fork : ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfo.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelInfo.Location = new System.Drawing.Point(8, 38);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(567, 47);
            this.labelInfo.TabIndex = 2;
            this.labelInfo.Text = "본 SW는 QuickAutoSps(https://github.com/FirstecRepo/QuickAutoSps)를 기반으로 제작되었습니다.\r\nQ" +
    "uickAutoSps는 소프트웨어 산출물 명세서 작성의 효율성을 높이기 위해 개발 되었으며, LGPL 2.1 라이선스 정책에 따라 공개되는 자유" +
    " 소프트웨어 입니다.\r\n";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(8, 7);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 25);
            this.label9.TabIndex = 1;
            this.label9.Text = "QuickAutoSpsEx";
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.groupBox3);
            this.panelMiddle.Controls.Add(this.groupBox1);
            this.panelMiddle.Controls.Add(this.groupBox2);
            this.panelMiddle.Controls.Add(this.pbProgress);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(5, 120);
            this.panelMiddle.Margin = new System.Windows.Forms.Padding(5);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(584, 501);
            this.panelMiddle.TabIndex = 18;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.buttonConfig);
            this.groupBox3.Controls.Add(this.tbEtcNumberBase);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cbTableHeaderSet);
            this.groupBox3.Controls.Add(this.lbDelText);
            this.groupBox3.Controls.Add(this.cbUseUpper);
            this.groupBox3.Controls.Add(this.tbPathDel);
            this.groupBox3.Controls.Add(this.tbPathHead);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.labelPathHead);
            this.groupBox3.Controls.Add(this.tbVersion);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbLibNumberBase);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbExeNumberbase);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(14, 233);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(558, 238);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "정보 추출 설정";
            // 
            // buttonConfig
            // 
            this.buttonConfig.Location = new System.Drawing.Point(10, 70);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonConfig.TabIndex = 10;
            this.buttonConfig.Text = "설정";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.ButtonConfig_Click);
            // 
            // tbEtcNumberBase
            // 
            this.tbEtcNumberBase.Location = new System.Drawing.Point(436, 72);
            this.tbEtcNumberBase.Name = "tbEtcNumberBase";
            this.tbEtcNumberBase.Size = new System.Drawing.Size(100, 21);
            this.tbEtcNumberBase.TabIndex = 16;
            this.tbEtcNumberBase.Text = "C";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(328, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "기타파일 부품번호";
            // 
            // cbTableHeaderSet
            // 
            this.cbTableHeaderSet.AutoSize = true;
            this.cbTableHeaderSet.Location = new System.Drawing.Point(22, 106);
            this.cbTableHeaderSet.Margin = new System.Windows.Forms.Padding(1);
            this.cbTableHeaderSet.Name = "cbTableHeaderSet";
            this.cbTableHeaderSet.Size = new System.Drawing.Size(148, 16);
            this.cbTableHeaderSet.TabIndex = 14;
            this.cbTableHeaderSet.Text = "한글 제목 셀 자동 반복";
            this.cbTableHeaderSet.UseVisualStyleBackColor = true;
            // 
            // lbDelText
            // 
            this.lbDelText.AutoSize = true;
            this.lbDelText.ForeColor = System.Drawing.Color.Red;
            this.lbDelText.Location = new System.Drawing.Point(155, 204);
            this.lbDelText.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbDelText.Name = "lbDelText";
            this.lbDelText.Size = new System.Drawing.Size(141, 12);
            this.lbDelText.TabIndex = 13;
            this.lbDelText.Text = "삭제할 문자열이 잘못 됨.";
            this.lbDelText.Visible = false;
            // 
            // cbUseUpper
            // 
            this.cbUseUpper.AutoSize = true;
            this.cbUseUpper.Location = new System.Drawing.Point(21, 127);
            this.cbUseUpper.Margin = new System.Windows.Forms.Padding(1);
            this.cbUseUpper.Name = "cbUseUpper";
            this.cbUseUpper.Size = new System.Drawing.Size(100, 16);
            this.cbUseUpper.TabIndex = 12;
            this.cbUseUpper.Text = "대문자로 변경";
            this.cbUseUpper.UseVisualStyleBackColor = true;
            // 
            // tbPathDel
            // 
            this.tbPathDel.Location = new System.Drawing.Point(153, 173);
            this.tbPathDel.Name = "tbPathDel";
            this.tbPathDel.Size = new System.Drawing.Size(387, 21);
            this.tbPathDel.TabIndex = 11;
            this.tbPathDel.TextChanged += new System.EventHandler(this.LbDelText_TextChanged);
            // 
            // tbPathHead
            // 
            this.tbPathHead.Location = new System.Drawing.Point(153, 150);
            this.tbPathHead.Name = "tbPathHead";
            this.tbPathHead.Size = new System.Drawing.Size(387, 21);
            this.tbPathHead.TabIndex = 10;
            this.tbPathHead.Text = "저장위치 : \\SW-00000000-EXE-R0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "파일경로 삭제문자열";
            // 
            // labelPathHead
            // 
            this.labelPathHead.AutoSize = true;
            this.labelPathHead.Location = new System.Drawing.Point(45, 152);
            this.labelPathHead.Name = "labelPathHead";
            this.labelPathHead.Size = new System.Drawing.Size(93, 12);
            this.labelPathHead.TabIndex = 8;
            this.labelPathHead.Text = "파일경로 접두어";
            // 
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(436, 99);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(100, 21);
            this.tbVersion.TabIndex = 7;
            this.tbVersion.Text = "1.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "버전";
            // 
            // tbLibNumberBase
            // 
            this.tbLibNumberBase.Location = new System.Drawing.Point(436, 45);
            this.tbLibNumberBase.Name = "tbLibNumberBase";
            this.tbLibNumberBase.Size = new System.Drawing.Size(100, 21);
            this.tbLibNumberBase.TabIndex = 5;
            this.tbLibNumberBase.Text = "L";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "라이브러리 부품번호";
            // 
            // tbExeNumberbase
            // 
            this.tbExeNumberbase.Location = new System.Drawing.Point(436, 17);
            this.tbExeNumberbase.Name = "tbExeNumberbase";
            this.tbExeNumberbase.Size = new System.Drawing.Size(100, 21);
            this.tbExeNumberbase.TabIndex = 5;
            this.tbExeNumberbase.Tag = "";
            this.tbExeNumberbase.Text = "E";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "실행파일 부품번호";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbSrcTypeProject);
            this.groupBox4.Controls.Add(this.rbSrcTypeExe);
            this.groupBox4.Controls.Add(this.rbSrcTypeSrc);
            this.groupBox4.Location = new System.Drawing.Point(6, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(285, 45);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "소스 타입";
            // 
            // rbSrcTypeProject
            // 
            this.rbSrcTypeProject.AutoSize = true;
            this.rbSrcTypeProject.Location = new System.Drawing.Point(168, 20);
            this.rbSrcTypeProject.Name = "rbSrcTypeProject";
            this.rbSrcTypeProject.Size = new System.Drawing.Size(71, 16);
            this.rbSrcTypeProject.TabIndex = 2;
            this.rbSrcTypeProject.TabStop = true;
            this.rbSrcTypeProject.Text = "프로젝트";
            this.rbSrcTypeProject.UseVisualStyleBackColor = true;
            // 
            // rbSrcTypeExe
            // 
            this.rbSrcTypeExe.AutoSize = true;
            this.rbSrcTypeExe.Location = new System.Drawing.Point(14, 20);
            this.rbSrcTypeExe.Name = "rbSrcTypeExe";
            this.rbSrcTypeExe.Size = new System.Drawing.Size(71, 16);
            this.rbSrcTypeExe.TabIndex = 1;
            this.rbSrcTypeExe.TabStop = true;
            this.rbSrcTypeExe.Text = "실행파일";
            this.rbSrcTypeExe.UseVisualStyleBackColor = true;
            // 
            // rbSrcTypeSrc
            // 
            this.rbSrcTypeSrc.AutoSize = true;
            this.rbSrcTypeSrc.Location = new System.Drawing.Point(91, 20);
            this.rbSrcTypeSrc.Name = "rbSrcTypeSrc";
            this.rbSrcTypeSrc.Size = new System.Drawing.Size(71, 16);
            this.rbSrcTypeSrc.TabIndex = 0;
            this.rbSrcTypeSrc.TabStop = true;
            this.rbSrcTypeSrc.Text = "소스파일";
            this.rbSrcTypeSrc.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbResultName);
            this.groupBox1.Controls.Add(this.resultDirPath);
            this.groupBox1.Controls.Add(this.tbResultPath);
            this.groupBox1.Location = new System.Drawing.Point(14, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 158);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "결과 파일";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbRetTypeHwp);
            this.groupBox5.Controls.Add(this.rbRetTypeExl);
            this.groupBox5.Location = new System.Drawing.Point(10, 25);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(171, 45);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "결과 파일 종류";
            // 
            // rbRetTypeHwp
            // 
            this.rbRetTypeHwp.AutoSize = true;
            this.rbRetTypeHwp.Location = new System.Drawing.Point(14, 20);
            this.rbRetTypeHwp.Name = "rbRetTypeHwp";
            this.rbRetTypeHwp.Size = new System.Drawing.Size(47, 16);
            this.rbRetTypeHwp.TabIndex = 1;
            this.rbRetTypeHwp.TabStop = true;
            this.rbRetTypeHwp.Text = "한글";
            this.rbRetTypeHwp.UseVisualStyleBackColor = true;
            this.rbRetTypeHwp.CheckedChanged += new System.EventHandler(this.RbRetTypeHwp_CheckedChanged);
            // 
            // rbRetTypeExl
            // 
            this.rbRetTypeExl.AutoSize = true;
            this.rbRetTypeExl.Location = new System.Drawing.Point(91, 20);
            this.rbRetTypeExl.Name = "rbRetTypeExl";
            this.rbRetTypeExl.Size = new System.Drawing.Size(47, 16);
            this.rbRetTypeExl.TabIndex = 0;
            this.rbRetTypeExl.TabStop = true;
            this.rbRetTypeExl.Text = "엑셀";
            this.rbRetTypeExl.UseVisualStyleBackColor = true;
            this.rbRetTypeExl.CheckedChanged += new System.EventHandler(this.RbRetTypeExl_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "파일 이름 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "경로 :";
            // 
            // tbResultName
            // 
            this.tbResultName.Location = new System.Drawing.Point(112, 109);
            this.tbResultName.Name = "tbResultName";
            this.tbResultName.Size = new System.Drawing.Size(343, 21);
            this.tbResultName.TabIndex = 8;
            // 
            // resultDirPath
            // 
            this.resultDirPath.Location = new System.Drawing.Point(461, 79);
            this.resultDirPath.Name = "resultDirPath";
            this.resultDirPath.Size = new System.Drawing.Size(75, 23);
            this.resultDirPath.TabIndex = 3;
            this.resultDirPath.Text = "탐색";
            this.resultDirPath.UseVisualStyleBackColor = true;
            this.resultDirPath.Click += new System.EventHandler(this.ResultDirPath_Click);
            // 
            // tbResultPath
            // 
            this.tbResultPath.Location = new System.Drawing.Point(112, 81);
            this.tbResultPath.Name = "tbResultPath";
            this.tbResultPath.Size = new System.Drawing.Size(343, 21);
            this.tbResultPath.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.extractDirPath);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbExtractPath);
            this.groupBox2.Location = new System.Drawing.Point(14, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 80);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "소스 경로";
            // 
            // extractDirPath
            // 
            this.extractDirPath.Location = new System.Drawing.Point(461, 29);
            this.extractDirPath.Name = "extractDirPath";
            this.extractDirPath.Size = new System.Drawing.Size(75, 23);
            this.extractDirPath.TabIndex = 2;
            this.extractDirPath.Tag = "";
            this.extractDirPath.Text = "탐색";
            this.extractDirPath.UseVisualStyleBackColor = true;
            this.extractDirPath.Click += new System.EventHandler(this.ExtractDirPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "경로 : ";
            // 
            // tbExtractPath
            // 
            this.tbExtractPath.Location = new System.Drawing.Point(112, 31);
            this.tbExtractPath.Name = "tbExtractPath";
            this.tbExtractPath.Size = new System.Drawing.Size(343, 21);
            this.tbExtractPath.TabIndex = 6;
            // 
            // pbProgress
            // 
            this.pbProgress.Image = ((System.Drawing.Image)(resources.GetObject("pbProgress.Image")));
            this.pbProgress.Location = new System.Drawing.Point(14, 477);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(45, 12);
            this.pbProgress.TabIndex = 18;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // axHwpCtrl
            // 
            this.axHwpCtrl.Enabled = true;
            this.axHwpCtrl.Location = new System.Drawing.Point(294, 946);
            this.axHwpCtrl.Margin = new System.Windows.Forms.Padding(1);
            this.axHwpCtrl.Name = "axHwpCtrl";
            this.axHwpCtrl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axHwpCtrl.OcxState")));
            this.axHwpCtrl.Size = new System.Drawing.Size(100, 50);
            this.axHwpCtrl.TabIndex = 16;
            this.axHwpCtrl.Visible = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.cbAutoRun);
            this.panelBottom.Controls.Add(this.startExtract);
            this.panelBottom.Controls.Add(this.buttonClose);
            this.panelBottom.Controls.Add(this.btDisplayResult);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(5, 621);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(584, 42);
            this.panelBottom.TabIndex = 19;
            // 
            // QuickAutoSpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(594, 668);
            this.Controls.Add(this.axHwpCtrl);
            this.Controls.Add(this.lbFile);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTopic);
            this.Controls.Add(this.panelBottom);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(610, 690);
            this.Name = "QuickAutoSpsForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "/";
            this.Load += new System.EventHandler(this.QuickAutoSpsForm_Load);
            this.Shown += new System.EventHandler(this.QuickAutoSpsForm_Shown);
            this.panelTopic.ResumeLayout(false);
            this.panelTopic.PerformLayout();
            this.panelMiddle.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axHwpCtrl)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startExtract;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label lbFile;
        private System.Windows.Forms.Button btDisplayResult;
        private AxHWPCONTROLLib.AxHwpCtrl axHwpCtrl;
        private System.Windows.Forms.CheckBox cbAutoRun;
        private System.Windows.Forms.Panel panelTopic;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonConfig;
        private System.Windows.Forms.TextBox tbEtcNumberBase;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cbTableHeaderSet;
        private System.Windows.Forms.Label lbDelText;
        private System.Windows.Forms.CheckBox cbUseUpper;
        private System.Windows.Forms.TextBox tbPathDel;
        private System.Windows.Forms.TextBox tbPathHead;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelPathHead;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLibNumberBase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbExeNumberbase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbSrcTypeExe;
        private System.Windows.Forms.RadioButton rbSrcTypeSrc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbRetTypeHwp;
        private System.Windows.Forms.RadioButton rbRetTypeExl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbResultName;
        private System.Windows.Forms.Button resultDirPath;
        private System.Windows.Forms.TextBox tbResultPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button extractDirPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbExtractPath;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.RadioButton rbSrcTypeProject;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

