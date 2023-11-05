Public Class FrmTU
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        FrmLogin.TextBox1.Text = ""
        FrmLogin.TextBox2.Text = ""
        FrmLogin.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmDataSiswa.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmMapel.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FrmJurusan.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        FrmUbahPassword.Show()
        Me.Hide()
    End Sub
End Class