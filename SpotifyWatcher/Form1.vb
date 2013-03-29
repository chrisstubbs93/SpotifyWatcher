Imports System.IO

Public Class Form1
    Dim songdata(1) As String
    Dim title As String
    Dim blocks(1024) As String
    Dim ptr As Integer
    Dim FILE_NAME As String = "C:\spotifywatcherblocks.txt"

    Dim spotify As New spotify()


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Enabled = True
        Button1.Text = "SpotifyWatcher Running"
        Button1.Enabled = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim p As Process
        Dim p2() As Process
        p2 = Process.GetProcessesByName("spotify")
        For Each p In Process.GetProcessesByName("spotify")

            title = p.MainWindowTitle.ToString
            If title.Length() > 10 Then
                songdata = Split(p.MainWindowTitle.ToString, " - ")
                songdata = Split(songdata(1), " – ")
                Label2.Text = songdata(0)
                Label3.Text = songdata(1)

                For a = 0 To blocks.Length - 1
                    If blocks(a) = title Then
                        ' MsgBox("BLOCKED SONG")


                        spotify.PlayNext()


                    End If
                Next
            End If
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Button1.Text = "SpotifyWatcher Running"
        Button1.Enabled = False

        '  Dim objWriter As New System.IO.StreamWriter(FILE_NAME, False)
        readfile()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim aryText As String
        aryText = title
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
        objWriter.WriteLine(aryText)
        objWriter.Close()
        ' MsgBox("Text Appended to the File")
        readfile()

    End Sub

    Sub readfile()
        Try
            ' Create an instance of StreamReader to read from a file.
            Dim sr As StreamReader = New StreamReader(FILE_NAME)
            Dim line As String
            ' Read and display the lines from the file until the end 
            ' of the file is reached.
            Do
                line = sr.ReadLine()
                ' MsgBox(line)
                blocks(ptr) = line
                ptr += 1
            Loop Until line Is Nothing
            sr.Close()
        Catch
            ' Let the user know what went wrong.
            '  MsgBox("The file could not be read:")
        End Try
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MsgBox("Delete the appropriate line from this notepad file")
        MsgBox("Make sure you leave the blank newline at the end of the file")
        System.Diagnostics.Process.Start(FILE_NAME)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MsgBox("Broken the program? Try exiting, deleting '" & FILE_NAME & "', then opening this program again")
    End Sub
End Class
