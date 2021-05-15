namespace Repository

open FSharp.Data.Npgsql

type InspectionDTO = {
    retail: string
    lighting_rate: int
    snow_rate: int
    rooftop_rate: int
}

module Database =
    
    [<Literal>]
    let connection =
        "Host=localhost;Database=dmg;Username=dmg;Password=dmg"

    type Postgres = NpgsqlConnection<connection>
    let convertToDto retailer snow lighting rooftop = 
        {
            retail=retailer
            snow_rate=snow
            lighting_rate=lighting
            rooftop_rate=rooftop
        }

    let saveInspection inspection = 
        use cmd = Postgres.CreateCommand<"
            INSERT INTO inspections 
                (retail, lighting_rate, snow_rate, rooftop_rate)
            VALUES
                (@retail, @lighting_rate,@snow_rate,@rooftop_rate)">(connection)
        cmd.Execute(retail=inspection.retail, lighting_rate=inspection.lighting_rate, snow_rate=inspection.snow_rate ,rooftop_rate=inspection.rooftop_rate)

