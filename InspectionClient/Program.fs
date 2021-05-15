open System
open Grpc.Net.Client
open ProtoBuffers
open System.Net.Http

[<EntryPoint>]
let main argv =
    let httpHandler = new HttpClientHandler()

    httpHandler.ServerCertificateCustomValidationCallback <-
        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator

    let options = new GrpcChannelOptions()
    options.HttpHandler <- httpHandler

    let channel =
        GrpcChannel.ForAddress("https://localhost:5001", options)

    let client = new Inspector.InspectorClient(channel)

    let inspection =
        new InspectionRequest(
            Retailer = "Le Biscuit",
            SnowRate = InspectionRequest.Types.Rate.Bad,
            RooftopRate = InspectionRequest.Types.Rate.Average,
            LightingRate = InspectionRequest.Types.Rate.Good
        )

    let reply = client.SaveInspection(inspection)

    printfn "%s" reply.Message
    0
