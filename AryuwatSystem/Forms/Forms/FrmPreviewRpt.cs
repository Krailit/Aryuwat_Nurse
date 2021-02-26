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
using DermasterSystem.Class;
using DermasterSystem.Reports;

namespace DermasterSystem.Forms
{
    public partial class FrmPreviewRpt : Form
    {
        public FrmPreviewRpt()
        {
            InitializeComponent();
        }

        public string FormName { get; set; }
        public DataTable dt { get; set; }

        public string Cn { get; set; }
        public string StrBirthDate { get; set; }
        public double? DiscountBath { get; set; }//ออกใบเสร็จ ส่วนลดเพิ่ม
        public string TypeOfPayment { get; set; }//ออกใบเสร็จ ชำระเงินโดย
        public string PayToday { get; set; }
        public DataSet DataSetReport { get; set; }
        private void FrmPreviewRpt_Load(object sender, EventArgs e)
        {
            try
            {

   
            switch (FormName)
            {
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
                case "RptSOFBill2Vat":
                    DisplayRptSOFBill2Vat();
                    break;
                case "RptSOFBill2NoVat":
                    DisplayRptSOFBill2NoVat();
                    break;
                case "RptRevenueByMonth":
                    DisplayRptRevenueByMonth();
                    break;
                case "RptRevenueByDept":
                    DisplayRptRevenueByDept();
                    break;
                case "RptAestheticSummary":
                    DisplayRptAestheticSummary();
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
        private void DisplayRptSOFBill2NoVat()
        {
            RptSOFBill2NoVat rpt = new RptSOFBill2NoVat();

            rpt.Load();
            rpt.SetDataSource(dt);
            object sumObject;
            //sumObject = dt.Compute("Sum(PriceAfterDis)", "");
            //object sumDis;
            //sumDis = dt.Compute("Sum(DiscountBath)", "");//Unpaid
            //sumDis = dt.Rows[0]["Unpaid"];//Unpaid
            //string strMoney = MoneyExt.NumberToThaiWord(double.Parse(sumObject.ToString()) - double.Parse(DiscountBath.ToString()));
            string strMoney = MoneyExt.NumberToThaiWord(double.Parse(PayToday));
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
        private void DisplayRptAestheticSummary()
        {
            RptAestheticSummary rpt = new RptAestheticSummary();
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
    }
}
