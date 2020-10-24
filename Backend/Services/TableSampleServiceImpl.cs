using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Protobuf;

namespace Backend
{
  public class TableSampleServiceImpl : TableSampleService.TableSampleServiceBase
  {
    private readonly ILogger<TableSampleServiceImpl> _logger;

    public TableSampleServiceImpl(ILogger<TableSampleServiceImpl> logger)
    {
      _logger = logger;
    }

    // public override Task<TableSamples> GetAllTableSamples(FiltersRequest requestData, ServerCallContext context)
    // {
    //   var responseData = new TableSamples();
    // }

    public override Task<TableSample> GetTableSample(KeysRequest request, ServerCallContext context)
    {
      var tableSample = new Models.GetTableSample(request);
      if (tableSample.Status <= 0)
      {
        return null;
      }
      return Task.FromResult(tableSample.Present);
    }
  }
}
