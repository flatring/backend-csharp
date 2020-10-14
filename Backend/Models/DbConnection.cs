using Dapper;
using System;
using System.Data.SqlClient;

namespace Backend.Models
{
  public class DbConnection
  {
    public static string connectionString =
      @"Data Source=localhost\tablespace_sample;"
      +"Initial Catalog=base;"
      +"User Id=admin;"
      +"Password=adminsample;";
  }
}
