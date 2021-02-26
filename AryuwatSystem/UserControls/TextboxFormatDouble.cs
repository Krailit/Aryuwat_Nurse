using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AryuwatSystem.UserControls
{
    public partial class TextboxFormatDouble :TextBox 
    {
        public TextboxFormatDouble()
        {
            InitializeComponent();
        }

        public TextboxFormatDouble(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            TextAlign = HorizontalAlignment.Right;
            Validating += TextboxDouble_Validating;
            KeyPress += TextboxDouble_KeyPress;
        }
        private void TextboxDouble_Validating(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Text.Trim()))
                {
                    Text = "";
                    return;
                }
                decimal doub = Convert.ToDecimal(Text);
                Text = doub.ToString("###,###,###,###.##");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool CurrencyOnly(TextBox  TargetTextBox, char CurrentChar)
        {
            if (CurrentChar >= 48 && CurrentChar <= 57)
            {
                return false;
            }

            if (Convert.ToString(CurrentChar) == "." && TargetTextBox.Text.IndexOf(".") == -1)
            {
                return false;
            }

            if (CurrentChar == Convert.ToChar(Keys.Back))
            {
                return false;
            }

            return true;
        }
        private void TextboxDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CurrencyOnly(this, e.KeyChar); 
        }
    }
}
