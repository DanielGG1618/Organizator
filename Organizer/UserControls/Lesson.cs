using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class Lesson : UserControlGG
    {
        public int Num = 1;
        public string Title = "";
        public string Homework = "Default";

        public bool Enabledd = true;
        public bool Done { get => DoneCheckBox.Checked; }

        private string defaultHomework;

        public Lesson()
        {
            InitializeComponent();
        }

        public Lesson(int num, bool done = false)
        {
            InitializeComponent();

            Initialize(num, done);
        }

        public Lesson(int num, string title, bool done = false)
        {
            InitializeComponent();

            Initialize(num, done);

            SetTitle(title);
        }

        public Lesson(int num, string title, bool done, string homework)
        {
            Homework = homework;

            InitializeComponent();

            Initialize(num, done);

            SetTitle(title);
        }

        private void Initialize(int num, bool done)
        {
            Num = num;

            NumLabel.Text = Num.ToString();
            NumLabel.BackColor = Main.GRAY[Num % 2];

            TitleLabel.Tag = Num.ToString();
            TitleLabel.BackColor = Main.GRAY[(Num + 1) % 2];

            WorkLabel.Tag = Num.ToString();
            WorkLabel.BackColor = Main.GRAY[(Num + 1) % 2];

            AddWorkButton.Tag = Num.ToString();
            AddWorkButton.BackColor = Main.GRAY[(Num + 1) % 2];

            DoneCheckBox.Tag = Num.ToString();
            DoneCheckBox.Checked = done;
        }

        public void CopyFrom(Lesson lesson)
        {
            Title = lesson.Title;
            Homework = lesson.Homework;

            if (TitleLabel == null) TitleLabel = new Label();
            TitleLabel.AccessibleName = Title;
            TitleLabel.Text = Program.Translate(TitleLabel.AccessibleName);

            if (WorkLabel == null) WorkLabel = new Label();
            WorkLabel.Text = lesson.WorkLabel.Text;

            if (DoneCheckBox == null) DoneCheckBox = new CheckBox();
            DoneCheckBox.Checked = lesson.Done;
        }

        public void TurnOff()
        {
            NumLabel.ForeColor = Main.GRAY[(Num + 1) % 2];

            TitleLabel.Text = "";
            WorkLabel.Text = "";
            DoneCheckBox.Visible = false;
            Enabledd = false;
        }

        public void SetTitle(string title)
        {
            Title = title;

            TitleLabel.AccessibleName = Title;
            TitleLabel.Text = Program.Translate(TitleLabel.AccessibleName);

            try { defaultHomework = Main.LessonsDefaultWork[Title]; }
            catch { defaultHomework = "Isn*t set"; }

            if (Homework == "Default")
            {
                WorkLabel.AccessibleName = defaultHomework;

                WorkLabel.Text = Program.Translate(WorkLabel.AccessibleName);
            }

            else
                WorkLabel.AccessibleName = "";
        }

        public void SetDone(bool done)
        {
            DoneCheckBox.Checked = done;
        }

        public static string Totxt(Lesson lesson)
        {
            string txt = lesson.Num + "╫ " + lesson.Title + "╫ " + lesson.Done + "╫ " + lesson.Homework;

            return txt;
        }

        public static Lesson Fromtxt(string txt)
        {
            string[] splited = txt.Split(new string[1] { "╫ " }, StringSplitOptions.None);

            return new Lesson(int.Parse(splited[0]), splited[1], bool.Parse(splited[2]), splited[3]);
        }
    }
}
