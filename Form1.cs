using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Text;
using System.Windows.Forms;

namespace ЛР_16_Editing_pictures_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bmp_for_draw;
        Point start_point;
        bool dozvil;
        Pen pen1 = new Pen(Color.Black, 5);

        string full_name_of_image;

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(pictureBox.Image))
                {
                    if (dozvil == true)
                    {
                        g.DrawLine(pen1, start_point, e.Location);
                        start_point = e.Location;
                        pictureBox.Invalidate();
                    }
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dozvil = true;
                start_point = e.Location;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dozvil = false;
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    full_name_of_image = open_dialog.FileName;
                    bmp_for_draw = new Bitmap(open_dialog.FileName);
                    this.pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBox.Image = bmp_for_draw;
                    pictureBox.Invalidate();
                }
                catch
                {
                    DialogResult result = MessageBox.Show("It's impossible to open selected file");
                }
            }
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox.CreateGraphics();
            g.Clear(SystemColors.Window);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                string format = full_name_of_image.Substring(full_name_of_image.Length - 5, 5);
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Зберегти як ...";
                savedialog.OverwritePrompt = true;
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bmp_for_draw.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                    }
                    catch
                    {
                        MessageBox.Show("It's impossible to save image", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
  
