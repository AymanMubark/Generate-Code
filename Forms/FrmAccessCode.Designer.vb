<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAccessCode
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAccessCode))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChSelectAll = New MetroFramework.Controls.MetroCheckBox()
        Me.DGVTable = New MetroFramework.Controls.MetroGrid()
        Me.DGVColumn = New MetroFramework.Controls.MetroGrid()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ORDINAL_POSITION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New MetroFramework.Controls.MetroButton()
        Me.btnUpdate = New MetroFramework.Controls.MetroButton()
        Me.btnInsert = New MetroFramework.Controls.MetroButton()
        Me.btnSelect = New MetroFramework.Controls.MetroButton()
        Me.btnConnection = New MetroFramework.Controls.MetroButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HjgToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LangugeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.VBnetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ForeColoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackGroundColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MultipleSelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtName = New MetroFramework.Controls.MetroTextBox()
        Me.btnFillcomboBox = New MetroFramework.Controls.MetroButton()
        Me.btnAoutoCmplete = New MetroFramework.Controls.MetroButton()
        Me.btnChange = New System.Windows.Forms.PictureBox()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.MetroTabControl1 = New MetroFramework.Controls.MetroTabControl()
        Me.MetroTabPage1 = New MetroFramework.Controls.MetroTabPage()
        Me.txtCode = New System.Windows.Forms.RichTextBox()
        Me.MetroTabPage2 = New MetroFramework.Controls.MetroTabPage()
        Me.txtCodeStore = New System.Windows.Forms.RichTextBox()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.lbMsg = New MetroFramework.Controls.MetroLabel()
        Me.btnRun = New MetroFramework.Controls.MetroButton()
        Me.txtAddprocedure = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGVTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.btnChange, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MetroTabControl1.SuspendLayout()
        Me.MetroTabPage1.SuspendLayout()
        Me.MetroTabPage2.SuspendLayout()
        Me.MetroPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChSelectAll)
        Me.GroupBox1.Controls.Add(Me.DGVTable)
        Me.GroupBox1.Controls.Add(Me.DGVColumn)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Location = New System.Drawing.Point(20, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(372, 480)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'ChSelectAll
        '
        Me.ChSelectAll.AutoSize = True
        Me.ChSelectAll.FontSize = MetroFramework.MetroCheckBoxSize.Tall
        Me.ChSelectAll.Location = New System.Drawing.Point(266, 216)
        Me.ChSelectAll.Name = "ChSelectAll"
        Me.ChSelectAll.Size = New System.Drawing.Size(96, 25)
        Me.ChSelectAll.TabIndex = 8
        Me.ChSelectAll.Text = "Select all"
        Me.ChSelectAll.UseSelectable = True
        '
        'DGVTable
        '
        Me.DGVTable.AllowUserToAddRows = False
        Me.DGVTable.AllowUserToDeleteRows = False
        Me.DGVTable.AllowUserToResizeRows = False
        Me.DGVTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGVTable.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGVTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGVTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGVTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVTable.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGVTable.EnableHeadersVisualStyles = False
        Me.DGVTable.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.DGVTable.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVTable.Location = New System.Drawing.Point(6, 41)
        Me.DGVTable.MultiSelect = False
        Me.DGVTable.Name = "DGVTable"
        Me.DGVTable.ReadOnly = True
        Me.DGVTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVTable.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DGVTable.RowHeadersVisible = False
        Me.DGVTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGVTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVTable.Size = New System.Drawing.Size(356, 158)
        Me.DGVTable.TabIndex = 7
        '
        'DGVColumn
        '
        Me.DGVColumn.AllowUserToAddRows = False
        Me.DGVColumn.AllowUserToDeleteRows = False
        Me.DGVColumn.AllowUserToResizeRows = False
        Me.DGVColumn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DGVColumn.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGVColumn.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVColumn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGVColumn.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGVColumn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVColumn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DGVColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVColumn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column4, Me.Column5, Me.Column6, Me.Column3, Me.Column7, Me.ORDINAL_POSITION})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.DGVColumn.EnableHeadersVisualStyles = False
        Me.DGVColumn.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.DGVColumn.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVColumn.Location = New System.Drawing.Point(6, 247)
        Me.DGVColumn.Name = "DGVColumn"
        Me.DGVColumn.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVColumn.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DGVColumn.RowHeadersVisible = False
        Me.DGVColumn.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGVColumn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGVColumn.Size = New System.Drawing.Size(356, 217)
        Me.DGVColumn.TabIndex = 6
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Column"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "DataType"
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        '
        'Column4
        '
        Me.Column4.HeaderText = "Select"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 60
        '
        'Column5
        '
        Me.Column5.HeaderText = "Where"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 60
        '
        'Column6
        '
        Me.Column6.HeaderText = "Type"
        Me.Column6.Items.AddRange(New Object() {"", "Count", "Max", "Min", "Sum", "Avg"})
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 70
        '
        'Column3
        '
        Me.Column3.HeaderText = "Length"
        Me.Column3.Name = "Column3"
        Me.Column3.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "OB"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 40
        '
        'ORDINAL_POSITION
        '
        Me.ORDINAL_POSITION.HeaderText = "Column8"
        Me.ORDINAL_POSITION.Name = "ORDINAL_POSITION"
        Me.ORDINAL_POSITION.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnDelete)
        Me.GroupBox2.Controls.Add(Me.btnUpdate)
        Me.GroupBox2.Controls.Add(Me.btnInsert)
        Me.GroupBox2.Controls.Add(Me.btnSelect)
        Me.GroupBox2.Controls.Add(Me.btnConnection)
        Me.GroupBox2.Controls.Add(Me.MenuStrip1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(392, 60)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(575, 101)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Basic Operation"
        '
        'btnDelete
        '
        Me.btnDelete.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnDelete.Location = New System.Drawing.Point(457, 60)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(107, 31)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseSelectable = True
        '
        'btnUpdate
        '
        Me.btnUpdate.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnUpdate.Location = New System.Drawing.Point(345, 60)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(107, 31)
        Me.btnUpdate.TabIndex = 9
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseSelectable = True
        '
        'btnInsert
        '
        Me.btnInsert.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnInsert.Location = New System.Drawing.Point(232, 60)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(107, 31)
        Me.btnInsert.TabIndex = 10
        Me.btnInsert.Text = "Insert"
        Me.btnInsert.UseSelectable = True
        '
        'btnSelect
        '
        Me.btnSelect.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnSelect.Location = New System.Drawing.Point(119, 60)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(107, 31)
        Me.btnSelect.TabIndex = 11
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseSelectable = True
        '
        'btnConnection
        '
        Me.btnConnection.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnConnection.Location = New System.Drawing.Point(6, 60)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(107, 31)
        Me.btnConnection.TabIndex = 12
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseSelectable = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HjgToolStripMenuItem, Me.FilToolStripMenuItem, Me.OptionToolStripMenuItem, Me.PrToolStripMenuItem, Me.SToolStripMenuItem, Me.MultipleSelectToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 23)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(569, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HjgToolStripMenuItem
        '
        Me.HjgToolStripMenuItem.Image = CType(resources.GetObject("HjgToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HjgToolStripMenuItem.Name = "HjgToolStripMenuItem"
        Me.HjgToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.HjgToolStripMenuItem.Text = "Copy"
        '
        'FilToolStripMenuItem
        '
        Me.FilToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem})
        Me.FilToolStripMenuItem.Image = CType(resources.GetObject("FilToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FilToolStripMenuItem.Name = "FilToolStripMenuItem"
        Me.FilToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.FilToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'OptionToolStripMenuItem
        '
        Me.OptionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LangugeToolStripMenuItem, Me.ToolStripSeparator2, Me.FontToolStripMenuItem, Me.ToolStripSeparator4, Me.ForeColoreToolStripMenuItem, Me.ToolStripSeparator3, Me.BackGroundColorToolStripMenuItem})
        Me.OptionToolStripMenuItem.Image = CType(resources.GetObject("OptionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem"
        Me.OptionToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.OptionToolStripMenuItem.Text = "Options"
        '
        'LangugeToolStripMenuItem
        '
        Me.LangugeToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.LangugeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CToolStripMenuItem, Me.ToolStripSeparator1, Me.VBnetToolStripMenuItem})
        Me.LangugeToolStripMenuItem.Name = "LangugeToolStripMenuItem"
        Me.LangugeToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.LangugeToolStripMenuItem.Text = "Languge"
        '
        'CToolStripMenuItem
        '
        Me.CToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.CToolStripMenuItem.Name = "CToolStripMenuItem"
        Me.CToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.CToolStripMenuItem.Text = "C#"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(105, 6)
        '
        'VBnetToolStripMenuItem
        '
        Me.VBnetToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.VBnetToolStripMenuItem.Checked = True
        Me.VBnetToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.VBnetToolStripMenuItem.Name = "VBnetToolStripMenuItem"
        Me.VBnetToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.VBnetToolStripMenuItem.Text = "VB.net"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(168, 6)
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.FontToolStripMenuItem.Text = "Font"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(168, 6)
        '
        'ForeColoreToolStripMenuItem
        '
        Me.ForeColoreToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.ForeColoreToolStripMenuItem.Name = "ForeColoreToolStripMenuItem"
        Me.ForeColoreToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ForeColoreToolStripMenuItem.Text = "Fore Color"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(168, 6)
        '
        'BackGroundColorToolStripMenuItem
        '
        Me.BackGroundColorToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.BackGroundColorToolStripMenuItem.Name = "BackGroundColorToolStripMenuItem"
        Me.BackGroundColorToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.BackGroundColorToolStripMenuItem.Text = "BackGround Color"
        '
        'PrToolStripMenuItem
        '
        Me.PrToolStripMenuItem.Image = CType(resources.GetObject("PrToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrToolStripMenuItem.Name = "PrToolStripMenuItem"
        Me.PrToolStripMenuItem.Size = New System.Drawing.Size(121, 20)
        Me.PrToolStripMenuItem.Text = "Procedure Table"
        Me.PrToolStripMenuItem.Visible = False
        '
        'SToolStripMenuItem
        '
        Me.SToolStripMenuItem.Image = CType(resources.GetObject("SToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SToolStripMenuItem.Name = "SToolStripMenuItem"
        Me.SToolStripMenuItem.Size = New System.Drawing.Size(123, 20)
        Me.SToolStripMenuItem.Text = "Special Methode"
        '
        'MultipleSelectToolStripMenuItem
        '
        Me.MultipleSelectToolStripMenuItem.Name = "MultipleSelectToolStripMenuItem"
        Me.MultipleSelectToolStripMenuItem.Size = New System.Drawing.Size(97, 20)
        Me.MultipleSelectToolStripMenuItem.Text = "Multiple Select"
        Me.MultipleSelectToolStripMenuItem.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtName)
        Me.GroupBox3.Controls.Add(Me.btnFillcomboBox)
        Me.GroupBox3.Controls.Add(Me.btnAoutoCmplete)
        Me.GroupBox3.Controls.Add(Me.btnChange)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(392, 472)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(575, 68)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'txtName
        '
        '
        '
        '
        Me.txtName.CustomButton.Image = Nothing
        Me.txtName.CustomButton.Location = New System.Drawing.Point(215, 1)
        Me.txtName.CustomButton.Name = ""
        Me.txtName.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.txtName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtName.CustomButton.TabIndex = 1
        Me.txtName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtName.CustomButton.UseSelectable = True
        Me.txtName.CustomButton.Visible = False
        Me.txtName.Lines = New String(-1) {}
        Me.txtName.Location = New System.Drawing.Point(279, 29)
        Me.txtName.MaxLength = 32767
        Me.txtName.Name = "txtName"
        Me.txtName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtName.PromptText = "Method Name"
        Me.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtName.SelectedText = ""
        Me.txtName.SelectionLength = 0
        Me.txtName.SelectionStart = 0
        Me.txtName.ShortcutsEnabled = True
        Me.txtName.Size = New System.Drawing.Size(237, 23)
        Me.txtName.TabIndex = 12
        Me.txtName.UseSelectable = True
        Me.txtName.WaterMark = "Method Name"
        Me.txtName.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtName.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'btnFillcomboBox
        '
        Me.btnFillcomboBox.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnFillcomboBox.Location = New System.Drawing.Point(148, 26)
        Me.btnFillcomboBox.Name = "btnFillcomboBox"
        Me.btnFillcomboBox.Size = New System.Drawing.Size(125, 31)
        Me.btnFillcomboBox.TabIndex = 10
        Me.btnFillcomboBox.Text = "Fill comboBox"
        Me.btnFillcomboBox.UseSelectable = True
        '
        'btnAoutoCmplete
        '
        Me.btnAoutoCmplete.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnAoutoCmplete.Location = New System.Drawing.Point(17, 26)
        Me.btnAoutoCmplete.Name = "btnAoutoCmplete"
        Me.btnAoutoCmplete.Size = New System.Drawing.Size(125, 31)
        Me.btnAoutoCmplete.TabIndex = 11
        Me.btnAoutoCmplete.Text = "Aouto Cmplete"
        Me.btnAoutoCmplete.UseSelectable = True
        '
        'btnChange
        '
        Me.btnChange.Image = CType(resources.GetObject("btnChange.Image"), System.Drawing.Image)
        Me.btnChange.Location = New System.Drawing.Point(506, 23)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(53, 36)
        Me.btnChange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.btnChange.TabIndex = 13
        Me.btnChange.TabStop = False
        '
        'FontDialog1
        '
        Me.FontDialog1.Color = System.Drawing.SystemColors.ControlText
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Text Fill|*.txt"
        '
        'MetroTabControl1
        '
        Me.MetroTabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.MetroTabControl1.Controls.Add(Me.MetroTabPage1)
        Me.MetroTabControl1.Controls.Add(Me.MetroTabPage2)
        Me.MetroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.MetroTabControl1.FontWeight = MetroFramework.MetroTabControlWeight.Regular
        Me.MetroTabControl1.Location = New System.Drawing.Point(392, 161)
        Me.MetroTabControl1.Multiline = True
        Me.MetroTabControl1.Name = "MetroTabControl1"
        Me.MetroTabControl1.SelectedIndex = 1
        Me.MetroTabControl1.Size = New System.Drawing.Size(575, 311)
        Me.MetroTabControl1.TabIndex = 6
        Me.MetroTabControl1.UseSelectable = True
        '
        'MetroTabPage1
        '
        Me.MetroTabPage1.Controls.Add(Me.txtCode)
        Me.MetroTabPage1.HorizontalScrollbarBarColor = True
        Me.MetroTabPage1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroTabPage1.HorizontalScrollbarSize = 10
        Me.MetroTabPage1.Location = New System.Drawing.Point(4, 4)
        Me.MetroTabPage1.Name = "MetroTabPage1"
        Me.MetroTabPage1.Size = New System.Drawing.Size(567, 272)
        Me.MetroTabPage1.TabIndex = 0
        Me.MetroTabPage1.Text = "Quiry statement"
        Me.MetroTabPage1.VerticalScrollbarBarColor = True
        Me.MetroTabPage1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroTabPage1.VerticalScrollbarSize = 10
        '
        'txtCode
        '
        Me.txtCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCode.Location = New System.Drawing.Point(0, 0)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(567, 272)
        Me.txtCode.TabIndex = 0
        Me.txtCode.Text = ""
        '
        'MetroTabPage2
        '
        Me.MetroTabPage2.Controls.Add(Me.txtCodeStore)
        Me.MetroTabPage2.Controls.Add(Me.MetroPanel1)
        Me.MetroTabPage2.Controls.Add(Me.txtAddprocedure)
        Me.MetroTabPage2.HorizontalScrollbarBarColor = True
        Me.MetroTabPage2.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroTabPage2.HorizontalScrollbarSize = 10
        Me.MetroTabPage2.Location = New System.Drawing.Point(4, 4)
        Me.MetroTabPage2.Name = "MetroTabPage2"
        Me.MetroTabPage2.Size = New System.Drawing.Size(567, 269)
        Me.MetroTabPage2.TabIndex = 1
        Me.MetroTabPage2.Text = "Store procedure"
        Me.MetroTabPage2.UseStyleColors = True
        Me.MetroTabPage2.VerticalScrollbarBarColor = True
        Me.MetroTabPage2.VerticalScrollbarHighlightOnWheel = False
        Me.MetroTabPage2.VerticalScrollbarSize = 10
        '
        'txtCodeStore
        '
        Me.txtCodeStore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodeStore.Location = New System.Drawing.Point(0, 154)
        Me.txtCodeStore.Name = "txtCodeStore"
        Me.txtCodeStore.Size = New System.Drawing.Size(567, 115)
        Me.txtCodeStore.TabIndex = 3
        Me.txtCodeStore.Text = ""
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.Add(Me.lbMsg)
        Me.MetroPanel1.Controls.Add(Me.btnRun)
        Me.MetroPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(0, 109)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(567, 45)
        Me.MetroPanel1.TabIndex = 3
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'lbMsg
        '
        Me.lbMsg.AutoSize = True
        Me.lbMsg.Location = New System.Drawing.Point(140, 13)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(31, 19)
        Me.lbMsg.TabIndex = 9
        Me.lbMsg.Text = "Run"
        Me.lbMsg.Visible = False
        '
        'btnRun
        '
        Me.btnRun.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnRun.Location = New System.Drawing.Point(20, 8)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(107, 29)
        Me.btnRun.TabIndex = 8
        Me.btnRun.Text = "Run"
        Me.btnRun.UseSelectable = True
        '
        'txtAddprocedure
        '
        Me.txtAddprocedure.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtAddprocedure.Location = New System.Drawing.Point(0, 0)
        Me.txtAddprocedure.Name = "txtAddprocedure"
        Me.txtAddprocedure.Size = New System.Drawing.Size(567, 109)
        Me.txtAddprocedure.TabIndex = 2
        Me.txtAddprocedure.Text = ""
        '
        'FrmAccessCode
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(987, 560)
        Me.Controls.Add(Me.MetroTabControl1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAccessCode"
        Me.Text = "Access Code"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGVTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.btnChange, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MetroTabControl1.ResumeLayout(False)
        Me.MetroTabPage1.ResumeLayout(False)
        Me.MetroTabPage2.ResumeLayout(False)
        Me.MetroPanel1.ResumeLayout(False)
        Me.MetroPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DGVColumn As MetroFramework.Controls.MetroGrid
    Friend WithEvents DGVTable As MetroFramework.Controls.MetroGrid
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HjgToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LangugeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents VBnetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ForeColoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BackGroundColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MultipleSelectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDelete As MetroFramework.Controls.MetroButton
    Friend WithEvents btnUpdate As MetroFramework.Controls.MetroButton
    Friend WithEvents btnInsert As MetroFramework.Controls.MetroButton
    Friend WithEvents btnSelect As MetroFramework.Controls.MetroButton
    Friend WithEvents btnConnection As MetroFramework.Controls.MetroButton
    Friend WithEvents txtName As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btnFillcomboBox As MetroFramework.Controls.MetroButton
    Friend WithEvents btnAoutoCmplete As MetroFramework.Controls.MetroButton
    Friend WithEvents btnChange As System.Windows.Forms.PictureBox
    Friend WithEvents ChSelectAll As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ORDINAL_POSITION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MetroTabControl1 As MetroFramework.Controls.MetroTabControl
    Friend WithEvents MetroTabPage1 As MetroFramework.Controls.MetroTabPage
    Friend WithEvents txtCode As System.Windows.Forms.RichTextBox
    Friend WithEvents MetroTabPage2 As MetroFramework.Controls.MetroTabPage
    Friend WithEvents txtCodeStore As System.Windows.Forms.RichTextBox
    Friend WithEvents MetroPanel1 As MetroFramework.Controls.MetroPanel
    Friend WithEvents lbMsg As MetroFramework.Controls.MetroLabel
    Friend WithEvents btnRun As MetroFramework.Controls.MetroButton
    Friend WithEvents txtAddprocedure As System.Windows.Forms.RichTextBox
End Class
