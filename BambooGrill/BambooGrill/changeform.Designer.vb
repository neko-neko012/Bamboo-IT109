<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class changeform
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
        TableLayoutPanel1 = New TableLayoutPanel()
        Label1 = New Label()
        changelbl = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        CFDonebtn = New Button()
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 48.4F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 51.6F))
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(changelbl, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel1.Size = New Size(411, 276)
        TableLayoutPanel1.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Segoe UI", 20.0F)
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(192, 276)
        Label1.TabIndex = 0
        Label1.Text = "Change:"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' changelbl
        ' 
        changelbl.AutoSize = True
        changelbl.Dock = DockStyle.Fill
        changelbl.Font = New Font("Segoe UI", 20.0F)
        changelbl.Location = New Point(201, 0)
        changelbl.Name = "changelbl"
        changelbl.Size = New Size(207, 276)
        changelbl.TabIndex = 1
        changelbl.Text = "Label2"
        changelbl.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(411, 276)
        Panel1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(CFDonebtn)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 211)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(411, 65)
        Panel2.TabIndex = 1
        ' 
        ' CFDonebtn
        ' 
        CFDonebtn.Location = New Point(133, 15)
        CFDonebtn.Name = "CFDonebtn"
        CFDonebtn.Size = New Size(138, 29)
        CFDonebtn.TabIndex = 0
        CFDonebtn.Text = "Print Receipt"
        CFDonebtn.UseVisualStyleBackColor = True
        ' 
        ' ChangeForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(411, 276)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "ChangeForm"
        Text = "changeform"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents changelbl As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents CFDonebtn As Button
End Class
