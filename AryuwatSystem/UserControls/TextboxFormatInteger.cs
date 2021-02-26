using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AryuwatSystem.UserControls
{
    public partial class TextboxFormatInteger : TextBox 
    {
        public TextboxFormatInteger()
        {
            InitializeComponent();
        }

        public TextboxFormatInteger(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            TextAlign = HorizontalAlignment.Right;
            Validated += TextboxFormatInteger_Validated;
            KeyPress += TextboxFormatInteger_KeyPress;
        }

        public bool CurrencyOnly(TextBox TargetTextBox, char CurrentChar)
        {
            if (CurrentChar >= 48 && CurrentChar <= 57)
            {
                return false;
            }

            //if (Convert.ToString(CurrentChar) == "." && TargetTextBox.Text.IndexOf(".") == -1)
            //{
            //    return false;
            //}

            if (CurrentChar == Convert.ToChar(Keys.Back))
            {
                return false;
            }

            return true;
        }

        void TextboxFormatInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CurrencyOnly(this, e.KeyChar); 
        }

        void TextboxFormatInteger_Validated(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Text.Trim()))
                {
                    //Text = "0";
                    return;
                }
                //this.Text = doub.ToString("n");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
