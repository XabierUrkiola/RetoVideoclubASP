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



    End Sub
End Class