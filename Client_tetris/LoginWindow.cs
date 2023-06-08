// namespace Client_tetris;
//
// using Terminal.Gui;
//
// public class LoginWindow : Window
// {
//     private readonly View _parent;
//     public Action<string>? OnLogin { get; set; }
//     public Action? OnExit { get; set; }
//
//     public LoginWindow(View parent) : base("Login", 5)
//     {
//         _parent = parent;
//         InitControls();
//         InitStyle();
//     }
//
//     public void InitStyle()
//     {
//         X = Pos.Center();
//         Width = Dim.Percent(50);
//         Height = 17;
//     }
//
//     public void Close()
//     {
//         Application.RequestStop(this);
//         _parent?.Remove(this);
//     }
//
//     private void InitControls()
//     {
//         #region nickname
//
//         var nameLabel = new Label(0, 0, "Nickname");
//         var nameText = new TextField("")
//         {
//             X = Pos.Left(nameLabel),
//             Y = Pos.Bottom(nameLabel),
//             Width = Dim.Fill()
//         };
//         
//         Add(nameLabel);
//         Add(nameText);
//
//         #endregion
//
//         #region buttons
//         var loginButton = new Button("Login", is_default: true)
//         {
//             X = Pos.Left(nameText),
//             Y = Pos.Bottom(nameText)
//         };
//
//         var exitButton = new Button("Exit")
//         {
//             X = Pos.Right(loginButton) + 1,
//             Y = Pos.Top(loginButton)
//         };
//
//         Add(loginButton);
//         Add(exitButton);
//         #endregion
//
//         #region bind-button-events
//
//         loginButton.Clicked += () =>
//         {
//             if (nameText.Text.ToString().TrimStart().Length == 0)
//             {
//                 MessageBox.ErrorQuery(25, 8, "Error", "Name cannot be empty.", "Ok");
//                 return;
//             }
//             OnLogin?.Invoke(nameText.Text.ToString());
//             Close();
//         };
//
//         exitButton.Clicked += () =>
//         {
//             OnExit?.Invoke();
//             Close();
//         };
//
//         #endregion
//     }
// }