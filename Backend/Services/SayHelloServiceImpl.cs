using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Protobuf;

namespace Backend
{
  public class SayHelloServiceImpl : SayHelloService.SayHelloServiceBase
  {
    private readonly ILogger<SayHelloServiceImpl> _logger;

    public SayHelloServiceImpl(ILogger<SayHelloServiceImpl> logger)
    {
      _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
      return Task.FromResult(new HelloReply
      {
        Message = "Hello " + request.Name
      });
    }
  }
}
