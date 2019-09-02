Imports System.Data.SqlClient
Imports System.ServiceProcess
Imports System.Data.Sql
Module ModSql
    Public Function gettext(txtcode As RichTextBox) As String
        Dim txt = ""
        For Each lin In txtcode.Lines
            txt += lin.ToString + vbNewLine
        Next
        Return txt
    End Function
    Public SqlConnectionString As String = ""
    Public Sqlcon As SqlConnection
    Sub LoadServer(cmbServer As ComboBox)
        Try
            Dim table As New DataTable
            Dim instance As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
            table = instance.GetDataSources()
            Dim Server As String = String.Empty
            Dim inst = String.Empty
            For Each row As System.Data.DataRow In table.Rows
                Server = row("ServerName")
                If row("InstanceName").ToString.Length > 0 Then
                    Server = Server & "\" & row("InstanceName")
                    If Not String.IsNullOrEmpty(row("InstanceName")) Then
                        inst = row("InstanceName")
                    End If
                End If
                cmbServer.Items.Add(Server)
            Next
            cmbServer.SelectedIndex = 0
            If cmbServer.Items.Count = 1 AndAlso Server.Contains(inst) Then
                For Each row As System.Data.DataRow In table.Rows
                    Server = row("ServerName")
                    If row("InstanceName").ToString.Length > 0 Then
                        Server = Server
                        If Not String.IsNullOrEmpty(row("InstanceName")) Then
                            inst = row("InstanceName")
                        End If
                    End If
                    cmbServer.Items.Add(Server)
                Next
            End If

        Catch ex As Exception
            'Me.Close()
        End Try
    End Sub
    Sub LoadDataBase(cmbServer As ComboBox, cmbDataBase As ComboBox)
        Dim Dt As New DataTable
        Try
            Sqlcon = New SqlConnection("Data Source=" & cmbServer.Text & ";Initial Catalog=master;Integrated Security=True")
            Dim cmd = New SqlCommand("select database_id,name from sys.databases order by database_id desc", Sqlcon)
            If Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()
            Sqlcon.Open()
            Dt.Load(cmd.ExecuteReader())
            Sqlcon.Close()
            cmbDataBase.DataSource = Dt
            cmbDataBase.ValueMember = Dt.Columns(0).ColumnName.ToString
            cmbDataBase.DisplayMember = Dt.Columns(1).ColumnName.ToString
        Catch ex As SqlException
            MsgBox("dkjs")
        End Try
    End Sub
    Public DtTable As New DataTable
    Sub LoadTable()
        DtTable.Clear()
        Try
            Dim cmd = New SqlCommand("select TABLE_NAME   from INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' And TABLE_NAME!='sysdiagrams'", Sqlcon)
            If Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()
            Sqlcon.Open()
            DtTable.Load(cmd.ExecuteReader)
            Sqlcon.Close()
            cmd = Nothing
        Catch ex As Exception
            Sqlcon.Close()
            'MsgBox(ex.Message)
        End Try
    End Sub

    Sub LoadViwe()
        DtTable.Clear()
        Try
            Dim cmd = New SqlCommand("select TABLE_NAME  from INFORMATION_SCHEMA.Views ", Sqlcon)
            If Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()
            Sqlcon.Open()
            DtTable.Load(cmd.ExecuteReader)
            Sqlcon.Close()
            cmd = Nothing
        Catch ex As Exception
            Sqlcon.Close()
            'MsgBox(ex.Message)
        End Try
    End Sub
    Public DtColumn As New DataTable
    Sub LoadColumn(TableName As String)
        Try
            DtColumn.Clear()
            Dim Da As New SqlDataAdapter("select COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='" + TableName + "' order by ORDINAL_POSITION ", Sqlcon)
            Da.Fill(DtColumn)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Public DtColumnMul As New DataTable
    Sub LoadColumnMul(TableName As String)
        Try
            DtColumnMul.Clear()
            Dim Da As New SqlDataAdapter("select Table_Name,COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='" + TableName + "' order by ORDINAL_POSITION ", Sqlcon)
            Da.Fill(DtColumnMul)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Public Function vbGetSql_Type(ByVal x As String) As String
        Dim type As String = ""
        Select Case x
            Case "varchar"
                type = "String"
            Case "nvarchar"
                type = "String"
            Case "int"
                type = "Integer"
	   Case "tinyint"
                type = "Integer"
            Case "bigint"
                type = "Integer"
            Case "binary"
                type = "Integer"
            Case "bit"
                type = "Boolean"
            Case "char"
                type = "Char"
            Case "date"
                type = "date"
            Case "datetime"
                type = "date"
            Case "datetime2"
                type = "date"
            Case "datetime2"
                type = "date"
            Case "datetimeoffset"
                type = "date"
            Case "decimal"
                type = "Decimal"
            Case "float"
                type = "Double"
            Case "image"
                type = "Byte"
            Case "mony"
                type = "Decimal"
            Case "nchar"
                type = "String"
        End Select
        Return type
    End Function
    Public Function CHGetSql_Type(ByVal x As String) As String
        Dim type As String = ""
        Select Case x
            Case "varchar"
                type = "string"
            Case "nvarchar"
                type = "string"
            Case "int"
                type = "int"
            Case "tinyint"
                type = "int"
            Case "bigint"
                type = "int"
            Case "binary"
                type = "int"
            Case "bit"
                type = "Boolean"
            Case "char"
                type = "char"
            Case "date"
                type = "DateTime"
            Case "datetime"
                type = "DateTime"
            Case "datetime2"
                type = "DateTime"
            Case "datetime2"
                type = "DateTime"
            Case "datetimeoffset"
                type = "DateTimeOffset"
            Case "decimal"
                type = "decimal"
            Case "float"
                type = "double"
            Case "image"
                type = "byte"
            Case "mony"
                type = "decimal"
            Case "nchar"
                type = "string"
        End Select
        Return type
    End Function
    Public Function CHGetSql_SType(ByVal x As String) As String
        Dim type As String = ""
        Select Case x
            Case "nvarchar"
                type = "NVarChar"
            Case "varchar"
                type = "VarChar"
            Case "int"
                type = "Int"
            Case "bigint"
                type = "BigInt"
            Case "bit"
                type = "Bit"
            Case "char"
                type = "Char"
            Case "date"
                type = "Date"
            Case "datetime"
                type = "DateTime"
            Case "datetime2"
                type = "DateTime2"
            Case "datetimeoffset"
                type = "DateTimeOffset"
            Case "decimal"
                type = "Decimal"
            Case "float"
                type = "Float"
            Case "image"
                type = "Image"
            Case "mony"
                type = "Mony"
            Case "nchar"
                type = "NChar"
        End Select
        Return type
    End Function
    Sub RunStoredProcdure(txtAddprocedure As String, txtCheckProcedureCode As String)
        Dim cmd = New SqlCommand(txtCheckProcedureCode, Sqlcon)
        If Sqlcon.State = ConnectionState.Open Then Sqlcon.Close()
        Sqlcon.Open()
        cmd.ExecuteNonQuery()
        Sqlcon.Close()
        cmd = New SqlCommand(txtAddprocedure, Sqlcon)
        Sqlcon.Open()
        cmd.ExecuteNonQuery()
        Sqlcon.Close()
    End Sub
    Public DtProcdure As New DataTable
    Sub LoadProcdure()
        Try
            DtProcdure.Clear()
            Dim Da As New SqlDataAdapter("select  SPECIFIC_NAME AS [Procdure Name], LAST_ALTERED as [LAST ALTERED] ,CREATED as [CREATED TIME],ROUTINE_DEFINITION FROM INFORMATION_SCHEMA.ROUTINES where ROUTINE_type='PROCEDURE' and LEFT(SPECIFIC_NAME,3) not in('sp_','ms_','xp_') order by CREATED Desc,LAST_ALTERED Desc", Sqlcon)
            Da.Fill(DtProcdure)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'drop procedure Insert_Into_tbDayu
    Sub DropProcdure(txtCheckProcedureCode As String)
        Try
            Dim cmd = New SqlCommand("Drop procedure " + txtCheckProcedureCode, Sqlcon)
            Sqlcon.Open()
            cmd.ExecuteNonQuery()
            Sqlcon.Close()
            MsgBox("Done")
        Catch ex As Exception
            Sqlcon.Close()
            MsgBox("Error : " + ex.Message)
        End Try
    End Sub
End Module
