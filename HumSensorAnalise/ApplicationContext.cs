using Npgsql;
using Microsoft.EntityFrameworkCore;
using HumSensorAnalise.Models;

namespace HumSensorAnalise
{
    public class ApplicationContext:DbContext
    {
        public DbSet<HumSensor> humSensor { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();//настройка ключей 
            //нужно проверить создана или нет, и если не создано, то настроить на низком уровне сделать запрос по созданию

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<HumSensor>()
        //        .HasKey(b => b.id);
        //}
        // public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgresssss;Username=postgres;Password=root");
            
        }
        //NpgsqlConnection connect = new NpgsqlConnection(CONNECTION_STRING); // оставить ли его в шапке?

        //private const string CONNECTION_STRING = "Host=localhost:5432;" +
        //   "Username=postgres;" +
        //   "Password=root;" +
        //   "Database=postgres";


    }


}
