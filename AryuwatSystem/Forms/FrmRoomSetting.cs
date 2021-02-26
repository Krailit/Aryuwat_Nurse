using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;
using AryuwatSystem.Data;
using AryuwatSystem.UserControls;
using AryuwatSystem.m_DataSet;

namespace AryuwatSystem.Forms
{
    public partial class FrmRoomSetting : DockContent, IForm
    {

        public FrmRoomSetting()
        {
            InitializeComponent();
        }

        public FrmRoomSetting(ref Entity.Customer info)
        {
            InitializeComponent();
           
        }
        private string Room_Code_prop;

        public string Room_Code
        {
            get { return Room_Code_prop; }
            set { Room_Code_prop = value; }

        }
        #region IForm Members

        void IForm.IsSave()
        {
        }

        void IForm.IsDelete()
        {
            //DeleteData();
        }

        void IForm.IsRefresh()
        {
            //BindDataCustomer(1);
        }

        void IForm.IsEdit()
        {
            //UpdateDataCustomer();
        }

        void IForm.IsPrint()
        {

        }

        void IForm.IsNew()
        {
            //NewCustomer();
        }

        void IForm.IsExit()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Private Member


        private DataTable dtTmpHairSelect = new DataTable();

        public string typeCustomer { get; set; }
        public string RefCN { get; set; }
        public string RefCN_Name { get; set; }
        public string customerType { get; set; }
        public string PriceRef { get; set; }
        public decimal SalePriceNew { get; set; }
        private DataTable dtByItem = new DataTable();
        private DataTable dtByItemOrg = new DataTable();
          
        private string vn = "";
        private string so = "";
        private string Pro_Code;

        List<string> LsSelectMS_Code = new List<string>();
        private string docFilePath;
        List<DataGridViewRow> rowsToDelete=new List<DataGridViewRow>();
        //DataGridView dataGridToDelete=new DataGridView();
        public List<Entity.MedicalStuff> MedicalStuffs { get; set; }
        public List<Entity.MedicalOrderUseTrans> MedicalOrderUseTranss{ get; set; }
        public DerUtility.AccessType FormType { get; set; }
        public string RefVN { get; set; }
        private Dictionary<string,List<Entity.MembersTrans>> dicMemberTran = new Dictionary<string,List<Entity.MembersTrans>> ();
        public string MS_Code="";
        public string PRO_Code
        {
            get { return Pro_Code; }
            set { Pro_Code = value; }

        }
        public string SO
        {
            get { return so; }
            set { so = value; }

        }

        public string TypeCustomer
        {
            get { return typeCustomer; }
            set { typeCustomer = value; }

        }

        private TabPageActive tabPageActive = TabPageActive.tabAesthetic;
        public enum TabPageActive
        {
            tabAesthetic = 1,
            tabTreatment = 2,
            tabSurgery = 3,
            tabHair = 4,
            tabWellness_Antiaging = 5,
            tabPharmacy = 6,
            tabAttachFile = 7,
        }
        #endregion
        List<string> lsUnit = new List<string>();
        List<string> MKTBudget = new List<string>();
        List<string> GiftVoucher = new List<string>();
        Dictionary<string, string> dicMKTBudget = new Dictionary<string, string>();
        Dictionary<string, string> dicGiftVoucher = new Dictionary<string, string>();
        public string MedStatus_Code = "0";
        string moso = "ROOM-";
        public string MO = "";
        string idMax = "";     
        private void FrmPromotionMMSetting_Load(object sender, EventArgs e)
        {
            try
            {
                this.btnSave.Click += new EventHandler(this.btnSave_Click);
                this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
                if (FormType == DerUtility.AccessType.Update)
                {
                   
                    this.BindData();
                }
                else 
                {
                    using (var context = new EntitiesOPD_System())
                    {
                        int maxid = context.Master_Room.Take(1).OrderByDescending(x => x.ID).FirstOrDefault().ID;
                        this.idMax = ((DateTime.Now.Year + 543).ToString().Substring(2,2) + (DateTime.Now.Month).ToString("0#") + (maxid + 1).ToString("000#")).ToString();
                        this.txtRoom_Code.Text = moso + this.idMax;
                    } 
                }
                     
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void BindData()
        {
            try
            {
                using (var context = new EntitiesOPD_System())
                {
                    var getTempRoom = context.Master_Room.Where(x => x.Room_Code == Room_Code_prop).FirstOrDefault();
                    if(getTempRoom != null)
                    {
                        txtAmount_Day.Text = (getTempRoom.Amount_Day ?? 0).ToString();
                        txtProPrice.Text = (getTempRoom.Room_Price ?? 0).ToString();
                        txtTotalPrice.Text = (getTempRoom.Room_PriceCredit ?? 0).ToString();
                        txtRoom_Code.Text = Room_Code_prop;
                        txtRoom_Name.Text = getTempRoom.Room_Name ?? "";
                        checkBoxActive.Checked = getTempRoom.Is_Active == true ? true : false;
                        txtRemark.Text = getTempRoom.Remark ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirm, "ยืนยันการบันทึกข้อมูล") != DialogResult.OK)
            {
                return;
            }
           
            if (string.IsNullOrEmpty(txtRoom_Code.Text) && string.IsNullOrEmpty(txtRoom_Name.Text) )
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ รหัสห้องและชื่อห้อง\n Please specify Room Codes and Room name.");
                return;
            }
            try
            {
                using (var context = new EntitiesOPD_System())
                {
                    if (FormType == DerUtility.AccessType.Update)
                    {
                        var editRoom = context.Master_Room.Where(x => x.Room_Code == txtRoom_Code.Text).FirstOrDefault();

                        if(editRoom != null)
                        {
                            editRoom.Room_Name = txtRoom_Name.Text.Trim();
                            editRoom.Remark = txtRemark.Text;
                            editRoom.Amount_Day = Convert.ToInt32(txtAmount_Day.Text);
                            editRoom.Room_PriceCredit = Convert.ToDecimal(txtTotalPrice.Text);
                            editRoom.Room_Price = Convert.ToDecimal(txtProPrice.Text);
                            editRoom.Is_Active = checkBoxActive.Checked ? true : false;
                            editRoom.Update_By = Userinfo.EN;
                            editRoom.Update_Date = DateTime.Now;
                            context.SaveChanges();
                        }
                    }
                    else
                    {

                        var masRoom = new Master_Room();
                        masRoom.Room_Code = txtRoom_Code.Text.Trim().ToUpper();
                        masRoom.Room_Name = txtRoom_Name.Text.Trim();
                        masRoom.Remark = txtRemark.Text;
                        masRoom.Amount_Day = Convert.ToInt32(txtAmount_Day.Text);
                        masRoom.Room_PriceCredit = Convert.ToDecimal(txtTotalPrice.Text);
                        masRoom.Room_Price = Convert.ToDecimal(txtProPrice.Text);
                        masRoom.Is_Active = true;
                        masRoom.Create_By = Userinfo.EN;
                        masRoom.Create_Date = DateTime.Now;
                        context.Master_Room.Add(masRoom);
                        context.SaveChanges();

                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.SaveComplete);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
            }
        }

        private void FrmPromotionMMSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmPromotionSetting = null;
        }

      
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Statics.frmPromotionSetting = null;
            this.Close();
        }
        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalPrice.Text.Length > 0) CalcPercen(txtTotalPrice);
        }
        private void txtProPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtProPrice.Text.Length > 0) CalcPercen(txtProPrice);
        }
        private void CalcPercen(TextboxFormatDouble txt)
        {
            try
            {
                if (txtTotalPrice.Text.Length > 0 && txtProPrice.Text.Length > 0)
                {
                    double valueUp = double.Parse(txtProPrice.Text);
                    double valueDown = double.Parse(txtTotalPrice.Text);

                    double discount =0;
                    discount = 100 - ((valueUp * 100) / valueDown);
                    //if (valueDown > (valueUp * 2)) discount = ((valueUp * 100) / valueDown);
                     if (valueDown < valueUp) discount = 0;
                    //else   discount = 100 - ((valueUp * 100) / valueDown);
                
                    txtDiscountPercen.Text =discount+""=="NaN"?"0.00": Math.Round(discount, 2).ToString("###,###,###.##");
                }
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}

