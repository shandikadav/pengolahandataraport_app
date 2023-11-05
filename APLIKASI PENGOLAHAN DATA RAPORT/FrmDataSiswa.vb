Imports System.Data.SqlClient
Public Class FrmDataSiswa
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If FrmAdmin.Label3.Text = "Administrator" Then
            FrmAdmin.Show()
            Me.Hide()
        ElseIf FrmTU.label3.Text = "Tata Usaha" Then
            FrmTU.Show()
            Me.Hide()
        End If
    End Sub
End Class