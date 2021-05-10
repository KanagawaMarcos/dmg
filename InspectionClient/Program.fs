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

    let client = new InspectionService.InspectionServiceClient(channel)
    let inspection = new Inspection(Retailer="Le Biscuit", LightingRate=1,SnowRate=1,RooftopRate=1)
    let reply = client.Inspect(inspection)
    
    printfn "%s" reply.Message
    0