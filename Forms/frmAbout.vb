Public Class frmAbout

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmAbout_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' MetroButton1.BackColor = ColorTranslator.FromHtml("0147219")
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Process.Start("http://fb.com/Aymn1997")
    End Sub
End Class