Public Class ProgressForm
    Private _cancellationTokenSource As Threading.CancellationTokenSource

    Public Sub New()
        InitializeComponent()
        _cancellationTokenSource = New Threading.CancellationTokenSource()
    End Sub

    ' Log messages to the log box
    Public Sub LogMessage(message As String)
        If LogBox.InvokeRequired Then
            LogBox.Invoke(New Action(Of String)(AddressOf LogMessage), message)
        Else
            LogBox.AppendText(message & Environment.NewLine)
            LogBox.SelectionStart = LogBox.Text.Length
            LogBox.ScrollToCaret()
        End If
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

    ' Cancel the operation
    Public ReadOnly Property CancellationToken As Threading.CancellationToken
        Get
            Return _cancellationTokenSource.Token
        End Get
    End Property

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        _cancellationTokenSource.Cancel()
        BtnCancel.Enabled = False
        LogMessage("Operation canceled by user.")
    End Sub
End Class