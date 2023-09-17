using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MyImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo hộp thoại mở file
            OpenFileDialog dlg = new OpenFileDialog();
            //lọc hiện thị các loại file
            dlg.Filter = "Pdf file| *.pdf | JPG File | *.jpg";
            //Hiện thị hộp thoại
            if (dlg.ShowDialog() == DialogResult.OK)
                MessageBox.Show(dlg.FileName);
            this.pictureBox1.Image = Image.FromFile(dlg.FileName);

            //mặc định là scale to fit
            scaleToFitToolStripMenuItem.Checked = true;

            //hiển thị đường dẫn của ảnh
            toolStripStatusLabel1.Text = dlg.FileName;

            //hiển thị WxH của hình
            string wxh = $"{pictureBox1.Image.Size.Width.ToString()} x {pictureBox1.Image.Height.ToString()}";
            toolStripStatusLabel2.Text = wxh; 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void scaleToFitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chỉ hiển thị dấu tick của mục được chọn
            scaleToFitToolStripMenuItem.Checked = true;
            //ẩn dấu tick của 2 mục còn lại khi chọn
            stretchToFitToolStripMenuItem.Checked = false;
            actualSizeToolStripMenuItem.Checked = false;

            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void stretchToFitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chỉ hiển thị dấu tick của mục được chọn
            stretchToFitToolStripMenuItem.Checked = true;
            //ẩn dấu tick của 2 mục còn lại khi chọn
            scaleToFitToolStripMenuItem.Checked = false;
            actualSizeToolStripMenuItem.Checked = false;
            
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void actualSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chỉ hiển thị dấu tick của mục được chọn
            actualSizeToolStripMenuItem.Checked = true;
            //ẩn dấu tick của 2 mục còn lại khi chọn
            scaleToFitToolStripMenuItem.Checked = false;
            stretchToFitToolStripMenuItem.Checked = false;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //đặt vị trí cho label 2 nằm bên phải

            toolStripStatusLabel1.Margin = new Padding(0, 0, 300, 0);
        }
    }
}
