Imports System.Data.Odbc
Imports MySql.Data.MySqlClient

Public Class frm_Login

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtNama.Text = "" Or txtPass.Text = "" Then
            MsgBox("Nama dan Password Tidak Boleh Kosong!")
        Else
            Call koneksi()
            cmd = New MySqlCommand("SELECT * FROM tbl_admin WHERE adminname = @nama AND adminpw = @password", conn)
            cmd.Parameters.AddWithValue("@nama", txtNama.Text)
            cmd.Parameters.AddWithValue("@password", txtPass.Text)

            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                loginberhasil()
            Else
                MsgBox("Nama dan Password Salah! Coba Lagi")
            End If

            dr.Close()
        End If
    End Sub

    Private Sub loginberhasil()
        ' Menampilkan Form1 dan mengatur btn_ManageFoods menjadi terlihat
        'Dim form1 As New Form1()
        'Form1.Show()
        Form1.btn_ManageFoods.Visible = True
        Form1.btn_Report.Visible = True
        Form1.btn_CancelOrder.Visible = True
        'Form1.btn_login.Visible = False
        isLogin = True
        Form1.CekLogin()
        Me.Close()
    End Sub

    Private Sub cbPass_CheckedChanged(sender As Object, e As EventArgs) Handles cbPass.CheckedChanged
        If cbPass.Checked = True Then
            txtPass.PasswordChar = ""
        Else
            txtPass.PasswordChar = "*"
        End If
    End Sub

    Private Sub frm_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
