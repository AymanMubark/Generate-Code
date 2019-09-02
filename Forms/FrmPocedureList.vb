Public Class FrmPocedureList

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MetroFramework.MetroMessageBox.Show(Me, "You want Delete this Procedure", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) <> Windows.Forms.DialogResult.OK Then
            Return
        End If
        Dim index = DGVTable.CurrentRow.Cells(0).RowIndex
        DropProcdure(DGVTable.CurrentRow.Cells(0).Value)
        LoadProcdure()
        Try
            DGVTable.Rows(index).Selected = True
            DGVTable.FirstDisplayedScrollingRowIndex = index
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FrmPocedureList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadProcdure()
            DGVTable.DataSource = DtProcdure

            DGVTable.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            DGVTable.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            DGVTable.Columns(3).Visible = False
            DGVTable.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        FrmSQLCode.txtAddprocedure.Text = DGVTable.CurrentRow.Cells(3).Value.ToString
        FrmSQLCode.txtCheckProcedureCode.Text = " IF OBJECT_ID('" + DGVTable.CurrentRow.Cells(0).Value + "') IS NOT NULL " + vbNewLine +
                                          " DROP PROC Delete_" + DGVTable.CurrentRow.Cells(0).Value + "" + vbNewLine
        Me.Close()
    End Sub
End Class