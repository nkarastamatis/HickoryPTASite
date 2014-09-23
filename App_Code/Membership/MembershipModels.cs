using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace HickoryPTASite
{
    /// <summary>
    /// Summary description for MembershipModels
    /// </summary>
    public class Membership
    {
        public string MembershipId { get; set; }
        public ICollection<Member> Members { get; set; }
        public ICollection<Student> Students { get; set; }
        public Address Address { get; set; }

        public Membership()
        {
            MembershipId = Guid.NewGuid().ToString();
            Members = new List<Member>();
            Students = new List<Student>();
            Address = new Address();
        }
    }

    public class Memberships : DbContext
    {
        public Memberships()
            : base("DefaultConnection")
        { 
        }

        public DbSet<Membership> MembershipRecords { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}