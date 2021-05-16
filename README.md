# Division Maintenance Group

DMG Divisions provides a platform to help retailers thrive.
One of the services provides is **inspections**. 

This project is a study case to gRPC + F#, the scenario is, an inspector goes to a retailer and give 3 rates for lighting, snow removal and rooftop maintenance. Those rates range from, BAD, AVERAGE, GOOD.

## Stack
- F#
    - Type Providers
    - Entity Framework
    - Fantomas
- gRPC
- Postgres
- Docker

Originally I was planing to add kafka to the study case but hit the time budget I've set for this project.

## How to run 

From the root of the project
1. `docker-compose up -d database`
2. [Follow the instructions on the CI Workflow](https://github.com/Marcos-Costa/dmg/blob/main/.github/workflows/dotnet.yml)

## Project's Retrospective/Postmortem

### What went well
    - Learned about gRPCs and how to build them
    - Learned about docs limitations of type providers.
    - Practiced Github Actions.
    - Practiced Docker.
    - Learned from real problem how Paket is superior to dotnet raw nuget management.
    - Most of the time was spent on bootstrapping stuff. Thus, last time spent on bootstrap work projects.
    - Learn about .NET gRPCs and their limitations like you need a C# project to consume the proto buffers from it.
    - Find out about VSCode Ionide limitation on C#/F# project interop solution.
    - Practiced type providers
### What went wrong
    - Most consuming problems were silly problems such as
        - After deleting the old C# gRPC project and creating a new one, I forgot to add the .csproject to the solution, thus, the service wasn't being compiled and matching the proto buffer from the client.
        - Spend too much time figuring out how to manage the DLLs when I had paket to do it as modern package managers do such as pip, npm, etc.
    - Didn't have time to add Kafka to the project.
    - Most of the time was spent on bootstrapping stuff. Thus, last time on business logic.
    - Time budget spent before properly handling security like Postgres credentials. Next project gotta do this from day 0.
    - Didn't have time to introduce Computations Expressions at some point. (too much simple of project, didn't need anything fancy tbh)
    - Could have added testing to the project, even that fancy lib of algebraic auto-generated tests. (looks promising for the next weekend study case)
    - Could have improved the project to use fake instead of having a bunch of steps to run.
### Where I got lucky
    - Paket solved all my DLL hell issues.
    - Docs on Entity Framework Core for FSharp, although small, are very precise.
    - gRPC docs on .NET C# still updated.

