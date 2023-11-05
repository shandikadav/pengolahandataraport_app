Imports System.Data.SqlClient
Public Class FrmLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim sql, user, pass As String
        konekdb()
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Username dan Password belum terisi!", vbInformation)
            TextBox1.Focus()
            Exit Sub
        End If
        user = TextBox1.Text
        pass = TextBox2.Text
        sql = "SELECT * FROM akun WHERE Username = '" + user + "' AND Password = '" + pass + "'"
        cmd = New SqlCommand(sql, konek)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows = True Then
            If rd.Item(1).ToString = "admin" Then
                MessageBox.Show("Login Administrator berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FrmAdmin.Label3.Text = rd.Item(3)
                FrmAdmin.Show()
                Me.Hide()
            ElseIf rd.Item(1).ToString = "tu" Then
                MessageBox.Show("Login Tata Usaha berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FrmTU.Label3.Text = rd.Item(3)
                FrmTU.Show()
                Me.Hide()
            ElseIf rd.Item(1).ToString = "siswa" Then
                MessageBox.Show("Login Siswa berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FrmSiswa.Label3.Text = rd.Item(3)
                FrmSiswa.Show()
                Me.Hide()
            End If
        Else
            MessageBox.Show("Username dan Password Salah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
