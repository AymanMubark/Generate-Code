Public Class FrmSQLCode

    Private Sub FrmSQLCode_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FrmSQLLog.Show()
    End Sub

    Private Sub FrmSQLCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmbSchema.SelectedIndex = 0
            DGVTable.DataSource = DtTable
            txtAddprocedure.ForeColor = My.Settings.txtForeColor
            txtCheckProcedureCode.ForeColor = My.Settings.txtForeColor

            txtCodeStore.ForeColor = My.Settings.txtForeColor

            txtCode.Font = My.Settings.txtFont
            txtAddprocedure.Font = My.Settings.txtFont
            txtCheckProcedureCode.Font = My.Settings.txtFont
            txtCodeStore.Font = My.Settings.txtFont

            txtAddprocedure.BackColor = My.Settings.txtBackColor
            txtCheckProcedureCode.BackColor = My.Settings.txtBackColor
            txtCode.BackColor = My.Settings.txtBackColor
            txtCodeStore.BackColor = My.Settings.txtBackColor
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGVTable_SelectionChanged(sender As Object, e As EventArgs) Handles DGVTable.SelectionChanged
        Try
            DGVColumn.Rows.Clear()
            LoadColumn(DGVTable(0, DGVTable.SelectedRows(0).Index).Value)
            For x = 0 To DtColumn.Rows.Count - 1
                DGVColumn.Rows.Add()
                DGVColumn(0, x).Value = DtColumn(x)(0).ToString
                DGVColumn(1, x).Value = DtColumn(x)(1).ToString
                DGVColumn(2, x).Value = DtColumn(x)(2).ToString
                DGVColumn(7, x).Value = DtColumn(x)(3).ToString
                DGVColumn(8, x).Value = DtColumn(x)(4).ToString
            Next
            txtName.Text = DGVTable(0, DGVTable.SelectedRows(0).Index).Value
        Catch ex As Exception

        End Try
        ChSelectAll_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub btnConnection_Click(sender As Object, e As EventArgs) Handles btnConnection.Click
        Try
            Dim st = ""
            If languge = "vb" Then
                st = "   Public Sqlcon = New SqlConnection(""" + SqlConnectionString + """)"
            Else
                st = "   public static SqlConnection Sqlcon = new SqlConnection(""" + SqlConnectionString + """);"
            End If
            txtCode.Text = st
            txtCodeStore.Text = st
        Catch ex As Exception

        End Try
    End Sub

    Sub ClearText()
        txtCode.Clear()
        txtAddprocedure.Clear()
        txtCheckProcedureCode.Clear()
        txtCodeStore.Clear()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            ClearText()
            Dim cont = 0
            Dim where = ""
            Dim Sel = ""
            Dim Prametre = ""
            Dim Selcont = 0
            Dim wherepor = ""
            Dim prameterofpro = ""
            '===================================================================================

            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(4).Value = True Then
                    cont += 1
                    If languge = "vb" Then
                        Prametre += "ByVal " + DGVColumn.Rows(x).Cells(0).Value + " As " + vbGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + ", "
                    Else
                        Prametre += CHGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + "  " + DGVColumn.Rows(x).Cells(0).Value + ", "
                    End If
                    where += " [" + DGVColumn.Rows(x).Cells(0).Value + "] =@" + DGVColumn.Rows(x).Cells(0).Value + " And "
                    prameterofpro += "@" + DGVColumn.Rows(x).Cells(0).Value + " , "
                    If DGVColumn.Rows(x).Cells(2).Value = "" Then
                        If DGVColumn.Rows(x).Cells(1).Value.ToString = "decimal" Or DGVColumn.Rows(x).Cells(1).Value.ToString = "numeric" Then
                            wherepor += "@" + DGVColumn.Rows(x).Cells(0).Value + "  " + DGVColumn.Rows(x).Cells(1).Value + "(" + DGVColumn.Rows(x).Cells(7).Value + "," + DGVColumn.Rows(x).Cells(8).Value + ") = Null , " + vbNewLine
                        Else
                            wherepor += " @" + DGVColumn.Rows(x).Cells(0).Value + " " + DGVColumn.Rows(x).Cells(1).Value + " = Null  , " + vbNewLine

                        End If
                    Else
                        If DGVColumn.Rows(x).Cells(2).Value = -1 And (DGVColumn.Rows(x).Cells(1).Value.ToString = "varchar" Or DGVColumn.Rows(x).Cells(1).Value.ToString = "varbinary" Or DGVColumn.Rows(x).Cells(1).Value.ToString = "nvarchar") Then
                            MsgBox(DGVColumn.Rows(x).Cells(1).Value)
                            wherepor += "@" + DGVColumn.Rows(x).Cells(0).Value + "  " + DGVColumn.Rows(x).Cells(1).Value + "(MAX) = Null , " + vbNewLine
                        Else
                            If DGVColumn.Rows(x).Cells(2).Value > 0 Then
                                If DGVColumn.Rows(x).Cells(1).Value.ToString = "image" Or DGVColumn.Rows(x).Cells(1).Value.ToString = "text" Or DGVColumn.Rows(x).Cells(1).Value.ToString = "hierarchyid" Then
                                    wherepor += " @" + DGVColumn.Rows(x).Cells(0).Value + " " + DGVColumn.Rows(x).Cells(1).Value + " = Null  , " + vbNewLine
                                Else
                                    wherepor += "@" + DGVColumn.Rows(x).Cells(0).Value + "  " + DGVColumn.Rows(x).Cells(1).Value + "(" + DGVColumn.Rows(x).Cells(2).Value + ") = Null , " + vbNewLine

                                End If
                            End If
                        End If
                    End If
                End If
            Next
            Dim isOne = ""
            Dim c = 0
            Dim v = 0
            Dim Group = ""
            Dim orderby = ""
            Dim orderCount = 0
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(3).Value = True Then
                    Selcont += 1
                    If Not DGVColumn.Rows(x).Cells(5).Value = "" Then
                        Sel += DGVColumn.Rows(x).Cells(5).Value + "([" + DGVColumn.Rows(x).Cells(0).Value + "]), "
                        isOne = DGVColumn.Rows(x).Cells(5).Value
                        c += 1
                    Else
                        Sel += "[" + DGVColumn.Rows(x).Cells(0).Value + "], "
                        Group += "[" + DGVColumn.Rows(x).Cells(0).Value + "], "
                    End If
                End If
                If DGVColumn.Rows(x).Cells(6).Value = True Then
                    orderCount += 1
                    If Not DGVColumn.Rows(x).Cells(5).Value = "" Then
                        orderby += DGVColumn.Rows(x).Cells(5).Value + "([" + DGVColumn.Rows(x).Cells(0).Value + "])  , "
                    Else
                        orderby += "[" + DGVColumn.Rows(x).Cells(0).Value + "]  , "
                    End If
                End If
            Next

            If cont >= 1 Then
                where = " WHERE " + where
            End If
            If orderCount >= 1 Then
                orderby = " ORDER BY " + orderby
            End If
            If Prametre.Length > 0 Then
                Prametre = Prametre.Remove(Prametre.Length - 2)
            End If
            If where.Length > 0 Then
                where = where.Remove(where.Length - 4)
            End If
            If orderby.Length > 0 Then
                orderby = orderby.Remove(orderby.Length - 4)
            End If

            If wherepor.Length > 0 Then
                wherepor = wherepor.Remove(wherepor.Length - 4)
            End If
            If prameterofpro.Length > 0 Then
                prameterofpro = prameterofpro.Remove(prameterofpro.Length - 2)
            End If
            If Sel = "" Then
                Sel = " *  "
            End If
            If Sel.Length > 0 Then
                Sel = Sel.Remove(Sel.Length - 2)
            End If
            If Not where = "" Then
                where += vbNewLine
            End If
            If Not wherepor = "" Then
                wherepor += vbNewLine
            End If
            '"" SELECT " + Sel + " FROM " + DGVTable.CurrentRow.Cells(0).Value + where + " " + d + orderby + """

            If c = 0 Then
                Group = ""
            ElseIf c >= 1 And Not Group = "" Then
                Group = " Group by " + Group
            End If
            If Not Group.Length = 0 Then
                Group = Group.Remove(Group.Length - 2)
            End If
          
            Dim sss = ""
            Dim ddd = ""
            Dim fff = "Load_" + txtName.Text
            If languge = "vb" Then
                sss = " Public Dt_" + txtName.Text + " As New DataTable" + vbNewLine +
                            " Public" + " Sub Load_" + txtName.Text + "(" + Prametre + ")" + vbNewLine +
                            " Dt_" + txtName.Text + ".clear()" + vbNewLine +
                            " Try" + vbNewLine
                ddd = " IF Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()" + vbNewLine +
                               " Sqlcon.Open()" + vbNewLine +
                               " Dt_" + txtName.Text + ".Load(cmd.ExecuteReader())" + vbNewLine +
                               " Sqlcon.Close()" + vbNewLine +
                               " cmd = Nothing" + vbNewLine +
                               " Catch ex As Exception" + vbNewLine +
                               " Sqlcon.Close()" + vbNewLine +
                               " MessageBox.Show(ex.Message)" + vbNewLine +
                               " End Try" + vbNewLine +
                               " End Sub "

                If Not isOne = "" AndAlso Selcont = 1 Then
                    sss = " Public Function " + isOne + "_" + txtName.Text + "(" + Prametre + ") As Integer" + vbNewLine +
                                   "Dim Number As Integer=0" + vbNewLine +
                                     "Try" + vbNewLine
                    fff = isOne + "_" + txtName.Text
                    ddd = " IF Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()" + vbNewLine +
                    "Sqlcon.Open()" + vbNewLine +
                    "Number = cmd.ExecuteScalar()" + vbNewLine +
                    "Sqlcon.Close()" + vbNewLine + "cmd = Nothing" + vbNewLine +
                    " Catch ex As Exception" + vbNewLine +
                    "Sqlcon.Close()" + vbNewLine +
                    "Number = 0" + vbNewLine +
                    "MessageBox.Show(ex.Message)" + vbNewLine +
                    " End Try" + vbNewLine +
                    " Return Number" + vbNewLine +
                    " End Sub"
                End If

                txtCode.Text = sss +
                 " Dim cmd = New SqlCommand("" SELECT " + Sel + " FROM " + DGVTable.CurrentRow.Cells(0).Value + where + " " + Group + orderby + """,Sqlcon)"
                For x = 0 To DGVColumn.Rows.Count - 1
                    If DGVColumn.Rows(x).Cells(4).Value = True Then
                        txtCode.Text += vbNewLine + "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + DGVColumn.Rows(x).Cells(1).Value + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + ""
                    End If
                Next
                txtCode.Text += vbNewLine + ddd
            Else

                sss = "public static DataTable Dt_" + txtName.Text + " = new DataTable();" + vbNewLine +
                         "public static void Load_" + txtName.Text + "(" + Prametre + "){" + vbNewLine +
                         "Dt_" + txtName.Text + ".Clear();" + vbNewLine +
                         "try{" + vbNewLine
                ddd = " if(Sqlcon.State == ConnectionState.Open) Sqlcon.Close();" + vbNewLine +
                           " Sqlcon.Open();" + vbNewLine +
                           " Dt_" + txtName.Text + ".Load(cmd.ExecuteReader());" + vbNewLine +
                           " Sqlcon.Close();" + vbNewLine +
                           " cmd = null;" + vbNewLine +
                           " }catch(Exception ex ){" + vbNewLine +
                           " Sqlcon.Close();" + vbNewLine +
                           " //MessageBox.Show(ex.Message);" + vbNewLine +
                           "}" + vbNewLine +
                           "}"

                txtCode.Text = sss +
                 "SqlCommand cmd = new SqlCommand("" SELECT " + Sel + " FROM " + DGVTable.CurrentRow.Cells(0).Value + where + " "",Sqlcon);"
                For x = 0 To DGVColumn.Rows.Count - 1
                    If DGVColumn.Rows(x).Cells(4).Value = True Then
                        txtCode.Text += vbNewLine + "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + CHGetSql_SType(DGVColumn.Rows(x).Cells(1).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + " ;"
                    End If
                Next
                txtCode.Text += vbNewLine + ddd
            End If
            '---------------------------------------------------------------------------------------------------------------------------------------

            '---------------------------------------------------------------------------------------------------------------------------------------
            If Group.Length > 0 Then
                Group += vbNewLine
            End If
            If orderby.Length > 0 Then
                orderby += vbNewLine
            End If
            txtCheckProcedureCode.Text = " IF OBJECT_ID('" + fff + "') Is Not  NULL " + vbNewLine +
                                         " DROP PROC " + fff + "" + vbNewLine

            txtAddprocedure.Text = " CREATE PROCEDURE " + fff + vbNewLine +
                wherepor +
                " AS " + vbNewLine +
                " BEGIN " + vbNewLine +
                "  SELECT " + Sel + vbNewLine +
                "  FROM " + DGVTable.CurrentRow.Cells(0).Value + vbNewLine +
                 where + " " +
                 Group +
                 orderby +
                " END"
            If languge = "vb" Then
                txtCodeStore.Text = sss +
                              "Dim cmd = new SqlCommand(""" + fff + " " + prameterofpro + " "",Sqlcon)"

                For x = 0 To DGVColumn.Rows.Count - 1
                    If DGVColumn.Rows(x).Cells(4).Value = True Then
                        txtCodeStore.Text += vbNewLine +
                            "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + DGVColumn.Rows(x).Cells(1).Value + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + ""
                    End If
                Next
                txtCodeStore.Text += vbNewLine + ddd
            Else
                txtCodeStore.Text = sss +
                             "SqlCommand cmd = new SqlCommand(""" + fff + " " + prameterofpro + " "",Sqlcon);"

                For x = 0 To DGVColumn.Rows.Count - 1
                    If DGVColumn.Rows(x).Cells(4).Value = True Then
                        txtCodeStore.Text += vbNewLine +
                            "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + CHGetSql_SType(DGVColumn.Rows(x).Cells(1).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + " ;"
                    End If
                Next
                txtCodeStore.Text += vbNewLine + ddd

            End If
            _change = "select"
        Catch ex As Exception

        End Try
    End Sub
    Sub edit(txt As String)

        'For Each lin In txt.Split(vbNewLine)
        '    lin = "   " + lin
        'Next

    End Sub
    Dim _change As String = ""
    Private Sub HjgToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HjgToolStripMenuItem.Click
        Try
            If MetroTabControl1.SelectedIndex = 0 Then
                If txtCode.SelectionLength = 0 Then
                    My.Computer.Clipboard.SetText(txtCode.Text)
                Else
                    My.Computer.Clipboard.SetText(txtCode.SelectedText)
                End If
            Else
                If txtCodeStore.SelectionLength = 0 Then
                    My.Computer.Clipboard.SetText(txtCodeStore.Text)
                Else
                    My.Computer.Clipboard.SetText(txtCodeStore.SelectedText)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        If MetroFramework.MetroMessageBox.Show(Me, "You want save Procdure ? ", "Run", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, 100) <> Windows.Forms.DialogResult.OK Then Return
        lbMsg.Visible = True
        lbMsg.Text = "Run..."
        If txtAddprocedure.Text = "" Or txtCheckProcedureCode.Text = "" Then Return
        Try
            RunStoredProcdure(txtAddprocedure.Text, txtCheckProcedureCode.Text)
            lbMsg.Text = "Run Successfully"
        Catch ex As Exception
            lbMsg.Visible = False
            Sqlcon.Close()
            MetroFramework.MetroMessageBox.Show(Me, "Error : " + ex.Message, "Run", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Try
            ClearText()
            Dim colomun As String = ""
            Dim prametr As String = ""
            Dim value As String = ""
            Dim AddParameters As String = ""
            Dim wherepor As String = ""
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(3).Value = True Then
                    colomun += DGVColumn.Rows(x).Cells(0).Value + ", "
                    If languge = "vb" Then
                        prametr += " ByVal " + DGVColumn.Rows(x).Cells(0).Value + " As " + vbGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + ", "
                        AddParameters += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + DGVColumn.Rows(x).Cells(1).Value + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + "" + vbNewLine

                    Else
                        prametr += CHGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + " " + DGVColumn.Rows(x).Cells(0).Value + ", "
                        AddParameters += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + CHGetSql_SType(DGVColumn.Rows(x).Cells(1).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + " ;" + vbNewLine

                    End If
                    value += "@" + DGVColumn.Rows(x).Cells(0).Value + ", "

                    If DGVColumn.Rows(x).Cells(2).Value = "" Then
                        If DGVColumn.Rows(x).Cells(1).Value.ToString = "decimal" Or DGVColumn.Rows(x).Cells(1).Value.ToString = "numeric" Then
                            wherepor += "@" + DGVColumn.Rows(x).Cells(0).Value + "  " + DGVColumn.Rows(x).Cells(1).Value + "(" + DGVColumn.Rows(x).Cells(7).Value + "," + DGVColumn.Rows(x).Cells(8).Value + ") = Null , " + vbNewLine
                        Else
                            wherepor += " @" + DGVColumn.Rows(x).Cells(0).Value + " " + DGVColumn.Rows(x).Cells(1).Value + " = Null  , " + vbNewLine

                        End If
                    Else
                        If DGVColumn.Rows(x).Cells(2).Value = -1 And (DGVColumn.Rows(x).Cells(1).Value.ToString = "varchar" Or DGVColumn.Rows(x).Cells(1).Value.ToString = "varbinary" Or DGVColumn.Rows(x).Cells(1).Value.ToString = "nvarchar") Then
                            wherepor += "@" + DGVColumn.Rows(x).Cells(0).Value + "  " + DGVColumn.Rows(x).Cells(1).Value + "(MAX) = Null , " + vbNewLine
                        Else
                            If DGVColumn.Rows(x).Cells(2).Value > 0 Then
                                If DGVColumn.Rows(x).Cells(1).Value.ToString = "image" Or DGVColumn.Rows(x).Cells(1).Value.ToString = "text" Or DGVColumn.Rows(x).Cells(1).Value.ToString = "hierarchyid" Then
                                    wherepor += " @" + DGVColumn.Rows(x).Cells(0).Value + " " + DGVColumn.Rows(x).Cells(1).Value + " = Null  , " + vbNewLine
                                Else
                                    wherepor += "@" + DGVColumn.Rows(x).Cells(0).Value + "  " + DGVColumn.Rows(x).Cells(1).Value + "(" + DGVColumn.Rows(x).Cells(2).Value + ") = Null , " + vbNewLine

                                End If
                            End If
                        End If
                    End If
                End If
            Next
            Try
                colomun = colomun.Remove(colomun.Length - 2)
                prametr = prametr.Remove(prametr.Length - 2)
                value = value.Remove(value.Length - 2)
                wherepor = wherepor.Remove(wherepor.Length - 4)
            Catch ex As Exception
                txtCode.Clear()
            End Try
            If languge = "vb" Then
                txtCode.Text = "Sub Insert_Into_" + txtName.Text + "( " + prametr + " )" + vbNewLine +
              " Try" + vbNewLine +
              "" + " Dim cmd As New SqlCommand(""Insert Into " + DGVTable.CurrentRow.Cells(0).Value + " (" + colomun + ") Values(" + value + ") ;"",Sqlcon)" + vbNewLine +
              "" + "" + AddParameters + " IF Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()" + vbNewLine +
              "Sqlcon.Open()" + vbNewLine +
              "cmd.ExecuteNonQuery()" + vbNewLine +
              "Sqlcon.close()" + vbNewLine +
              "MessageBox.Show(""Insert successfully"")" + vbNewLine +
              " Catch ex As Exception" + vbNewLine +
              "Sqlcon.close()" + vbNewLine +
              "" + "MessageBox.Show(ex.Message + ""Insert Not successfully"" )" + vbNewLine +
              " End Try" + vbNewLine +
              " End Sub"
                txtCodeStore.Text = "public sub Insert_Into_" + txtName.Text + "(" + prametr + ")" + vbNewLine +
               "Try" + vbNewLine +
               "" + "Dim cmd As New SqlCommand(""Insert_Into_" + txtName.Text + " " + value + " ;"",Sqlcon)" + vbNewLine +
               "" + "" + AddParameters + " IF Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()" + vbNewLine +
               " Sqlcon.Open()" + vbNewLine +
               " cmd.ExecuteNonQuery()" + vbNewLine +
               " Sqlcon.close()" + vbNewLine +
               " MessageBox.Show(""Insert successfully"")" + vbNewLine +
               " Catch ex As Exception" + vbNewLine +
               " Sqlcon.close()" + vbNewLine +
               "" + "MessageBox.Show(ex.Message + ""Insert Not successfully"" )" + vbNewLine +
               " End Try" + vbNewLine +
               " End Sub"
            Else
                txtCode.Text = "public static void Insert_Into_" + txtName.Text + "( " + prametr + " ){" + vbNewLine +
                " try{" + vbNewLine +
              " SqlCommand cmd = new SqlCommand(""Insert Into " + DGVTable.CurrentRow.Cells(0).Value + " (" + colomun + ") Values(" + value + ") ;"",Sqlcon) ;" + vbNewLine +
               AddParameters + " if(Sqlcon.State == ConnectionState.Open) Sqlcon.Close();" + vbNewLine +
              "Sqlcon.Open();" + vbNewLine +
              "cmd.ExecuteNonQuery();" + vbNewLine +
              "Sqlcon.Close();" + vbNewLine +
              "//MessageBox.Show(""Insert successfully"");" + vbNewLine +
              "}catch(Exception ex){ " + vbNewLine +
              "Sqlcon.Close();" + vbNewLine +
               "//MessageBox.Show(ex.Message + ""Insert Not successfully"" );" + vbNewLine +
              "}" + vbNewLine +
              "}"
                txtCodeStore.Text = "public static void Insert_Into_" + txtName.Text + "(" + prametr + "){" + vbNewLine +
               " try{" + vbNewLine +
               "SqlCommand cmd = new SqlCommand(""Insert_Into_" + txtName.Text + " " + value + " ;"",Sqlcon);" + vbNewLine +
                 AddParameters + " if(Sqlcon.State == ConnectionState.Open); Sqlcon.Close();" + vbNewLine +
               " Sqlcon.Open();" + vbNewLine +
               " cmd.ExecuteNonQuery();" + vbNewLine +
               " Sqlcon.Close();" + vbNewLine +
               " //MessageBox.Show(""Insert successfully"");" + vbNewLine +
              "}catch(Exception ex){ " + vbNewLine +
              "Sqlcon.Close();" + vbNewLine +
               "//MessageBox.Show(ex.Message + ""Insert Not successfully"" );" + vbNewLine +
              "}" + vbNewLine +
              "}"
            End If

            '_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
            txtCheckProcedureCode.Text = " IF OBJECT_ID('Insert_Into_" + txtName.Text + "') Is Not NULL" + vbNewLine +
                                       " DROP PROC Insert_Into_" + txtName.Text + "" + vbNewLine

            txtAddprocedure.Text = " CREATE PROCEDURE Insert_Into_" + txtName.Text + vbNewLine +
                " " + wherepor + vbNewLine +
                " AS" + vbNewLine +
                " BEGIN" + vbNewLine +
                "  INSERT INTO " + DGVTable.CurrentRow.Cells(0).Value + " (" + colomun + ") VALUES(" + value + ") ;" + vbNewLine +
                " End"



            _change = "insert"
            edit(txtCode.Text)
            edit(txtCheckProcedureCode.Text)
            edit(txtCodeStore.Text)
            edit(txtCodeStore.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ChSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChSelectAll.CheckedChanged
        Try
            For row = 0 To DGVColumn.Rows.Count - 1
                DGVColumn.Rows(row).Cells(3).Value = ChSelectAll.Checked
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            ClearText()
            Dim colomun As String = ""
            Dim AddParametersproc As String = ""
            Dim wherepor As String = ""
            Dim prameterofpro = ""
            Dim prametersub = ""
            Dim prametersubin = ""
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(3).Value = True Then
                    colomun += DGVColumn.Rows(x).Cells(0).Value + "=@" + DGVColumn.Rows(x).Cells(0).Value + ", "
                    If languge = "vb" Then
                        AddParametersproc += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + DGVColumn.Rows(x).Cells(1).Value + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + "" + vbNewLine
                        prametersub += "ByVal " + DGVColumn.Rows(x).Cells(0).Value + " As " + vbGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + " , "

                    Else
                        AddParametersproc += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + CHGetSql_SType(DGVColumn.Rows(x).Cells(1).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + " ;" + vbNewLine
                        prametersub += CHGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + "  " + DGVColumn.Rows(x).Cells(0).Value + " , "

                    End If
                    If DGVColumn.Rows(x).Cells(2).Value = "" Then
                        prameterofpro += "@" + DGVColumn.Rows(x).Cells(0).Value + " " + DGVColumn.Rows(x).Cells(1).Value + "=Null , " + vbNewLine
                    Else
                        prameterofpro += "@" + DGVColumn.Rows(x).Cells(0).Value + "  " + DGVColumn.Rows(x).Cells(1).Value + "(" + DGVColumn.Rows(x).Cells(2).Value + ")=Null , " + vbNewLine
                    End If
                    prametersubin += "@" + DGVColumn.Rows(x).Cells(0).Value + " , "
                End If
            Next
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(4).Value = True Then
                    If languge = "vb" Then
                        prametersub += " ByVal " + DGVColumn.Rows(x).Cells(0).Value + "_pre As " + vbGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + " , "
                        AddParametersproc += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + "_pre"", SqlDbType." + DGVColumn.Rows(x).Cells(1).Value + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + "_pre " + vbNewLine
                    Else
                        prametersub += CHGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + " " + DGVColumn.Rows(x).Cells(0).Value + "_pre  , "
                        AddParametersproc += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + "_pre"", SqlDbType." + CHGetSql_SType(DGVColumn.Rows(x).Cells(1).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + "_pre ;" + vbNewLine
                    End If
                    wherepor += DGVColumn.Rows(x).Cells(0).Value + "=@" + DGVColumn.Rows(x).Cells(0).Value + "_pre And "
                    prametersubin += "@" + DGVColumn.Rows(x).Cells(0).Value + "_pre , "
                    If DGVColumn.Rows(x).Cells(2).Value = "" Then
                        prameterofpro += " @" + DGVColumn.Rows(x).Cells(0).Value + "_pre " + DGVColumn.Rows(x).Cells(1).Value + "= NULL , " + vbNewLine
                    Else
                        prameterofpro += " @" + DGVColumn.Rows(x).Cells(0).Value + "_pre  " + DGVColumn.Rows(x).Cells(1).Value + "(" + DGVColumn.Rows(x).Cells(2).Value + ")= NULL , " + vbNewLine
                    End If
                End If
            Next

            If prametersub.Length > 0 Then
                prametersub = prametersub.Remove(prametersub.Length - 2)
            End If
            If wherepor.Length > 0 Then
                wherepor = wherepor.Remove(wherepor.Length - 4)
                wherepor = "WHERE " + wherepor
            End If
            If colomun.Length > 0 Then
                colomun = colomun.Remove(colomun.Length - 2)
            End If
            If prametersubin.Length > 0 Then
                prametersubin = prametersubin.Remove(prametersubin.Length - 2)
            End If
            If prameterofpro.Length > 0 Then
                prameterofpro = prameterofpro.Remove(prameterofpro.Length - 4)
            End If

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            If languge = "vb" Then
                txtCode.Text = " Sub Update_" + txtName.Text + "(" + prametersub + ")" + vbNewLine +
                   " Try" + vbNewLine +
                   "" + "   Dim cmd As New SqlCommand(""UPDATE " + DGVTable.CurrentRow.Cells(0).Value + " SET " + colomun + " " + wherepor + "  ;"", Sqlcon)" + vbNewLine +
                   "" + "" + AddParametersproc + " IF Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()" + vbNewLine +
                   "  Sqlcon.Open()" + vbNewLine +
                   "  cmd.ExecuteNonQuery()" + vbNewLine +
                   "  Sqlcon.close()" + vbNewLine +
                   "  MessageBox.Show(""Update successfully"")" + vbNewLine +
                   " Catch ex As Exception" + vbNewLine +
                   "     Sqlcon.close()" + vbNewLine +
                   "     MessageBox.Show(ex.Message + ""Update Not successfully"" )" + vbNewLine +
                   " End Try" + vbNewLine +
                   " End Sub"

                txtCodeStore.Text = "Sub Update_" + txtName.Text + "(" + prametersub + ")" + vbNewLine +
                " Try" + vbNewLine +
                "Dim cmd As New SqlCommand(""Update_" + txtName.Text + " " + prametersubin + " "", Sqlcon)" + vbNewLine +
                AddParametersproc +
                " IF Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()" + vbNewLine +
                "  Sqlcon.Open()" + vbNewLine +
                "  cmd.ExecuteNonQuery()" + vbNewLine +
                "  Sqlcon.close()" + vbNewLine +
                "  MessageBox.Show(""Update successfully"")" + vbNewLine +
                " Catch ex As Exception" + vbNewLine +
                "   Sqlcon.close()" + vbNewLine +
                "   MessageBox.Show(ex.Message + ""Update Not successfully"" )" + vbNewLine +
                " End Try" + vbNewLine +
                " End Sub"
            Else

                txtCode.Text = "public static void Update_" + txtName.Text + "(" + prametersub + "){" + vbNewLine +
                   " try{" + vbNewLine +
                " SqlCommand cmd = new SqlCommand(""UPDATE " + DGVTable.CurrentRow.Cells(0).Value + " SET " + colomun + " " + wherepor + "  ;"", Sqlcon) ;" + vbNewLine +
                   AddParametersproc + " if(Sqlcon.State == ConnectionState.Open) " + vbNewLine + "Sqlcon.Close();" + vbNewLine +
                   "  Sqlcon.Open();" + vbNewLine +
                   "  cmd.ExecuteNonQuery();" + vbNewLine +
                   "  Sqlcon.Close();" + vbNewLine +
                   "  //MessageBox.Show(""Update successfully"");" + vbNewLine +
                  "}catch(Exception ex){ " + vbNewLine +
                    "Sqlcon.Close();" + vbNewLine +
                     "//MessageBox.Show(ex.Message + ""Insert Not successfully"" );" + vbNewLine +
                     "}" + vbNewLine +
                    "}"
                txtCodeStore.Text = "public static void Update_" + txtName.Text + "(" + prametersub + "){" + vbNewLine +
                " try{" + vbNewLine +
                "SqlCommand cmd = new SqlCommand(""Update_" + txtName.Text + " " + prametersubin + " "", Sqlcon);" + vbNewLine +
                AddParametersproc +
                " if(Sqlcon.State == ConnectionState.Open);  Sqlcon.Close();" + vbNewLine +
                "  Sqlcon.Open();" + vbNewLine +
                "  cmd.ExecuteNonQuery();" + vbNewLine +
                "  Sqlcon.Close();" + vbNewLine +
                "  //MessageBox.Show(""Update successfully"");" + vbNewLine +
                " }catch(Exception ex){ " + vbNewLine +
                " Sqlcon.Close();" + vbNewLine +
                "//MessageBox.Show(ex.Message + ""Insert Not successfully"" );" + vbNewLine +
                "}" + vbNewLine +
                "}"
            End If

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            txtCheckProcedureCode.Text = " IF OBJECT_ID('Update_" + txtName.Text + "') is not null " + vbNewLine +
                                              " Drop Proc Update_" + txtName.Text + "" + vbNewLine
            txtAddprocedure.Text = " CREATE PROCEDURE Update_" + txtName.Text + "  " + vbNewLine +
                    prameterofpro + vbNewLine +
                    " AS " + vbNewLine +
                    " Begin" + vbNewLine +
                    "  Update " + DGVTable.CurrentRow.Cells(0).Value + vbNewLine +
                    " SET " + colomun + vbNewLine +
                      wherepor + "  ;" + vbNewLine +
                    " End"


            _change = "update"
            edit(txtCode.Text)
            edit(txtCheckProcedureCode.Text)
            edit(txtCodeStore.Text)
            edit(txtCodeStore.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            ClearText()
            Dim prametr As String = ""
            Dim Where As String = ""
            Dim AddParameters As String = ""
            Dim prameterofpro As String = ""
            Dim wherepor As String = ""
            Dim Selcont = 0
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(4).Value = True Then
                    Selcont = 1
                    Where += DGVColumn.Rows(x).Cells(0).Value + "=@" + DGVColumn.Rows(x).Cells(0).Value + " And "
                    If languge = "vb" Then
                        prametr += "ByVal " + DGVColumn.Rows(x).Cells(0).Value + " As " + vbGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + ", "
                        AddParameters += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + DGVColumn.Rows(x).Cells(1).Value + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + "" + vbNewLine
                    Else
                        prametr += CHGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + " " + DGVColumn.Rows(x).Cells(0).Value + ", "
                        AddParameters += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + CHGetSql_SType(DGVColumn.Rows(x).Cells(1).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + ";" + vbNewLine
                    End If
                    prameterofpro += "@" + DGVColumn.Rows(x).Cells(0).Value + " , "
                    If DGVColumn.Rows(x).Cells(2).Value = "" Then
                        wherepor += " @" + DGVColumn.Rows(x).Cells(0).Value + " " + DGVColumn.Rows(x).Cells(1).Value + " = Null  ," + vbNewLine
                    Else
                        wherepor += " @" + DGVColumn.Rows(x).Cells(0).Value + "  " + DGVColumn.Rows(x).Cells(1).Value + "(" + DGVColumn.Rows(x).Cells(2).Value + ") = Null ," + vbNewLine
                    End If
                End If
            Next
            Try
                prametr = prametr.Remove(prametr.Length - 2)
                wherepor = wherepor.Remove(wherepor.Length - 4)
                prameterofpro = prameterofpro.Remove(prameterofpro.Length - 2)
                Where = Where.Remove(Where.Length - 4)
            Catch ex As Exception
                '   MsgBox(ex.Message)
            End Try
            If Selcont = 1 Then
                Where = " Where " + Where
            Else
                Where = " "
            End If
            If languge = "vb" Then
                txtCode.Text = " Sub Delete_" + txtName.Text + "( " + prametr + " )" + vbNewLine +
                            " Try " + vbNewLine +
                           " Dim cmd As New SqlCommand("" Delete From " + DGVTable.CurrentRow.Cells(0).Value + Where + " ;"", Sqlcon)" + vbNewLine +
                             AddParameters + " IF Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()" + vbNewLine +
                            "Sqlcon.Open()" + vbNewLine +
                            "cmd.ExecuteNonQuery()" + vbNewLine +
                            "Sqlcon.close()" + vbNewLine +
                            "MessageBox.Show(""Delete successfully"")" + vbNewLine +
                            " Catch ex As Exception" + vbNewLine +
                            "  Sqlcon.close()" + vbNewLine +
                            "  MessageBox.Show(ex.Message + ""Delete Not successfully"")" + vbNewLine +
                            " End Try" + vbNewLine +
                            " End Sub"
                txtCodeStore.Text = " Sub Delete_" + txtName.Text + "( " + prametr + " )" + vbNewLine +
                             "Try" + vbNewLine +
                              "Dim cmd As New SqlCommand(""Delete_" + txtName.Text + " " + prameterofpro + " ;"", Sqlcon)" + vbNewLine +
                               AddParameters +
                               "If Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()" + vbNewLine +
                              "Sqlcon.Open()" + vbNewLine +
                              "cmd.ExecuteNonQuery()" + vbNewLine +
                              "Sqlcon.close()" + vbNewLine +
                              "MessageBox.Show(""Delete successfully"")" + vbNewLine +
                              "Catch ex As Exception" + vbNewLine +
                              "Sqlcon.close()" + vbNewLine +
                              "MessageBox.Show(ex.Message + "" Delete Not successfully"")" + vbNewLine +
                              "End Try" + vbNewLine +
                              "End Sub"
            Else
                txtCode.Text = "public static void Delete_" + txtName.Text + "( " + prametr + " ){" + vbNewLine +
                          " try{ " + vbNewLine +
                         " SqlCommand cmd = new SqlCommand("" Delete From " + DGVTable.CurrentRow.Cells(0).Value + Where + " ;"", Sqlcon) ;" + vbNewLine +
                           AddParameters + " if(Sqlcon.State == ConnectionState.Open) Sqlcon.Close();" + vbNewLine +
                          "Sqlcon.Open();" + vbNewLine +
                          "cmd.ExecuteNonQuery();" + vbNewLine +
                          "Sqlcon.Close();" + vbNewLine +
                          "//MessageBox.Show(""Delete successfully"");" + vbNewLine +
                            "}catch(Exception ex){ " + vbNewLine +
                            "Sqlcon.Close();" + vbNewLine +
                            "//MessageBox.Show(ex.Message + ""Insert Not successfully"" );" + vbNewLine +
                            "}" + vbNewLine +
                            "}"
                txtCodeStore.Text = "public static void Delete_" + txtName.Text + "( " + prametr + " ){" + vbNewLine +
                          " try{ " + vbNewLine +
                           "SqlCommand cmd = new SqlCommand(""Delete_" + txtName.Text + " " + prameterofpro + " ;"", Sqlcon);" + vbNewLine +
                            AddParameters +
                          " if(Sqlcon.State == ConnectionState.Open) " + vbNewLine + "Sqlcon.Close();" + vbNewLine +
                          "Sqlcon.Open();" + vbNewLine +
                          "cmd.ExecuteNonQuery();" + vbNewLine +
                          "Sqlcon.Close();" + vbNewLine +
                          "//MessageBox.Show(""Delete successfully"");" + vbNewLine +
                            "}catch(Exception ex){ " + vbNewLine +
                            "Sqlcon.Close();" + vbNewLine +
                            "//MessageBox.Show(ex.Message + ""Insert Not successfully"" );" + vbNewLine +
                            "}" + vbNewLine +
                            "}"

            End If

            txtCheckProcedureCode.Text = " IF OBJECT_ID('Delete_" + txtName.Text + "') IS NOT NULL " + vbNewLine +
                                           " DROP PROC Delete_" + txtName.Text + "" + vbNewLine
            txtAddprocedure.Text = " CREATE PROCEDURE Delete_" + txtName.Text + "  " + vbNewLine +
                    wherepor + vbNewLine +
                    " AS " + vbNewLine +
                    " Begin" + vbNewLine +
                    " Delete From " + DGVTable.CurrentRow.Cells(0).Value + Where + " ;" + vbNewLine +
                    " End"


            _change = "delete"
            edit(txtCode.Text)
            edit(txtCheckProcedureCode.Text)
            edit(txtCodeStore.Text)
            edit(txtCodeStore.Text)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FontToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.ShowDialog()
        txtCode.Font = FontDialog1.Font
        txtAddprocedure.Font = FontDialog1.Font
        txtCheckProcedureCode.Font = FontDialog1.Font
        txtCodeStore.Font = FontDialog1.Font
        My.Settings.txtFont = FontDialog1.Font
    End Sub

    Private Sub ForeColoreToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ForeColoreToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        txtAddprocedure.ForeColor = ColorDialog1.Color
        txtCheckProcedureCode.ForeColor = ColorDialog1.Color
        txtCode.ForeColor = ColorDialog1.Color
        txtCodeStore.ForeColor = ColorDialog1.Color
        My.Settings.txtForeColor = ColorDialog1.Color
    End Sub

    Private Sub BackGroundColorToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BackGroundColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        txtAddprocedure.BackColor = ColorDialog1.Color
        txtCheckProcedureCode.BackColor = ColorDialog1.Color
        txtCode.BackColor = ColorDialog1.Color
        txtCodeStore.BackColor = ColorDialog1.Color
        My.Settings.txtBackColor = ColorDialog1.Color
    End Sub

    Private Sub btnAoutoCmplete_Click(sender As Object, e As EventArgs) Handles btnAoutoCmplete.Click
        Try
            ClearText()
            Dim cont = 0
            Dim where = ""
            Dim Sel = ""
            Dim Prametre = ""
            Dim wherepor = ""
            Dim prameterofpro = ""
            Dim Selcont = 0
            Dim colomnname = ""
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(3).Value = True Then
                    Selcont += 1
                End If
            Next
            If Selcont > 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "You Can Select Only One Column", "Aouto Cmplete", MessageBoxButtons.OK, MessageBoxIcon.Information, 60)
                Exit Sub
            End If
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(4).Value = True Then
                    cont += 1
                    Prametre += DGVColumn.Rows(x).Cells(0).Value + " As " + vbGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + ",  "
                    where += " " + DGVColumn.Rows(x).Cells(0).Value + " =@" + DGVColumn.Rows(x).Cells(0).Value + " And "
                    prameterofpro += "@" + DGVColumn.Rows(x).Cells(0).Value + " , "
                    If DGVColumn.Rows(x).Cells(2).Value = "" Then
                        wherepor += " @" + DGVColumn.Rows(x).Cells(0).Value + " " + DGVColumn.Rows(x).Cells(1).Value + " = Null  , " + vbNewLine
                    Else
                        wherepor += " @" + DGVColumn.Rows(x).Cells(0).Value + "  " + DGVColumn.Rows(x).Cells(1).Value + "(" + DGVColumn.Rows(x).Cells(2).Value + ") = Null , " + vbNewLine
                    End If
                End If
            Next

            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(3).Value = True Then
                    Sel += DGVColumn.Rows(x).Cells(0).Value
                End If
            Next
            If cont >= 1 Then
                where = " WHERE " + where
            End If
            If Prametre.Length > 0 Then
                Prametre = Prametre.Remove(Prametre.Length - 2)
            End If
            If where.Length > 0 Then
                where = where.Remove(where.Length - 4)
            End If
            If wherepor.Length > 0 Then
                wherepor = wherepor.Remove(wherepor.Length - 4)
            End If
            If prameterofpro.Length > 0 Then
                prameterofpro = prameterofpro.Remove(prameterofpro.Length - 2)
            End If
            _change = "AoutComplet"
            txtCode.Text = "Public Sub AoutComplet_" + txtName.Text + "(" + Prametre + " ByVal txtbox As TextBox)" + vbNewLine +
                "txtbox.Clear()" + vbNewLine +
                "Try" + vbNewLine +
                 "txtbox.AutoCompleteSource = AutoCompleteSource.CustomSource" + vbNewLine +
                 "txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend" + vbNewLine +
                 "Dim cmd = New SqlCommand(""SELECT " + Sel + " FROM " + DGVTable.CurrentRow.Cells(0).Value + where + " "",Sqlcon)"
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(4).Value = True Then
                    txtCode.Text += vbNewLine + "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + DGVColumn.Rows(x).Cells(1).Value + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + ""
                End If
            Next
            txtCode.Text += vbNewLine + "Dim Dt As New DataTable" + vbNewLine +
                    "IF Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()" + vbNewLine +
                    "Sqlcon.Open()" + vbNewLine +
                    "Dt.Load(cmd.ExecuteReader())" + vbNewLine +
                    "Dim drow As DataRow" + vbNewLine +
                    "txtbox.AutoCompleteCustomSource.Clear()" + vbNewLine +
                    "For Each drow In dt.Rows" + vbNewLine +
                    "txtbox.AutoCompleteCustomSource.Add(drow.Item(""" + Sel + """).ToString)" + vbNewLine +
                    "Next" + vbNewLine +
                    "Sqlcon.Close()" + vbNewLine +
                    "cmd = Nothing" + vbNewLine +
                    "Catch ex As Exception" + vbNewLine +
                    "Sqlcon.Close()" + vbNewLine +
                    "MessageBox.Show(ex.Message)" + vbNewLine +
                    "End Try" + vbNewLine +
                    "End Sub"

            txtCheckProcedureCode.Text = "IF OBJECT_ID('AoutComplet_" + txtName.Text + "') Is Not  NULL " + vbNewLine +
                                             "DROP PROC AoutComplet_" + txtName.Text + "" + vbNewLine
            If Not where = "" Then
                where += vbNewLine
            End If
            If Not wherepor = "" Then
                wherepor += vbNewLine
            End If
            txtAddprocedure.Text = "CREATE PROCEDURE AoutComplet_" + txtName.Text + vbNewLine +
                    wherepor +
                    "AS " + vbNewLine +
                    "BEGIN " + vbNewLine +
                    "  SELECT " + Sel + vbNewLine +
                    "  FROM " + DGVTable.CurrentRow.Cells(0).Value + vbNewLine +
                     where +
                    "END"

            txtCodeStore.Text = "Public Sub AoutComplet_" + txtName.Text + "(" + Prametre + " ByVal txtbox As TextBox)" + vbNewLine +
                "txtbox.Clear()" + vbNewLine +
                "Try" +
                "Dim cmd = New SqlCommand(""AoutComplet_" + txtName.Text + " " + prameterofpro + " "",Sqlcon)"

            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(4).Value = True Then
                    txtCodeStore.Text += vbNewLine +
                        "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + DGVColumn.Rows(x).Cells(1).Value + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + ""
                End If
            Next

            txtCodeStore.Text += vbNewLine + "Dim Dt As New DataTable" + vbNewLine +
                "If Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()" + vbNewLine +
                "Sqlcon.Open()" + vbNewLine +
                "Dt.Load(cmd.ExecuteReader())" + vbNewLine +
                "Dim drow As DataRow" + vbNewLine +
                "txtbox.AutoCompleteCustomSource.Clear()" + vbNewLine +
                "For Each drow In dt.Rows" + vbNewLine +
                "txtbox.AutoCompleteCustomSource.Add(drow.Item(""" + Sel + """).ToString)" + vbNewLine +
                "Next" + vbNewLine +
                "Sqlcon.Close()" + vbNewLine +
                "cmd = Nothing" + vbNewLine +
                "Catch ex As Exception" + vbNewLine + "Sqlcon.Close()" + vbNewLine +
                "MessageBox.Show(ex.Message)" + vbNewLine +
                "End Try" + vbNewLine +
                "End Sub"
            edit(txtCode.Text)
            edit(txtCheckProcedureCode.Text)
            edit(txtCodeStore.Text)
            edit(txtCodeStore.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnFillcomboBox_Click(sender As Object, e As EventArgs) Handles btnFillcomboBox.Click
        Try
        ClearText()
        Dim cont = 0
        Dim where = ""
        Dim Sel = ""
        Dim Prametre = ""
        Dim wherepor = ""
        Dim prameterofpro = ""
        Dim Selcont = 0
        Dim colomnname = ""
        For x = 0 To DGVColumn.Rows.Count - 1
            If DGVColumn.Rows(x).Cells(3).Value = True Then
                Selcont += 1
            End If
        Next
            If Selcont < 1 Then
                MetroFramework.MetroMessageBox.Show(Me, "You Can just Select Tow Column", "FillcomboBox", MessageBoxButtons.OK, MessageBoxIcon.Information, 60)
                Exit Sub
            End If
        For x = 0 To DGVColumn.Rows.Count - 1
            If DGVColumn.Rows(x).Cells(4).Value = True Then
                cont += 1
                If languge = "vb" Then
                    Prametre += DGVColumn.Rows(x).Cells(0).Value + " As " + vbGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + " ,  "
                Else
                    Prametre += CHGetSql_Type(DGVColumn.Rows(x).Cells(1).Value) + " " + DGVColumn.Rows(x).Cells(0).Value + " ,  "

                End If
                where += " " + DGVColumn.Rows(x).Cells(0).Value + " =@" + DGVColumn.Rows(x).Cells(0).Value + " And "
                prameterofpro += "@" + DGVColumn.Rows(x).Cells(0).Value + " , "
                If DGVColumn.Rows(x).Cells(2).Value = "" Then
                    wherepor += " @" + DGVColumn.Rows(x).Cells(0).Value + " " + DGVColumn.Rows(x).Cells(1).Value + " = Null  , " + vbNewLine
                Else
                    wherepor += " @" + DGVColumn.Rows(x).Cells(0).Value + "  " + DGVColumn.Rows(x).Cells(1).Value + "(" + DGVColumn.Rows(x).Cells(2).Value + ") = Null , " + vbNewLine
                End If
            End If
        Next

        For x = 0 To DGVColumn.Rows.Count - 1
            If DGVColumn.Rows(x).Cells(3).Value = True Then
                Sel += DGVColumn.Rows(x).Cells(0).Value + " , "
            End If
        Next
        If cont >= 1 Then
            where = " WHERE " + where
        End If
        If Prametre.Length > 0 Then
            Prametre = Prametre.Remove(Prametre.Length - 2)
        End If
        If where.Length > 0 Then
            where = where.Remove(where.Length - 4)
        End If
        If wherepor.Length > 0 Then
            wherepor = wherepor.Remove(wherepor.Length - 4)
        End If
        If prameterofpro.Length > 0 Then
            prameterofpro = prameterofpro.Remove(prameterofpro.Length - 2)
        End If
        If Sel.Length > 0 Then
            Sel = Sel.Remove(Sel.Length - 2)
        End If
        If languge = "vb" Then
            txtCode.Text = "Public Sub FillCompoBox_" + txtName.Text + "(" + Prametre + " ByVal cmb As ComboBox)" + vbNewLine +
           "Try" + vbNewLine +
            "cmb.AutoCompleteSource = AutoCompleteSource.CustomSource" + vbNewLine +
            "Dim cmd = New SqlCommand(""SELECT " + Sel + " FROM " + DGVTable.CurrentRow.Cells(0).Value + where + " "",Sqlcon)"
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(4).Value = True Then
                    txtCode.Text += vbNewLine + "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + DGVColumn.Rows(x).Cells(1).Value + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + ""
                End If
            Next
                txtCode.Text += vbNewLine + "Dim Dt As New DataTable" + vbNewLine +
                        "IF Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()" + vbNewLine +
                        "Sqlcon.Open()" + vbNewLine +
                        "Dt.Load(cmd.ExecuteReader())" + vbNewLine +
                        "Sqlcon.Close()" + vbNewLine +
                        "cmd = Nothing" + vbNewLine +
                        "cmb.DataSource = Dt" + vbNewLine +
                        "cmb.ValueMember = Dt.Columns(0).ColumnName" + vbNewLine
                If Selcont = 1 Then
                    txtCode.Text += "cmb.DisplayMember =Dt.Columns(0).ColumnName" + vbNewLine
                Else
                    txtCode.Text += "cmb.DisplayMember =Dt.Columns(1).ColumnName" + vbNewLine
                End If
            txtCode.Text +=
                    "Catch ex As Exception" + vbNewLine +
                    "MessageBox.Show(ex.Message)" + vbNewLine +
                    "End Try" + vbNewLine +
                    "End Sub"

            txtCodeStore.Text = " Public Sub FillCompoBox_" + txtName.Text + "(" + Prametre + " ByVal cmb As ComboBox)" + vbNewLine +
             " Try" + vbNewLine +
             "cmb.AutoCompleteSource = AutoCompleteSource.CustomSource" + vbNewLine +
            " Dim cmd = New SqlCommand(""FillCompoBox_" + txtName.Text + " " + prameterofpro + " "",Sqlcon)"
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(4).Value = True Then
                    txtCodeStore.Text += vbNewLine + "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + DGVColumn.Rows(x).Cells(1).Value + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + ""
                End If
            Next
                txtCodeStore.Text += vbNewLine + "Dim Dt As New DataTable" + vbNewLine +
                        "IF Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()" + vbNewLine +
                        "Sqlcon.Open()" + vbNewLine +
                        "Dt.Load(cmd.ExecuteReader())" + vbNewLine +
                        "Sqlcon.Close()" + vbNewLine +
                        "cmd = Nothing" + vbNewLine +
                        "cmb.DataSource = Dt" + vbNewLine +
                        "cmb.ValueMember = Dt.Columns(0).ColumnName" + vbNewLine
                If Selcont = 1 Then
                    txtCodeStore.Text += "cmb.DisplayMember =Dt.Columns(0).ColumnName" + vbNewLine
            Else
                    txtCodeStore.Text += "cmb.DisplayMember =Dt.Columns(1).ColumnName" + vbNewLine
            End If
                txtCodeStore.Text += "Catch ex As Exception" + vbNewLine +
                    "MessageBox.Show(ex.Message)" + vbNewLine +
                    "End Try" + vbNewLine +
                    "End Sub"

        Else
            txtCode.Text = "public static void FillCompoBox_" + txtName.Text + "(" + Prametre + " ByVal cmb As ComboBox){" + vbNewLine +
               " try{" + vbNewLine +
                " cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;" + vbNewLine +
                "Dim cmd = New SqlCommand(""SELECT " + Sel + " FROM " + DGVTable.CurrentRow.Cells(0).Value + where + " "",Sqlcon);"
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(4).Value = True Then
                    txtCode.Text += vbNewLine + "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + CHGetSql_SType(DGVColumn.Rows(x).Cells(1).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + " ;"
                End If
            Next
                txtCode.Text += vbNewLine + "DataTable Dt = new DataTable();" + vbNewLine +
                        " if(Sqlcon.State == ConnectionState.Open) Sqlcon.Close();" + vbNewLine +
                        "Sqlcon.Open();" + vbNewLine +
                        "Dt.Load(cmd.ExecuteReader());" + vbNewLine +
                        "Sqlcon.Close();" + vbNewLine +
                        "cmb.DataSource = Dt;" + vbNewLine +
                        "cmb.ValueMember = Dt.Columns[0].ColumnName;" + vbNewLine
                If Selcont = 1 Then
                    txtCode.Text += "cmb.DisplayMember =Dt.Columns[0].ColumnName;" + vbNewLine
                Else
                    txtCode.Text += "cmb.DisplayMember =Dt.Columns[1].ColumnName;" + vbNewLine
                End If                
                txtCode.Text += "//MessageBox.Show(""Delete successfully"");" + vbNewLine +
            "}catch(Exception ex){ " + vbNewLine +
           "Sqlcon.Close();" + vbNewLine +
           "//MessageBox.Show(ex.Message + ""Insert Not successfully"" );" + vbNewLine +
           "}" + vbNewLine +
           "}"
            txtCodeStore.Text = "public static void FillCompoBox_" + txtName.Text + "(" + Prametre + " ComboBox cmb ){" + vbNewLine +
                                "cmb.Items.Clear();" + vbNewLine +
                                 " try{" + vbNewLine +
                                  " cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;" + vbNewLine +
                                   "SqlCommand cmd = new SqlCommand(""FillCompoBox_" + txtName.Text + " " + prameterofpro + " "",Sqlcon);"

            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(4).Value = True Then
                    txtCodeStore.Text += vbNewLine +
                        "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, SqlDbType." + CHGetSql_SType(DGVColumn.Rows(x).Cells(1).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + " ;"
                End If
            Next
                txtCodeStore.Text += vbNewLine + "DataTable Dt = new DataTable();" + vbNewLine +
                          " if(Sqlcon.State == ConnectionState.Open) Sqlcon.Close();" + vbNewLine +
                        "Sqlcon.Open();" + vbNewLine +
                        "Dt.Load(cmd.ExecuteReader());" + vbNewLine +
                        "Sqlcon.Close();" + vbNewLine +
                        "cmb.DataSource = Dt;" + vbNewLine +
                        "cmb.ValueMember = Dt.Columns[0].ColumnName;" + vbNewLine
                If Selcont = 1 Then
                    txtCodeStore.Text += "cmb.DisplayMember =Dt.Columns[0].ColumnName;" + vbNewLine
                Else
                    txtCodeStore.Text += "cmb.DisplayMember =Dt.Columns[1].ColumnName;" + vbNewLine
                End If
                txtCodeStore.Text += "//MessageBox.Show(""Delete successfully"");" + vbNewLine +
                     "}catch(Exception ex){ " + vbNewLine +
                    "Sqlcon.Close();" + vbNewLine +
                    "//MessageBox.Show(ex.Message + ""Insert Not successfully"" );" + vbNewLine +
                    "}" + vbNewLine +
                    "}"
        End If


            txtCheckProcedureCode.Text = "IF OBJECT_ID('FillCompoBox_" + txtName.Text + "') Is Not  NULL " + vbNewLine +
                                             "DROP PROC FillCompoBox_" + txtName.Text + "" + vbNewLine
            If Not where = "" Then
                where += vbNewLine
            End If
            If Not wherepor = "" Then
                wherepor += vbNewLine
            End If
            txtAddprocedure.Text = "CREATE PROCEDURE FillCompoBox_" + txtName.Text + vbNewLine +
                    wherepor +
                    "AS " + vbNewLine +
                    "BEGIN " + vbNewLine +
                    "  SELECT " + Sel + vbNewLine +
                    "  FROM " + DGVTable.CurrentRow.Cells(0).Value + vbNewLine +
                     where +
                    "END"
            _change = "FillcomboBox"
            edit(txtCode.Text)
            edit(txtCheckProcedureCode.Text)
            edit(txtCodeStore.Text)
            edit(txtCodeStore.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Try
            Select Case _change
                Case "select"
                    btnSelect_Click(Nothing, Nothing)
                Case "insert"
                    btnInsert_Click(Nothing, Nothing)
                Case "update"
                    btnUpdate_Click(Nothing, Nothing)
                Case "delete"
                    btnDelete_Click(Nothing, Nothing)
                Case "AoutComplet"
                    btnAoutoCmplete_Click(Nothing, Nothing)
                Case "FillcomboBox"
                    btnFillcomboBox_Click(Nothing, Nothing)
                Case Else
            End Select
        Catch ex As Exception

        End Try

        'txtName.Text = DGVTable.CurrentRow.Cells(0).Value
    End Sub

    Private Sub PrToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrToolStripMenuItem.Click
        Try
            FrmPocedureList.Close()
            FrmPocedureList.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = 13 Then
            btnChange_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmbSchema_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSchema.SelectedIndexChanged
        If cmbSchema.SelectedIndex = 0 Then
            LoadTable()
        Else
            LoadViwe()
        End If
        DGVTable_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Sub MultipleSelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MultipleSelectToolStripMenuItem.Click
        FrmSQLMultiple.ShowDialog()

    End Sub
    'For simple coloring, provided that the text isn't too long, something like this will do:

    Dim KeyWords As List(Of String) = New List(Of String)(New String() {"if", "dim", "color", "public", "end", "sub", "try", "as", "new", "datatable", "sqlcommand", "then", "connectionstate", "nothing", "exception", "sqldbtype", "catch", "byval", "string", "integer", "boolean", "SqlConnection", "begin", "for", "each", "decimal", "double", "byte", "return", "char", "date", "textbox", "combobox", "group", "order by", "numeric"})
    Dim KeyWordsColors As List(Of Color) = New List(Of Color)(New Color() {Color.Blue, Color.Blue, Color.Green, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.LightSeaGreen, Color.Blue, Color.LightSeaGreen, Color.Blue, Color.LightSeaGreen, Color.LightSeaGreen, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue})
    Private Sub PreviewRTB_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged, txtAddprocedure.TextChanged, txtCheckProcedureCode.TextChanged, txtCodeStore.TextChanged
        Dim words As IEnumerable(Of String) = CType(sender, RichTextBox).Text.Split(New Char() {" "c, ".", ",", "?", "!", "(", ")"})
        Dim index As Integer = 0
        Dim rtb As RichTextBox = sender 'to give normal color according to the base fore color
        For Each word As String In words
            'If the list contains the word, then color it specially. Else, color it normally
            'Edit: Trim() is added such that it may guarantee the empty space after word does not cause error
            Try
                coloringRTB(sender, index, word.Length, If(KeyWords.Contains(word.ToLower().Trim()), KeyWordsColors(KeyWords.IndexOf(word.ToLower().Trim())), rtb.ForeColor))
                index = index + word.Length + 1 '1 is for the whitespace, though Trimmed, original word.Length is still used to advance
            Catch ex As Exception

            End Try

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

    Private Sub FrmSQLCode_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.R AndAlso e.Control) And Not txtCodeStore.Text = "" Then
            btnRun_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.C AndAlso e.Control Then
            HjgToolStripMenuItem_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.F1 Then
            frmAbout.Show()
        End If
    End Sub


    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk


        My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName,
                                            "------------------------------ Quiry Statement : ------------------------------" + vbNewLine + vbNewLine +
                                            gettext(txtCode) +
                                            "------------------------------ Store Procdure : ------------------------------" + vbNewLine + vbNewLine +
                                            gettext(txtCheckProcedureCode) + vbNewLine +
                                            gettext(txtAddprocedure) + vbNewLine +
                                            gettext(txtCodeStore) + vbNewLine + vbNewLine + "------------------------------ :: Gene Code ::  ------------------------------", False)
        Process.Start(SaveFileDialog1.FileName)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.FileName = _change + "_" + txtName.Text
        SaveFileDialog1.ShowDialog()
    End Sub

    'Private Sub FrmSQLCode_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
    '    frmHelp.ShowDialog()
    'End Sub


    Private Sub SToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SToolStripMenuItem.Click
        frmSpecialMethode.ShowDialog()
    End Sub
    Dim languge = "vb"
    Private Sub VBnetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VBnetToolStripMenuItem.Click
        languge = "vb"
        VBnetToolStripMenuItem.Checked = True
        CToolStripMenuItem.Checked = False
        btnChange_Click(Nothing, Nothing)

    End Sub

    Private Sub CToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CToolStripMenuItem.Click
        languge = "c#"
        VBnetToolStripMenuItem.Checked = False
        CToolStripMenuItem.Checked = True
        btnChange_Click(Nothing, Nothing)
    End Sub


End Class