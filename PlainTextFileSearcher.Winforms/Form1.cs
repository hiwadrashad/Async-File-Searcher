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
                btnSearch.Text = SEARCH;
                AssignedText = true;
            }

            if (AssignedText == false)
            {
                if (btnSearch.Text == SEARCH)
                {
                    btnSearch.Text = CANCEL;
                    btnSearch.Update();
                }
            }


            //try
            //{

                Stopwatch STPWTCH = new Stopwatch();
                string path = lblOpenedFolder.Text;
                string word = tbxSearch.Text;
                ConcurrentList<string> AllFiles = await AsyncCalls.GetFilesAsync(path);
                ConcurrentList<string> AllLines = new ConcurrentList<string>();
                int AmountOfFoundFiles = 0;
                int AmountOfFoundLines = 0;
                STPWTCH.Start();
                await Iterations.AllFilesIteratorAsync(AllFiles, word, AmountOfFoundLines,AllLines, path, AmountOfFoundLines);
                lblMatchesInFiles.Text = "files with matches: " + AmountOfFoundFiles.ToString();
                lblTotalMatches.Text = "total matches: " + AmountOfFoundLines.ToString();
                STPWTCH.Stop();
                TimeSpan TS = STPWTCH.Elapsed;

                lblTimePassedMs.Text = "🕑" + TS.TotalMilliseconds;
                tbxSearchResults.Text = string.Join(Environment.NewLine, AllLines.ToArray());
                btnSearch.Text = SEARCH;
//            }
//#pragma warning disable CS0168 // Variable is declared but never used
//            catch (Exception ex)
//#pragma warning restore CS0168 // Variable is declared but never used
//            {
//                Application.Restart();
//                Environment.Exit(0);
//            }

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
