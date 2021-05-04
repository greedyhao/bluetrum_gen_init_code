using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gen_print_init
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string gen_bits_code(CheckedListBox checkedListBox)
        {
            string code = "";
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (checkedListBox.GetItemChecked(i) == true)
                {
                    code += (String.IsNullOrEmpty(code) ? "" : " | ") + checkedListBox.GetItemText(checkedListBox.Items[i]);
                }
            }
            return code;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] portName = { "A", "B", "E", "F" };
            var msg = "";
            foreach (Control control in this.tabPage1.Controls)
            {
                if (control is CheckedListBox)
                {
                    CheckedListBox clb = control as CheckedListBox;
                    var index = control.Name.Substring(control.Name.Length - 1, 1);
                    var num = int.Parse(index) - 1;
                    var port = "GPIO" + portName[num];
                    var fen = port + "FEN &= ~(" + gen_bits_code(clb) + ");\n";
                    var de = port + "DE  |= (" + gen_bits_code(clb) + ");\n";
                    var dir = port + "DIR &= ~(" + gen_bits_code(clb) + ");\n";

                    if (gen_bits_code(clb) != "")
                    {
                        msg += fen + de + dir + "\n";
                    }
                }
            }
            MessageBox.Show(msg, "关闭窗口会自动复制代码到粘贴板");
            Clipboard.SetText(msg);
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, false);
            }
            for (int i = 0; i < this.checkedListBox2.Items.Count; i++)
            {
                this.checkedListBox2.SetItemChecked(i, false);
            }
            for (int i = 0; i < this.checkedListBox3.Items.Count; i++)
            {
                this.checkedListBox3.SetItemChecked(i, false);
            }
            for (int i = 0; i < this.checkedListBox4.Items.Count; i++)
            {
                this.checkedListBox4.SetItemChecked(i, false);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
