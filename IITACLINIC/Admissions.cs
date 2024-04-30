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
    public partial class Admissions : Form
    {
        public Admissions()
        {
            InitializeComponent();
            Con = new Functions();
            ShowAdmissions();

        }
        Functions Con;

        private void ShowAdmissions()
        {
            string Query = "Select * from AdmissionsTbl";
            AdmissionDGV.DataSource = Con.GetData(Query);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AdmissionDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            APatTb.Text = AdmissionDGV.SelectedRows[0].Cells[1].Value.ToString();
            AdocTb.Text = AdmissionDGV.SelectedRows[0].Cells[2].Value.ToString();
            RTb.Text = AdmissionDGV.SelectedRows[0].Cells[4].Value.ToString();
            WTb.Text = AdmissionDGV.SelectedRows[0].Cells[5].Value.ToString();
            TemTb.Text = AdmissionDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (APatTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(AdmissionDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void AdmitBtn_Click(object sender, EventArgs e)
        {
            if (APatTb.Text == "" || AdocTb.Text == "" || RTb.Text == "" || WTb.Text == "" || TemTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Patient = APatTb.Text;
                    string Doctor = AdocTb.Text;
                    string Reason = RTb.Text;
                    string Weight = WTb.Text;
                    string Temperature = TemTb.Text;
                    string Query = "insert into AdmissionsTbl values('{0}','{1}', '{2}', '{3}', '{4}', '{5}')";
                    Query = string.Format(Query, Patient, Doctor, Reason, AdDate.Value.Date.ToString(), Weight, Temperature, System.DateTime.Today.ToString());
                    Con.SetData(Query);
                    MessageBox.Show("Patient Added!!!");
                    ShowAdmissions();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        int key = 0;

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DeletitiBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {

                    string Query = "delete from AdmissionsTbl where AdNum = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    MessageBox.Show("Admission Deleted!!!");
                    ShowAdmissions();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void EditiiBtn_Click(object sender, EventArgs e)
        {
            if (APatTb.Text == "" || AdocTb.Text == "" || RTb.Text == "" || WTb.Text == "" || TemTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Patient = APatTb.Text;
                    string Doctor = AdocTb.Text;
                    string Reason = RTb.Text;
                    string Weight = WTb.Text;
                    string Temperature = TemTb.Text;
                    string Query = "update AdmissionsTbl set Patient = '{0}',Doctor = '{1}',Reason = '{2}',DataAd = '{3}',PWeight = '{4}',Temperature = '{5}' where AdNum = {6}";
                    Query = string.Format(Query, Patient, Doctor, Reason, AdDate.Value.Date.ToString(), Weight, Temperature, key);
                    Con.SetData(Query);
                    MessageBox.Show("Admission Updated!!!");
                    ShowAdmissions();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void BackiiBtn_Click(object sender, EventArgs e)
        {
            Menu Obj = new Menu();
            Obj.Show();
            this.Hide();
        }

        private void RTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

