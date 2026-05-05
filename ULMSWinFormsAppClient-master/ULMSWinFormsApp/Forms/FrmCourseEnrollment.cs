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
    public partial class FrmCourseEnrollment : Form
    {
        public Enrollment? CurrentEnrollment { get; private set; }

        public FrmCourseEnrollment()
        {
            InitializeComponent();
        }

        public static class EnrollmentStore
        {
            public static List<Enrollment> Enrollments { get; } = new List<Enrollment>();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            // Intentional weak business-rule validation for testing purposes
            Enrollment newEnrollment = new Enrollment
            {
                StudentId = txtEnrollStudentId.Text,
                StudentName = txtEnrollStudentName.Text,
                CourseName = cmbCourse.Text,
                Semester = cmbSemester.Text
            };

            //Check for duplicate enrollments
            bool alreadyEnrolled = EnrollmentStore.Enrollments.Any(e => e.StudentId == newEnrollment.StudentId &&
                  e.CourseName == newEnrollment.CourseName);

            if (alreadyEnrolled) 
            {
                MessageBox.Show("this Student is already enrolled in " + newEnrollment.CourseName + " Enrollment blocked.");
                return;
            }

            EnrollmentStore.Enrollments.Add(newEnrollment);
            CurrentEnrollment = newEnrollment;

            txtEnrollmentOutput.Text =
                "Enrollment completed successfully!" + Environment.NewLine +
                "Student ID: " + newEnrollment.StudentId + Environment.NewLine +
                "Student Name: " + newEnrollment.StudentName + Environment.NewLine +
                "Course: " + newEnrollment.CourseName + Environment.NewLine +
                "Semester: " + newEnrollment.Semester;
        }

        private void btnClearEnrollment_Click(object sender, EventArgs e)
        {
            txtEnrollStudentId.Clear();
            txtEnrollStudentName.Clear();
            cmbCourse.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            txtEnrollmentOutput.Clear();
            txtEnrollStudentId.Focus();
        }

        private void btnBackEnrollment_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
