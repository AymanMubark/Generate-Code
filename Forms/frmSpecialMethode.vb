Public Class frmSpecialMethode

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedIndex
            Case 0
                txtCode.Text = " Public Sub OnlyInteger( ByVal e As KeyPressEventArgs )" + vbNewLine +
                      " IF Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then" + vbNewLine +
                          "  e.Handled = True" + vbNewLine +
                          " End If" + vbNewLine +
                          " End Sub"
            Case 1
                txtCode.Text = " Public Sub OnlyDecimal( ByVal e As KeyPressEventArgs, sender As Object )" + vbNewLine +
      "    IF Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) AndAlso e.KeyChar <> ""."" Then" + vbNewLine +
          "       e.Handled = True" + vbNewLine +
      "    End If" + vbNewLine +
      "    If (CType(sender, TextBox).Text.IndexOf(""."") >= 0 And e.KeyChar = ""."") Then" + vbNewLine +
      "        e.Handled = True" + vbNewLine +
      "    End If" + vbNewLine +
      " End Sub"
            Case 2
                txtCode.Text = " Public Sub OnlyIntegerAndCharcter( ByVal e As KeyPressEventArgs,ByVal Charcter As String )" + vbNewLine +
                      "    If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) AndAlso e.KeyChar <> Charcter Then" + vbNewLine +
                      "        e.Handled = True" + vbNewLine +
                       "    End If" + vbNewLine +
                       " End Sub"
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If txtCode.SelectionLength = 0 Then
                My.Computer.Clipboard.SetText(txtCode.Text)
            Else
                My.Computer.Clipboard.SetText(txtCode.SelectedText)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Dim KeyWords As List(Of String) = New List(Of String)(New String() {"if", "dim", "color", "public", "end", "sub", "try", "as", "new", "datatable", "sqlcommand", "then", "connectionstate", "nothing", "exception", "dss", "catch", "byval", "string", "integer", "boolean", "SqlConnection", "begin", "for", "each", "decimal", "double", "byte", "return", "char", "andalso", "textbox", "combobox"})
    Dim KeyWordsColors As List(Of Color) = New List(Of Color)(New Color() {Color.Blue, Color.Blue, Color.Green, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.LightSeaGreen, Color.Blue, Color.LightSeaGreen, Color.Blue, Color.LightSeaGreen, Color.LightSeaGreen, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue})
    Private Sub PreviewRTB_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        Dim words As IEnumerable(Of String) = CType(sender, RichTextBox).Text.Split(New Char() {" "c, ".", ",", "?", "!", "(", ")"})
        Dim index As Integer = 0
        Dim rtb As RichTextBox = sender 'to give normal color according to the base fore color
        For Each word As String In words
            'If the list contains the word, then color it specially. Else, color it normally
            'Edit: Trim() is added such that it may guarantee the empty space after word does not cause error
            coloringRTB(sender, index, word.Length, If(KeyWords.Contains(word.ToLower().Trim()), KeyWordsColors(KeyWords.IndexOf(word.ToLower().Trim())), rtb.ForeColor))
            index = index + word.Length + 1 '1 is for the whitespace, though Trimmed, original word.Length is still used to advance
        Next
    End Sub

    Private Sub coloringRTB(rtb As RichTextBox, index As Integer, length As Integer, color As Color)
        Dim selectionStartSave As Integer = rtb.SelectionStart 'to return this back to its original position
        rtb.SelectionStart = index
        rtb.SelectionLength = length
        rtb.SelectionColor = color
        rtb.SelectionLength = 0
        rtb.SelectionStart = selectionStartSave
        rtb.SelectionColor = rtb.ForeColor 'return back to the original color
    End Sub

    Private Sub frmSpecialMethode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class