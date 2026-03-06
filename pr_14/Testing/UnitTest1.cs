using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using pr_14;

namespace Testing
{
    public class TestableForm2 : Form2
    {
        public void SimulateFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }

    [TestClass]
    public class Form2Tests
    {
        [TestMethod]
        public void AnsweredYes_DefaultValue_IsFalse()
        {
            var form = new TestableForm2();
            Assert.IsFalse(form.answeredYes);
        }

        [TestMethod]
        public void FormClosing_UserClicksYes_FormClosesAndFlagBecomesTrue()
        {
            var form = new TestableForm2();
            var original = Form2.MessageBoxDependency;

            Form2.MessageBoxDependency = (msg, title, buttons) => DialogResult.Yes;

            try
            {
                var args = new FormClosingEventArgs(CloseReason.UserClosing, false);
                form.SimulateFormClosing(args);

                Assert.IsFalse(args.Cancel);
                Assert.IsTrue(form.answeredYes);
            }
            finally
            {
                Form2.MessageBoxDependency = original;
                form.Dispose();
            }
        }

        [TestMethod]
        public void FormClosing_UserClicksNo_ClosingIsCancelled_FlagRemainsFalse()
        {
            var form = new TestableForm2();
            var original = Form2.MessageBoxDependency;

            Form2.MessageBoxDependency = (msg, title, buttons) => DialogResult.No;

            try
            {
                var args = new FormClosingEventArgs(CloseReason.UserClosing, false);
                form.SimulateFormClosing(args);

                Assert.IsTrue(args.Cancel);
                Assert.IsFalse(form.answeredYes);
            }
            finally
            {
                Form2.MessageBoxDependency = original;
                form.Dispose();
            }
        }

        [TestMethod]
        public void FormClosing_MultipleNo_ThenYes_OnlyLastYesCloses()
        {
            var form = new TestableForm2();
            var original = Form2.MessageBoxDependency;

            try
            {
                Form2.MessageBoxDependency = (msg, title, buttons) => DialogResult.No;
                var args1 = new FormClosingEventArgs(CloseReason.UserClosing, false);
                form.SimulateFormClosing(args1);
                Assert.IsTrue(args1.Cancel);
                Assert.IsFalse(form.answeredYes);

                var args2 = new FormClosingEventArgs(CloseReason.UserClosing, false);
                form.SimulateFormClosing(args2);
                Assert.IsTrue(args2.Cancel);
                Assert.IsFalse(form.answeredYes);

                Form2.MessageBoxDependency = (msg, title, buttons) => DialogResult.Yes;
                var args3 = new FormClosingEventArgs(CloseReason.UserClosing, false);
                form.SimulateFormClosing(args3);
                Assert.IsFalse(args3.Cancel);
                Assert.IsTrue(form.answeredYes);
            }
            finally
            {
                Form2.MessageBoxDependency = original;
                form.Dispose();
            }
        }

        [TestMethod]
        public void Button1Click_OpensForm2_AsDialog()
        {
            var form1 = new Form1();
            form1.button1_Click(null, EventArgs.Empty);
        }
    }
}