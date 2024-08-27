using DataAccessLayer.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
  public  interface IBookingRepository
    {
        public List<TicketBooking> SelectALLUser();

        public TicketBooking SelectUserByUsername(string Busname);
        public void Registeruser(TicketBooking userRegData);
        public void UpdateUser(TicketBooking reg);
        public void DeleteUser(long TicketId);
    }
}
