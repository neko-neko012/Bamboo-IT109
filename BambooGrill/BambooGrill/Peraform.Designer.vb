<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Peraform
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
        TableLayoutPanel1 = New TableLayoutPanel()
        PFTotallbl = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Panel2 = New Panel()
        Cancelbtn = New Button()
        Proceedbtn = New Button()
        Label1 = New Label()
        Moneyinputlbl = New TextBox()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(595, 505)
        Panel1.TabIndex = 0
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(PFTotallbl, 1, 0)
        TableLayoutPanel1.Controls.Add(Label3, 0, 0)
        TableLayoutPanel1.Controls.Add(Label4, 0, 1)
        TableLayoutPanel1.Controls.Add(Panel2, 1, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(595, 505)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' PFTotallbl
        ' 
        PFTotallbl.AutoSize = True
        PFTotallbl.Dock = DockStyle.Fill
        PFTotallbl.Font = New Font("Segoe UI", 30F)
        PFTotallbl.Location = New Point(300, 0)
        PFTotallbl.Name = "PFTotallbl"
        PFTotallbl.Size = New Size(292, 252)
        PFTotallbl.TabIndex = 0
        PFTotallbl.Text = "Label2"
        PFTotallbl.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Dock = DockStyle.Fill
        Label3.Font = New Font("Segoe UI", 30F)
        Label3.Location = New Point(3, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(291, 252)
        Label3.TabIndex = 1
        Label3.Text = "Total"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Dock = DockStyle.Fill
        Label4.Font = New Font("Segoe UI", 30F)
        Label4.Location = New Point(3, 252)
        Label4.Name = "Label4"
        Label4.Size = New Size(291, 253)
        Label4.TabIndex = 2
        Label4.Text = "Label4"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Moneyinputlbl)
        Panel2.Controls.Add(Cancelbtn)
        Panel2.Controls.Add(Proceedbtn)
        Panel2.Location = New Point(300, 255)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(292, 247)
        Panel2.TabIndex = 3
        ' 
        ' Cancelbtn
        ' 
        Cancelbtn.Location = New Point(46, 191)
        Cancelbtn.Name = "Cancelbtn"
        Cancelbtn.Size = New Size(94, 29)
        Cancelbtn.TabIndex = 2
        Cancelbtn.Text = "Cancel"
        Cancelbtn.UseVisualStyleBackColor = True
        ' 
        ' Proceedbtn
        ' 
        Proceedbtn.Location = New Point(146, 191)
        Proceedbtn.Name = "Proceedbtn"
        Proceedbtn.Size = New Size(94, 29)
        Proceedbtn.TabIndex = 1
        Proceedbtn.Text = "Ok"
        Proceedbtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(53, 20)
        Label1.TabIndex = 0
        Label1.Text = "Label1"
        ' 
        ' Moneyinputlbl
        ' 
        Moneyinputlbl.Font = New Font("Segoe UI", 20F)
        Moneyinputlbl.Location = New Point(46, 93)
        Moneyinputlbl.Name = "Moneyinputlbl"
        Moneyinputlbl.Size = New Size(194, 52)
        Moneyinputlbl.TabIndex = 3
        ' 
        ' Peraform
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(595, 505)
        Controls.Add(Panel1)
        Name = "Peraform"
        Text = "Peraform"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PFTotallbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Cancelbtn As Button
    Friend WithEvents Proceedbtn As Button
    Friend WithEvents Moneyinputlbl As TextBox
End Class
