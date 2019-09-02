<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSQLLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSQLLog))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbAuthentication = New MetroFramework.Controls.MetroComboBox()
        Me.txtuserpass = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel5 = New MetroFramework.Controls.MetroLabel()
        Me.btnConnect = New MetroFramework.Controls.MetroButton()
        Me.btnCancel = New MetroFramework.Controls.MetroButton()
        Me.txtusername = New System.Windows.Forms.ComboBox()
        Me.cmbServer = New System.Windows.Forms.ComboBox()
        Me.cmbDataBase = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
        Me.Label6.Location = New System.Drawing.Point(1, 324)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 45)
        Me.Label6.TabIndex = 18
        '
        'cmbAuthentication
        '
        Me.cmbAuthentication.FormattingEnabled = True
        Me.cmbAuthentication.ItemHeight = 23
        Me.cmbAuthentication.Items.AddRange(New Object() {"Windows Authentication", "SQL Server Authentication"})
        Me.cmbAuthentication.Location = New System.Drawing.Point(137, 192)
        Me.cmbAuthentication.Name = "cmbAuthentication"
        Me.cmbAuthentication.Size = New System.Drawing.Size(253, 29)
        Me.cmbAuthentication.TabIndex = 19
        Me.cmbAuthentication.UseSelectable = True
        '
        'txtuserpass
        '
        '
        '
        '
        Me.txtuserpass.CustomButton.Image = Nothing
        Me.txtuserpass.CustomButton.Location = New System.Drawing.Point(229, 2)
        Me.txtuserpass.CustomButton.Name = ""
        Me.txtuserpass.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.txtuserpass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtuserpass.CustomButton.TabIndex = 1
        Me.txtuserpass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtuserpass.CustomButton.UseSelectable = True
        Me.txtuserpass.CustomButton.Visible = False
        Me.txtuserpass.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtuserpass.Lines = New String(-1) {}
        Me.txtuserpass.Location = New System.Drawing.Point(137, 284)
        Me.txtuserpass.MaxLength = 32767
        Me.txtuserpass.Name = "txtuserpass"
        Me.txtuserpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtuserpass.PromptText = "Password"
        Me.txtuserpass.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtuserpass.SelectedText = ""
        Me.txtuserpass.SelectionLength = 0
        Me.txtuserpass.SelectionStart = 0
        Me.txtuserpass.ShortcutsEnabled = True
        Me.txtuserpass.Size = New System.Drawing.Size(253, 26)
        Me.txtuserpass.TabIndex = 20
        Me.txtuserpass.UseSelectable = True
        Me.txtuserpass.UseSystemPasswordChar = True
        Me.txtuserpass.WaterMark = "Password"
        Me.txtuserpass.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtuserpass.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(41, 102)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(90, 19)
        Me.MetroLabel1.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroLabel1.TabIndex = 21
        Me.MetroLabel1.Text = "Server name :"
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(61, 149)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(70, 19)
        Me.MetroLabel2.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroLabel2.TabIndex = 21
        Me.MetroLabel2.Text = "DataBase :"
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(28, 197)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(103, 19)
        Me.MetroLabel3.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroLabel3.TabIndex = 21
        Me.MetroLabel3.Text = "Authentication  :"
        '
        'MetroLabel4
        '
        Me.MetroLabel4.AutoSize = True
        Me.MetroLabel4.Location = New System.Drawing.Point(52, 244)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(79, 19)
        Me.MetroLabel4.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroLabel4.TabIndex = 21
        Me.MetroLabel4.Text = "User name :"
        '
        'MetroLabel5
        '
        Me.MetroLabel5.AutoSize = True
        Me.MetroLabel5.Location = New System.Drawing.Point(60, 287)
        Me.MetroLabel5.Name = "MetroLabel5"
        Me.MetroLabel5.Size = New System.Drawing.Size(71, 19)
        Me.MetroLabel5.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroLabel5.TabIndex = 21
        Me.MetroLabel5.Text = "Password :"
        '
        'btnConnect
        '
        Me.btnConnect.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnConnect.Location = New System.Drawing.Point(137, 324)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(76, 23)
        Me.btnConnect.TabIndex = 22
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseSelectable = True
        '
        'btnCancel
        '
        Me.btnCancel.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnCancel.Location = New System.Drawing.Point(314, 324)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(76, 23)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseSelectable = True
        '
        'txtusername
        '
        Me.txtusername.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtusername.FormattingEnabled = True
        Me.txtusername.Location = New System.Drawing.Point(137, 242)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(253, 27)
        Me.txtusername.TabIndex = 23
        '
        'cmbServer
        '
        Me.cmbServer.FormattingEnabled = True
        Me.cmbServer.Location = New System.Drawing.Point(137, 98)
        Me.cmbServer.Name = "cmbServer"
        Me.cmbServer.Size = New System.Drawing.Size(253, 27)
        Me.cmbServer.TabIndex = 24
        '
        'cmbDataBase
        '
        Me.cmbDataBase.FormattingEnabled = True
        Me.cmbDataBase.Location = New System.Drawing.Point(137, 145)
        Me.cmbDataBase.Name = "cmbDataBase"
        Me.cmbDataBase.Size = New System.Drawing.Size(253, 27)
        Me.cmbDataBase.TabIndex = 24
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(395, 98)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 27)
        Me.Button1.TabIndex = 26
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(395, 145)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(28, 27)
        Me.Button2.TabIndex = 26
        Me.Button2.UseVisualStyleBackColor = False
        '
        'FrmSQLLog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(446, 367)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmbDataBase)
        Me.Controls.Add(Me.cmbServer)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.MetroLabel5)
        Me.Controls.Add(Me.MetroLabel4)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.txtuserpass)
        Me.Controls.Add(Me.cmbAuthentication)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSQLLog"
        Me.Text = "Connect to DataBase"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbAuthentication As MetroFramework.Controls.MetroComboBox
    Friend WithEvents txtuserpass As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel4 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel5 As MetroFramework.Controls.MetroLabel
    Friend WithEvents btnConnect As MetroFramework.Controls.MetroButton
    Friend WithEvents btnCancel As MetroFramework.Controls.MetroButton
    Friend WithEvents txtusername As System.Windows.Forms.ComboBox
    Friend WithEvents cmbServer As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataBase As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
