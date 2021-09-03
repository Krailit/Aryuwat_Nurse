using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;


namespace AryuwatSystem.Data
{
    public class Customer
    {
        public static int? InsertMembersID(ref Entity.Customer info, SqlTransaction trn)
        {

            try
            {

                SqlParameter[] msSqlParameter = {
                                                   new SqlParameter("@QueryType","INSERT_MEMID"),
                                                   new SqlParameter("@CN", info.CN),
                                                   new SqlParameter("@CreateBy", info.CreateBy),
                                                   new SqlParameter("@MemID", info.MemID)
                                                   

                                               };
                int intStatus =
                    SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_customer", msSqlParameter);
           
                return intStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int? InsertCustomer(ref Entity.Customer info, SqlTransaction trn)
        {
           
            try
            {


                //var idMax = UtilityBackEnd.GenMaxSeqnoValues(info.DocPrefix);
                //var nameImage = string.IsNullOrEmpty(info.Image) ? null : idMax + Path.GetExtension(info.Image);

                SqlParameter[] msSqlParameter = {
                                                   new SqlParameter("@QueryType","INSERT"),
                                                   //new SqlParameter("@CN", idMax),
                                                   new SqlParameter("@CN", info.CN),
                                                   new SqlParameter("@Dateregister", info.DateRegister),
                                                   new SqlParameter("@PrefixCode", info.PrefixCode),
                                                   new SqlParameter("@Tname", info.TName),
                                                   new SqlParameter("@TsurName", info.TSurname),
                                                   new SqlParameter("@Tnickname", info.TNickname),
                                                   new SqlParameter("@FirstName", info.Firstname),
                                                   new SqlParameter("@MiddleName", info.Middlename),
                                                   new SqlParameter("@Surname", info.Surname),
                                                   new SqlParameter("@Nickname", info.NickName),
                                                   new SqlParameter("@DateBirth", info.DateBirth),
                                                   new SqlParameter("@DateBirthOther", info.DateBirthOther),
                                                   new SqlParameter("@Age", info.Age),
                                                   new SqlParameter("@Gender", info.Gender),
                                                   new SqlParameter("@Height", info.Height),
                                                   new SqlParameter("@Weights", info.Weights),
                                                   new SqlParameter("@Nationality", info.Nationality),
                                                   new SqlParameter("@Race", info.Race),
                                                   new SqlParameter("@Mobile1", info.Mobile1),
                                                   new SqlParameter("@Mobile2", info.Mobile2),
                                                   new SqlParameter("@Tel1", info.Tel1),
                                                   new SqlParameter("@Tel2", info.Tel2),
                                                   new SqlParameter("@E_mail", info.E_mail),
                                                   new SqlParameter("@AddressId", info.AddressId),
                                                   new SqlParameter("@Building", info.Building),
                                                   new SqlParameter("@Soi", info.Soi),
                                                   new SqlParameter("@Road", info.Road),
                                                   new SqlParameter("@Sub_districtCode", info.Sub_district),
                                                   new SqlParameter("@DistrictCode", info.District),
                                                   new SqlParameter("@ProvinceCode", info.Province),
                                                   new SqlParameter("@Postcode", info.PostCode),
                                                   new SqlParameter("@PassportNo", info.PassportNo),
                                                   new SqlParameter("@IdCard", info.IdCard),
                                                   new SqlParameter("@VipFlag", info.VipFlag),
                                                   new SqlParameter("@Celeb", info.Celeb),
                                                   new SqlParameter("@Remark", info.Remark),
                                                   new SqlParameter("@AllergyHistory", info.AllergyHistory),
                                                   new SqlParameter("@UnderlyingDisease", info.UnderlyingDisease),
                                                   new SqlParameter("@WhereGotTreatment", info.WhereGotTreatment),
                                                   new SqlParameter("@CreateBy", info.CreateBy),
                                                   new SqlParameter("@CreateDate", DateTime.Now),
                                                   new SqlParameter("@UpdateBy", info.UpdateBy),
                                                   new SqlParameter("@Image", info.Image),
                                                   new SqlParameter("@CustomerType",info.CustomerType),
                                                   new SqlParameter("@AgenMemID",info.AgenMemId),
                                                   new SqlParameter("@BloodPressure",info.BloodPressure),
                                                   new SqlParameter("@ProviderTypID",info.ProviderTypID),
                                                   new SqlParameter("@Credit_Bath",info.Credit_Bath),
                                                   new SqlParameter("@Credit_Day",info.Credit_Day),
                                                   new SqlParameter("@Country_ID", info.Country),
                                                   new SqlParameter("@SaleConsult", info.SaleConsult),
                                                   new SqlParameter("@MainOfficeCust", info.MainOfficeCust),
                                                   new SqlParameter("@BranchCust", info.BranchCust),
                                                   new SqlParameter("@BranchAuth", info.BranchAuth),
                                                   new SqlParameter("@BranchID", info.BranchId),
                                                   new SqlParameter("@Active", info.Is_Active)
                                               };
                int intStatus =
                    SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_customer", msSqlParameter);
                //info.CN = idMax;
                if (intStatus == 1)
                {
                    if (File.Exists(Properties.Settings.Default.ImagePathServer + "\\" + info.Image))
                    {
                        File.Delete(Properties.Settings.Default.ImagePathServer + "\\" + info.Image);

                    }
                    if (info.Image != null)
                    {
                        File.Copy(info.ImagePath, Properties.Settings.Default.ImagePathServer + "\\" + info.Image);
                    }
                }
                return intStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int? InsertMembersGroup(ref Entity.Customer info, SqlTransaction trn)
        {

            try
            {


                //var idMax = UtilityBackEnd.GenMaxSeqnoValues(info.DocPrefix);
                //var nameImage = string.IsNullOrEmpty(info.Image) ? null : idMax + Path.GetExtension(info.Image);

                SqlParameter[] msSqlParameter = {
                                                   new SqlParameter("@QueryType","INSERT"),
                                                   //new SqlParameter("@CN", idMax),
                                                   new SqlParameter("@CN", info.CN),
                                                   new SqlParameter("@Dateregister", info.DateRegister),
                                                   new SqlParameter("@PrefixCode", info.PrefixCode),
                                                   new SqlParameter("@Tname", info.TName),
                                                   new SqlParameter("@TsurName", info.TSurname),
                                                   new SqlParameter("@Tnickname", info.TNickname),
                                                   new SqlParameter("@FirstName", info.Firstname),
                                                   new SqlParameter("@MiddleName", info.Middlename),
                                                   new SqlParameter("@Surname", info.Surname),
                                                   new SqlParameter("@Nickname", info.NickName),
                                                   new SqlParameter("@DateBirth", info.DateBirth),
                                                   new SqlParameter("@DateBirthOther", info.DateBirthOther),
                                                   new SqlParameter("@Age", info.Age),
                                                   new SqlParameter("@Gender", info.Gender),
                                                   new SqlParameter("@Height", info.Height),
                                                   new SqlParameter("@Weights", info.Weights),
                                                   new SqlParameter("@Nationality", info.Nationality),
                                                   new SqlParameter("@Race", info.Race),
                                                   new SqlParameter("@Mobile1", info.Mobile1),
                                                   new SqlParameter("@Mobile2", info.Mobile2),
                                                   new SqlParameter("@Tel1", info.Tel1),
                                                   new SqlParameter("@Tel2", info.Tel2),
                                                   new SqlParameter("@E_mail", info.E_mail),
                                                   new SqlParameter("@AddressId", info.AddressId),
                                                   new SqlParameter("@Building", info.Building),
                                                   new SqlParameter("@Soi", info.Soi),
                                                   new SqlParameter("@Road", info.Road),
                                                   new SqlParameter("@Sub_districtCode", info.Sub_district),
                                                   new SqlParameter("@DistrictCode", info.District),
                                                   new SqlParameter("@ProvinceCode", info.Province),
                                                   new SqlParameter("@Postcode", info.PostCode),
                                                   new SqlParameter("@PassportNo", info.PassportNo),
                                                   new SqlParameter("@IdCard", info.IdCard),
                                                   new SqlParameter("@VipFlag", info.VipFlag),
                                                   new SqlParameter("@Remark", info.Remark),
                                                   new SqlParameter("@AllergyHistory", info.AllergyHistory),
                                                   new SqlParameter("@UnderlyingDisease", info.UnderlyingDisease),
                                                   new SqlParameter("@WhereGotTreatment", info.WhereGotTreatment),
                                                   new SqlParameter("@CreateBy", info.CreateBy),
                                                   new SqlParameter("@CreateDate", DateTime.Now),
                                                   new SqlParameter("@UpdateBy", info.UpdateBy),
                                                   new SqlParameter("@Image", info.Image),
                                                   new SqlParameter("@CustomerType",info.CustomerType),
                                                   new SqlParameter("@AgenMemID",info.AgenMemId),
                                                   new SqlParameter("@BloodPressure",info.BloodPressure),
                                                   new SqlParameter("@ProviderTypID",info.ProviderTypID),
                                                   new SqlParameter("@Credit_Bath",info.Credit_Bath),
                                                   new SqlParameter("@Credit_Day",info.Credit_Day)
                                               };
                int intStatus =
                    SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_customer", msSqlParameter);
                //info.CN = idMax;
                if (intStatus == 1)
                {
                    if (File.Exists(Properties.Settings.Default.ImagePathServer + "\\" + info.Image))
                    {
                        File.Delete(Properties.Settings.Default.ImagePathServer + "\\" + info.Image);

                    }
                    if (info.Image != null)
                    {
                        File.Copy(info.ImagePath, Properties.Settings.Default.ImagePathServer + "\\" + info.Image);
                    }
                }
                return intStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetCnNumber(string docPrefix, string BranchID)
        {
            try
            {
                var idMax = UtilityBackEnd.GenMaxSeqnoValues(docPrefix, BranchID);
                return idMax;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int? INSERTCustomerConnect(Entity.Customer info, SqlTransaction trn)
        {
            StringBuilder sb = new StringBuilder();

            SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","INSERTCustomerConnect"),
                                               new SqlParameter("@ContactName", info.ContactName),
                                               new SqlParameter("@ContactFrom", info.ContactFrom),
                                                new SqlParameter("@Mobile1", info.Mobile1),
                                               new SqlParameter("@ContactFB_IN_LineID", info.ContactFB_IN_LineID),
                                               new SqlParameter("@Interest", info.Interest),
                                               new SqlParameter("@DateConnect", info.DateConnect),
                                               new SqlParameter("@DateBooking", info.DateBooking),
                                               new SqlParameter("@CloseBal", info.CloseBal),
                                               new SqlParameter("@Remark", info.Remark),
                                               new SqlParameter("@EN", info.SaleConsult),
                                               new SqlParameter("@EN_Save", info.EN),
                                               new SqlParameter("@ID", info.CFID),
                                               new SqlParameter("@BranchId", info.BranchId)
                                               
                                               
                                           };
            int intStatus =
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_customer", msSqlParameter);
 
            return intStatus;
        }

        public static int? UpdateCustomer(Entity.Customer info, SqlTransaction trn)
        {
            StringBuilder sb = new StringBuilder();
        
            SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","UPDATE"),
                                               //new SqlParameter("@CN", info.CN),
                                               new SqlParameter("@CN", info.CN),
                                               new SqlParameter("@Dateregister", info.DateRegister),
                                               new SqlParameter("@PrefixCode", info.PrefixCode),
                                               new SqlParameter("@Tname", info.TName),
                                               new SqlParameter("@TsurName", info.TSurname),
                                               new SqlParameter("@Tnickname", info.TNickname),
                                               new SqlParameter("@FirstName", info.Firstname),
                                               new SqlParameter("@MiddleName", info.Middlename),
                                               new SqlParameter("@Surname", info.Surname),
                                               new SqlParameter("@Nickname", info.NickName),
                                               new SqlParameter("@DateBirth", info.DateBirth),
                                               new SqlParameter("@DateBirthOther", info.DateBirthOther),
                                               new SqlParameter("@Age", info.Age),
                                               new SqlParameter("@Gender", info.Gender),
                                               new SqlParameter("@Height", info.Height),
                                               new SqlParameter("@Weights", info.Weights),
                                               new SqlParameter("@Nationality", info.Nationality),
                                               new SqlParameter("@Race", info.Race),
                                               new SqlParameter("@Mobile1", info.Mobile1),
                                               new SqlParameter("@Mobile2", info.Mobile2),
                                               new SqlParameter("@Tel1", info.Tel1),
                                               new SqlParameter("@Tel2", info.Tel2),
                                               new SqlParameter("@E_mail", info.E_mail),
                                               new SqlParameter("@AddressId", info.AddressId),
                                               new SqlParameter("@Building", info.Building),
                                               new SqlParameter("@Soi", info.Soi),
                                               new SqlParameter("@Road", info.Road),
                                               new SqlParameter("@Sub_districtCode", info.Sub_district),
                                               new SqlParameter("@DistrictCode", info.District),
                                               new SqlParameter("@ProvinceCode", info.Province),
                                               new SqlParameter("@Postcode", info.PostCode),
                                               new SqlParameter("@PassportNo", info.PassportNo),
                                               new SqlParameter("@IdCard", info.IdCard),
                                               new SqlParameter("@VipFlag", info.VipFlag),
                                               new SqlParameter("@Celeb", info.Celeb),
                                               new SqlParameter("@Remark", info.Remark),
                                               new SqlParameter("@AllergyHistory", info.AllergyHistory),
                                               new SqlParameter("@UnderlyingDisease", info.UnderlyingDisease),
                                               new SqlParameter("@WhereGotTreatment", info.WhereGotTreatment),
                                               new SqlParameter("@UpdateBy", info.UpdateBy),
                                               new SqlParameter("@UpdateDate",DateTime.Now),
                                               new SqlParameter("@Image", info.Image),
                                               new SqlParameter("@BranchId", info.BranchId),
                                               new SqlParameter("@AgenMemID",info.AgenMemId),
                                               new SqlParameter("@BloodPressure",info.BloodPressure),
                                               new SqlParameter("@ProviderTypID",info.ProviderTypID),
                                               new SqlParameter("@Credit_Bath",info.Credit_Bath),
                                               new SqlParameter("@Credit_Day",info.Credit_Day),
                                               new SqlParameter("@Country_ID",info.Country),
                                               new SqlParameter("@SaleConsult", info.SaleConsult),
                                               new SqlParameter("@MainOfficeCust", info.MainOfficeCust),
                                               new SqlParameter("@BranchCust", info.BranchCust),
                                               new SqlParameter("@Active", info.Is_Active)
                                           };
            int intStatus =
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_customer", msSqlParameter);
            //if (!string.IsNullOrEmpty(info.Image))
            //{
            //    if (File.Exists(Properties.Settings.Default.ImagePathServer + "\\" + info.Image))
            //    {
            //        File.Delete(Properties.Settings.Default.ImagePathServer + "\\" + info.Image);

            //    }
            //    if (info.Image != null)
            //    {
            //        File.Copy(info.ImagePath, Properties.Settings.Default.ImagePathServer + "\\" + info.Image);
            //    }
            //}
            return intStatus;
        }
        public static DataSet SelectCustomerConnect(Entity.Customer info)
        {
            try
            {
                long iRowStart = 0;
                long iRowEnd = 0;
                DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@StartDate",info.StartDate),
                                               new SqlParameter("@EndDate",info.EndDate),
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd)
                                            };
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_customer", msSqlParameter);
                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectCustomerPaging", ex);
            }
        }
        public static DataSet SelectCustomerPaging(Entity.Customer info)
        {
            try
            {
               // StringBuilder sb = new StringBuilder();
               // sb.Append(" select vwData.* from  \n");
               // sb.Append(" ( \n");
               // sb.Append(" 	select  \n");
               // sb.Append(" 	vwTmp.*,max(vwTmp.rownum) over ()As rowTotal   \n");
               // sb.Append(" 	 \n");
               // sb.Append(" 	from  \n");
               // sb.Append(" 	( \n");
               // sb.Append(" 		select  \n");
               // sb.Append(" 			ROW_NUMBER() OVER (ORDER BY cust.CN Asc) AS rownum \n");
               // sb.Append("          ,cust.CN \n");
               // sb.Append(" 			,cust.CN  \n");
               // sb.Append(" 			,(case when cust.Tname <> '' then cust.PrefixCode+ ' ' \n");
               // sb.Append(" 				+ cust.Tname + ' ' + cust.TsurName  \n");
               // sb.Append(" 				else '' end ) as FullNameThai \n");
               // sb.Append(" 			,(case when cust.FirstName <> '' then cust.PrefixCode + ' '+ cust.FirstName + ' ' \n");
               // sb.Append(" 				+ cust.MiddleName + ' '+ cust.Surname  \n");
               // sb.Append(" 			  else '' end)	  as FullNameEng \n");
               // sb.Append(" 			 ,(case when cust.Gender = 'M' then 'Male' else 'Female' end) as gender \n");
               // sb.Append(" 			,(   case when STUFF(cust.Mobile1,4,0,'-') IS NULL then ' ' else STUFF(cust.Mobile1,4,0,'-') end +'  '+ case when STUFF(cust.Mobile2,4,0,'-') IS NULL then '' else STUFF(cust.Mobile2,4,0,'-') end ) As Mobile  \n");
               // sb.Append(" 			,(cust.Tel1 + case when cust.Tel2 <> '' then + '/'else  + cust.Tel2 end ) As Tel \n");
               // //sb.Append(" 			,(cust.AddressId + ' '+ cust.Building + ' ' + cust.soi + ' '  \n");
               // //sb.Append(" 			  + cust.Road + ' ' + subD.SUBDISTRICT_NAME + ' '  \n");
               // //sb.Append(" 			  + dist.District_NAME + ' ' + pro.PROVINCE_NAME + ' ' + cust.postcode ) As Address			 \n");
               //sb.Append(" 			   ,(cust.AddressId + ' '+ cust.Building + ' ซ.' +case when cust.soi ='' then '-' else cust.soi end + ' ถ.'  	 \n");
               //               sb.Append(" 			  + case when cust.Road ='' then '-' else cust.Road end + ' แขวง/ต.' + subD.SUBDISTRICT_NAME + ' เขต/อ.'  	 \n");
               //               sb.Append(" 			  + dist.District_NAME + ' จ.' + pro.PROVINCE_NAME + ' ' + cust.postcode ) As Address		 \n");
               // sb.Append("        ,cust.CustomerType \n");
               // sb.Append(" 		from  Customers cust     \n");
               // //sb.Append(" 		left outer join Prefix pre on pre.PrefixCode = cust.PrefixCode 		 \n");
               // sb.Append(" 		left outer join Provinces pro on pro.PROVINCE_CODE =  cust.ProvinceCode \n");
               // sb.Append(" 		left outer join Districts dist on dist.District_CODE = cust.DistrictCode \n");
               // sb.Append(" 		left outer join Subdistricts subD on subD.SUBDISTRICT_CODE = cust.Sub_districtCode \n");
               // sb.Append(" 		where 1= 1 \n");
               // sb.Append(" 		and ((@CN is null) or (cust.CN like @CN)) \n");
               // sb.Append(" 		and (((@Mobile1 is null) or (cust.Mobile1 like @Mobile1)) Or ((@Mobile1 is null) or (cust.Mobile2 like @Mobile1))  Or ((@Mobile1 is null) or (cust.tel1 like @Mobile1))  Or ((@Mobile1 is null) or (cust.Mobile2 like @Mobile1))) \n");
               // sb.Append(" 		and (((@Tname is null) or (cust.Tname like @Tname)) Or ((@Tname is null) or (cust.FirstName like @Tname))) \n");
               // sb.Append(" 		and (((@TsurName is null) or (cust.TsurName like @TsurName)) Or ((@TsurName is null) or (cust.Surname like @TsurName))) \n");
               // sb.Append(" 	) as vwTmp \n");
               // sb.Append(" ) as vwData \n");
               // sb.Append(" Where rownum >=@row_start and rownum <=@row_end   \n");
                long iRowStart = 0;
                long iRowEnd = 0;
                DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECT"),
                                               new SqlParameter("@CN",info.CN),
                                               new SqlParameter("@Tname",info.TName),
                                               new SqlParameter("@TsurName",info.TSurname),
                                               new SqlParameter("@DateBirthOther",info.DateBirthOther),
                                               new SqlParameter("@Mobile1",info.Mobile1),
                                               //new SqlParameter("@IdCard",info.IdCard),
                                               new SqlParameter("@MemID",info.MemID),

                                               new SqlParameter("@BranchId",info.BranchId),
                                               
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd)
                                            };
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_customer", msSqlParameter);
                return ds;
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectCustomerPaging", ex);
            }
        }
        public static DataSet SelectCustomerPOP(Entity.Customer info)
        {
            try
            {
               
                long iRowStart = 0;
                long iRowEnd = 0;
                DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","POPUP_SELECT"),
                                               new SqlParameter("@CN",info.CN),
                                               new SqlParameter("@Tname",info.TName),
                                               new SqlParameter("@TsurName",info.TSurname),
                                               new SqlParameter("@DateBirthOther",info.DateBirthOther),
                                               new SqlParameter("@Mobile1",info.Mobile1),
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd)
                                            };
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_customer", msSqlParameter);
                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectCustomerPaging", ex);
            }
        }


        public static DataSet SelectCustomerWhereCause(Entity.Customer info)
        {
            try
            {
                long iRowStart = 0;
                long iRowEnd = 0;
                DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTWHERECAUSE"),
                                               new SqlParameter("@CN",info.CN),
                                               new SqlParameter("@Tname",info.TName),
                                               new SqlParameter("@TsurName",info.TSurname),
                                               new SqlParameter("@Mobile1",info.Mobile1),
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd)
                                            };
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_customer", msSqlParameter);
                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectCustomerWhereCause", ex);
            }
        }


        public static DataSet SelectCustomerById(string CN)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" select cust.*,(agency.AgenMemPrefix+ ' ' + agency.AgenMemName + ' ' + agency.AgenMemSurName) as agencyFullNameThai ,cust.SaleConsult,per.TName+' '+per.[TSurname] as SaleConsultName from Customers cust left outer join [AgencyMember] agency on agency.AgenMemID = cust.AgenMemID left join Personnels per  WITH (NOLOCK)  on per.EN=cust.SaleConsult Where cust.CN = @CN; \n");
                sb.Append(" select * from AestheticCenter where CN = @CN; \n");
                sb.Append(" select * from BodyCenter      where CN = @CN; \n");
                sb.Append(" select * from CosmeticSurgery where CN = @CN; \n");
                sb.Append(" select * from HairCenter      where CN = @CN; \n");
                sb.Append(" select * from HowYouhear      where CN = @CN; \n");
                sb.Append(" select * from ContactCustomer Where CN = @CN; \n");
                //sb.Append(" SELECT m.cn_sub ,(case when cust.Tname <> '''' then cust.PrefixCode+ '''' + cust.Tname + '' '' + cust.TsurName else '''' end ) as FullNameThai,(case when cust.FirstName <> '''' then cust.PrefixCode + ''''+ cust.FirstName + '' '' + cust.MiddleName + '' ''+ cust.Surname else '''' end)	  as FullNameEng,cust.CustomerType FROM [MemberGroup] m inner join [dbo].[Customers] cust on cust.cn=m.cn_sub where m.cn_main= @CN; \n");
                sb.Append(string.Format("exec sp_MemberGroup @CN='{0}'",CN));
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@CN",CN)
                                            };
                sb.Append(" select * from FileOPD Where CN = @CN; \n");
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.Text, sb.ToString(), msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectCustomerById", ex);
            }
        }
        public static DataSet SelectCustomerOpdScan(string CN)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                             SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@CN",CN)
                                            };
                sb.Append(" select * from FileOPD Where CN = @CN; \n");
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.Text, sb.ToString(), msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectCustomerById", ex);
            }
        }
        public static DataSet SelectCustomerMemberById(string CN)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("exec sp_MemberGroup @CN='" + CN + "'; \n");
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@CN",CN)
                                            };
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.Text, sb.ToString(), msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectCustomerById", ex);
            }
        }
        public static DataSet CheckDupCustomer(string cn)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" select cn from Customers       Where CN = @CN; \n");
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@CN",cn)
                                            };
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.Text, sb.ToString(), msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.CheckDupCustomer", ex);
            }
        }

        public static DataSet SelectCustomerByCN(string cn, string IDCard, string cname)
        {
         

            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","CHECK_DUP"),
                                               new SqlParameter("@CN",cn),
                                               new SqlParameter("@IdCard",IDCard),
                                               new SqlParameter("@CUSTNAME",cname)
                                            };
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_customer", msSqlParameter);
                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectCustomerByCN", ex);
            }
        }
        public static DataSet SelectDistinctCN()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT distinct [CustomerType] FROM [dbo].[Customers] order by [CustomerType]");
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.Text, sb.ToString());
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectCustomerByCN", ex);
            }
        }


        public static int? DeleteContactById(Entity.Customer info, SqlTransaction trn)
        {
            try
            {
                long iRowStart = 0;
                long iRowEnd = 0;
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","DeleteContactById"),
                                               new SqlParameter("@ID",info.CFID),
                                               new SqlParameter("@EN",info.EN)
                                            };
              int  intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_customer",msSqlParameter);


                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectCustomerWhereCause", ex);
            }
        }

        public static int? DeleteCustomerById(Entity.Customer info, SqlTransaction trn)
        {
        
            try
            {
                long iRowStart = 0;
                long iRowEnd = 0;
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","DeleteCustomerById"),
                                               new SqlParameter("@CN",info.CN),
                                               new SqlParameter("@EN",info.EN)
                                             
                                            };
                //DataSet ds =
                //    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_customer", msSqlParameter);
              int  intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_customer",msSqlParameter);


                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectCustomerWhereCause", ex);
            }
        }

        public static DataSet SelectRptCustomerById(string CN)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
               
                sb.Append(" 		select  \n");
                sb.Append("            cust.CN \n");
                sb.Append("            ,cust.Height \n");
                sb.Append("            ,cust.Weights \n");
                sb.Append("            ,cust.BloodPressure \n");
                sb.Append(" 			,cust.CN ,cust.NickName,cust.E_mail \n");
                sb.Append(" 			,(case when cust.Tname <> '' then cust.PrefixCode+ ' ' \n");
                sb.Append(" 				+ cust.Tname + ' ' + cust.TsurName  \n");
                sb.Append(" 				else '' end ) as FullNameThai \n");
                sb.Append(" 			,(case when cust.FirstName <> '' then cust.PrefixCode + ' '+ cust.FirstName + ' ' \n");
                sb.Append(" 				+ cust.MiddleName + ' '+ cust.Surname  \n");
                sb.Append(" 			  else '' end)	  as FullNameEng \n");
                sb.Append(" 			 ,(case when cust.Gender = 'M' then 'Male' else 'Female' end) as Gender \n");
                sb.Append(" 			,(   case when STUFF(cust.Mobile1,4,0,'-') IS NULL then ' ' else STUFF(cust.Mobile1,4,0,'-') end +'  '+ case when STUFF(cust.Mobile2,4,0,'-') IS NULL then '' else STUFF(cust.Mobile2,4,0,'-') end ) As Mobile  \n");
                sb.Append(" 			,(cust.Tel1 + '/' + cust.Tel2 ) As Tel \n");
                sb.Append(" 			,(cust.AddressId + ' '+ cust.Building + ' ' + cust.soi + ' '  \n");
                sb.Append(" 			  + cust.Road + ' ' + subD.SUBDISTRICT_NAME + ' '  \n");
                sb.Append(" 			  + dist.District_NAME + ' ' + pro.PROVINCE_NAME + ' ' + cust.postcode ) As Address			 \n");
                sb.Append("             ,cust.DateBirth \n");
                sb.Append("             ,cust.AllergyHistory \n");
                sb.Append("             ,cust.UnderlyingDisease \n");
                sb.Append(" 		from  Customers cust     \n");
                //sb.Append(" 		left outer join Prefix pre on pre.PrefixCode = cust.PrefixCode 		 \n");
                sb.Append(" 		left outer join Provinces pro on pro.PROVINCE_CODE =  cust.ProvinceCode \n");
                sb.Append(" 		left outer join Districts dist on dist.District_CODE = cust.DistrictCode \n");
                sb.Append(" 		left outer join Subdistricts subD on subD.SUBDISTRICT_CODE = cust.Sub_districtCode \n");
                sb.Append(" 		where cust.CN= @CN \n");
              
            
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@CN",CN),
                                               new SqlParameter("@QueryType","PRINTDETAIL")
                                            };
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_customer", msSqlParameter);
                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectRptCustomerById", ex);
            }
        }

    }

}
