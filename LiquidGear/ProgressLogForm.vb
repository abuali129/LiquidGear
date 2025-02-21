Imports System.Text

Public Class ProgressLogForm
    Private _log As New StringBuilder()

    Public Sub New()
        InitializeComponent()
    End Sub

    ' Update the progress bar
    Public Sub UpdateProgress(value As Integer, max As Integer)
        If ProgressBar.InvokeRequired Then
            ProgressBar.Invoke(New Action(Of Integer, Integer)(AddressOf UpdateProgress), value, max)
        Else
            ProgressBar.Maximum = max
            ProgressBar.Value = Math.Min(value, max)
        End If
    End Sub

    ' Append a message to the log
    Public Sub LogMessage(message As String)
        If LogTextBox.InvokeRequired Then
            LogTextBox.BeginInvoke(New Action(Of String)(AddressOf LogMessage), message)
        Else
            _log.AppendLine(message)
            LogTextBox.AppendText(message & Environment.NewLine)
            LogTextBox.SelectionStart = LogTextBox.Text.Length
            LogTextBox.ScrollToCaret()
        End If
    End Sub

    ' Reset the progress bar and log
    Public Sub ResetProgress()
        If ProgressBar.InvokeRequired Then
            ProgressBar.Invoke(New Action(AddressOf ResetProgress))
        Else
            ProgressBar.Value = 0
            ProgressBar.Maximum = 100
            _log.Clear()
            LogTextBox.Clear()
        End If
    End Sub
End Class
