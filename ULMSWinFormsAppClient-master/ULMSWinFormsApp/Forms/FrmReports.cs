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
    public partial class FrmReports : Form
    {
        private Student _student;
        private MarkRecord _markRecord;
        private Enrollment _enrollment;

        public FrmReports(Student student, MarkRecord record, Enrollment enrollment)
        {
            InitializeComponent();
            _student = student;
            _markRecord = record;
            _enrollment = enrollment;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Intentional weak validation and slow processing for testing purposes
            string reportType = cmbReportType.Text;
            string studentId = txtReportStudentId.Text;

            /*Intentional poor performance simulation
            Thread.Sleep(4000);*/

            StringBuilder report = new StringBuilder();
            report.AppendLine("===== ULMS REPORT =====");
            report.AppendLine("Report Type: " + reportType);
            report.AppendLine("Generated On: " + DateTime.Now);
            report.AppendLine();

            if (reportType == "Student Summary Report" && _student != null)
            {
                report.AppendLine("Student ID Filter: " + _student.StudentId);
                report.AppendLine("Student Name: " + _student.FullName);
                report.AppendLine("Programme: " + _student.Programme);
                report.AppendLine("Status: Active");
            }
            else if (reportType == "Marks Report" && _markRecord != null)
            {
                report.AppendLine("Student ID Filter: " + _markRecord.StudentId);
                report.AppendLine("Subject 1: " + _markRecord.Subject1);
                report.AppendLine("Subject 2: " + _markRecord.Subject2);
                report.AppendLine("Subject 3: " + _markRecord.Subject3);
                report.AppendLine("Average: " + _markRecord.Average);
            }
            else if (reportType == "Enrollment Report" && _enrollment != null)
            {
                report.AppendLine("Student ID: " + _enrollment.StudentId);
                report.AppendLine("Student Name: " + _enrollment.StudentName);
                report.AppendLine("Course: " + _enrollment.CourseName);
                report.AppendLine("Semester: " + _enrollment.Semester);
            }
            else
            {
                report.AppendLine("No report type selected.");
            }

            txtReportOutput.Text = report.ToString();
        }

        private void btnClearReport_Click(object sender, EventArgs e)
        {
            cmbReportType.SelectedIndex = -1;
            txtReportStudentId.Clear();
            txtReportOutput.Clear();
            txtReportStudentId.Focus();
        }

        private void btnBackReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
