using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IITACLINIC
{
    public partial class Patients : Form
    {
        public Patients()
        {
            InitializeComponent();
            Con = new Functions();
            ShowPatients();
        }
        Functions Con;
        private void ShowPatients()
        {
            string Query = "Select * from PatientTbl";
            PatientDGV.DataSource = Con.GetData(Query);
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Patients_Load(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (PatTb.Text == "" || EmailTb.Text == "" || AllergiesTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Nom = PatTb.Text;
                    string Phone = PhoneTb.Text;
                    string Email = EmailTb.Text;
                    string Allergies = AllergiesTb.Text;
                    string Gender = GenCb.Text;
                    string Insurance = InsuranceTb.Text;
                    string Query = "insert into PatientTbl values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')";
                    Query = string.Format(Query, Nom, Gender, BDate.Value.Date.ToString(), Email, Phone, Insurance, Allergies, System.DateTime.Today.ToString());
                    Con.SetData(Query);
                    MessageBox.Show("Patient Added!!!");
                    ShowPatients();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        int key = 0;

        private void PatientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatTb.Text = PatientDGV.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.Text = PatientDGV.SelectedRows[0].Cells[2].Value.ToString();
            // DOBTb.Text = PatientDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmailTb.Text = PatientDGV.SelectedRows[0].Cells[4].Value.ToString();
            PhoneTb.Text = PatientDGV.SelectedRows[0].Cells[5].Value.ToString();
            InsuranceTb.Text = PatientDGV.SelectedRows[0].Cells[6].Value.ToString();
            AllergiesTb.Text = PatientDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (PatTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {

                    string Query = "delete from PatientTbl where PCode = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    MessageBox.Show("Patient Deleted!!!");
                    ShowPatients();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PatTb.Text == "" || EmailTb.Text == "" || AllergiesTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Nom = PatTb.Text;
                    string Phone = PhoneTb.Text;
                    string Email = EmailTb.Text;
                    string Allergies = AllergiesTb.Text;
                    string Gender = GenCb.Text;
                    string Insurance = InsuranceTb.Text;
                    string Query = "update PatientTbl set Name = '{0}',Gender = '{1}',DOB = '{2}',Email = '{3}',Phone = '{4}',Insurance = '{5}',Allergies = '{6}',CreatedOn = '{7}' where PCode = {8}";
                    Query = string.Format(Query, Nom, Gender, BDate.Value.Date.ToString(), Email, Phone, Insurance, Allergies, System.DateTime.Today.ToString(), key);
                    Con.SetData(Query);
                    MessageBox.Show("Patient Updated!!!");
                    ShowPatients();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu Obj = new Menu();
            Obj.Show();
            this.Hide();
        }

        private void PatTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void BDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}