Public Class Answers
    Implements IComparable

    Private strName As String
    Private strAnswer As String
    Private intQID As Integer
    Private intPoints As Integer

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing Then Return 1

        Dim otherAnswer As Answers = TryCast(obj, Answers)
        If otherAnswer IsNot Nothing Then
            Return Me.strName.CompareTo(otherAnswer.strName)
        Else
            Throw New ArgumentException("Object is not a answer")
        End If
    End Function
    Public Sub New(name As String, answer As String, qid As Integer, points As Integer)
        strName = name
        strAnswer = answer
        intQID = qid
        intPoints = points
    End Sub

    Public Function name()
        Return strName
    End Function
    Public Function answer()
        Return strAnswer
    End Function
    Public Function qid()
        Return intQID
    End Function
    Public Function points()
        Return intPoints
    End Function
End Class
