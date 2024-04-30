using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IITACLINIC
{
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
            Con = new Functions();
            ShowDoctor();
        }
        Functions Con;

        private void ShowDoctor()
        {
            string Query = "Select * from DoctorTbl";
            DoctorDGV.DataSource = Con.GetData(Query);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DocTb.Text = DoctorDGV.SelectedRows[0].Cells[1].Value.ToString();
            GenCbt.Text = DoctorDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmailTbc.Text = DoctorDGV.SelectedRows[0].Cells[5].Value.ToString();
            PhoneTbc.Text = DoctorDGV.SelectedRows[0].Cells[4].Value.ToString();
            SpecTb.Text = DoctorDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (DocTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DoctorDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Doctor_Load(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Menu Obj = new Menu();
            Obj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (DocTb.Text == "" || EmailTbc.Text == "" || SpecTb.Text == "" || PhoneTbc.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Nom = DocTb.Text;
                    string Phone = PhoneTbc.Text;
                    string Email = EmailTbc.Text;
                    string Gender = GenCbt.Text;
                    string Speciality = SpecTb.Text;
                    string Query = "insert into DoctorTbl values('{0}','{1}', '{2}', '{3}', '{4}')";
                    Query = string.Format(Query, Nom, Gender, Email, Phone, Speciality);
                    Con.SetData(Query);
                    MessageBox.Show("Doctor Added!!!");
                    ShowDoctor();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        int key = 0;

        private void DocTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditiBtn_Click(object sender, EventArgs e)
        {
            if (DocTb.Text == "" || EmailTbc.Text == "" || SpecTb.Text == "" || PhoneTbc.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Nom = DocTb.Text;
                    string Phone = PhoneTbc.Text;
                    string Email = EmailTbc.Text;
                    string Gender = GenCbt.Text;
                    string Speciality = SpecTb.Text;
                    string Query = "update DoctorTbl set Name = '{0}',Gender = '{1}',Email = '{2}',Phone = '{3}', Speciality = '{4}' where DocNum = {5}";
                    Query = string.Format(Query, Nom, Gender, Email, Phone, Speciality, key);
                    Con.SetData(Query);
                    MessageBox.Show("Doctor Updated!!!");
                    ShowDoctor();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void DeletiBtn_Click(object sender, EventArgs e)
        {

            if (key == 0)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {

                    string Query = "delete from DoctorTbl where DocNum = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    MessageBox.Show("Doctor Deleted!!!");
                    ShowDoctor();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
