<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgressLogForm
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.LogTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ProgressBar
        '
        Me.ProgressBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProgressBar.Location = New System.Drawing.Point(0, 0)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(400, 23)
        Me.ProgressBar.TabIndex = 0
        '
        'LogTextBox
        '
        Me.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogTextBox.Multiline = True
        Me.LogTextBox.ReadOnly = True
        Me.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.LogTextBox.Location = New System.Drawing.Point(0, 23)
        Me.LogTextBox.Name = "LogTextBox"
        Me.LogTextBox.Size = New System.Drawing.Size(400, 277)
        Me.LogTextBox.TabIndex = 1
        '
        'ProgressLogForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 300)
        Me.Controls.Add(Me.LogTextBox)
        Me.Controls.Add(Me.ProgressBar)
        Me.Name = "ProgressLogForm"
        Me.Text = "Progress and Log"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents LogTextBox As System.Windows.Forms.TextBox
End Class