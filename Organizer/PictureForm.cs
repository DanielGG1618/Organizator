﻿using System;
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
    public partial class PictureForm : Form
    {
        public PictureForm(Image image)
        {
            BackgroundImage = image;
            InitializeComponent();
        }
    }
}
