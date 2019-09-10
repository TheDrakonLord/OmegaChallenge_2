Public Class TwitchBot
    ' Author: Neal Jamieson
    ' Date: 4/3/2019
    ' Version: 1.0.0.0
    ' Heavily modified based upon original code by:https://jakash3.wordpress.com on https://jakash3.wordpress.com/2012/02/13/simple-vb-net-and-csharp-irc-client/
    ' Description: 
    ' designed to connect to the Twitch IRC server and join a specified channel.
    ' once connected monitors for incoming messages and sends messages when requested.
    ' also responds to server PINGs when necessary.
    ' Does not contain its own commands, those must be provided by the calling code.
    Private port As Integer
    Private buf As String, nick As String, server As String, chan As String, pass As String
    Private sock As New System.Net.Sockets.TcpClient()
    Private input As System.IO.TextReader
    Private output As System.IO.TextWriter

    ''' <summary>
    ''' Constructor for the TwitchBot class.
    ''' </summary>
    ''' <param name="Nickname">The username of the bot</param>
    ''' <param name="ServerName">The twitch IRC server address. Use the Non-SSL IRC Client address found in the API documentation</param>
    ''' <param name="ServerPort">The twitch IRC Server port. Use the Non-SSL IRC Client port found in the API documentation</param>
    ''' <param name="Channel">The name of the twitch channel to connect to</param>
    ''' <param name="OathPass">the Oath Password obtained from twitch. Must be formated as oath:###########</param>
    Public Sub New(Nickname As String, ServerName As String, ServerPort As Integer, Channel As String, OathPass As String)
        nick = Nickname.Trim.ToLower

        server = ServerName

        port = ServerPort

        chan = Channel.Trim.ToLower

        pass = OathPass
    End Sub
    ''' <summary>
    ''' Connects to the server and then accesses the specified channel
    ''' </summary>
    ''' <returns>Returns string values of either "Failed to connect! on failure otherwise returns a copy of the access message that was sent to the server.</returns>
    Public Function Initialize()
        '------------BEGIN BOT LOAD------------
        'Connect to irc server and get input and output text streams from TcpClient.
        sock.Connect(server, port)
        If Not sock.Connected Then
            Return "Failed to connect!"
        End If
        input = New System.IO.StreamReader(sock.GetStream())
        output = New System.IO.StreamWriter(sock.GetStream())

        'Starting USER and NICK login commands 
        output.Write("PASS " & pass & vbCr & vbLf & "NICK " & nick & vbCr & vbLf & "JOIN #" & chan & vbCr & vbLf)
        output.Flush()
        Return "PASS " & pass & vbCr & vbLf & "NICK " & nick & vbCr & vbLf & "JOIN #" & chan & vbCr & vbLf


        '------------END BOT LOAD------------
    End Function
    ''' <summary>
    ''' This function must be placed inside a loop. Strongly reccommended that the loop occur within another thread.
    ''' Monitors the server for new messages and responds to server PINGs.
    ''' </summary>
    ''' <returns>Returns messages recieved by the server. also returns PONG when the bot responds to a PING request</returns>
    Public Function monitor()
        'Process each line received from irc server
        buf = input.ReadLine()

        'Send pong reply to any ping messages
        If buf.StartsWith("PING ") Then
            output.Write(buf.Replace("PING", "PONG") & vbCr & vbLf)
            output.Flush()
            Return buf & vbCrLf & "PONG" & vbCrLf
        Else
            'Display received irc message
            Return buf & vbCrLf
        End If
    End Function
    ''' <summary>
    ''' Sends a message to the specified channel on the server
    ''' </summary>
    ''' <param name="message">a string containing the message to be sent</param>
    ''' <returns>Returns a copy of the message sent to the server to be stored in a log</returns>
    Public Function send(message As String)
        output.Write("PRIVMSG #" & chan & " :" & message & vbCr & vbLf)
        output.Flush()
        Return "PRIVMSG #" & chan & " :" & message & vbCr & vbLf
    End Function
End Class
