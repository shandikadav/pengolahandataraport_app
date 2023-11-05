Imports System.Data.SqlClient
Public Class FrmMapel
    Dim databaru As Boolean

    Sub bersihkandata()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
    End Sub

    Sub tampilkandata()
        Dim da As SqlDataAdapter
        Dim ds As DataSet
        da = New SqlDataAdapter("SELECT * FROM mapel", konek)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "mapel")
        DataGridView1.DataSource = (ds.Tables("mapel"))
    End Sub
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
    Private Sub FrmMapel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_APPdataraportDataSet2.mapel' table. You can move, or remove it, as needed.
        Me.MapelTableAdapter.Fill(Me.DB_APPdataraportDataSet2.mapel)
        databaru = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim pesan, simpan As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data belum lengkap!", vbExclamation)
            Exit Sub
            TextBox1.Focus()
        Else
            If databaru Then
                pesan = MsgBox("Apakah anda yakin ingin menyimpan data ini?", vbYesNo + vbInformation)
                If pesan = vbNo Then
                    Exit Sub
                End If
                simpan = "INSERT INTO mapel(kdmapel,nama_mapel,kurikulum)VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "')"
                jalankansql(simpan)
                MsgBox("Data berhasil disimpan!", vbInformation)
                bersihkandata()
                tampilkandata()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pesan, ubah As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Silahkan cari data terlebih daulu!", vbExclamation)
            Exit Sub
            TextBox1.Focus()
        Else
            If databaru Then
                pesan = MsgBox("Apakah anda yakin ingin mengubah data ini?", vbYesNo + vbInformation)
                If pesan = vbNo Then
                    Exit Sub
                End If
                ubah = "UPDATE mapel set nama_mapel = '" + TextBox2.Text + "', kurikulum = '" + ComboBox1.Text + "' WHERE kdmapel = '" + TextBox1.Text + "'"
                jalankansql(ubah)
                MsgBox("Data berhasil diubah!", vbInformation)
                bersihkandata()
                tampilkandata()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pesan, hapus As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Silahkan cari data yang ingin dihapus terlebih dahulu!", vbExclamation)
            Exit Sub
            TextBox1.Focus()
        Else
            If databaru Then
                pesan = MsgBox("Apakah anda yakin ingin menghapus data ini?", vbYesNo + vbInformation)
                If pesan = vbNo Then
                    Exit Sub
                End If
                hapus = "DELETE FROM mapel WHERE kdmapel LIKE '" + TextBox1.Text + "'"
                jalankansql(hapus)
                MsgBox("Data berhasil dihapus!", vbInformation)
                bersihkandata()
                tampilkandata()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim sql As String
        konekdb()
        sql = "SELECT * FROM mapel WHERE kdmapel = '" + TextBox1.Text + "'"
        cmd = New SqlCommand(sql, konek)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows = True Then
            TextBox1.Text = rd.Item(0)
            TextBox2.Text = rd.Item(1)
            ComboBox1.Text = rd.Item(2)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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