Imports System.Net.Sockets
Imports System.Text
Imports System.Net
Public Class Client
    Private _Server, _Port, _Nick, _Channel, _Pass, _Jmsg As String
    Private ClientThread As Threading.Thread
    Private EP As IPEndPoint
    Private Connection As Socket
    Private WithEvents SendingTimer As Timer
    Private queToSend As New Queue()
    Public Sub New(Server As String, Port As String, Nick As String, Channel As String, Pass As String, Jmsg As String)
        _Server = Server
        _Port = Port
        _Nick = Nick.Trim.ToLower
        _Channel = Channel.Trim.ToLower
        _Pass = Pass
        _Jmsg = Jmsg
    End Sub
    Public Function StartConnection() As Boolean

        Try
            EP = New IPEndPoint(Dns.GetHostEntry(_Server).AddressList(0), _Port)
            Connection = New Socket(EP.Address.AddressFamily, Net.Sockets.SocketType.Stream, Net.Sockets.ProtocolType.Tcp)
            Connection.Connect(_Server, _Port)
            Send("PASS " & _Pass) : Send("NICK " & _Nick) : Send("JOIN " & _Channel)
            Send("PRIVMSG " & _Channel & " :" & _Jmsg)
        Catch ex As Exception
            Return False
        End Try
        ClientThread = New Threading.Thread(AddressOf Connect)
        ClientThread.Start()
        SendingTimer = New Timer
        SendingTimer.Interval = 1500
        SendingTimer.Start()
        Return True
    End Function
    Public Function ConnectionStatus() As Boolean
        Try
            SyncLock Connection
                Return Connection.Connected
            End SyncLock
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub Close()
        On Error Resume Next
        SyncLock Connection
            Connection.Disconnect(False)
            Connection.Close()
        End SyncLock
    End Sub
    Private Sub Connect()
        Dim link As Boolean = True
        Do While link
            recv()
            SyncLock Connection
                link = Connection.Connected
            End SyncLock
        Loop
        MsgBox("Disconnected") 'add actual disconnect handling
    End Sub
    Public Sub Send(ByVal msg As String)
        msg = msg.Trim
        Dim data() As Byte = ASCIIEncoding.ASCII.GetBytes(msg & vbCrLf)
        SyncLock Connection
            Connection.Send(data, data.Length, SocketFlags.None)
        End SyncLock
    End Sub
    Private Sub recv()
        On Error Resume Next
        Dim data(511) As Byte
        Connection.Receive(data, 512, SocketFlags.None)
        Dim mail As String = System.Text.ASCIIEncoding.ASCII.GetString(data)
        mail = mail.TrimEnd(Chr(0)).Remove(mail.LastIndexOf(vbLf), 1).Remove(mail.LastIndexOf(vbCr), 1)
        If mail.StartsWith("PING") Then
            Dim pserv As String = mail.Substring(mail.IndexOf(" "), mail.Length - mail.IndexOf(" ")).TrimEnd(Chr(0))
            Send("PONG" & pserv)
        End If
        MammetBot.RichTextBox1.AppendText(mail.Trim + "/n")
    End Sub
    Public Sub addToQueue(message As String)
        queToSend.Enqueue(message)
    End Sub
    Private Sub SendingTimer_Tick(sender As Object, e As EventArgs) Handles SendingTimer.Tick
        If queToSend.Count > 0 Then
            Dim meh As String = queToSend.Dequeue
            If Not meh = String.Empty Then Send(meh)
        End If
    End Sub
End Class
