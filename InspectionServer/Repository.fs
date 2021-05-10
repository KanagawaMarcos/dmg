﻿namespace Repository

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

    

    type Postgres = NpgsqlConnection<connection>

    let saveInspection inspection = 
        use cmd = Postgres.CreateCommand<"
            INSERT INTO inspections 
                (retail, lighting_rate, snow_rate, rooftop_rate)
            VALUES
                (@retail, @lighting_rate,@snow_rate,@rooftop_rate)">(connection)
        cmd.Execute(retail=inspection, lighting_rate= 1, snow_rate=2 ,rooftop_rate=3)
