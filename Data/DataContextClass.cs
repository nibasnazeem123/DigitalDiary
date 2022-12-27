
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalDiary.Models;

namespace DigitalDiary.Data
{
    public class DataContextClass : DbContext
    {
        public DataContextClass(DbContextOptions<DataContextClass> options) : base(options)
        {



        }
        public DbSet<Registration> tblregistration { get; set; }
    }
}
