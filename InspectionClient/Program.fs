open System
open Grpc.Net.Client
open ProtoBuffers
open System.Net.Http

[<EntryPoint>]
let main argv =
    let httpHandler = new HttpClientHandler()
    httpHandler.ServerCertificateCustomValidationCallback <- 
        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
    let options = new GrpcChannelOptions()
    options.HttpHandler <- httpHandler
    let channel = GrpcChannel.ForAddress("https://localhost:5001", options)
    let client = new Greeter.GreeterClient(channel)
    let request = new HelloRequest(Name="Marcos")
    let reply = client.SayHello(request)
    
    printfn "Hello world %s" reply.Message
    0