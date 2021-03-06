﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Organizer.Properties;

namespace Organizer
{
    public partial class UserControlGG : UserControl
    {
        public List<Control> LocalizationControls = new List<Control>();
        public List<List<Control>> ThemedControls = new List<List<Control>>();

        public UserControlGG()
        {
            InitializeComponent();
        }

        public virtual void ApplyColor()
        {
            ForeColor = Settings.Default.Color;
        }

        public virtual void ApplyLocalization()
        {
            foreach (var control in LocalizationControls)
                if (!string.IsNullOrEmpty(control.Text) && !string.IsNullOrEmpty(control.AccessibleName))
                    control.Text = Localization.Translate(control.AccessibleName);
        }

        public void ApplyAll()
        {
            ApplyColor();
            ApplyLocalization();
        }
    }
}
