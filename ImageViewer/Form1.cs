using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class Form1 : Form
    {
        string FilePath;
        public Form1(string FilePath)
        {
            InitializeComponent();
            this.FilePath = FilePath;
            LoadImage();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                Change(-1);
            }
            else if (e.KeyCode == Keys.Right)
            {
                Change(1);
            }
            base.OnKeyDown(e);
        }

        private void Change(int c) 
        {
            string[] files = Directory.GetFiles(Path.GetDirectoryName(FilePath));
            for (int i = (Array.IndexOf(files, FilePath) + c + files.Length) % files.Length; ; i = (i + c + files.Length) % files.Length) 
            {
                try
                {
                    FilePath = files[i];
                    LoadImage();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    continue;
                }
            }
        }

        private void LoadImage()
        {
            this.BackgroundImage?.Dispose();
            this.BackgroundImage = Image.FromFile(FilePath);
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
