using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlainTextFileSearcher.Business.DesignPatterns;
using PlainTextFileSearcher.Business.ExtensionMethods;
using PlainTextFileSearcher.Business.Methods;
using PlainTextFileSearcher.Business.Services;
using PlainTextFileSearcher.Business.Singletons;
using PlainTextFileSearcher.Business.Types;

namespace PlainTextFileSearcher.Winforms
{
    public partial class Form1 : Form
    {
        private const string SEARCH = "Search";
        private const string CANCEL = "Cancel";

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            bool AssignedText = false;

            if (btnSearch.Text == CANCEL)
            {
                CancelationTokenSingleton.GetCancellationTokenSource().Cancel();
                progressBar1.Value = 0;
                tbxSearchResults.Text = "";
                btnSearch.Text = SEARCH;
                AssignedText = true;
            }

            if (AssignedText == false)
            {

                if (btnSearch.Text == SEARCH)
                {
                    progressBar1.Value = 0;
                    tbxSearchResults.Text = "";
                    btnSearch.Text = CANCEL;
                    btnSearch.Update();
                }
            }


            try
            {

                Stopwatch STPWTCH = new Stopwatch();
                string path = lblOpenedFolder.Text;
                string word = tbxSearch.Text;
                ConcurrentList<string> AllFiles = await AsyncCalls.GetFilesAsync(path);
                ConcurrentList<string> AllLines = new ConcurrentList<string>();
                int AmountOfFoundFiles = 0;
                int AmountOfFoundLines = 0;
                STPWTCH.Start();
                await Iterations.AllFilesIteratorAsync(AllFiles, word, AmountOfFoundFiles, AllLines, path, AmountOfFoundLines);
                this.Invoke(new MethodInvoker(delegate () { AssignValueToLabel(STPWTCH); }));
                this.AutoScroll = false;
                //progressBar1.Maximum = AllFiles.Count;
                progressBar1.Maximum = AllFiles.Count;
                progressBar1.Minimum = 0;
                progressBar1.Step = 1;
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.Invoke((Action)(async () =>
                {
                    for (int i = 0; i <= AllFiles.Count; i += 1)
                    {
                            await Task.Delay(50);
                            progressBar1.Value = ResultsSingleton.GetCurrentFileCount();                        
                    }
    
                }
                ));
                //tbxSearchResults.Text = string.Join(Environment.NewLine,ResultsSingleton.GetResults().ToArray());
                btnSearch.Text = SEARCH;
        }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Application.Restart();
                Environment.Exit(0);
            }

}

        private async Task AssignValueToLabelAsync(Stopwatch STPWTCH)
        {
            Form1 form = this;
            Task Assign = new Task(() => form.AssignValueToLabel(STPWTCH), CancelationTokenSingleton.GetCancelationToken());
            Assign.Start();
            await Assign;
        }
        private async void AssignValueToLabel(Stopwatch STPWTCH)
        {
            ConcurrentList<string> LabelValues = new ConcurrentList<string>();
            int ListCount = 0;
            while (true)
            {
                await Task.Delay(50);
                LabelValues = ResultsSingleton.GetResults().Distinct().ToList().ToConcurrentList<string>();
                lblMatchesInFiles.Text = "files with matches: " + ResultsSingleton.GetCurrentFoundFiles().ToString();
                lblTotalMatches.Text = "total matches: " + ResultsSingleton.GetCurrentFoundLines().ToString();
                tbxSearchResults.Text = string.Join(Environment.NewLine, LabelValues.ToArray());
                if (ListCount < LabelValues.Count())
                {
                    ListCount = LabelValues.Count();
                    TimeSpan TS = STPWTCH.Elapsed;
                    lblTimePassedMs.Text = "🕑" + TS.TotalMilliseconds;
                }
                else
                {
                    STPWTCH.Stop();
                    TimeSpan TS = STPWTCH.Elapsed;
                    lblTimePassedMs.Text = "🕑" + TS.TotalMilliseconds;
                    break;
                }
            }
        }

        
        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            lblOpenedFolder.Text = folderBrowserDialog.SelectedPath;
            btnSearch.Enabled = true;
        }

        private void tbxSearchResults_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTotalMatches_Click(object sender, EventArgs e)
        {

        }
    }
}
