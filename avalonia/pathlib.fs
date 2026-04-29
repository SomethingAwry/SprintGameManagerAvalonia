module pathlib

open System.IO

let CWD () =
    System.Environment.CurrentDirectory |> DirectoryInfo
   
type DirectoryInfo with
    member di.PredictDeep ([<System.ParamArray>] paths: string array) =
        Path.Combine [| di.FullName; yield! paths |]
        |> DirectoryInfo
    member di.Predict path =
        Path.Combine [| di.FullName; path |]
        |> DirectoryInfo

// cannot put custom operator on type extension above, so it's here in this module   
let (/) (di: DirectoryInfo) path =
    di.Predict path