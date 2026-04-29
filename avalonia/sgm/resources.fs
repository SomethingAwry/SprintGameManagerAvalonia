module sgm.resources

// import sys
open sys
// from pathlib import Path
open pathlib
open System.IO


// def _bundle_base_dir() -> Path:
let _bundle_base_dir () =
//     # PyInstaller: files are unpacked to sys._MEIPASS.
//     if getattr(sys, "frozen", False) and hasattr(sys, "_MEIPASS"):
    if sys.frozen = false && sys._MEIPASS <> "" then
//         return Path(getattr(sys, "_MEIPASS"))
        exit(1)
//
    else
//     # Source checkout: `src/sgm/resources.py` -> repo root is parents[2].
//     return Path(__file__).resolve().parents[2]
    __SOURCE_DIRECTORY__ |> DirectoryInfo |> _.Parent.Parent


// def resources_dir() -> Path:
let resources_dir () =
//     # Prefer a `resources/` folder next to where the app is being run from.
//     cwd = Path.cwd() / "resources"
    let cwd = CWD() / "resources"
//     if cwd.exists():
    if cwd.Exists then
//         return cwd
        cwd
//
    else
//     return _bundle_base_dir() / "resources"
        (_bundle_base_dir ()) / "resources"


// def resource_path(*parts: str) -> Path:
let resource_path parts =
//     return resources_dir().joinpath(*parts)
    (resources_dir ()).PredictDeep parts

let resource_subpath part =
    resource_path [| part |]