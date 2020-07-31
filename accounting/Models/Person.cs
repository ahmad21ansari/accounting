using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace accounting.Models
{
    public class Person
    {

        public Person()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Product> products { get; set; }
        public List<CashPayment> Payments { get; set; }
       public List<IsPerson> IsPeople { get; set; }


    }

    public class Product
    {

        


        public int ID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        
        public Person Person { get; set; }
        public List<IsPerson> IsPerson { get; set; }


    }
    public class CashPayment
    {
        public int ID { get; set; }
        public double Pay { get; set; }
        public int PersonID { get; set; }
        public DateTime Date { get; set; }
        public Person person { get; set; }


    }
    public class IsPerson
    {
        public int ID { get; set; }
        public int IDperson { get; set; }
        
        public int IDproduct { get; set; }

        public Person Person { get; set; }
        public Product Product { get; set; }
    }
    public class AccountDBContex : IdentityDbContext
    {
        public AccountDBContex(DbContextOptions<AccountDBContex> option) : base(option)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CashPayment> CashPayments { get; set; }
        public DbSet<IsPerson> IsPeople { get; set; }
    }
}

