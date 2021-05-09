namespace Repository

open FSharp.Data.Sql

module database =
    [<Literal>]
    let connection =
        "Server=localhost;Database=postgres;User=postgres;Password=postgres"

    [<Literal>]
    let vendor = Common.DatabaseProviderTypes.POSTGRESQL

    type sql = SqlDataProvider<vendor, connection>
