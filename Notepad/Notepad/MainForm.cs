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
using System.Text;

namespace Notepad
{
    public partial class MainForm : Form
    {

        MdiClient mdiClient = null;
        public MainForm()
        {
            InitializeComponent();
            AutoSavingTimer.Start();
            for (int i = 0; i < Controls.Count; i++)
            {
                mdiClient = Controls[i] as MdiClient;
                if (mdiClient != null)
                    break;
            }
            mdiClient.BackColor = Color.LightCyan;
            foreach (FontFamily font in FontFamily.Families)
                fontsToolStripComboBox.Items.Add(font.Name);
            for (int i = 8; i <= 72; i++)
                fontSizeToolStripComboBox.Items.Add(i);
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                ShowChildForm(new TextForm(openDialog.FileName));
            }
            else return;
        }
        private void ShowChildForm(Form form)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is TextForm)
                    child.WindowState = FormWindowState.Minimized;
            }
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void saveAllWithFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is TextForm)
                    (child as TextForm).SaveFile(true);
            }
        }

        private void saveAllWithoutFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is TextForm)
                    (child as TextForm).SaveFile(false);
            }
        }

        protected bool AutoSavingFormat = true;
        private void AutoSavingTimer_Tick(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is TextForm)
                    (child as TextForm).SaveFile(AutoSavingFormat);
            }
        }

        
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm(AutoSavingTimer.Interval,AutoSavingFormat,menuStrip.BackColor==Color.PeachPuff);
            settings.Owner = this;
            settings.ShowDialog();
        }

        public void ChangeSettings(int interval, bool savingFormat,bool light)
        {
            AutoSavingTimer.Interval = interval;
            AutoSavingFormat = savingFormat;
            if (light)
            {
                menuStrip.BackColor = Color.PeachPuff;
                toolStrip.BackColor = Color.LemonChiffon;
                mdiClient.BackColor = Color.LightCyan;
            }
            else
            {
                menuStrip.BackColor = Color.MediumPurple;
                toolStrip.BackColor = Color.PowderBlue;
                mdiClient.BackColor = Color.MidnightBlue;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is TextForm && (child as TextForm).IsChanged)
                {
                    DialogResult result = MessageBox.Show($"Сохранить изменения в {(child as TextForm).fileName}?", "Сохранение изменений",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        (child as TextForm).SaveFile(AutoSavingFormat);
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
            StringBuilder fileNames = new StringBuilder("");
            foreach (Form child in MdiChildren)
            {
                if (child is TextForm)
                    fileNames.Append((child as TextForm).fileName + ';');
            }
            Properties.Settings.Default.fileNames = fileNames.ToString();
            Properties.Settings.Default.savingInterval = AutoSavingTimer.Interval;
            Properties.Settings.Default.withFormat = AutoSavingFormat;
            if (menuStrip.BackColor == Color.PeachPuff)
                Properties.Settings.Default.lightColor = true;
            else
                Properties.Settings.Default.lightColor = false;
            Properties.Settings.Default.Save();
        }

        private void italicsToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextForm)
                (ActiveMdiChild as TextForm).MakeItalics();
        }

        private void boldToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextForm)
                (ActiveMdiChild as TextForm).MakeBold();
        }

        private void underlineToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextForm)
                (ActiveMdiChild as TextForm).MakeUnderline();
        }

        private void strikeOutToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextForm)
                (ActiveMdiChild as TextForm).MakeStrikeout();
        }
        private void registerToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextForm)
                (ActiveMdiChild as TextForm).ChangeRegister();
        }

        private void FontColorToolStripButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            FontColorToolStripButton.BackColor = colorDialog.Color;

            if (ActiveMdiChild is TextForm)
                (ActiveMdiChild as TextForm).ChangeSelectionColor(colorDialog.Color);

        }

        private void fontsToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ActiveMdiChild is TextForm)
                (ActiveMdiChild as TextForm).ChangeSelectedFont(fontsToolStripComboBox.SelectedItem.ToString());
            fontsToolStripComboBox.Font = new Font(fontsToolStripComboBox.SelectedItem.ToString(), 11);

        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.Cancel)
                return;
            foreach (Form child in MdiChildren)
            {
                if (child is TextForm)
                    (child as TextForm).ChangeFont(fontDialog.Font, fontDialog.Color);
            }
        }

        private void saveHowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (ActiveMdiChild is TextForm)
                    (ActiveMdiChild as TextForm).SaveFileHow(saveDialog.FileName);
                else
                    MessageBox.Show("Выберите форму, которую необходимо сохранить, и повторите попытку!", "Ошибка");
            }
            else
                return;
        }

        private void fontSizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ActiveMdiChild is TextForm)
                (ActiveMdiChild as TextForm).ChangeSize(int.Parse(fontSizeToolStripComboBox.SelectedItem.ToString()));

        }
        private void createNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveDialog.FileName, "");
                MainForm form = new MainForm();
                form.Show();
                form.ShowChildForm(new TextForm(saveDialog.FileName));
            }
            else
                return;
        }
        private void createInsideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveDialog.FileName, "");
                ShowChildForm(new TextForm(saveDialog.FileName));
            }
            else
                return;
        }
        private void saveActiveWithFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextForm)
                (ActiveMdiChild as TextForm).SaveFile(true);
        }

        private void saveActiveWithoutFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextForm)
                (ActiveMdiChild as TextForm).SaveFile(false);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] fileNames = Properties.Settings.Default.fileNames.Split(';',StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < fileNames.Length; i++)
            {
                ShowChildForm(new TextForm(fileNames[i]));
            }
            ChangeSettings(Properties.Settings.Default.savingInterval, Properties.Settings.Default.withFormat, Properties.Settings.Default.lightColor);
            Properties.Settings.Default.Save();
        }

        private void undoToolStripButton_Click(object sender, EventArgs e)
        {
            if(ActiveMdiChild is TextForm)
            {
                (ActiveMdiChild as TextForm).Undo();
            }
        }

        private void redoToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextForm)
            {
                (ActiveMdiChild as TextForm).Redo();
            }
        }
    }
}
