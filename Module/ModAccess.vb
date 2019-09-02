Imports System.Data.OleDb
Imports System.Data
Module ModAccess
    Public OleDbonnectionString As String = ""
    Public OleDbCon As New OleDbConnection

    Public dt_Access_Table As DataTable
    Sub Get_Access_Table()
        'dt_Access_Table.Clear()
        Try
            Using OleDbCon = New OleDbConnection(OleDbonnectionString)
                If OleDbCon.State = ConnectionState.Open Then OleDbCon.Close()
                OleDbCon.Open()
                dt_Access_Table = OleDbCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
            End Using
            OleDbCon.Close()
        Catch ex As Exception
            OleDbCon.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub RunStoredProcdureAccess(txtAddprocedure As String, load As String)
        Try
            Dim cmd = New OleDbCommand(txtAddprocedure, OleDbCon)
            If OleDbCon.State = ConnectionState.Open Then OleDbCon.Close()
            OleDbCon.Open()
            cmd.ExecuteNonQuery()
            OleDbCon.Close()
            FrmAccessCode.lbMsg.Text = "Run Successfully"
        Catch ex As Exception
            Try
                Dim cmd = New OleDbCommand("DROP PROC " + load, OleDbCon)
                If OleDbCon.State = ConnectionState.Open Then OleDbCon.Close()
                OleDbCon.Open()
                cmd.ExecuteNonQuery()
                cmd = New OleDbCommand(txtAddprocedure, OleDbCon)
                If OleDbCon.State = ConnectionState.Open Then OleDbCon.Close()
                OleDbCon.Open()
                cmd.ExecuteNonQuery()
                OleDbCon.Close()
                FrmAccessCode.lbMsg.Visible = True
                FrmAccessCode.lbMsg.Text = "Run Successfully"
            Catch ex2 As Exception
                FrmAccessCode.lbMsg.Visible = True
                FrmAccessCode.lbMsg.Text = ex2.Message.ToString
            End Try
        End Try
    End Sub
    Public dt_Access_Columns As New DataTable
    Sub Get_Access_Columns(ByVal tablename As String)
        dt_Access_Columns.Clear()
        Try
            If OleDbCon.State = ConnectionState.Open Then OleDbCon.Close()
            OleDbCon.Open()
            dt_Access_Columns = OleDbCon.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, {Nothing, Nothing, tablename, Nothing})
            OleDbCon.Close()
        Catch ex As Exception
            OleDbCon.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function Get_Access_Type(ByVal i As Integer) As String
        Dim type As String = ""
        Select Case i
            Case 130
                type = "Text"
            Case 17
                type = "Byte"
            Case 6
                type = "Currency"
            Case 7
                type = "Date/Time"
            Case 2
                type = "Integer"
            Case 3
                type = "Long Integer"
            Case 128
                type = "OLE Object"
            Case 11
                type = "Yes/No"
            Case 131
                type = "Decimal"
            Case 5
                type = "Double"
            Case 4
                type = "Single"
        End Select
        Return type
    End Function

    Public Function CHGet_Oledb_Type_Prameter(ByVal i As Integer) As String
        Dim type As String = ""
        Select Case i
            Case 130
                type = "LongVarChar"
            Case 17
                type = "UnsignedTinyInt"
            Case 6
                type = "Numeric"
            Case 7
                type = "Date"
            Case 2
                type = "SmallInt"
            Case 3
                type = "Integer"
            Case 128
                type = "LongVarBinary"
            Case 11
                type = "Boolean"
            Case 131
                type = "Numeric"
            Case 5
                type = "Double"
            Case 4
                type = "Single"
        End Select
        Return type
    End Function

    Public Function Get_Oledb_Type_Prameter(ByVal i As Integer) As String
        Dim type As String = ""
        Select Case i
            Case 130
                type = "LongVarWchar"
            Case 17
                type = "UnsignedTinyInt"
            Case 6
                type = "Numeric"
            Case 7
                type = "Date"
            Case 2
                type = "SmallInt"
            Case 3
                type = "Integer"
            Case 128
                type = "LongVarBinary"
            Case 11
                type = "Boolean"
            Case 131
                type = "Numeric"
            Case 5
                type = "Double"
            Case 4
                type = "Single"
        End Select
        Return type
    End Function
    Dim type As String = ""

    Public Function GET_Access_Type_inteface(ByVal x As String) As String
        Select Case x
            Case "Text"
                type = "String"
            Case "Byte"
                type = "Byte"
            Case "Integer"
                type = "Integer"
            Case "Long Integer"
                type = "long"
            Case "Date/Time"
                type = "Date"
            Case "Decimal"
                type = "Decimal"
            Case "Currency"
                type = "Decimal"
            Case "Yes/No"
                type = "Boolean"
            Case "OLE Object"
                type = "Object"
            Case "Double"
                type = "Double"
            Case "Single"
                type = "Single"
        End Select
        Return type
    End Function
End Module
