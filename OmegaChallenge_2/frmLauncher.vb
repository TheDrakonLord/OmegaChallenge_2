
Public Class frmLauncher
    ' Author: Neal Jamieson
    ' Date: 4/7/2019
    ' Version: 1.0.0.0
    ' Description:
    ' Provides an interface for users to input application settings.
    ' once settings have been input, launches main application
    Const RepeatEnabled As Boolean = True
    Const DurModEnabled As Boolean = True

    Public bolRepeatOn As Boolean
    ''' <summary>
    ''' 0 = short, 1 = standard, 2 = Long
    ''' </summary>
    Public dblDurationMod As Double

    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' [ALG] FRM L Load
        ' [ALG] set server
        txtServer.Text = "Twitch.tv"
        ' [ALG] set nick
        txtNick.Text = My.Settings.Nick

        If DurModEnabled Then
            gbxDuration.Visible = True
        Else
            gbxDuration.Visible = False
        End If
        If RepeatEnabled Then
            gbxRepeat.Visible = True
        Else
            gbxRepeat.Visible = False
        End If

    End Sub

    Private Sub btnLaunch_Click(sender As Object, e As EventArgs) Handles btnLaunch.Click
        ' [ALG] FRM L Button Launch
        ' [ALG] set user inputs
        Select Case True
            Case radRepeatAvoidOn.Checked
                bolRepeatOn = True
            Case radRepeatAvoidOff.Checked
                bolRepeatOn = False
            Case Else
                bolRepeatOn = True
        End Select



        Select Case True
            Case radDurShort.Checked
                dblDurationMod = 0.5
            Case radDurStandard.Checked
                dblDurationMod = 1
            Case radDurLong.Checked
                dblDurationMod = 2
            Case Else
                dblDurationMod = 1
        End Select

        ' [ALG] error check
        If txtChannel.Text.Equals(String.Empty) Then
            MessageBox.Show("Channel Name is required", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            ' [ALG] set server
            My.Settings.Channel = txtChannel.Text
            ' [ALG] open frm main
            frmMain.Show()
        End If

    End Sub
End Class
