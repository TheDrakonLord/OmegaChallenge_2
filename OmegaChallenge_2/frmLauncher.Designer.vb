<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLauncher
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLauncher))
        Me.btnLaunch = New System.Windows.Forms.Button()
        Me.gbxBot = New System.Windows.Forms.GroupBox()
        Me.lblChannel = New System.Windows.Forms.Label()
        Me.lblNick = New System.Windows.Forms.Label()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.txtChannel = New System.Windows.Forms.TextBox()
        Me.txtNick = New System.Windows.Forms.TextBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.gbxRepeat = New System.Windows.Forms.GroupBox()
        Me.rtbRepeatAvoid = New System.Windows.Forms.RichTextBox()
        Me.radRepeatAvoidOff = New System.Windows.Forms.RadioButton()
        Me.radRepeatAvoidOn = New System.Windows.Forms.RadioButton()
        Me.gbxNote = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbxDuration = New System.Windows.Forms.GroupBox()
        Me.radDurLong = New System.Windows.Forms.RadioButton()
        Me.radDurStandard = New System.Windows.Forms.RadioButton()
        Me.radDurShort = New System.Windows.Forms.RadioButton()
        Me.gbxBot.SuspendLayout()
        Me.gbxRepeat.SuspendLayout()
        Me.gbxNote.SuspendLayout()
        Me.gbxDuration.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLaunch
        '
        Me.btnLaunch.Location = New System.Drawing.Point(12, 259)
        Me.btnLaunch.Name = "btnLaunch"
        Me.btnLaunch.Size = New System.Drawing.Size(442, 54)
        Me.btnLaunch.TabIndex = 0
        Me.btnLaunch.Text = "Launch"
        Me.btnLaunch.UseVisualStyleBackColor = True
        '
        'gbxBot
        '
        Me.gbxBot.Controls.Add(Me.lblChannel)
        Me.gbxBot.Controls.Add(Me.lblNick)
        Me.gbxBot.Controls.Add(Me.lblServer)
        Me.gbxBot.Controls.Add(Me.txtChannel)
        Me.gbxBot.Controls.Add(Me.txtNick)
        Me.gbxBot.Controls.Add(Me.txtServer)
        Me.gbxBot.Location = New System.Drawing.Point(12, 12)
        Me.gbxBot.Name = "gbxBot"
        Me.gbxBot.Size = New System.Drawing.Size(239, 98)
        Me.gbxBot.TabIndex = 1
        Me.gbxBot.TabStop = False
        Me.gbxBot.Text = "Bot Properties"
        '
        'lblChannel
        '
        Me.lblChannel.AutoSize = True
        Me.lblChannel.Location = New System.Drawing.Point(12, 71)
        Me.lblChannel.Name = "lblChannel"
        Me.lblChannel.Size = New System.Drawing.Size(80, 13)
        Me.lblChannel.TabIndex = 5
        Me.lblChannel.Text = "Target Channel"
        '
        'lblNick
        '
        Me.lblNick.AutoSize = True
        Me.lblNick.Location = New System.Drawing.Point(12, 42)
        Me.lblNick.Name = "lblNick"
        Me.lblNick.Size = New System.Drawing.Size(54, 13)
        Me.lblNick.TabIndex = 4
        Me.lblNick.Text = "Bot Name"
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(12, 15)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(38, 13)
        Me.lblServer.TabIndex = 3
        Me.lblServer.Text = "Server"
        '
        'txtChannel
        '
        Me.txtChannel.Location = New System.Drawing.Point(98, 68)
        Me.txtChannel.Name = "txtChannel"
        Me.txtChannel.Size = New System.Drawing.Size(135, 20)
        Me.txtChannel.TabIndex = 2
        '
        'txtNick
        '
        Me.txtNick.Location = New System.Drawing.Point(98, 39)
        Me.txtNick.Name = "txtNick"
        Me.txtNick.ReadOnly = True
        Me.txtNick.Size = New System.Drawing.Size(135, 20)
        Me.txtNick.TabIndex = 1
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(98, 12)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.ReadOnly = True
        Me.txtServer.Size = New System.Drawing.Size(135, 20)
        Me.txtServer.TabIndex = 0
        '
        'gbxRepeat
        '
        Me.gbxRepeat.Controls.Add(Me.rtbRepeatAvoid)
        Me.gbxRepeat.Controls.Add(Me.radRepeatAvoidOff)
        Me.gbxRepeat.Controls.Add(Me.radRepeatAvoidOn)
        Me.gbxRepeat.Location = New System.Drawing.Point(110, 116)
        Me.gbxRepeat.Name = "gbxRepeat"
        Me.gbxRepeat.Size = New System.Drawing.Size(236, 97)
        Me.gbxRepeat.TabIndex = 0
        Me.gbxRepeat.TabStop = False
        Me.gbxRepeat.Text = "Avoid Repeat Questions"
        '
        'rtbRepeatAvoid
        '
        Me.rtbRepeatAvoid.Location = New System.Drawing.Point(64, 44)
        Me.rtbRepeatAvoid.Name = "rtbRepeatAvoid"
        Me.rtbRepeatAvoid.ReadOnly = True
        Me.rtbRepeatAvoid.Size = New System.Drawing.Size(166, 47)
        Me.rtbRepeatAvoid.TabIndex = 2
        Me.rtbRepeatAvoid.Text = "Logs what questions have appeared and attempts to avoid them in future playthroug" &
    "hs"
        '
        'radRepeatAvoidOff
        '
        Me.radRepeatAvoidOff.AutoSize = True
        Me.radRepeatAvoidOff.Location = New System.Drawing.Point(6, 44)
        Me.radRepeatAvoidOff.Name = "radRepeatAvoidOff"
        Me.radRepeatAvoidOff.Size = New System.Drawing.Size(39, 17)
        Me.radRepeatAvoidOff.TabIndex = 1
        Me.radRepeatAvoidOff.Text = "Off"
        Me.radRepeatAvoidOff.UseVisualStyleBackColor = True
        '
        'radRepeatAvoidOn
        '
        Me.radRepeatAvoidOn.AutoSize = True
        Me.radRepeatAvoidOn.Checked = True
        Me.radRepeatAvoidOn.Location = New System.Drawing.Point(6, 20)
        Me.radRepeatAvoidOn.Name = "radRepeatAvoidOn"
        Me.radRepeatAvoidOn.Size = New System.Drawing.Size(39, 17)
        Me.radRepeatAvoidOn.TabIndex = 0
        Me.radRepeatAvoidOn.TabStop = True
        Me.radRepeatAvoidOn.Text = "On"
        Me.radRepeatAvoidOn.UseVisualStyleBackColor = True
        '
        'gbxNote
        '
        Me.gbxNote.Controls.Add(Me.Label1)
        Me.gbxNote.Location = New System.Drawing.Point(12, 215)
        Me.gbxNote.Name = "gbxNote"
        Me.gbxNote.Size = New System.Drawing.Size(445, 38)
        Me.gbxNote.TabIndex = 3
        Me.gbxNote.TabStop = False
        Me.gbxNote.Text = "Note:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(380, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "You will have an opportunity to set up your capture software on the next screen"
        '
        'gbxDuration
        '
        Me.gbxDuration.Controls.Add(Me.radDurLong)
        Me.gbxDuration.Controls.Add(Me.radDurStandard)
        Me.gbxDuration.Controls.Add(Me.radDurShort)
        Me.gbxDuration.Location = New System.Drawing.Point(257, 13)
        Me.gbxDuration.Name = "gbxDuration"
        Me.gbxDuration.Size = New System.Drawing.Size(200, 97)
        Me.gbxDuration.TabIndex = 4
        Me.gbxDuration.TabStop = False
        Me.gbxDuration.Text = "Duration"
        '
        'radDurLong
        '
        Me.radDurLong.AutoSize = True
        Me.radDurLong.Location = New System.Drawing.Point(7, 67)
        Me.radDurLong.Name = "radDurLong"
        Me.radDurLong.Size = New System.Drawing.Size(102, 17)
        Me.radDurLong.TabIndex = 2
        Me.radDurLong.Text = "Long (~60 Mins)"
        Me.radDurLong.UseVisualStyleBackColor = True
        '
        'radDurStandard
        '
        Me.radDurStandard.AutoSize = True
        Me.radDurStandard.Checked = True
        Me.radDurStandard.Location = New System.Drawing.Point(7, 43)
        Me.radDurStandard.Name = "radDurStandard"
        Me.radDurStandard.Size = New System.Drawing.Size(121, 17)
        Me.radDurStandard.TabIndex = 1
        Me.radDurStandard.TabStop = True
        Me.radDurStandard.Text = "Standard (~30 Mins)"
        Me.radDurStandard.UseVisualStyleBackColor = True
        '
        'radDurShort
        '
        Me.radDurShort.AutoSize = True
        Me.radDurShort.Location = New System.Drawing.Point(7, 19)
        Me.radDurShort.Name = "radDurShort"
        Me.radDurShort.Size = New System.Drawing.Size(103, 17)
        Me.radDurShort.TabIndex = 0
        Me.radDurShort.Text = "Short (~15 Mins)"
        Me.radDurShort.UseVisualStyleBackColor = True
        '
        'frmLauncher
        '
        Me.AcceptButton = Me.btnLaunch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 325)
        Me.Controls.Add(Me.gbxDuration)
        Me.Controls.Add(Me.gbxNote)
        Me.Controls.Add(Me.gbxRepeat)
        Me.Controls.Add(Me.gbxBot)
        Me.Controls.Add(Me.btnLaunch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmLauncher"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Launcher"
        Me.gbxBot.ResumeLayout(False)
        Me.gbxBot.PerformLayout()
        Me.gbxRepeat.ResumeLayout(False)
        Me.gbxRepeat.PerformLayout()
        Me.gbxNote.ResumeLayout(False)
        Me.gbxNote.PerformLayout()
        Me.gbxDuration.ResumeLayout(False)
        Me.gbxDuration.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnLaunch As Button
    Friend WithEvents gbxBot As GroupBox
    Friend WithEvents lblChannel As Label
    Friend WithEvents lblNick As Label
    Friend WithEvents lblServer As Label
    Friend WithEvents txtChannel As TextBox
    Friend WithEvents txtNick As TextBox
    Friend WithEvents txtServer As TextBox
    Friend WithEvents gbxRepeat As GroupBox
    Friend WithEvents rtbRepeatAvoid As RichTextBox
    Friend WithEvents radRepeatAvoidOff As RadioButton
    Friend WithEvents radRepeatAvoidOn As RadioButton
    Friend WithEvents gbxNote As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents gbxDuration As GroupBox
    Friend WithEvents radDurLong As RadioButton
    Friend WithEvents radDurStandard As RadioButton
    Friend WithEvents radDurShort As RadioButton
End Class
