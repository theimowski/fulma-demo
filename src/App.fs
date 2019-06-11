module App

open Elmish
open Fable.FontAwesome
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

open Fable.React
open Fable.React.Props

let navBrand =
    Navbar.navbar [ Navbar.Color IsWhite ]
        [ Container.container [ ]
            [ Navbar.Brand.div [ ]
                [ Navbar.Item.a [ Navbar.Item.CustomClass "brand-text" ]
                      [ str "SAFE Admin" ] ]
              Navbar.menu [ ]
                  [ Navbar.Start.div [ ]
                      [ Navbar.Item.a [ ]
                            [ str "Home" ]
                        Navbar.Item.a [ ]
                            [ str "Orders" ]
                        Navbar.Item.a [ ]
                            [ str "Payments" ]
                        Navbar.Item.a [ ]
                            [ str "Exceptions" ] ] ] ] ]

let menu =
    Menu.menu [ ]
        [ Menu.label [ ]
              [ str "General" ]
          Menu.list [ ]
              [ Menu.Item.a [ ]
                    [ str "Dashboard" ]
                Menu.Item.a [ ]
                    [ str "Customers" ] ]
          Menu.label [ ]
              [ str "Administration" ]
          Menu.list [ ]
              [ Menu.Item.a [ ]
                  [ str "Team Settings" ]
                li [ ]
                    [ a [ ]
                        [ str "Manage Your Team" ]
                      Menu.list [ ]
                          [ Menu.Item.a [ ]
                                [ str "Members" ]
                            Menu.Item.a [ ]
                                [ str "Plugins" ]
                            Menu.Item.a [ ]
                                [ str "Add a member" ] ] ]
                Menu.Item.a [ ]
                    [ str "Invitations" ]
                Menu.Item.a [ ]
                    [ str "Cloud Storage Environment Settings" ]
                Menu.Item.a [ ]
                    [ str "Authentication" ] ]
          Menu.label [ ]
              [ str "Transactions" ]
          Menu.list [ ]
              [ Menu.Item.a [ ]
                    [ str "Payments" ]
                Menu.Item.a [ ]
                    [ str "Transfers" ]
                Menu.Item.a [ ]
                    [ str "Balance" ] ] ]

let breadcrump =
    Breadcrumb.breadcrumb [ ]
        [ Breadcrumb.item [ ]
              [ a [ ] [ str "Bulma" ] ]
          Breadcrumb.item [ ]
              [ a [ ] [ str "Templates" ] ]
          Breadcrumb.item [ ]
              [ a [ ] [ str "Examples" ] ]
          Breadcrumb.item [ Breadcrumb.Item.IsActive true ]
              [ a [ ] [ str "Admin" ] ] ]

let hero =
    Hero.hero [ Hero.Color IsInfo
                Hero.CustomClass "welcome" ]
        [ Hero.body [ ]
            [ Container.container [ ]
                [ Heading.h1 [ ]
                      [ str "Hello, Admin." ] ] ] ]

let info =
    section [ Class "info-tiles" ]
        [ Tile.ancestor [ Tile.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
            [ Tile.parent [ ]
                  [ Tile.child [ ]
                      [ Box.box' [ ]
                          [ Heading.p [ ]
                                [ str "439k" ]
                            Heading.p [ Heading.IsSubtitle ]
                                [ str "Users" ] ] ] ]
              Tile.parent [ ]
                  [ Tile.child [ ]
                      [ Box.box' [ ]
                          [ Heading.p [ ]
                                [ str "59k" ]
                            Heading.p [ Heading.IsSubtitle ]
                                [ str "Products" ] ] ] ]
              Tile.parent [ ]
                  [ Tile.child [ ]
                      [ Box.box' [ ]
                          [ Heading.p [ ]
                                [ str "3.4k" ]
                            Heading.p [ Heading.IsSubtitle ]
                                [ str "Open Orders" ] ] ] ]
              Tile.parent [ ]
                  [ Tile.child [ ]
                      [ Box.box' [ ]
                          [ Heading.p [ ]
                                [ str "19" ]
                            Heading.p [ Heading.IsSubtitle ]
                                [ str "Exceptions" ] ] ] ] ] ]

let counter (model : Model) (dispatch : Msg -> unit) =
    Field.div [ Field.IsGrouped ]
        [ Control.p [ Control.IsExpanded ]
            [ Input.text
                [ Input.Disabled true
                  Input.Value (string model) ] ]
          Control.p [ ]
            [ Button.a
                [ Button.Color IsInfo
                  Button.OnClick (fun _ -> dispatch Increment) ]
                [ str "+" ] ]
          Control.p [ ]
            [ Button.a
                [ Button.Color IsInfo
                  Button.OnClick (fun _ -> dispatch Decrement) ]
                [ str "-" ] ] ]

let columns (model : Model) (dispatch : Msg -> unit) =
    Columns.columns [ ]
        [ Column.column [ Column.Width (Screen.All, Column.Is6) ]
            [ Card.card [ CustomClass "events-card" ]
                [ Card.header [ ]
                    [ Card.Header.title [ ]
                        [ str "Events" ]
                      Card.Header.icon [ ]
                          [ Icon.icon [ ]
                              [ Fa.i [ Fa.Solid.AngleDown ] [] ] ] ]
                  div [ Class "card-table" ]
                      [ Content.content [ ]
                          [ Table.table
                              [ Table.IsFullWidth
                                Table.IsStriped ]
                              [ tbody [ ]
                                  [ for _ in 1..10 ->
                                      tr [ ]
                                          [ td [ Style [ Width "5%" ] ]
                                              [ Icon.icon
                                                  [ ]
                                                  [ Fa.i [ Fa.Regular.Bell ] [] ] ]
                                            td [ ]
                                                [ str "Lorem ipsum dolor aire" ]
                                            td [ ]
                                                [ Button.a
                                                    [ Button.Size IsSmall
                                                      Button.Color IsPrimary ]
                                                    [ str "Action" ] ] ] ] ] ] ]
                  Card.footer [ ]
                      [ Card.Footer.div [ ]
                          [ str "View All" ] ] ] ]
          Column.column [ Column.Width (Screen.All, Column.Is6) ]
              [ Card.card [ ]
                  [ Card.header [ ]
                      [ Card.Header.title [ ]
                          [ str "Inventory Search" ]
                        Card.Header.icon [ ]
                            [ Icon.icon [ ]
                                [ Fa.i [Fa.Solid.AngleDown] [] ] ] ]
                    Card.content [ ]
                        [ Content.content [ ]
                            [ Control.div
                                [ Control.HasIconLeft
                                  Control.HasIconRight ]
                                [ Input.text
                                      [ Input.Size IsLarge ]
                                  Icon.icon
                                      [ Icon.Size IsMedium
                                        Icon.IsLeft ]
                                      [ Fa.i [Fa.Solid.Search] [] ]
                                  Icon.icon
                                      [ Icon.Size IsMedium
                                        Icon.IsRight ]
                                      [ Fa.i [Fa.Solid.Check] [] ] ] ] ] ]
                Card.card [ ]
                    [ Card.header [ ]
                        [ Card.Header.title [ ]
                              [ str "Counter" ]
                          Card.Header.icon [ ]
                              [ Icon.icon [ ]
                                  [ Fa.i [Fa.Solid.AngleDown] [] ] ] ]
                      Card.content [ ]
                        [ Content.content   [ ]
                            [ counter model dispatch ] ] ]   ] ]

let view (model : Model) (dispatch : Msg -> unit) =
    div [ ]
        [ navBrand
          Container.container [ ]
              [ Columns.columns [ ]
                  [ Column.column [ Column.Width (Screen.All, Column.Is3) ]
                      [ menu ]
                    Column.column [ Column.Width (Screen.All, Column.Is9) ]
                      [ breadcrump
                        hero
                        info
                        columns model dispatch ] ] ] ]
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
