Public Class FrmWelcom

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If ListBox1.SelectedIndex = 0 Then
            Me.Hide()
            FrmSQLLog.Show()
        ElseIf ListBox1.SelectedIndex = 1 Then
            FrmAccessLog.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub FrmWelcom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.SelectedIndex = 0
        MetroCheckBox1.Checked = My.Settings.startupch
        ' CheckBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#bcbdb9")

    End Sub


    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        btnConnect_Click(Nothing, Nothing)
    End Sub

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = 13 Then
            btnConnect_Click(Nothing, Nothing)

        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs)
        'ShowInTaskbar = True
        'Me.WindowState = FormWindowState.Normal
        'NotifyIcon1.Visible = False
    End Sub

    Private Sub FrmWelcom_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'If Me.WindowState = FormWindowState.Minimized Then
        '    NotifyIcon1.Visible = True
        '    NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        '    NotifyIcon1.BalloonTipTitle = "Gene Code"
        '    NotifyIcon1.BalloonTipText = "Gene Code"
        '    NotifyIcon1.ShowBalloonTip(50000)
        '    ShowInTaskbar = False

        'End If
    End Sub

    Private Sub MetroCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox1.CheckedChanged
        Try
            My.Settings.startupch = MetroCheckBox1.Checked
            If MetroCheckBox1.Checked Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
            Else
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Try
            Process.Start("http://fb.com/Aymn1997")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        frmAbout.Close()
        frmAbout.ShowDialog()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Try
            Process.Start("http://goo.gl/JiPes5")
        Catch ex As Exception

        End Try


    End Sub
End Class