module App

open Elmish
open Fable.React
open Fulma

type Model = int

type Msg =
| Increment
| Decrement

let init () : Model * Cmd<Msg> =
    42, Cmd.none

let update (msg : Msg) (currentModel : Model) : Model * Cmd<Msg> =
    match msg with
    | Increment ->
        let nextModel = currentModel + 1
        nextModel, Cmd.none
    | Decrement ->
        let nextModel = currentModel - 1
        nextModel, Cmd.none

let button txt onClick =
    Button.button
        [ Button.IsFullWidth
          Button.Color IsPrimary
          Button.OnClick onClick ]
        [ str txt ]

let view (model : Model) (dispatch : Msg -> unit) =
    div []
        [ Navbar.navbar [ Navbar.Color IsPrimary ]
            [ Navbar.Item.div [ ]
                [ Heading.h2 [ ]
                    [ str "SAFE Template" ] ] ]

          Container.container []
              [ Content.content [ Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
                    [ Heading.h3 [] [ str ("Press buttons to manipulate counter: " + string model) ] ]
                Columns.columns []
                    [ Column.column [] [ button "-" (fun _ -> dispatch Decrement) ]
                      Column.column [] [ button "+" (fun _ -> dispatch Increment) ] ] ]

          Footer.footer [ ]
                [ Content.content [ Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
                    [ str "Credits: " ] ] ]

open Elmish.Debug
open Elmish.Navigation
open Elmish.HMR

Program.mkProgram init update view
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
