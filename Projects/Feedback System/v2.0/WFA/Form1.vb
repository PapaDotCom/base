Imports MySql.Data.MySqlClient



'Home form
Public Class Form1
    Dim con As New MySqlConnection(My.Settings.Connection)
    Dim reader As MySqlDataReader
    Dim cmd As MySqlCommand
    Dim query As String
    Dim str As String



    'On load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        check()
        Panel1.Visible = True
        TextBox1.Focus()
    End Sub



    'Sudent menu click
    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click
        TextBox1.Text = "7317"
        DatePicker.Value = "01/01/2000"
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        check()
        Panel1.Visible = True
        TextBox1.Focus()
    End Sub




    'Advisor menu click
    Private Sub AdvisorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdvisorToolStripMenuItem.Click
        TextBox3.Text = ""
        TextBox4.Text = ""
        Panel1.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        check()
        Panel2.Visible = True
        TextBox3.Focus()
    End Sub



    'Department menu click
    Private Sub HODToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HODToolStripMenuItem.Click
        TextBox5.Text = ""
        TextBox6.Text = ""
        Panel1.Visible = False
        Panel2.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        check()
        Panel3.Visible = True
        TextBox5.Focus()
    End Sub



    'Administrator menu click
    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        TextBox7.Text = ""
        TextBox8.Text = ""
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel5.Visible = False
        check()
        Panel4.Visible = True
        TextBox7.Focus()
    End Sub



    'About menu click
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = True
    End Sub



    'Link clicked
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.ananthsoft.in")
    End Sub



    'Student login button click
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If IsNumeric(TextBox1.Text) = False Then
            MsgBox("Register number should be a number", vbInformation, "Information")
            TextBox1.Focus()
            ProgressBar.Visible = False
        ElseIf TextBox1.Text.Length <> 12 Then
            MsgBox("Register number should be a 12 digit number", vbInformation, "Information")
            TextBox1.Focus()
            ProgressBar.Visible = False
        Else
            Dim value As String = DatePicker.Value.ToShortDateString
            Dim dob As DateTime = value
            query = "select * from student where regno='" & TextBox1.Text & "' and dob='" & dob.ToString("dd/MM/yyyy") & "'"
            str = exe(query)
            If str = "valid" Then
                ProgressBar.Visible = False
                Form2.Show()
                Me.Hide()
            ElseIf str = "invalid" Then
                MsgBox("Invalid register number or date of birth" + vbCrLf + "(Else contact your class advisor)", vbCritical, "Login failed")
                ProgressBar.Visible = False
                TextBox1.Focus()
            ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                Label2.Text = "Offline"
                Label2.ForeColor = Color.Red
                MsgBox("Unable to connect server", vbCritical, "No internet")
                ProgressBar.Visible = False
                TextBox1.Text = "7317"
                DatePicker.Value = "01/01/2000"
            Else
                MsgBox(str, vbCritical, "Error")
                ProgressBar.Visible = False
                TextBox1.Text = "7317"
                DatePicker.Value = "01/01/2000"
            End If
        End If
    End Sub



    'Advisor login button click
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        query = "select * from advisor where username='" & TextBox3.Text & "' and password='" & TextBox4.Text & "' "
        str = exe(query)
        If str = "valid" Then
            ProgressBar.Visible = False
            Form3.Show()
            Me.Hide()
        ElseIf str = "invalid" Then
            MsgBox("Invalid username or password" + vbCrLf + "(Else contact your department)", vbCritical, "Login failed")
            ProgressBar.Visible = False
            TextBox4.Text = ""
            TextBox3.Focus()
        ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
            Label2.Text = "Offline"
            Label2.ForeColor = Color.Red
            MsgBox("Unable to connect server", vbCritical, "No internet")
            ProgressBar.Visible = False
            TextBox3.Text = ""
            TextBox4.Text = ""
        Else
            MsgBox(str, vbCritical, "Error")
            ProgressBar.Visible = False
            TextBox3.Text = ""
            TextBox4.Text = ""
        End If
    End Sub



    'Department login button click
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox5.Text <> "ADMIN" Then
            query = "select * from account where username='" & TextBox5.Text & "' and password='" & TextBox6.Text & "' "
            str = exe(query)
            If str = "valid" Then
                ProgressBar.Visible = False
                Form4.Show()
                Me.Hide()
            ElseIf str = "invalid" Then
                MsgBox("Invalid username or password" + vbCrLf + "(Else contact administrator)", vbCritical, "Try again")
                ProgressBar.Visible = False
                TextBox6.Text = ""
                TextBox5.Focus()
            ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                Label2.Text = "Offline"
                Label2.ForeColor = Color.Red
                MsgBox("Unable to connect server", vbCritical, "No internet")
                ProgressBar.Visible = False
                TextBox5.Text = ""
                TextBox6.Text = ""
            Else
                MsgBox(str, vbCritical, "Error")
                ProgressBar.Visible = False
                TextBox5.Text = ""
                TextBox6.Text = ""
            End If
        Else
            MsgBox("Invalid username", vbCritical, "Try again")
            ProgressBar.Visible = False
            TextBox6.Text = ""
            TextBox5.Focus()
        End If
    End Sub



    'Administrator login button click
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox7.Text = "admin" Or TextBox7.Text = "Admin" Then
            query = "select * from account where username='" & TextBox7.Text & "' and password='" & TextBox8.Text & "' "
            str = exe(query)
            If str = "valid" Then
                ProgressBar.Visible = False
                Form5.Show()
                Me.Hide()
            ElseIf str = "invalid" Then
                MsgBox("Invalid username or password", vbCritical, "Try again")
                ProgressBar.Visible = False
                TextBox8.Text = ""
                TextBox7.Focus()
            ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                Label2.Text = "Offline"
                Label2.ForeColor = Color.Red
                MsgBox("Unable to connect server", vbCritical, "No internet")
                ProgressBar.Visible = False
                TextBox7.Text = ""
                TextBox8.Text = ""
            Else
                MsgBox(str, vbCritical, "Error")
                ProgressBar.Visible = False
                TextBox7.Text = ""
                TextBox8.Text = ""
            End If
        Else
            MsgBox("Invalid username", vbCritical, "Try again")
            ProgressBar.Visible = False
            TextBox8.Text = ""
            TextBox7.Focus()
        End If
    End Sub



    'Execute query function
    Function exe(ByVal query As String) As String
        cmd = New MySqlCommand(query, con)
        ProgressBar.Value = 50
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
                Label2.Text = "Online"
                Label2.ForeColor = Color.LimeGreen
            End If
            ProgressBar.Value = 75
            reader = cmd.ExecuteReader
            If reader.HasRows = 0 Then
                ProgressBar.Value = 75
                Return "invalid"
            Else
                ProgressBar.Value = 100
                Return "valid"
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As MySqlException
            ProgressBar.Value = 50
            Return ex.Message
        Finally
            con.Dispose()
        End Try
    End Function



    'Check connection
    Sub check()
        Try
            con.Open()
            Label2.Text = "Online"
            Label2.ForeColor = Color.LimeGreen
            con.Close()
        Catch ex As Exception
            Label2.Text = "Offline"
            Label2.ForeColor = Color.Red
            MsgBox("Unable to connect server", vbCritical, "No internet")
        Finally
            con.Dispose()
        End Try
    End Sub





    'Key press
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            If IsNumeric(TextBox1.Text) = False Then
                MsgBox("Register number should be a number", vbInformation, "Information")
                TextBox1.Focus()
            ElseIf TextBox1.Text.Length <> 12 Then
                MsgBox("Register number should be a 12 digit number", vbInformation, "Information")
                TextBox1.Focus()
            Else
                DatePicker.Focus()
            End If
        End If
    End Sub
    Private Sub DatePicker1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DatePicker.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1.PerformClick()
        End If
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox4.Focus()
        End If
    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If e.KeyChar = Chr(13) Then
            Button2.PerformClick()
        End If
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar = Chr(13) Then
            Button3.PerformClick()
        End If
    End Sub
    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox8.Focus()
        End If
    End Sub
    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If e.KeyChar = Chr(13) Then
            Button4.PerformClick()
        End If
    End Sub


End Class
