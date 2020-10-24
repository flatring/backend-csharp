using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
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

      var (acceptStatus, accptResult) = this.accept(request);
      if (acceptStatus <= 0)
      {
        Status = acceptStatus;
        return;
      }

      var (presentStatus, presentResult) = this.present(accptResult);
      if (presentStatus < 0)
      {
        Status = presentStatus;
        return;
      }

      Status = presentStatus;
      Present = presentResult;
    }

    private (int, Entities.TableSample) accept(KeysRequest request)
    {
      // Console.WriteLine($"request.id = {request.Id}");
      var sql = $@"
      select
        id,
        code,
        name,
        created_at
      from
        table_samples
      where
        id = @requestId
      ;
      ";
      // Console.WriteLine($"query = {DbConnection.TrimSql(sql, 6)}");

      try
      {
        Entities.TableSample row;
        // using (SqlConnection conn = new SqlConnection())
        using (NpgsqlConnection conn = new NpgsqlConnection(DbConnection.connectionString))
        {
          // conn.ConnectionString = DbConnection.connectionString;
          conn.Open();
          Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
          // Console.WriteLine($"db.State = {conn.State}");
          // var tests = conn.QuerySingleOrDefault<Entities.Tests>("select * from tests where id = @requestId", new { requestId = 1 });
          // Console.WriteLine($"tests.name = {tests.Name}");
          row = conn.QuerySingleOrDefault<Entities.TableSample>(DbConnection.TrimSql(sql, 6), new { requestId = request.Id });
          Console.WriteLine(row);
          if (row == null)
          {
            Console.WriteLine("result 0.");
            return (0, null);
          }
          else
          {
            Console.WriteLine($"row.id = {row.Id}");
            Console.WriteLine($"row.code = {row.Code}");
            Console.WriteLine($"row.name = {row.Name}");
            return (1, row);
          }
        }
      }
      catch
      {
        return (-1, null);
      }
    }

    private (int, Protobuf.TableSample) present(Entities.TableSample queryResult)
    {
      var row = new TableSample();
      try
      {
        row.Id = queryResult.Id;
        row.Code = queryResult.Code;
        row.Name = queryResult.Name;
      }
      catch
      {
        return (-1, null);
      }
      return (1, row);
    }
  }
}
