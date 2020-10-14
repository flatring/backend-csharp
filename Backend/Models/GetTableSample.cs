using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Protobuf;

namespace Backend.Models
{
  public class GetTableSample
  {
    public int Status { get; }
    public TableSample Present { get; }

    public GetTableSample(KeysRequest request)
    {
      Status = -1;
      Present = null;

      ver (acceptStatus, accptResult) = this.accept(request);
      if (acceptStatus < 0)
      {
        Status = acceptStatus;
        return;
      }

      ver (presentStatus, presentResult) = this.present(accptResult);
      if (presentResult < 0)
      {
        Status = presentResult;
        return;
      }

      Status = presentStatus;
      Present = presentResult;
    }

    private (int, Entities.TableSample) accept(KeysRequest request)
    {
      Console.WriteLine($"request.id = {request.id}");
      var sql = $@"
      select
        id,
        code,
        name,
        created_at,
      from
        table_samples
      where
        id = @requestId
      ;
      ";
      Console.WriteLine($"query = {sql}");
      Console.WriteLine($"query = {Regex.Replace(sql, "^    ", String.Empty)}");

      try
      {
        Entities.TableSample row;
        using (SqlConnection conn = new SqlConnection())
        {
          conn.ConnectionString = DbConnection.connectionString;
          conn.Open();
          Console.WriteLine($"db.State = {conn.State}");
          row = conn.QuerySingleOrDefault<Entities.TableSample>(sql, new { requestId = request.Id });
        }
        Console.WriteLine($"row.id = {row.Id}");
        Console.WriteLine($"row.code = {row.Code}");
        Console.WriteLine($"row.name = {row.Name}");
        return (1, row);
      }
      catch
      {
        return (-1, null);
      }
    }
  }
}
