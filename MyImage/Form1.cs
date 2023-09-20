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
            //mặc định là scale to fit
            scaleToFitToolStripMenuItem.Checked = true;

            //đặt kích thước ban đầu cho picture
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox1.Dock = DockStyle.Fill;
            this.Controls.Add(pictureBox1);
            this.SizeChanged += Form1_SizeChanged;
            KT_ItemMenuView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            UpdatePictureBoxSizeAndLocation();

        }

        private void UpdatePictureBoxSizeAndLocation()
        {
            // Lấy kích thước cửa sổ mới
            int newWidth = this.ClientSize.Width;
            int newHeight = this.ClientSize.Height;

            // Cập nhật kích thước và vị trí của PictureBox để đảm bảo không bị biến đổi tỷ lệ và lấp đầy cửa sổ
            pictureBox1.Size = new Size(newWidth, newHeight);
            pictureBox1.Location = new Point(0, 0);
        }

        //file -> open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo hộp thoại mở file
            OpenFileDialog dlg = new OpenFileDialog();
            //lọc hiện thị các loại file
            dlg.Filter = "JPG File | *.jpg";
            //Hiện thị hộp thoại
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dlg.FileName);
                KT_ItemMenuView();
            }

            //hiển thị đường dẫn của ảnh
            labelFilePath.Text = dlg.FileName;

            //hiển thị WxH của hình
            string wxh = $"{pictureBox1.Image.Size.Width.ToString()} x {pictureBox1.Image.Height.ToString()}";
            labelSize.Text = wxh;
            
            labelFilePath.Spring = true;
            
        }

        private void KT_ItemMenuView()
        {
            if (pictureBox1.Image == null)
            {
                scaleToFitToolStripMenuItem.Enabled = false;
                stretchToFitToolStripMenuItem.Enabled = false;
                actualSizeToolStripMenuItem.Enabled = false;
            }
            else
            {
                scaleToFitToolStripMenuItem.Enabled = true;
                stretchToFitToolStripMenuItem.Enabled = true;
                actualSizeToolStripMenuItem.Enabled = true;
            }
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

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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

            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}
