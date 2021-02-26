using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AryuwatSystem.Forms
{
    public partial class TextPrompt : Form
    {
        public string Value
        {
            get { return tbText.Text.Trim(); }
        }

        public TextPrompt(string promptInstructions)
        {
            InitializeComponent();

            //lblPromptText.Text = promptInstructions;
        }

        //private void BtnSubmitText_Click(object sender, EventArgs e)
        //{
        //    Close();
        //}

        private void TextPrompt_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            tbText.Text = "0";
            Close();
        }
    }
}
