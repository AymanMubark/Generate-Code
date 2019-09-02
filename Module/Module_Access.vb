Imports System.Data.OleDb
Imports System.Data
Module Module_Access
    'Dim con As OleDbConnection

    'Public Sub TestConection_Access2007(ByVal dbname As String, ByVal dbpasswrd As String)
    '    Try
    '        conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbname + dbpasswrd + ""
    '        con = New OleDbConnection(conString)
    '        con.Open()
    '        If (con.State = ConnectionState.Open) Then
    '            con.Close()
    '            frm_Access_load.Hide()
    '            frm_Access_Codes.Show()
    '        End If
    '    Catch ex As Exception
    '        ms = "Test Conection Not Successfully"
    '        MessageBox.Show(ex.Message, "Test Conection", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Public Sub TestConection_Access2003(ByVal dbname As String, ByVal dbpasswrd As String)
    '    Try
    '        conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbname + dbpasswrd + ""
    '        con = New OleDbConnection(conString)
    '        con.Open()
    '        If (con.State = ConnectionState.Open) Then
    '            con.Close()
    '            frm_Access_load.Hide()
    '            frm_Access_Codes.Show()
    '        End If
    '    Catch ex As Exception
    '        ms = "Test Conection Not Successfully"
    '        MessageBox.Show(ex.Message, "Test Conection", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    ''Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\DB.accdb;Jet OLEDB:Database Password=1234
    ''Provider=Microsoft.Jet.OLEDB.4.0;Data Source="D:\DB .mdb";
    'Public dt_Access_Table As New DataTable
    'Sub Get_Access_Table()
    '    dt_Access_Table.Clear()
    '    Try
    '        Using con As New OleDbConnection(conString)
    '            If con.State = ConnectionState.Open Then con.Close()
    '            con.Open()
    '            dt_Access_Table = con.GetSchema("TABLES", {Nothing, Nothing, Nothing, "TABLE"})
    '        End Using
    '    Catch ex As Exception
    '        con.Close()
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    'Public dt_Access_Columns As New DataTable
    'Sub Get_Access_Columns(ByVal tablename As String)
    '    dt_Access_Columns.Clear()
    '    Try
    '        Using con As New OleDbConnection(conString)
    '            If con.State = ConnectionState.Open Then con.Close()
    '            con.Open()
    '            dt_Access_Columns = con.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, {Nothing, Nothing, tablename, Nothing})
    '        End Using
    '    Catch ex As Exception
    '        con.Close()
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    'Public Function Get_Access_Type(ByVal i As Integer) As String
    '    Dim type As String = ""
    '    Select Case i
    '        Case 130
    '            type = "Text"
    '        Case 17
    '            type = "Byte"
    '        Case 6
    '            type = "Currency"
    '        Case 7
    '            type = "Date/Time"
    '        Case 2
    '            type = "Integer"
    '        Case 3
    '            type = "Long Integer"
    '        Case 128
    '            type = "OLE Object"
    '        Case 11
    '            type = "Yes/No"
    '        Case 131
    '            type = "Decimal"
    '        Case 5
    '            type = "Double"
    '        Case 4
    '            type = "Single"
    '    End Select
    '    Return type
    'End Function
    'Public Function GET_Access_Type_inteface(ByVal x As String) As String
    '    Dim type As String = ""
    '    Select Case x
    '        Case "Text"
    '            type = "String"
    '        Case "Byte"
    '            type = "Byte"
    '        Case "Integer"
    '            type = "Integer"
    '        Case "Long Integer"
    '            type = "Long"
    '        Case "Date/Time"
    '            type = "Date"
    '        Case "Decimal"
    '            type = "Decimal"
    '        Case "Currency"
    '            type = "Decimal"
    '        Case "Yes/No"
    '            type = "Boolean"
    '        Case "OLE Object"
    '            type = "Object"
    '        Case "Double"
    '            type = "Double"
    '        Case "Single"
    '            type = "Single"
    '    End Select
    '    Return type
    'End Function

    'Public Function Get_Oledb_Type_Prameter(ByVal i As Integer) As String
    '    Dim type As String = ""
    '    Select Case i
    '        Case 130
    '            type = "LongVarWchar"
    '        Case 17
    '            type = "UnsignedTinyInt"
    '        Case 6
    '            type = "Numeric"
    '        Case 7
    '            type = "Date"
    '        Case 2
    '            type = "SmallInt"
    '        Case 3
    '            type = "Integer"
    '        Case 128
    '            type = "LongVarBinary"
    '        Case 11
    '            type = "Boolean"
    '        Case 131
    '            type = "Numeric"
    '        Case 5
    '            type = "Double"
    '        Case 4
    '            type = "Single"
    '    End Select
    '    Return type
    'End Function
End Module
