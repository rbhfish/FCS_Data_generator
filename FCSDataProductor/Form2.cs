using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCSDataProductor
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //byte[] bMem = null;
            string strSelected = null;
            string strKey = "$MODE";
            if (comboBox3.SelectedIndex == 0)
                strSelected = "L";
            else if(comboBox3.SelectedIndex == 1)
                strSelected = "C";
            else
                strSelected = "U";
            string strValue = "\\"+strSelected.ToString()+"\\";
            //SingletonFCSDataEncodingTool singleton = SingletonFCSDataEncodingTool.CreateInstance();
            singleton.ConvertKeyVlaue2Byte(strKey,strValue,ref bMem);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "FCS file|*.fcs";
            sfd.ShowDialog();
            string path = sfd.FileName;
            singleton.WriteBinaryStream2File(path.ToString(),bMem);
            MessageBox.Show("The file has been written.", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }
}
