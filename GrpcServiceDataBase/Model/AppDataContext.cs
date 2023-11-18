using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GrpcServiceDataBase.Model.DAL.Entities;
using System.Numerics;
using System.Xml.Linq;


namespace GrpcServiceDataBase.Model
{
    public class AppDataContext : DbContext
    {
        public virtual DbSet<ClientInfo> ClientInfo => Set<ClientInfo>();
        public virtual DbSet<ClientBankAccount> ClientBankAccounts => Set<ClientBankAccount>();


        public AppDataContext(DbContextOptions<AppDataContext> options): base(options) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClientBankAccount>(entity =>{
                //1-Many
                entity.HasOne(t => t.ClientInfo)
                .WithMany(d=>d.ClientBankAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ClientId");
            });

            modelBuilder.Entity<ClientInfo>().HasData(new ClientInfo
            {
                Id = 1,
                Phone = "89969520206",
                Password = "12345",
                Name = "Тест",
                FirstName = "Тестов",
                LastName = "Тестович"
            });


            modelBuilder.Entity<ClientBankAccount>().HasData(new ClientBankAccount[]
            {
               new ClientBankAccount() {Id = 1, Account = "Срочный",Number = "42305840513000000112", ClientInfo = new ClientInfo{ Id=1} },
               new ClientBankAccount() {Id = 2, Account = "До востреббования",Number = "42301810413002008000", ClientInfo = new ClientInfo{ Id=1} },
               new ClientBankAccount() {Id = 3, Account = "Карточный",Number = "40817810310009035474", ClientInfo = new ClientInfo{ Id=1}}
            });

            base.OnModelCreating(modelBuilder);

        }

    }


}
