using DataAccessLayer.entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public class BookingRepository:IBookingRepository
    {
        string connectionString = string.Empty;// "server=DESKTOP-BLBGEHJ\\SQLEXPRESS;database=BusTicket;user Id =sa;password=Anaiyaan@123;";
        SqlConnection con = null;
        public BookingRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Dbconnection");
            con = new SqlConnection(connectionString);
        }



        public List<TicketBooking> SelectALLUser()
        {

            try
            {
                var selectQuery = $"exec ListBookTicket_sp";
                con.Open();
                List<TicketBooking> result = con.Query<TicketBooking>(selectQuery).ToList();
                con.Close();

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public TicketBooking SelectUserByUsername(string Busname)
        {
            try
            {
                var selectQuery = $"exec SelectByName '{Busname}'";
                con.Open();
                TicketBooking result = con.QueryFirstOrDefault<TicketBooking>(selectQuery);
                con.Close();

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Registeruser(TicketBooking userRegData)
        {
            try
            {
                var insertQuery = $"exec InsertBookTicket_sp '{userRegData.Busname}','{userRegData.Startingpoint}','{userRegData.Droppingpoint}',{userRegData.Amount},{userRegData.NoOfpeople},'{userRegData.JourneyDate}',{userRegData.ContactNo}";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                con.Execute(insertQuery);
                con.Close();



            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void UpdateUser(TicketBooking reg)
        {
            try
            {
                var updateQuery = $"exec UpdateBookTicket_sp  {reg.TicketID},'{reg.Busname}','{reg.Startingpoint}','{reg.Droppingpoint}',{reg.Amount},{reg.NoOfpeople},'{reg.JourneyDate}',{reg.ContactNo}";
                con.Open();
                con.Execute(updateQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteUser(long TicketId)
        {
            try
            {
                var deleteQuery = $"exec DeleteBookTicket_sp {TicketId}";
                con.Open();
                con.Execute(deleteQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }

}
