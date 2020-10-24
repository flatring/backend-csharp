using System;
using System.Net.Http;
using System.Threading.Tasks;
using Protobuf;
using Grpc.Core;
using Grpc.Net.Client;

namespace ClientStub
{
  class Program
  {
    static async Task Main(string[] args)
    {
      // The port number(5001) must match the port of the gRPC server.
      using var channel = GrpcChannel.ForAddress("https://localhost:5001");
      using (Task<string> task = TestSayHello(channel))
      {
        Console.WriteLine(task.Result);
      }
      using (Task<string> task = TestGetTableSample(channel, 2))
      {
        Console.WriteLine(task.Result);
      }
      using (Task<string> task = TestGetTableSample(channel, 3))
      {
        Console.WriteLine(task.Result);
      }
      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
    }

    static async Task<string> TestSayHello(GrpcChannel channel)
    {
      var client = new SayHelloService.SayHelloServiceClient(channel);
      try
      {
        var reply = await client.SayHelloAsync(
          new HelloRequest { Name = "Hello!" });
        return $"reply.Message = {reply.Message}";
      }
      catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded)
      {
        return "SayHello timeout.";
      }
      catch
      {
        return "SayHello faild.";
      }
    }

    static async Task<string> TestGetTableSample(GrpcChannel channel, int id)
    {
      var client = new TableSampleService.TableSampleServiceClient(channel);
      try
      {
        TableSample res =
          await client.GetTableSampleAsync(
          new KeysRequest { Id = id });
        if (res == null)
        {
          return "result 0.";
        }
        else
        {
          return
            @$"TableSample\n"
            +$"  .code = {res.Code}\n"
            +$"  .name = {res.Name}";
        }
      }
      catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded)
      {
        return "GetTableSample timeout.";
      }
      catch
      {
        return "GetTableSample faild.";
      }
    }
  }
}
