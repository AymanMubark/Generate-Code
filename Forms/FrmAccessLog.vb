Imports System.IO
Imports System.Data.OleDb

Public Class FrmAccessLog

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If txtDataBase.Text = "" Then
            txtDataBase.Focus()
            Exit Sub
        End If
        If cmbLoginType.SelectedIndex = 1 Then
            If txtconfirmpass.Text = "" Then
                txtconfirmpass.Focus()
                Exit Sub
            ElseIf txtconfirmpass.Text = "" Then
                txtconfirmpass.Focus()
                Exit Sub
            End If
            If txtuserpass.Text <> txtconfirmpass.Text Then
                MsgBox("Password Not Confirm")
                Exit Sub
            End If
        End If
        Dim dbpasswrd = ""
        If txtconfirmpass.Enabled = True Then
            dbpasswrd = ";Jet OLEDB:Database Password=" + txtconfirmpass.Text
        End If
        If comboBox1.SelectedIndex = 0 Then
            OleDbonnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & txtDataBase.Text & dbpasswrd
        Else
            OleDbonnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & txtDataBase.Text & dbpasswrd
        End If
        Try
            OleDbCon = New OleDbConnection(OleDbonnectionString)
            OleDbCon.Open()
            OleDbCon.Close()
            Try
                My.Settings.lastLogtypeaccess = comboBox1.SelectedIndex
                My.Settings.LastAccessDataBase = txtDataBase.Text
            Catch ex As Exception

            End Try
            Hide()
            FrmAccessCode.Show()
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Test Conection", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        If comboBox1.SelectedIndex = 0 Then
            OFD.Filter = "Access 2010|*.accdb"
        Else
            OFD.Filter = "Access 2003|*.mdb"
        End If
        OFD.ShowDialog()
    End Sub

    Private Sub OFD_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OFD.FileOk
        txtDataBase.Text = OFD.FileName
    End Sub

    Private Sub FrmAccessLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FrmWelcom.Show()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub FrmAccessLog_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            btnConnect_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then
            btnCancel_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FrmAccessLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        cmbLoginType.SelectedIndex = 0
        Try
            ComboBox1.SelectedIndex = My.Settings.lastLogtypeaccess
            txtDataBase.Text = My.Settings.LastAccessDataBase
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbLoginType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLoginType.SelectedIndexChanged
        If cmbLoginType.SelectedIndex = 0 Then
            txtconfirmpass.Enabled = False
            txtuserpass.Enabled = False
        Else
            txtconfirmpass.Enabled = True
            txtuserpass.Enabled = True
        End If
    End Sub

    Private Sub txtconfirmpass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtconfirmpass.KeyDown, txtuserpass.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnConnect_Click(Nothing, Nothing)
        End If
    End Sub
End Class