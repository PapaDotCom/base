Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing



'Department form
Public Class Form4
    Dim con As New MySqlConnection(My.Settings.Connection)
    Dim newpage As Boolean = True
    Dim reader As MySqlDataReader
    Private bitmap As Bitmap
    Dim cmd As MySqlCommand
    Dim query As String
    Dim str As String
    Dim r As Integer
    Dim c As String
    Dim t As String



    'On load
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label6.Text = "Department of " + Form1.TextBox5.Text

        If Form1.TextBox5.Text = "ENG" Or Form1.TextBox5.Text = "CHEM" Or Form1.TextBox5.Text = "MATH" Or Form1.TextBox5.Text = "PHY" Then
            AdvisorToolStripMenuItem.Enabled = False
        End If
    End Sub



    'Advisor menu click
    Private Sub AdvisorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdvisorToolStripMenuItem.Click
        GroupBox2.Visible = False
        GroupBox3.Visible = False
        GroupBox4.Visible = False
        GroupBox5.Visible = False

        ProgressBar.Visible = True
        ProgressBar.Value = 25
        loader("*", "advisor", "where branch='" & Form1.TextBox5.Text & "'")

        GroupBox1.Visible = True

        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("I")
        ComboBox1.Items.Add("II")
        ComboBox1.Items.Add("III")
        ComboBox1.Items.Add("IV")

        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("I")
        ComboBox2.Items.Add("II")
        ComboBox2.Items.Add("III")
        ComboBox2.Items.Add("IV")
        ComboBox2.Items.Add("V")
        ComboBox2.Items.Add("VI")
        ComboBox2.Items.Add("VII")
        ComboBox2.Items.Add("VIII")

        TextBox0.Focus()
    End Sub



    'Add button click (advisor)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox0.Text = "" Then
            MsgBox("Username is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf TextBox1.Text = "" Then
            MsgBox("Password is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf ComboBox1.Text = "" Then
            MsgBox("Year is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf ComboBox2.Text = "" Then
            MsgBox("Semester is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf TextBox2.Text = "" Then
            MsgBox("Register code is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf (ComboBox1.Text = "I" = False) And (ComboBox1.Text = "II" = False) And (ComboBox1.Text = "III" = False) And (ComboBox1.Text = "IV" = False) Then
            MsgBox("Year format is invalid", vbExclamation, "Invalid")
            ProgressBar.Visible = False
        ElseIf (ComboBox2.Text = "I" = False) And (ComboBox2.Text = "II" = False) And (ComboBox2.Text = "III" = False) And (ComboBox2.Text = "IV" = False) And (ComboBox2.Text = "V" = False) And (ComboBox2.Text = "VI" = False) And (ComboBox2.Text = "VII" = False) And (ComboBox2.Text = "VIII" = False) Then
            MsgBox("Semester format is invalid", vbExclamation, "Invalid")
            ProgressBar.Visible = False
        ElseIf IsNumeric(TextBox2.Text) = False Then
            MsgBox("Register code should be a number", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf TextBox2.Text.Length <> 9 Then
            MsgBox("Register code should be a 9 digit number", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            query = "insert into advisor values('" & TextBox0.Text & "', '" & TextBox1.Text & "', '" & ComboBox1.Text & "', '" & ComboBox2.Text & "', '" & Form1.TextBox5.Text & "', '" & TextBox2.Text & "', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)"
            str = exe(query)
            If str = "valid" Then
                MsgBox("Record added successfully", vbInformation, "Successful")
                ProgressBar.Visible = False
                loader("*", "advisor", "where branch='" & Form1.TextBox5.Text & "'")
            ElseIf str = "invalid" Then
                MsgBox("Record add failed", vbCritical, "Failed")
                ProgressBar.Visible = False
                clr()
            ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                MsgBox("Connection lost", vbCritical, "No internet")
                ProgressBar.Visible = False
                clr()
            Else
                MsgBox(str, vbCritical, "Error")
                ProgressBar.Visible = False
                clr()
            End If
        End If
    End Sub



    'Update button click (advisor)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox0.Text = "" Then
            MsgBox("Username is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf TextBox1.Text = "" Then
            MsgBox("Password is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf ComboBox1.Text = "" Then
            MsgBox("Year is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf ComboBox2.Text = "" Then
            MsgBox("Semester is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf TextBox2.Text = "" Then
            MsgBox("Register code is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf (ComboBox1.Text = "I" = False) And (ComboBox1.Text = "II" = False) And (ComboBox1.Text = "III" = False) And (ComboBox1.Text = "IV" = False) Then
            MsgBox("Year format is invalid", vbExclamation, "Invalid")
            ProgressBar.Visible = False
        ElseIf (ComboBox2.Text = "I" = False) And (ComboBox2.Text = "II" = False) And (ComboBox2.Text = "III" = False) And (ComboBox2.Text = "IV" = False) And (ComboBox2.Text = "V" = False) And (ComboBox2.Text = "VI" = False) And (ComboBox2.Text = "VII" = False) And (ComboBox2.Text = "VIII" = False) Then
            MsgBox("Semester format is invalid", vbExclamation, "Invalid")
            ProgressBar.Visible = False
        ElseIf IsNumeric(TextBox2.Text) = False Then
            MsgBox("Register code should be a number", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf TextBox2.Text.Length <> 9 Then
            MsgBox("Register code should be a 9 digit number", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            query = "update advisor set password = '" & TextBox1.Text & "', year= '" & ComboBox1.Text & "', semester ='" & ComboBox2.Text & "',regcode = '" & TextBox2.Text & "' where username= '" & TextBox0.Text & "'"
            str = exe(query)
            If str = "valid" Then
                MsgBox("Record updated successfully", vbInformation, "Successful")
                ProgressBar.Visible = False
                loader("*", "advisor", "where branch='" & Form1.TextBox5.Text & "'")
            ElseIf str = "invalid" Then
                MsgBox("Record update failed", vbCritical, "Failed")
                ProgressBar.Visible = False
                clr()
            ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                MsgBox("Connection lost", vbCritical, "No internet")
                ProgressBar.Visible = False
                clr()
            Else
                MsgBox(str, vbCritical, "Error")
                ProgressBar.Visible = False
                clr()
            End If
        End If
    End Sub



    'Remove button click (advisor)
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        Dim ans As String
        ans = MsgBox("Confirm to delete user" + vbCrLf + TextBox0.Text, vbExclamation + vbYesNo, "Confirm")
        If ans = vbYes Then
            query = "delete from advisor where username='" & TextBox0.Text & "'"
            str = exe(query)
            If str = "valid" Then
                MsgBox("Record removed successfully", vbInformation, "Successful")
                ProgressBar.Visible = False
                loader("*", "advisor", "where branch='" & Form1.TextBox5.Text & "'")
            ElseIf str = "invalid" Then
                MsgBox("Record remove failed", vbCritical, "Failed")
                ProgressBar.Visible = False
                clr()
            ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                MsgBox("Connection lost", vbCritical, "No internet")
                ProgressBar.Visible = False
                clr()
            Else
                MsgBox(str, vbCritical, "Error")
                ProgressBar.Visible = False
                clr()
            End If
        Else
            ProgressBar.Visible = False
            clr()
        End If
    End Sub



    'Search button click (advisor)
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        loader("*", "advisor", " where username='" & TextBox0.Text & "' and branch='" & Form1.TextBox5.Text & "'")
    End Sub



    'Move first button click (advisor)
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        clr()
        With DataGridView1
            If .RowCount > 1 Then
                .ClearSelection()
                .CurrentCell = .Rows(0).Cells(0)
                .Rows(0).Selected = True
                c = .CurrentRow.Index + 1
                t = .RowCount - 1
                TextBox4.Text = c + " of " + t
            End If
        End With
    End Sub



    'Move previous button click (advisor)
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        clr()
        With DataGridView1
            If .RowCount > 1 Then
                Dim i As Integer = 0
                If .CurrentRow.Index <= .RowCount - 1 Then
                    If .CurrentRow.Index = 0 Then
                        i = .RowCount - 2
                    Else
                        i = .CurrentRow.Index - 1
                    End If
                End If
                .ClearSelection()
                .CurrentCell = .Rows(i).Cells(0)
                .Rows(i).Selected = True
                c = .CurrentRow.Index + 1
                t = .RowCount - 1
                TextBox4.Text = c + " of " + t
            End If
        End With
    End Sub



    'Move next button click (advisor)
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        clr()
        With DataGridView1
            If .RowCount > 1 Then
                Dim i As Integer = 0
                If .CurrentRow.Index < .RowCount - 2 Then
                    i = .CurrentRow.Index + 1
                End If
                .ClearSelection()
                .CurrentCell = .Rows(i).Cells(0)
                .Rows(i).Selected = True
                c = .CurrentRow.Index + 1
                t = .RowCount - 1
                TextBox4.Text = c + " of " + t
            End If
        End With
    End Sub



    'Move last button click (advisor)
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        clr()
        With DataGridView1
            If .RowCount > 1 Then
                .ClearSelection()
                .CurrentCell = .Rows(.RowCount - 1).Cells(0)
                .Rows(.RowCount - 1).Selected = True
                TextBox4.Text = ""
            End If
        End With
    End Sub



    'Refresh button click (advisor)
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        loader("*", "advisor", "where branch='" & Form1.TextBox5.Text & "'")
    End Sub



    'Datagrid cell click (advisor)
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        With DataGridView1
            If e.RowIndex >= 0 Then
                i = .CurrentRow.Index
                If IsNothing(.Rows(i).Cells(0).Value.ToString) Then
                    clr()
                Else
                    TextBox0.Text = .Rows(i).Cells("username").Value.ToString
                    TextBox1.Text = .Rows(i).Cells("password").Value.ToString
                    ComboBox1.Text = .Rows(i).Cells("year").Value.ToString
                    ComboBox2.Text = .Rows(i).Cells("semester").Value.ToString
                    TextBox2.Text = .Rows(i).Cells("regcode").Value.ToString
                End If
                c = .CurrentRow.Index + 1
                t = .RowCount - 1
                If c <= t Then
                    TextBox4.Text = c + " of " + t
                Else
                    TextBox4.Text = ""
                End If
            End If
        End With
    End Sub



    'Staff menu click
    Private Sub StaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffToolStripMenuItem.Click
        GroupBox1.Visible = False
        GroupBox3.Visible = False
        GroupBox4.Visible = False
        GroupBox5.Visible = False

        ProgressBar.Visible = True
        ProgressBar.Value = 25
        loader("name,hsub,hbrc,hsem", "staff", "where dept='" & Form1.TextBox5.Text & "'")

        GroupBox2.Visible = True

        ComboBox3.Items.Clear()
        ComboBox3.Items.Add("CIVIL")
        ComboBox3.Items.Add("CSE")
        ComboBox3.Items.Add("ECE")
        ComboBox3.Items.Add("EEE")
        ComboBox3.Items.Add("IT")
        ComboBox3.Items.Add("MBA")
        ComboBox3.Items.Add("MCA")
        ComboBox3.Items.Add("MECH")

        ComboBox4.Items.Clear()
        ComboBox4.Items.Add("I")
        ComboBox4.Items.Add("II")
        ComboBox4.Items.Add("III")
        ComboBox4.Items.Add("IV")
        ComboBox4.Items.Add("V")
        ComboBox4.Items.Add("VI")
        ComboBox4.Items.Add("VII")
        ComboBox4.Items.Add("VIII")

        Button11.Enabled = False

        TextBox5.Focus()
    End Sub



    'Add button click (staff)
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox5.Text = "" Then
            MsgBox("Name is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf TextBox6.Text = "" Then
            MsgBox("Subject is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf ComboBox3.Text = "" Then
            MsgBox("Branch is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf ComboBox4.Text = "" Then
            MsgBox("Semester is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf (ComboBox3.Text = "CIVIL" = False) And (ComboBox3.Text = "CSE" = False) And (ComboBox3.Text = "ECE" = False) And (ComboBox3.Text = "EEE" = False) And (ComboBox3.Text = "IT" = False) And (ComboBox3.Text = "MBA" = False) And (ComboBox3.Text = "MCA" = False) And (ComboBox3.Text = "MECH" = False) Then
            MsgBox("Branch name is invalid", vbExclamation, "Invalid")
            ProgressBar.Visible = False
        ElseIf (ComboBox4.Text = "I" = False) And (ComboBox4.Text = "II" = False) And (ComboBox4.Text = "III" = False) And (ComboBox4.Text = "IV" = False) And (ComboBox4.Text = "V" = False) And (ComboBox4.Text = "VI" = False) And (ComboBox4.Text = "VII" = False) And (ComboBox4.Text = "VIII" = False) Then
            MsgBox("Semester format is invalid", vbExclamation, "Invalid")
            ProgressBar.Visible = False
        Else
            query = "select * from staff where name= '" & TextBox5.Text & "' and hsub='" & TextBox6.Text & "'and hbrc= '" & ComboBox3.Text & "'and hsem ='" & ComboBox4.Text & "'"
            cmd = New MySqlCommand(query, con)
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                ProgressBar.Value = 75
                reader = cmd.ExecuteReader
                If reader.HasRows = 0 Then
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    query = "insert into staff values('" & TextBox5.Text & "', '" & Form1.TextBox5.Text & "', '" & ComboBox4.Text & "', '" & ComboBox3.Text & "', '" & TextBox6.Text & "', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0')"
                    str = exe(query)
                    If str = "valid" Then
                        MsgBox("Record added successfully", vbInformation, "Successful")
                        ProgressBar.Visible = False
                        loader("name,hsub,hbrc,hsem", "staff", "where dept='" & Form1.TextBox5.Text & "'")
                    ElseIf str = "invalid" Then
                        MsgBox("Record add failed", vbCritical, "Failed")
                        ProgressBar.Visible = False
                        clr()
                    ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                        MsgBox("Connection lost", vbCritical, "No internet")
                        ProgressBar.Visible = False
                        clr()
                    Else
                        MsgBox(str, vbCritical, "Error")
                        ProgressBar.Visible = False
                        clr()
                    End If
                Else
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    MsgBox("Same record already found", vbExclamation, "Invalid")
                    ProgressBar.Visible = False
                End If
            Catch ex As MySqlException
                If ex.Message = "Unable to connect to any of the specified MySQL hosts." Then
                    MsgBox("Connection lost", vbCritical, "No internet")
                Else
                    MsgBox(ex.Message, vbCritical, "Error")
                End If
                ProgressBar.Visible = False
            Finally
                con.Dispose()
            End Try


        End If
    End Sub



    'Update button click (staff)
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox5.Text = "" Then
            MsgBox("Name is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf TextBox6.Text = "" Then
            MsgBox("Subject is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf ComboBox3.Text = "" Then
            MsgBox("Branch is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf ComboBox4.Text = "" Then
            MsgBox("Semester is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf (ComboBox3.Text = "CIVIL" = False) And (ComboBox3.Text = "CSE" = False) And (ComboBox3.Text = "ECE" = False) And (ComboBox3.Text = "EEE" = False) And (ComboBox3.Text = "IT" = False) And (ComboBox3.Text = "MBA" = False) And (ComboBox3.Text = "MCA" = False) And (ComboBox3.Text = "MECH" = False) Then
            MsgBox("Branch name is invalid", vbExclamation, "Invalid")
            ProgressBar.Visible = False
        ElseIf (ComboBox4.Text = "I" = False) And (ComboBox4.Text = "II" = False) And (ComboBox4.Text = "III" = False) And (ComboBox4.Text = "IV" = False) And (ComboBox4.Text = "V" = False) And (ComboBox4.Text = "VI" = False) And (ComboBox4.Text = "VII" = False) And (ComboBox4.Text = "VIII" = False) Then
            MsgBox("Semester format is invalid", vbExclamation, "Invalid")
            ProgressBar.Visible = False
        Else
            query = ""
            str = exe(query)
            If str = "valid" Then
                MsgBox("Record updated successfully", vbInformation, "Successful")
                ProgressBar.Visible = False
                loader("name,hsub,hbrc,hsem", "staff", "where dept='" & Form1.TextBox5.Text & "'")
            ElseIf str = "invalid" Then
                MsgBox("Record update failed", vbCritical, "Failed")
                ProgressBar.Visible = False
                clr()
            ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                MsgBox("Connection lost", vbCritical, "No internet")
                ProgressBar.Visible = False
                clr()
            Else
                MsgBox(str, vbCritical, "Error")
                ProgressBar.Visible = False
                clr()
            End If
        End If
    End Sub



    'Remove button click (staff)
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        Dim ans As String
        ans = MsgBox("Confirm to delete staff" + vbCrLf + TextBox5.Text, vbExclamation + vbYesNo, "Confirm")
        If ans = vbYes Then
            query = "delete from staff where name='" & TextBox5.Text & "' and hsub='" & TextBox6.Text & "' and hbrc= '" & ComboBox3.Text & "'and hsem ='" & ComboBox4.Text & "'"
            str = exe(query)
            If str = "valid" Then
                MsgBox("Record removed successfully", vbInformation, "Successful")
                ProgressBar.Visible = False
                loader("name,hsub,hbrc,hsem", "staff", "where dept='" & Form1.TextBox5.Text & "'")
            ElseIf str = "invalid" Then
                MsgBox("Record remove failed", vbCritical, "Failed")
                ProgressBar.Visible = False
                clr()
            ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                MsgBox("Connection lost", vbCritical, "No internet")
                ProgressBar.Visible = False
                clr()
            Else
                MsgBox(str, vbCritical, "Error")
                ProgressBar.Visible = False
                clr()
            End If
        Else
            ProgressBar.Visible = False
            clr()
        End If
    End Sub



    'Search button click (staff)
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        loader("*", "staff", " where name='" & TextBox7.Text & "' and dept='" & Form1.TextBox5.Text & "'")
    End Sub



    'Move first button click (staff)
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        clr()
        With DataGridView2
            If .RowCount > 1 Then
                .ClearSelection()
                .CurrentCell = .Rows(0).Cells(0)
                .Rows(0).Selected = True
                c = .CurrentRow.Index + 1
                t = .RowCount - 1
                TextBox8.Text = c + " of " + t
            End If
        End With
    End Sub



    'Move previous button click (staff)
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        With DataGridView2
            If .RowCount > 1 Then
                Dim i As Integer = 0
                If .CurrentRow.Index <= .RowCount - 1 Then
                    If .CurrentRow.Index = 0 Then
                        i = .RowCount - 2
                    Else
                        i = .CurrentRow.Index - 1
                    End If
                End If
                .ClearSelection()
                .CurrentCell = .Rows(i).Cells(0)
                .Rows(i).Selected = True
                c = .CurrentRow.Index + 1
                t = .RowCount - 1
                TextBox8.Text = c + " of " + t
            End If
        End With
    End Sub



    'Move next button click (staff)
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        clr()
        With DataGridView2
            If .RowCount > 1 Then
                Dim i As Integer = 0
                If .CurrentRow.Index < .RowCount - 2 Then
                    i = .CurrentRow.Index + 1
                End If
                .ClearSelection()
                .CurrentCell = .Rows(i).Cells(0)
                .Rows(i).Selected = True
                c = .CurrentRow.Index + 1
                t = .RowCount - 1
                TextBox8.Text = c + " of " + t
            End If
        End With
    End Sub



    'Move last button click (staff)
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        With DataGridView2
            If .RowCount > 1 Then
                .ClearSelection()
                .CurrentCell = .Rows(.RowCount - 1).Cells(0)
                .Rows(.RowCount - 1).Selected = True
                TextBox8.Text = ""
            End If
        End With
    End Sub



    'Refresh button click (staff)
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        loader("name,hsub,hbrc,hsem", "staff", "where dept='" & Form1.TextBox5.Text & "'")
    End Sub



    'Datagrid cell click (staff)
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Dim i As Integer
        With DataGridView2
            If e.RowIndex >= 0 Then
                i = .CurrentRow.Index
                If IsNothing(.Rows(i).Cells(0).Value.ToString) Then
                    clr()
                Else
                    TextBox5.Text = .Rows(i).Cells("name").Value.ToString
                    TextBox6.Text = .Rows(i).Cells("hsub").Value.ToString
                    ComboBox3.Text = .Rows(i).Cells("hbrc").Value.ToString
                    ComboBox4.Text = .Rows(i).Cells("hsem").Value.ToString
                End If
                c = .CurrentRow.Index + 1
                t = .RowCount - 1
                If c <= t Then
                    TextBox8.Text = c + " of " + t
                Else
                    TextBox8.Text = ""
                End If
            End If
        End With
    End Sub



    'Change password menu click
    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = False
        GroupBox4.Visible = False
        GroupBox5.Visible = True

        TextBox9.Focus()
    End Sub



    'Change password button click 
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If TextBox9.Text = "" Then
            MsgBox("Old password is empty", vbInformation, "Information")
            TextBox9.Focus()
        ElseIf TextBox10.Text = "" Then
            MsgBox("New password is empty", vbInformation, "Information")
            TextBox10.Focus()
        Else
            Try
                ProgressBar.Visible = True
                con.Open()
                ProgressBar.Value = 25
                query = "select * from account where username='" & Form1.TextBox5.Text & "' and password='" & TextBox9.Text & "' "
                ProgressBar.Value = 50
                cmd = New MySqlCommand(query, con)
                reader = cmd.ExecuteReader
                ProgressBar.Value = 75
                If reader.HasRows = 0 Then
                    con.Close()
                    MsgBox("Old password is wrong", vbCritical, "Try again")
                    TextBox9.Text = ""
                    TextBox10.Text = ""
                    TextBox9.Focus()
                    ProgressBar.Visible = False
                Else
                    ProgressBar.Value = 85
                    con.Close()
                    query = "update account set password = '" & TextBox10.Text & "' where username= '" & Form1.TextBox5.Text & "'"
                    str = exe(query)
                    If str = "valid" Then
                        MsgBox("Password changed successfully", vbInformation, "Successful")
                        ProgressBar.Visible = False
                    ElseIf str = "invalid" Then
                        MsgBox("Password change failed", vbCritical, "Failed")
                        ProgressBar.Visible = False
                    ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                        MsgBox("Connection lost", vbCritical, "No internet")
                        ProgressBar.Visible = False
                    Else
                        MsgBox(str, vbCritical, "Error")
                        ProgressBar.Visible = False
                    End If
                    TextBox9.Text = ""
                    TextBox10.Text = ""
                    TextBox9.Focus()
                End If
                con.Close()
            Catch ex As MySqlException
                If ex.Message = "Unable to connect to any of the specified MySQL hosts." Then
                    MsgBox("Connection lost", vbCritical, "No internet")
                Else
                    MsgBox(ex.Message, vbCritical, "Error")
                End If
                ProgressBar.Visible = False
            Finally
                con.Dispose()
            End Try
        End If
    End Sub



    'Log out menu click
    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Close()
        Form1.TextBox5.Text = ""
        Form1.TextBox6.Text = ""
        Form1.Show()
        Form1.TextBox5.Focus()
    End Sub



    'Student report menu click
    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = True
        GroupBox4.Visible = False
        GroupBox5.Visible = False

        ComboBox5.Items.Clear()
        ComboBox5.Items.Add("I")
        ComboBox5.Items.Add("II")
        ComboBox5.Items.Add("III")
        ComboBox5.Items.Add("IV")

        ComboBox6.Items.Clear()
        ComboBox6.Items.Add("I")
        ComboBox6.Items.Add("II")
        ComboBox6.Items.Add("III")
        ComboBox6.Items.Add("IV")
        ComboBox6.Items.Add("V")
        ComboBox6.Items.Add("VI")
        ComboBox6.Items.Add("VII")
        ComboBox6.Items.Add("VIII")

        ComboBox7.Items.Clear()
        ComboBox7.Items.Add("I")
        ComboBox7.Items.Add("II")
        ComboBox7.Items.Add("III")
        ComboBox7.Items.Add("IV")
        ComboBox7.Items.Add("V")
        ComboBox7.Items.Add("VI")
        ComboBox7.Items.Add("VII")
        ComboBox7.Items.Add("VIII")

        DataGridView3.DataSource = Nothing
        DataGridView3.Visible = False
        Button24.Visible = False
        Button25.Visible = False
        TextBox13.Visible = False
    End Sub



    'Submit button click (year,semester) (student)
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If ComboBox5.Text = "" Then
            MsgBox("Please select year", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf ComboBox6.Text = "" Then
            MsgBox("Please select semester", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            loader("*", "feedback", " where year='" & ComboBox5.Text & "' and semester='" & ComboBox6.Text & "' and branch='" & Form1.TextBox5.Text & "'")
            DataGridView3.Visible = True
            TextBox13.Visible = True
            Button24.Visible = True
            Button25.Visible = True
            If DataGridView3.RowCount > 1 Then
                t = DataGridView3.RowCount - 1
                TextBox13.Text = " " + t + " records found"
            Else
                TextBox13.Text = " No record found"
            End If
        End If
    End Sub



    'Submit button click (name,semester) (student)
    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox11.Text = "" Then
            MsgBox("Please enter staff name", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf ComboBox7.Text = "" Then
            MsgBox("Please select semester", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            loader("*", "feedback", " where name='" & TextBox11.Text & "' and semester='" & ComboBox7.Text & "' and dept='" & Form1.TextBox5.Text & "'")
            DataGridView3.Visible = True
            TextBox13.Visible = True
            Button24.Visible = True
            Button25.Visible = True
            If DataGridView3.RowCount > 1 Then
                t = DataGridView3.RowCount - 1
                TextBox13.Text = " " + t + " records found"
            Else
                TextBox13.Text = " No record found"
            End If
        End If
    End Sub



    'Submit button click (subject) (student)
    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox12.Text = "" Then
            MsgBox("Please enter subject name", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            loader("*", "feedback", " where sub='" & TextBox12.Text & "' and branch='" & Form1.TextBox5.Text & "'")
            DataGridView3.Visible = True
            TextBox13.Visible = True
            Button24.Visible = True
            Button25.Visible = True
            If DataGridView3.RowCount > 1 Then
                t = DataGridView3.RowCount - 1
                TextBox13.Text = " " + t + " records found"
            Else
                TextBox13.Text = " No record found"
            End If
        End If
    End Sub



    'View all button click (student)
    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        loader("*", "feedback", " where branch='" & Form1.TextBox5.Text & "'")
        DataGridView3.Visible = True
        TextBox13.Visible = True
        Button24.Visible = True
        Button25.Visible = True
        If DataGridView3.RowCount > 1 Then
            t = DataGridView3.RowCount - 1
            TextBox13.Text = " " + t + " records found"
        Else
            TextBox13.Text = " No record found"
        End If
    End Sub



    'Print button click (student)
    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Printer.DefaultPageSettings.Margins = New Margins(5, 5, 50, 20)
        Previewer.WindowState = FormWindowState.Maximized
        Previewer.ShowDialog()
    End Sub



    'Back button click (student)
    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        DataGridView3.Visible = False
        TextBox13.Visible = False
        Button24.Visible = False
        Button25.Visible = False

        ComboBox5.SelectedIndex = -1
        ComboBox6.SelectedIndex = -1
        ComboBox7.SelectedIndex = -1
        TextBox11.Text = ""
        TextBox12.Text = ""

        DataGridView3.DataSource = Nothing
        DataGridView3.Refresh()
    End Sub




    'Staff report menu click
    Private Sub StaffToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StaffToolStripMenuItem1.Click
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = False
        GroupBox4.Visible = True
        GroupBox5.Visible = False

        ComboBox8.Items.Clear()
        ComboBox8.Items.Add("I")
        ComboBox8.Items.Add("II")
        ComboBox8.Items.Add("III")
        ComboBox8.Items.Add("IV")

        ComboBox9.Items.Clear()
        ComboBox9.Items.Add("I")
        ComboBox9.Items.Add("II")
        ComboBox9.Items.Add("III")
        ComboBox9.Items.Add("IV")
        ComboBox9.Items.Add("V")
        ComboBox9.Items.Add("VI")
        ComboBox9.Items.Add("VII")
        ComboBox9.Items.Add("VIII")

        ComboBox10.Items.Clear()
        ComboBox10.Items.Add("I")
        ComboBox10.Items.Add("II")
        ComboBox10.Items.Add("III")
        ComboBox10.Items.Add("IV")
        ComboBox10.Items.Add("V")
        ComboBox10.Items.Add("VI")
        ComboBox10.Items.Add("VII")
        ComboBox10.Items.Add("VIII")

        DataGridView4.DataSource = Nothing
        DataGridView4.Visible = False
        Button30.Visible = False
        Button31.Visible = False
        TextBox16.Visible = False
    End Sub


    'Submit button click (year,semester) (staff)
    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If ComboBox8.Text = "" Then
            MsgBox("Please select year", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf ComboBox8.Text = "" Then
            MsgBox("Please select semester", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            loader("*", "staff", " where hsem='" & ComboBox9.Text & "' and dept='" & Form1.TextBox5.Text & "'")
            DataGridView4.Visible = True
            TextBox16.Visible = True
            Button30.Visible = True
            Button31.Visible = True
            If DataGridView4.RowCount > 1 Then
                t = DataGridView4.RowCount - 1
                TextBox16.Text = " " + t + " records found"
            Else
                TextBox16.Text = " No record found"
            End If
        End If
    End Sub



    'Submit button click (name,semester) (staff)
    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox14.Text = "" Then
            MsgBox("Please enter staff name", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf ComboBox10.Text = "" Then
            MsgBox("Please select semester", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            loader("*", "staff", " where name='" & TextBox14.Text & "' and hsem='" & ComboBox10.Text & "' and dept='" & Form1.TextBox5.Text & "'")
            DataGridView4.Visible = True
            TextBox16.Visible = True
            Button30.Visible = True
            Button31.Visible = True
            If DataGridView4.RowCount > 1 Then
                t = DataGridView4.RowCount - 1
                TextBox16.Text = " " + t + " records found"
            Else
                TextBox16.Text = " No record found"
            End If
        End If
    End Sub



    'Submit button click (subject) (staff)
    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox15.Text = "" Then
            MsgBox("Please enter subject name", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            loader("*", "staff", " where hsub='" & TextBox15.Text & "' and hbrc='" & Form1.TextBox5.Text & "'")
            DataGridView4.Visible = True
            TextBox16.Visible = True
            Button30.Visible = True
            Button31.Visible = True
            If DataGridView4.RowCount > 1 Then
                t = DataGridView4.RowCount - 1
                TextBox16.Text = " " + t + " records found"
            Else
                TextBox16.Text = " No record found"
            End If
        End If
    End Sub



    'View all button click (staff)
    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        loader("*", "staff", " where dept='" & Form1.TextBox5.Text & "'")
        DataGridView4.Visible = True
        TextBox16.Visible = True
        Button30.Visible = True
        Button31.Visible = True
        If DataGridView4.RowCount > 1 Then
            t = DataGridView4.RowCount - 1
            TextBox16.Text = " " + t + " records found"
        Else
            TextBox16.Text = " No record found"
        End If
    End Sub



    'Print button click (staff)
    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        Printer.DefaultPageSettings.Margins = New Margins(5, 5, 50, 20)
        Previewer.WindowState = FormWindowState.Maximized
        Previewer.ShowDialog()
    End Sub



    'Back button click (staff)
    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        DataGridView4.Visible = False
        TextBox16.Visible = False
        Button30.Visible = False
        Button31.Visible = False

        ComboBox8.SelectedIndex = -1
        ComboBox9.SelectedIndex = -1
        ComboBox10.SelectedIndex = -1
        TextBox14.Text = ""
        TextBox15.Text = ""

        DataGridView4.DataSource = Nothing
        DataGridView4.Refresh()
    End Sub



    'Execute query functions
    Function exe(ByVal query As String) As String
        cmd = New MySqlCommand(query, con)
        ProgressBar.Value = 50
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            ProgressBar.Value = 75
            If cmd.ExecuteNonQuery() = 1 Then
                ProgressBar.Value = 100
                Return "valid"
            Else
                ProgressBar.Value = 75
                Return "invalid"
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



    'Begin print
    Private Sub Printer_BeginPrint(sender As Object, e As PrintEventArgs) Handles Printer.BeginPrint
        r = 0
        newpage = True
        Previewer.PrintPreviewControl.Zoom = 1.0
        Previewer.PrintPreviewControl.StartPage = 0
    End Sub



    'Print page
    Private Sub Printer_PrintPage(sender As Object, e As PrintPageEventArgs) Handles Printer.PrintPage
        Try
            If DataGridView3.Visible = True Then
                With DataGridView3
                    Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
                    fmt.LineAlignment = StringAlignment.Center
                    fmt.Trimming = StringTrimming.Word
                    Dim y As Int32 = e.MarginBounds.Top
                    Dim rc As Rectangle
                    Dim x As Int32
                    Dim h As Int32 = 0
                    Dim row As DataGridViewRow

                    e.Graphics.DrawString("MPNMJEC Feedback System Reports", .Font, Brushes.Black, 2, 15, New StringFormat())
                    e.Graphics.DrawString("Department of " + Form1.TextBox5.Text, .Font, Brushes.Black, 648, 15, New StringFormat())
                    If newpage Then
                        row = .Rows(r)
                        x = e.MarginBounds.Left
                        For Each cell As DataGridViewCell In row.Cells
                            If cell.Visible Then
                                rc = New Rectangle(x, y, cell.Size.Width, cell.Size.Height)

                                e.Graphics.FillRectangle(Brushes.LightGray, rc)
                                e.Graphics.DrawRectangle(Pens.Black, rc)

                                Select Case .Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                                    Case DataGridViewContentAlignment.BottomRight, DataGridViewContentAlignment.MiddleRight
                                        fmt.Alignment = StringAlignment.Far
                                        rc.Offset(-1, 0)
                                    Case DataGridViewContentAlignment.BottomCenter, DataGridViewContentAlignment.MiddleCenter
                                        fmt.Alignment = StringAlignment.Center
                                    Case Else
                                        fmt.Alignment = StringAlignment.Near
                                        rc.Offset(2, 0)
                                End Select

                                e.Graphics.DrawString(.Columns(cell.ColumnIndex).HeaderText, .Font, Brushes.Black, rc, fmt)
                                x += rc.Width
                                h = Math.Max(h, rc.Height)
                            End If
                        Next
                        y += h

                    End If
                    newpage = False

                    Dim ndx As Int32
                    For ndx = r To .RowCount - 1
                        If .Rows(ndx).IsNewRow Then Exit For

                        row = .Rows(ndx)
                        x = e.MarginBounds.Left
                        h = 0

                        x = e.MarginBounds.Left

                        For Each cell As DataGridViewCell In row.Cells
                            If cell.Visible Then
                                rc = New Rectangle(x, y, cell.Size.Width, cell.Size.Height)

                                e.Graphics.DrawRectangle(Pens.Black, rc)

                                Select Case .Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                                    Case DataGridViewContentAlignment.BottomRight, DataGridViewContentAlignment.MiddleRight
                                        fmt.Alignment = StringAlignment.Far
                                        rc.Offset(-1, 0)
                                    Case DataGridViewContentAlignment.BottomCenter, DataGridViewContentAlignment.MiddleCenter
                                        fmt.Alignment = StringAlignment.Center
                                    Case Else
                                        fmt.Alignment = StringAlignment.Near
                                        rc.Offset(2, 0)
                                End Select

                                e.Graphics.DrawString(cell.FormattedValue.ToString(), .Font, Brushes.Black, rc, fmt)

                                x += rc.Width
                                h = Math.Max(h, rc.Height)
                            End If

                        Next
                        y += h
                        r = ndx + 1

                        If y + h > e.MarginBounds.Bottom Then
                            e.HasMorePages = True
                            newpage = True
                            Return
                        End If
                    Next
                End With
            Else
                With DataGridView4
                    Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
                    fmt.LineAlignment = StringAlignment.Center
                    fmt.Trimming = StringTrimming.Word
                    Dim y As Int32 = e.MarginBounds.Top
                    Dim rc As Rectangle
                    Dim x As Int32
                    Dim h As Int32 = 0
                    Dim row As DataGridViewRow

                    e.Graphics.DrawString("MPNMJEC Feedback System Reports", .Font, Brushes.Black, 2, 15, New StringFormat())
                    e.Graphics.DrawString("Department of " + Form1.TextBox5.Text, .Font, Brushes.Black, 648, 15, New StringFormat())
                    If newpage Then
                        row = .Rows(r)
                        x = e.MarginBounds.Left
                        For Each cell As DataGridViewCell In row.Cells
                            If cell.Visible Then
                                rc = New Rectangle(x, y, cell.Size.Width, cell.Size.Height)

                                e.Graphics.FillRectangle(Brushes.LightGray, rc)
                                e.Graphics.DrawRectangle(Pens.Black, rc)

                                Select Case .Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                                    Case DataGridViewContentAlignment.BottomRight, DataGridViewContentAlignment.MiddleRight
                                        fmt.Alignment = StringAlignment.Far
                                        rc.Offset(-1, 0)
                                    Case DataGridViewContentAlignment.BottomCenter, DataGridViewContentAlignment.MiddleCenter
                                        fmt.Alignment = StringAlignment.Center
                                    Case Else
                                        fmt.Alignment = StringAlignment.Near
                                        rc.Offset(2, 0)
                                End Select

                                e.Graphics.DrawString(.Columns(cell.ColumnIndex).HeaderText, .Font, Brushes.Black, rc, fmt)
                                x += rc.Width
                                h = Math.Max(h, rc.Height)
                            End If
                        Next
                        y += h

                    End If
                    newpage = False

                    Dim ndx As Int32
                    For ndx = r To .RowCount - 1
                        If .Rows(ndx).IsNewRow Then Exit For

                        row = .Rows(ndx)
                        x = e.MarginBounds.Left
                        h = 0

                        x = e.MarginBounds.Left

                        For Each cell As DataGridViewCell In row.Cells
                            If cell.Visible Then
                                rc = New Rectangle(x, y, cell.Size.Width, cell.Size.Height)

                                e.Graphics.DrawRectangle(Pens.Black, rc)

                                Select Case .Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                                    Case DataGridViewContentAlignment.BottomRight, DataGridViewContentAlignment.MiddleRight
                                        fmt.Alignment = StringAlignment.Far
                                        rc.Offset(-1, 0)
                                    Case DataGridViewContentAlignment.BottomCenter, DataGridViewContentAlignment.MiddleCenter
                                        fmt.Alignment = StringAlignment.Center
                                    Case Else
                                        fmt.Alignment = StringAlignment.Near
                                        rc.Offset(2, 0)
                                End Select

                                e.Graphics.DrawString(cell.FormattedValue.ToString(), .Font, Brushes.Black, rc, fmt)

                                x += rc.Width
                                h = Math.Max(h, rc.Height)
                            End If

                        Next
                        y += h
                        r = ndx + 1

                        If y + h > e.MarginBounds.Bottom Then
                            e.HasMorePages = True
                            newpage = True
                            Return
                        End If
                    Next
                End With
            End If
        Catch
            MsgBox("Unable to print", vbCritical, "Error")
        End Try
    End Sub



    'Execute select query function
    Sub loader(ByVal slt As String, tab As String, ext As String)
        ProgressBar.Value = 50
        query = "select " + slt + " from " + tab + " " + ext + ""
        Dim da As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            ProgressBar.Value = 75
            da.Fill(ds, tab)
            ProgressBar.Value = 100
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If tab = "advisor" Then
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = tab
                DataGridView1.Columns(0).HeaderText = "Username"
                DataGridView1.Columns(1).HeaderText = "Password"
                DataGridView1.Columns(2).Width = 75
                DataGridView1.Columns(2).HeaderText = "Year"
                DataGridView1.Columns(2).Width = 45
                DataGridView1.Columns(3).HeaderText = "Semester"
                DataGridView1.Columns(3).Width = 80
                DataGridView1.Columns(4).HeaderText = "Branch"
                DataGridView1.Columns(4).Width = 65
                DataGridView1.Columns(5).HeaderText = "Reg code"
                DataGridView1.Columns(5).Width = 125
                DataGridView1.Columns(6).HeaderText = "Subject 1"
                DataGridView1.Columns(7).HeaderText = "Subject 2"
                DataGridView1.Columns(8).HeaderText = "Subject 3"
                DataGridView1.Columns(9).HeaderText = "Subject 4"
                DataGridView1.Columns(10).HeaderText = "Subject 5"
                DataGridView1.Columns(11).HeaderText = "Subject 6"
                DataGridView1.Columns(12).HeaderText = "Subject 7"
                DataGridView1.Columns(13).HeaderText = "Subject 8"
                DataGridView1.Columns(14).HeaderText = "Subject 9"
                DataGridView1.Columns(15).HeaderText = "Subject 10"
                ProgressBar.Visible = False
            ElseIf tab = "staff" Then
                If GroupBox4.Visible = False Then
                    DataGridView2.DataSource = ds
                    DataGridView2.DataMember = tab
                    DataGridView2.Columns(0).HeaderText = "Staff name"
                    DataGridView2.Columns(0).Width = 135
                    DataGridView2.Columns(1).HeaderText = "Hendle subject"
                    DataGridView2.Columns(1).Width = 130
                    DataGridView2.Columns(2).HeaderText = "Branch"
                    DataGridView2.Columns(3).HeaderText = "Semester"
                    ProgressBar.Visible = False
                Else
                    DataGridView4.DataSource = ds
                    DataGridView4.DataMember = tab
                    DataGridView4.Columns(0).HeaderText = "Staff name"
                    DataGridView4.Columns(0).Width = 135
                    DataGridView4.Columns(1).HeaderText = "Dept"
                    DataGridView4.Columns(1).Width = 60
                    DataGridView4.Columns(2).HeaderText = "Sem"
                    DataGridView4.Columns(2).Width = 50
                    DataGridView4.Columns(3).HeaderText = "Branch"
                    DataGridView4.Columns(3).Width = 60
                    DataGridView4.Columns(4).HeaderText = "Subject"
                    DataGridView4.Columns(4).Width = 70
                    DataGridView4.Columns(5).HeaderText = "1"
                    DataGridView4.Columns(5).Width = 30
                    DataGridView4.Columns(6).HeaderText = "2"
                    DataGridView4.Columns(6).Width = 30
                    DataGridView4.Columns(7).HeaderText = "3"
                    DataGridView4.Columns(7).Width = 30
                    DataGridView4.Columns(8).HeaderText = "4"
                    DataGridView4.Columns(8).Width = 30
                    DataGridView4.Columns(9).HeaderText = "5"
                    DataGridView4.Columns(9).Width = 30
                    DataGridView4.Columns(10).HeaderText = "6"
                    DataGridView4.Columns(10).Width = 30
                    DataGridView4.Columns(11).HeaderText = "7"
                    DataGridView4.Columns(11).Width = 30
                    DataGridView4.Columns(12).HeaderText = "8"
                    DataGridView4.Columns(12).Width = 35
                    DataGridView4.Columns(13).HeaderText = "Total"
                    DataGridView4.Columns(13).Width = 70
                    DataGridView4.Columns(14).HeaderText = "Vote"
                    DataGridView4.Columns(14).Width = 45
                    DataGridView4.Columns(15).HeaderText = "%"
                    DataGridView4.Columns(15).Width = 45
                    ProgressBar.Visible = False
                End If
            ElseIf tab = "feedback" Then
                DataGridView3.DataSource = ds
                DataGridView3.DataMember = tab
                DataGridView3.Columns(0).HeaderText = "Entry date"
                DataGridView3.Columns(0).Width = 88
                DataGridView3.Columns(1).HeaderText = "Year"
                DataGridView3.Columns(1).Width = 40
                DataGridView3.Columns(2).HeaderText = "Sem"
                DataGridView3.Columns(2).Width = 40
                DataGridView3.Columns(3).Visible = False
                DataGridView3.Columns(4).HeaderText = "Register no"
                DataGridView3.Columns(4).Width = 115
                DataGridView3.Columns(5).HeaderText = "Staff name"
                DataGridView3.Columns(5).Width = 135
                DataGridView3.Columns(6).HeaderText = "Dept"
                DataGridView3.Columns(6).Width = 50
                DataGridView3.Columns(7).HeaderText = "Subject"
                DataGridView3.Columns(7).Width = 65
                DataGridView3.Columns(8).HeaderText = "1"
                DataGridView3.Columns(8).Width = 25
                DataGridView3.Columns(9).HeaderText = "2"
                DataGridView3.Columns(9).Width = 25
                DataGridView3.Columns(10).HeaderText = "3"
                DataGridView3.Columns(10).Width = 25
                DataGridView3.Columns(11).HeaderText = "4"
                DataGridView3.Columns(11).Width = 25
                DataGridView3.Columns(12).HeaderText = "5"
                DataGridView3.Columns(12).Width = 25
                DataGridView3.Columns(13).HeaderText = "6"
                DataGridView3.Columns(13).Width = 25
                DataGridView3.Columns(14).HeaderText = "7"
                DataGridView3.Columns(14).Width = 25
                DataGridView3.Columns(15).HeaderText = "8"
                DataGridView3.Columns(15).Width = 30
                DataGridView3.Columns(16).HeaderText = "Total"
                DataGridView3.Columns(16).Width = 42
                ProgressBar.Visible = False
            Else
                MsgBox("Error due to load table", vbCritical, "Error")
            End If
            clr()
        Catch ex As MySqlException
            If ex.Message = "Unable to connect to any of the specified MySQL hosts." Then
                MsgBox("Connection lost", vbCritical, "No internet")
            Else
                MsgBox(ex.Message, vbCritical, "Error")
            End If
            ProgressBar.Visible = False
        Finally
            con.Dispose()
        End Try
    End Sub



    'Clear function
    Sub clr()
        TextBox0.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
    End Sub



    'Key press
    Private Sub TextBox0_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox0.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox0.Text = "" Then
                MsgBox("Username is empty", vbInformation, "Information")
                TextBox0.Focus()
            Else
                TextBox1.Focus()
            End If
        End If
    End Sub



    'Key press
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox1.Text = "" Then
                MsgBox("Password is empty", vbInformation, "Information")
                TextBox1.Focus()
            Else
                ComboBox1.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox1.Text = "" Then
                MsgBox("Year is empty", vbInformation, "Information")
                ComboBox1.Focus()
            ElseIf (ComboBox1.Text = "I" = False) And (ComboBox1.Text = "II" = False) And (ComboBox1.Text = "III" = False) And (ComboBox1.Text = "IV" = False) Then
                MsgBox("Year format is invalid", vbExclamation, "Invalid")
                ComboBox1.Focus()
            Else
                ComboBox2.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox2.Text = "" Then
                MsgBox("Semester is empty", vbInformation, "Information")
                ComboBox2.Focus()
            ElseIf (ComboBox2.Text = "I" = False) And (ComboBox2.Text = "II" = False) And (ComboBox2.Text = "III" = False) And (ComboBox2.Text = "IV" = False) And (ComboBox2.Text = "V" = False) And (ComboBox2.Text = "VI" = False) And (ComboBox2.Text = "VII" = False) And (ComboBox2.Text = "VIII" = False) Then
                MsgBox("Semester format is invalid", vbExclamation, "Invalid")
                ComboBox2.Focus()
            Else
                TextBox2.Focus()
            End If
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox2.Text = "" Then
                MsgBox("Register code is empty", vbInformation, "Information")
                TextBox2.Focus()
            ElseIf IsNumeric(TextBox2.Text) = False Then
                MsgBox("Register code should be a number", vbInformation, "Information")
                TextBox2.Focus()
            ElseIf TextBox2.Text.Length <> 9 Then
                MsgBox("Register code should be a 9 digit number", vbInformation, "Information")
                TextBox2.Focus()
            Else
                Button1.Focus()
            End If
        End If
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox5.Text = "" Then
                MsgBox("Name is empty", vbInformation, "Information")
                TextBox5.Focus()
            Else
                TextBox6.Focus()
            End If
        End If
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox6.Text = "" Then
                MsgBox("Subject is empty", vbInformation, "Information")
                TextBox6.Focus()
            Else
                ComboBox3.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox3.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox3.Text = "" Then
                MsgBox("Branch name is empty", vbInformation, "Information")
                ComboBox3.Focus()
            ElseIf (ComboBox3.Text = "CIVIL" = False) And (ComboBox3.Text = "CSE" = False) And (ComboBox3.Text = "ECE" = False) And (ComboBox3.Text = "EEE" = False) And (ComboBox3.Text = "IT" = False) And (ComboBox3.Text = "MBA" = False) And (ComboBox3.Text = "MCA" = False) And (ComboBox3.Text = "MECH" = False) Then
                MsgBox("Branch name is invalid", vbExclamation, "Invalid")
                ComboBox3.Focus()
            Else
                ComboBox4.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox4.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox4.Text = "" Then
                MsgBox("Semester is empty", vbInformation, "Information")
                ComboBox4.Focus()
            ElseIf (ComboBox4.Text = "I" = False) And (ComboBox4.Text = "II" = False) And (ComboBox4.Text = "III" = False) And (ComboBox4.Text = "IV" = False) And (ComboBox4.Text = "V" = False) And (ComboBox4.Text = "VI" = False) And (ComboBox4.Text = "VII" = False) And (ComboBox4.Text = "VIII" = False) Then
                MsgBox("Semester format is invalid", vbExclamation, "Invalid")
                ComboBox4.Focus()
            Else
                Button10.Focus()
            End If
        End If
    End Sub
    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox9.Text = "" Then
                MsgBox("Old password is empty", vbInformation, "Information")
                TextBox9.Focus()
            Else
                TextBox10.Focus()
            End If
        End If
    End Sub
    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox10.Text = "" Then
                MsgBox("New password is empty", vbInformation, "Information")
                TextBox10.Focus()
            Else
                Button19.PerformClick()
            End If
        End If
    End Sub
    Private Sub ComboBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox5.Text = "" Then
                MsgBox("Please select year", vbInformation, "Information")
                ComboBox5.Focus()
            Else
                ComboBox6.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox6.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox6.Text = "" Then
                MsgBox("Please select semester", vbInformation, "Information")
                ComboBox6.Focus()
            Else
                Button20.PerformClick()
            End If
        End If
    End Sub
    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox11.Text = "" Then
                MsgBox("Please enter staff name", vbInformation, "Information")
                TextBox11.Focus()
            Else
                ComboBox7.Focus()
            End If
        End If
    End Sub
    Private Sub ComboBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox7.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox7.Text = "" Then
                MsgBox("Please select semester", vbInformation, "Information")
                ComboBox7.Focus()
            Else
                Button21.PerformClick()
            End If
        End If
    End Sub
    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox12.Text = "" Then
                MsgBox("Please enter subject name", vbInformation, "Information")
                TextBox12.Focus()
            Else
                Button22.PerformClick()
            End If
        End If
    End Sub


End Class
