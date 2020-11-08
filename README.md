# backend-csharp
1. For grpc-based templates.

## Prerequisites - 前提条件
1. OS: Windows 10 pro
1. Lang: C#
1. Framework: .Net Core 3.1
    1. Download - <https://dotnet.microsoft.com/download/dotnet-core/>
1. Docker - [docker-compose.yml](docker-compose.yml)
    1. DB: PostgresSQL
    1. Viewer: adminer
1. csharp project NuGet
    1. See "*.csproj" for the version.
    1. [Backend.csproj](Backend/Backend.csproj)
        1. Google.Protobuf
        1. Related to gRPC
        1. Dapper
        1. Npgsql
    1. [ClientStub.csproj](ClientStub/ClientStub.csproj)

### Tested environment - 動作確認した環境
1. Last check: 2020-10-22
1. tools
    1. VSCode: v1.50.1
        1. extend
            1. Microsoft
                1. Docker: v1.7.0
                1. C#: v1.23.3
            1. Other
                1. vscode-proto3: v0.5.2

## Operation Procedure - 動作手順
### preparation - 準備
1. git clone
    ```powershell
    git clone https://github.com/flatring/backend-csharp.git
    cd backend-csharp
    ```
1. docker run
    ```posershell
    docker-compose up -d
    ```
1. insert data > Adminer
    1. brower
        `localhost:8080`
    1. Adminer login
        1. See [docker-compose.yml](docker-compose.yml)
    1. execute sql
        1. sql command
            1. `docker\db\init\table_samples.sql`

### :one: - server
1. power shell 起動
    ```powershell
    cd backend-csharp/Backend
    dotnet run
    ```

### :two: - client
1. power shell 起動
    ```powershell
    cd backend-csharp/ClientStub
    dotnet run
    ```

## Add in the following tutorials
1. [チュートリアル: ASP.NET Core で gRPC のクライアントとサーバーを作成する](https://docs.microsoft.com/ja-jp/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-3.1&tabs=visual-studio-code)
1. [Dapper Tutorial](https://dapper-tutorial.net/dapper)
