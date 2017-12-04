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

namespace StudyCaption
{
    public partial class MainWindow : Window
    {
        List<Caption> CaptionQueue = new List<Caption>();
        int listIndex = 0;
        private BackgroundWorker myThread;

        public MainWindow()
        {
            InitializeComponent();

            Player.Source = new System.Uri(@"D:\Anime\코노하나+기담+1화.mp4");
            Player.LoadedBehavior = MediaState.Manual;

            CaptionQueue.Add(new Caption("사람이 잔뜩 있어~", 7055));
            CaptionQueue.Add(new Caption("", 8917));
            CaptionQueue.Add(new Caption("유즈", 9569));
            CaptionQueue.Add(new Caption("", 10421));
            CaptionQueue.Add(new Caption("유즈!", 10421));
            CaptionQueue.Add(new Caption("사람이 잔뜩 있어~", 12440));
            CaptionQueue.Add(new Caption("멍하니 있다가는 떨어지고 말 거에요?", 13420));
            CaptionQueue.Add(new Caption("네! 비구니님!", 15008));
            
            
            Thread updateThread = new Thread(Update);
            updateThread.Start();
            
        }

        private void btn_Play_Click(object sender, RoutedEventArgs e)
        {
            Player.Play();
        }

        private void btn_Pause_Click(object sender, RoutedEventArgs e)
        {
            Player.Pause();
        }

        private void Update()
        {
            while (true)
            {
                System.Diagnostics.Debug.WriteLine(CaptionQueue[listIndex].sync + " / " + Player.Position.TotalMilliseconds);
                if (CaptionQueue.Count > listIndex && Player.Position.TotalMilliseconds >= CaptionQueue[listIndex].sync)
                {
                    CaptionText.Text = CaptionQueue[listIndex++].caption;
                }
            }
        }

        private void ChangeCaption(string caption)
        {

        }
    }
}
