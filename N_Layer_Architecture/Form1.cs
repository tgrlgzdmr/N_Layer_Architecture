using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using LogicLayer;

namespace N_Layer_Architecture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            List<EntityPersonal> PerList = LogicPersonal.LLPersonalList();
            dataGridView1.DataSource = PerList;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            EntityPersonal ent = new EntityPersonal();
            ent.Name = TxtName.Text;
            ent.Surname=TxtSurname.Text;
            ent.City=TxtCity.Text;
            ent.Duty=TxtDuty.Text;
            ent.Salary = short.Parse(TxtSalary.Text);
            LogicPersonal.LLAddPersonel(ent);
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            EntityPersonal entd = new EntityPersonal();
            entd.Id = int.Parse(Txtid.Text);
            LogicPersonal.LLDelPersonal(entd.Id);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            EntityPersonal entu = new EntityPersonal();
            entu.Id = int.Parse(Txtid.Text);
            entu.Name = TxtName.Text;
            entu.Surname = TxtSurname.Text;
            entu.City = TxtCity.Text;
            entu.Duty = TxtDuty.Text;
            entu.Salary = short.Parse(TxtSalary.Text);
            LogicPersonal.LLUpdPersonal(entu);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[chosen].Cells[0].Value.ToString();
            TxtName.Text = dataGridView1.Rows[chosen].Cells[1].Value.ToString();
            TxtSurname.Text = dataGridView1.Rows[chosen].Cells[2].Value.ToString();
            TxtCity.Text = dataGridView1.Rows[chosen].Cells[3].Value.ToString();
            TxtDuty.Text = dataGridView1.Rows[chosen].Cells[4].Value.ToString();
            TxtSalary.Text = dataGridView1.Rows[chosen].Cells[5].Value.ToString();
            
        }
    }
}
