using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class TimerForm : Form
    {
        private Image[] timerImages = new Image[24];
        private Image pause, start;
        private bool started, work = true, pauseInEnd, counter;
        private int time, targetTime, workTime = 25 * 60, breakTime = 5 * 60, worksCount = 1;
        
        public TimerForm()
        {
            LoadFiles();
            targetTime = workTime;
            
            InitializeComponent();
        }

        private void TimerForm_Load(object sender, EventArgs e)
        {
            UpdateCyclesLabel(worksCount, counter);
            UpdateTimeLabel(targetTime - time);

            workTextBox.Text = (workTime / 60).ToString();
            breakTextBox.Text = (breakTime / 60).ToString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time++;

            if (time > targetTime)
            {
                if(!work) worksCount++;
                ChangeWork();
            }

            UpdateTimeLabel(targetTime - time);

            timerPicture.Image = timerImages[time % 24];
        }

        private void LoadFiles()
        {
            for(int i = 0; i < timerImages.Length; i++)
                timerImages[i] = Image.FromFile("Timer images/" + i + ".png");

            start = Image.FromFile("Timer images/start.png");
            pause = Image.FromFile("Timer images/pause.png");

            try
            {
                string[] timerSave = File.ReadAllLines("TimerSave.txt");

                workTime = int.Parse(timerSave[0]) * 60;
                breakTime = int.Parse(timerSave[1]) * 60;
                pauseInEnd = bool.Parse(timerSave[2]);
                counter = bool.Parse(timerSave[3]);
                worksCount = File.GetLastAccessTime("TimerSave.txt").Date == DateTime.Today ? int.Parse(timerSave[4]) : 1;
            }

            catch
            {
                SaveTimer();
            }
        }

        private void SaveFiles(object sender, FormClosingEventArgs e)
        {
            SaveTimer();
        }

        private void SaveTimer()
        {
            string[] timerSave = new string[5];

            timerSave[0] = (workTime / 60).ToString();
            timerSave[1] = (breakTime / 60).ToString();
            timerSave[2] = pauseInEnd.ToString();
            timerSave[3] = counter.ToString();
            timerSave[4] = worksCount.ToString();

            File.WriteAllLines("TimerSave.txt", timerSave);
        }

        private void WorkTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckDigit(sender);
        }

        private void BreakTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckDigit(sender);
        }

        private void CheckDigit(object sender)
        {
            TextBox textBox = (TextBox)sender;

            if (!int.TryParse(textBox.Text, out _) && textBox.Text.Length > 0)
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void ResetTimer_Click(object sender, EventArgs e)
        {
            time = -1;

            Timer_Tick(sender, e);
        }

        private void SkipButton_Click(object sender, EventArgs e)
        {
            if (!work) worksCount++;
            ChangeWork();
        }

        private void ChangeWork()
        {
            time = -1;

            work = !work;
            skipButton.Text = "Пропустить " + (work ? "работу" : "отдых");

            targetTime = work ? workTime : breakTime;

            Timer_Tick(0, new EventArgs());
            UpdateCyclesLabel(worksCount, counter);

            if (pauseInEnd)
            {
                started = false;
                startPause.Image = start;

                timer.Enabled = false;
            }
        }

        private void StartPause_Click(object sender, EventArgs e)
        {
            started = !started;
            startPause.Image = started ? pause : start;

            timer.Enabled = started;
        }

        private bool settings = false;

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            settings = !settings;

            if (!settings)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Настройки таймера", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    workTime = int.Parse(workTextBox.Text) * 60;
                    breakTime = int.Parse(breakTextBox.Text) * 60;

                    if(time == 0)
                        targetTime = work ? workTime : breakTime;

                    pauseInEnd = pauseCheckBox.Checked;
                    counter = couterCheckBox.Checked;
                    UpdateCyclesLabel(worksCount, counter);
                    UpdateTimeLabel(targetTime - time);
                }

                else if (result == DialogResult.Cancel)
                    settings = true;
            }

            settingsButton.ForeColor = settings ? Color.LimeGreen : Head.ProjectColor;
            startPause.Visible = !settings;

            workTextBox.Text = (workTime / 60).ToString();
            breakTextBox.Text = (breakTime / 60).ToString();

            pauseCheckBox.Checked = pauseInEnd;
            couterCheckBox.Checked = counter;

            workLabel.Visible = settings;//\\//\\
            breakLabel.Visible = settings;//\\//\\//\\
            workTextBox.Visible = settings;//\\//\\//\\//\\
            breakTextBox.Visible = settings;//\\//\\//\\//\\//\\
            pauseCheckBox.Visible = settings;//\\//\\//\\//\\//\\//\\
            couterCheckBox.Visible = settings;//\\//\\//\\//\\\//\\//\\//\\
        }

        private void UpdateCyclesLabel(int _worksCount, bool _counter)
        {
            cycleLabel.Text = "цикл №" + _worksCount;

            if(_counter)
            {
                timeLabel.Size = new Size(194, 40);
                timeLabel.Font = new Font(timeLabel.Font.Name, 18, FontStyle.Bold);

                cycleLabel.Visible = true;
            }

            else
            {
                timeLabel.Size = new Size(194, 66);
                timeLabel.Font = new Font(timeLabel.Font.Name, 24, FontStyle.Bold);

                cycleLabel.Visible = false;
            }
        }

        private void UpdateTimeLabel(int _time)
        {
            int minutes = _time / 60;
            int seconds = _time - (minutes * 60);

            timeLabel.Text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }
}
