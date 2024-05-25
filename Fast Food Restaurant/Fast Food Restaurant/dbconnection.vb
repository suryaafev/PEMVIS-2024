Imports MySql.Data.MySqlClient
Imports System.IO
Module dbconnection

    Public isLogin As Boolean = False
    Public conn As New MySqlConnection
    Dim result As Boolean
    Public cmd As New MySqlCommand
    Public dr As MySqlDataReader
    Public da As MySqlDataAdapter
    Public i As Integer
    Public DS As DataSet 'Koneksi Ke Data Adapter
    Public STR As String

    Public Function dbconn() As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.ConnectionString = "server=localhost;userid=root;password=;port=3306;database=fastfood_db"
                result = True
            End If
        Catch ex As Exception
            result = False
            MsgBox("Server Not Connected !", vbExclamation)
        End Try
        Return result
    End Function

    Sub koneksi()
        Try
            Dim STR As String =
            "server=localhost;userid=root;password=;database=fastfood_db"
            'Ganti nama database sesuaikan dengan nama database kalian
            conn = New MySqlConnection(STR)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Module
