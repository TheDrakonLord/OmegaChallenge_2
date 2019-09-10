Imports System.IO
Imports System.Media
Public Class frmMain
    ' Author: Neal Jamieson
    ' Date: 4/3/2019
    ' Version: 0.2.0.0
    ' Description:
    'TO DO (listed by priority):


    ' Declare classes
    Public tbotMammetBot As New TwitchBot(My.Settings.Nick,
                                          My.Settings.Server,
                                          My.Settings.Port,
                                          My.Settings.Channel,
                                          My.Settings.Pass)
    Dim bstPlayerTree As BinarySearchTree = New BinarySearchTree("mammetbot")
    'declare constants (all times in seconds)
    Dim baseQsPerPhase As Integer = 10 * frmLauncher.dblDurationMod
    Dim baseTimePerPhase As Integer = 360 * frmLauncher.dblDurationMod
    Const baseTimePerQ As Integer = 30
    Const basePointsPerQ As Integer = 500
    Const CorrectSelectDelay As Integer = 3
    Const moogleTimeMod As Double = 1
    Const mooglePointMod As Double = 1
    Const moogleRuleText As String = "No Special Rules."
    Const chocoboTimeMod As Double = 1
    Const chocoboPointMod As Double = 1.5
    Const chocoboRuleText As String = "Point values are increased."
    Const voidsentTimeMod As Double = 1
    Const voidsentPointMod As Double = 2.5
    Dim voidsentReductionMod As Double = Math.Floor((basePointsPerQ * voidsentPointMod) / ((CorrectSelectDelay * 2) + baseTimePerQ)) '34
    Const voidsentRuleText As String = "Points decrease the longer you take to answer."
    Const primalTimeMod As Double = 1
    Const primalPointMod As Double = 5
    Const primalPenaltyMod As Double = -1
    Const primalRuleText As String = "Incorrect Answers count against you!"
    Const omegaTimeMod As Double = 1
    Const omegaPointMod As Double = 10
    Const omegaPenaltyMod As Double = -1
    Const omegaRuleText As String = "Omega plays as well! All players will lose points equal to his score at the end of the round!"
    Const omegaSuccessRate As Double = 50 '%
    Const StartScreenWait As Integer = 10
    Const strInstruction As String = "To play, enter your answer in chat by typing ! then your answer (e.g. !A)."
    Const baseBufferScreen As Integer = 10
    Const ButtonText As String = "Im Ready"
    Const CaptureText As String = ">>>Take a moment now to set up your capture software<<<"
    Const ValueHeadText As String = "Question is worth:"
    Const valueFootText As String = "Points"
    'declare strings
    Dim strBuffer As String
    Dim strBuffer2() As String
    Dim strBuffer3() As String
    Dim strU As String
    Dim strM As String
    ''' <summary>
    ''' 1st index is qid.
    ''' 2nd index: 0 = question, 1 = A, 2 = B, 3 = C, 4 = D, 5 = Answer, 6 = Author
    ''' </summary>
    Dim strQuestions((baseQsPerPhase * 5) - 1, 6) As String
    ' declare queues
    Dim queUsers As Queue = New Queue()
    Dim queMessages As Queue = New Queue()
    Dim queAnswers As Queue = New Queue()
    ' declare stacks
    Dim stkPlayers As Stack = New Stack()
    ' declare ints
    ''' <summary>
    ''' phases: 0 = Moogle, 1 = Chocobo, 2 = Voidsent, 3 = Primal, 4 = Omega, 5 = End
    ''' </summary>
    Dim intPhase As Integer = 0
    ''' <summary>
    ''' Sub Phases: 0 = Start, 1 = Quiz, 2 = Finish, 3 = Ranks
    ''' </summary>
    Dim intSubPhase As Integer = 0
    ''' <summary>
    ''' Q Phases: 0 = Ask, 1 = Select, 2 = Correct
    ''' </summary>
    Dim intQPhase As Integer = 0
    Dim intQValue As Integer = basePointsPerQ
    Dim intValue As Integer = intQValue
    Dim intTime As Integer = baseTimePerPhase
    Dim intQTime As Integer = baseTimePerQ
    Dim intAnswers As Integer = 0
    Dim intM As Integer
    Dim intS As Integer
    Dim intQID As Integer = 0
    Dim intQCount As Integer = 0
    Dim intCorBuffer = 3
    Dim intOmegaBuffer = 3
    Dim intRankBuffer = baseBufferScreen
    Dim intStartBuffer = StartScreenWait
    ''' <summary>
    ''' 0 = user, 1 = answer, 2 = intQID, 3 = intValue
    ''' </summary>
    Dim strAnsBuffer() As String
    ''' <summary>
    ''' 1st index = place
    ''' 2nd index: 0 = name, 1 = score
    ''' </summary>
    Dim strTop9(8, 1)
    Dim rand As New Random()
    Dim intOmega As Integer = 0
    Dim intInOmega As Integer = 0
    Dim strCorrect As String
    Dim bolRepeats As Boolean = frmLauncher.bolRepeatOn
    Dim Music As SoundPlayer = New SoundPlayer("C:\Users\nealc\OneDrive\Application Development\OmegaChallenge\OmegaChallenge_2\OmegaChallenge_2\Resources\Moogle.wav")
    Dim intPbr As Integer = 0



    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' [ALG] frmMain load
        ' [ALG] frmL close
        frmLauncher.Close()
        ' [ALG] tbot initialize
        strBuffer = tbotMammetBot.Initialize()
        tmrSeconds.Enabled = True
        tmrCountdown.Enabled = False
        Console.WriteLine(strBuffer)
        ' [ALG] start bot thread
        bwMammetBot.RunWorkerAsync()

        ' [ALG] pre-load questions
        If bolRepeats Then
            If File.Exists("UsedQ.txt") Then
            Else
                File.Create("UsedQ.txt").Dispose()
            End If

            If File.ReadAllText("UsedQ.txt").Length = 0 Then
                firstReadWithRepeats()
            Else
                readFileWithoutRepeats()
            End If
        Else
            readFileWithRepeats()
        End If

        lblQuestion.Visible = False
        lblInstruction.Visible = False
        lblA.Visible = False
        lblB.Visible = False
        lblC.Visible = False
        lblD.Visible = False
        lblAnswersHead.Visible = False
        lblAnswers.Visible = False
        lblValueHead.Visible = False
        lblValue.Visible = False
        lblValueFoot.Visible = False
        lbl1stName.Visible = False
        lbl1stScore.Visible = False
        lbl2ndName.Visible = False
        lbl2ndScore.Visible = False
        lbl3rdName.Visible = False
        lbl3rdScore.Visible = False
        lbl4thName.Visible = False
        lbl4thScore.Visible = False
        lbl5thName.Visible = False
        lbl5thScore.Visible = False
        lbl6thName.Visible = False
        lbl6thScore.Visible = False
        lbl7thName.Visible = False
        lbl7thScore.Visible = False
        lbl8thName.Visible = False
        lbl8thScore.Visible = False
        lbl9thName.Visible = False
        lbl9thScore.Visible = False
        lblTimer.Visible = False
        lblCapture.Visible = True
        btnReady.Visible = True
        pbrQTime.Visible = False
        lblValueHead.Text = ValueHeadText
        lblValueFoot.Text = valueFootText
        lblCapture.Text = CaptureText
        btnReady.Text = ButtonText
        Me.BackgroundImage = My.Resources.Moogle_Start
    End Sub

    Private Sub btnReady_Click(sender As Object, e As EventArgs) Handles btnReady.Click
        tmrCountdown.Enabled = True
        lblCapture.Visible = False
        btnReady.Visible = False
        ' [ALG] main loop
        bwMain.RunWorkerAsync()
    End Sub

    Private Sub SubPhase()
        intSubPhase = 0
        intTime = baseTimePerPhase + 20
        intRankBuffer = baseBufferScreen



        If intPhase = 1 Then
            If lblQuestion.InvokeRequired Then
                lblQuestion.Invoke(Sub() lblQuestion.ForeColor = Color.Black)
            Else
                lblQuestion.ForeColor = Color.Black
            End If
            If lblInstruction.InvokeRequired Then
                lblInstruction.Invoke(Sub() lblInstruction.ForeColor = Color.Black)
            Else
                lblInstruction.ForeColor = Color.Black
            End If
            If lblA.InvokeRequired Then
                lblA.Invoke(Sub() lblA.ForeColor = Color.Black)
            Else
                lblA.ForeColor = Color.Black
            End If
            If lblB.InvokeRequired Then
                lblB.Invoke(Sub() lblB.ForeColor = Color.Black)
            Else
                lblB.ForeColor = Color.Black
            End If
            If lblC.InvokeRequired Then
                lblC.Invoke(Sub() lblC.ForeColor = Color.Black)
            Else
                lblC.ForeColor = Color.Black
            End If
            If lblD.InvokeRequired Then
                lblD.Invoke(Sub() lblD.ForeColor = Color.Black)
            Else
                lblD.ForeColor = Color.Black
            End If
        Else
            If lblQuestion.InvokeRequired Then
                lblQuestion.Invoke(Sub() lblQuestion.ForeColor = Color.White)
            Else
                lblQuestion.ForeColor = Color.White
            End If
            If lblInstruction.InvokeRequired Then
                lblInstruction.Invoke(Sub() lblInstruction.ForeColor = Color.White)
            Else
                lblInstruction.ForeColor = Color.White
            End If
            If lblA.InvokeRequired Then
                lblA.Invoke(Sub() lblA.ForeColor = Color.White)
            Else
                lblA.ForeColor = Color.White
            End If
            If lblB.InvokeRequired Then
                lblB.Invoke(Sub() lblB.ForeColor = Color.White)
            Else
                lblB.ForeColor = Color.White
            End If
            If lblC.InvokeRequired Then
                lblC.Invoke(Sub() lblC.ForeColor = Color.White)
            Else
                lblC.ForeColor = Color.White
            End If
            If lblD.InvokeRequired Then
                lblD.Invoke(Sub() lblD.ForeColor = Color.White)
            Else
                lblD.ForeColor = Color.White
            End If
        End If

        'phases: 0: Moogle, 1: Chocobo, 2: Voidsent, 3: Primal, 4: Omega, 5: End
        Select Case intPhase
            Case 0
                intQValue = basePointsPerQ * mooglePointMod
                intValue = intQValue
            Case 1
                intQValue = basePointsPerQ * chocoboPointMod
                intValue = intQValue
            Case 2
                intQValue = basePointsPerQ * voidsentPointMod
                intValue = intQValue
            Case 3
                intQValue = basePointsPerQ * primalPointMod
                intValue = intQValue
            Case 4
                intQValue = basePointsPerQ * omegaPointMod
                intValue = intQValue
            Case 5

            Case Else

        End Select

        If lblValue.InvokeRequired Then
            lblValue.Invoke(Sub() lblValue.Text = intValue)
        Else
            lblValue.Text = intValue
        End If


        setStart()

        Select Case intPhase
            Case 0
                tbotMammetBot.send("Here we go!" & " This is stage 1: Moogle!" & " There are no special rules in this round " & strInstruction)
                Music.SoundLocation = "C:\Users\nealc\OneDrive\Application Development\OmegaChallenge\OmegaChallenge_2\OmegaChallenge_2\Resources\Moogle.wav"

            Case 1
                tbotMammetBot.send("On to the next Stage!" & " This is stage 2: Chocobo! " & chocoboRuleText & " " & strInstruction)
                If rand.Next(0, 100) > 50 Then
                    Music.SoundLocation = "C:\Users\nealc\OneDrive\Application Development\OmegaChallenge\OmegaChallenge_2\OmegaChallenge_2\Resources\Chocobo_01.wav"


                Else

                    Music.SoundLocation = "C:\Users\nealc\OneDrive\Application Development\OmegaChallenge\OmegaChallenge_2\OmegaChallenge_2\Resources\Chocobo_02.wav"

                End If


            Case 2
                tbotMammetBot.send("On to the next stage!" & " This is stage 3: Voidsent! " & voidsentRuleText & " " & strInstruction)
                If rand.Next(0, 100) > 50 Then
                    Music.SoundLocation = "C:\Users\nealc\OneDrive\Application Development\OmegaChallenge\OmegaChallenge_2\OmegaChallenge_2\Resources\Voidsent_01.wav"


                Else
                    Music.SoundLocation = "C:\Users\nealc\OneDrive\Application Development\OmegaChallenge\OmegaChallenge_2\OmegaChallenge_2\Resources\Voidsent_02.wav"

                End If


            Case 3
                tbotMammetBot.send("On to the next stage! " & " This is stage 4: Primal! " & primalRuleText & " " & strInstruction)
                Music.SoundLocation = "C:\Users\nealc\OneDrive\Application Development\OmegaChallenge\OmegaChallenge_2\OmegaChallenge_2\Resources\primal.wav"

            Case 4
                tbotMammetBot.send("On to the next stage!" & " This is the final stage: Omega! " & omegaRuleText & " " & strInstruction)
                Music.SoundLocation = "C:\Users\nealc\OneDrive\Application Development\OmegaChallenge\OmegaChallenge_2\OmegaChallenge_2\Resources\omega.wav"

            Case Else

        End Select
        Music.Load()
        Music.PlayLooping()

        While intStartBuffer > 0
            'wait
        End While
        intStartBuffer = StartScreenWait

        intTime = baseTimePerPhase
        intSubPhase = 1
        QPhase()
        intSubPhase = 2
        'score evaluation
        analyzeAnswers()
        If intPhase = 4 Then
            OmegaPenalty(bstPlayerTree._root)
        End If
        'rank loading
        treeToStack(bstPlayerTree._root)
        analyzePlayerStack()

        intSubPhase = 3
        setRanks()
        If intPhase < 4 Then
            tbotMammetBot.send("@" & strTop9(0, 0) & " is currently in first place with a score of " & strTop9(0, 1) & " points!")
        Else
            tbotMammetBot.send("@" & strTop9(0, 0) & " has won the game with a score of " & strTop9(0, 1) & " points!")
        End If
        While intRankBuffer > 0
            'wait
        End While
        intRankBuffer = baseBufferScreen
        Music.Stop()

        If intPhase < 4 Then
            intPhase += 1
            SubPhase()
        Else
            EndPhase()
        End If
    End Sub

    Private Sub QPhase()
        intOmegaBuffer = CorrectSelectDelay
        intCorBuffer = CorrectSelectDelay
        intPbr = 0
        intQPhase = 0
        setAsk()
        intQTime = baseTimePerQ
        intValue = intQValue
        intAnswers = 0
        If lblAnswers.InvokeRequired Then
            lblAnswers.Invoke(Sub() lblAnswers.Text = intAnswers)
        Else
            lblAnswers.Text = intAnswers
        End If
        tbotMammetBot.send("question " & (intQID + 1) & ": " & strQuestions(intQID, 0) & " !A: " & strQuestions(intQID, 1) & " !B: " & strQuestions(intQID, 2) & " !C: " & strQuestions(intQID, 3) & " !D: " & strQuestions(intQID, 4) & " (created by: " & strQuestions(intQID, 6) & ")")
        While intQTime > 0
            'wait
        End While
        intQPhase = 1


        If intPhase = 4 Then
            strCorrect = strQuestions(intQID, 5)
            If rand.Next(0, 100) < omegaSuccessRate Then
                setSelect(strCorrect)
                intOmega += intValue
            Else
                intInOmega = rand.Next(1, 5)
                Select Case intInOmega
                    Case 1
                        If strCorrect.Equals("A") Then
                            setSelect("B")
                        Else
                            setSelect("A")
                        End If
                    Case 2
                        If strCorrect.Equals("B") Then
                            setSelect("C")
                        Else
                            setSelect("B")
                        End If
                    Case 3
                        If strCorrect.Equals("C") Then
                            setSelect("D")
                        Else
                            setSelect("C")
                        End If
                    Case 4
                        If strCorrect.Equals("D") Then
                            setSelect("A")
                        Else
                            setSelect("D")
                        End If
                    Case Else
                End Select
            End If

        End If

        While intOmegaBuffer > 0
            'wait
        End While
        intOmegaBuffer = CorrectSelectDelay
        intQPhase = 2

        setCorrect(strQuestions(intQID, 5))
        tbotMammetBot.send("The correct answer was: " & strQuestions(intQID, 5))

        While intCorBuffer > 0
            'wait
        End While
        intCorBuffer = CorrectSelectDelay

        intQID += 1
        If intQCount < (baseQsPerPhase - 1) Then
            intQCount += 1
            QPhase()
        Else
            intQCount = 0
        End If
    End Sub

    Private Sub EndPhase()
        tmrCountdown.Enabled = False
        Music.SoundLocation = "C:\Users\nealc\OneDrive\Application Development\OmegaChallenge\OmegaChallenge_2\OmegaChallenge_2\Resources\victory.wav"

        Music.Load()
        Music.Play()
    End Sub

    Private Sub subInterpreter(rawMessage As String)
        Dim strSplitter() As String
        Dim strSplitter2() As String
        Dim strUsername As String
        Dim strMessage As String
        If rawMessage.Contains("PRIVMSG") Then
            strSplitter = rawMessage.Split(":")
            strSplitter2 = strSplitter(1).Split("!")
            If strSplitter.Length = 3 And strSplitter2.Length = 2 Then
                strMessage = strSplitter(2)
                strUsername = strSplitter2(0)
                subAddToQueue(strUsername, strMessage)
                Console.WriteLine(strUsername & ": " & strMessage)
            End If
        End If
    End Sub

    Private Sub subAddToQueue(username As String, message As String)
        queUsers.Enqueue(username)
        queMessages.Enqueue(message)
    End Sub

    Private Sub subRemoveFromQueue(ByRef username As String, ByRef message As String)
        username = queUsers.Dequeue()
        message = queMessages.Dequeue()
    End Sub

    Private Sub subBotCommands(user As String, message As String)
        Dim plrPlayerBuf As Player
        If checkQID(user) Then
            Select Case True
                Case message.Contains("!A"), message.Contains("!a")
                    intAnswers += 1
                    lblAnswers.Text = intAnswers
                    queAnswers.Enqueue(user & ":" & "A" & ":" & intQID & ":" & intValue)
                Case message.Contains("!B"), message.Contains("!b")
                    intAnswers += 1
                    lblAnswers.Text = intAnswers
                    queAnswers.Enqueue(user & ":" & "B" & ":" & intQID & ":" & intValue)
                Case message.Contains("!C"), message.Contains("!c")
                    intAnswers += 1
                    lblAnswers.Text = intAnswers
                    queAnswers.Enqueue(user & ":" & "C" & ":" & intQID & ":" & intValue)
                Case message.Contains("!D"), message.Contains("!d")
                    intAnswers += 1
                    lblAnswers.Text = intAnswers
                    queAnswers.Enqueue(user & ":" & "D" & ":" & intQID & ":" & intValue)
                Case Else

            End Select
        End If
        If (message.Contains("!score") Or message.Contains("!Score")) Then
            Try
                plrPlayerBuf = bstPlayerTree.SearchTree(user)
                tbotMammetBot.send("@" & plrPlayerBuf.getName & " your score is currently " & plrPlayerBuf.getScore & " points")
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub bwMammetBot_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwMammetBot.DoWork
        ' [ALG] bot loop
        While True
            ' [ALG] monitor
            strBuffer = tbotMammetBot.monitor()
            ' [ALG] interpret
            subInterpreter(strBuffer)
            Console.WriteLine(strBuffer)
        End While
    End Sub

    Private Sub tmrSeconds_Tick(sender As Object, e As EventArgs) Handles tmrSeconds.Tick
        Dim i As Integer = 0
        If queUsers.Count > 0 And queMessages.Count > 0 And queUsers.Count = queMessages.Count Then
            For i = 1 To queMessages.Count
                subRemoveFromQueue(strU, strM)
                subBotCommands(strU, strM)

            Next
        End If


    End Sub

    Private Sub tmrCountdown_Tick(sender As Object, e As EventArgs) Handles tmrCountdown.Tick
        intTime -= 1
        intQTime -= 1
        If intQPhase = 2 Then
            intCorBuffer -= 1
        End If
        If intQPhase = 1 Then
            intOmegaBuffer -= 1
        End If
        If intSubPhase = 3 Then
            intRankBuffer -= 1
        End If
        If intSubPhase = 0 Then
            intStartBuffer -= 1
        End If
        If intSubPhase = 1 Then
            intPbr = 100 - (100 * (intQTime / (baseTimePerQ + (CorrectSelectDelay * 2))))
            If intPbr >= 100 Then
                pbrQTime.Value = 100
            Else
                pbrQTime.Value = intPbr
            End If
        End If
        intM = Math.Truncate(intTime / 60)
        intS = Math.Round((((intTime / 60) - Math.Truncate(intTime / 60)) * 60), 0, MidpointRounding.AwayFromZero)
        If intS < 10 Then
            lblTimer.Text = intM & ":0" & intS
        Else
            lblTimer.Text = intM & ":" & intS
        End If
        If intPhase = 2 Then
            intValue = intValue - voidsentReductionMod
            lblValue.Text = intValue
        End If

        If intTime = 0 Then
            setFinish()
        End If
    End Sub

    Private Function checkQID(name As String)
        Dim plrPlayerBuf As Player
        Try
            plrPlayerBuf = bstPlayerTree.SearchTree(name)
        Catch ex As Exception
            bstPlayerTree.AddtoTree(name)
            plrPlayerBuf = bstPlayerTree.SearchTree(name)
        End Try
        If plrPlayerBuf.getQID() < intQID Then
            plrPlayerBuf.setQID(intQID)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub treeToStack(ByVal node As Player)
        If Not node Is Nothing Then
            treeToStack(node.LeftNode)
            stkPlayers.Push(node)
            treeToStack(node.RightNode)
        End If
    End Sub

    Private Sub OmegaPenalty(ByVal node As Player)
        If Not node Is Nothing Then
            OmegaPenalty(node.LeftNode)
            node.addScore(intOmega * omegaPenaltyMod)
            OmegaPenalty(node.RightNode)
        End If
    End Sub

    Private Sub analyzePlayerStack()
        Dim plrPlayers(stkPlayers.Count) As Player
        For index = 0 To stkPlayers.Count - 1
            plrPlayers(index) = stkPlayers.Pop()
        Next
        Array.Sort(plrPlayers)
        For index2 = 0 To (strTop9.Length / 2) - 1
            If (plrPlayers.Length - (1 + index2)) < 0 Then
                strTop9(index2, 0) = "N/A"
                strTop9(index2, 1) = 0
            ElseIf plrPlayers(plrPlayers.Length - (1 + index2)) Is Nothing Then
                strTop9(index2, 0) = "N/A"
                strTop9(index2, 1) = 0
            Else

                strTop9(index2, 0) = plrPlayers(plrPlayers.Length - (1 + index2)).getName
                strTop9(index2, 1) = plrPlayers(plrPlayers.Length - (1 + index2)).getScore
            End If
        Next
    End Sub

    Private Sub analyzeAnswers()
        Dim strBuf() As String
        Dim ansAnswers(queAnswers.Count) As Answers
        Dim strNameBuf As String = ""
        Dim plrPlayerBuf As Player


        For index = 0 To queAnswers.Count - 1
            strBuf = queAnswers.Dequeue().Split(":")
            ansAnswers(index) = New Answers(strBuf(0), strBuf(1), CInt(strBuf(2)), CInt(strBuf(3)))
        Next
        '0 = name
        '1 = answer
        '2 = question id
        '3 = points
        Array.Sort(ansAnswers)
        For index2 = 0 To ansAnswers.Length - 1

            If ansAnswers(index2) Is Nothing Then
            Else
                plrPlayerBuf = bstPlayerTree.SearchTree(ansAnswers(index2).name())

                ' check if answer is correct
                If strQuestions(ansAnswers(index2).qid, 5).Equals(ansAnswers(index2).answer) Then
                    plrPlayerBuf.addScore(ansAnswers(index2).points)
                ElseIf intPhase = 3 Then
                    plrPlayerBuf.addScore(ansAnswers(index2).points * primalPenaltyMod)
                End If
            End If


        Next
    End Sub

    Private Sub setStart()
        'lblquestion
        If lblQuestion.InvokeRequired Then
            lblQuestion.Invoke(Sub() lblQuestion.Visible = False)
        Else
            lblQuestion.Visible = False
        End If
        'lblinstruciton
        If lblInstruction.InvokeRequired Then
            lblInstruction.Invoke(Sub() lblInstruction.Visible = False)
        Else
            lblInstruction.Visible = False
        End If
        'lblA
        If lblA.InvokeRequired Then
            lblA.Invoke(Sub() lblA.Visible = False)
        Else
            lblA.Visible = False
        End If
        'lblB
        If lblB.InvokeRequired Then
            lblB.Invoke(Sub() lblB.Visible = False)
        Else
            lblB.Visible = False
        End If
        'lblC
        If lblC.InvokeRequired Then
            lblC.Invoke(Sub() lblC.Visible = False)
        Else
            lblC.Visible = False
        End If
        'lblD  
        If lblD.InvokeRequired Then
            lblD.Invoke(Sub() lblD.Visible = False)
        Else
            lblD.Visible = False
        End If
        'lblAnswers
        If lblAnswers.InvokeRequired Then
            lblAnswers.Invoke(Sub() lblAnswers.Visible = False)
        Else
            lblAnswers.Visible = False
        End If
        'lblAnswersHead
        If lblAnswersHead.InvokeRequired Then
            lblAnswersHead.Invoke(Sub() lblAnswersHead.Visible = False)
        Else
            lblAnswersHead.Visible = False
        End If
        'lblValue
        If lblValue.InvokeRequired Then
            lblValue.Invoke(Sub() lblValue.Visible = False)
        Else
            lblValue.Visible = False
        End If
        'lblValueFOot
        If lblValueFoot.InvokeRequired Then
            lblValueFoot.Invoke(Sub() lblValueFoot.Visible = False)
        Else
            lblValueFoot.Visible = False
        End If
        'lblValueHead
        If lblValueHead.InvokeRequired Then
            lblValueHead.Invoke(Sub() lblValueHead.Visible = False)
        Else
            lblValueHead.Visible = False
        End If
        'lblTimer
        If lblTimer.InvokeRequired Then
            lblTimer.Invoke(Sub() lblTimer.Visible = False)
        Else
            lblTimer.Visible = False
        End If
        'lbl1stName
        If lbl1stName.InvokeRequired Then
            lbl1stName.Invoke(Sub() lbl1stName.Visible = False)
        Else
            lbl1stName.Visible = False
        End If
        'lbl1stScore
        If lbl1stScore.InvokeRequired Then
            lbl1stScore.Invoke(Sub() lbl1stScore.Visible = False)
        Else
            lbl1stScore.Visible = False
        End If
        'lbl2ndName
        If lbl2ndName.InvokeRequired Then
            lbl2ndName.Invoke(Sub() lbl2ndName.Visible = False)
        Else
            lbl2ndName.Visible = False
        End If
        'lbl2ndScore
        If lbl2ndScore.InvokeRequired Then
            lbl2ndScore.Invoke(Sub() lbl2ndScore.Visible = False)
        Else
            lbl2ndScore.Visible = False
        End If
        'lbl3rdName
        If lbl3rdName.InvokeRequired Then
            lbl3rdName.Invoke(Sub() lbl3rdName.Visible = False)
        Else
            lbl3rdName.Visible = False
        End If
        'lbl3rdScore
        If lbl3rdScore.InvokeRequired Then
            lbl3rdScore.Invoke(Sub() lbl3rdScore.Visible = False)
        Else
            lbl3rdScore.Visible = False
        End If
        'lbl4thName
        If lbl4thName.InvokeRequired Then
            lbl4thName.Invoke(Sub() lbl4thName.Visible = False)
        Else
            lbl4thName.Visible = False
        End If
        'lbl4thScore
        If lbl4thScore.InvokeRequired Then
            lbl4thScore.Invoke(Sub() lbl4thScore.Visible = False)
        Else
            lbl4thScore.Visible = False
        End If
        'lbl5thName
        If lbl5thName.InvokeRequired Then
            lbl5thName.Invoke(Sub() lbl5thName.Visible = False)
        Else
            lbl5thName.Visible = False
        End If
        'lbl5thScore
        If lbl5thScore.InvokeRequired Then
            lbl5thScore.Invoke(Sub() lbl5thScore.Visible = False)
        Else
            lbl5thScore.Visible = False
        End If
        'lbl6thName
        If lbl6thName.InvokeRequired Then
            lbl6thName.Invoke(Sub() lbl6thName.Visible = False)
        Else
            lbl6thName.Visible = False
        End If
        'lbl6thScore
        If lbl6thScore.InvokeRequired Then
            lbl6thScore.Invoke(Sub() lbl6thScore.Visible = False)
        Else
            lbl6thScore.Visible = False
        End If
        'lbl7thName
        If lbl7thName.InvokeRequired Then
            lbl7thName.Invoke(Sub() lbl7thName.Visible = False)
        Else
            lbl7thName.Visible = False
        End If
        'lbl7thScore
        If lbl7thScore.InvokeRequired Then
            lbl7thScore.Invoke(Sub() lbl7thScore.Visible = False)
        Else
            lbl7thScore.Visible = False
        End If
        'lbl8thName
        If lbl8thName.InvokeRequired Then
            lbl8thName.Invoke(Sub() lbl8thName.Visible = False)
        Else
            lbl8thName.Visible = False
        End If
        'lbl8thScore
        If lbl8thScore.InvokeRequired Then
            lbl8thScore.Invoke(Sub() lbl8thScore.Visible = False)
        Else
            lbl8thScore.Visible = False
        End If
        'lbl9thName
        If lbl9thName.InvokeRequired Then
            lbl9thName.Invoke(Sub() lbl9thName.Visible = False)
        Else
            lbl9thName.Visible = False
        End If
        'lbl9thScore
        If lbl9thScore.InvokeRequired Then
            lbl9thScore.Invoke(Sub() lbl9thScore.Visible = False)
        Else
            lbl9thScore.Visible = False
        End If
        'pbrQTime
        If pbrQTime.InvokeRequired Then
            pbrQTime.Invoke(Sub() pbrQTime.Visible = False)
        Else
            pbrQTime.Visible = False
        End If


        'phases: 0: Moogle, 1: Chocobo, 2: Voidsent, 3: Primal, 4: Omega, 5: End
        Select Case intPhase
            Case 0
                Me.BackgroundImage = My.Resources.Moogle_Start
            Case 1
                Me.BackgroundImage = My.Resources.Chocobo_Start
            Case 2
                Me.BackgroundImage = My.Resources.Voidsent_Start
            Case 3
                Me.BackgroundImage = My.Resources.Primal_Start
            Case 4
                Me.BackgroundImage = My.Resources.Omega_Start
            Case 5

            Case Else

        End Select
    End Sub

    Private Sub setAsk()
        'lblquestion
        If lblQuestion.InvokeRequired Then
            lblQuestion.Invoke(Sub() lblQuestion.Visible = True)
        Else
            lblQuestion.Visible = True
        End If
        'lblinstruciton
        If lblInstruction.InvokeRequired Then
            lblInstruction.Invoke(Sub() lblInstruction.Visible = True)
        Else
            lblInstruction.Visible = True
        End If
        'lblA
        If lblA.InvokeRequired Then
            lblA.Invoke(Sub() lblA.Visible = True)
        Else
            lblA.Visible = True
        End If
        'lblB
        If lblB.InvokeRequired Then
            lblB.Invoke(Sub() lblB.Visible = True)
        Else
            lblB.Visible = True
        End If
        'lblC
        If lblC.InvokeRequired Then
            lblC.Invoke(Sub() lblC.Visible = True)
        Else
            lblC.Visible = True
        End If
        'lblD  
        If lblD.InvokeRequired Then
            lblD.Invoke(Sub() lblD.Visible = True)
        Else
            lblD.Visible = True
        End If
        'lblAnswers
        If lblAnswers.InvokeRequired Then
            lblAnswers.Invoke(Sub() lblAnswers.Visible = True)
        Else
            lblAnswers.Visible = True
        End If
        'lblAnswersHead
        If lblAnswersHead.InvokeRequired Then
            lblAnswersHead.Invoke(Sub() lblAnswersHead.Visible = True)
        Else
            lblAnswersHead.Visible = True
        End If
        'lblValue
        If lblValue.InvokeRequired Then
            lblValue.Invoke(Sub() lblValue.Visible = True)
        Else
            lblValue.Visible = True
        End If
        'lblValueFOot
        If lblValueFoot.InvokeRequired Then
            lblValueFoot.Invoke(Sub() lblValueFoot.Visible = True)
        Else
            lblValueFoot.Visible = True
        End If
        'lblValueHead
        If lblValueHead.InvokeRequired Then
            lblValueHead.Invoke(Sub() lblValueHead.Visible = True)
        Else
            lblValueHead.Visible = True
        End If
        'lblTimer
        If lblTimer.InvokeRequired Then
            lblTimer.Invoke(Sub() lblTimer.Visible = True)
        Else
            lblTimer.Visible = True
        End If
        'lbl1stName
        If lbl1stName.InvokeRequired Then
            lbl1stName.Invoke(Sub() lbl1stName.Visible = False)
        Else
            lbl1stName.Visible = False
        End If
        'lbl1stScore
        If lbl1stScore.InvokeRequired Then
            lbl1stScore.Invoke(Sub() lbl1stScore.Visible = False)
        Else
            lbl1stScore.Visible = False
        End If
        'lbl2ndName
        If lbl2ndName.InvokeRequired Then
            lbl2ndName.Invoke(Sub() lbl2ndName.Visible = False)
        Else
            lbl2ndName.Visible = False
        End If
        'lbl2ndScore
        If lbl2ndScore.InvokeRequired Then
            lbl2ndScore.Invoke(Sub() lbl2ndScore.Visible = False)
        Else
            lbl2ndScore.Visible = False
        End If
        'lbl3rdName
        If lbl3rdName.InvokeRequired Then
            lbl3rdName.Invoke(Sub() lbl3rdName.Visible = False)
        Else
            lbl3rdName.Visible = False
        End If
        'lbl3rdScore
        If lbl3rdScore.InvokeRequired Then
            lbl3rdScore.Invoke(Sub() lbl3rdScore.Visible = False)
        Else
            lbl3rdScore.Visible = False
        End If
        'lbl4thName
        If lbl4thName.InvokeRequired Then
            lbl4thName.Invoke(Sub() lbl4thName.Visible = False)
        Else
            lbl4thName.Visible = False
        End If
        'lbl4thScore
        If lbl4thScore.InvokeRequired Then
            lbl4thScore.Invoke(Sub() lbl4thScore.Visible = False)
        Else
            lbl4thScore.Visible = False
        End If
        'lbl5thName
        If lbl5thName.InvokeRequired Then
            lbl5thName.Invoke(Sub() lbl5thName.Visible = False)
        Else
            lbl5thName.Visible = False
        End If
        'lbl5thScore
        If lbl5thScore.InvokeRequired Then
            lbl5thScore.Invoke(Sub() lbl5thScore.Visible = False)
        Else
            lbl5thScore.Visible = False
        End If
        'lbl6thName
        If lbl6thName.InvokeRequired Then
            lbl6thName.Invoke(Sub() lbl6thName.Visible = False)
        Else
            lbl6thName.Visible = False
        End If
        'lbl6thScore
        If lbl6thScore.InvokeRequired Then
            lbl6thScore.Invoke(Sub() lbl6thScore.Visible = False)
        Else
            lbl6thScore.Visible = False
        End If
        'lbl7thName
        If lbl7thName.InvokeRequired Then
            lbl7thName.Invoke(Sub() lbl7thName.Visible = False)
        Else
            lbl7thName.Visible = False
        End If
        'lbl7thScore
        If lbl7thScore.InvokeRequired Then
            lbl7thScore.Invoke(Sub() lbl7thScore.Visible = False)
        Else
            lbl7thScore.Visible = False
        End If
        'lbl8thName
        If lbl8thName.InvokeRequired Then
            lbl8thName.Invoke(Sub() lbl8thName.Visible = False)
        Else
            lbl8thName.Visible = False
        End If
        'lbl8thScore
        If lbl8thScore.InvokeRequired Then
            lbl8thScore.Invoke(Sub() lbl8thScore.Visible = False)
        Else
            lbl8thScore.Visible = False
        End If
        'lbl9thName
        If lbl9thName.InvokeRequired Then
            lbl9thName.Invoke(Sub() lbl9thName.Visible = False)
        Else
            lbl9thName.Visible = False
        End If
        'lbl9thScore
        If lbl9thScore.InvokeRequired Then
            lbl9thScore.Invoke(Sub() lbl9thScore.Visible = False)
        Else
            lbl9thScore.Visible = False
        End If
        'pbrQTime
        If pbrQTime.InvokeRequired Then
            pbrQTime.Invoke(Sub() pbrQTime.Visible = True)
        Else
            pbrQTime.Visible = True
        End If

        'phases: 0: Moogle, 1: Chocobo, 2: Voidsent, 3: Primal, 4: Omega, 5: End
        Select Case intPhase
            Case 0
                Me.BackgroundImage = My.Resources.Moogle_Ask
            Case 1
                Me.BackgroundImage = My.Resources.Chocobo_Ask
            Case 2
                Me.BackgroundImage = My.Resources.Voidsent_Ask
            Case 3
                Me.BackgroundImage = My.Resources.Primal_Ask
            Case 4
                Me.BackgroundImage = My.Resources.Omega_Ask
            Case 5

            Case Else

        End Select

        If lblQuestion.InvokeRequired Then
            lblQuestion.Invoke(Sub() lblQuestion.Text = strQuestions(intQID, 0))
        Else
            lblQuestion.Text = strQuestions(intQID, 0)
        End If
        If lblA.InvokeRequired Then
            lblA.Invoke(Sub() lblA.Text = strQuestions(intQID, 1))
        Else
            lblA.Text = strQuestions(intQID, 1)
        End If
        If lblB.InvokeRequired Then
            lblB.Invoke(Sub() lblB.Text = strQuestions(intQID, 2))
        Else
            lblB.Text = strQuestions(intQID, 2)
        End If
        If lblC.InvokeRequired Then
            lblC.Invoke(Sub() lblC.Text = strQuestions(intQID, 3))
        Else
            lblC.Text = strQuestions(intQID, 3)
        End If
        If lblD.InvokeRequired Then
            lblD.Invoke(Sub() lblD.Text = strQuestions(intQID, 4))
        Else
            lblD.Text = strQuestions(intQID, 4)
        End If

        'phases: 0: Moogle, 1: Chocobo, 2: Voidsent, 3: Primal, 4: Omega, 5: End
        Select Case intPhase
            Case 0
                If lblInstruction.InvokeRequired Then
                    lblInstruction.Invoke(Sub() lblInstruction.Text = strInstruction & " " & moogleRuleText)
                Else
                    lblInstruction.Text = strInstruction & " " & moogleRuleText
                End If
            Case 1
                If lblInstruction.InvokeRequired Then
                    lblInstruction.Invoke(Sub() lblInstruction.Text = strInstruction & " " & chocoboRuleText)
                Else
                    lblInstruction.Text = strInstruction & " " & chocoboRuleText
                End If
            Case 2
                If lblInstruction.InvokeRequired Then
                    lblInstruction.Invoke(Sub() lblInstruction.Text = strInstruction & " " & voidsentRuleText)
                Else
                    lblInstruction.Text = strInstruction & " " & voidsentRuleText
                End If
            Case 3
                If lblInstruction.InvokeRequired Then
                    lblInstruction.Invoke(Sub() lblInstruction.Text = strInstruction & " " & primalRuleText)
                Else
                    lblInstruction.Text = strInstruction & " " & primalRuleText
                End If
            Case 4
                If lblInstruction.InvokeRequired Then
                    lblInstruction.Invoke(Sub() lblInstruction.Text = omegaRuleText)
                Else
                    lblInstruction.Text = omegaRuleText
                End If
            Case 5

            Case Else

        End Select
    End Sub

    Private Sub setSelect(omegaSelect As String)
        If intPhase = 4 Then
            Select Case omegaSelect
                Case "A"
                    Me.BackgroundImage = My.Resources.Omega_Select_A
                    tbotMammetBot.send("Omega chose A!")
                Case "B"
                    Me.BackgroundImage = My.Resources.Omega_Select_B
                    tbotMammetBot.send("Omega chose B!")
                Case "C"
                    Me.BackgroundImage = My.Resources.Omega_Select_C
                    tbotMammetBot.send("Omega chose C!")
                Case "D"
                    Me.BackgroundImage = My.Resources.Omega_Select_D
                    tbotMammetBot.send("Omega chose D!")
                Case Else

            End Select
        End If
    End Sub

    Private Sub setCorrect(correct As String)
        If correct.Equals("A") Then
            'phases: 0: Moogle, 1: Chocobo, 2: Voidsent, 3: Primal, 4: Omega, 5: End
            Select Case intPhase
                Case 0
                    Me.BackgroundImage = My.Resources.Moogle_Correct_A
                Case 1
                    Me.BackgroundImage = My.Resources.Chocobo_Correct_A
                Case 2
                    Me.BackgroundImage = My.Resources.Voidsent_Correct_A
                Case 3
                    Me.BackgroundImage = My.Resources.Primal_Correct_A
                Case 4
                    Me.BackgroundImage = My.Resources.Omega_Correct_A
                Case 5

                Case Else

            End Select
        End If
        If correct.Equals("B") Then
            'phases: 0: Moogle, 1: Chocobo, 2: Voidsent, 3: Primal, 4: Omega, 5: End
            Select Case intPhase
                Case 0
                    Me.BackgroundImage = My.Resources.Moogle_Correct_B
                Case 1
                    Me.BackgroundImage = My.Resources.Chocobo_Correct_B
                Case 2
                    Me.BackgroundImage = My.Resources.Voidsent_Correct_B
                Case 3
                    Me.BackgroundImage = My.Resources.Primal_Correct_B
                Case 4
                    Me.BackgroundImage = My.Resources.Omega_Correct_B
                Case 5

                Case Else

            End Select
        End If
        If correct.Equals("C") Then
            'phases: 0: Moogle, 1: Chocobo, 2: Voidsent, 3: Primal, 4: Omega, 5: End
            Select Case intPhase
                Case 0
                    Me.BackgroundImage = My.Resources.Moogle_Correct_C
                Case 1
                    Me.BackgroundImage = My.Resources.Chocobo_Correct_C
                Case 2
                    Me.BackgroundImage = My.Resources.Voidsent_Correct_C
                Case 3
                    Me.BackgroundImage = My.Resources.Primal_Correct_C
                Case 4
                    Me.BackgroundImage = My.Resources.Omega_Correct_C
                Case 5

                Case Else

            End Select
        End If
        If correct.Equals("D") Then
            'phases: 0: Moogle, 1: Chocobo, 2: Voidsent, 3: Primal, 4: Omega, 5: End
            Select Case intPhase
                Case 0
                    Me.BackgroundImage = My.Resources.Moogle_Correct_D
                Case 1
                    Me.BackgroundImage = My.Resources.Chocobo_Correct_D
                Case 2
                    Me.BackgroundImage = My.Resources.Voidsent_Correct_D
                Case 3
                    Me.BackgroundImage = My.Resources.Primal_Correct_D
                Case 4
                    Me.BackgroundImage = My.Resources.Omega_Correct_D
                Case 5

                Case Else

            End Select
        End If

    End Sub

    Private Sub setFinish()
        'phases: 0: Moogle, 1: Chocobo, 2: Voidsent, 3: Primal, 4: Omega, 5: End
        Select Case intPhase
            Case 0
                Me.BackgroundImage = My.Resources.Moogle_Finished
            Case 1
                Me.BackgroundImage = My.Resources.Chocobo_Finished
            Case 2
                Me.BackgroundImage = My.Resources.Voidsent_Finished
            Case 3
                Me.BackgroundImage = My.Resources.Primal_Finished
            Case 4
                Me.BackgroundImage = My.Resources.Omega_Finished
            Case 5

            Case Else

        End Select
    End Sub

    Private Sub setRanks()
        'lblquestion
        If lblQuestion.InvokeRequired Then
            lblQuestion.Invoke(Sub() lblQuestion.Visible = False)
        Else
            lblQuestion.Visible = False
        End If
        'lblinstruciton
        If lblInstruction.InvokeRequired Then
            lblInstruction.Invoke(Sub() lblInstruction.Visible = False)
        Else
            lblInstruction.Visible = False
        End If
        'lblA
        If lblA.InvokeRequired Then
            lblA.Invoke(Sub() lblA.Visible = False)
        Else
            lblA.Visible = False
        End If
        'lblB
        If lblB.InvokeRequired Then
            lblB.Invoke(Sub() lblB.Visible = False)
        Else
            lblB.Visible = False
        End If
        'lblC
        If lblC.InvokeRequired Then
            lblC.Invoke(Sub() lblC.Visible = False)
        Else
            lblC.Visible = False
        End If
        'lblD  
        If lblD.InvokeRequired Then
            lblD.Invoke(Sub() lblD.Visible = False)
        Else
            lblD.Visible = False
        End If
        'lblAnswers
        If lblAnswers.InvokeRequired Then
            lblAnswers.Invoke(Sub() lblAnswers.Visible = False)
        Else
            lblAnswers.Visible = False
        End If
        'lblAnswersHead
        If lblAnswersHead.InvokeRequired Then
            lblAnswersHead.Invoke(Sub() lblAnswersHead.Visible = False)
        Else
            lblAnswersHead.Visible = False
        End If
        'lblValue
        If lblValue.InvokeRequired Then
            lblValue.Invoke(Sub() lblValue.Visible = False)
        Else
            lblValue.Visible = False
        End If
        'lblValueFOot
        If lblValueFoot.InvokeRequired Then
            lblValueFoot.Invoke(Sub() lblValueFoot.Visible = False)
        Else
            lblValueFoot.Visible = False
        End If
        'lblValueHead
        If lblValueHead.InvokeRequired Then
            lblValueHead.Invoke(Sub() lblValueHead.Visible = False)
        Else
            lblValueHead.Visible = False
        End If
        'lblTimer
        If lblTimer.InvokeRequired Then
            lblTimer.Invoke(Sub() lblTimer.Visible = False)
        Else
            lblTimer.Visible = False
        End If
        'lbl1stName
        If lbl1stName.InvokeRequired Then
            lbl1stName.Invoke(Sub() lbl1stName.Visible = True)
        Else
            lbl1stName.Visible = True
        End If
        'lbl1stScore
        If lbl1stScore.InvokeRequired Then
            lbl1stScore.Invoke(Sub() lbl1stScore.Visible = True)
        Else
            lbl1stScore.Visible = True
        End If
        'lbl2ndName
        If lbl2ndName.InvokeRequired Then
            lbl2ndName.Invoke(Sub() lbl2ndName.Visible = True)
        Else
            lbl2ndName.Visible = True
        End If
        'lbl2ndScore
        If lbl2ndScore.InvokeRequired Then
            lbl2ndScore.Invoke(Sub() lbl2ndScore.Visible = True)
        Else
            lbl2ndScore.Visible = True
        End If
        'lbl3rdName
        If lbl3rdName.InvokeRequired Then
            lbl3rdName.Invoke(Sub() lbl3rdName.Visible = True)
        Else
            lbl3rdName.Visible = True
        End If
        'lbl3rdScore
        If lbl3rdScore.InvokeRequired Then
            lbl3rdScore.Invoke(Sub() lbl3rdScore.Visible = True)
        Else
            lbl3rdScore.Visible = True
        End If
        'lbl4thName
        If lbl4thName.InvokeRequired Then
            lbl4thName.Invoke(Sub() lbl4thName.Visible = True)
        Else
            lbl4thName.Visible = True
        End If
        'lbl4thScore
        If lbl4thScore.InvokeRequired Then
            lbl4thScore.Invoke(Sub() lbl4thScore.Visible = True)
        Else
            lbl4thScore.Visible = True
        End If
        'lbl5thName
        If lbl5thName.InvokeRequired Then
            lbl5thName.Invoke(Sub() lbl5thName.Visible = True)
        Else
            lbl5thName.Visible = True
        End If
        'lbl5thScore
        If lbl5thScore.InvokeRequired Then
            lbl5thScore.Invoke(Sub() lbl5thScore.Visible = True)
        Else
            lbl5thScore.Visible = True
        End If
        'lbl6thName
        If lbl6thName.InvokeRequired Then
            lbl6thName.Invoke(Sub() lbl6thName.Visible = True)
        Else
            lbl6thName.Visible = True
        End If
        'lbl6thScore
        If lbl6thScore.InvokeRequired Then
            lbl6thScore.Invoke(Sub() lbl6thScore.Visible = True)
        Else
            lbl6thScore.Visible = True
        End If
        'lbl7thName
        If lbl7thName.InvokeRequired Then
            lbl7thName.Invoke(Sub() lbl7thName.Visible = True)
        Else
            lbl7thName.Visible = True
        End If
        'lbl7thScore
        If lbl7thScore.InvokeRequired Then
            lbl7thScore.Invoke(Sub() lbl7thScore.Visible = True)
        Else
            lbl7thScore.Visible = True
        End If
        'lbl8thName
        If lbl8thName.InvokeRequired Then
            lbl8thName.Invoke(Sub() lbl8thName.Visible = True)
        Else
            lbl8thName.Visible = True
        End If
        'lbl8thScore
        If lbl8thScore.InvokeRequired Then
            lbl8thScore.Invoke(Sub() lbl8thScore.Visible = True)
        Else
            lbl8thScore.Visible = True
        End If
        'lbl9thName
        If lbl9thName.InvokeRequired Then
            lbl9thName.Invoke(Sub() lbl9thName.Visible = True)
        Else
            lbl9thName.Visible = True
        End If
        'lbl9thScore
        If lbl9thScore.InvokeRequired Then
            lbl9thScore.Invoke(Sub() lbl9thScore.Visible = True)
        Else
            lbl9thScore.Visible = True
        End If
        'pbrQTime
        If pbrQTime.InvokeRequired Then
            pbrQTime.Invoke(Sub() pbrQTime.Visible = False)
        Else
            pbrQTime.Visible = False
        End If

        'phases: 0: Moogle, 1: Chocobo, 2: Voidsent, 3: Primal, 4: Omega, 5: End
        Select Case intPhase
            Case 0
                Me.BackgroundImage = My.Resources.Moogle_Ranks
            Case 1
                Me.BackgroundImage = My.Resources.Chocobo_Ranks
            Case 2
                Me.BackgroundImage = My.Resources.Voidsent_Ranks
            Case 3
                Me.BackgroundImage = My.Resources.Primal_Ranks
            Case 4
                Me.BackgroundImage = My.Resources.Victory
            Case 5
                Me.BackgroundImage = My.Resources.Victory
            Case Else

        End Select

        If lbl1stName.InvokeRequired Then
            lbl1stName.Invoke(Sub() lbl1stName.Text = strTop9(0, 0))
        Else
            lbl1stName.Text = strTop9(0, 0)
        End If
        If lbl1stScore.InvokeRequired Then
            lbl1stScore.Invoke(Sub() lbl1stScore.Text = strTop9(0, 1))
        Else
            lbl1stScore.Text = strTop9(0, 1)
        End If

        If lbl2ndName.InvokeRequired Then
            lbl2ndName.Invoke(Sub() lbl2ndName.Text = strTop9(1, 0))
        Else
            lbl2ndName.Text = strTop9(1, 0)
        End If
        If lbl2ndScore.InvokeRequired Then
            lbl2ndScore.Invoke(Sub() lbl2ndScore.Text = strTop9(1, 1))
        Else
            lbl2ndScore.Text = strTop9(1, 1)
        End If

        If lbl3rdName.InvokeRequired Then
            lbl3rdName.Invoke(Sub() lbl3rdName.Text = strTop9(2, 0))
        Else
            lbl3rdName.Text = strTop9(2, 0)
        End If
        If lbl3rdScore.InvokeRequired Then
            lbl3rdScore.Invoke(Sub() lbl3rdScore.Text = strTop9(2, 1))
        Else
            lbl3rdScore.Text = strTop9(2, 1)
        End If

        If lbl4thName.InvokeRequired Then
            lbl4thName.Invoke(Sub() lbl4thName.Text = strTop9(3, 0))
        Else
            lbl4thName.Text = strTop9(3, 0)
        End If
        If lbl4thScore.InvokeRequired Then
            lbl4thScore.Invoke(Sub() lbl4thScore.Text = strTop9(3, 1))
        Else
            lbl4thScore.Text = strTop9(3, 1)
        End If

        If lbl5thName.InvokeRequired Then
            lbl5thName.Invoke(Sub() lbl5thName.Text = strTop9(4, 0))
        Else
            lbl5thName.Text = strTop9(4, 0)
        End If
        If lbl5thScore.InvokeRequired Then
            lbl5thScore.Invoke(Sub() lbl5thScore.Text = strTop9(4, 1))
        Else
            lbl5thScore.Text = strTop9(4, 1)
        End If

        If lbl6thName.InvokeRequired Then
            lbl6thName.Invoke(Sub() lbl6thName.Text = strTop9(5, 0))
        Else
            lbl6thName.Text = strTop9(5, 0)
        End If
        If lbl6thScore.InvokeRequired Then
            lbl6thScore.Invoke(Sub() lbl6thScore.Text = strTop9(5, 1))
        Else
            lbl6thScore.Text = strTop9(5, 1)
        End If

        If lbl7thName.InvokeRequired Then
            lbl7thName.Invoke(Sub() lbl7thName.Text = strTop9(6, 0))
        Else
            lbl7thName.Text = strTop9(6, 0)
        End If
        If lbl7thScore.InvokeRequired Then
            lbl7thScore.Invoke(Sub() lbl7thScore.Text = strTop9(6, 1))
        Else
            lbl7thScore.Text = strTop9(6, 1)
        End If

        If lbl8thName.InvokeRequired Then
            lbl8thName.Invoke(Sub() lbl8thName.Text = strTop9(7, 0))
        Else
            lbl8thName.Text = strTop9(7, 0)
        End If
        If lbl8thScore.InvokeRequired Then
            lbl8thScore.Invoke(Sub() lbl8thScore.Text = strTop9(7, 1))
        Else
            lbl8thScore.Text = strTop9(7, 1)
        End If

        If lbl9thName.InvokeRequired Then
            lbl9thName.Invoke(Sub() lbl9thName.Text = strTop9(8, 0))
        Else
            lbl9thName.Text = strTop9(8, 0)
        End If
        If lbl9thScore.InvokeRequired Then
            lbl9thScore.Invoke(Sub() lbl9thScore.Text = strTop9(8, 1))
        Else
            lbl9thScore.Text = strTop9(8, 1)
        End If
    End Sub

    Private Sub bwMain_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwMain.DoWork
        SubPhase()
    End Sub

    Private Sub Shuffle(arry() As Integer)
        Dim tmp As Integer
        Dim j As Integer

        For n As Integer = arry.Length - 1 To 0 Step -1
            j = rand.Next(0, n + 1)
            tmp = arry(j)

            ' swap item(j) and item(n) 
            arry(j) = arry(n)
            arry(n) = tmp
        Next
    End Sub

    Private Sub readFileWithoutRepeats()
        Dim testReader As StreamReader = New StreamReader("UsedQ.txt")
        Dim intFileLength = 0
        Dim junkBuffer As String
        While testReader.EndOfStream = False
            junkBuffer = testReader.ReadLine()
            intFileLength += 1
        End While
        testReader.Close()
        Dim intIndex As Integer = 0
        Dim strInbound(intFileLength - 1) As String
        Dim usedReader As StreamReader = New StreamReader("UsedQ.txt")
        While usedReader.EndOfStream = False
            strInbound(intIndex) = usedReader.ReadLine()
            intIndex += 1
        End While
        usedReader.Close()

        strBuffer3 = My.Resources.QnA.Split(vbLf)
        Dim pool As Int32() = Enumerable.Range(0, strBuffer3.Length).ToArray()
        Dim index7 = 0
        For index6 = 0 To pool.Length - 1
            If pool(index6).Equals(strInbound(index7)) Then
                pool(index6) = -1
                index7 += 1
            End If
        Next
        Shuffle(pool)
        Dim SelectedQs((baseQsPerPhase * 5) - 1) As Integer
        Dim index8 As Integer = 0
        Dim index9 As Integer = 0
        Dim bolTest As Boolean = True
        While bolTest
            If pool(index9) = -1 Then
                index9 += 1
            Else
                Try
                    SelectedQs(index8) = pool(index9)
                    index8 += 1
                    index9 += 1
                Catch ex As Exception
                    SelectedQs(index8) = rand.Next(0, strBuffer3.Length)
                    index8 += 1
                    index9 += 1
                End Try

            End If
            If index8 >= SelectedQs.Length - 1 Then
                bolTest = False
            End If
        End While

        For index = 0 To SelectedQs.Length - 1
            strBuffer2 = strBuffer3(SelectedQs(index)).Split("|")
            strQuestions(index, 0) = strBuffer2(0)
            strQuestions(index, 1) = strBuffer2(1)
            strQuestions(index, 2) = strBuffer2(2)
            strQuestions(index, 3) = strBuffer2(3)
            strQuestions(index, 4) = strBuffer2(4)
            strQuestions(index, 5) = strBuffer2(5)
            strQuestions(index, 6) = strBuffer2(6)
        Next

        Array.Sort(SelectedQs)

        Dim intOutbound((SelectedQs.Length + strInbound.Length) - 1) As Integer
        Dim index2 As Integer = 0
        For index3 = 0 To SelectedQs.Length - 1
            intOutbound(index2) = SelectedQs(index3)
            index2 += 1
        Next
        For index4 = 0 To strInbound.Length - 1
            If strInbound(index4).Equals(String.Empty) Then
            Else
                intOutbound(index2) = CInt(strInbound(index4))
                index2 += 1
            End If
        Next
        Array.Sort(intOutbound)
        Dim UsedWriter As StreamWriter = New StreamWriter("UsedQ.txt")
        For index5 = 0 To intOutbound.Length - 1
            UsedWriter.WriteLine(intOutbound(index5))
        Next
        UsedWriter.Close()

    End Sub

    Private Sub firstReadWithRepeats()
        strBuffer3 = My.Resources.QnA.Split(vbLf)
        Dim pool As Int32() = Enumerable.Range(0, strBuffer3.Length).ToArray()
        Shuffle(pool)
        Dim SelectedQs((baseQsPerPhase * 5) - 1) As Integer
        SelectedQs = pool.Take((baseQsPerPhase * 5)).ToArray()
        For index = 0 To SelectedQs.Length - 1
            strBuffer2 = strBuffer3(SelectedQs(index)).Split("|")
            strQuestions(index, 0) = strBuffer2(0)
            strQuestions(index, 1) = strBuffer2(1)
            strQuestions(index, 2) = strBuffer2(2)
            strQuestions(index, 3) = strBuffer2(3)
            strQuestions(index, 4) = strBuffer2(4)
            strQuestions(index, 5) = strBuffer2(5)
            strQuestions(index, 6) = strBuffer2(6)
        Next

        Array.Sort(SelectedQs)

        Dim UsedWriter As StreamWriter = New StreamWriter("UsedQ.txt")
        For index5 = 0 To SelectedQs.Length - 1
            UsedWriter.WriteLine(SelectedQs(index5))
        Next
        UsedWriter.Close()
    End Sub

    Private Sub readFileWithRepeats()
        strBuffer3 = My.Resources.QnA.Split(vbLf)
        Dim pool As Int32() = Enumerable.Range(0, strBuffer3.Length).ToArray()
        Shuffle(pool)
        Dim SelectedQs((baseQsPerPhase * 5) - 1) As Integer
        SelectedQs = pool.Take((baseQsPerPhase * 5)).ToArray()
        For index = 0 To SelectedQs.Length - 1
            strBuffer2 = strBuffer3(SelectedQs(index)).Split("|")
            strQuestions(index, 0) = strBuffer2(0)
            strQuestions(index, 1) = strBuffer2(1)
            strQuestions(index, 2) = strBuffer2(2)
            strQuestions(index, 3) = strBuffer2(3)
            strQuestions(index, 4) = strBuffer2(4)
            strQuestions(index, 5) = strBuffer2(5)
            strQuestions(index, 6) = strBuffer2(6)
        Next
    End Sub

End Class
