
namespace Notepad
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOnlySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveActiveWithFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveActiveWithoutFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllWithFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllWithoutFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveHowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createInsideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSavingTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.italicsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.boldToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.underlineToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.strikeOutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.registerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fontsToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.FontColorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fontSizeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.redoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.PeachPuff;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.CloseToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(990, 38);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveHowToolStripMenuItem,
            this.создатьToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(81, 34);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(277, 38);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveOnlySelectedToolStripMenuItem,
            this.всеToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(277, 38);
            this.saveToolStripMenuItem.Text = "Сохранить";
            // 
            // saveOnlySelectedToolStripMenuItem
            // 
            this.saveOnlySelectedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveActiveWithFormatToolStripMenuItem,
            this.saveActiveWithoutFormatToolStripMenuItem});
            this.saveOnlySelectedToolStripMenuItem.Name = "saveOnlySelectedToolStripMenuItem";
            this.saveOnlySelectedToolStripMenuItem.Size = new System.Drawing.Size(278, 38);
            this.saveOnlySelectedToolStripMenuItem.Text = "только текущий";
            // 
            // saveActiveWithFormatToolStripMenuItem
            // 
            this.saveActiveWithFormatToolStripMenuItem.Name = "saveActiveWithFormatToolStripMenuItem";
            this.saveActiveWithFormatToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveActiveWithFormatToolStripMenuItem.Size = new System.Drawing.Size(594, 38);
            this.saveActiveWithFormatToolStripMenuItem.Text = "с сохранением форматирования";
            this.saveActiveWithFormatToolStripMenuItem.Click += new System.EventHandler(this.saveActiveWithFormatToolStripMenuItem_Click);
            // 
            // saveActiveWithoutFormatToolStripMenuItem
            // 
            this.saveActiveWithoutFormatToolStripMenuItem.Name = "saveActiveWithoutFormatToolStripMenuItem";
            this.saveActiveWithoutFormatToolStripMenuItem.Size = new System.Drawing.Size(594, 38);
            this.saveActiveWithoutFormatToolStripMenuItem.Text = "без сохранения форматирования";
            this.saveActiveWithoutFormatToolStripMenuItem.Click += new System.EventHandler(this.saveActiveWithoutFormatToolStripMenuItem_Click);
            // 
            // всеToolStripMenuItem
            // 
            this.всеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAllWithFormatToolStripMenuItem,
            this.saveAllWithoutFormatToolStripMenuItem});
            this.всеToolStripMenuItem.Name = "всеToolStripMenuItem";
            this.всеToolStripMenuItem.Size = new System.Drawing.Size(278, 38);
            this.всеToolStripMenuItem.Text = "все";
            // 
            // saveAllWithFormatToolStripMenuItem
            // 
            this.saveAllWithFormatToolStripMenuItem.Name = "saveAllWithFormatToolStripMenuItem";
            this.saveAllWithFormatToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAllWithFormatToolStripMenuItem.Size = new System.Drawing.Size(522, 38);
            this.saveAllWithFormatToolStripMenuItem.Text = "с сохранением форматирования";
            this.saveAllWithFormatToolStripMenuItem.Click += new System.EventHandler(this.saveAllWithFormatToolStripMenuItem_Click);
            // 
            // saveAllWithoutFormatToolStripMenuItem
            // 
            this.saveAllWithoutFormatToolStripMenuItem.Name = "saveAllWithoutFormatToolStripMenuItem";
            this.saveAllWithoutFormatToolStripMenuItem.Size = new System.Drawing.Size(522, 38);
            this.saveAllWithoutFormatToolStripMenuItem.Text = "без сохранения форматирования";
            this.saveAllWithoutFormatToolStripMenuItem.Click += new System.EventHandler(this.saveAllWithoutFormatToolStripMenuItem_Click);
            // 
            // saveHowToolStripMenuItem
            // 
            this.saveHowToolStripMenuItem.Name = "saveHowToolStripMenuItem";
            this.saveHowToolStripMenuItem.Size = new System.Drawing.Size(277, 38);
            this.saveHowToolStripMenuItem.Text = "Сохранить как...";
            this.saveHowToolStripMenuItem.Click += new System.EventHandler(this.saveHowToolStripMenuItem_Click);
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createInsideToolStripMenuItem,
            this.createNewWindowToolStripMenuItem});
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(277, 38);
            this.создатьToolStripMenuItem.Text = "Создать";
            // 
            // createInsideToolStripMenuItem
            // 
            this.createInsideToolStripMenuItem.Name = "createInsideToolStripMenuItem";
            this.createInsideToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.createInsideToolStripMenuItem.Size = new System.Drawing.Size(406, 38);
            this.createInsideToolStripMenuItem.Text = "В новой вкладке";
            this.createInsideToolStripMenuItem.Click += new System.EventHandler(this.createInsideToolStripMenuItem_Click);
            // 
            // createNewWindowToolStripMenuItem
            // 
            this.createNewWindowToolStripMenuItem.Name = "createNewWindowToolStripMenuItem";
            this.createNewWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.createNewWindowToolStripMenuItem.Size = new System.Drawing.Size(406, 38);
            this.createNewWindowToolStripMenuItem.Text = "В новом окне";
            this.createNewWindowToolStripMenuItem.Click += new System.EventHandler(this.createNewWindowToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(103, 34);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(106, 34);
            this.formatToolStripMenuItem.Text = "Формат";
            this.formatToolStripMenuItem.Click += new System.EventHandler(this.formatToolStripMenuItem_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(138, 34);
            this.SettingsToolStripMenuItem.Text = "Настройки";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(16, 34);
            this.CloseToolStripMenuItem.Visible = false;
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(16, 34);
            this.undoToolStripMenuItem.Visible = false;
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripButton_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(16, 34);
            this.redoToolStripMenuItem.Visible = false;
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripButton_Click);
            // 
            // AutoSavingTimer
            // 
            this.AutoSavingTimer.Interval = 900000;
            this.AutoSavingTimer.Tick += new System.EventHandler(this.AutoSavingTimer_Tick);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.LemonChiffon;
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.italicsToolStripButton,
            this.boldToolStripButton,
            this.underlineToolStripButton,
            this.strikeOutToolStripButton,
            this.registerToolStripButton,
            this.fontsToolStripComboBox,
            this.FontColorToolStripButton,
            this.fontSizeToolStripComboBox,
            this.toolStripSeparator1,
            this.undoToolStripButton,
            this.redoToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 38);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(990, 45);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // italicsToolStripButton
            // 
            this.italicsToolStripButton.AutoSize = false;
            this.italicsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.italicsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("italicsToolStripButton.Image")));
            this.italicsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.italicsToolStripButton.Name = "italicsToolStripButton";
            this.italicsToolStripButton.Size = new System.Drawing.Size(40, 40);
            this.italicsToolStripButton.Text = "Курсив";
            this.italicsToolStripButton.Click += new System.EventHandler(this.italicsToolStripButton_Click);
            // 
            // boldToolStripButton
            // 
            this.boldToolStripButton.AutoSize = false;
            this.boldToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.boldToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("boldToolStripButton.Image")));
            this.boldToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boldToolStripButton.Name = "boldToolStripButton";
            this.boldToolStripButton.Size = new System.Drawing.Size(40, 40);
            this.boldToolStripButton.Text = "Жирный";
            this.boldToolStripButton.Click += new System.EventHandler(this.boldToolStripButton_Click);
            // 
            // underlineToolStripButton
            // 
            this.underlineToolStripButton.AutoSize = false;
            this.underlineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.underlineToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("underlineToolStripButton.Image")));
            this.underlineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.underlineToolStripButton.Name = "underlineToolStripButton";
            this.underlineToolStripButton.Size = new System.Drawing.Size(40, 40);
            this.underlineToolStripButton.Text = "Подчеркнутый";
            this.underlineToolStripButton.Click += new System.EventHandler(this.underlineToolStripButton_Click);
            // 
            // strikeOutToolStripButton
            // 
            this.strikeOutToolStripButton.AutoSize = false;
            this.strikeOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.strikeOutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("strikeOutToolStripButton.Image")));
            this.strikeOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.strikeOutToolStripButton.Name = "strikeOutToolStripButton";
            this.strikeOutToolStripButton.Size = new System.Drawing.Size(40, 40);
            this.strikeOutToolStripButton.Text = "Зачеркнутый";
            this.strikeOutToolStripButton.Click += new System.EventHandler(this.strikeOutToolStripButton_Click);
            // 
            // registerToolStripButton
            // 
            this.registerToolStripButton.AutoSize = false;
            this.registerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.registerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("registerToolStripButton.Image")));
            this.registerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.registerToolStripButton.Name = "registerToolStripButton";
            this.registerToolStripButton.Size = new System.Drawing.Size(40, 40);
            this.registerToolStripButton.Text = "Регистр";
            this.registerToolStripButton.Click += new System.EventHandler(this.registerToolStripButton_Click);
            // 
            // fontsToolStripComboBox
            // 
            this.fontsToolStripComboBox.AutoSize = false;
            this.fontsToolStripComboBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fontsToolStripComboBox.Name = "fontsToolStripComboBox";
            this.fontsToolStripComboBox.Size = new System.Drawing.Size(185, 38);
            this.fontsToolStripComboBox.ToolTipText = "Шрифт";
            this.fontsToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.fontsToolStripComboBox_SelectedIndexChanged);
            // 
            // FontColorToolStripButton
            // 
            this.FontColorToolStripButton.AutoSize = false;
            this.FontColorToolStripButton.BackColor = System.Drawing.Color.Black;
            this.FontColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.FontColorToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("FontColorToolStripButton.Image")));
            this.FontColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FontColorToolStripButton.Name = "FontColorToolStripButton";
            this.FontColorToolStripButton.Size = new System.Drawing.Size(40, 40);
            this.FontColorToolStripButton.Text = "Цвет шрифта";
            this.FontColorToolStripButton.Click += new System.EventHandler(this.FontColorToolStripButton_Click);
            // 
            // fontSizeToolStripComboBox
            // 
            this.fontSizeToolStripComboBox.Name = "fontSizeToolStripComboBox";
            this.fontSizeToolStripComboBox.Size = new System.Drawing.Size(75, 45);
            this.fontSizeToolStripComboBox.ToolTipText = "Размер шрифта";
            this.fontSizeToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.fontSizeToolStripComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // undoToolStripButton
            // 
            this.undoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripButton.Image")));
            this.undoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoToolStripButton.Name = "undoToolStripButton";
            this.undoToolStripButton.Size = new System.Drawing.Size(34, 40);
            this.undoToolStripButton.Text = "Отменить";
            this.undoToolStripButton.Click += new System.EventHandler(this.undoToolStripButton_Click);
            // 
            // redoToolStripButton
            // 
            this.redoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripButton.Image")));
            this.redoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoToolStripButton.Name = "redoToolStripButton";
            this.redoToolStripButton.Size = new System.Drawing.Size(34, 40);
            this.redoToolStripButton.Text = "toolStripButton2";
            this.redoToolStripButton.Click += new System.EventHandler(this.redoToolStripButton_Click);
            // 
            // fontDialog
            // 
            this.fontDialog.ShowColor = true;
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openFileDialog1";
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "txt files (*.txt)|*.txt | rtf files (*.rtf)|*.rtf | C# files (*cs)|*.cs";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(990, 707);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Блокнотик-Енотик";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.Timer AutoSavingTimer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton italicsToolStripButton;
        private System.Windows.Forms.ToolStripButton boldToolStripButton;
        private System.Windows.Forms.ToolStripButton underlineToolStripButton;
        private System.Windows.Forms.ToolStripButton strikeOutToolStripButton;
        private System.Windows.Forms.ToolStripButton registerToolStripButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripComboBox fontsToolStripComboBox;
        private System.Windows.Forms.ToolStripButton FontColorToolStripButton;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.ToolStripMenuItem saveHowToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox fontSizeToolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createInsideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOnlySelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveActiveWithFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveActiveWithoutFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllWithFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllWithoutFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton undoToolStripButton;
        private System.Windows.Forms.ToolStripButton redoToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    }
}

