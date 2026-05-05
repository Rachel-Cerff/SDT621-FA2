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
    public partial class FrmMarksCapture : Form
    {
        public FrmMarksCapture()
        {
            InitializeComponent();
        }

        public MarkRecord? ProcessedRecord { get; private set; }

        private void btnCalculateResults_Click(object sender, EventArgs e)
        {
            // Intentional weak validation and faulty average logic for testing purposes
            MarkRecord record = new MarkRecord
            {
                StudentId = txtMarkStudentId.Text,
                StudentName = txtMarkStudentName.Text,
                Subject1 = Convert.ToDouble(txtSubject1.Text),
                Subject2 = Convert.ToDouble(txtSubject2.Text),
                Subject3 = Convert.ToDouble(txtSubject3.Text),
            };

            record.Average = Math.Round((record.Subject1 + record.Subject2 + record.Subject3) / 3.0, 2);
            record.ResultStatus = record.Average >= 50 ? "PASS" : "FAIL";

            ProcessedRecord = record;


            txtMarksOutput.Text =
                "Marks processed successfully!" + Environment.NewLine +
                "Student ID: " + record.StudentId + Environment.NewLine +
                "Student Name: " + record.StudentName + Environment.NewLine +
                "Subject 1: " + record.Subject1 + Environment.NewLine +
                "Subject 2: " + record.Subject2 + Environment.NewLine +
                "Subject 3: " + record.Subject3 + Environment.NewLine +
                "Average: " + record.Average.ToString("F2") + Environment.NewLine +
                "Final Result: " + record.ResultStatus;
        }

        private void btnClearMarks_Click(object sender, EventArgs e)
        {
            txtMarkStudentId.Clear();
            txtMarkStudentName.Clear();
            txtSubject1.Clear();
            txtSubject2.Clear();
            txtSubject3.Clear();
            txtMarksOutput.Clear();
            txtMarkStudentId.Focus();
        }

        private void btnBackMarks_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
