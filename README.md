# Grpc C# Test Drive

This is a simple project to test gRPC in C# and to use as a reference setup for future gRPC-based projects.

## Organisation

It contains the following 3 projects:
- `Client`: client app
- `Server`: server app that implements the service
- `Common`: contains the service `.proto` files references to `Grpc`, `Grpc.Tools` and `Google.Protobuf`. The base service code will be generated in this project. This is a class library that's used by the other two projects.

## Building

Building the `GrpcTestDrive.sln` solution will generate the service grpc code and compile the apps.

```
dotnet build GrpcTestDrive.sln
```

## Running

Run the server (make sure port `50051` is free):
```
dotnet run -p Server
```

In a different termina window, run the client:
```
dotnet run -p Client
```