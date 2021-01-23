using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ImageViewer
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length != 0)
            {
                if (string.IsNullOrEmpty(args[0]) || !File.Exists(args[0]))
                {
                    MessageBox.Show("有効なパスではありません。", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Application.Run(new Form1(args[0]));
            }
            else 
            {
                MessageBox.Show("引数でファイルを指定してください。", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
