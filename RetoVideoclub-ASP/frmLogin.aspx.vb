Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security
Public Class frmLogin
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()

        End If
    End Sub

    Protected Sub MiLogin_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles MiLogin.Authenticate

    End Sub

    Protected Sub ValidarUsuario(sender As Object, e As EventArgs)
        Dim UserId As Integer = 0
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Using cnnBD As New SqlConnection(constr)
            Using cmd As New SqlCommand("ValidarUsuario")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Username", MiLogin.UserName)
                cmd.Parameters.AddWithValue("@Password", MiLogin.Password)
                cmd.Connection = cnnBD
                cnnBD.Open()
                UserId = Convert.ToInt32(cmd.ExecuteScalar())
                cnnBD.Close()
            End Using
            Select Case UserId
                Case -1
                    MiLogin.FailureText = "Nombre de usuario y / o contraseña incorrecta."
                    Exit Select
                Case -2
                    MiLogin.FailureText = "La cuenta no ha sido activada."
                    Exit Select
                Case Else
                    FormsAuthentication.RedirectFromLoginPage(MiLogin.UserName, MiLogin.RememberMeSet)
            End Select
        End Using
    End Sub
End Class