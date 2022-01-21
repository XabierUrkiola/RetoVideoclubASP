Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class frmChangePassword
    Inherits System.Web.UI.Page

    Private _OleDbConnection As OleDbConnection
    Public Property OleDbConnection() As OleDbConnection
        Get
            Return _OleDbConnection
        End Get
        Set(ByVal value As OleDbConnection)
            _OleDbConnection = value
        End Set
    End Property

    Dim usuario As String = "admin"

    Protected Sub miChangePassword_ChangedPassword(sender As Object, e As EventArgs) Handles miChangePassword.ContinueButtonClick
        ConexionBBDD()
        ComprobarCambiarPass()
    End Sub

    Private Sub ConexionBBDD()
        ':::Nuestro objeto OleDbConnetion con la cadena de conexión y la ruta de la base

        Dim path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory(), "App_Data", "EMPRESA.mdb")
        Dim cnnString As String = String.Format("Provider=Microsoft.Jet.Oledb.4.0; Data Source={0}", path)
        OleDbConnection = New OleDbConnection(cnnString)
        ':::Utilizamos el try para capturar posibles errores

        Try
            OleDbConnection.Open()
            If OleDbConnection.State = System.Data.ConnectionState.Open Then
                MessageBox.Show("Se conecta")
            End If
        Catch ex As Exception
            MessageBox.Show("No se conecta")
        Finally
            If Not IsNothing(OleDbConnection) Then
                OleDbConnection.Close()
            End If
        End Try
    End Sub
    Private Sub ComprobarCambiarPass()
        Dim passVieja As String = miChangePassword.CurrentPassword
        Dim passNueva As String = miChangePassword.NewPassword
        Dim passNuevaConfirm As String = miChangePassword.ConfirmNewPassword

        Dim sql As String = "SELECT Password FROM Clientes WHERE Nombre = '" & usuario & "'"

        Dim cmd As OleDbCommand = New OleDbCommand(sql, _OleDbConnection)

        Try
            _OleDbConnection.Open()
            Dim pass = cmd.ExecuteScalar

            If pass = passVieja Then
                If passNueva = passNuevaConfirm Then
                    CambiarPass()
                Else
                    MessageBox.Show("La contraseña debe coincidir")
                End If
            Else
                MessageBox.Show("Introduce tu contraseña actual")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Conexión DB")
        Finally
            If Not IsNothing(OleDbConnection) Then
                OleDbConnection.Close()
            End If
        End Try
    End Sub

    Private Sub CambiarPass()
        Dim passNueva As String = miChangePassword.NewPassword
        Dim Sql As String
        Sql = "UPDATE Clientes SET [Password] ='" & passNueva & "' WHERE [Nombre] ='" & usuario & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(Sql, _OleDbConnection)
        Try
            If Not _OleDbConnection.State = ConnectionState.Open Then
                _OleDbConnection.Open()
            End If

            cmd.ExecuteNonQuery()

            MessageBox.Show("Contraseña cambiada")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Conexión DB")
        Finally
            If Not IsNothing(OleDbConnection) Then
                OleDbConnection.Close()
            End If
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ConexionBBDD()
        ComprobarCambiarPass()
    End Sub
End Class