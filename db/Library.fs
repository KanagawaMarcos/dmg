namespace Repository

open FSharp.Data.Npgsql

type InspectionDTO = {
    retail: string
    lighting_rate: int
    snow_rate: int
    rooftop_rate: int
}

module database =
    
    [<Literal>]
    let connection =
        "Host=localhost;Database=dmg;Username=dmg;Password=dmg"

    
    type postgres = NpgsqlConnection<connection>

    use cmd = postgres.CreateCommand<"SELECT * FROM inspections">(postgres)

    let getInspections = 
        
        for inspection in cmd.Execute() do
            inspection.
