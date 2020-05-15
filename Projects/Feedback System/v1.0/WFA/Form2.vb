Imports MySql.Data.MySqlClient



'Feedback form
Public Class Form2
    Dim con As New MySqlConnection(My.Settings.Connection)
    Dim reader As MySqlDataReader
    Dim cmd As MySqlCommand
    Dim query As String
    Dim year, sem, branch, regno, staffname, dept As String
    Dim sub1, sub2, sub3, sub4, sub5, sub6, sub7, sub8, sub9, sub10 As String
    Dim s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 As Integer
    Dim v1, v2, v3, v4, v5, v6, v7, v8 As Integer
    Dim c1, c2, c3, c4, c5, c6, c7, c8 As Integer
    Dim t, v, p, total As Long
    Dim status As Integer
    Dim id As String
    Dim s As String



    'On load
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            ProgressBar.Value = 40
            cmd = New MySqlCommand("select * from student where regno='" & Form1.TextBox1.Text & "'", con)
            reader = cmd.ExecuteReader()
            reader.Read()

            ProgressBar.Value = 50
            regno = reader.Item(0).ToString
            year = reader.Item(2).ToString
            sem = reader.Item(3).ToString
            branch = reader.Item(4).ToString
            s1 = reader.Item(5)
            s2 = reader.Item(6)
            s3 = reader.Item(7)
            s4 = reader.Item(8)
            s5 = reader.Item(9)
            s6 = reader.Item(10)
            s7 = reader.Item(11)
            s8 = reader.Item(12)
            s9 = reader.Item(13)
            s10 = reader.Item(14)

            reader.Close()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            Label4.Text = year
            Label6.Text = sem
            Label8.Text = branch
            Label15.Text = regno

            Panel1.Visible = True

            ComboBox0.Focus()

            ProgressBar.Value = 60
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            ProgressBar.Value = 70
            cmd = New MySqlCommand("select * from advisor where year='" & year & "' and semester='" & sem & "' and branch='" & branch & "'", con)
            reader = cmd.ExecuteReader()
            reader.Read()

            ProgressBar.Value = 80
            sub1 = reader.Item(6).ToString
            sub2 = reader.Item(7).ToString
            sub3 = reader.Item(8).ToString
            sub4 = reader.Item(9).ToString
            sub5 = reader.Item(10).ToString
            sub6 = reader.Item(11).ToString
            sub7 = reader.Item(12).ToString
            sub8 = reader.Item(13).ToString
            sub9 = reader.Item(14).ToString
            sub10 = reader.Item(15).ToString

            reader.Close()

            Panel2.Visible = True

            ProgressBar.Value = 90
            If s1 = 0 Then
                If sub1 <> "" Or IsNothing(sub1) = False Then
                    ComboBox0.Items.Add(sub1)
                End If
            End If
            If s2 = 0 Then
                If sub2 <> "" Then
                    ComboBox0.Items.Add(sub2)
                End If
            End If
            If s3 = 0 Then
                If sub3 <> "" Then
                    ComboBox0.Items.Add(sub3)
                End If
            End If
            If s4 = 0 Then
                If sub4 <> "" Then
                    ComboBox0.Items.Add(sub4)
                End If
            End If
            If s5 = 0 Then
                If sub5 <> "" Then
                    ComboBox0.Items.Add(sub5)
                End If
            End If
            If s6 = 0 Then
                If sub6 <> "" Then
                    ComboBox0.Items.Add(sub6)
                End If
            End If
            If s7 = 0 Then
                If sub7 <> "" Then
                    ComboBox0.Items.Add(sub7)
                End If
            End If
            If s8 = 0 Then
                If sub8 <> "" Then
                    ComboBox0.Items.Add(sub8)
                End If
            End If
            If s9 = 0 Then
                If sub9 <> "" Then
                    ComboBox0.Items.Add(sub9)
                End If
            End If
            If s10 = 0 Then
                If sub10 <> "" Then
                    ComboBox0.Items.Add(sub10)
                End If
            End If

            If ComboBox0.Items.Count > 0 Then
                ComboBox0.SelectedIndex = 0
            End If

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            For i = 10 To 0 Step -1
                ComboBox1.Items.Add(i)
            Next i
            For i = 10 To 0 Step -1
                ComboBox2.Items.Add(i)
            Next i
            For i = 10 To 0 Step -1
                ComboBox3.Items.Add(i)
            Next i
            For i = 10 To 0 Step -1
                ComboBox4.Items.Add(i)
            Next i
            For i = 10 To 0 Step -1
                ComboBox5.Items.Add(i)
            Next i
            For i = 10 To 0 Step -1
                ComboBox6.Items.Add(i)
            Next i
            For i = 10 To 0 Step -1
                ComboBox7.Items.Add(i)
            Next i
            For i = 30 To 0 Step -1
                ComboBox8.Items.Add(i)
            Next i

            ProgressBar.Value = 100
            ProgressBar.Visible = False

            Button4.Visible = True
        Catch ex As MySqlException
            If ex.Message = "Unable to connect to any of the specified MySQL hosts." Then
                MsgBox("Connection lost", vbCritical, "No internet")
            Else
                MsgBox(ex.Message, vbCritical, "Error")
            End If
            ProgressBar.Visible = False
            Button4.Visible = True
        Finally
            con.Dispose()
        End Try
    End Sub



    'Submit subject button click
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button4.Visible = False
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If ComboBox0.Text = "" Then
            MsgBox("Please select subject", vbInformation, "Information")
            ProgressBar.Visible = False
            Button4.Visible = True
            ComboBox0.Focus()
        Else
            Button1.Visible = False
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                ProgressBar.Value = 50
                cmd = New MySqlCommand("select * from staff where hsub='" & ComboBox0.Text & "' and hsem='" & sem & "' and hbrc='" & branch & "'", con)
                reader = cmd.ExecuteReader()
                reader.Read()

                staffname = reader.Item(0).ToString
                dept = reader.Item(1).ToString
                v1 = reader.Item(5)
                v2 = reader.Item(6)
                v3 = reader.Item(7)
                v4 = reader.Item(8)
                v5 = reader.Item(9)
                v6 = reader.Item(10)
                v7 = reader.Item(11)
                v8 = reader.Item(12)
                t = reader.Item(13)
                v = reader.Item(14)
                p = reader.Item(15)

                reader.Close()

                ProgressBar.Value = 75
                GroupBox1.Visible = True
                GroupBox2.Visible = True
                GroupBox3.Visible = True

                Label10.Visible = True
                Label11.Visible = True
                Label11.Text = dept
                Label12.Visible = True
                Label13.Visible = True
                Label13.Text = staffname

                ComboBox1.SelectedIndex = 0
                ComboBox2.SelectedIndex = 0
                ComboBox3.SelectedIndex = 0
                ComboBox4.SelectedIndex = 0
                ComboBox5.SelectedIndex = 0
                ComboBox6.SelectedIndex = 0
                ComboBox7.SelectedIndex = 0
                ComboBox8.SelectedIndex = 0

                ProgressBar.Value = 100
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

                ProgressBar.Visible = False
                Button2.Visible = True
                Button3.Visible = True
            Catch ex As MySqlException
                If ex.Message = "Unable to connect to any of the specified MySQL hosts." Then
                    MsgBox("Connection lost", vbCritical, "No internet")
                ElseIf ex.Message = "Invalid attempt to access a field before calling Read()" Then
                    MsgBox("Please contact your class advisor", vbCritical, "Subject not found")
                Else
                    MsgBox(ex.Message, vbCritical, "Error")
                End If
                ProgressBar.Visible = False
                Button4.Visible = True
            Finally
                con.Dispose()
            End Try
        End If
    End Sub



    'Submit score button click
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If ComboBox1.Text = "" Then
            MsgBox("Value 1 is empty", vbExclamation, "Invalid")
            ProgressBar.Visible = False
            ComboBox1.Focus()
        ElseIf ComboBox2.Text = "" Then
            MsgBox("Value 2 is empty", vbExclamation, "Invalid")
            ProgressBar.Visible = False
            ComboBox2.Focus()
        ElseIf ComboBox3.Text = "" Then
            MsgBox("Value 3 is empty", vbExclamation, "Invalid")
            ProgressBar.Visible = False
            ComboBox3.Focus()
        ElseIf ComboBox4.Text = "" Then
            MsgBox("Value 4 is empty", vbExclamation, "Invalid")
            ProgressBar.Visible = False
            ComboBox4.Focus()
        ElseIf ComboBox5.Text = "" Then
            MsgBox("Value 5 is empty", vbExclamation, "Invalid")
            ProgressBar.Visible = False
            ComboBox5.Focus()
        ElseIf ComboBox6.Text = "" Then
            MsgBox("Value 6 is empty", vbExclamation, "Invalid")
            ProgressBar.Visible = False
            ComboBox6.Focus()
        ElseIf ComboBox7.Text = "" Then
            MsgBox("Value 7 is empty", vbExclamation, "Invalid")
            ProgressBar.Visible = False
            ComboBox7.Focus()
        ElseIf ComboBox8.Text = "" Then
            MsgBox("Value 8 is empty", vbExclamation, "Invalid")
            ProgressBar.Visible = False
            ComboBox8.Focus()
        Else
            c1 = ComboBox1.Text
            c2 = ComboBox2.Text
            c3 = ComboBox3.Text
            c4 = ComboBox4.Text
            c5 = ComboBox5.Text
            c6 = ComboBox6.Text
            c7 = ComboBox7.Text
            c8 = ComboBox8.Text
            total = c1 + c2 + c3 + c4 + c5 + c6 + c7 + c8

            t = t + total
            v = v + 1

            If p = 0 Then
                p = t
            Else
                p = t / v
            End If

            If v1 = 0 And v2 = 0 And v3 = 0 And v4 = 0 And v5 = 0 And v6 = 0 And v7 = 0 And v8 = 0 Then
                v1 = c1
                v2 = c2
                v3 = c3
                v4 = c4
                v5 = c5
                v6 = c6
                v7 = c7
                v8 = c8
            Else
                v1 = (v1 + c1) / 2
                v2 = (v2 + c2) / 2
                v3 = (v3 + c3) / 2
                v4 = (v4 + c4) / 2
                v5 = (v5 + c5) / 2
                v6 = (v6 + c6) / 2
                v7 = (v7 + c7) / 2
                v8 = (v8 + c8) / 2
            End If

            Try
                If ComboBox0.Text = sub1 Then
                    id = 1
                End If
                If ComboBox0.Text = sub2 Then
                    id = 2
                End If
                If ComboBox0.Text = sub3 Then
                    id = 3
                End If
                If ComboBox0.Text = sub4 Then
                    id = 4
                End If
                If ComboBox0.Text = sub6 Then
                    id = 5
                End If
                If ComboBox0.Text = sub6 Then
                    id = 6
                End If
                If ComboBox0.Text = sub7 Then
                    id = 7
                End If
                If ComboBox0.Text = sub8 Then
                    id = 8
                End If
                If ComboBox0.Text = sub9 Then
                    id = 9
                End If
                If ComboBox0.Text = sub10 Then
                    id = 10
                End If

                ProgressBar.Value = 30
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                status = 0
                query = "update staff set v1 = '" & v1 & "', v2= '" & v2 & "', v3 ='" & v3 & "',v4 = '" & v4 & "', v5= '" & v5 & "', v6 ='" & v6 & "',v7 = '" & v7 & "', v8= '" & v8 & "', total ='" & t & "', vote= '" & v & "', percent= '" & p & "' where name= '" & staffname & "' and dept='" & dept & "' and hsub='" & ComboBox0.Text & "' and hsem='" & sem & "' and hbrc='" & branch & "'"
                cmd = New MySqlCommand(query, con)
                If cmd.ExecuteNonQuery() = 1 Then
                    status += 1
                End If

                ProgressBar.Value = 50
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                Dim day As DateTime = DateTime.Now
                query = "insert into feedback values('" & day.ToString("yyyy/MM/dd") & "','" & year & "', '" & sem & "', '" & branch & "', '" & Label15.Text & "', '" & staffname & "', '" & dept & "', '" & ComboBox0.Text & "', '" & c1 & "', '" & c2 & "', '" & c3 & "', '" & c4 & "', '" & c5 & "', '" & c6 & "', '" & c7 & "', '" & c8 & "', '" & total & "')"
                cmd = New MySqlCommand(query, con)
                If cmd.ExecuteNonQuery() = 1 Then
                    status += 1
                End If

                ProgressBar.Value = 70
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                query = "update student set s" & id & "='1' where regno='" & regno & "'"
                cmd = New MySqlCommand(query, con)
                If cmd.ExecuteNonQuery() = 1 Then
                    status += 1
                End If

                ProgressBar.Value = 90
                If status = 3 Then
                    ProgressBar.Value = 100
                    MsgBox("Successfully update your feedback", vbInformation, "Successful")
                    ComboBox0.Items.Remove(ComboBox0.SelectedItem)
                Else
                    MsgBox("Update failed", vbCritical, "Failed")
                End If

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

                clr()

                If ComboBox0.Items.Count > 0 Then
                    ComboBox0.SelectedIndex = 0
                    Button1.Visible = True
                End If

                Button2.Visible = False
                Button3.Visible = False
                Button4.Visible = True
                ProgressBar.Visible = False
            Catch ex As MySqlException
                If ex.Message = "Unable to connect to any of the specified MySQL hosts." Then
                    MsgBox("Connection lost", vbCritical, "No internet")
                Else
                    MsgBox(ex.Message, vbCritical, "Error")
                End If
                ProgressBar.Visible = False
                Button2.Visible = False
                Button3.Visible = False
                Button4.Visible = True
            Finally
                con.Dispose()
            End Try
        End If
    End Sub



    'Dropdown closed
    Private Sub ComboBox0_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox0.DropDownClosed
        Button1.Visible = True

        clr()
    End Sub



    'Exit button click
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form1.TextBox1.Text = "7317"
        Form1.DatePicker.Value = "01/01/2000"
        Form1.Show()
        Form1.TextBox1.Focus()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Form1.TextBox1.Text = "7317"
        Form1.DatePicker.Value = "01/01/2000"
        Form1.Show()
        Form1.TextBox1.Focus()
    End Sub



    'Clear function
    Sub clr()
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = False

        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        Label13.Visible = False

        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        ComboBox4.SelectedIndex = 0
        ComboBox5.SelectedIndex = 0
        ComboBox6.SelectedIndex = 0
        ComboBox7.SelectedIndex = 0
        ComboBox8.SelectedIndex = 0

        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = True
    End Sub



    'Key press
    Private Sub ComboBox0_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox0.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox0.Text = "" Then
                MsgBox("Please select subject", vbInformation, "Information")
                ComboBox0.Focus()
            Else
                Button1.Visible = True
                Button1.PerformClick()
            End If
        End If
    End Sub
    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox1.Text = "" Then
                MsgBox("Value 1 is empty", vbExclamation, "Invalid")
                ComboBox1.Focus()
            Else
                ComboBox2.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox2.Text = "" Then
                MsgBox("Value 2 is empty", vbExclamation, "Invalid")
                ComboBox2.Focus()
            Else
                ComboBox3.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox3.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox3.Text = "" Then
                MsgBox("Value 3 is empty", vbExclamation, "Invalid")
                ComboBox3.Focus()
            Else
                ComboBox4.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox4.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox4.Text = "" Then
                MsgBox("Value 4 is empty", vbExclamation, "Invalid")
                ComboBox4.Focus()
            Else
                ComboBox5.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox5.Text = "" Then
                MsgBox("Value 5 is empty", vbExclamation, "Invalid")
                ComboBox5.Focus()
            Else
                ComboBox6.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox6.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox6.Text = "" Then
                MsgBox("Value 6 is empty", vbExclamation, "Invalid")
                ComboBox6.Focus()
            Else
                ComboBox7.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox7.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox7.Text = "" Then
                MsgBox("Value 7 is empty", vbExclamation, "Invalid")
                ComboBox7.Focus()
            Else
                ComboBox8.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox8.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox8.Text = "" Then
                MsgBox("Value 8 is empty", vbExclamation, "Invalid")
                ComboBox8.Focus()
            Else
                Button2.PerformClick()
            End If
        End If
    End Sub



End Class