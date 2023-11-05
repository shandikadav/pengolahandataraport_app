Public Class FrmSiswa
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FrmLogin.TextBox1.Text = ""
        FrmLogin.TextBox2.Text = ""
        FrmLogin.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmUbahPassword.Show()
        Me.Hide()
    End Sub
End Class