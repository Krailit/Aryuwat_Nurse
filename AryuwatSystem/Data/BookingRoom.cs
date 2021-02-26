using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;
using Entity.Validation;
using Calendar.NET;
using Entity;

namespace AryuwatSystem.Data
{
    public class BookingRoom
    {
        public static DataSet DUP_BOOKINGROOM(SqlTransaction trn, string whereDate)
        {
            DataSet set2;
            try
            {
                SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@QueryType", "DUP_BOOKINGROOM"), new SqlParameter("@whereDate", whereDate) };
                set2 = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", commandParameters);
            }
            catch (Exception exception)
            {
                throw new Exception("An error occurred while executing the Data.GetBookingRoomExport", exception);
            }
            return set2;
        }
        public static DataSet DUP_BOOKINGDOCTOR(SqlTransaction trn, CustomEvent book)
        {
            DataSet set2;
            try
            {
                SqlParameter[] commandParameters = new SqlParameter[] { 
                                                                        new SqlParameter("@QueryType", "DUP_BOOKINGDOCTOR"),
                                                                        new SqlParameter("@AppointDate",book.AppointDate),
                                                                        //new SqlParameter("@TimeStart",book.TimeStart),
                                                                        //new SqlParameter("@TimeEnd", book.TimeEnd),
                                                                        new SqlParameter("@RoomID", book.RoomID),
                                                                        new SqlParameter("@DrID", book.DrID),
                                                                        new SqlParameter("@BranchID", book.BranchID) 
                                                                        };
                set2 = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", commandParameters);
            }
            catch (Exception exception)
            {
                throw new Exception("An error occurred while executing the Data.GetBookingRoomExport", exception);
            }
            return set2;
        }


        public static DataSet SelectRoom(SqlTransaction trn,string typ)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTROOM"),
                                                new SqlParameter("@TYP",typ)
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }

        public static int SaveBookingRoom(SqlTransaction trn, List<ItemInfo> lst, List<ItemInfo> RoomDelete)
        {
            try
            {
                try
                {
                    foreach (ItemInfo itemInfo in RoomDelete)
                    {
                        SqlParameter[] msSqlParameter = {
                                                        new SqlParameter("@QueryType", "DELETE"),
                                                        new SqlParameter("@RoomID", itemInfo.RoomID),
                                                        new SqlParameter("@BookID", itemInfo.BookID),
                                                        new SqlParameter("@DateShowStart",itemInfo.DateShowStart),
                                                    };
                        SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                    }
                }
                catch (Exception)
                {
                }
               

                var intStatus = 0;
                foreach (ItemInfo info in lst)
                {
                SqlParameter[] msSqlParameter = {
                                                        new SqlParameter("@QueryType", "INSERT"),
                                                        new SqlParameter("@RoomID", info.RoomID),
                                                        new SqlParameter("@AppointDate", info.AppointDateTime),
                                                        new SqlParameter("@DateShowStart",info.DateShowStart),
                                                        new SqlParameter("@DateShowEnd", info.DateShowEnd),
                                                        new SqlParameter("@Duration", info.Duration),
                                                        new SqlParameter("@A", info.A),
                                                        new SqlParameter("@R", info.R),
                                                        new SqlParameter("@G", info.G),
                                                        new SqlParameter("@B", info.B),
                                                        new SqlParameter("@ENSave", info.ENSave),
                                                        new SqlParameter("@CustName", info.CustName),
                                                        new SqlParameter("@CustID", info.CustID),
                                                        new SqlParameter("@Treadment", info.Treadment),
                                                        new SqlParameter("@DrName", info.DrName),
                                                        new SqlParameter("@DrID", info.DrID),
                                                        new SqlParameter("@Mobile", info.Mobile),
                                                        new SqlParameter("@Howmagazine", info.Howmagazine),
                                                        new SqlParameter("@Howinternet", info.Howinternet),
                                                        new SqlParameter("@Howfriend", info.Howfriend),
                                                        new SqlParameter("@Hownewpaper", info.Hownewpaper),
                                                        new SqlParameter("@HowTravel", info.HowTravel),
                                                        new SqlParameter("@Howother", info.Howother),
                                                        new SqlParameter("@HowotherText", info.HowotherText),
                                                        new SqlParameter("@Note", info.Note),
                                                        new SqlParameter("@BranchID", info.BranchID),
                                                        new SqlParameter("@DateSave", info.DateSave),
                                                        new SqlParameter("@DrBookID", info.DrBookID),
                                                        new SqlParameter("@BookID", info.BookID)
                                                        
                                                        
                                                       
       
                                                    };
                // intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SurgeryFee", msSqlParameter);

                //string ss = "exec [sp_BookingRoom] @QueryType = 'INSERT' ";
                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
               // DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                }
                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.BookingRoom.SaveBookingRoom", ex);
            }
        }
        public static int SaveBookingDoctor(SqlTransaction trn, CustomEvent info)
        {
            try
            {
                var intStatus = 0;
          
                    SqlParameter[] msSqlParameter = {
                                                        new SqlParameter("@QueryType", "INSERTDOCTOR"),
                                                        new SqlParameter("@RoomID", info.RoomID),
                                                        new SqlParameter("@DateBookDoctor", info.Date),
                                                        new SqlParameter("@AppointDate", info.AppointDate),
                                                        new SqlParameter("@DateShowStart",info.DateShowStart),
                                                        new SqlParameter("@DateShowEnd", info.DateShowEnd),
                                                        new SqlParameter("@TimeStart",info.TimeStart),
                                                        new SqlParameter("@TimeEnd", info.TimeEnd),
                                                        new SqlParameter("@Duration", info.Duration),
                                                        new SqlParameter("@ENSave", info.ENSave),
                                                        new SqlParameter("@DrName", info.DrName),
                                                        new SqlParameter("@DrID", info.DrID),
                                                        new SqlParameter("@Note", info.Note),
                                                        new SqlParameter("@BranchID", info.BranchID),
                                                        new SqlParameter("@DateSave", info.DateSave),
                                                        new SqlParameter("@ID", info.ID),
                                                        new SqlParameter("@CustName", info.CustName),
                                                        new SqlParameter("@IDBookLink", info.IDBookLink),
                                                        new SqlParameter("@A", info.A),
                                                        new SqlParameter("@R", info.R),
                                                        new SqlParameter("@G", info.G),
                                                        new SqlParameter("@B", info.B),
                                                         
                                                        

       
                                                    };
                    intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.BookingRoom.SaveBookingRoom", ex);
            }
        }
        public static int SaveAutoBookingProfile(SqlTransaction trn, CustomEvent info)
        {
            try
            {
                var intStatus = 0;
          
                    SqlParameter[] msSqlParameter = {
                                                        new SqlParameter("@QueryType", "SaveAutoBookingProfile"),
                                                        new SqlParameter("@RoomID", info.RoomID),
                                                        new SqlParameter("@DateBookDoctor", info.Date),
                                                        new SqlParameter("@AppointDate", info.AppointDate),
                                                        new SqlParameter("@DateShowStart",info.DateShowStart),
                                                        new SqlParameter("@DateShowEnd", info.DateShowEnd),
                                                        new SqlParameter("@TimeStart",info.TimeStart),
                                                        new SqlParameter("@TimeEnd", info.TimeEnd),
                                                        new SqlParameter("@Duration", info.Duration),
                                                        new SqlParameter("@ENSave", info.ENSave),
                                                        new SqlParameter("@DrName", info.DrName),
                                                        new SqlParameter("@DrID", info.DrID),
                                                        new SqlParameter("@Note", info.Note),
                                                        new SqlParameter("@BranchID", info.BranchID),
                                                        new SqlParameter("@DateSave", info.DateSave),
                                                        new SqlParameter("@ID", info.ID),
                                                        new SqlParameter("@CustName", info.CustName),
                                                        new SqlParameter("@IDBookLink", info.IDBookLink),
                                                        new SqlParameter("@A", info.A),
                                                        new SqlParameter("@R", info.R),
                                                        new SqlParameter("@G", info.G),
                                                        new SqlParameter("@B", info.B),
                                                        new SqlParameter("@DayFullName", info.DayFullName),
                                                    };
                    intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.BookingRoom.SaveBookingRoom", ex);
            }
        }
        
        public static DataSet SelectDoctorSchedule(SqlTransaction trn, ItemInfo lst)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","SELECTDOCTORSCHEDULE"),
                                                new SqlParameter("@whereDate",lst.whereDate ),
                                                new SqlParameter("@DrID",lst.DrID ),
                                                new SqlParameter("@DateShowStart",lst.DateShowStart ),
                                                new SqlParameter("@DateShowEnd",lst.DateShowEnd )
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectDoctorSchedule", ex);
            }
        }

        public static DataSet GetBookingRoom(SqlTransaction trn, DateTime curentDate, string typ, string BranchId)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","SELECTBOOKINGROOM"),
                                                     new SqlParameter("@AppointDate", curentDate),
                                                     new SqlParameter("@TYP", typ),
                                                     new SqlParameter("@BranchId", BranchId)
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        public static DataSet GetBookingDoctor(SqlTransaction trn, DateTime StartDate, DateTime EndDate, string BranchId)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","SELECTBOOKINGDOCTOR"),
                                                     new SqlParameter("@DateShowStart", StartDate),
                                                     new SqlParameter("@DateShowEnd", EndDate),
                                                     new SqlParameter("@BranchId", BranchId)
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        public static DataSet PrintDoctorSign(SqlTransaction trn, DateTime StartDate, DateTime EndDate, string BranchId, string RoomID)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","PrintDoctorSign"),
                                                     new SqlParameter("@StartDate", StartDate),
                                                     new SqlParameter("@EndDate", EndDate),
                                                     new SqlParameter("@BranchId", BranchId),
                                                     new SqlParameter("@RoomID", RoomID)
                                                     
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        public static int DelBookingDoctor(SqlTransaction trn, decimal ID)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","DELETEBOOKINGDOCTOR"),
                                                     new SqlParameter("@ID", ID),
                                                     new SqlParameter("@ENSave", Userinfo.EN)
                                                     
                                                };
                int intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        public static int DelAutoBookingProfile(SqlTransaction trn, string BranchId)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","DelAutoBookingProfile"),
                                                     new SqlParameter("@BranchId", BranchId),
                                                     new SqlParameter("@ENSave", Userinfo.EN)
                                                     
                                                };
                int intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        
        public static int DelBookingDoctorMonth(SqlTransaction trn, string BranchId, DateTime startdate, DateTime enddate)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","DELETEBOOKINGDOCTOR_MONTH"),
                                                     new SqlParameter("@BranchId", BranchId),
                                                     new SqlParameter("@DateShowStart", startdate),
                                                     new SqlParameter("@DateShowEnd", enddate),
                                                     new SqlParameter("@ENSave", Userinfo.EN)
                                                     
                                                };
                int intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        public static DataSet SELECTROOMDOCTOR(SqlTransaction trn, DateTime curentDate, string typ, string BranchId)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","SELECTROOMDOCTOR"),
                                                     new SqlParameter("@AppointDate", curentDate),
                                                     new SqlParameter("@TYP", typ),
                                                     new SqlParameter("@BranchId", BranchId)
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        public static DataSet LoadAutoBookingProfile(SqlTransaction trn,string BranchId)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","LoadAutoBookingProfile"),
                                                     new SqlParameter("@BranchId", BranchId)
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        public static DataSet GetBookingDoctor(SqlTransaction trn, DateTime curentDate, string typ, string BranchId)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","SELECTBOOKINGDOCTOR"),
                                                     new SqlParameter("@AppointDate", curentDate),
                                                     new SqlParameter("@TYP", typ),
                                                     new SqlParameter("@BranchId", BranchId)
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        public static DataSet GetBookingDoctorGETMAXID(SqlTransaction trn,string BranchId)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","GETMAXID"),
                                                     new SqlParameter("@BranchId", BranchId)
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        public static DataSet GetBookingDoctorID(SqlTransaction trn, decimal BookID)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","GETDrBookID"),
                                                     new SqlParameter("@ID", BookID)
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        
        public static DataSet GetBookingRoomExport(SqlTransaction trn, string whereDate,string whereRoomTyp)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","BOOKINGROOM_EXPORT"),
                                                new SqlParameter("@whereDate",whereDate ),
                                                new SqlParameter("@whereRoomTyp",whereRoomTyp )
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.GetBookingRoomExport", ex);
            }
        }
        public static DataSet GetBookingDoctorExport(SqlTransaction trn, string whereDate, string whereRoomTyp)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","BOOKINGDOCTOR_EXPORT"),
                                                new SqlParameter("@whereDate",whereDate ),
                                                new SqlParameter("@whereRoomTyp",whereRoomTyp )
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.GetBookingRoomExport", ex);
            }
        }
        public static DataSet GetBookingRoomExport(SqlTransaction trn, string whereDate, string whereRoomTyp, string QueryType, string BranchID)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType",QueryType),
                                                new SqlParameter("@whereDate",whereDate ),
                                                new SqlParameter("@whereRoomTyp",whereRoomTyp ),
                                                new SqlParameter("@BranchID",BranchID )
                                                
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.GetBookingRoomExport", ex);
            }
        }
        public static DataSet GetBookingDoctorExport(SqlTransaction trn, string whereDate, string whereRoomTyp, string QueryType, string BranchID)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType",QueryType),
                                                new SqlParameter("@whereDate",whereDate ),
                                                new SqlParameter("@whereRoomTyp",whereRoomTyp ),
                                                new SqlParameter("@BranchID",BranchID )
                                                
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_BookingRoom", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.GetBookingRoomExport", ex);
            }
        }
    }
}
