Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class frmLogin
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

    Protected Sub MiLogin_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles MiLogin.Authenticate
        ConexionBBDD()
        Login()
    End Sub

    Private Sub ConexionBBDD()
        ':::Nuestro objeto OleDbConnetion con la cadena de conexión y la ruta de la base
        Dim cnnString As String = String.Format("Provider=Microsoft.Jet.Oledb.4.0; Data Source=C:\Users\in2dam-b\Desktop\Urki\RetoVideoclub-ASP\App_Data\EMPRESA.mdb")
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

    Private Sub Login()
        Dim usuarioEscrito As String = MiLogin.UserName
        Dim passEscrita As String = MiLogin.Password
        Dim sql As String = "SELECT Password FROM Clientes WHERE Nombre = '" + usuarioEscrito + "'"

        Dim cmd As OleDbCommand = New OleDbCommand(sql, _OleDbConnection)

        Try
            _OleDbConnection.Open()
            Dim pass = cmd.ExecuteScalar

            If pass = passEscrita Then
                MessageBox.Show("Login correcto")
            Else
                MessageBox.Show("Login incorrecto")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Conexión DB")
        Finally
            If Not IsNothing(OleDbConnection) Then
                OleDbConnection.Close()
            End If
        End Try

    End Sub


End Class