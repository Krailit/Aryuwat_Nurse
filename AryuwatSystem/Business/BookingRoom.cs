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

namespace AryuwatSystem.Business
{
    public class BookingRoom
    {
        public DataSet DUP_BOOKINGROOM(string whereDate)
        {
            DataSet set2;
            SqlConnection connection = new SqlConnection(DataObject.ConnectionString);
            connection.Open();
            SqlTransaction trn = connection.BeginTransaction();
            try
            {
                DataSet set =Data.BookingRoom.DUP_BOOKINGROOM(trn, whereDate);
                trn.Commit();
                connection.Close();
                set2 = set;
            }
            catch (AppException)
            {
                set2 = null;
            }
            catch (Exception exception)
            {
                throw new AppException("An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", exception);
            }
            return set2;
        }

        public DataSet DUP_BOOKINGDOCTOR(CustomEvent book)
        {
            DataSet set2;
            SqlConnection connection = new SqlConnection(DataObject.ConnectionString);
            connection.Open();
            SqlTransaction trn = connection.BeginTransaction();
            try
            {
                DataSet set = Data.BookingRoom.DUP_BOOKINGDOCTOR(trn, book);
                trn.Commit();
                connection.Close();
                set2 = set;
            }
            catch (AppException)
            {
                set2 = null;
            }
            catch (Exception exception)
            {
                throw new AppException("An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", exception);
            }
            return set2;
        }

        public DataSet SelectRoom(string typ)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.BookingRoom.SelectRoom(trn,typ);
                
                trn.Commit();
                conn.Close();
                return ds;
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException(
                    "An error occurred while executing the Bussiness.SelectSumOfTreatment", ex);
            }
        }

    public int? SaveBookingRoom(List<ItemInfo> lst,List<ItemInfo> RoomDelete)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                int ds = Data.BookingRoom.SaveBookingRoom(trn, lst, RoomDelete);

                trn.Commit();
                conn.Close();
                var intReturnData = 1;// 
                //if (intReturnData == -1)
                //{
                //   // trn.Rollback();
                //    conn.Close();
                //    return intReturnData;
                //}
                //trn.Commit();
                //conn.Close();
                return intReturnData;
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.BookingRoom.SaveBookingRoom", ex);
            }
        }

    public int? SaveBookingDoctor(CustomEvent book)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            int ds = Data.BookingRoom.SaveBookingDoctor(trn,book);

            trn.Commit();
            conn.Close();
            var intReturnData = 1;// 
            return intReturnData;
        }
        catch (AppException)
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new AppException("An error occurred while executing the Bussiness.BookingRoom.SaveBookingRoom", ex);
        }
    }
    public int? SaveAutoBookingProfile(CustomEvent book)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            int ds = Data.BookingRoom.SaveAutoBookingProfile(trn, book);

            trn.Commit();
            conn.Close();
            var intReturnData = 1;// 
            return intReturnData;
        }
        catch (AppException)
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new AppException("An error occurred while executing the Bussiness.BookingRoom.SaveBookingRoom", ex);
        }
    }
    public DataSet GetBookingDoctorGETMAXID(string BranchId)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.BookingRoom.GetBookingDoctorGETMAXID(trn,BranchId);

                trn.Commit();
                conn.Close();
                return ds;
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException(
                    "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
            }
        }
    public DataSet GetBookingDoctorID(decimal BookID)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.BookingRoom.GetBookingDoctorID(trn, BookID);

                trn.Commit();
                conn.Close();
                return ds;
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException(
                    "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
            }
        }
        
    public DataSet GetBookingRoom(DateTime curentDate, string typ, string BranchId)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            DataSet ds = Data.BookingRoom.GetBookingRoom(trn, curentDate, typ, BranchId);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
        }
    }
    public DataSet GetBookingDoctor(DateTime startdate, DateTime enddate, string BranchId)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            DataSet ds = Data.BookingRoom.GetBookingDoctor(trn, startdate, enddate, BranchId);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
        }
    }
    public DataSet PrintDoctorSign(DateTime startdate, DateTime enddate, string BranchId, string RoomID)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            DataSet ds = Data.BookingRoom.PrintDoctorSign(trn, startdate, enddate, BranchId, RoomID);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
        }
    }
        
    public int DelBookingDoctor(decimal ID)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            int ds = Data.BookingRoom.DelBookingDoctor(trn, ID);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return -1;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
        }
    }
    public int DelAutoBookingProfile(string BranchId)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            int ds = Data.BookingRoom.DelAutoBookingProfile(trn, BranchId);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return -1;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
        }
    }
    public int DelBookingDoctorMonth(string BranchId, DateTime startdate, DateTime enddate)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            int ds = Data.BookingRoom.DelBookingDoctorMonth(trn, BranchId, startdate, enddate);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return -1;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
        }
    }
    public DataSet SELECTROOMDOCTOR(DateTime curentDate, string typ, string BranchId)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            DataSet ds = Data.BookingRoom.SELECTROOMDOCTOR(trn, curentDate, typ, BranchId);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
        }
    }
    public DataSet LoadAutoBookingProfile(string BranchId)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            DataSet ds = Data.BookingRoom.LoadAutoBookingProfile(trn,BranchId);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
        }
    }
        
    public DataSet GetBookingRoomExport(string whereDate, string whereRoomTyp)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            DataSet ds = Data.BookingRoom.GetBookingRoomExport(trn, whereDate, whereRoomTyp);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
        }
    }
    public DataSet GetBookingDoctorExport(string whereDate, string whereRoomTyp)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            DataSet ds = Data.BookingRoom.GetBookingDoctorExport(trn, whereDate, whereRoomTyp);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
        }
    }
    public DataSet GetBookingRoomExport(string whereDate, string whereRoomTyp, string QueryType, string BranchID)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            DataSet ds = Data.BookingRoom.GetBookingRoomExport(trn, whereDate, whereRoomTyp, QueryType, BranchID);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
        }
    }
    public DataSet GetBookingDoctorExport(string whereDate, string whereRoomTyp, string QueryType, string BranchID)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            DataSet ds = Data.BookingRoom.GetBookingRoomExport(trn, whereDate, whereRoomTyp, QueryType, BranchID);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.BookingRoom.GetBookingRoom", ex);
        }
    }
    public DataSet SelectDoctorSchedule(ItemInfo list)
    {
        var conn = new SqlConnection(DataObject.ConnectionString);
        conn.Open();
        var trn = conn.BeginTransaction();
        try
        {
            DataSet ds = Data.BookingRoom.SelectDoctorSchedule(trn, list);

            trn.Commit();
            conn.Close();
            return ds;
        }
        catch (AppException)
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new AppException(
                "An error occurred while executing the Bussiness.SelectSumOfTreatment", ex);
        }
    }

    }
}
