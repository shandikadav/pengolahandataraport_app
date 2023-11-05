Imports System.Data.SqlClient
Public Class FrmUbahPassword
    Private Sub jalankansql(ByVal sql As String)
        Dim sqlcmd As New SqlCommand
        Try
            konekdb()
            sqlcmd.Connection = konek
            sqlcmd.CommandType = CommandType.Text
            sqlcmd.CommandText = sql
            sqlcmd.ExecuteNonQuery()
            sqlcmd.Dispose()
            konek.Close()
        Catch ex As Exception
            MsgBox("error" & ex.Message)
        End Try
    End Sub
    Sub bersihkandata()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        konekdb()
        Dim ubah As String
        Dim uname, pass As String
        uname = FrmLogin.TextBox1.Text
        pass = FrmLogin.TextBox2.Text
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("data belum lengkap!", vbExclamation)
            Exit Sub
            TextBox1.Focus()
        ElseIf (TextBox1.Text <> pass) Then
            MsgBox("Password lama salah!", vbExclamation)
            bersihkandata()
            Exit Sub
            TextBox1.Focus()
        ElseIf (TextBox2.Text <> TextBox3.Text) Then
            MsgBox("Password baru denga Konfirmasi Password tidak sama!", vbExclamation)
            TextBox2.Text = ""
            TextBox3.Text = ""
            Exit Sub
            TextBox2.Focus()
        Else
            ubah = "UPDATE akun SET password = '" + TextBox3.Text + "' WHERE username = '" + uname + "'"
            jalankansql(ubah)
            MsgBox("Password berhasil diubah!", vbInformation)
            bersihkandata()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If FrmAdmin.Label3.Text = "Administrator" Then
            FrmAdmin.Show()
            Me.Hide()
        ElseIf FrmTU.Label3.Text = "Tata Usaha" Then
            FrmTU.Show()
            Me.Hide()
        ElseIf FrmSiswa.Label3.Text = "Siswa" Then
            FrmSiswa.Show()
            Me.Hide()
        End If
    End Sub
End Class