using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST1
{
    public partial class Form1 : Form
    {
        string filename;
        private int width;
        int change_flag = 0;//0表示未作修改,1表示作出修改

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            //richTextBox1.Width = this.width;
            //richTextBox1.Height = this.Height;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "d:\\";
            openFileDialog1.Filter = "文本文件|*.txt|富文本文件|*.rtf";
            DialogResult dr = openFileDialog1.ShowDialog();
            if(dr == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if(dr == DialogResult.OK)
            {
                change_flag = 0;
                richTextBox1.SaveFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("保存成功");
            }
        }

        private void 保存toolStripButton_Click(object sender, EventArgs e)
        {
            保存ToolStripMenuItem_Click(sender, e);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(change_flag == 1)
            {
                DialogResult dr = MessageBox.Show("文件未保存，是否保存？");
                if(dr == DialogResult.OK)
                {
                    保存ToolStripMenuItem_Click(sender, e);
                    this.Close();
                }
            }
        }

        private void 从打开toolStripButton_Click(object sender, EventArgs e)
        {
            打开ToolStripMenuItem_Click(sender, e);
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void 打印toolStripButton_Click(object sender, EventArgs e)
        {
            打印ToolStripMenuItem_Click(sender, e);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            MessageBox.Show("复制到粘贴板板成功");
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void 重做ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void CuttoolStripButton_Click(object sender, EventArgs e)
        {
            剪切ToolStripMenuItem_Click(sender, e);
        }

        private void CopytoolStripButton_Click(object sender, EventArgs e)
        {
            复制ToolStripMenuItem_Click(sender, e);
        }

        private void PastetoolStripButton_Click(object sender, EventArgs e)
        {
            粘贴ToolStripMenuItem_Click(sender,  e);
        }

        private void 帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ipv4.ftp.uuoc.me:444/working/another/%E4%BA%BA%E6%9C%BA%E4%BA%A4%E4%BA%92/test1_help.html");
        }

        private void HelptoolStripButton_Click(object sender, EventArgs e)
        {
            帮助文档ToolStripMenuItem_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 新建toolStripButton_Click(object sender, EventArgs e)
        {
            新建ToolStripMenuItem_Click(sender, e);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dr = fontDialog1.ShowDialog();
            if(dr == DialogResult.OK)
            {
                fontDialog1.ShowDialog();
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "d:\\";
            saveFileDialog1.Filter = "文本文件|*.txt|富文本文件|*.rtf";
            saveFileDialog1.FileName = @"新建文本文件.txt";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                change_flag = 0;
                MessageBox.Show("文件另存为成功");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog();
            if(dr == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            change_flag = 1;
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
