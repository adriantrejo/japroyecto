﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Japolingo_0._0._1.GUI
{
    public partial class Aprendizaje : Form
    {
        public Aprendizaje()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void ExamenesM_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Lecciones().Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new Kanji().Show();
        }
    }
}
