<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAccessLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAccessLog))
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.MetroLabel5 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.comboBox1 = New MetroFramework.Controls.MetroComboBox()
        Me.txtconfirmpass = New MetroFramework.Controls.MetroTextBox()
        Me.txtuserpass = New MetroFramework.Controls.MetroTextBox()
        Me.btnCancel = New MetroFramework.Controls.MetroButton()
        Me.btnConnect = New MetroFramework.Controls.MetroButton()
        Me.txtDataBase = New MetroFramework.Controls.MetroTextBox()
        Me.cmbLoginType = New MetroFramework.Controls.MetroComboBox()
        Me.btnOpen = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.btnOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OFD
        '
        '
        'MetroLabel5
        '
        Me.MetroLabel5.AutoSize = True
        Me.MetroLabel5.Location = New System.Drawing.Point(52, 256)
        Me.MetroLabel5.Name = "MetroLabel5"
        Me.MetroLabel5.Size = New System.Drawing.Size(71, 19)
        Me.MetroLabel5.Style = MetroFramework.MetroColorStyle.Black
        Me.MetroLabel5.TabIndex = 31
        Me.MetroLabel5.Text = "Password :"
        '
        'MetroLabel4
        '
        Me.MetroLabel4.AutoSize = True
        Me.MetroLabel4.Location = New System.Drawing.Point(44, 222)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(79, 19)
        Me.MetroLabel4.Style = MetroFramework.MetroColorStyle.Black
        Me.MetroLabel4.TabIndex = 32
        Me.MetroLabel4.Text = "User name :"
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(39, 186)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(84, 19)
        Me.MetroLabel3.Style = MetroFramework.MetroColorStyle.Black
        Me.MetroLabel3.TabIndex = 33
        Me.MetroLabel3.Text = "Login  Type :"
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(53, 149)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(70, 19)
        Me.MetroLabel2.Style = MetroFramework.MetroColorStyle.Black
        Me.MetroLabel2.TabIndex = 34
        Me.MetroLabel2.Text = "DataBase :"
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(20, 109)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(103, 19)
        Me.MetroLabel1.Style = MetroFramework.MetroColorStyle.Black
        Me.MetroLabel1.TabIndex = 35
        Me.MetroLabel1.Text = "Access  version :"
        '
        'comboBox1
        '
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.ItemHeight = 23
        Me.comboBox1.Items.AddRange(New Object() {"2010", "2003"})
        Me.comboBox1.Location = New System.Drawing.Point(129, 105)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(254, 29)
        Me.comboBox1.TabIndex = 36
        Me.comboBox1.UseSelectable = True
        '
        'txtconfirmpass
        '
        '
        '
        '
        Me.txtconfirmpass.CustomButton.Image = Nothing
        Me.txtconfirmpass.CustomButton.Location = New System.Drawing.Point(230, 2)
        Me.txtconfirmpass.CustomButton.Name = ""
        Me.txtconfirmpass.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.txtconfirmpass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtconfirmpass.CustomButton.TabIndex = 1
        Me.txtconfirmpass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtconfirmpass.CustomButton.UseSelectable = True
        Me.txtconfirmpass.CustomButton.Visible = False
        Me.txtconfirmpass.Enabled = False
        Me.txtconfirmpass.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtconfirmpass.Lines = New String(-1) {}
        Me.txtconfirmpass.Location = New System.Drawing.Point(129, 254)
        Me.txtconfirmpass.MaxLength = 32767
        Me.txtconfirmpass.Name = "txtconfirmpass"
        Me.txtconfirmpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtconfirmpass.PromptText = "Confirm password"
        Me.txtconfirmpass.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtconfirmpass.SelectedText = ""
        Me.txtconfirmpass.SelectionLength = 0
        Me.txtconfirmpass.SelectionStart = 0
        Me.txtconfirmpass.ShortcutsEnabled = True
        Me.txtconfirmpass.Size = New System.Drawing.Size(254, 26)
        Me.txtconfirmpass.TabIndex = 37
        Me.txtconfirmpass.UseSelectable = True
        Me.txtconfirmpass.UseSystemPasswordChar = True
        Me.txtconfirmpass.WaterMark = "Confirm password"
        Me.txtconfirmpass.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtconfirmpass.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtuserpass
        '
        '
        '
        '
        Me.txtuserpass.CustomButton.Image = Nothing
        Me.txtuserpass.CustomButton.Location = New System.Drawing.Point(230, 2)
        Me.txtuserpass.CustomButton.Name = ""
        Me.txtuserpass.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.txtuserpass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtuserpass.CustomButton.TabIndex = 1
        Me.txtuserpass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtuserpass.CustomButton.UseSelectable = True
        Me.txtuserpass.CustomButton.Visible = False
        Me.txtuserpass.Enabled = False
        Me.txtuserpass.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtuserpass.Lines = New String(-1) {}
        Me.txtuserpass.Location = New System.Drawing.Point(129, 220)
        Me.txtuserpass.MaxLength = 32767
        Me.txtuserpass.Name = "txtuserpass"
        Me.txtuserpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtuserpass.PromptText = "Password"
        Me.txtuserpass.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtuserpass.SelectedText = ""
        Me.txtuserpass.SelectionLength = 0
        Me.txtuserpass.SelectionStart = 0
        Me.txtuserpass.ShortcutsEnabled = True
        Me.txtuserpass.Size = New System.Drawing.Size(254, 26)
        Me.txtuserpass.TabIndex = 39
        Me.txtuserpass.UseSelectable = True
        Me.txtuserpass.UseSystemPasswordChar = True
        Me.txtuserpass.WaterMark = "Password"
        Me.txtuserpass.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtuserpass.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'btnCancel
        '
        Me.btnCancel.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnCancel.Location = New System.Drawing.Point(307, 299)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(76, 23)
        Me.btnCancel.TabIndex = 40
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseSelectable = True
        '
        'btnConnect
        '
        Me.btnConnect.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnConnect.Location = New System.Drawing.Point(129, 299)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(76, 23)
        Me.btnConnect.TabIndex = 41
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseSelectable = True
        '
        'txtDataBase
        '
        '
        '
        '
        Me.txtDataBase.CustomButton.Image = Nothing
        Me.txtDataBase.CustomButton.Location = New System.Drawing.Point(198, 1)
        Me.txtDataBase.CustomButton.Name = ""
        Me.txtDataBase.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.txtDataBase.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtDataBase.CustomButton.TabIndex = 1
        Me.txtDataBase.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtDataBase.CustomButton.UseSelectable = True
        Me.txtDataBase.CustomButton.Visible = False
        Me.txtDataBase.Lines = New String(-1) {}
        Me.txtDataBase.Location = New System.Drawing.Point(129, 145)
        Me.txtDataBase.MaxLength = 32767
        Me.txtDataBase.Name = "txtDataBase"
        Me.txtDataBase.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDataBase.ReadOnly = True
        Me.txtDataBase.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtDataBase.SelectedText = ""
        Me.txtDataBase.SelectionLength = 0
        Me.txtDataBase.SelectionStart = 0
        Me.txtDataBase.ShortcutsEnabled = True
        Me.txtDataBase.Size = New System.Drawing.Size(220, 23)
        Me.txtDataBase.TabIndex = 42
        Me.txtDataBase.UseSelectable = True
        Me.txtDataBase.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtDataBase.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'cmbLoginType
        '
        Me.cmbLoginType.FormattingEnabled = True
        Me.cmbLoginType.ItemHeight = 23
        Me.cmbLoginType.Items.AddRange(New Object() {"Normal", "By password"})
        Me.cmbLoginType.Location = New System.Drawing.Point(129, 178)
        Me.cmbLoginType.Name = "cmbLoginType"
        Me.cmbLoginType.Size = New System.Drawing.Size(254, 29)
        Me.cmbLoginType.TabIndex = 36
        Me.cmbLoginType.UseSelectable = True
        '
        'btnOpen
        '
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.Location = New System.Drawing.Point(355, 143)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(28, 28)
        Me.btnOpen.TabIndex = 43
        Me.btnOpen.TabStop = False
        '
        'Label1
        '
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.Location = New System.Drawing.Point(16, 317)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 45)
        Me.Label1.TabIndex = 44
        '
        'FrmAccessLog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(446, 367)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.txtDataBase)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.txtuserpass)
        Me.Controls.Add(Me.txtconfirmpass)
        Me.Controls.Add(Me.cmbLoginType)
        Me.Controls.Add(Me.comboBox1)
        Me.Controls.Add(Me.MetroLabel5)
        Me.Controls.Add(Me.MetroLabel4)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(446, 367)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(446, 367)
        Me.Name = "FrmAccessLog"
        Me.Text = "Connect to DataBase"
        CType(Me.btnOpen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MetroLabel5 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel4 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents comboBox1 As MetroFramework.Controls.MetroComboBox
    Friend WithEvents txtconfirmpass As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtuserpass As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btnCancel As MetroFramework.Controls.MetroButton
    Friend WithEvents btnConnect As MetroFramework.Controls.MetroButton
    Friend WithEvents txtDataBase As MetroFramework.Controls.MetroTextBox
    Friend WithEvents cmbLoginType As MetroFramework.Controls.MetroComboBox
    Friend WithEvents btnOpen As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
