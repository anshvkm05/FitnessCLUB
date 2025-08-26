using NUnit.Framework;
using Moq;
using System;
using System.Reflection;
using System.Windows.Forms;
using FitnessCLUB;
using FitnessCLUB.Resources;
using Guna.UI2.WinForms;

namespace FitnessCLUB.Tests
{
    [TestFixture]
    public class ActivityTests
    {
        private Activity activityControl;
        private Dashboard dummyDashboard;

        [SetUp]
        public void Setup()
        {
            dummyDashboard = new Dashboard();
            activityControl = new Activity(dummyDashboard);
            activityControl.Controls["txtTime"].Text = "30";
            activityControl.Controls["txtMetric1"].Text = "moderate";
            activityControl.Controls["txtMetric2"].Text = "5";
            activityControl.Controls["txtMetric3"].Text = "30";
            ((Guna2CustomRadioButton)activityControl.Controls["rdoRunning"]).Checked = false;
            ((Guna2CustomRadioButton)activityControl.Controls["rdoSwimming"]).Checked = false;
            ((Guna2CustomRadioButton)activityControl.Controls["rdoWalking"]).Checked = false;
            ((Guna2CustomRadioButton)activityControl.Controls["rdoSkipping"]).Checked = false;
            ((Guna2CustomRadioButton)activityControl.Controls["rdoCycling"]).Checked = false;
            ((Guna2CustomRadioButton)activityControl.Controls["rdoZumba"]).Checked = false;
        }
        [Test]
        public void EmptyFields_ShouldShowErrorMessage()
        {
            activityControl.Controls["txtTime"].Text = "";
            activityControl.Controls["txtMetric1"].Text = "";
            activityControl.Controls["txtMetric2"].Text = "";
            activityControl.Controls["txtMetric3"].Text = "";
            var runningRadio = (Guna2CustomRadioButton)activityControl.Controls["rdoRunning"];
            runningRadio.Checked = true;
            activityControl.ShowMessageCallback = (text, caption, buttons, icon) =>
            {
                throw new Exception(text);
            };
            var method = typeof(Activity).GetMethod("Addgoalbtn_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(method, Is.Not.Null, "Addgoalbtn_Click method was not found.");

            var ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(activityControl, new object[] { null, EventArgs.Empty }));
            Assert.That(ex.InnerException.Message, Is.EqualTo("Please fill in all fields."), "Error message did not match.");
        }
        [Test]
        public void InvalidMetric3Field_ShouldShowError()
        {
            activityControl.Controls["txtTime"].Text = "10";
            activityControl.Controls["txtMetric1"].Text = "moderate";
            activityControl.Controls["txtMetric2"].Text = "5";
            activityControl.Controls["txtMetric3"].Text = "invalid"; 
            var runningRadio = (Guna2CustomRadioButton)activityControl.Controls["rdoRunning"];
            runningRadio.Checked = true;

            LoginUser.SessionManager.CurrentUserID = "Admin";

            activityControl.ShowMessageCallback = (text, caption, buttons, icon) =>
            {
                throw new Exception(text); 
            };
            var method = typeof(Activity).GetMethod("Addgoalbtn_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(method, Is.Not.Null, "Addgoalbtn_Click method was not found.");

            var ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(activityControl, new object[] { null, EventArgs.Empty }));
            Assert.That(ex.InnerException, Is.InstanceOf<FormatException>(), "Expected a FormatException due to invalid txtMetric3 value.");
        }
        [Test]
        public void AddActivity_WithValidData_ShouldClearFields()
        {
            activityControl.Controls["txtTime"].Text = "12:30";
            activityControl.Controls["txtMetric1"].Text = "moderate";
            activityControl.Controls["txtMetric2"].Text = "5";
            activityControl.Controls["txtMetric3"].Text = "30";
            activityControl.weight = 70;
            activityControl.UserCALB = 100;


            var runningRadio = (Guna2CustomRadioButton)activityControl.Controls["rdoRunning"];
            runningRadio.Checked = true;

            LoginUser.SessionManager.CurrentUserID = "Admin";
            activityControl.ShowMessageCallback = (text, caption, buttons, icon) =>
            {
                return DialogResult.OK; 
            };
            var method = typeof(Activity).GetMethod("Addgoalbtn_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(method, Is.Not.Null, "Addgoalbtn_Click method was not found.");
            method.Invoke(activityControl, new object[] { null, EventArgs.Empty });

            Assert.That(activityControl.Controls["txtTime"].Text, Is.Empty, "Time field should be cleared.");
            Assert.That(activityControl.Controls["txtMetric1"].Text, Is.Empty, "Metric1 field should be cleared.");
            Assert.That(activityControl.Controls["txtMetric2"].Text, Is.Empty, "Metric2 field should be cleared.");
            Assert.That(activityControl.Controls["txtMetric3"].Text, Is.Empty, "Metric3 field should be cleared.");
        }
    }
}
