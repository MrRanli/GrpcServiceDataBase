using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GrpcServiceDataBase.Model.DAL.Entities;


namespace GrpcServiceDataBase.Model
{
    public class AppDataContext : DbContext
    {
        public virtual DbSet<ClientInfo> ClientInfo => Set<ClientInfo>();
        public virtual DbSet<ClientBankAccounts> UserAuthentiClientBankAccountscationInfo => Set<ClientBankAccounts>();


        public AppDataContext(DbContextOptions<AppDataContext> options): base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Driver>
        //}   

    }


}
