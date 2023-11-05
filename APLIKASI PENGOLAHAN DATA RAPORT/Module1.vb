Imports System.Data.SqlClient
Module Module1
    Public konek As SqlConnection
    Sub konekdb()
        Try
            konek = New SqlConnection("Data Source=DESKTOP-D5OLT2H\SQLEXPRESS;initial catalog=DB_APPdataraport;integrated security=true")
            konek.Open()
            'MsgBox("Database terkoneksi", vbInformation)
        Catch ex As Exception
            MsgBox("Database tidak terkoneksi", vbExclamation)
        End Try
    End Sub
End Module
