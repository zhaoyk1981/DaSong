namespace AutoSC
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl预计手数 = new System.Windows.Forms.Label();
            this.Lbl手续费 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtStartTradeTime = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.TxtKeepEHE = new System.Windows.Forms.TextBox();
            this.TxtEHEUnitPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtTHSCUnitPrice = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Txt较大亏损 = new System.Windows.Forms.TextBox();
            this.Txt暂停分钟 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TxtEndTradeTime = new System.Windows.Forms.MaskedTextBox();
            this.ChkBuyEHE = new System.Windows.Forms.CheckBox();
            this.DdlMethods = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DdlBrowser = new System.Windows.Forms.ComboBox();
            this.TxtTradePassword = new System.Windows.Forms.TextBox();
            this.BtnMax = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.Txt结束手数 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TxtMessage = new System.Windows.Forms.TextBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnPause = new System.Windows.Forms.Button();
            this.BtnLoadOrderHistory = new System.Windows.Forms.Button();
            this.LblSellTHSC = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Lbl总手数 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.LblMethod = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblCompleted = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblProfit = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl预计手数
            // 
            this.Lbl预计手数.AutoSize = true;
            this.Lbl预计手数.Location = new System.Drawing.Point(252, 90);
            this.Lbl预计手数.Name = "Lbl预计手数";
            this.Lbl预计手数.Size = new System.Drawing.Size(35, 18);
            this.Lbl预计手数.TabIndex = 30;
            this.Lbl预计手数.Text = "N/A";
            // 
            // Lbl手续费
            // 
            this.Lbl手续费.AutoSize = true;
            this.Lbl手续费.Location = new System.Drawing.Point(538, 38);
            this.Lbl手续费.Name = "Lbl手续费";
            this.Lbl手续费.Size = new System.Drawing.Size(35, 18);
            this.Lbl手续费.TabIndex = 28;
            this.Lbl手续费.Text = "N/A";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 18);
            this.label15.TabIndex = 311;
            this.label15.Text = "手数：";
            // 
            // TxtStartTradeTime
            // 
            this.TxtStartTradeTime.Location = new System.Drawing.Point(387, 100);
            this.TxtStartTradeTime.Margin = new System.Windows.Forms.Padding(4);
            this.TxtStartTradeTime.Mask = "90:00";
            this.TxtStartTradeTime.Name = "TxtStartTradeTime";
            this.TxtStartTradeTime.Size = new System.Drawing.Size(60, 28);
            this.TxtStartTradeTime.TabIndex = 60;
            this.TxtStartTradeTime.ValidatingType = typeof(System.DateTime);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 18);
            this.label10.TabIndex = 23;
            this.label10.Text = "交易时间：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.TxtKeepEHE);
            this.groupBox4.Controls.Add(this.TxtEHEUnitPrice);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.TxtTHSCUnitPrice);
            this.groupBox4.Location = new System.Drawing.Point(218, 295);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(318, 132);
            this.groupBox4.TabIndex = 1005;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "仅卖出选项";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(51, 98);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 18);
            this.label19.TabIndex = 1002;
            this.label19.Text = "保留EHE：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 18);
            this.label17.TabIndex = 311;
            this.label17.Text = "EHE最低单价：";
            // 
            // TxtKeepEHE
            // 
            this.TxtKeepEHE.Location = new System.Drawing.Point(156, 96);
            this.TxtKeepEHE.Name = "TxtKeepEHE";
            this.TxtKeepEHE.Size = new System.Drawing.Size(121, 28);
            this.TxtKeepEHE.TabIndex = 330;
            // 
            // TxtEHEUnitPrice
            // 
            this.TxtEHEUnitPrice.Location = new System.Drawing.Point(156, 60);
            this.TxtEHEUnitPrice.Name = "TxtEHEUnitPrice";
            this.TxtEHEUnitPrice.Size = new System.Drawing.Size(121, 28);
            this.TxtEHEUnitPrice.TabIndex = 320;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "THSC最低单价：";
            // 
            // TxtTHSCUnitPrice
            // 
            this.TxtTHSCUnitPrice.Location = new System.Drawing.Point(156, 26);
            this.TxtTHSCUnitPrice.Name = "TxtTHSCUnitPrice";
            this.TxtTHSCUnitPrice.Size = new System.Drawing.Size(121, 28);
            this.TxtTHSCUnitPrice.TabIndex = 310;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.Txt较大亏损);
            this.groupBox3.Controls.Add(this.Txt暂停分钟);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(542, 295);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 132);
            this.groupBox3.TabIndex = 1004;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "买入选项";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 18);
            this.label11.TabIndex = 121;
            this.label11.Text = "较大亏损(EHE)：";
            // 
            // Txt较大亏损
            // 
            this.Txt较大亏损.Location = new System.Drawing.Point(170, 27);
            this.Txt较大亏损.Name = "Txt较大亏损";
            this.Txt较大亏损.Size = new System.Drawing.Size(74, 28);
            this.Txt较大亏损.TabIndex = 210;
            // 
            // Txt暂停分钟
            // 
            this.Txt暂停分钟.Location = new System.Drawing.Point(170, 60);
            this.Txt暂停分钟.Name = "Txt暂停分钟";
            this.Txt暂停分钟.Size = new System.Drawing.Size(74, 28);
            this.Txt暂停分钟.TabIndex = 220;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(58, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 18);
            this.label12.TabIndex = 123;
            this.label12.Text = "暂停分钟：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.TxtEndTradeTime);
            this.groupBox2.Controls.Add(this.ChkBuyEHE);
            this.groupBox2.Controls.Add(this.DdlMethods);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TxtStartTradeTime);
            this.groupBox2.Controls.Add(this.TxtUserName);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TxtPassword);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.DdlBrowser);
            this.groupBox2.Controls.Add(this.TxtTradePassword);
            this.groupBox2.Location = new System.Drawing.Point(9, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(788, 142);
            this.groupBox2.TabIndex = 1003;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "帐号";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(453, 104);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 18);
            this.label20.TabIndex = 63;
            this.label20.Text = "至";
            // 
            // TxtEndTradeTime
            // 
            this.TxtEndTradeTime.Location = new System.Drawing.Point(486, 100);
            this.TxtEndTradeTime.Margin = new System.Windows.Forms.Padding(4);
            this.TxtEndTradeTime.Mask = "90:00";
            this.TxtEndTradeTime.Name = "TxtEndTradeTime";
            this.TxtEndTradeTime.Size = new System.Drawing.Size(60, 28);
            this.TxtEndTradeTime.TabIndex = 62;
            this.TxtEndTradeTime.ValidatingType = typeof(System.DateTime);
            // 
            // ChkBuyEHE
            // 
            this.ChkBuyEHE.AutoSize = true;
            this.ChkBuyEHE.Location = new System.Drawing.Point(94, 104);
            this.ChkBuyEHE.Name = "ChkBuyEHE";
            this.ChkBuyEHE.Size = new System.Drawing.Size(97, 22);
            this.ChkBuyEHE.TabIndex = 61;
            this.ChkBuyEHE.Text = "购买EHE";
            this.ChkBuyEHE.UseVisualStyleBackColor = true;
            // 
            // DdlMethods
            // 
            this.DdlMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DdlMethods.FormattingEnabled = true;
            this.DdlMethods.Location = new System.Drawing.Point(94, 64);
            this.DdlMethods.Name = "DdlMethods";
            this.DdlMethods.Size = new System.Drawing.Size(175, 26);
            this.DdlMethods.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "策略：";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(387, 28);
            this.TxtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(392, 28);
            this.TxtUserName.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "浏览器：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "登录密码：";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(387, 64);
            this.TxtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(166, 28);
            this.TxtPassword.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "资金密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "钱包地址：";
            // 
            // DdlBrowser
            // 
            this.DdlBrowser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DdlBrowser.FormattingEnabled = true;
            this.DdlBrowser.Location = new System.Drawing.Point(94, 28);
            this.DdlBrowser.Name = "DdlBrowser";
            this.DdlBrowser.Size = new System.Drawing.Size(175, 26);
            this.DdlBrowser.TabIndex = 40;
            // 
            // TxtTradePassword
            // 
            this.TxtTradePassword.Location = new System.Drawing.Point(668, 64);
            this.TxtTradePassword.Margin = new System.Windows.Forms.Padding(4);
            this.TxtTradePassword.Name = "TxtTradePassword";
            this.TxtTradePassword.PasswordChar = '*';
            this.TxtTradePassword.Size = new System.Drawing.Size(114, 28);
            this.TxtTradePassword.TabIndex = 30;
            // 
            // BtnMax
            // 
            this.BtnMax.Location = new System.Drawing.Point(249, 435);
            this.BtnMax.Margin = new System.Windows.Forms.Padding(4);
            this.BtnMax.Name = "BtnMax";
            this.BtnMax.Size = new System.Drawing.Size(112, 39);
            this.BtnMax.TabIndex = 1009;
            this.BtnMax.Text = "窗口化";
            this.BtnMax.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(158, 90);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 18);
            this.label18.TabIndex = 29;
            this.label18.Text = "预计手数:";
            // 
            // Txt结束手数
            // 
            this.Txt结束手数.Location = new System.Drawing.Point(80, 28);
            this.Txt结束手数.Name = "Txt结束手数";
            this.Txt结束手数.Size = new System.Drawing.Size(102, 28);
            this.Txt结束手数.TabIndex = 410;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(460, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 18);
            this.label16.TabIndex = 27;
            this.label16.Text = "手续费:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.Txt结束手数);
            this.groupBox5.Location = new System.Drawing.Point(11, 295);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(201, 134);
            this.groupBox5.TabIndex = 1011;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "结束条件";
            // 
            // TxtMessage
            // 
            this.TxtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtMessage.BackColor = System.Drawing.Color.White;
            this.TxtMessage.Location = new System.Drawing.Point(11, 483);
            this.TxtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.ReadOnly = true;
            this.TxtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtMessage.Size = new System.Drawing.Size(787, 230);
            this.TxtMessage.TabIndex = 1010;
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(9, 435);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(4);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(112, 39);
            this.BtnStart.TabIndex = 1006;
            this.BtnStart.Text = "开始";
            this.BtnStart.UseVisualStyleBackColor = true;
            // 
            // BtnPause
            // 
            this.BtnPause.Location = new System.Drawing.Point(369, 435);
            this.BtnPause.Margin = new System.Windows.Forms.Padding(4);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(112, 39);
            this.BtnPause.TabIndex = 1007;
            this.BtnPause.Text = "暂停";
            this.BtnPause.UseVisualStyleBackColor = true;
            // 
            // BtnLoadOrderHistory
            // 
            this.BtnLoadOrderHistory.Location = new System.Drawing.Point(129, 435);
            this.BtnLoadOrderHistory.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLoadOrderHistory.Name = "BtnLoadOrderHistory";
            this.BtnLoadOrderHistory.Size = new System.Drawing.Size(112, 39);
            this.BtnLoadOrderHistory.TabIndex = 1008;
            this.BtnLoadOrderHistory.Text = "交易记录";
            this.BtnLoadOrderHistory.UseVisualStyleBackColor = true;
            // 
            // LblSellTHSC
            // 
            this.LblSellTHSC.AutoSize = true;
            this.LblSellTHSC.Location = new System.Drawing.Point(392, 38);
            this.LblSellTHSC.Name = "LblSellTHSC";
            this.LblSellTHSC.Size = new System.Drawing.Size(35, 18);
            this.LblSellTHSC.TabIndex = 26;
            this.LblSellTHSC.Text = "N/A";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(315, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 18);
            this.label14.TabIndex = 25;
            this.label14.Text = "卖出币:";
            // 
            // Lbl总手数
            // 
            this.Lbl总手数.AutoSize = true;
            this.Lbl总手数.Location = new System.Drawing.Point(100, 90);
            this.Lbl总手数.Name = "Lbl总手数";
            this.Lbl总手数.Size = new System.Drawing.Size(35, 18);
            this.Lbl总手数.TabIndex = 24;
            this.Lbl总手数.Text = "N/A";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 18);
            this.label13.TabIndex = 23;
            this.label13.Text = "已刷手数:";
            // 
            // LblMethod
            // 
            this.LblMethod.AutoSize = true;
            this.LblMethod.Location = new System.Drawing.Point(384, 90);
            this.LblMethod.Name = "LblMethod";
            this.LblMethod.Size = new System.Drawing.Size(35, 18);
            this.LblMethod.TabIndex = 22;
            this.LblMethod.Text = "N/A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(326, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 18);
            this.label9.TabIndex = 21;
            this.label9.Text = "策略:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "已完成:";
            // 
            // LblCompleted
            // 
            this.LblCompleted.AutoSize = true;
            this.LblCompleted.Location = new System.Drawing.Point(82, 38);
            this.LblCompleted.Name = "LblCompleted";
            this.LblCompleted.Size = new System.Drawing.Size(35, 18);
            this.LblCompleted.TabIndex = 18;
            this.LblCompleted.Text = "N/A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(171, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "利润:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Lbl预计手数);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.Lbl手续费);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.LblSellTHSC);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.Lbl总手数);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.LblMethod);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.LblProfit);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.LblCompleted);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(11, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 132);
            this.groupBox1.TabIndex = 1002;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计信息";
            // 
            // LblProfit
            // 
            this.LblProfit.AutoSize = true;
            this.LblProfit.Location = new System.Drawing.Point(230, 38);
            this.LblProfit.Name = "LblProfit";
            this.LblProfit.Size = new System.Drawing.Size(35, 18);
            this.LblProfit.TabIndex = 20;
            this.LblProfit.Text = "N/A";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(808, 722);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnMax);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnPause);
            this.Controls.Add(this.BtnLoadOrderHistory);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl预计手数;
        private System.Windows.Forms.Label Lbl手续费;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox TxtStartTradeTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TxtKeepEHE;
        private System.Windows.Forms.TextBox TxtEHEUnitPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtTHSCUnitPrice;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Txt较大亏损;
        private System.Windows.Forms.TextBox Txt暂停分钟;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox TxtEndTradeTime;
        private System.Windows.Forms.CheckBox ChkBuyEHE;
        private System.Windows.Forms.ComboBox DdlMethods;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DdlBrowser;
        private System.Windows.Forms.TextBox TxtTradePassword;
        private System.Windows.Forms.Button BtnMax;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox Txt结束手数;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnPause;
        private System.Windows.Forms.Button BtnLoadOrderHistory;
        private System.Windows.Forms.Label LblSellTHSC;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Lbl总手数;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label LblMethod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblCompleted;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblProfit;
    }
}

