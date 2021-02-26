using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
namespace AryuwatSystem.Forms
{
    public partial class FrmEnAndDeCode : Form
    {
        public FrmEnAndDeCode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBoxORG.Text.Length > 5)
                    textBoxEN.Text = EncryptDecrypText.encryptPassword(textBoxORG.Text);
                else if (textBoxEN.Text.Length > 5)
                    textBoxORG.Text = EncryptDecrypText.decryptPassword(textBoxEN.Text);
                  
            }
            catch (Exception ex)
            {
                
              
            }
        }
    }
}
