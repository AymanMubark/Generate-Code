Imports System.Data.SqlClient
Imports System.ServiceProcess

Public Class FrmSQLLog
    Public Sub StratServices(ByVal servername As String)
        Try
            Dim service As ServiceController = New ServiceController(servername)
            If service.Status = ServiceControllerStatus.Stopped Then
                service.Start()
                service.Refresh()
            End If
        Catch ex As Exception
            MsgBox("You dont have Sql Srver in your Machine")
        End Try
    End Sub
    Private Sub FrmSQLLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FrmWelcom.Show()
    End Sub

    Private Sub FrmSQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbAuthentication.SelectedIndex = 0
        cmbServer.Text = My.Settings.lastserver
        ' MetroButton2_Click(Nothing, Nothing)
    End Sub



    Private Sub cmbDataBase_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbAuthentication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAuthentication.SelectedIndexChanged
        Try
            If cmbAuthentication.SelectedIndex = 0 Then
                txtusername.Enabled = False
                txtuserpass.Enabled = False
                MetroLabel4.Text = "User name :"
            Else
                txtusername.Enabled = True
                txtuserpass.Enabled = True
                MetroLabel4.Text = "Login :"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If cmbServer.Text = "" Then
            cmbServer.Focus()
            Exit Sub
        ElseIf cmbDataBase.Text = "" Then
            cmbDataBase.Focus()
            Exit Sub
        End If
        If cmbAuthentication.SelectedIndex = 1 Then
            If txtusername.Text = "" Then
                txtusername.Focus()
                Exit Sub
            ElseIf txtuserpass.Text = "" Then
                txtuserpass.Focus()
                Exit Sub
            End If
        End If
        If cmbAuthentication.SelectedIndex = 0 Then
            SqlConnectionString = "Data Source=" & cmbServer.Text & ";Initial Catalog=" + cmbDataBase.Text + ";Integrated Security=True"
        ElseIf cmbAuthentication.SelectedIndex = 1 Then
            SqlConnectionString = "Data Source=" + cmbServer.Text + ";Initial Catalog=" + cmbDataBase.Text + ";User ID=" + txtusername.Text + ";Password=" + txtuserpass.Text
        End If
        Try
            Sqlcon = New SqlConnection(SqlConnectionString)
            Sqlcon.Open()
            Sqlcon.Close()

            FrmSQLCode.Show()
            Try
                My.Settings.lastserver = cmbServer.Text
                My.Settings.LastSqlDataBase = cmbDataBase.Text
                Dim isone = False
                For Each lin In My.Settings.userName.Split
                    If Not txtusername.Text = lin.ToString Then
                        isone = True
                    Else
                        isone = False
                    End If
                Next
                If isone Then
                    My.Settings.userName += txtusername.Text
                End If
            Catch ex As Exception

            End Try
            Hide()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Sqlcon.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub


    Private Sub FrmSQLLog_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            btnConnect_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then
            btnCancel_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        frmAbout.Close()
        frmAbout.ShowDialog()
    End Sub


    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        StratServices("SQLBrowser")
        UseWaitCursor = True
        cmbServer.Items.Clear()
        For Each lin In My.Settings.userName.Split
            If Not lin.ToString = " " AndAlso Not lin.ToString = "" Then
                txtusername.Items.Add(lin.ToString)
            End If
        Next
        cmbAuthentication.SelectedIndex = 0
        LoadServer(cmbServer)
        Try
            cmbDataBase.SelectedItem = My.Settings.LastSqlDataBase
            UseWaitCursor = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If cmbServer.Text = "" Then
                Return
            End If
            UseWaitCursor = True
            LoadDataBase(cmbServer, cmbDataBase)
            UseWaitCursor = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class