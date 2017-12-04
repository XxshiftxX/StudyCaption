using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.ComponentModel;
using System.Windows.Threading;
using System.Diagnostics;
using System.IO;

namespace StudyCaption
{
    public partial class MainWindow : Window
    {
        List<Caption> captionQueue = new List<Caption>();
        int listIndex = 0;
        DispatcherTimer updateTimer = new DispatcherTimer();

        public MainWindow()
        {
            string[] smiTemp = File.ReadAllLines(@"D:\Anime\코노하나+기담+01.smi");
            foreach(string line in smiTemp)
            {
                if (!line.StartsWith("<SYNC Start"))
                    continue;

                bool isTagRead = false;
                string tag = string.Empty;
                int sync = 0;
                string caption = string.Empty;
                StringBuilder stringBuilder;
                foreach(char c in line)
                {
                    switch(c)
                    {
                        case '<':
                            isTagRead = true;
                            break;
                        case '>':
                            isTagRead = false;
                            if(tag.StartsWith("SYNC Start="))
                            {
                                sync = int.Parse(tag.Remove(0, 11));
                            }
                            else if(tag == "br")
                            {
                                stringBuilder = new StringBuilder(caption);
                                stringBuilder.Append('\n');
                                caption = stringBuilder.ToString();
                            }

                            tag = string.Empty;
                            break;
                        default:
                            if(isTagRead)
                            {
                                stringBuilder = new StringBuilder(tag);
                                stringBuilder.Append(c);
                                tag = stringBuilder.ToString();
                            }
                            else
                            {
                                stringBuilder = new StringBuilder(caption);
                                stringBuilder.Append(c);
                                caption = stringBuilder.ToString();
                            }
                            break;
                    }
                }
                caption = caption.Replace("&nbsp;", "");
                captionQueue.Add(new Caption(caption, sync));
            }

            updateTimer.Interval = TimeSpan.FromMilliseconds(0.2);
            updateTimer.Tick += Update;
            updateTimer.Start();

            InitializeComponent();

            Player.Source = new System.Uri(@"D:\Anime\코노하나+기담+1화.mp4");
            Player.LoadedBehavior = MediaState.Manual;
        }

        private void btn_Play_Click(object sender, RoutedEventArgs e)
        {
            Player.Play();
        }

        private void btn_Pause_Click(object sender, RoutedEventArgs e)
        {
            Player.Pause();
        }

        private void Update(object sender, EventArgs e)
        {
            Debug.WriteLine(Player.Position.TotalMilliseconds);
            if (captionQueue.Count > listIndex && Player.Position.TotalMilliseconds >= captionQueue[listIndex].sync)
            {
                CaptionText.Text = captionQueue[listIndex++].caption;
            }
        }

        private void ChangeCaption(string caption)
        {

        }
    }
}
