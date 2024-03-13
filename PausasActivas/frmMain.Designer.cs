namespace PausasActivas
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuMain = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            configToolStripMenuItem = new ToolStripMenuItem();
            historyToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            grpbxStart = new GroupBox();
            timeToStart = new DateTimePicker();
            txtDelayInitMinutes = new TextBox();
            trackBarDelay = new TrackBar();
            rdbtnStartAt = new RadioButton();
            rdbtnStartIn = new RadioButton();
            grpbxEnd = new GroupBox();
            cmbQRepeats = new ComboBox();
            cmbQHours = new ComboBox();
            timeToEnd = new DateTimePicker();
            rdbtnStopAt = new RadioButton();
            rdbtnStopInQHours = new RadioButton();
            rdbtnStopInQRepeats = new RadioButton();
            btnStart = new Button();
            btnStop = new Button();
            grpbxTimes = new GroupBox();
            cmbRepeat = new ComboBox();
            lblRepeat = new Label();
            cmbDuration = new ComboBox();
            lblDuration = new Label();
            menuMain.SuspendLayout();
            grpbxStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarDelay).BeginInit();
            grpbxEnd.SuspendLayout();
            grpbxTimes.SuspendLayout();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(549, 24);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configToolStripMenuItem, historyToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "&Menú";
            // 
            // configToolStripMenuItem
            // 
            configToolStripMenuItem.Name = "configToolStripMenuItem";
            configToolStripMenuItem.Size = new Size(150, 22);
            configToolStripMenuItem.Text = "&Configuración";
            // 
            // historyToolStripMenuItem
            // 
            historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            historyToolStripMenuItem.Size = new Size(150, 22);
            historyToolStripMenuItem.Text = "&Historial";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(147, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(150, 22);
            exitToolStripMenuItem.Text = "&Salir";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // grpbxStart
            // 
            grpbxStart.Controls.Add(timeToStart);
            grpbxStart.Controls.Add(txtDelayInitMinutes);
            grpbxStart.Controls.Add(trackBarDelay);
            grpbxStart.Controls.Add(rdbtnStartAt);
            grpbxStart.Controls.Add(rdbtnStartIn);
            grpbxStart.Location = new Point(31, 37);
            grpbxStart.Name = "grpbxStart";
            grpbxStart.Size = new Size(487, 92);
            grpbxStart.TabIndex = 1;
            grpbxStart.TabStop = false;
            grpbxStart.Text = "Start";
            // 
            // timeToStart
            // 
            timeToStart.CustomFormat = "dd - MMM HH:mm";
            timeToStart.Format = DateTimePickerFormat.Custom;
            timeToStart.Location = new Point(144, 56);
            timeToStart.Name = "timeToStart";
            timeToStart.Size = new Size(121, 23);
            timeToStart.TabIndex = 4;
            // 
            // txtDelayInitMinutes
            // 
            txtDelayInitMinutes.Enabled = false;
            txtDelayInitMinutes.Location = new Point(144, 22);
            txtDelayInitMinutes.Name = "txtDelayInitMinutes";
            txtDelayInitMinutes.Size = new Size(42, 23);
            txtDelayInitMinutes.TabIndex = 3;
            // 
            // trackBarDelay
            // 
            trackBarDelay.Location = new Point(263, 22);
            trackBarDelay.Maximum = 60;
            trackBarDelay.Minimum = 5;
            trackBarDelay.Name = "trackBarDelay";
            trackBarDelay.Size = new Size(215, 45);
            trackBarDelay.TabIndex = 2;
            trackBarDelay.Value = 5;
            // 
            // rdbtnStartAt
            // 
            rdbtnStartAt.AutoSize = true;
            rdbtnStartAt.Location = new Point(27, 56);
            rdbtnStartAt.Name = "rdbtnStartAt";
            rdbtnStartAt.Size = new Size(65, 19);
            rdbtnStartAt.TabIndex = 1;
            rdbtnStartAt.TabStop = true;
            rdbtnStartAt.Text = "A las... :";
            rdbtnStartAt.UseVisualStyleBackColor = true;
            // 
            // rdbtnStartIn
            // 
            rdbtnStartIn.AutoSize = true;
            rdbtnStartIn.Location = new Point(27, 22);
            rdbtnStartIn.Name = "rdbtnStartIn";
            rdbtnStartIn.Size = new Size(96, 19);
            rdbtnStartIn.TabIndex = 0;
            rdbtnStartIn.TabStop = true;
            rdbtnStartIn.Text = "En (minutos):";
            rdbtnStartIn.UseVisualStyleBackColor = true;
            // 
            // grpbxEnd
            // 
            grpbxEnd.Controls.Add(cmbQRepeats);
            grpbxEnd.Controls.Add(cmbQHours);
            grpbxEnd.Controls.Add(timeToEnd);
            grpbxEnd.Controls.Add(rdbtnStopAt);
            grpbxEnd.Controls.Add(rdbtnStopInQHours);
            grpbxEnd.Controls.Add(rdbtnStopInQRepeats);
            grpbxEnd.Location = new Point(31, 187);
            grpbxEnd.Name = "grpbxEnd";
            grpbxEnd.Size = new Size(487, 117);
            grpbxEnd.TabIndex = 2;
            grpbxEnd.TabStop = false;
            grpbxEnd.Text = "End";
            // 
            // cmbQRepeats
            // 
            cmbQRepeats.FormattingEnabled = true;
            cmbQRepeats.Location = new Point(144, 22);
            cmbQRepeats.Name = "cmbQRepeats";
            cmbQRepeats.Size = new Size(59, 23);
            cmbQRepeats.TabIndex = 7;
            // 
            // cmbQHours
            // 
            cmbQHours.FormattingEnabled = true;
            cmbQHours.Location = new Point(144, 52);
            cmbQHours.Name = "cmbQHours";
            cmbQHours.Size = new Size(59, 23);
            cmbQHours.TabIndex = 6;
            // 
            // timeToEnd
            // 
            timeToEnd.CustomFormat = "dd - MMM HH:mm";
            timeToEnd.Format = DateTimePickerFormat.Custom;
            timeToEnd.Location = new Point(144, 82);
            timeToEnd.Name = "timeToEnd";
            timeToEnd.Size = new Size(121, 23);
            timeToEnd.TabIndex = 5;
            // 
            // rdbtnStopAt
            // 
            rdbtnStopAt.AutoSize = true;
            rdbtnStopAt.Location = new Point(27, 84);
            rdbtnStopAt.Name = "rdbtnStopAt";
            rdbtnStopAt.Size = new Size(65, 19);
            rdbtnStopAt.TabIndex = 2;
            rdbtnStopAt.TabStop = true;
            rdbtnStopAt.Text = "A las... :";
            rdbtnStopAt.UseVisualStyleBackColor = true;
            // 
            // rdbtnStopInQHours
            // 
            rdbtnStopInQHours.AutoSize = true;
            rdbtnStopInQHours.Location = new Point(27, 54);
            rdbtnStopInQHours.Name = "rdbtnStopInQHours";
            rdbtnStopInQHours.Size = new Size(84, 19);
            rdbtnStopInQHours.TabIndex = 1;
            rdbtnStopInQHours.TabStop = true;
            rdbtnStopInQHours.Text = "En (horas) :";
            rdbtnStopInQHours.UseVisualStyleBackColor = true;
            // 
            // rdbtnStopInQRepeats
            // 
            rdbtnStopInQRepeats.AutoSize = true;
            rdbtnStopInQRepeats.Location = new Point(27, 24);
            rdbtnStopInQRepeats.Name = "rdbtnStopInQRepeats";
            rdbtnStopInQRepeats.Size = new Size(119, 19);
            rdbtnStopInQRepeats.TabIndex = 0;
            rdbtnStopInQRepeats.TabStop = true;
            rdbtnStopInQRepeats.Text = "En (repeticiones) :";
            rdbtnStopInQRepeats.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(58, 320);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 3;
            btnStart.Text = "&Iniciar";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(397, 320);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 4;
            btnStop.Text = "&Parar";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // grpbxTimes
            // 
            grpbxTimes.Controls.Add(cmbRepeat);
            grpbxTimes.Controls.Add(lblRepeat);
            grpbxTimes.Controls.Add(cmbDuration);
            grpbxTimes.Controls.Add(lblDuration);
            grpbxTimes.Location = new Point(31, 135);
            grpbxTimes.Name = "grpbxTimes";
            grpbxTimes.Size = new Size(487, 46);
            grpbxTimes.TabIndex = 5;
            grpbxTimes.TabStop = false;
            grpbxTimes.Text = "Tiempos";
            // 
            // cmbRepeat
            // 
            cmbRepeat.FormattingEnabled = true;
            cmbRepeat.Location = new Point(419, 17);
            cmbRepeat.Name = "cmbRepeat";
            cmbRepeat.Size = new Size(59, 23);
            cmbRepeat.TabIndex = 3;
            // 
            // lblRepeat
            // 
            lblRepeat.AutoSize = true;
            lblRepeat.Location = new Point(263, 21);
            lblRepeat.Name = "lblRepeat";
            lblRepeat.Size = new Size(133, 15);
            lblRepeat.TabIndex = 2;
            lblRepeat.Text = "Repetir cada (minutos): ";
            // 
            // cmbDuration
            // 
            cmbDuration.FormattingEnabled = true;
            cmbDuration.Location = new Point(144, 17);
            cmbDuration.Name = "cmbDuration";
            cmbDuration.Size = new Size(59, 23);
            cmbDuration.TabIndex = 1;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(27, 21);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(116, 15);
            lblDuration.TabIndex = 0;
            lblDuration.Text = "Duración (minutos): ";
            // 
            // frmMain
            // 
            AcceptButton = btnStart;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 369);
            Controls.Add(grpbxTimes);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(grpbxEnd);
            Controls.Add(grpbxStart);
            Controls.Add(menuMain);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MainMenuStrip = menuMain;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pausas Activas";
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            grpbxStart.ResumeLayout(false);
            grpbxStart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarDelay).EndInit();
            grpbxEnd.ResumeLayout(false);
            grpbxEnd.PerformLayout();
            grpbxTimes.ResumeLayout(false);
            grpbxTimes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuMain;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem configToolStripMenuItem;
        private ToolStripMenuItem historyToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private GroupBox grpbxStart;
        private GroupBox grpbxEnd;
        private Button btnStart;
        private Button btnStop;
        private RadioButton rdbtnStartAt;
        private RadioButton rdbtnStartIn;
        private RadioButton rdbtnStopAt;
        private RadioButton rdbtnStopInQHours;
        private RadioButton rdbtnStopInQRepeats;
        private TrackBar trackBarDelay;
        private TextBox txtDelayInitMinutes;
        private DateTimePicker timeToStart;
        private DateTimePicker timeToEnd;
        private GroupBox grpbxTimes;
        private Label lblDuration;
        private ComboBox cmbDuration;
        private ComboBox cmbRepeat;
        private Label lblRepeat;
        private ComboBox cmbQHours;
        private ComboBox cmbQRepeats;
    }
}
