Public Class FrmSQLMultiple

    Sub FIllDGV(ByVal DGVColumn As DataGridView)
        If DGVColumn.Rows.Count > 0 Then
            Exit Sub
        End If
        Try
            DGVColumn.Rows.Clear()
            LoadColumnMul(DGVTable.CurrentRow.Cells(0).Value)
            For x = 0 To DtColumnMul.Rows.Count - 1
                DGVColumn.Rows.Add()
                DGVColumn(1, x).Value = DtColumnMul(x)(0).ToString
                DGVColumn(2, x).Value = DtColumnMul(x)(1).ToString
                DGVColumn(3, x).Value = DtColumnMul(x)(2).ToString
                DGVColumn(4, x).Value = DtColumnMul(x)(3).ToString
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private tablename As String
    Private whereRe As String
    Sub selectRow(ByVal DGVColumn As DataGridView)
        Try
            For x = 0 To DGVColumn.Rows.Count - 1
                If Not DGVColumn.Rows(x).Cells(0).Value = "" Then
                    tablename += DGVColumn.Rows(x).Cells(1).Value + " As " + DGVColumn.Rows(x).Cells(0).Value + " ,"
                    whereRe += DGVColumn.Rows(x).Cells(0).Value + "." + DGVColumn.Rows(x).Cells(1).Value + " ="
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DGVTable_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGVTable.DoubleClick
        If DGVColumn1.Rows.Count = 0 Then
            FIllDGV(DGVColumn1)
            'btn1.BackColor = Color.Lime
            'LB1.Text = DGVTable.CurrentRow.Cells(0).Value
        ElseIf DGVColumn2.Rows.Count = 0 Then
            FIllDGV(DGVColumn2)
            'btn2.BackColor = Color.Lime
            'lb2.Text = DGVTable.CurrentRow.Cells(0).Value
        ElseIf DGVColumn3.Rows.Count = 0 Then
            FIllDGV(DGVColumn3)
            'btn3.BackColor = Color.Lime
            'lb3.Text = DGVTable.CurrentRow.Cells(0).Value
        ElseIf DGVColumn4.Rows.Count = 0 Then
            FIllDGV(DGVColumn4)
            'btn4.BackColor = Color.Lime
            'lb4.Text = DGVTable.CurrentRow.Cells(0).Value
        End If
    End Sub

    Private Sub FrmSQLMultiple_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadTable()
        DGVTable.DataSource = DtTable
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        selectRow(DGVColumn1)
        selectRow(DGVColumn2)
        selectRow(DGVColumn3)
        selectRow(DGVColumn4)
        txtCode.Text = "Select " + "*" + " from " + tablename + " where " + whereRe

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class