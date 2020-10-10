using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Protobuf;

namespace Backend
{
  public class TableSample : Protobuf.TableSample.TableSampleBase
  {
    private readonly ILogger<Protobuf.TableSample> _logger;

    // public override Task<TableSamples> GetAllTableSamples(FiltersRequest requestData, ServerCallContext context)
    // {
    //   var responseData = new TableSamples();
    // }

    public override Task<TableSample> GetTableSample(KeysRequest requestData, ServerCallContext context)
    {
      var tableSample = new Models.GetTableSample(request);
      if (tableSample < 0)
      {
        return null;
      }
      return Task.FromResult(tableSample.Present);
    }
  }
}
