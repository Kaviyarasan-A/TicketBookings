using DataAccessLayer.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LocationRepository : ILocationRepository
    {
        LocationDbcontext Dbcontext = null;
        public LocationRepository(LocationDbcontext context)
        {
            Dbcontext = context;
        }
        public void InsertLocation(Location loc)
        {
            try
            {
                Dbcontext.Add(loc);
                Dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Location GetLocationByName(string name)
        {
            try
            {
                return Dbcontext.location.FirstOrDefault(X => X.Name == name);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<Location> GetAllLocation()
        {
            try
            {
                return Dbcontext.location.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void UpdateLocation(Location loc)
        {
            try
            {
                Dbcontext.Update(loc);
                Dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteLocation(long loc)
        {
            try
            {
                var count = Dbcontext.location.Find(loc);
                Dbcontext.Remove(count);
                Dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
