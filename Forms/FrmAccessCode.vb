Public Class FrmAccessCode

    Private Sub FrmAccessCode_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FrmAccessLog.Show()
    End Sub

    Private Sub FrmAccessCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCode.BackColor = My.Settings.txtBackColor
        txtCodeStore.BackColor = My.Settings.txtBackColor
        txtAddprocedure.BackColor = My.Settings.txtBackColor
        txtCode.ForeColor = My.Settings.txtForeColor
        txtCodeStore.ForeColor = My.Settings.txtForeColor
        txtAddprocedure.ForeColor = My.Settings.txtForeColor
        txtCode.Font = My.Settings.txtFont
        txtCodeStore.Font = My.Settings.txtFont
        txtAddprocedure.Font = My.Settings.txtFont
        Get_Access_Table()
        DGVTable.Rows.Clear()
        DGVTable.Columns.Add("Table", "TABLE NAME")
        For x = 0 To dt_Access_Table.Rows.Count - 1
            DGVTable.Rows.Add()
            DGVTable("Table", x).Value = dt_Access_Table(x)(2)
        Next
        DGVTable_SelectionChanged(Nothing, Nothing)
        txtCode.BackColor = My.Settings.txtBackColor
        txtCode.ForeColor = My.Settings.txtForeColor
        txtCode.Font = My.Settings.txtFont
    End Sub

    Private Sub DGVTable_SelectionChanged(sender As Object, e As EventArgs) Handles DGVTable.SelectionChanged
        Try
            dt_Access_Columns.Clear()
            Get_Access_Columns(DGVTable.CurrentRow.Cells("Table").Value)
            DGVColumn.Rows.Clear()
            For x = 0 To dt_Access_Columns.Rows.Count - 1
                DGVColumn.Rows.Add()
                DGVColumn(0, x).Value = dt_Access_Columns(x)(3)
                DGVColumn(1, x).Value = Get_Access_Type(dt_Access_Columns(x)(11))
                DGVColumn(5, x).Value = dt_Access_Columns(x)(11)
                DGVColumn(7, x).Value = dt_Access_Columns(x)(6)
            Next
            DGVColumn.Sort(DGVColumn.Columns(7), System.ComponentModel.ListSortDirection.Ascending)
            txtName.Text = DGVTable.CurrentRow.Cells("Table").Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnConnection_Click(sender As Object, e As EventArgs) Handles btnConnection.Click
        Try
            Try
                Dim st = ""
                If languge = "vb" Then
                    st = "   Public OleDbcon = New OleDbConnection(""" + OleDbonnectionString + """)"
                Else
                    st = "   public static OleDbConnection OleDbcon = new OleDbConnection(""" + OleDbonnectionString + """);"
                    st = st.Replace("\", "/")
                End If
                txtCode.Text = st
                txtCodeStore.Text = st
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        'GET_Access_Type_inteface
        Try
            txtCode.Clear()
            Dim cont = 0
            Dim where = ""
            Dim Sel = ""
            Dim Prametre = ""
            Dim Selcont = 0
            Dim prameterofpro = ""
            '===================================================================================

            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(3).Value = True Then
                    cont += 1
                    If languge = "vb" Then
                        Prametre += DGVColumn.Rows(x).Cells(0).Value + " As " + GET_Access_Type_inteface(DGVColumn.Rows(x).Cells(1).Value) + ", "
                    Else
                        Prametre += GET_Access_Type_inteface(DGVColumn.Rows(x).Cells(1).Value) + " " + DGVColumn.Rows(x).Cells(0).Value + ", "
                    End If
                    where += " " + DGVColumn.Rows(x).Cells(0).Value + " =@" + DGVColumn.Rows(x).Cells(0).Value + " And "
                    prameterofpro += "@" + DGVColumn.Rows(x).Cells(0).Value + " , "
                End If
            Next
            Dim isone = ""
            Dim c = 0
            Dim v = 0
            Dim Group = ""
            Dim orderby = ""
            Dim orderCount = 0

            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(2).Value = True Then
                    Selcont += 1
                    If Not DGVColumn.Rows(x).Cells(4).Value = "" Then
                        Sel += DGVColumn.Rows(x).Cells(4).Value + "(" + DGVColumn.Rows(x).Cells(0).Value + "), "
                        isone = DGVColumn.Rows(x).Cells(4).Value
                        c += 1
                    Else
                        Sel += DGVColumn.Rows(x).Cells(0).Value + ", "
                        Group += DGVColumn.Rows(x).Cells(0).Value + ", "
                    End If
                End If
                If DGVColumn.Rows(x).Cells(6).Value = True Then
                    orderCount += 1
                    If Not DGVColumn.Rows(x).Cells(4).Value = "" Then
                        orderby += DGVColumn.Rows(x).Cells(4).Value + "(" + DGVColumn.Rows(x).Cells(0).Value + ")  , "
                    Else
                        orderby += DGVColumn.Rows(x).Cells(0).Value + "  , "
                    End If
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
            If prameterofpro.Length > 0 Then
                prameterofpro = prameterofpro.Remove(prameterofpro.Length - 2)
            End If
            If Sel = "" Then
                Sel = " *  "
            End If
            If Sel.Length > 0 Then
                Sel = Sel.Remove(Sel.Length - 2)
            End If
            If c = 0 Then
                Group = ""
            ElseIf c >= 1 And Not Group = "" Then
                Group = " Group by " + Group
            End If
            If orderCount >= 1 Then
                orderby = "ORDER BY " + orderby
            End If
            If Not Group.Length = 0 Then
                Group = Group.Remove(Group.Length - 2)
            End If
            If Not orderby.Length = 0 Then
                orderby = orderby.Remove(orderby.Length - 2)
            End If
            Dim header = ""
            Dim sbody = ""
            Dim pbody = ""
            Dim footer = ""
            Dim comandtype = "cmd.CommandType = CommandType.StoredProcedure"
            Dim sql = "SELECT " + Sel + " FROM " + DGVTable.CurrentRow.Cells(0).Value + where + " " + Group + " " + orderby + ""
            txtAddprocedure.Text = "CREATE PROC Load_" + txtName.Text + " AS " + sql + " "
            sql = """" + sql + """"
            If languge = "vb" Then

                header = " Public Dt_" + txtName.Text + " As New DataTable" + vbNewLine +
                          " Public" + " Sub Load_" + txtName.Text + "(" + Prametre + ")" + vbNewLine +
                          "Dt_" + txtName.Text + ".clear()" + vbNewLine +
                          " Try" + vbNewLine
                sbody = " Dim cmd = New OleDbCommand(" + sql + ",OleDbcon)"
                pbody = " Dim cmd = New OleDbCommand(""load_" + txtName.Text + """,OleDbcon)"
                For x = 0 To DGVColumn.Rows.Count - 1
                    If DGVColumn.Rows(x).Cells(3).Value = True Then
                        footer += vbNewLine + "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbType." + Get_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(5).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + ""
                    End If
                Next
                footer += vbNewLine +
                " IF OleDbcon.State = ConnectionState.Open Then OleDbcon.Close()" + vbNewLine +
                " OleDbcon.Open()" + vbNewLine +
                " Dt_" + txtName.Text + ".Load(cmd.ExecuteReader())" + vbNewLine +
                " OleDbcon.Close()" + vbNewLine +
                " cmd = Nothing" + vbNewLine +
                " Catch ex As Exception" + vbNewLine +
                " OleDbcon.Close()" + vbNewLine +
                " MsgBox(ex.Message)" + vbNewLine +
                " End Try" + vbNewLine +
                " End Sub"
                txtCode.Text = header + sbody + footer
                txtCodeStore.Text = header + pbody + "cmd.CommandType = CommandType.StoredProcedure" + vbNewLine + footer
            Else
                header = " public static DataTable Dt_" + txtName.Text + " = new DataTable();" + vbNewLine +
                         " public static void Load_" + txtName.Text + "(" + Prametre + "){" + vbNewLine +
                         " Dt_" + txtName.Text + ".Clear();" + vbNewLine +
                         " try{" + vbNewLine
                sbody = "OleDbCommand cmd = new OleDbCommand(" + sql + ",OleDbcon);"
                pbody = "OleDbCommand cmd = new OleDbCommand(""Load_" + txtName.Text + """,OleDbcon);"
                footer = ""
                For x = 0 To DGVColumn.Rows.Count - 1
                    If DGVColumn.Rows(x).Cells(3).Value = True Then
                        footer += vbNewLine + "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbType." + CHGet_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(5).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + " ;"
                    End If
                Next
                footer += vbNewLine +
                " if(OleDbcon.State == ConnectionState.Open)" + vbNewLine + " OleDbcon.Close();" + vbNewLine +
                           " OleDbcon.Open();" + vbNewLine +
                           " Dt_" + txtName.Text + ".Load(cmd.ExecuteReader());" + vbNewLine +
                           " OleDbcon.Close();" + vbNewLine +
                           " cmd = null;" + vbNewLine +
                           " }catch(Exception ex ){" + vbNewLine +
                           " OleDbcon.Close();" + vbNewLine +
                           " //MessageBox.Show(ex.Message);" + vbNewLine +
                           "}" + vbNewLine +
                           "}"
                comandtype += ";"
            End If
            txtCode.Text = header + sbody + footer
            txtCodeStore.Text = header + pbody + vbNewLine + comandtype + footer
            'If Not isone = "" And Selcont = 1 Then
            '    header = " public Function " + isone + "_" + txtName.Text + "(" + Prametre + ") As Integer" + vbNewLine +
            '                   " Dim Number As Integer=0" + vbNewLine +
            '                     "Try" + vbNewLine
            '    For x = 0 To DGVColumn.Rows.Count - 1
            '        If DGVColumn.Rows(x).Cells(3).Value = True Then
            '            txtCode.Text += vbNewLine + "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbType." + Get_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(5).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + ""
            '        End If
            '    Next
            'txtCode.Text += vbNewLine + " IF OleDbcon.State = ConnectionState.Open Then OleDbcon.Close()" + vbNewLine +
            '" OleDbcon.Open()" + vbNewLine +
            '" Number = cmd.ExecuteScalar()" + vbNewLine +
            '" OleDbcon.Close()" + vbNewLine + "cmd = Nothing" + vbNewLine +
            '" Catch ex As Exception" + vbNewLine +
            '" OleDbcon.Close()" + vbNewLine +
            '" Number = 0" + vbNewLine +
            '" MsgBox(ex.Message)" + vbNewLine +
            '" End Try" + vbNewLine +
            '" Return Number" + vbNewLine +
            '" End Sub"
            'End If
            _change = "select"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Try
            txtCode.Clear()
            Dim colomun As String = ""
            Dim prametr As String = ""
            Dim value As String = ""
            Dim AddParameters As String = ""
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(2).Value = True Then
                    colomun += DGVColumn.Rows(x).Cells(0).Value + ", "
                    value += "@" + DGVColumn.Rows(x).Cells(0).Value + ", "
                    If languge = "vb" Then
                        prametr += DGVColumn.Rows(x).Cells(0).Value + " As " + GET_Access_Type_inteface(DGVColumn.Rows(x).Cells(1).Value) + ", "
                        AddParameters += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbType." + Get_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(5).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + "" + vbNewLine
                    Else
                        prametr += GET_Access_Type_inteface(DGVColumn.Rows(x).Cells(1).Value) + " " + DGVColumn.Rows(x).Cells(0).Value + ", "
                        AddParameters += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbType." + CHGet_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(5).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + " ;" + vbNewLine
                    End If
                End If
            Next
            Try
                colomun = colomun.Remove(colomun.Length - 2)
                prametr = prametr.Remove(prametr.Length - 2)
                value = value.Remove(value.Length - 2)
            Catch ex As Exception
                txtCode.Clear()
            End Try

            _change = "insert"
            Dim header = ""
            Dim sbody = ""
            Dim pbody = ""
            Dim footer = ""
            Dim comandtype = "cmd.CommandType = CommandType.StoredProcedure"
            Dim sql = "Insert Into " + txtName.Text + " (" + colomun + ") Values(" + value + ") "
            txtAddprocedure.Text = "CREATE PROC Insert_Into_" + txtName.Text + " AS " + sql + " "
            sql = """" + sql + """"
            If languge = "vb" Then
                header = " Sub Insert_Into_" + txtName.Text + "(" + prametr + ")" + vbNewLine +
                       " Try" + vbNewLine
                sbody = " Dim cmd As New OleDbCommand(" + sql + ",OleDbcon)" + vbNewLine
                pbody = " Dim cmd As New OleDbCommand(""Insert_Into_" + txtName.Text + """,OleDbcon)" + vbNewLine
                footer = AddParameters + "If OleDbcon.State = ConnectionState.Open Then OleDbcon.Close()" + vbNewLine +
                " OleDbcon.Open()" + vbNewLine +
                " cmd.ExecuteNonQuery()" + vbNewLine +
                " OleDbcon.close()" + vbNewLine +
                " MsgBox(""Insert successfully"")" + vbNewLine +
                " Catch ex As Exception" + vbNewLine +
                " OleDbcon.close()" + vbNewLine +
                " MsgBox(ex.Message + ""Insert Not successfully"" )" + vbNewLine +
                " End Try" + vbNewLine +
                " End Sub"
            Else
                header = "public static void Insert_Into_" + txtName.Text + "( " + prametr + " ){" + vbNewLine +
                                    " try{" + vbNewLine
                sbody = " OleDbCommand cmd = new OleDbCommand(" + sql + ") ;"",OleDbcon) ;" + vbNewLine
                pbody = " OleDbCommand cmd = new OleDbCommand(""Insert_Into_" + txtName.Text + """,OleDbcon) ;" + vbNewLine
                footer = "" + AddParameters + " if(OleDbcon.State == ConnectionState.Open)" + vbNewLine + " OleDbcon.Close();" + vbNewLine +
                   "OleDbcon.Open();" + vbNewLine +
                   "cmd.ExecuteNonQuery();" + vbNewLine +
                   "OleDbcon.Close();" + vbNewLine +
                   "//MessageBox.Show(""Insert successfully"");" + vbNewLine +
                   "}catch(Exception ex){ " + vbNewLine +
                   "OleDbcon.Close();" + vbNewLine +
                    "//MessageBox.Show(ex.Message + ""Insert Not successfully"" );" + vbNewLine +
                   "}" + vbNewLine +
                   "}"
                comandtype += ";"
            End If
            txtCode.Text = header + sbody + footer
            txtCodeStore.Text = header + pbody + comandtype + vbNewLine + footer
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            txtCode.Clear()
            Dim colomun As String = ""
            Dim AddParametersproc As String = ""
            Dim wherepor As String = ""
            Dim prameterofpro = ""
            Dim prametersub = ""
            Dim prametersubin = ""
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(2).Value = True Then
                    colomun += DGVColumn.Rows(x).Cells(0).Value + "=@" + DGVColumn.Rows(x).Cells(0).Value + ", "
                    If languge = "vb" Then
                        AddParametersproc += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbType." + Get_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(5).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + "" + vbNewLine
                        prametersub += DGVColumn.Rows(x).Cells(0).Value + " As " + GET_Access_Type_inteface(DGVColumn.Rows(x).Cells(1).Value) + ", "
                    Else
                        AddParametersproc += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbType." + CHGet_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(5).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + " ;" + vbNewLine
                        prametersub += GET_Access_Type_inteface(DGVColumn.Rows(x).Cells(1).Value) + " " + DGVColumn.Rows(x).Cells(0).Value + ", "
                    End If
                    prametersubin += "@" + DGVColumn.Rows(x).Cells(0).Value + " , "
                End If
            Next
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(3).Value = True Then
                    If languge = "vb" Then
                        AddParametersproc += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbType." + Get_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(5).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + "_pre" + vbNewLine
                        prametersub += DGVColumn.Rows(x).Cells(0).Value + " As " + GET_Access_Type_inteface(DGVColumn.Rows(x).Cells(1).Value) + "_pre, "
                    Else
                        AddParametersproc += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbType." + CHGet_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(5).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + "_pre ;" + vbNewLine
                        prametersub += GET_Access_Type_inteface(DGVColumn.Rows(x).Cells(1).Value) + " " + DGVColumn.Rows(x).Cells(0).Value + "_pre, "
                    End If
                    wherepor += DGVColumn.Rows(x).Cells(0).Value + "=@" + DGVColumn.Rows(x).Cells(0).Value + "_pre And "
                    prametersubin += "@" + DGVColumn.Rows(x).Cells(0).Value + "_pre , "
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
            _change = "update"
            Dim header = ""
            Dim footer = ""
            Dim sbody = ""
            Dim pbody = ""
            Dim sql = "UPDATE " + DGVTable.CurrentRow.Cells(0).Value + " SET " + colomun + " " + wherepor + "  ;"
            txtAddprocedure.Text = "CREATE PROC Update_" + txtName.Text + " AS " + sql + " "
            sql = """" + sql + """"
            Dim comandtype = "cmd.CommandType = CommandType.StoredProcedure"
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            If languge = "vb" Then
                header = " Sub Update_" + txtName.Text + "(" + prametersub + ")" + vbNewLine +
                                   " Try" + vbNewLine
                sbody = " Dim cmd As New OleDbCommand(" + sql + ", OleDbcon)" + vbNewLine
                pbody = " Dim cmd As New OleDbCommand(""Update_" + txtName.Text + """, OleDbcon)" + vbNewLine
                footer = AddParametersproc + "If OleDbcon.State = ConnectionState.Open Then OleDbcon.Close()" + vbNewLine +
                   " OleDbcon.Open()" + vbNewLine +
                   " cmd.ExecuteNonQuery()" + vbNewLine +
                   " OleDbcon.close()" + vbNewLine +
                   " MsgBox(""Update successfully"")" + vbNewLine +
                   " Catch ex As Exception" + vbNewLine +
                   " OleDbcon.close()" + vbNewLine +
                   " MsgBox(ex.Message + ""Update Not successfully"" )" + vbNewLine +
                   " End Try" + vbNewLine +
                   " End Sub"
            Else
                header = "public static void Update_" + txtName.Text + "(" + prametersub + "){" + vbNewLine +
                                " try{" + vbNewLine
                sbody = " OleDbCommand cmd = new OleDbCommand(""UPDATE " + DGVTable.CurrentRow.Cells(0).Value + " SET " + colomun + " " + wherepor + "  ;"", OleDbcon) ;" + vbNewLine
                pbody = " OleDbCommand cmd = new OleDbCommand(""Update_" + txtName.Text + """, OleDbcon) ;" + vbNewLine
                footer = AddParametersproc + " if(OleDbcon.State == ConnectionState.Open)" + vbNewLine + " OleDbcon.Close();" + vbNewLine +
                "  OleDbcon.Open();" + vbNewLine +
                "  cmd.ExecuteNonQuery();" + vbNewLine +
                "  OleDbcon.Close();" + vbNewLine +
                "  //MessageBox.Show(""Update successfully"");" + vbNewLine +
                "}catch(Exception ex){ " + vbNewLine +
                "OleDbcon.Close();" + vbNewLine +
                "//MessageBox.Show(ex.Message + ""Insert Not successfully"" );" + vbNewLine +
                "}" + vbNewLine +
                "}"
                comandtype += ";"
            End If
            txtCode.Text = header + sbody + footer
            txtCodeStore.Text = header + pbody + comandtype + vbNewLine + footer
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            txtCode.Clear()
            Dim prametr As String = ""
            Dim Where As String = ""
            Dim AddParameters As String = ""
            Dim prameterofpro As String = ""
            Dim Selcont = 0
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(3).Value = True Then
                    Selcont = 1
                    Where += DGVColumn.Rows(x).Cells(0).Value + "=@" + DGVColumn.Rows(x).Cells(0).Value + " And "
                    If languge = "vb" Then
                        prametr += "ByVal " + DGVColumn.Rows(x).Cells(0).Value + " As " + GET_Access_Type_inteface(DGVColumn.Rows(x).Cells(1).Value) + ", "
                        AddParameters += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbType." + Get_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(5).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + "" + vbNewLine
                    Else
                        prametr += GET_Access_Type_inteface(DGVColumn.Rows(x).Cells(1).Value) + " " + DGVColumn.Rows(x).Cells(0).Value + ", "
                        AddParameters += "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbType." + CHGet_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(5).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + " ;" + vbNewLine
                    End If
                    prameterofpro += "@" + DGVColumn.Rows(x).Cells(0).Value + " , "
                End If
            Next
            Try
                prametr = prametr.Remove(prametr.Length - 2)
                prameterofpro = prameterofpro.Remove(prameterofpro.Length - 2)
                Where = Where.Remove(Where.Length - 4)
            Catch ex As Exception
                txtCode.Clear()
            End Try
            If Selcont = 1 Then
                Where = " Where " + Where
            Else
                Where = " "
            End If
            Dim header = ""
            Dim footer = ""
            Dim sql = "Delete From " + DGVTable.CurrentRow.Cells(0).Value + Where + " ;"
            Dim sbody = ""
            Dim pbody = ""
            txtAddprocedure.Text = "CREATE PROC Delete_" + txtName.Text + " AS " + sql + " "
            sql = """" + sql + """"
            Dim comandtype = "cmd.CommandType = CommandType.StoredProcedure"
            If languge = "vb" Then
                header = "Sub Delete_" + txtName.Text + "(" + prametr + ")" + vbNewLine +
                               " Try" + vbNewLine
                sbody = " Dim cmd As New OleDbCommand(" + sql + ", OleDbcon)" + vbNewLine
                pbody = " Dim cmd As New OleDbCommand(""Delete_" + txtName.Text + """, OleDbcon)" + vbNewLine
                footer = AddParameters + " IF OleDbcon.State = ConnectionState.Open Then OleDbcon.Close()" + vbNewLine +
                 " OleDbcon.Open()" + vbNewLine +
                 " cmd.ExecuteNonQuery()" + vbNewLine +
                 " OleDbcon.close()" + vbNewLine +
                 " MsgBox(""Delete successfully"")" + vbNewLine +
                 " Catch ex As Exception" + vbNewLine +
                 " OleDbcon.close()" + vbNewLine +
                 " MsgBox(ex.Message + ""Delete Not successfully"")" + vbNewLine +
                 " End Try" + vbNewLine +
                 " End Sub"
            Else
                header = "public static void Delete_" + txtName.Text + "( " + prametr + " ){" + vbNewLine +
                                " try{ " + vbNewLine
                sbody = " OleDbCommand cmd = new OleDbCommand(""Delete From " + DGVTable.CurrentRow.Cells(0).Value + Where + " ;"", OleDbcon) ;" + vbNewLine
                pbody = " OleDbCommand cmd = new OleDbCommand(""Delete_" + DGVTable.CurrentRow.Cells(0).Value + """, OleDbcon) ;" + vbNewLine
                footer = AddParameters + " if(OleDbcon.State == ConnectionState.Open)" + vbNewLine + " OleDbcon.Close();" + vbNewLine +
                "OleDbcon.Open();" + vbNewLine +
                "cmd.ExecuteNonQuery();" + vbNewLine +
                "OleDbcon.Close();" + vbNewLine +
                "//MessageBox.Show(""Delete successfully"");" + vbNewLine +
                  "}catch(Exception ex){ " + vbNewLine +
                  "OleDbcon.Close();" + vbNewLine +
                  "//MessageBox.Show(ex.Message + ""Insert Not successfully"" );" + vbNewLine +
                  "}" + vbNewLine +
                  "}"
                comandtype += ";"
            End If
            txtCode.Text = header + sbody + footer
            txtCodeStore.Text = header + pbody + comandtype + vbNewLine + footer
            _change = "delete"
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.ShowDialog()
        txtCode.Font = FontDialog1.Font
        txtCodeStore.Font = FontDialog1.Font
        txtAddprocedure.Font = FontDialog1.Font
        My.Settings.txtFont = FontDialog1.Font
    End Sub

    Private Sub ForeColoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForeColoreToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        txtCode.ForeColor = ColorDialog1.Color
        txtCodeStore.ForeColor = ColorDialog1.Color
        txtAddprocedure.ForeColor = ColorDialog1.Color
        My.Settings.txtForeColor = ColorDialog1.Color
    End Sub

    Private Sub BackGroundColorToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BackGroundColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        txtCode.BackColor = ColorDialog1.Color
        txtCodeStore.BackColor = ColorDialog1.Color
        txtAddprocedure.BackColor = ColorDialog1.Color
        My.Settings.txtBackColor = ColorDialog1.Color
    End Sub
    Dim KeyWords As List(Of String) = New List(Of String)(New String() {"if", "dim", "color", "public", "end", "sub", "try", "as", "new", "datatable", "sqlcommand", "then", "connectionstate", "nothing", "exception", "sqldbtype", "catch", "byval", "string", "integer", "boolean", "SqlConnection", "begin", "for", "each", "decimal", "double", "byte", "return", "char", "date", "textbox", "combobox", "group", "order by", "numeric"})
    Dim KeyWordsColors As List(Of Color) = New List(Of Color)(New Color() {Color.Blue, Color.Blue, Color.Green, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.LightSeaGreen, Color.Blue, Color.LightSeaGreen, Color.Blue, Color.LightSeaGreen, Color.LightSeaGreen, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue, Color.Blue})
    Private Sub PreviewRTB_TextChanged(sender As Object, e As EventArgs)
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

    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged, txtAddprocedure.TextChanged, txtCodeStore.TextChanged
        PreviewRTB_TextChanged(sender, e)
    End Sub
    Dim _change As String = ""
    Private Sub btnFillcomboBox_Click(sender As Object, e As EventArgs) Handles btnFillcomboBox.Click
        Try
            txtCode.Clear()
            Dim cont = 0
            Dim where = ""
            Dim Sel = ""
            Dim Prametre = ""
            Dim wherepor = ""
            Dim prameterofpro = ""
            Dim Selcont = 0
            Dim colomnname = ""
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(2).Value = True Then
                    Selcont += 1
                End If
            Next
            If Selcont < 1 Then
                MsgBox("You Can Select Minimum One Column")
                Exit Sub
            End If
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(3).Value = True Then
                    cont += 1
                    Prametre += DGVColumn.Rows(x).Cells(0).Value + " As " + GET_Access_Type_inteface(DGVColumn.Rows(x).Cells(1).Value) + " ,  "
                    where += " " + DGVColumn.Rows(x).Cells(0).Value + " =@" + DGVColumn.Rows(x).Cells(0).Value + " And "
                    prameterofpro += "@" + DGVColumn.Rows(x).Cells(0).Value + " , "
                End If
            Next

            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(2).Value = True Then
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

            _change = "FillcomboBox"
            If languge = "vb" Then
                txtCode.Text = " Public Sub FillCompoBox_" + txtName.Text + "(" + Prametre + " ByVal cmb As ComboBox)" + vbNewLine +
            " cmb.Items.Clear()" + vbNewLine +
            " Try" + vbNewLine +
             " cmb.AutoCompleteSource = AutoCompleteSource.CustomSource" + vbNewLine +
             " Dim cmd = New OleDbCommand("" SELECT " + Sel + " FROM " + DGVTable.CurrentRow.Cells(0).Value + where + " "",OleDbcon)"
                For x = 0 To DGVColumn.Rows.Count - 1
                    If DGVColumn.Rows(x).Cells(4).Value = True Then
                        txtCode.Text += vbNewLine + "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbDbType." + Get_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(5).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + ""
                    End If
                Next
                txtCode.Text += vbNewLine + "Dim Dt As New DataTable" + vbNewLine +
                  " IF OleDbcon.State = ConnectionState.Open Then OleDbcon.Close()" + vbNewLine +
                  " OleDbcon.Open()" + vbNewLine +
                  " Dt.Load(cmd.ExecuteReader())" + vbNewLine +
                  " OleDbcon.Close()" + vbNewLine +
                  " cmd = Nothing" + vbNewLine +
                  " cmb.DataSource = Dt" + vbNewLine +
                  " cmb.ValueMember = Dt.Columns(0).ColumnName" + vbNewLine
                If (Selcont = 1) Then
                    txtCode.Text += " cmb.DisplayMember =Dt.Columns(0).ColumnName" + vbNewLine
                Else
                    txtCode.Text += " cmb.DisplayMember =Dt.Columns(1).ColumnName" + vbNewLine
                End If
                txtCode.Text +=
                  " Catch ex As Exception" + vbNewLine +
                  " MsgBox(ex.Message)" + vbNewLine +
                  " End Try" + vbNewLine +
                  " End Sub"
            Else
                txtCode.Text = "public static void FillCompoBox_" + txtName.Text + "(" + Prametre + " ByVal cmb As ComboBox){" + vbNewLine +
                 "cmb.Items.Clear();" + vbNewLine +
                 " try{" + vbNewLine +
                  " cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;" + vbNewLine +
                  "Dim cmd = New OleDbCommand(""SELECT " + Sel + " FROM " + DGVTable.CurrentRow.Cells(0).Value + where + " "",OleDbcon);"
                For x = 0 To DGVColumn.Rows.Count - 1
                    If DGVColumn.Rows(x).Cells(4).Value = True Then
                        txtCode.Text += vbNewLine + "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbDbType." + Get_Oledb_Type_Prameter(DGVColumn.Rows(x).Cells(1).Value) + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + " ;"
                    End If
                Next
                txtCode.Text += vbNewLine + "DataTable Dt = new DataTable();" + vbNewLine +
                        " if(OleDbcon.State == ConnectionState.Open) OleDbcon.Close();" + vbNewLine +
                        "OleDbcon.Open();" + vbNewLine +
                        "Dt.Load(cmd.ExecuteReader());" + vbNewLine +
                        "OleDbcon.Close();" + vbNewLine +
                        "cmb.DataSource = Dt;" + vbNewLine +
                        "cmb.ValueMember = Dt.Columns[0].ColumnName;" + vbNewLine
                If (Selcont = 1) Then
                    txtCode.Text += "cmb.DisplayMember = Dt.Columns[0].ColumnName;" + vbNewLine
                Else
                    txtCode.Text += "cmb.DisplayMember = Dt.Columns[1].ColumnName;" + vbNewLine
                End If
                txtCode.Text +=
                        "//MessageBox.Show(""Delete successfully"");" + vbNewLine +
                         "}catch(Exception ex){ " + vbNewLine +
                        "OleDbcon.Close();" + vbNewLine +
                        "//MessageBox.Show(ex.Message + ""Insert Not successfully"" );" + vbNewLine +
                        "}" + vbNewLine +
                        "}"
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
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
        End Select
        'txtName.Text = DGVTable.CurrentRow.Cells(0).Value
    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = 13 Then
            btnChange_Click(Nothing, Nothing)
        End If
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

    Private Sub ChSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChSelectAll.CheckedChanged
        For x = 0 To DGVColumn.Rows.Count - 1
            DGVColumn.Rows(x).Cells(2).Value = ChSelectAll.Checked
        Next
    End Sub

    Private Sub FrmSQLCode_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.C AndAlso e.Control Then
            HjgToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

        My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName,
                                            "------------------------------ Quiry Statement : ------------------------------" + vbNewLine + vbNewLine +
                                            gettext(txtCode) +
                                            "------------------------------ Store Procdure : ------------------------------" + vbNewLine + vbNewLine +
                                            gettext(txtAddprocedure) + vbNewLine +
                                            "------------------------------ Store Procdure : ------------------------------" + vbNewLine + vbNewLine +
                                            gettext(txtCodeStore) + vbNewLine + vbNewLine + "------------------------------ :: Gene Code ::  ------------------------------", False)
        Process.Start(SaveFileDialog1.FileName)
    End Sub

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

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.FileName = _change + "_" + txtName.Text
        SaveFileDialog1.ShowDialog()
    End Sub

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

    Private Sub btnAoutoCmplete_Click(sender As Object, e As EventArgs) Handles btnAoutoCmplete.Click
        Try
            txtCode.Clear()
            Dim cont = 0
            Dim where = ""
            Dim Sel = ""
            Dim Prametre = ""
            Dim Selcont = 0
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(2).Value = True Then
                    Selcont += 1
                End If
            Next
            If Selcont > 1 Then
                MsgBox("You Can Select Only One Column")
                Exit Sub
            End If
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(3).Value = True Then
                    cont += 1
                    Prametre += DGVColumn.Rows(x).Cells(0).Value + " As " + GET_Access_Type_inteface(DGVColumn.Rows(x).Cells(1).Value) + ",  "
                    where += " " + DGVColumn.Rows(x).Cells(0).Value + " =@" + DGVColumn.Rows(x).Cells(0).Value + " And "
                End If
            Next

            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(2).Value = True Then
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

            _change = "AoutComplet"
            txtCode.Text = " Public Sub AoutComplet_" + txtName.Text + "(" + Prametre + " ByVal txtbox As TextBox)" + vbNewLine +
                "txtbox.Clear()" + vbNewLine +
                " Try" + vbNewLine +
                 "txtbox.AutoCompleteSource = AutoCompleteSource.CustomSource" + vbNewLine +
                 "txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend" + vbNewLine +
                 " Dim cmd = New OleDbCommand(""SELECT " + Sel + " FROM " + DGVTable.CurrentRow.Cells(0).Value + where + " "",OleDbcon)"
            For x = 0 To DGVColumn.Rows.Count - 1
                If DGVColumn.Rows(x).Cells(4).Value = True Then
                    txtCode.Text += vbNewLine + "cmd.Parameters.Add(""" + DGVColumn.Rows(x).Cells(0).Value + """, OleDbDbType." + DGVColumn.Rows(x).Cells(1).Value + ").Value = " + DGVColumn.Rows(x).Cells(0).Value + ""
                End If
            Next
            txtCode.Text += vbNewLine + "Dim Dt As New DataTable" + vbNewLine +
                    " IF OleDbcon.State = ConnectionState.Open Then OleDbcon.Close()" + vbNewLine +
                    " OleDbcon.Open()" + vbNewLine +
                    " Dt.Load(cmd.ExecuteReader())" + vbNewLine +
                    " Dim drow As DataRow" + vbNewLine +
                    " txtbox.AutoCompleteCustomSource.Clear()" + vbNewLine +
                    " For Each drow In dt.Rows" + vbNewLine +
                    " txtbox.AutoCompleteCustomSource.Add(drow.Item(""" + Sel + """).ToString)" + vbNewLine +
                    "Next" + vbNewLine +
                    " OleDbcon.Close()" + vbNewLine +
                    "cmd = Nothing" + vbNewLine +
                    " Catch ex As Exception" + vbNewLine +
                    "OleDbcon.Close()" + vbNewLine +
                    "MsgBox(ex.Message)" + vbNewLine +
                    " End Try" + vbNewLine +
                    " End Sub"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        Select Case _change
            Case "select"
                RunStoredProcdureAccess(txtAddprocedure.Text, "load_" + DGVTable.CurrentRow.Cells(0).Value)
            Case "insert"
                RunStoredProcdureAccess(txtAddprocedure.Text, "Insert_Into_" + DGVTable.CurrentRow.Cells(0).Value)
            Case "update"
                RunStoredProcdureAccess(txtAddprocedure.Text, "Update_" + DGVTable.CurrentRow.Cells(0).Value)
            Case "delete"
                RunStoredProcdureAccess(txtAddprocedure.Text, "Delete_" + DGVTable.CurrentRow.Cells(0).Value)
            Case "AoutComplet"

            Case "FillcomboBox"

            Case Else
        End Select
        lbMsg.Text = "Run Successfully"
    End Sub
End Class