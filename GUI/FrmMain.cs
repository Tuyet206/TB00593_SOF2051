using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public static string email;
        public static int vaitro = 0; // 0 là nhân viên 1 là quản trị viên
        public static int session = 0; //trạng thái đăng nhập 
        public static int profile = 0; //kiểm tra có cập nhật mk không 
        private object dn;
        private static string mail;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Resetvalue();
            if (profile == 1)// nếu vừa câp nhật mật khẩu thì 
                             //phải login lại, mục 'thong tin nhan vien' ẩn
            {
                thongtinnvToolStripMenuItem.Text = null;
                profile = 0; //ẩn mục 'thong tin nhan vien'
            }
        }

        private void VaiTroNV()
        {
            NhanVienToolStripMenuItem.Visible = false;
            thongkeToolStripMenuItem.Visible = false;
        }

        private void Resetvalue()
        {
            if (session == 1)
            {

                thongtinnvToolStripMenuItem.Text = "Chào " + FrmMain.mail;
                NhanVienToolStripMenuItem.Visible = true;
                danhMụcToolStripMenuItem.Visible = true;
                LoOutToolStripMenuItem1.Enabled = true;
                thongkeToolStripMenuItem.Visible = true;
                ThongKeSPToolStripMenuItem.Visible = true;
                ProfileNvToolStripMenuItem.Visible = true;
                đăngNhậpToolStripMenuItem.Enabled = false;

                if (vaitro == 0)//nêu la vai tro nhan vien
                {
                    VaiTroNV(); //chuc nang nhan vien bình thường
                }
            }
            else
            {
                NhanVienToolStripMenuItem.Visible = false;
                danhMụcToolStripMenuItem.Visible = false;
                LoOutToolStripMenuItem1.Enabled = false;
                ProfileNvToolStripMenuItem.Visible = false;
                ThongKeSPToolStripMenuItem.Visible = false;
                thongkeToolStripMenuItem.Visible = false;
                đăngNhậpToolStripMenuItem.Enabled = true;
            }
        }



        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin dn = new FrmLogin();
            if (!CheckExistForm("FrmDangNhap"))
            {
                dn.MdiParent = this;
                dn.Show();
                dn.FormClosed += new FormClosedEventHandler(FrmDangNhap_FormClosed);
            }
            else
            {
                ActiveChildForm("FrmDangNhap");
            }
        }

        private void FrmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed        
            this.Refresh();
            FrmMain_Load(sender, e);// load form main again
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed        
            this.Refresh();
            FrmMain_Load(sender, e);// load form main again
        }
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hồSơNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmThongTinNV profilenv = new FrmThongTinNV(email);// khơi tạo FrmThongTinNV với email nv

            if (!CheckExistForm("FrmThongTinNV"))
            {
                profilenv.MdiParent = this;
                profilenv.FormClosed += new FormClosedEventHandler(FrmThongTinNV_FormClosed);
                profilenv.Show();
            }
            else
                ActiveChildForm("frmThongTinNV");
        }

        private void FrmThongTinNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            this.Refresh();

            FrmMain_Load(sender, e);// load form main again
        }


        private void dangxuatToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            thongtinnvToolStripMenuItem.Text = null;
            session = 0;
            Resetvalue();
        }
    }
}
