Public Class Player
    Implements IComparable
    ' Author: Neal Jamieson
    ' Date: 4/7/2019
    ' Version: 0.0.0.0
    ' Description:
    ' Class for tracking vital information for players in the game
    ' Acts as a node in a tree

    Private strName As String
    Private intScore As Integer
    Private intQID As Integer
    Public LeftNode As Player
    Public RightNode As Player

    Public Overloads Function CompareTo(ByVal obj As Object) As Integer _
        Implements IComparable.CompareTo

        If obj Is Nothing Then Return 1

        Dim otherPlayer As Player = TryCast(obj, Player)
        If otherPlayer IsNot Nothing Then
            Return Me.intScore.CompareTo(otherPlayer.intScore)
        Else
            Throw New ArgumentException("Object is not a player")
        End If
    End Function

    Public Sub New(PlayerName As String)
        strName = PlayerName
        intScore = 0
        intQID = -1
    End Sub

    Public Sub addScore(Score As Integer)
        intScore += Score
    End Sub
    Public Function getScore()
        Return intScore
    End Function
    Public Function getName()
        Return strName
    End Function
    Public Function getQID()
        Return intQID
    End Function
    Public Sub setQID(qid As Integer)
        intQID = qid
    End Sub
End Class
