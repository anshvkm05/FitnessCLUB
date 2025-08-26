using NUnit.Framework;
using System;
using System.Reflection;
using System.Windows.Forms;
using FitnessCLUB;           
using FitnessCLUB.Resources; 

namespace FitnessCLUB.Tests
{
    [TestFixture]
    public class TestGoalAddition
    {
        private Goal goalControl;
        private Dashboard dummyDashboard;

        [SetUp]
        public void Setup()
        {
            dummyDashboard = new Dashboard();
            goalControl = new Goal(dummyDashboard);
            goalControl.txtGoalName1.Text = "";
            goalControl.select_Excercise.Items.Clear();
            goalControl.select_Excercise.Text = "";
            goalControl.txtTime.Text = "";
            goalControl.txtMetric1.Text = "";
            goalControl.txtMetric2.Text = "";
            goalControl.txtMetric3.Text = "";
        }

        [Test]
        public void Test_AddGoal_ValidInput_ShouldClearFieldsAfterInsertion()
        {
            goalControl.txtGoalName1.Text = "Morning Run";
            goalControl.select_Excercise.Items.Add("Running");
            goalControl.select_Excercise.SelectedItem = "Running";
            goalControl.txtTime.Text = "12:30";
            goalControl.txtMetric1.Text = "moderate";
            goalControl.txtMetric2.Text = "5";
            goalControl.txtMetric3.Text = "30";
            goalControl.weight = 70;
            goalControl.UserCALB = 100;

            MethodInfo method = typeof(Goal).GetMethod("Addgoalbtn_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(method, Is.Not.Null, "Addgoalbtn_Click method not found.");
            method.Invoke(goalControl, new object[] { null, EventArgs.Empty });

            Assert.That(goalControl.txtGoalName1.Text, Is.Empty, "Goal name should be cleared after valid insertion.");
            Assert.That(goalControl.select_Excercise.Text, Is.Empty, "Exercise selection should be cleared after valid insertion.");
            Assert.That(goalControl.txtTime.Text, Is.Empty, "Time field should be cleared after valid insertion.");
            Assert.That(goalControl.txtMetric1.Text, Is.Empty, "Metric1 field should be cleared after valid insertion.");
            Assert.That(goalControl.txtMetric2.Text, Is.Empty, "Metric2 field should be cleared after valid insertion.");
            Assert.That(goalControl.txtMetric3.Text, Is.Empty, "Metric3 field should be cleared after valid insertion.");
        }

        [Test]
        public void Test_AddGoal_InvalidInput_ShouldNotClearFields()
        {
            goalControl.txtGoalName1.Text = ""; 
            goalControl.select_Excercise.Items.Add("Running");
            goalControl.select_Excercise.SelectedItem = "Running";
            goalControl.txtTime.Text = "12:30";
            goalControl.txtMetric1.Text = "moderate";
            goalControl.txtMetric2.Text = "5";
            goalControl.txtMetric3.Text = "30";

            MethodInfo method = typeof(Goal).GetMethod("Addgoalbtn_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(method, Is.Not.Null, "Addgoalbtn_Click method not found.");
            method.Invoke(goalControl, new object[] { null, EventArgs.Empty });

            Assert.That(goalControl.txtGoalName1.Text, Is.Empty, "Goal name field remains empty due to invalid input.");
            Assert.That(goalControl.txtTime.Text, Is.Not.Empty, "Time field should remain unchanged on invalid input.");
            Assert.That(goalControl.txtMetric1.Text, Is.Not.Empty, "Metric1 field should remain unchanged on invalid input.");
            Assert.That(goalControl.txtMetric2.Text, Is.Not.Empty, "Metric2 field should remain unchanged on invalid input.");
            Assert.That(goalControl.txtMetric3.Text, Is.Not.Empty, "Metric3 field should remain unchanged on invalid input.");
        }
    }
}
