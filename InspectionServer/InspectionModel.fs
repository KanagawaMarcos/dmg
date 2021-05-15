module InspectionModel

open System.ComponentModel.DataAnnotations
open Microsoft.EntityFrameworkCore

type Inspections = {
    Retail: string
    SnowRate: int
    LightingRate: int
    RooftopRate: int
}

type InspectionsContext() =  
    inherit DbContext()
    
    [<DefaultValue>] val mutable inspections : DbSet<Inspections>
    member this.Inspections with get() = this.inspections and set v = this.inspections <- v

    override __.OnConfiguring(options: DbContextOptionsBuilder) : unit =
        //options.UseNpgsql(Configuration.GetConnectionString) |> ignore
        options.UseNpgsql("Host=localhost;Database=dmg;Username=dmg;Password=dmg") |> ignore