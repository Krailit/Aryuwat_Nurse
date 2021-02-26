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
    public partial class PopDateTime : Form
    {
        public PopDateTime()
        {
            InitializeComponent();
          
            
        }

       
        public DateTime SelecttDate { get; set; }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelecttDate = monthCalendar1.Value;//dateTimePicker1.SelectionRange.Start;
            this.DialogResult = DialogResult.OK;
        }

        private void PopDateTime_Load(object sender, EventArgs e)
        {
            try
            {
                 //monthCalendar1.SetSelectionRange(DateTime.Now.AddMonths(+6), DateTime.Now.AddMonths(+6));

                monthCalendar1.Value=SelecttDate;
            }
            catch (Exception)
            {
                
            }
        }

    }
}
