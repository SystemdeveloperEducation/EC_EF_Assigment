// using System.Data.Odbc;
using System.Data.Odbc;
using EF_CodeFirstApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirstApp.Context;

internal class DataContext : DbContext
{
    #region constructor overrrides
    public DataContext()
    {

    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=localhost;Database=AndresTestDB;Uid=sa;Pwd=Miyamoto81;TrustServerCertificate=yes;";
        // string connectionString = "Driver={ODBC Driver 18 for SQL Server};Server=localhost;Database=AndresTestDB;Uid=sa;Pwd=Miyamoto81;TrustServerCertificate=yes;";
        // OdbcConnection connection = new OdbcConnection(connectionString);
        // optionsBuilder.UseSqlServer(connection, options => options.EnableRetryOnFailure());
        optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
    }

    #endregion

    public DbSet<IssuersEntity> Issuers { get; set; } = null!;
    public DbSet<RoleEntity> Roles { get; set; } = null!;
    public DbSet<IssueEntity> Issues { get; set; } = null!;
}
