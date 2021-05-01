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
            var port = "GPIOA";
            var fen = port + "FEN &= ~(" + gen_bits_code(checkedListBox1) + ");\n";
            var de  = port + "DE  |= (" + gen_bits_code(checkedListBox1) + ");\n";
            var dir = port + "DIR &= ~(" + gen_bits_code(checkedListBox1) + ");\n";

            var port2 = "GPIOB";
            var fen2 = port2 + "FEN &= ~(" + gen_bits_code(checkedListBox2) + ");\n";
            var de2  = port2 + "DE  |= (" + gen_bits_code(checkedListBox2) + ");\n";
            var dir2 = port2 + "DIR &= ~(" + gen_bits_code(checkedListBox2) + ");\n";

            var port3 = "GPIOE";
            var fen3 = port3 + "FEN &= ~(" + gen_bits_code(checkedListBox3) + ");\n";
            var de3  = port3 + "DE  |= (" + gen_bits_code(checkedListBox3) + ");\n";
            var dir3 = port3 + "DIR &= ~(" + gen_bits_code(checkedListBox3) + ");\n";
            
            var port4 = "GPIOF";
            var fen4 = port4 + "FEN &= ~(" + gen_bits_code(checkedListBox4) + ");\n";
            var de4  = port4 + "DE  |= (" + gen_bits_code(checkedListBox4) + ");\n";
            var dir4 = port4 + "DIR &= ~(" + gen_bits_code(checkedListBox4) + ");\n";

            var msg = "";
            var msg1 = fen + de + dir + "\n";
            var msg2 = fen2 + de2 + dir2 + "\n";
            var msg3 = fen3 + de3 + dir3 + "\n";
            var msg4 = fen4 + de4 + dir4 + "\n";
            if (gen_bits_code(checkedListBox1) != "")
            {
                msg += msg1;
            }
            if (gen_bits_code(checkedListBox2) != "")
            {
                msg += msg2;
            }
            if (gen_bits_code(checkedListBox3) != "")
            {
                msg += msg3;
            }
            if (gen_bits_code(checkedListBox4) != "")
            {
                msg += msg4;
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
