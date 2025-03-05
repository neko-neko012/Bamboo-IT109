<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Customerdetails
    Inherits System.Windows.Forms.Form

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
        Panel1 = New Panel()
        donebtn = New Button()
        CusAddress = New TextBox()
        CusPhone = New TextBox()
        CusLastName = New TextBox()
        CusFirstName = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(donebtn)
        Panel1.Controls.Add(CusAddress)
        Panel1.Controls.Add(CusPhone)
        Panel1.Controls.Add(CusLastName)
        Panel1.Controls.Add(CusFirstName)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(800, 450)
        Panel1.TabIndex = 1
        ' 
        ' donebtn
        ' 
        donebtn.Location = New Point(417, 202)
        donebtn.Name = "donebtn"
        donebtn.Size = New Size(94, 29)
        donebtn.TabIndex = 8
        donebtn.Text = "Done"
        donebtn.UseVisualStyleBackColor = True
        ' 
        ' CusAddress
        ' 
        CusAddress.Font = New Font("Segoe UI", 12F)
        CusAddress.Location = New Point(190, 154)
        CusAddress.Multiline = True
        CusAddress.Name = "CusAddress"
        CusAddress.Size = New Size(229, 27)
        CusAddress.TabIndex = 7
        ' 
        ' CusPhone
        ' 
        CusPhone.Font = New Font("Segoe UI", 12F)
        CusPhone.Location = New Point(190, 114)
        CusPhone.Name = "CusPhone"
        CusPhone.Size = New Size(229, 34)
        CusPhone.TabIndex = 6
        ' 
        ' CusLastName
        ' 
        CusLastName.Font = New Font("Segoe UI", 12F)
        CusLastName.Location = New Point(191, 71)
        CusLastName.Name = "CusLastName"
        CusLastName.Size = New Size(229, 34)
        CusLastName.TabIndex = 5
        ' 
        ' CusFirstName
        ' 
        CusFirstName.Font = New Font("Segoe UI", 12F)
        CusFirstName.Location = New Point(191, 31)
        CusFirstName.Name = "CusFirstName"
        CusFirstName.Size = New Size(229, 34)
        CusFirstName.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(36, 153)
        Label4.Name = "Label4"
        Label4.Size = New Size(86, 28)
        Label4.TabIndex = 3
        Label4.Text = "Address:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(36, 114)
        Label3.Name = "Label3"
        Label3.Size = New Size(148, 28)
        Label3.TabIndex = 2
        Label3.Text = "Phone Number:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(36, 71)
        Label2.Name = "Label2"
        Label2.Size = New Size(107, 28)
        Label2.TabIndex = 1
        Label2.Text = "Last Name:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(36, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(110, 28)
        Label1.TabIndex = 0
        Label1.Text = "First Name:"
        ' 
        ' Customerdetails
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Panel1)
        Name = "Customerdetails"
        Text = "Customerdetails"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents donebtn As Button
    Friend WithEvents CusAddress As TextBox
    Friend WithEvents CusPhone As TextBox
    Friend WithEvents CusLastName As TextBox
    Friend WithEvents CusFirstName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
