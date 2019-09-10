Public Class BinarySearchTree
    ' Author: Neal Jamieson
    ' Date: 4/7/2019
    ' Version: 0.0.0.0
    ' Based upon original code by:  Manoj G. on Code Project (https://www.codeproject.com/articles/4647/a-simple-binary-tree-implementation-with-vb-net)
    ' Description: 

    Public _root As Player

    Sub New(ByVal rootName As String)
        _root = GetNode(rootName)
    End Sub

    Private Function GetNode(ByVal name As String) As Player
        Dim node As New Player(name)
        Return node
    End Function

    Public Sub AddtoTree(ByVal name As String)
        Dim currentNode As Player = _root
        Dim nextNode As Player = _root

        While currentNode.getName() <> name And Not nextNode Is Nothing
            currentNode = nextNode
            If nextNode.getName() < name Then
                nextNode = nextNode.RightNode
            Else
                nextNode = nextNode.LeftNode
            End If
        End While
        If currentNode.getName() = name Then
            Console.WriteLine("Duplicate value (" &
                 name & "). Node was not inserted")
        ElseIf currentNode.getName() < name Then
            currentNode.RightNode = GetNode(name)
        Else
            currentNode.LeftNode = GetNode(name)
        End If
    End Sub

    Public Function SearchTree(ByVal name As String)
        Dim currentNode As Player = _root
        Dim nextNode As Player = _root

        While currentNode.getName() <> name And Not nextNode Is Nothing
            currentNode = nextNode
            If nextNode.getName() < name Then
                nextNode = nextNode.RightNode
            Else
                nextNode = nextNode.LeftNode
            End If
        End While
        If currentNode.getName() = name Then
            Return currentNode
        Else
            Return False
        End If
    End Function
End Class
