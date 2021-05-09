namespace Repository

open FSharp.Data.Sql

module database =
    [<Literal>]
    let connection =
        "Host=localhost;Database=dmg;Username=dmg;Password=dmg"

    [<Literal>]
    let vendor = Common.DatabaseProviderTypes.POSTGRESQL

    type sql = SqlDataProvider<vendor, connection>
