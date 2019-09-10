<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.bwMammetBot = New System.ComponentModel.BackgroundWorker()
        Me.tmrSeconds = New System.Windows.Forms.Timer(Me.components)
        Me.lblQuestion = New System.Windows.Forms.Label()
        Me.lblInstruction = New System.Windows.Forms.Label()
        Me.lblA = New System.Windows.Forms.Label()
        Me.lblB = New System.Windows.Forms.Label()
        Me.lblC = New System.Windows.Forms.Label()
        Me.lblD = New System.Windows.Forms.Label()
        Me.lblAnswersHead = New System.Windows.Forms.Label()
        Me.lblTimer = New System.Windows.Forms.Label()
        Me.tmrCountdown = New System.Windows.Forms.Timer(Me.components)
        Me.lblAnswers = New System.Windows.Forms.Label()
        Me.lblValueHead = New System.Windows.Forms.Label()
        Me.lblValueFoot = New System.Windows.Forms.Label()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lbl1stName = New System.Windows.Forms.Label()
        Me.lbl1stScore = New System.Windows.Forms.Label()
        Me.lbl2ndScore = New System.Windows.Forms.Label()
        Me.lbl2ndName = New System.Windows.Forms.Label()
        Me.lbl4thScore = New System.Windows.Forms.Label()
        Me.lbl4thName = New System.Windows.Forms.Label()
        Me.lbl3rdScore = New System.Windows.Forms.Label()
        Me.lbl3rdName = New System.Windows.Forms.Label()
        Me.lbl5thScore = New System.Windows.Forms.Label()
        Me.lbl5thName = New System.Windows.Forms.Label()
        Me.lbl6thScore = New System.Windows.Forms.Label()
        Me.lbl6thName = New System.Windows.Forms.Label()
        Me.lbl7thScore = New System.Windows.Forms.Label()
        Me.lbl7thName = New System.Windows.Forms.Label()
        Me.lbl8thScore = New System.Windows.Forms.Label()
        Me.lbl8thName = New System.Windows.Forms.Label()
        Me.lbl9thScore = New System.Windows.Forms.Label()
        Me.lbl9thName = New System.Windows.Forms.Label()
        Me.bwMain = New System.ComponentModel.BackgroundWorker()
        Me.lblCapture = New System.Windows.Forms.Label()
        Me.btnReady = New System.Windows.Forms.Button()
        Me.pbrQTime = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'bwMammetBot
        '
        '
        'tmrSeconds
        '
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestion.ForeColor = System.Drawing.Color.White
        Me.lblQuestion.Location = New System.Drawing.Point(221, 15)
        Me.lblQuestion.MaximumSize = New System.Drawing.Size(597, 104)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(260, 24)
        Me.lblQuestion.TabIndex = 3
        Me.lblQuestion.Text = "The question will appear here"
        '
        'lblInstruction
        '
        Me.lblInstruction.AutoSize = True
        Me.lblInstruction.BackColor = System.Drawing.Color.Transparent
        Me.lblInstruction.ForeColor = System.Drawing.Color.White
        Me.lblInstruction.Location = New System.Drawing.Point(221, 125)
        Me.lblInstruction.MaximumSize = New System.Drawing.Size(597, 20)
        Me.lblInstruction.Name = "lblInstruction"
        Me.lblInstruction.Size = New System.Drawing.Size(569, 13)
        Me.lblInstruction.TabIndex = 4
        Me.lblInstruction.Text = "To play, enter your answer in chat by typing ! then your answer (e.g. !A). points" &
    " decrease the longer you take to answer."
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.BackColor = System.Drawing.Color.Transparent
        Me.lblA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblA.ForeColor = System.Drawing.Color.White
        Me.lblA.Location = New System.Drawing.Point(168, 206)
        Me.lblA.MaximumSize = New System.Drawing.Size(165, 117)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(155, 48)
        Me.lblA.TabIndex = 5
        Me.lblA.Text = "Answer A will go here"
        '
        'lblB
        '
        Me.lblB.AutoSize = True
        Me.lblB.BackColor = System.Drawing.Color.Transparent
        Me.lblB.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB.ForeColor = System.Drawing.Color.White
        Me.lblB.Location = New System.Drawing.Point(690, 206)
        Me.lblB.MaximumSize = New System.Drawing.Size(165, 117)
        Me.lblB.Name = "lblB"
        Me.lblB.Size = New System.Drawing.Size(154, 48)
        Me.lblB.TabIndex = 6
        Me.lblB.Text = "Answer B will go here"
        '
        'lblC
        '
        Me.lblC.AutoSize = True
        Me.lblC.BackColor = System.Drawing.Color.Transparent
        Me.lblC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblC.ForeColor = System.Drawing.Color.White
        Me.lblC.Location = New System.Drawing.Point(184, 379)
        Me.lblC.MaximumSize = New System.Drawing.Size(165, 117)
        Me.lblC.Name = "lblC"
        Me.lblC.Size = New System.Drawing.Size(155, 48)
        Me.lblC.TabIndex = 7
        Me.lblC.Text = "Answer C will go here"
        '
        'lblD
        '
        Me.lblD.AutoSize = True
        Me.lblD.BackColor = System.Drawing.Color.Transparent
        Me.lblD.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblD.ForeColor = System.Drawing.Color.White
        Me.lblD.Location = New System.Drawing.Point(690, 387)
        Me.lblD.MaximumSize = New System.Drawing.Size(165, 117)
        Me.lblD.Name = "lblD"
        Me.lblD.Size = New System.Drawing.Size(151, 48)
        Me.lblD.TabIndex = 8
        Me.lblD.Text = "Answer D wil go here"
        '
        'lblAnswersHead
        '
        Me.lblAnswersHead.AutoSize = True
        Me.lblAnswersHead.BackColor = System.Drawing.Color.Transparent
        Me.lblAnswersHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnswersHead.ForeColor = System.Drawing.Color.White
        Me.lblAnswersHead.Location = New System.Drawing.Point(2, 555)
        Me.lblAnswersHead.Name = "lblAnswersHead"
        Me.lblAnswersHead.Size = New System.Drawing.Size(131, 32)
        Me.lblAnswersHead.TabIndex = 9
        Me.lblAnswersHead.Text = "Answers:"
        '
        'lblTimer
        '
        Me.lblTimer.AutoSize = True
        Me.lblTimer.BackColor = System.Drawing.Color.Transparent
        Me.lblTimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 54.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimer.ForeColor = System.Drawing.Color.White
        Me.lblTimer.Location = New System.Drawing.Point(406, 531)
        Me.lblTimer.MaximumSize = New System.Drawing.Size(345, 76)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(179, 76)
        Me.lblTimer.TabIndex = 10
        Me.lblTimer.Text = "5:00"
        '
        'tmrCountdown
        '
        Me.tmrCountdown.Enabled = True
        Me.tmrCountdown.Interval = 1000
        '
        'lblAnswers
        '
        Me.lblAnswers.AutoSize = True
        Me.lblAnswers.BackColor = System.Drawing.Color.Transparent
        Me.lblAnswers.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnswers.ForeColor = System.Drawing.Color.White
        Me.lblAnswers.Location = New System.Drawing.Point(1, 584)
        Me.lblAnswers.MaximumSize = New System.Drawing.Size(173, 74)
        Me.lblAnswers.Name = "lblAnswers"
        Me.lblAnswers.Size = New System.Drawing.Size(71, 74)
        Me.lblAnswers.TabIndex = 11
        Me.lblAnswers.Text = "0"
        '
        'lblValueHead
        '
        Me.lblValueHead.AutoSize = True
        Me.lblValueHead.BackColor = System.Drawing.Color.Transparent
        Me.lblValueHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValueHead.ForeColor = System.Drawing.Color.White
        Me.lblValueHead.Location = New System.Drawing.Point(265, 626)
        Me.lblValueHead.Name = "lblValueHead"
        Me.lblValueHead.Size = New System.Drawing.Size(223, 29)
        Me.lblValueHead.TabIndex = 12
        Me.lblValueHead.Text = "Question is worth:"
        '
        'lblValueFoot
        '
        Me.lblValueFoot.AutoSize = True
        Me.lblValueFoot.BackColor = System.Drawing.Color.Transparent
        Me.lblValueFoot.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValueFoot.ForeColor = System.Drawing.Color.White
        Me.lblValueFoot.Location = New System.Drawing.Point(610, 623)
        Me.lblValueFoot.Name = "lblValueFoot"
        Me.lblValueFoot.Size = New System.Drawing.Size(86, 29)
        Me.lblValueFoot.TabIndex = 13
        Me.lblValueFoot.Text = "Points"
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.BackColor = System.Drawing.Color.Transparent
        Me.lblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.ForeColor = System.Drawing.Color.White
        Me.lblValue.Location = New System.Drawing.Point(482, 609)
        Me.lblValue.MaximumSize = New System.Drawing.Size(123, 53)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(86, 46)
        Me.lblValue.TabIndex = 14
        Me.lblValue.Text = "500"
        '
        'lbl1stName
        '
        Me.lbl1stName.AutoSize = True
        Me.lbl1stName.BackColor = System.Drawing.Color.Transparent
        Me.lbl1stName.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1stName.ForeColor = System.Drawing.Color.White
        Me.lbl1stName.Location = New System.Drawing.Point(275, 189)
        Me.lbl1stName.MaximumSize = New System.Drawing.Size(448, 44)
        Me.lbl1stName.Name = "lbl1stName"
        Me.lbl1stName.Size = New System.Drawing.Size(283, 44)
        Me.lbl1stName.TabIndex = 15
        Me.lbl1stName.Text = "TheDrakonLord"
        '
        'lbl1stScore
        '
        Me.lbl1stScore.AutoSize = True
        Me.lbl1stScore.BackColor = System.Drawing.Color.Transparent
        Me.lbl1stScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1stScore.ForeColor = System.Drawing.Color.White
        Me.lbl1stScore.Location = New System.Drawing.Point(275, 239)
        Me.lbl1stScore.MaximumSize = New System.Drawing.Size(448, 39)
        Me.lbl1stScore.Name = "lbl1stScore"
        Me.lbl1stScore.Size = New System.Drawing.Size(242, 39)
        Me.lbl1stScore.TabIndex = 16
        Me.lbl1stScore.Text = "239,448,190"
        '
        'lbl2ndScore
        '
        Me.lbl2ndScore.AutoSize = True
        Me.lbl2ndScore.BackColor = System.Drawing.Color.Transparent
        Me.lbl2ndScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2ndScore.ForeColor = System.Drawing.Color.White
        Me.lbl2ndScore.Location = New System.Drawing.Point(65, 344)
        Me.lbl2ndScore.MaximumSize = New System.Drawing.Size(375, 40)
        Me.lbl2ndScore.Name = "lbl2ndScore"
        Me.lbl2ndScore.Size = New System.Drawing.Size(242, 40)
        Me.lbl2ndScore.TabIndex = 18
        Me.lbl2ndScore.Text = "239,448,190"
        '
        'lbl2ndName
        '
        Me.lbl2ndName.AutoSize = True
        Me.lbl2ndName.BackColor = System.Drawing.Color.Transparent
        Me.lbl2ndName.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2ndName.ForeColor = System.Drawing.Color.White
        Me.lbl2ndName.Location = New System.Drawing.Point(65, 304)
        Me.lbl2ndName.MaximumSize = New System.Drawing.Size(375, 40)
        Me.lbl2ndName.Name = "lbl2ndName"
        Me.lbl2ndName.Size = New System.Drawing.Size(283, 40)
        Me.lbl2ndName.TabIndex = 17
        Me.lbl2ndName.Text = "TheDrakonLord"
        '
        'lbl4thScore
        '
        Me.lbl4thScore.AutoSize = True
        Me.lbl4thScore.BackColor = System.Drawing.Color.Transparent
        Me.lbl4thScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4thScore.ForeColor = System.Drawing.Color.White
        Me.lbl4thScore.Location = New System.Drawing.Point(108, 447)
        Me.lbl4thScore.MaximumSize = New System.Drawing.Size(309, 27)
        Me.lbl4thScore.Name = "lbl4thScore"
        Me.lbl4thScore.Size = New System.Drawing.Size(176, 27)
        Me.lbl4thScore.TabIndex = 20
        Me.lbl4thScore.Text = "239,448,190"
        '
        'lbl4thName
        '
        Me.lbl4thName.AutoSize = True
        Me.lbl4thName.BackColor = System.Drawing.Color.Transparent
        Me.lbl4thName.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4thName.ForeColor = System.Drawing.Color.White
        Me.lbl4thName.Location = New System.Drawing.Point(108, 413)
        Me.lbl4thName.MaximumSize = New System.Drawing.Size(309, 34)
        Me.lbl4thName.Name = "lbl4thName"
        Me.lbl4thName.Size = New System.Drawing.Size(228, 34)
        Me.lbl4thName.TabIndex = 19
        Me.lbl4thName.Text = "TheDrakonLord"
        '
        'lbl3rdScore
        '
        Me.lbl3rdScore.AutoSize = True
        Me.lbl3rdScore.BackColor = System.Drawing.Color.Transparent
        Me.lbl3rdScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3rdScore.ForeColor = System.Drawing.Color.White
        Me.lbl3rdScore.Location = New System.Drawing.Point(555, 344)
        Me.lbl3rdScore.MaximumSize = New System.Drawing.Size(375, 40)
        Me.lbl3rdScore.Name = "lbl3rdScore"
        Me.lbl3rdScore.Size = New System.Drawing.Size(242, 40)
        Me.lbl3rdScore.TabIndex = 22
        Me.lbl3rdScore.Text = "239,448,190"
        '
        'lbl3rdName
        '
        Me.lbl3rdName.AutoSize = True
        Me.lbl3rdName.BackColor = System.Drawing.Color.Transparent
        Me.lbl3rdName.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3rdName.ForeColor = System.Drawing.Color.White
        Me.lbl3rdName.Location = New System.Drawing.Point(555, 304)
        Me.lbl3rdName.MaximumSize = New System.Drawing.Size(375, 40)
        Me.lbl3rdName.Name = "lbl3rdName"
        Me.lbl3rdName.Size = New System.Drawing.Size(283, 40)
        Me.lbl3rdName.TabIndex = 21
        Me.lbl3rdName.Text = "TheDrakonLord"
        '
        'lbl5thScore
        '
        Me.lbl5thScore.AutoSize = True
        Me.lbl5thScore.BackColor = System.Drawing.Color.Transparent
        Me.lbl5thScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5thScore.ForeColor = System.Drawing.Color.White
        Me.lbl5thScore.Location = New System.Drawing.Point(589, 447)
        Me.lbl5thScore.MaximumSize = New System.Drawing.Size(309, 27)
        Me.lbl5thScore.Name = "lbl5thScore"
        Me.lbl5thScore.Size = New System.Drawing.Size(176, 27)
        Me.lbl5thScore.TabIndex = 24
        Me.lbl5thScore.Text = "239,448,190"
        '
        'lbl5thName
        '
        Me.lbl5thName.AutoSize = True
        Me.lbl5thName.BackColor = System.Drawing.Color.Transparent
        Me.lbl5thName.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5thName.ForeColor = System.Drawing.Color.White
        Me.lbl5thName.Location = New System.Drawing.Point(589, 413)
        Me.lbl5thName.MaximumSize = New System.Drawing.Size(309, 34)
        Me.lbl5thName.Name = "lbl5thName"
        Me.lbl5thName.Size = New System.Drawing.Size(228, 34)
        Me.lbl5thName.TabIndex = 23
        Me.lbl5thName.Text = "TheDrakonLord"
        '
        'lbl6thScore
        '
        Me.lbl6thScore.AutoSize = True
        Me.lbl6thScore.BackColor = System.Drawing.Color.Transparent
        Me.lbl6thScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6thScore.ForeColor = System.Drawing.Color.White
        Me.lbl6thScore.Location = New System.Drawing.Point(108, 536)
        Me.lbl6thScore.MaximumSize = New System.Drawing.Size(309, 27)
        Me.lbl6thScore.Name = "lbl6thScore"
        Me.lbl6thScore.Size = New System.Drawing.Size(176, 27)
        Me.lbl6thScore.TabIndex = 26
        Me.lbl6thScore.Text = "239,448,190"
        '
        'lbl6thName
        '
        Me.lbl6thName.AutoSize = True
        Me.lbl6thName.BackColor = System.Drawing.Color.Transparent
        Me.lbl6thName.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6thName.ForeColor = System.Drawing.Color.White
        Me.lbl6thName.Location = New System.Drawing.Point(108, 502)
        Me.lbl6thName.MaximumSize = New System.Drawing.Size(309, 34)
        Me.lbl6thName.Name = "lbl6thName"
        Me.lbl6thName.Size = New System.Drawing.Size(228, 34)
        Me.lbl6thName.TabIndex = 25
        Me.lbl6thName.Text = "TheDrakonLord"
        '
        'lbl7thScore
        '
        Me.lbl7thScore.AutoSize = True
        Me.lbl7thScore.BackColor = System.Drawing.Color.Transparent
        Me.lbl7thScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7thScore.ForeColor = System.Drawing.Color.White
        Me.lbl7thScore.Location = New System.Drawing.Point(593, 533)
        Me.lbl7thScore.MaximumSize = New System.Drawing.Size(309, 27)
        Me.lbl7thScore.Name = "lbl7thScore"
        Me.lbl7thScore.Size = New System.Drawing.Size(176, 27)
        Me.lbl7thScore.TabIndex = 28
        Me.lbl7thScore.Text = "239,448,190"
        '
        'lbl7thName
        '
        Me.lbl7thName.AutoSize = True
        Me.lbl7thName.BackColor = System.Drawing.Color.Transparent
        Me.lbl7thName.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7thName.ForeColor = System.Drawing.Color.White
        Me.lbl7thName.Location = New System.Drawing.Point(593, 499)
        Me.lbl7thName.MaximumSize = New System.Drawing.Size(309, 34)
        Me.lbl7thName.Name = "lbl7thName"
        Me.lbl7thName.Size = New System.Drawing.Size(228, 34)
        Me.lbl7thName.TabIndex = 27
        Me.lbl7thName.Text = "TheDrakonLord"
        '
        'lbl8thScore
        '
        Me.lbl8thScore.AutoSize = True
        Me.lbl8thScore.BackColor = System.Drawing.Color.Transparent
        Me.lbl8thScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl8thScore.ForeColor = System.Drawing.Color.White
        Me.lbl8thScore.Location = New System.Drawing.Point(114, 623)
        Me.lbl8thScore.MaximumSize = New System.Drawing.Size(309, 27)
        Me.lbl8thScore.Name = "lbl8thScore"
        Me.lbl8thScore.Size = New System.Drawing.Size(176, 27)
        Me.lbl8thScore.TabIndex = 30
        Me.lbl8thScore.Text = "239,448,190"
        '
        'lbl8thName
        '
        Me.lbl8thName.AutoSize = True
        Me.lbl8thName.BackColor = System.Drawing.Color.Transparent
        Me.lbl8thName.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl8thName.ForeColor = System.Drawing.Color.White
        Me.lbl8thName.Location = New System.Drawing.Point(114, 589)
        Me.lbl8thName.MaximumSize = New System.Drawing.Size(309, 34)
        Me.lbl8thName.Name = "lbl8thName"
        Me.lbl8thName.Size = New System.Drawing.Size(228, 34)
        Me.lbl8thName.TabIndex = 29
        Me.lbl8thName.Text = "TheDrakonLord"
        '
        'lbl9thScore
        '
        Me.lbl9thScore.AutoSize = True
        Me.lbl9thScore.BackColor = System.Drawing.Color.Transparent
        Me.lbl9thScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl9thScore.ForeColor = System.Drawing.Color.White
        Me.lbl9thScore.Location = New System.Drawing.Point(591, 618)
        Me.lbl9thScore.MaximumSize = New System.Drawing.Size(309, 27)
        Me.lbl9thScore.Name = "lbl9thScore"
        Me.lbl9thScore.Size = New System.Drawing.Size(176, 27)
        Me.lbl9thScore.TabIndex = 32
        Me.lbl9thScore.Text = "239,448,190"
        '
        'lbl9thName
        '
        Me.lbl9thName.AutoSize = True
        Me.lbl9thName.BackColor = System.Drawing.Color.Transparent
        Me.lbl9thName.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl9thName.ForeColor = System.Drawing.Color.White
        Me.lbl9thName.Location = New System.Drawing.Point(591, 584)
        Me.lbl9thName.MaximumSize = New System.Drawing.Size(309, 34)
        Me.lbl9thName.Name = "lbl9thName"
        Me.lbl9thName.Size = New System.Drawing.Size(228, 34)
        Me.lbl9thName.TabIndex = 31
        Me.lbl9thName.Text = "TheDrakonLord"
        '
        'bwMain
        '
        '
        'lblCapture
        '
        Me.lblCapture.AutoSize = True
        Me.lblCapture.BackColor = System.Drawing.Color.Transparent
        Me.lblCapture.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapture.ForeColor = System.Drawing.Color.White
        Me.lblCapture.Location = New System.Drawing.Point(89, 447)
        Me.lblCapture.Name = "lblCapture"
        Me.lblCapture.Size = New System.Drawing.Size(871, 37)
        Me.lblCapture.TabIndex = 33
        Me.lblCapture.Text = ">>>Take a moment now to set up your capture software<<<"
        '
        'btnReady
        '
        Me.btnReady.Location = New System.Drawing.Point(432, 479)
        Me.btnReady.Name = "btnReady"
        Me.btnReady.Size = New System.Drawing.Size(126, 49)
        Me.btnReady.TabIndex = 34
        Me.btnReady.Text = "Im Ready"
        Me.btnReady.UseVisualStyleBackColor = True
        '
        'pbrQTime
        '
        Me.pbrQTime.Location = New System.Drawing.Point(120, 141)
        Me.pbrQTime.Name = "pbrQTime"
        Me.pbrQTime.Size = New System.Drawing.Size(763, 10)
        Me.pbrQTime.TabIndex = 35
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.OmegaChallenge_2.My.Resources.Resources.Moogle_Start
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.pbrQTime)
        Me.Controls.Add(Me.btnReady)
        Me.Controls.Add(Me.lblCapture)
        Me.Controls.Add(Me.lbl9thScore)
        Me.Controls.Add(Me.lbl9thName)
        Me.Controls.Add(Me.lbl8thScore)
        Me.Controls.Add(Me.lbl8thName)
        Me.Controls.Add(Me.lbl7thScore)
        Me.Controls.Add(Me.lbl7thName)
        Me.Controls.Add(Me.lbl6thScore)
        Me.Controls.Add(Me.lbl6thName)
        Me.Controls.Add(Me.lbl5thScore)
        Me.Controls.Add(Me.lbl5thName)
        Me.Controls.Add(Me.lbl3rdScore)
        Me.Controls.Add(Me.lbl3rdName)
        Me.Controls.Add(Me.lbl4thScore)
        Me.Controls.Add(Me.lbl4thName)
        Me.Controls.Add(Me.lbl2ndScore)
        Me.Controls.Add(Me.lbl2ndName)
        Me.Controls.Add(Me.lbl1stScore)
        Me.Controls.Add(Me.lbl1stName)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.lblValueFoot)
        Me.Controls.Add(Me.lblValueHead)
        Me.Controls.Add(Me.lblAnswers)
        Me.Controls.Add(Me.lblTimer)
        Me.Controls.Add(Me.lblAnswersHead)
        Me.Controls.Add(Me.lblD)
        Me.Controls.Add(Me.lblC)
        Me.Controls.Add(Me.lblB)
        Me.Controls.Add(Me.lblA)
        Me.Controls.Add(Me.lblInstruction)
        Me.Controls.Add(Me.lblQuestion)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Omega's Challenge"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bwMammetBot As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrSeconds As Timer
    Friend WithEvents lblQuestion As Label
    Friend WithEvents lblInstruction As Label
    Friend WithEvents lblA As Label
    Friend WithEvents lblB As Label
    Friend WithEvents lblC As Label
    Friend WithEvents lblD As Label
    Friend WithEvents lblAnswersHead As Label
    Friend WithEvents lblTimer As Label
    Friend WithEvents tmrCountdown As Timer
    Friend WithEvents lblAnswers As Label
    Friend WithEvents lblValueHead As Label
    Friend WithEvents lblValueFoot As Label
    Friend WithEvents lblValue As Label
    Friend WithEvents lbl1stName As Label
    Friend WithEvents lbl1stScore As Label
    Friend WithEvents lbl2ndScore As Label
    Friend WithEvents lbl2ndName As Label
    Friend WithEvents lbl4thScore As Label
    Friend WithEvents lbl4thName As Label
    Friend WithEvents lbl3rdScore As Label
    Friend WithEvents lbl3rdName As Label
    Friend WithEvents lbl5thScore As Label
    Friend WithEvents lbl5thName As Label
    Friend WithEvents lbl6thScore As Label
    Friend WithEvents lbl6thName As Label
    Friend WithEvents lbl7thScore As Label
    Friend WithEvents lbl7thName As Label
    Friend WithEvents lbl8thScore As Label
    Friend WithEvents lbl8thName As Label
    Friend WithEvents lbl9thScore As Label
    Friend WithEvents lbl9thName As Label
    Friend WithEvents bwMain As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblCapture As Label
    Friend WithEvents btnReady As Button
    Friend WithEvents pbrQTime As ProgressBar
End Class
