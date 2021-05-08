namespace Biblioteca

open Newtonsoft.Json

module Library =
    let getJsonNetJson value =
        let json = JsonConvert.SerializeObject(value)
        $"I used to be {value} but now I'm {json} thanks to JSON.NET!"
