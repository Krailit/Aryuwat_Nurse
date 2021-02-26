using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using AryuwatSystem.DerClass;
using AryuwatSystem.Reports;
using Entity;


namespace AryuwatSystem.Forms
{
    public partial class FrmPreviewRpt : Form
    {
        public FrmPreviewRpt()
        {
            InitializeComponent();
        }

        public string FormName { get; set; }
        public string ENPrint { get; set; }
        public string PrintType { get; set; }
        public string Today { get; set; }
        public string PRO { get; set; }
        public string Remark { get; set; }
        public string ForDate { get; set; }
        public string MainName { get; set; }
        public string UsedName { get; set; }
        public bool HasDiscount { get; set; }
        public DataTable dt { get; set; }
        public DataTable dt2 { get; set; }

        public int RenewAddMonth { get; set; }
        public DateTime RenewStartDate { get; set; }
        

        public string Cn { get; set; }
        public string StrBirthDate { get; set; }
        public double? DiscountBath { get; set; }//ออกใบเสร็จ ส่วนลดเพิ่ม
        public string TypeOfPayment { get; set; }//ออกใบเสร็จ ชำระเงินโดย
        public string ApploveDr { get; set; }
        public string Applove2 { get; set; }
        public string ApploveRemark { get; set; }
        public string PayToday { get; set; }
        public string INVNo { get; set; }
        public string BranchName { get; set; }
        public double PayTodayDouble { get; set; }
        public double SumPriceAfterDis { get; set; }
        public double SumUnpaid { get; set; }
        public DataSet DataSetReport { get; set; }
        private void FrmPreviewRpt_Load(object sender, EventArgs e)
        {
            try
            {

   
            switch (FormName)
            {

                case "RptPrintSO_Stock":
                    RptPrintSO_Stock();
                    break;
                case "RptAccPendingNormalSummary":
                    RptAccPendingNormalSummary();
                    break;
                case "RptAccPendingNormal":
                    RptAccPendingNormal();
                    break;
                case "RptCustomerConnect":
                    RptCustomerConnect();
                    break;
                case "RptREQREPInventoryGroupByDocNumber":
                    RptREQREPInventoryGroupByDocNumber();
                    break;
                    
                case "RptREQREPInventory":
                    RptREQREPInventory();
                    break;
                case "RptGiftVoucher":
                    RptGiftVoucher();
                    break;
                case "RtpSPQInventory":
                    RtpSPQInventory();
                    break;
                case "RtpReplySupplies":
                    RtpReplySupplies();
                    break;
                 case "RptRFDReq":
                    RtpRFDReq();
                    break;
                case "RtpREQInventory":
                    RtpREQInventory();
                    break;
                case "RtpReplyInventory":
                    RtpReplyInventory();
                    break;
                    
               case "RptSUCheckMoneyByCN":
                    RptSUCheckMoneyByCN();
                    break;
                    
                case "RptDayFollow":
                    RptDayFollow();
                    break;
                case "RptAccClearPending":
                    DisplayRptAccClearPending();
                    break;
                case "RptSendToCustomer":
                    DisplayRptSendToCustomer();
                    break;
                    
                case "RptCourseApproved":
                    DisplayRptCourseApproved();
                    break;
                case "RptCourseCard":
                    DisplayRptCourseCard();
                    break;
                case "RptCourseCardCreditLand":
                    DisplayRptCourseCardCreditLand();
                    break;
                    
                case "RptCourseSlip":
                    DisplayRptCourseSlip();
                    break;
                case "RptCourseSlipCredit":
                    DisplayRptCourseSlipCredit();
                    break;
                    
                case "RptCourseCardForm":
                    DisplayRptCourseCardForm();
                    break;

                case "RptCourseCardFormCreditLand":
                    DisplayRptCourseCardFormCredit();
                    break;
                    
                    
                case "RptCourseApprovedRenewal":
                    DisplayRptCourseApprovedRenewal();
                    break;
                case "RptDoctorAtten":
                    DisplayRptDoctorAtten();
                    break;
                case "RptCustomerList":
                    DisplayRptCustomerList();
                    break;
                case "RptCustomerDetail":
                    DisplayRptCustomer();
                    break;
                case "RptSOFBillVAT":
                    DisplayRptSOFBillVat();
                    break;
                case "RptSOFBillNoVAT":
                    DisplayRptSOFBillNoVat();
                    break;
                case "RptSOFInvNoVatDiscount"://ใบแจ้งหนี Non Vat
                    DisplayRptSOFINVNonVatDiscount();
                    break;
                case "RptSOFInvVatDiscount"://ใบแจ้งหนี Vat
                    DisplayRptSOFINVVatDiscount();
                    break;
                case "RptSOFBill2NoVat"://ใบเสร็จ
                    if(HasDiscount)DisplayRptSOFBill2NoVatDiscount();
                    else DisplayRptSOFBill2NoVatNoDiscount();
                    break;
                case "RptRevenueByMonth":
                    DisplayRptRevenueByMonth();
                    break;
                case "RptRevenueByDept":
                    DisplayRptRevenueByDept();
                    break;
          
                case "RptSalesVolumeByDept":
                    DisplayRptSalesVolumeByDept();
                    break;
                case "RptSalesVolumeByMonth":
                    DisplayRptSalesVolumeByMonth();
                    break;
                case "RptRevenueDistGroup":
                    DisplayRptRevenueByGroup();
                    break;
                case "RptSummaryBodyByMonth":
                    DisplayRptSummaryBodyByMonth();
                    break;
                case "RptSummaryFaceByMonth":
                    DisplayRptSummaryFaceByMonth();
                    break;
                case "RptSummaryBodyFaceByMonth":
                    DisplayRptSummaryBodyFaceByMonth();
                    break;
                case "RptSummaryTherapist":
                    DisplayRptSummaryTherapist();
                    break;
                case "RptPaymentSummary":
                    DisplayRptPaymentSummary();
                    break;
                case "RptPaymentByGroup":
                    DisplayRptPaymentByGroup();
                    break;
                case "RptPaymentMarketing":
                    DisplayRptPaymentMarketing();
                    break;
                case "RptPaymentMarketingHear":
                    DisplayRptPaymentMarketingHear();
                    break;
                case "RptPaymentMarketingList":
                    DisplayRptPaymentMarketingList();
                    break;
                case "RptPaymentSumByDept":
                    DisplayRptPaymentSumByDept();
                    break;
                case "RptMedicalOrderSaleSO":
                    DisplayRptMedicalOrderSaleSO();
                    break;
                case "RptMedicalOrderRefVN":
                    DisplayRptMedicalOrderRefVN();
                    break;
                    
                case "RptSalesFollow":
                    DisplayRptSalesFollow();
                    break;
                case "RptBrithdate":
                    DisplayRptBrithdate();
                    break;
                case "RptCycleDate":
                    DisplayRptCycleDate();
                    break;
                case "RptCoursePending":
                    DisplayRptCoursePending();
                    break;
                case "RptStockSell":
                    DisplayRptStock("RptStockSell");
                    break;
                case "RptStockReceipt":
                    DisplayRptStock("RptStockReceipt");
                    break;
                case "RptStockBalance":
                    DisplayRptStock("RptStockBalance");
                    break;
                case "RptAccReceiptVat":
                    DisplayRptAcc("RptAccReceiptVat");
                    break;
                case "RptAccReceiptByProductVat":
                    DisplayRptAcc("RptAccReceiptByProductVat");
                    break;
                case "RptAccReceiptByProductNoVat":
                    DisplayRptAcc("RptAccReceiptByProductNoVat");
                    break;
                case "RptAccReceiptByProductAll":
                    DisplayRptAcc("RptAccReceiptByProductAll");
                    break;
                case "RptAccBenefitAESTHETIC":
                    DisplayRptAcc("RptAccBenefitAESTHETIC");
                    break;
                case "RptAccBenefitTREATMENT":
                    DisplayRptAcc("RptAccBenefitTREATMENT");
                    break;
                case "RptAccBenefitANGTI-AGING":
                    DisplayRptAcc("RptAccBenefitANGTI-AGING");
                    break;
                case "RptAccBenefitSURGERY":
                    DisplayRptAcc("RptAccBenefitSURGERY");
                    break;
                case "RptAccBenefitHAIR":
                    DisplayRptAcc("RptAccBenefitHAIR");
                    break;
                case "RptAccOutstanding":
                    DisplayRptAcc("RptAccOutstanding");
                    break;
                case "RptAccOutstandingByInvoid":
                    DisplayRptAcc("RptAccOutstandingByInvoid");
                    break;
                case "RptAccUseProCredit":
                    DisplayRptAcc("RptAccUseProCredit");
                    break;
                case "RptAccUseCourseMoRefNotProCredit":
                    DisplayRptAcc("RptAccUseCourseMoRefNotProCredit");
                    break;
                case "RptAccReceiptByProductAllDetail":
                    DisplayRptAcc("RptAccReceiptByProductAllDetail");
                    break;
                case "RptAccReceiptByProductAllDetail_SaleCheck":
                    DisplayRptAcc("RptAccReceiptByProductAllDetail_SaleCheck");
                    break;
                case "RptAccReceiptByProductAllDetail_SaleCom":
                    DisplayRptAcc("RptAccReceiptByProductAllDetail_SaleCom");
                    break;
                case "RptMedicalOrderFreeApplove":
                    DisplayRptMedicalOrderFreeApplove();
                    break;
                case "RptHRSurgicalFeeType2":
                    DisplayRptHRSurgicalFeeType2();
                    break;
                case "RptDayListCheck":
                    RptDayListCheck();
                    break;
                case "RptFeeDayListCheck":
                    RptFeeDayListCheck();
                    break;
                case "RptFeeDayListCheckTP":
                    RptFeeDayListCheckTP();
                    break;
                case "RptAccReceiptpaidDaily":
                    RptAccReceiptpaidDaily();
                    break;
                case "RptAccReceiptDepositDaily":
                    RptAccReceiptDepositDaily();
                    break;
                case "RptAccReceiptDebtorDepositDaily":
                    RptAccReceiptDebtorDepositDaily();
                    break;
                case "RptAccReceiptComSaleD1_D3":
                    RptAccReceiptComSaleD1_D3();
                    break;
                case "RptUsedCouseDaily":
                    RptUsedCouseDaily();
                    break;
                case "RptUsedCouseDailyTP":
                    RptUsedCouseDailyTP();
                    break;
                    


                    
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void DisplayRptAccClearPending()
        {

            RptAccClearPending rpt = new RptAccClearPending();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate+"";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate+"";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
            
        }
        private void DisplayRptSendToCustomer()
        {

            RptSendToCustomer rpt = new RptSendToCustomer();

            rpt.Load();
            //rpt.SetDataSource(dt);
            rpt.Database.Tables[0].SetDataSource(dt);
            if(dt2.Rows.Count>0) rpt.Database.Tables[1].SetDataSource(dt2);

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptCourseApproved()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptCourseApproved rpt = new RptCourseApproved();

            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(PayTodayDouble);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = MainName;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["MainName"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = UsedName;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["UsedName"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = Remark + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Remark"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = Userinfo.TName + " " + Userinfo.TSurname;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ENPrint"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);



            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        
        private void DisplayRptCourseCard()
        {
            RptCourseCard rpt = new RptCourseCard();
            string ExpireText = "";
            rpt.Load();
            if (dt.Rows.Count == 0)
            {
                // generate the data you want to insert
                DataRow toInsert = dt.NewRow();
                // insert in the desired place
                dt.Rows.InsertAt(toInsert, 0);
            }
            rpt.Database.Tables["CourseCard"].SetDataSource(dt);
            if (dt2.Rows.Count > 0)
            {
                rpt.Database.Tables["CourseApproved"].SetDataSource(dt2);
                if (dt.Rows[0]["PrintSlip"] + "" == "Y")
                {  
                    if(dt2.Rows[0]["ExpireDate"]+""=="")
                        ExpireText="";
                    else
                        ExpireText=Convert.ToDateTime(dt2.Rows[0]["ExpireDate"] + "").ToString("dd-MMM-yyyy");
                    //DateTime.Now.ToString("yyyy/MM/dd HH:mm")
                    ExpireText = string.Format("Expired : {0}", ExpireText);
                }
            }
            
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = ExpireText;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ExpireText"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptCourseCardCreditLand()
        {
            RptCourseCardCreditLand rpt = new RptCourseCardCreditLand();
            string ExpireText = "";
            rpt.Load();
            if (dt.Rows.Count == 0)
            {
                // generate the data you want to insert
                DataRow toInsert = dt.NewRow();
                // insert in the desired place
                dt.Rows.InsertAt(toInsert, 0);
            }

          
            //rpt.Database.Tables["CourseCard"].SetDataSource(dt);
            if (dt2.Rows.Count > 0)
            {
                //rpt.Database.Tables["CourseApproved"].SetDataSource(dt2);
                if (dt.Rows[0]["PrintSlip"] + "" == "Y")//|| dt.Rows[26]["PrintSlip"] + "" == "Y" || dt.Rows[53]["PrintSlip"] + "" == "Y"
                {
                    if (dt2.Rows[0]["ExpireDate"] + "" == "")
                        ExpireText = "";
                    else
                        ExpireText = Convert.ToDateTime(dt2.Rows[0]["ExpireDate"] + "").ToString("dd-MMM-yyyy");
                    //DateTime.Now.ToString("yyyy/MM/dd HH:mm")
                    ExpireText = string.Format("Expired : {0}", ExpireText);
                }
                if (dt.Rows.Count>25 && dt.Rows[26]["PrintSlip"] + "" == "Y")//|| dt.Rows[26]["PrintSlip"] + "" == "Y" || dt.Rows[53]["PrintSlip"] + "" == "Y"
                {
                    if (dt2.Rows[0]["ExpireDate"] + "" == "")
                        ExpireText = "";
                    else
                        ExpireText = Convert.ToDateTime(dt2.Rows[0]["ExpireDate"] + "").ToString("dd-MMM-yyyy");
                    //DateTime.Now.ToString("yyyy/MM/dd HH:mm")
                    ExpireText = string.Format("Expired : {0}", ExpireText);
                }
                if (dt.Rows.Count > 52 && dt.Rows[53]["PrintSlip"] + "" == "Y")//|| dt.Rows[26]["PrintSlip"] + "" == "Y" || dt.Rows[53]["PrintSlip"] + "" == "Y"
                {
                    if (dt2.Rows[0]["ExpireDate"] + "" == "")
                        ExpireText = "";
                    else
                        ExpireText = Convert.ToDateTime(dt2.Rows[0]["ExpireDate"] + "").ToString("dd-MMM-yyyy");
                    //DateTime.Now.ToString("yyyy/MM/dd HH:mm")
                    ExpireText = string.Format("Expired : {0}", ExpireText);
                }
            }
            DataSet ds = new DataSet();
            dt.TableName = "CourseCard";
            dt2.TableName = "CourseApproved";
            ds.Tables.Add(dt);
            ds.Tables.Add(dt2);
rpt.SetDataSource(ds);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = ExpireText;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ExpireText"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptCourseSlip()
        {
            RptCourseSlip rpt = new RptCourseSlip();

            rpt.Load();
            if (dt.Rows.Count == 0)
            {
                // generate the data you want to insert
                DataRow toInsert = dt.NewRow();
                // insert in the desired place
                dt.Rows.InsertAt(toInsert, 0);
            }
            rpt.Database.Tables["CourseCard"].SetDataSource(dt);
            if (dt2.Rows.Count > 0) rpt.Database.Tables["CourseApproved"].SetDataSource(dt2);

            //object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptCourseSlipCredit()
        {
            RptCourseSlipCredit rpt = new RptCourseSlipCredit();

            rpt.Load();
            if (dt.Rows.Count == 0)
            {
                // generate the data you want to insert
                DataRow toInsert = dt.NewRow();
                // insert in the desired place
                dt.Rows.InsertAt(toInsert, 0);
            }
            rpt.Database.Tables["CourseCard"].SetDataSource(dt);
            if (dt2.Rows.Count > 0) rpt.Database.Tables["CourseApproved"].SetDataSource(dt2);

            //object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }

        private void DisplayRptCourseCardFormCredit()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptCourseCardFormCreditLand rpt = new RptCourseCardFormCreditLand();

            rpt.Load();
            if (dt.Rows.Count == 0)
            {
                // generate the data you want to insert
                DataRow toInsert = dt.NewRow();
                foreach (DataColumn  item in dt.Columns)
                {
                    try
                    {
                        foreach (DataColumn cm in dt2.Columns)
                        {
                            if (cm.ColumnName == item.ColumnName)
                                toInsert[item.ColumnName] = dt2.Rows[0][cm.ColumnName];
                        }
                    }
                    catch (Exception )
                    {
                        
                    }
                    
                }
                toInsert["AmountOfUse"] = dt2.Rows[0]["Amount"];
                toInsert["DateOfUse"] = dt2.Rows[0]["DateUpdate"];
                // insert in the desired place
                dt.Rows.InsertAt(toInsert, 0);
            }
            //rpt.Database.Tables["CourseCard"].SetDataSource(dt);
            if (dt.Rows.Count > 0) rpt.Database.Tables["CourseCard"].SetDataSource(dt);
            if (dt2.Rows.Count > 0) rpt.Database.Tables["CourseApproved"].SetDataSource(dt2);

            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptCourseCardForm()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptCourseCardForm rpt = new RptCourseCardForm();

            rpt.Load();
            if (dt.Rows.Count == 0)
            {
                // generate the data you want to insert
                DataRow toInsert = dt.NewRow();
                foreach (DataColumn  item in dt.Columns)
                {
                    try
                    {
                        foreach (DataColumn cm in dt2.Columns)
                        {
                            if (cm.ColumnName == item.ColumnName)
                                toInsert[item.ColumnName] = dt2.Rows[0][cm.ColumnName];
                        }
                    }
                    catch (Exception )
                    {
                        
                    }
                    
                }
                toInsert["AmountOfUse"] = dt2.Rows[0]["Amount"];
                toInsert["DateOfUse"] = dt2.Rows[0]["DateUpdate"];
                // insert in the desired place
                dt.Rows.InsertAt(toInsert, 0);
            }
            //rpt.Database.Tables["CourseCard"].SetDataSource(dt);
            if (dt.Rows.Count > 0) rpt.Database.Tables["CourseCard"].SetDataSource(dt);
            if (dt2.Rows.Count > 0) rpt.Database.Tables["CourseApproved"].SetDataSource(dt2);

            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        
        private void DisplayRptCourseApprovedRenewal()
        {
            
            RptCourseApprovedRenewal rpt = new RptCourseApprovedRenewal();

            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(PayTodayDouble);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = RenewAddMonth;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["RenewAddMonth"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = MainName;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["MainName"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = UsedName;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["UsedName"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            //========================

            crParameterDiscreteValue.Value = Remark + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Remark"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = Userinfo.TName + " " + Userinfo.TSurname;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ENPrint"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            //========================
            //========================

            crParameterDiscreteValue.Value = RenewStartDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["RenewStartDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            //========================

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptDoctorAtten()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptDoctorAtten rpt = new RptDoctorAtten();

            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(PayTodayDouble);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["TitleText"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = PrintType;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["RoomName"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = Remark;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Remark"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptCustomer()
        {
        
            string strAge = "-";
            //string StrBirthDate = "-";
            var dsCust = new Business.Customer().SelectRptCustomerById(Cn);

            RptCustomerDetail rpt = new RptCustomerDetail();
            rpt.Load();
            //rpt.Database.Tables[0].SetDataSource(dsCust.Tables[0]);
            rpt.SetDataSource(dsCust.Tables[0]);
            if (!string.IsNullOrEmpty(dsCust.Tables[0].Rows[0]["DateBirth"] + ""))
            {
                DateTime myDate = (DateTime)(dsCust.Tables[0].Rows[0]["DateBirth"]); // DateTime(dateTimePicker1.Value);
                StrBirthDate = myDate.ToShortDateString();
                DateTime ToDate = DateTime.Now;

                DateDifference dDiff = new DateDifference(myDate, ToDate);
                strAge = dDiff.ToString();
            }
            else
            {
                strAge = "-";
                StrBirthDate = "-";
            }

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = StrBirthDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BirthDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;


            ParameterFieldDefinitions crParameterFieldDefinitionsAge;
            ParameterFieldDefinition crParameterFieldDefinitionAge;
            ParameterValues crParameterValuesAge = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueAge = new ParameterDiscreteValue();

            crParameterDiscreteValueAge.Value = strAge;
            crParameterFieldDefinitionsAge = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionAge = crParameterFieldDefinitionsAge["Age"];
            crParameterValuesAge = crParameterFieldDefinition.CurrentValues;

          

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValuesAge.Add(crParameterDiscreteValueAge);
            crParameterFieldDefinitionAge.ApplyCurrentValues(crParameterValuesAge);




            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }

        private void DisplayRptCustomerList()
        {
            RptCustomerList rpt = new RptCustomerList();
            rpt.Load();
            rpt.SetDataSource(DataSetReport.Tables[0]);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }

        private void DisplayRptSOFBillNoVat()
        {
            RptSOFBillNoVat rpt = new RptSOFBillNoVat();
            
            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            object sumDis;
            sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()));
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = "( " + strMoney + " )";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BathThai"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsEmp;
            ParameterFieldDefinition crParameterFieldDefinitionEmp;
            ParameterValues crParameterValuesEmp = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueEmp = new ParameterDiscreteValue();

            crParameterDiscreteValueEmp.Value = "( " + Statics.StrFullName + " )";
            crParameterFieldDefinitionsEmp = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionEmp = crParameterFieldDefinitionsEmp["EmpName"];
            crParameterValuesEmp = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsDis;
            ParameterFieldDefinition crParameterFieldDefinitionDis;
            ParameterValues crParameterValuesDis = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueDis = new ParameterDiscreteValue();

            crParameterDiscreteValueDis.Value = DiscountBath;
            crParameterFieldDefinitionsDis = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionDis = crParameterFieldDefinitionsDis["Dis"];
            crParameterValuesDis = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsTypeOfPayment;
            ParameterFieldDefinition crParameterFieldDefinitionTypeOfPayment;
            ParameterValues crParameterValuesTypeOfPayment = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueTypeOfPayment = new ParameterDiscreteValue();

            crParameterDiscreteValueTypeOfPayment.Value = TypeOfPayment;
            crParameterFieldDefinitionsTypeOfPayment = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionTypeOfPayment = crParameterFieldDefinitionsTypeOfPayment["TypeOfPayment"];
            crParameterValuesTypeOfPayment = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValuesEmp.Add(crParameterDiscreteValueEmp);
            crParameterFieldDefinitionEmp.ApplyCurrentValues(crParameterValuesEmp);

            crParameterValuesDis.Add(crParameterDiscreteValueDis);
            crParameterFieldDefinitionDis.ApplyCurrentValues(crParameterValuesDis);

            crParameterValuesTypeOfPayment.Add(crParameterDiscreteValueTypeOfPayment);
            crParameterFieldDefinitionTypeOfPayment.ApplyCurrentValues(crParameterValuesTypeOfPayment);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptSOFBillVat()
        {
            RptSOFBillVat rpt = new RptSOFBillVat();

            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            object sumDis;
            sumDis = dt.Compute("Sum(DiscountBath)", "");
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(sumDis.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = "( " + strMoney + " )";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BathThai"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsEmp;
            ParameterFieldDefinition crParameterFieldDefinitionEmp;
            ParameterValues crParameterValuesEmp = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueEmp = new ParameterDiscreteValue();

            crParameterDiscreteValueEmp.Value = "( " + Statics.StrFullName + " )";
            crParameterFieldDefinitionsEmp = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionEmp = crParameterFieldDefinitionsEmp["EmpName"];
            crParameterValuesEmp = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsDis;
            ParameterFieldDefinition crParameterFieldDefinitionDis;
            ParameterValues crParameterValuesDis = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueDis = new ParameterDiscreteValue();

            crParameterDiscreteValueDis.Value = DiscountBath;
            crParameterFieldDefinitionsDis = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionDis = crParameterFieldDefinitionsDis["Dis"];
            crParameterValuesDis = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsTypeOfPayment;
            ParameterFieldDefinition crParameterFieldDefinitionTypeOfPayment;
            ParameterValues crParameterValuesTypeOfPayment = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueTypeOfPayment = new ParameterDiscreteValue();

            crParameterDiscreteValueTypeOfPayment.Value = TypeOfPayment;
            crParameterFieldDefinitionsTypeOfPayment = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionTypeOfPayment = crParameterFieldDefinitionsTypeOfPayment["TypeOfPayment"];
            crParameterValuesTypeOfPayment = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValuesEmp.Add(crParameterDiscreteValueEmp);
            crParameterFieldDefinitionEmp.ApplyCurrentValues(crParameterValuesEmp);

            crParameterValuesDis.Add(crParameterDiscreteValueDis);
            crParameterFieldDefinitionDis.ApplyCurrentValues(crParameterValuesDis);

            crParameterValuesTypeOfPayment.Add(crParameterDiscreteValueTypeOfPayment);
            crParameterFieldDefinitionTypeOfPayment.ApplyCurrentValues(crParameterValuesTypeOfPayment);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptSOFINVNonVatDiscount()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptSOFInvNoVatDiscount rpt = new RptSOFInvNoVatDiscount();

            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(SumUnpaid);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = INVNo;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["INVNo"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = PrintType;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["TypeCopyReport"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = strMoney;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BathThai"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            ParameterFieldDefinitions crParameterFieldDefinitionsEmp;
            ParameterFieldDefinition crParameterFieldDefinitionEmp;
            ParameterValues crParameterValuesEmp = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueEmp = new ParameterDiscreteValue();
            crParameterDiscreteValueEmp.Value = "( " + Statics.StrFullName + " )";
            crParameterFieldDefinitionsEmp = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionEmp = crParameterFieldDefinitionsEmp["EmpName"];
            crParameterValuesEmp = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsDis;
            ParameterFieldDefinition crParameterFieldDefinitionDis;
            ParameterValues crParameterValuesDis = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueDis = new ParameterDiscreteValue();
            crParameterDiscreteValueDis.Value = DiscountBath;
            crParameterFieldDefinitionsDis = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionDis = crParameterFieldDefinitionsDis["Dis"];
            crParameterValuesDis = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsTypeOfPayment;
            ParameterFieldDefinition crParameterFieldDefinitionTypeOfPayment;
            ParameterValues crParameterValuesTypeOfPayment = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueTypeOfPayment = new ParameterDiscreteValue();
            crParameterDiscreteValueTypeOfPayment.Value = TypeOfPayment;
            crParameterFieldDefinitionsTypeOfPayment = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionTypeOfPayment = crParameterFieldDefinitionsTypeOfPayment["TypeOfPayment"];
            crParameterValuesTypeOfPayment = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsPayToday;
            ParameterFieldDefinition crParameterFieldDefinitionPayToday;
            ParameterValues crParameterValuesPayToday = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValuePayToday = new ParameterDiscreteValue();
            crParameterDiscreteValuePayToday.Value = PayToday;
            crParameterFieldDefinitionsPayToday = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionPayToday = crParameterFieldDefinitionsPayToday["PayToday"];
            crParameterValuesPayToday = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();

            //crParameterValues.Add(crParameterDiscreteValue);
            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValuesEmp.Add(crParameterDiscreteValueEmp);
            crParameterFieldDefinitionEmp.ApplyCurrentValues(crParameterValuesEmp);

            crParameterValuesDis.Add(crParameterDiscreteValueDis);
            crParameterFieldDefinitionDis.ApplyCurrentValues(crParameterValuesDis);

            crParameterValuesTypeOfPayment.Add(crParameterDiscreteValueTypeOfPayment);
            crParameterFieldDefinitionTypeOfPayment.ApplyCurrentValues(crParameterValuesTypeOfPayment);

            crParameterValuesPayToday.Add(crParameterDiscreteValuePayToday);
            crParameterFieldDefinitionPayToday.ApplyCurrentValues(crParameterValuesPayToday);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptSOFINVVatDiscount()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptSOFInvVatDiscount rpt = new RptSOFInvVatDiscount();

            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(SumUnpaid);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = INVNo;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["INVNo"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = PrintType;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["TypeCopyReport"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = strMoney;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BathThai"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            ParameterFieldDefinitions crParameterFieldDefinitionsEmp;
            ParameterFieldDefinition crParameterFieldDefinitionEmp;
            ParameterValues crParameterValuesEmp = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueEmp = new ParameterDiscreteValue();
            crParameterDiscreteValueEmp.Value = "( " + Statics.StrFullName + " )";
            crParameterFieldDefinitionsEmp = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionEmp = crParameterFieldDefinitionsEmp["EmpName"];
            crParameterValuesEmp = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsDis;
            ParameterFieldDefinition crParameterFieldDefinitionDis;
            ParameterValues crParameterValuesDis = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueDis = new ParameterDiscreteValue();
            crParameterDiscreteValueDis.Value = DiscountBath;
            crParameterFieldDefinitionsDis = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionDis = crParameterFieldDefinitionsDis["Dis"];
            crParameterValuesDis = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsTypeOfPayment;
            ParameterFieldDefinition crParameterFieldDefinitionTypeOfPayment;
            ParameterValues crParameterValuesTypeOfPayment = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueTypeOfPayment = new ParameterDiscreteValue();
            crParameterDiscreteValueTypeOfPayment.Value = TypeOfPayment;
            crParameterFieldDefinitionsTypeOfPayment = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionTypeOfPayment = crParameterFieldDefinitionsTypeOfPayment["TypeOfPayment"];
            crParameterValuesTypeOfPayment = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsPayToday;
            ParameterFieldDefinition crParameterFieldDefinitionPayToday;
            ParameterValues crParameterValuesPayToday = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValuePayToday = new ParameterDiscreteValue();
            crParameterDiscreteValuePayToday.Value = PayToday;
            crParameterFieldDefinitionsPayToday = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionPayToday = crParameterFieldDefinitionsPayToday["PayToday"];
            crParameterValuesPayToday = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();

            //crParameterValues.Add(crParameterDiscreteValue);
            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValuesEmp.Add(crParameterDiscreteValueEmp);
            crParameterFieldDefinitionEmp.ApplyCurrentValues(crParameterValuesEmp);

            crParameterValuesDis.Add(crParameterDiscreteValueDis);
            crParameterFieldDefinitionDis.ApplyCurrentValues(crParameterValuesDis);

            crParameterValuesTypeOfPayment.Add(crParameterDiscreteValueTypeOfPayment);
            crParameterFieldDefinitionTypeOfPayment.ApplyCurrentValues(crParameterValuesTypeOfPayment);

            crParameterValuesPayToday.Add(crParameterDiscreteValuePayToday);
            crParameterFieldDefinitionPayToday.ApplyCurrentValues(crParameterValuesPayToday);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptSOFBill2NoVatDiscount()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptSOFBill2NoVatNoDiscount rpt = new RptSOFBill2NoVatNoDiscount();

            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(PayTodayDouble);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = PrintType;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["TypeCopyReport"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = strMoney;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BathThai"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            ParameterFieldDefinitions crParameterFieldDefinitionsEmp;
            ParameterFieldDefinition crParameterFieldDefinitionEmp;
            ParameterValues crParameterValuesEmp = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueEmp = new ParameterDiscreteValue();
            crParameterDiscreteValueEmp.Value = "( " + Statics.StrFullName + " )";
            crParameterFieldDefinitionsEmp = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionEmp = crParameterFieldDefinitionsEmp["EmpName"];
            crParameterValuesEmp = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsDis;
            ParameterFieldDefinition crParameterFieldDefinitionDis;
            ParameterValues crParameterValuesDis = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueDis = new ParameterDiscreteValue();
            crParameterDiscreteValueDis.Value = DiscountBath;
            crParameterFieldDefinitionsDis = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionDis = crParameterFieldDefinitionsDis["Dis"];
            crParameterValuesDis = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsTypeOfPayment;
            ParameterFieldDefinition crParameterFieldDefinitionTypeOfPayment;
            ParameterValues crParameterValuesTypeOfPayment = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueTypeOfPayment = new ParameterDiscreteValue();
            crParameterDiscreteValueTypeOfPayment.Value = TypeOfPayment;
            crParameterFieldDefinitionsTypeOfPayment = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionTypeOfPayment = crParameterFieldDefinitionsTypeOfPayment["TypeOfPayment"];
            crParameterValuesTypeOfPayment = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsPayToday;
            ParameterFieldDefinition crParameterFieldDefinitionPayToday;
            ParameterValues crParameterValuesPayToday = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValuePayToday = new ParameterDiscreteValue();
            crParameterDiscreteValuePayToday.Value = PayToday;
            crParameterFieldDefinitionsPayToday = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionPayToday = crParameterFieldDefinitionsPayToday["PayToday"];
            crParameterValuesPayToday = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();

            //crParameterValues.Add(crParameterDiscreteValue);
            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValuesEmp.Add(crParameterDiscreteValueEmp);
            crParameterFieldDefinitionEmp.ApplyCurrentValues(crParameterValuesEmp);

            crParameterValuesDis.Add(crParameterDiscreteValueDis);
            crParameterFieldDefinitionDis.ApplyCurrentValues(crParameterValuesDis);

            crParameterValuesTypeOfPayment.Add(crParameterDiscreteValueTypeOfPayment);
            crParameterFieldDefinitionTypeOfPayment.ApplyCurrentValues(crParameterValuesTypeOfPayment);

            crParameterValuesPayToday.Add(crParameterDiscreteValuePayToday);
            crParameterFieldDefinitionPayToday.ApplyCurrentValues(crParameterValuesPayToday);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptSOFBill2NoVatNoDiscount()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptSOFBill2NoVatNoDiscount rpt = new RptSOFBill2NoVatNoDiscount();

            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(PayTodayDouble);//double.Parse(PayToday)
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = PrintType;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["TypeCopyReport"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterDiscreteValue.Value = strMoney;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BathThai"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            ParameterFieldDefinitions crParameterFieldDefinitionsEmp;
            ParameterFieldDefinition crParameterFieldDefinitionEmp;
            ParameterValues crParameterValuesEmp = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueEmp = new ParameterDiscreteValue();
            crParameterDiscreteValueEmp.Value = "( " + Statics.StrFullName + " )";
            crParameterFieldDefinitionsEmp = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionEmp = crParameterFieldDefinitionsEmp["EmpName"];
            crParameterValuesEmp = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsDis;
            ParameterFieldDefinition crParameterFieldDefinitionDis;
            ParameterValues crParameterValuesDis = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueDis = new ParameterDiscreteValue();
            crParameterDiscreteValueDis.Value = DiscountBath;
            crParameterFieldDefinitionsDis = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionDis = crParameterFieldDefinitionsDis["Dis"];
            crParameterValuesDis = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsTypeOfPayment;
            ParameterFieldDefinition crParameterFieldDefinitionTypeOfPayment;
            ParameterValues crParameterValuesTypeOfPayment = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueTypeOfPayment = new ParameterDiscreteValue();
            crParameterDiscreteValueTypeOfPayment.Value = TypeOfPayment;
            crParameterFieldDefinitionsTypeOfPayment = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionTypeOfPayment = crParameterFieldDefinitionsTypeOfPayment["TypeOfPayment"];
            crParameterValuesTypeOfPayment = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsPayToday;
            ParameterFieldDefinition crParameterFieldDefinitionPayToday;
            ParameterValues crParameterValuesPayToday = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValuePayToday = new ParameterDiscreteValue();
            crParameterDiscreteValuePayToday.Value = PayToday;
            crParameterFieldDefinitionsPayToday = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionPayToday = crParameterFieldDefinitionsPayToday["PayToday"];
            crParameterValuesPayToday = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValuesEmp.Add(crParameterDiscreteValueEmp);
            crParameterFieldDefinitionEmp.ApplyCurrentValues(crParameterValuesEmp);

            crParameterValuesDis.Add(crParameterDiscreteValueDis);
            crParameterFieldDefinitionDis.ApplyCurrentValues(crParameterValuesDis);

            crParameterValuesTypeOfPayment.Add(crParameterDiscreteValueTypeOfPayment);
            crParameterFieldDefinitionTypeOfPayment.ApplyCurrentValues(crParameterValuesTypeOfPayment);

            crParameterValuesPayToday.Add(crParameterDiscreteValuePayToday);
            crParameterFieldDefinitionPayToday.ApplyCurrentValues(crParameterValuesPayToday);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptMedicalOrderSaleSO()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptMedicalOrderSaleSO  rpt = new RptMedicalOrderSaleSO();
            
            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(SumUnpaid);//double.Parse(PayToday)
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = PrintType;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["TypeCopyReport"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            
               crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterDiscreteValue.Value = strMoney;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BathThai"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            ParameterFieldDefinitions crParameterFieldDefinitionsEmp;
            ParameterFieldDefinition crParameterFieldDefinitionEmp;
            ParameterValues crParameterValuesEmp = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueEmp = new ParameterDiscreteValue();
            crParameterDiscreteValueEmp.Value = "( " + Statics.StrFullName + " )";
            crParameterFieldDefinitionsEmp = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionEmp = crParameterFieldDefinitionsEmp["EmpName"];
            crParameterValuesEmp = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsDis;
            ParameterFieldDefinition crParameterFieldDefinitionDis;
            ParameterValues crParameterValuesDis = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueDis = new ParameterDiscreteValue();
            crParameterDiscreteValueDis.Value = 0;
            crParameterFieldDefinitionsDis = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionDis = crParameterFieldDefinitionsDis["Dis"];
            crParameterValuesDis = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsTypeOfPayment;
            ParameterFieldDefinition crParameterFieldDefinitionTypeOfPayment;
            ParameterValues crParameterValuesTypeOfPayment = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueTypeOfPayment = new ParameterDiscreteValue();
            crParameterDiscreteValueTypeOfPayment.Value = TypeOfPayment;
            crParameterFieldDefinitionsTypeOfPayment = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionTypeOfPayment = crParameterFieldDefinitionsTypeOfPayment["TypeOfPayment"];
            crParameterValuesTypeOfPayment = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsPayToday;
            ParameterFieldDefinition crParameterFieldDefinitionPayToday;
            ParameterValues crParameterValuesPayToday = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValuePayToday = new ParameterDiscreteValue();
            crParameterDiscreteValuePayToday.Value = PayToday;
            crParameterFieldDefinitionsPayToday = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionPayToday = crParameterFieldDefinitionsPayToday["PayToday"];
            crParameterValuesPayToday = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValuesEmp.Add(crParameterDiscreteValueEmp);
            crParameterFieldDefinitionEmp.ApplyCurrentValues(crParameterValuesEmp);

            crParameterValuesDis.Add(crParameterDiscreteValueDis);
            crParameterFieldDefinitionDis.ApplyCurrentValues(crParameterValuesDis);

            crParameterValuesTypeOfPayment.Add(crParameterDiscreteValueTypeOfPayment);
            crParameterFieldDefinitionTypeOfPayment.ApplyCurrentValues(crParameterValuesTypeOfPayment);

            crParameterValuesPayToday.Add(crParameterDiscreteValuePayToday);
            crParameterFieldDefinitionPayToday.ApplyCurrentValues(crParameterValuesPayToday);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptMedicalOrderRefVN()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptMedicalOrderRefVN rpt = new RptMedicalOrderRefVN();

            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(SumUnpaid);//double.Parse(PayToday)
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = PrintType;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["TypeCopyReport"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterDiscreteValue.Value = strMoney;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BathThai"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            ParameterFieldDefinitions crParameterFieldDefinitionsEmp;
            ParameterFieldDefinition crParameterFieldDefinitionEmp;
            ParameterValues crParameterValuesEmp = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueEmp = new ParameterDiscreteValue();
            crParameterDiscreteValueEmp.Value = "( " + Statics.StrFullName + " )";
            crParameterFieldDefinitionsEmp = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionEmp = crParameterFieldDefinitionsEmp["EmpName"];
            crParameterValuesEmp = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsDis;
            ParameterFieldDefinition crParameterFieldDefinitionDis;
            ParameterValues crParameterValuesDis = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueDis = new ParameterDiscreteValue();
            crParameterDiscreteValueDis.Value = 0;
            crParameterFieldDefinitionsDis = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionDis = crParameterFieldDefinitionsDis["Dis"];
            crParameterValuesDis = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsTypeOfPayment;
            ParameterFieldDefinition crParameterFieldDefinitionTypeOfPayment;
            ParameterValues crParameterValuesTypeOfPayment = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueTypeOfPayment = new ParameterDiscreteValue();
            crParameterDiscreteValueTypeOfPayment.Value = TypeOfPayment;
            crParameterFieldDefinitionsTypeOfPayment = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionTypeOfPayment = crParameterFieldDefinitionsTypeOfPayment["TypeOfPayment"];
            crParameterValuesTypeOfPayment = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsPayToday;
            ParameterFieldDefinition crParameterFieldDefinitionPayToday;
            ParameterValues crParameterValuesPayToday = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValuePayToday = new ParameterDiscreteValue();
            crParameterDiscreteValuePayToday.Value = PayToday;
            crParameterFieldDefinitionsPayToday = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionPayToday = crParameterFieldDefinitionsPayToday["PayToday"];
            crParameterValuesPayToday = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValuesEmp.Add(crParameterDiscreteValueEmp);
            crParameterFieldDefinitionEmp.ApplyCurrentValues(crParameterValuesEmp);

            crParameterValuesDis.Add(crParameterDiscreteValueDis);
            crParameterFieldDefinitionDis.ApplyCurrentValues(crParameterValuesDis);

            crParameterValuesTypeOfPayment.Add(crParameterDiscreteValueTypeOfPayment);
            crParameterFieldDefinitionTypeOfPayment.ApplyCurrentValues(crParameterValuesTypeOfPayment);

            crParameterValuesPayToday.Add(crParameterDiscreteValuePayToday);
            crParameterFieldDefinitionPayToday.ApplyCurrentValues(crParameterValuesPayToday);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptMedicalOrderFreeApplove()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptMedicalOrderFreeApplove rpt = new RptMedicalOrderFreeApplove();

            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(SumUnpaid);//double.Parse(PayToday)
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = ApploveDr+"";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ApploveDr"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = Applove2+"";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Applove2"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ApploveRemark + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ApploveRemark"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

          

            //ParameterFieldDefinitions crParameterFieldDefinitionsDis;
            //ParameterFieldDefinition crParameterFieldDefinitionDis;
            //ParameterValues crParameterValuesDis = new ParameterValues();
            //ParameterDiscreteValue crParameterDiscreteValueDis = new ParameterDiscreteValue();
            //crParameterDiscreteValueDis.Value = 0;
            //crParameterFieldDefinitionsDis = rpt.DataDefinition.ParameterFields;
            //crParameterFieldDefinitionDis = crParameterFieldDefinitionsDis["Dis"];
            //crParameterValuesDis = crParameterFieldDefinition.CurrentValues;

            //ParameterFieldDefinitions crParameterFieldDefinitionsTypeOfPayment;
            //ParameterFieldDefinition crParameterFieldDefinitionTypeOfPayment;
            //ParameterValues crParameterValuesTypeOfPayment = new ParameterValues();
            //ParameterDiscreteValue crParameterDiscreteValueTypeOfPayment = new ParameterDiscreteValue();
            //crParameterDiscreteValueTypeOfPayment.Value = TypeOfPayment;
            //crParameterFieldDefinitionsTypeOfPayment = rpt.DataDefinition.ParameterFields;
            //crParameterFieldDefinitionTypeOfPayment = crParameterFieldDefinitionsTypeOfPayment["TypeOfPayment"];
            //crParameterValuesTypeOfPayment = crParameterFieldDefinition.CurrentValues;

            //ParameterFieldDefinitions crParameterFieldDefinitionsPayToday;
            //ParameterFieldDefinition crParameterFieldDefinitionPayToday;
            //ParameterValues crParameterValuesPayToday = new ParameterValues();
            //ParameterDiscreteValue crParameterDiscreteValuePayToday = new ParameterDiscreteValue();
            //crParameterDiscreteValuePayToday.Value = PayToday;
            //crParameterFieldDefinitionsPayToday = rpt.DataDefinition.ParameterFields;
            //crParameterFieldDefinitionPayToday = crParameterFieldDefinitionsPayToday["PayToday"];
            //crParameterValuesPayToday = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            //crParameterValuesEmp.Add(crParameterDiscreteValueEmp);
            //crParameterFieldDefinitionEmp.ApplyCurrentValues(crParameterValuesEmp);

            //crParameterValuesDis.Add(crParameterDiscreteValueDis);
            //crParameterFieldDefinitionDis.ApplyCurrentValues(crParameterValuesDis);

            //crParameterValuesTypeOfPayment.Add(crParameterDiscreteValueTypeOfPayment);
            //crParameterFieldDefinitionTypeOfPayment.ApplyCurrentValues(crParameterValuesTypeOfPayment);

            //crParameterValuesPayToday.Add(crParameterDiscreteValuePayToday);
            //crParameterFieldDefinitionPayToday.ApplyCurrentValues(crParameterValuesPayToday);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RtpRFDReq()
        {

            RptRFDReq rpt = new RptRFDReq();

            rpt.Load();
            rpt.SetDataSource(dt);

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = ENPrint;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ENPrint"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptGiftVoucher()
        {

            RptGiftVoucher rpt = new RptGiftVoucher();

            rpt.Load();
            rpt.SetDataSource(dt);

            //ParameterFieldDefinitions crParameterFieldDefinitions;
            //ParameterFieldDefinition crParameterFieldDefinition;
            //ParameterValues crParameterValues = new ParameterValues();
            //ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            //crParameterDiscreteValue.Value = ForDate + "";
            //crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            //crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            //crParameterValues = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();

            //crParameterValues.Add(crParameterDiscreteValue);
            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            //crParameterValues.Add(crParameterDiscreteValue);
            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptAccPendingNormalSummary()
        {

            RptAccPendingNormalSummary rpt = new RptAccPendingNormalSummary();

            rpt.Load();
            rpt.SetDataSource(dt);

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            //=================
            crParameterDiscreteValue.Value = BranchName + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BranchName"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            //=================
            crParameterDiscreteValue.Value = Today + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Today"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            //===================
            //=================
            crParameterDiscreteValue.Value = PRO + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["PRO"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            //===================

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptAccPendingNormal()
        {

            RptAccPendingNormal rpt = new RptAccPendingNormal();

            rpt.Load();
            rpt.SetDataSource(dt);

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            //=================
            crParameterDiscreteValue.Value = BranchName + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BranchName"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            //===================
            //=================
            crParameterDiscreteValue.Value = Today + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Today"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            //===================
            //=================
            crParameterDiscreteValue.Value = PRO + "";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["PRO"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            //===================


            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptCustomerConnect()
        {

            RptCustomerConnect rpt = new RptCustomerConnect();

            rpt.Load();
            rpt.SetDataSource(dt);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptPrintSO_Stock()
        {

            RptPrintSO_Stock rpt = new RptPrintSO_Stock();

            rpt.Load();
            rpt.SetDataSource(dt);
            //ParameterFieldDefinitions crParameterFieldDefinitions;
            //ParameterFieldDefinition crParameterFieldDefinition;
            //ParameterValues crParameterValues = new ParameterValues();
            //ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            //crParameterDiscreteValue.Value = ForDate + "";
            //crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            //crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            //crParameterValues = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();

            //crParameterValues.Add(crParameterDiscreteValue);
            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            //crParameterValues.Add(crParameterDiscreteValue);
            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptREQREPInventory()
        {

            RptREQREPInventory rpt = new RptREQREPInventory();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate+"";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptREQREPInventoryGroupByDocNumber()
        {

            RptREQREPInventoryGroupByDocNumber rpt = new RptREQREPInventoryGroupByDocNumber();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate+"";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RtpSPQInventory()
        {

            RtpSPQInventory rpt = new RtpSPQInventory();

            rpt.Load();
            rpt.SetDataSource(dt);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RtpReplySupplies()
        {

            RtpReplySupplies rpt = new RtpReplySupplies();

            rpt.Load();
            rpt.SetDataSource(dt);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RtpREQInventory()
        {

            RtpREQInventory rpt = new RtpREQInventory();

            rpt.Load();
            rpt.SetDataSource(dt);
          
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RtpReplyInventory()
        {

            RtpReplyInventory rpt = new RtpReplyInventory();

            rpt.Load();
            rpt.SetDataSource(dt);
          
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptSUCheckMoneyByCN()
        {

            RptSUCheckMoneyByCN rpt = new RptSUCheckMoneyByCN();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate+"";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = Entity.Userinfo.TName + " " + Entity.Userinfo.TSurname;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["userinfo"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptDayListCheck()
        {

            RptDayListCheck rpt = new RptDayListCheck();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptUsedCouseDaily()
        {

            RptUsedCouseDaily rpt = new RptUsedCouseDaily();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptUsedCouseDailyTP()
        {

            RptUsedCouseDailyTP rpt = new RptUsedCouseDailyTP();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptFeeDayListCheck()
        {

            RptFeeDayListCheck rpt = new RptFeeDayListCheck();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptFeeDayListCheckTP()
        {

            RptFeeDayListCheckTP rpt = new RptFeeDayListCheckTP();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptAccReceiptpaidDaily()
        {

            RptAccReceiptpaidDaily rpt = new RptAccReceiptpaidDaily();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptAccReceiptDepositDaily()
        {

            RptAccReceiptDepositDaily rpt = new RptAccReceiptDepositDaily();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptAccReceiptDebtorDepositDaily()
        {

            RptAccReceiptDebtorDepositDaily rpt = new RptAccReceiptDebtorDepositDaily();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void RptAccReceiptComSaleD1_D3()
        {

            RptAccReceiptComSaleD1_D3 rpt = new RptAccReceiptComSaleD1_D3();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }

        private void RptDayFollow()
        {

            RptDayFollow rpt = new RptDayFollow();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptHRSurgicalFeeType2()
        {

            RptHRSurgicalFeeType2 rpt = new RptHRSurgicalFeeType2();

            rpt.Load();
            rpt.SetDataSource(dt);
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ForDate;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = Userinfo.TName + " " + Userinfo.TSurname;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ENPrint"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptSOFBill2Vat()
        {
            RptSOFBill2Vat rpt = new RptSOFBill2Vat();

            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            object sumDis;
            sumDis = dt.Compute("Sum(DiscountBath)", "");
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(sumDis.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()));// - double.Parse(DiscountBath.ToString()));
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = "( " + strMoney + " )";
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BathThai"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsEmp;
            ParameterFieldDefinition crParameterFieldDefinitionEmp;
            ParameterValues crParameterValuesEmp = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueEmp = new ParameterDiscreteValue();
            crParameterDiscreteValueEmp.Value = "( " + Statics.StrFullName + " )";
            crParameterFieldDefinitionsEmp = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionEmp = crParameterFieldDefinitionsEmp["EmpName"];
            crParameterValuesEmp = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsDis;
            ParameterFieldDefinition crParameterFieldDefinitionDis;
            ParameterValues crParameterValuesDis = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueDis = new ParameterDiscreteValue();
            crParameterDiscreteValueDis.Value = 0;// DiscountBath;
            crParameterFieldDefinitionsDis = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionDis = crParameterFieldDefinitionsDis["Dis"];
            crParameterValuesDis = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsTypeOfPayment;
            ParameterFieldDefinition crParameterFieldDefinitionTypeOfPayment;
            ParameterValues crParameterValuesTypeOfPayment = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValueTypeOfPayment = new ParameterDiscreteValue();
            crParameterDiscreteValueTypeOfPayment.Value = TypeOfPayment;
            crParameterFieldDefinitionsTypeOfPayment = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionTypeOfPayment = crParameterFieldDefinitionsTypeOfPayment["TypeOfPayment"];
            crParameterValuesTypeOfPayment = crParameterFieldDefinition.CurrentValues;

            ParameterFieldDefinitions crParameterFieldDefinitionsPayToday;
            ParameterFieldDefinition crParameterFieldDefinitionPayToday;
            ParameterValues crParameterValuesPayToday = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValuePayToday = new ParameterDiscreteValue();
            crParameterDiscreteValuePayToday.Value = PayToday;
            crParameterFieldDefinitionsPayToday = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinitionPayToday = crParameterFieldDefinitionsPayToday["PayToday"];
            crParameterValuesPayToday = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValuesEmp.Add(crParameterDiscreteValueEmp);
            crParameterFieldDefinitionEmp.ApplyCurrentValues(crParameterValuesEmp);

            crParameterValuesDis.Add(crParameterDiscreteValueDis);
            crParameterFieldDefinitionDis.ApplyCurrentValues(crParameterValuesDis);

            crParameterValuesTypeOfPayment.Add(crParameterDiscreteValueTypeOfPayment);
            crParameterFieldDefinitionTypeOfPayment.ApplyCurrentValues(crParameterValuesTypeOfPayment);

            crParameterValuesPayToday.Add(crParameterDiscreteValuePayToday);
            crParameterFieldDefinitionPayToday.ApplyCurrentValues(crParameterValuesPayToday);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }

       
        private void DisplayRptRevenueByMonth()
        {
            RevenueDistributionByMonth rpt = new RevenueDistributionByMonth();
            rpt.Load();

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }  
        
        private void DisplayRptRevenueByDept()
        {
            RptRevenueByDept rpt = new RptRevenueByDept();
            rpt.Load();

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
       
        private void DisplayRptSalesVolumeByDept()
        {
            RptSalesVolumeByDept rpt = new RptSalesVolumeByDept();
            rpt.Load();

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptSalesVolumeByMonth()
        {
            RptSalesVolumeByMonth rpt = new RptSalesVolumeByMonth();
            rpt.Load();

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        } 
        private void DisplayRptRevenueByGroup()
        {
            RptRevenueDistGroup rpt = new RptRevenueDistGroup();
            rpt.Load();
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptSummaryBodyByMonth()
        {
            RptSummaryBodyByMonth rpt = new RptSummaryBodyByMonth();
            rpt.Load();
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptSummaryFaceByMonth()
        {
            RptSummaryFaceByMonth rpt = new RptSummaryFaceByMonth();
            rpt.Load();
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptSummaryBodyFaceByMonth()
        {
            RptSummaryBodyFaceByMonth rpt = new RptSummaryBodyFaceByMonth();
            rpt.Load();
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptSummaryTherapist()
        {
            RptSummaryTherapist rpt = new RptSummaryTherapist();
            rpt.Load();
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptPaymentSummary()
        {
            RptPaymentSummary rpt = new RptPaymentSummary();
            rpt.Load();
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptPaymentByGroup()
        {
            RptPaymentByGroup rpt = new RptPaymentByGroup();
            rpt.Load();
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptPaymentMarketing()
        {
            RptPaymentMarketing rpt = new RptPaymentMarketing();
            rpt.Load();
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptPaymentMarketingHear()
        {
            RptPaymentMarketingHear rpt = new RptPaymentMarketingHear();
            rpt.Load();
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptPaymentMarketingList()
        {
            RptPaymentMarketingList rpt = new RptPaymentMarketingList();
            rpt.Load();
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptPaymentSumByDept()
        {
            RptPaymentSumByDept rpt = new RptPaymentSumByDept();
            rpt.Load();
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptSalesFollow()
        {
            
            RptSalesFollow rpt = new RptSalesFollow();
            rpt.Load();
            rpt.SetDataSource(dt);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();

        }

        private void DisplayRptBrithdate()
        {

            RptBrithDate rpt = new RptBrithDate();
            rpt.Load();
            rpt.SetDataSource(dt);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptCycleDate()
        {

            RptCycleDate rpt = new RptCycleDate();
            rpt.Load();
            rpt.SetDataSource(dt);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptCoursePending()
        {

            RptCoursePending rpt = new RptCoursePending();
            rpt.Load();
            rpt.SetDataSource(dt);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptStock(string typ)
        {
            if (typ == "RptStockSell")
            {
                RptStockSell rpt = new RptStockSell();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();

                


            }
            else if (typ == "RptStockReceipt")
            {
                RptStockReceipt rpt = new RptStockReceipt();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();
                

           
            }
            else if (typ == "RptStockBalance")
            {
                RptStockBalance rpt = new RptStockBalance();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();

                


            }
        }
        private void DisplayRptAcc(string typ)
        {
            
            if (typ == "RptAccReceiptVat")
            {
                RptAccReceiptVat rpt = new RptAccReceiptVat();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();

                


            }
            else if (typ == "RptAccReceiptByProductVat")
            {
                RptAccReceiptByProductVat rpt = new RptAccReceiptByProductVat();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();

                


            }
            else if (typ == "RptAccReceiptByProductNoVat")
            {
                RptAccReceiptByProductNoVat rpt = new RptAccReceiptByProductNoVat();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();

                


            }
            else if (typ == "RptAccReceiptByProductAll")
            {
                RptAccReceiptByProductAll rpt = new RptAccReceiptByProductAll();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();
                


            }
            else if (typ == "RptAccBenefitAESTHETIC" || typ == "RptAccBenefitTREATMENT" || typ == "RptAccBenefitANGTI-AGING" || typ == "RptAccBenefitSURGERY" || typ == "RptAccBenefitHAIR")
            {
                RptAccBenefitTreatment rpt = new RptAccBenefitTreatment();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                crParameterValues = new ParameterValues();
                crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = ForDate;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ForDate"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();

                

            }
            else if (typ == "RptAccOutstanding" )
            {
                RptAccOutstanding rpt = new RptAccOutstanding();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();

                


            }
            else if (typ == "RptAccOutstandingByInvoid")
            {
                RptAccOutstandingByInvoid rpt = new RptAccOutstandingByInvoid();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();

                


            }
            else if (typ == "RptAccUseProCredit")
            {
                RptAccUseProCredit rpt = new RptAccUseProCredit();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();

                

            }
            else if (typ == "RptAccUseCourseMoRefNotProCredit")
            {
                RptAccUseCourseMoRefNotProCredit rpt = new RptAccUseCourseMoRefNotProCredit();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();

                


            }
            else if (typ == "RptAccReceiptByProductAllDetail")
            {
                RptAccReceiptByProductAllDetail rpt = new RptAccReceiptByProductAllDetail();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();

                


            }
            else if (typ == "RptAccReceiptByProductAllDetail_SaleCheck")
            {
                RptAccReceiptByProductAllDetail_SaleCheck rpt = new RptAccReceiptByProductAllDetail_SaleCheck();

                rpt.Load();
                rpt.SetDataSource(dt);

                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterDiscreteValue.Value = PrintType;
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["ReportFor"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();

                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                reportViewer.ReportSource = rpt;
                reportViewer.Refresh();

                


            }

            
            
            
            
            
            
            
        }


    }
}
