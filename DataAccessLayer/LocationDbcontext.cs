using DataAccessLayer.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LocationDbcontext:DbContext
    {
        public LocationDbcontext(DbContextOptions options) :base(options)
        {

        }

        public DbSet<Location> location{get;set;}
    }
}
