using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmStudentRegistration : Form
    {
        public FrmStudentRegistration()
        {
            InitializeComponent();
        }

        public Student? RegisteredStudent { get; private set; }

        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            // Intentional weak validation for testing purposes
            RegisteredStudent = new Student
            {
                StudentId = txtStudentId.Text,
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Age = int.Parse(txtAge.Text),
                Programme = cmbProgramme.Text
            };

            txtStudentOutput.Text =
                "Student saved successfully!" + Environment.NewLine +
                "Student ID: " + RegisteredStudent.StudentId + Environment.NewLine +
                "Full Name: " + RegisteredStudent.FullName + Environment.NewLine +
                "Email: " + RegisteredStudent.Email + Environment.NewLine +
                "Age: " + RegisteredStudent.Age + Environment.NewLine +
                "Programme: " + RegisteredStudent.Programme;
        }

        private void btnClearStudent_Click(object sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            cmbProgramme.SelectedIndex = -1;
            txtStudentOutput.Clear();
            txtStudentId.Focus();
        }

        //Add Back button to return to dashboard
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
