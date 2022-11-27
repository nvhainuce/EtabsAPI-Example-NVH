using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETABSv17;

namespace EtabsAPI_DocNL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EtabsAPI_Ctrinhcon.DocETABSAPI_GetallFrame();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Class_BienToanCuc.Etabs_Frames;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EtabsAPI_Ctrinhcon.DocETABSAPI_FrameForce();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EtabsAPI_Ctrinhcon.DocEtabsAPI_PropFrame();
        }
    }
}
