using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using System.Drawing.Imaging;

namespace AryuwatSystem.Forms
{
    public partial class PopMedicalUsedBeforLicence : Form
    {
        public PopMedicalUsedBeforLicence()
        {
            InitializeComponent();
        }

        private List<Entity.MedicalOrderUseTrans> listUse = new List<MedicalOrderUseTrans>();
        private Entity.MedicalOrderUseTrans useInfo;
        //public Entity.MedicalOrderUseTrans info;
        public string CustomerName { get; set; }
        public string AmountTotal { get; set; }//จำนวนทั้งหมด
        public string AmountUsed { get; set; }//จำนวนที่ใช้
        public string CurrentUsed { get; set; }//จำนวนที่ใช้
        private double Amounttotal = 0;
        public string AmountBalance { get; set; }//คงเหลือ
        public string SupplieName { get; set; }//ชื่อรายการ
        public string CN { get; set; }
        public string VN { get; set; }
        public string MS_Code { get; set; }
        public string RefMO { get; set; }
        public string ReMark { get; set; }
        public string BranchName { get; set; }
        public string DateUsed { get; set; }
        
        public string ListOrder { get; set; }
        public decimal FeeRate { get; set; }
        public decimal FeeRate2 { get; set; }
        
        public string CO { get; set; }
        
        public string ExpireDate { get; set; }
        private string useTransId;
        private DataTable dtTmp;
        private List<Entity.MedicalStuff> MedicalStuffs;
        private Entity.MedicalStuff stuffInfo;
        public string TabName { get; set; }
        private string statusSave = "INSERT";
        public Form ParentForm { get; set; }
      

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }
        private string GetCOnumber()
        {
            string co = "";
            try
            {
                co=CO = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("CO-");
            }
            catch (Exception ex)
            {
              
            }
            return co;
        }
        private void PopMedicalUsedBeforLicence_Load(object sender, EventArgs e)
        {
            lblCustomerName.Text  = CustomerName+"\n CN : "+CN;
            lblSupplie.Text = SupplieName;
            lblTotal.Text = AmountTotal;
            if (AmountBalance.Split(':').Length > 1) AmountBalance = AmountBalance.Split(':')[0];
            lblBalance.Text = AmountBalance;
            labelDate.Text = DateUsed;// DateTime.Now.ToString("dd/MM/yyy");
            lblAmountUsed.Text = (Convert.ToDouble(AmountUsed) - Convert.ToDouble(CurrentUsed)).ToString("###,###,###.##");
            lbRefMO.Text = RefMO;
            txtRemark.Text = ReMark;
            txtRemark.Select(0, 0);
            lblCurrentUsed.Text = Convert.ToDouble(CurrentUsed).ToString("###,###,###.##");
            labelBranchName.Text = BranchName;
            //BindData();

            //SumAmountUse();
        }
        //private void SumAmountUse()
        //{
        //    Amounttotal = dgvUsedTrans.Rows.Cast<DataGridViewRow>()
        //           .Where(r => r.Cells["Amount"].Value + "" != "")
        //           .Sum(t => Convert.ToDouble(t.Cells["Amount"].Value));

        //    AmountUsed = Amounttotal.ToString("###,###,###.##");
        //    AmountBalance = (Convert.ToDouble(AmountTotal) - Amounttotal).ToString("###,###,###.##");

        //    lblAmountUsed.Text = AmountUsed;
        //    lblBalance.Text = AmountBalance;
        //}
    

    

   

        private void BindData()
        {
            try
            {
                DerUtility.MouseOn(this);
                Entity.MedicalOrderUseTrans info = new MedicalOrderUseTrans();
                info.CN = CN;
                info.VN = VN;
                info.MS_Code = MS_Code;
                info.ListOrder = ListOrder;

                if (!string.IsNullOrEmpty(info.VN))
                {
                    dtTmp = new Business.MedicalOrderUseTrans().SelectMedicalOrderUseTransById(info).Tables[0];
                    foreach (DataRowView item in dtTmp.DefaultView)
                    {
                        double AmountU = Convert.ToDouble(string.IsNullOrEmpty(item["AmountOfUse"] + "") ? "1" : item["AmountOfUse"] + "".Replace(",", ""));
                        object[] myItems = {
                                               item["ID"] + "",
                                               AmountU.ToString("###,###,###.##"),
                                               item["DateOfUse"] + "" != ""? DateTime.Parse(item["DateOfUse"] + "").Date.ToShortDateString():"",
                                               item["CN_USED"]+"",
                                               item["FullNameThai"]+"" != ""?item["FullNameThai"]+"":item["FullNameEng"]+"",
                                                item["CO"]+"",
                                                item["RefMO"]+"",
                                               imageList1.Images[2],
                                               imageList1.Images[3],
                                                item["ListOrder"]+"",
                                                item["Remark"]+""

                                           };
                    }
                    //foreach (Entity.MedicalOrderUseTrans medicalInfo in MedicalOrderUseTranss)
                    //{
                    //    if (medicalInfo.MS_Code == MS_Code)
                    //    {
                    //        txtUseNew.Text = Convert.ToDouble(medicalInfo.AmountOfUse).ToString("###,##0.00");
                    //    }
                    //}
                    //if (MedicalOrderUseTranss.Count > 0)
                    //{
                    //    //var itemToRemove = StuffAesthetic.Single(r => r.MS_Code == MS_Code);
                    //    //StuffAesthetic.Remove(itemToRemove);
                    //    MedicalOrderUseTranss.RemoveAll(x => x.MS_Code == MS_Code);
                    //}
                } 
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
    


        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 80, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);  
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 80, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);  
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 0, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Use this version to capture the full extended desktop (i.e. multiple screens)

                //Bitmap screenshot = new Bitmap(this.Width,
                //                               this.Height,
                //                               PixelFormat.Format24bppRgb);
                //Graphics screenGraph = Graphics.FromImage(screenshot);
                //screenGraph.CopyFromScreen(this.Location.X,
                //                           this.Location.Y,
                //                           0,
                //                           0,
                //                           this.Size,
                //                           CopyPixelOperation.SourceCopy);

                //screenshot.Save("Screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
                frmCustomerLicence frm = new frmCustomerLicence();
                frm.ShowDialog();
            }
            catch (Exception)
            {


            }
        }

        //private void txtUseNew_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (statusSave == "UPDATE") return;
        //        if((Convert.ToDouble(AmountTotal) - (Amounttotal+Convert.ToDouble(txtUseNew.Text)))<0)
        //        {
        //            MessageBox.Show("ใส่จำนวนการใช้มากกว่า คงเหลือ");
        //            txtUseNew.Text ="0";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //    }
        //}

    }
}
