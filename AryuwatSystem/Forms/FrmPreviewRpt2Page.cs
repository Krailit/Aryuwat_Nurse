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
using CrystalDecisions.ReportSource;
using AryuwatSystem.DerClass;
using AryuwatSystem.Reports;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;

namespace AryuwatSystem.Forms
{
    public partial class FrmPreviewRpt2Page : Form
    {
        public FrmPreviewRpt2Page()
        {
            InitializeComponent();
        }

        public string FormName { get; set; }
        public string PrintType = "ORG";
        public bool HasDiscount { get; set; }
        public DataTable dt { get; set; }

        public string Cn { get; set; }
        public string AddressDer { get; set; }
        public string StrBirthDate { get; set; }
        public double? DiscountBath { get; set; }//ออกใบเสร็จ ส่วนลดเพิ่ม
        public string TypeOfPayment { get; set; }//ออกใบเสร็จ ชำระเงินโดย
        public string PayToday { get; set; }
        public string INVNo { get; set; }
        public double PayTodayDouble { get; set; }
        public double SumPriceAfterDis { get; set; }
        public double SumUnpaid { get; set; }
        public DataSet DataSetReport { get; set; }
        private void FrmPreviewRpt_Load(object sender, EventArgs e)
        {
            ReloadReport();
        }
        private void ReloadReport()
        {
            try
            {
                switch (FormName)
                {
                    case "RptCustomerList":
                        DisplayRptCustomerList();
                        break;
                    case "RptLabel8x5cm":
                        DisplayrtpLabel8x5();
                        break;
                    case "RptLabel6x3cm":
                        DisplayrtpLabel6x3();
                        break;
                    case "RptLabel3x2cm_1x":
                        DisplayrtpLabel3x2cm_1x();
                        break;

                    case "rtpLabelHairF":
                        rtpLabelHairF();
                        break;
                    case "rtpLabelPA":
                        rtpLabelPA();
                        break;
                    case "rtpLabelPA_E":
                        rtpLabelPA_E();
                        break;
                    case "rtpLabelPA_coat_E":
                        rtpLabelPA_coat_E();
                        break;
                    case "rtpLabelPA_coat":
                        rtpLabelPA_coat();
                        break;
                    case "RptLabel6x3cm_1x":
                        DisplayrtpLabel6x3cm_1x();
                        break;
                    case "RptLabel6x3cm_1xForSale":
                        DisplayRptLabel6x3cm_1xForSale();
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
                    case "RptSOFBillComplete"://ใบเสร็จ
                        //if (HasDiscount) DisplayRptSOFBill2NoVatDiscount();
                        //else DisplayRptSOFBill2NoVatNoDiscount();
                        DisplayRptSOFBillComplete();
                        break;
                    case "RptSOFBillDeposit"://ใบเสร็จ จ่ายไม่ครบ
                        DisplayRptSOFBillDeposit();
                        break;
                    case "RptSOFTaxVat"://ใบกำกับภาษี vat
                        //if (HasDiscount) DisplayRptSOFBill2VatDiscount();
                        //else DisplayRptSOFBill2VatNoDiscount();
                        DisplayRptSOFBill2VatNoDiscount();
                        
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

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        private void rtpLabelHairF()
        {
            rtpLabelHairF rpt = new rtpLabelHairF();
            rpt.Load();

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = PayToday;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ExpireDate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;


            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayrtpLabel8x5()
        {
            RptLabel8x5cm rpt = new RptLabel8x5cm();
            rpt.Load();
            rpt.SetDataSource(dt);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void rtpLabelPA()
        {
            rtpLabelPA rpt = new rtpLabelPA();
            rpt.Load();
            rpt.SetDataSource(dt);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void rtpLabelPA_E()
        {
            rtpLabelPA_E rpt = new rtpLabelPA_E();
            rpt.Load();
            rpt.SetDataSource(dt);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void rtpLabelPA_coat_E()
        {
            rtpLabelPA_coat_E rpt = new rtpLabelPA_coat_E();
            rpt.Load();
            rpt.SetDataSource(dt);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void rtpLabelPA_coat()
        {
            rtpLabelPA_coat rpt = new rtpLabelPA_coat();
            rpt.Load();
            rpt.SetDataSource(dt);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayrtpLabel3x2cm_1x()
        {
            RptLabel3x2cm_1x rpt = new RptLabel3x2cm_1x();
            rpt.Load();
            rpt.SetDataSource(dt);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayrtpLabel6x3cm_1x()
        {
            RptLabel6x3cm_1x rpt = new RptLabel6x3cm_1x();
            rpt.Load();
            rpt.SetDataSource(dt);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        private void DisplayRptLabel6x3cm_1xForSale()
        {
            RptLabel6x3cm_1xForSale rpt = new RptLabel6x3cm_1xForSale();
            rpt.Load();
            rpt.SetDataSource(dt);
            reportViewer.ReportSource = rpt;
            reportViewer.Refresh();
        }
        
        private void DisplayrtpLabel6x3()
        {
            RptLabel6x3cm rpt = new RptLabel6x3cm();
            rpt.Load();
            rpt.SetDataSource(dt);
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
            sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            //string strMoney = MoneyExt.NumberToThaiWord(Convert.ToDouble(sumObject+""));
            string strMoney = MoneyExt.NumberToThaiWord(Convert.ToDouble(SumUnpaid + ""));
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

            //reportViewer.ReportSource = rpt;
            //reportViewer.Refresh();

            string fpath = string.Format(@"{0}\TempPDF\{1}.{2}", Application.StartupPath, DateTime.Now.Ticks + "", "pdf");
            string pathTemp = string.Format(@"{0}\TempPDF\", Application.StartupPath);
            if (!Directory.Exists(pathTemp)) Directory.CreateDirectory(pathTemp);

            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fpath);
            string fpath90 = string.Format(@"{0}\TempPDF\{1}.{2}", Application.StartupPath, DateTime.Now.Ticks + "", "pdf");
            //ExtractPages(fpath, fpath90, 1, 1);
            FileInfo f = new FileInfo(fpath);
            if (f.Exists) Process.Start(fpath);
        }
        private void DisplayRptSOFINVVatDiscount()
        {
            //============================ORG==============================
            RptSOFInvVatDiscount rpt = new RptSOFInvVatDiscount();
            rpt.Load();
            rpt.SetDataSource(dt);

            string strMoney = MoneyExt.NumberToThaiWord(SumPriceAfterDis);
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
            RptSOFBill2NoVatDiscount rpt = new RptSOFBill2NoVatDiscount();

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
        private void DisplayRptSOFBillComplete()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptSOFBillComplete rpt = new RptSOFBillComplete();

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


            string fpath = string.Format(@"{0}\TempPDF\{1}.{2}", Application.StartupPath, DateTime.Now.Ticks + "", "pdf");
            string pathTemp = string.Format(@"{0}\TempPDF\", Application.StartupPath);
            if (!Directory.Exists(pathTemp)) Directory.CreateDirectory(pathTemp);
            
            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fpath);
            string fpath90 = string.Format(@"{0}\TempPDF\{1}.{2}", Application.StartupPath, DateTime.Now.Ticks + "", "pdf");
            //ExtractPages(fpath, fpath90, 1, 1);
            FileInfo f = new FileInfo(fpath);
            if (f.Exists) Process.Start(fpath);
           
            //reportViewer.ReportSource = rpt;
            //reportViewer.Refresh();
            
     
        }
        private static void ExtractPages(string inputFile, string outputFile,  int start, int end)
        {
            // get input document
            PdfReader inputPdf = new PdfReader(inputFile);

            // retrieve the total number of pages
            int pageCount = inputPdf.NumberOfPages;

            if (end < start || end > pageCount)
            {
                end = pageCount;
            }

            // load the input document
            Document inputDoc =   new Document(inputPdf.GetPageSizeWithRotation(1));

            // create the filestream
            using (FileStream fs = new FileStream(outputFile, FileMode.Create))
            {
                // create the output writer
                PdfWriter outputWriter = PdfWriter.GetInstance(inputDoc, fs);
                inputDoc.Open();

                PdfContentByte cb1 = outputWriter.DirectContent;

                // copy pages from input to output document
                for (int i = start; i <= end; i++)
                {
                    // Default to the current page size
                    iTextSharp.text.Rectangle newPageSize = null;
                    int rotation = inputPdf.GetPageSizeWithRotation(1).Rotation;
                    newPageSize = new iTextSharp.text.Rectangle(inputPdf.GetPageSizeWithRotation(1).Height, inputPdf.GetPageSizeWithRotation(1).Width, rotation+=90);
                    inputDoc.SetPageSize(newPageSize);
                    inputDoc.NewPage();
                    //inputDoc.SetPageSize(inputPdf.GetPageSizeWithRotation(1));
                    PdfImportedPage page =outputWriter.GetImportedPage(inputPdf, i);
                     //rotation = 270;// inputPdf.GetPageRotation(i);



                     switch (rotation)
                     {
                         case 0:
                             cb1.AddTemplate(page, 0, 0);
                             break;
                         case 90:
                             cb1.AddTemplate(page, 0, -1f, 1f, 0, 0, newPageSize.Height);
                             break;
                         case 180:
                             cb1.AddTemplate(page, -1f, 0, 0, -1f, newPageSize.Width, newPageSize.Height);
                             break;
                         case 270:
                             cb1.AddTemplate(page, 0, 1f, -1f, 0, newPageSize.Width, 0);
                             break;
                         default:
                             throw new System.Exception(string.Format("Unexpected rotation of {0} degrees", rotation));
                             break;
                     }
                }

                inputDoc.Close();
            }
        }
        private void DisplayRptSOFBillDeposit()
        {
            //RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();
            RptSOFBillDeposit rpt = new RptSOFBillDeposit();

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


            string fpath = string.Format(@"{0}\TempPDF\{1}.{2}", Application.StartupPath, DateTime.Now.Ticks + "", "pdf");
            string pathTemp = string.Format(@"{0}\TempPDF\", Application.StartupPath);
            if (!Directory.Exists(pathTemp)) Directory.CreateDirectory(pathTemp);

            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fpath);
            string fpath90 = string.Format(@"{0}\TempPDF\{1}.{2}", Application.StartupPath, DateTime.Now.Ticks + "", "pdf");
            //ExtractPages(fpath, fpath90, 1, 1);
            FileInfo f = new FileInfo(fpath);
            if (f.Exists) Process.Start(fpath);
           

            //reportViewer.ReportSource = rpt;
            //reportViewer.Refresh();
        }
        private void DisplayRptSOFBill2VatDiscount()
        {
            RptSOFBill2VatDiscount rpt = new RptSOFBill2VatDiscount();

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


            crParameterDiscreteValue.Value = PrintType;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["TypeCopyReport"];
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
        private void DisplayRptSOFBill2VatNoDiscount()
        {
            RptSOFTaxVat rpt = new RptSOFTaxVat();

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

            crParameterDiscreteValue.Value = strMoney;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["BathThai"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterDiscreteValue.Value = PrintType;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["TypeCopyReport"];
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

        private void btnORG_Click(object sender, EventArgs e)
        {

            PrintType = "ORG";
            ReloadReport();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            PrintType = "COPY";
            ReloadReport();
        }
    }
}
