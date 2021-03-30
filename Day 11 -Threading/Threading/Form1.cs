using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threading
{
    delegate void myDel();

    public partial class Form1 : Form
    {
        int count;
        public Form1()
        {
            InitializeComponent();


        }

        private int Loop(int count)
        {
            myDel del = UpdateText;
            for (int i = 0; i < 10000; i++)
            {
                count++;
                this.count = count;
                this.Invoke(del);
            }
            return count;
        }

        void UpdateText()
        {
            textBox1.Text = count.ToString();
        }

        void UpdateText(Task<int> t)
        {
            textBox1.Text = t.Result.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Task<int> tsk = Task<int>.Run(()=>Loop(1000));

            //tsk.GetAwaiter().OnCompleted(() => UpdateText(tsk));

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                count++;
                backgroundWorker1.ReportProgress(count);
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox1.Text = count.ToString();
        }
    }
}
