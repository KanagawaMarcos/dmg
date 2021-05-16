module InspectionModel

open System.ComponentModel.DataAnnotations
open Microsoft.EntityFrameworkCore

[<CLIMutable>]
type inspections =
    { [<Key>]
      retail: string
      snow_rate: int
      lighting_rate: int
      rooftop_rate: int }

type InspectionsContext() =
    inherit DbContext()

    [<DefaultValue>]
    val mutable inspections: DbSet<inspections>

    member this.Inspections
        with get () = this.inspections
        and set v = this.inspections <- v

    override __.OnConfiguring(options: DbContextOptionsBuilder) : unit =
        options.UseNpgsql("Host=localhost;Database=dmg;Username=dmg;Password=dmg")
        |> ignore
