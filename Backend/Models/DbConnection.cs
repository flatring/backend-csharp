using Dapper;
using System;
using System.Text.RegularExpressions;

namespace Backend.Models
{
  public class DbConnection
  {
    // public static string connectionString =
    //   @"Data Source=localhost\tablespace_sample;"
    //   +"Initial Catalog=base;"
    //   +"User Id=admin;"
    //   +"Password=adminsample;";
    public static string connectionString =
      @"Server=localhost;"
      +"Port=5432;"
      +"Database=sampledb;"
      +"User ID=postgres;"
      +"Password=password0123password;"
      +"Enlist=true;";

    public static string TrimSql(string sql, int spaceLength)
    {
      return Regex.Replace(sql, $"\n {{{spaceLength}}}", "\n");
    }
  }
}
