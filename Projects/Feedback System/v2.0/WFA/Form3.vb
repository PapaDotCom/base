Imports MySql.Data.MySqlClient



'Advisor form
Public Class Form3
    Dim con As New MySqlConnection(My.Settings.Connection)
    Dim reader As MySqlDataReader
    Dim cmd As MySqlCommand
    Dim query As String
    Dim regno As String
    Dim str As String
    Dim c As String
    Dim t As String
    Dim year, sem, branch, regcode As String
    Dim sub1, sub2, sub3, sub4, sub5, sub6, sub7, sub8, sub9, sub10 As String



    'On load
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label6.Text = "Welcome, " + Form1.TextBox3.Text
    End Sub



    'Student menu click 
    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click
        GroupBox2.Visible = False
        GroupBox3.Visible = False

        ProgressBar.Visible = True
        ProgressBar.Value = 25

        loader("*", "advisor", "")
        loader("regno,dob,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10", "student", "where year='" & year & "' and semester='" & sem & "' and branch='" & branch & "'")

        Label18.Text = regcode

        GroupBox1.Visible = True
    End Sub



    'Add button click
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim value As String = DatePicker.Value.ToShortDateString
        Dim dob As DateTime = value
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox1.Text = "" Then
            MsgBox("Register number is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf IsNumeric(TextBox1.Text) = False Then
            MsgBox("Register number should be a number", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf TextBox1.Text.Length <> 3 Then
            MsgBox("Register number should be a 3 digit number", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            regno = regcode + TextBox1.Text
            query = "insert into student values('" & regno & "', '" & dob.ToString("dd/MM/yyyy") & "', '" & year & "', '" & sem & "', '" & branch & "', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0')"
            str = exe(query)
            If str = "valid" Then
                MsgBox("Record added successfully", vbInformation, "Successful")
                ProgressBar.Visible = False
                loader("regno,dob,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10", "student", "where year='" & year & "' and semester='" & sem & "' and branch='" & branch & "'")
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



    'Update button click
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim value As String = DatePicker.Value.ToShortDateString
        Dim dob As DateTime = value
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox1.Text = "" Then
            MsgBox("Register number is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf IsNumeric(TextBox1.Text) = False Then
            MsgBox("Register number should be a number", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf TextBox1.Text.Length <> 3 Then
            MsgBox("Register number should be a 3 digit number", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            regno = regcode + TextBox1.Text
            query = "update student set dob = '" & dob.ToString("dd/MM/yyyy") & "' where regno= '" & regno & "'"
            str = exe(query)
            If str = "valid" Then
                MsgBox("Record updated successfully", vbInformation, "Successful")
                ProgressBar.Visible = False
                loader("regno,dob,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10", "student", "where year='" & year & "' and semester='" & sem & "' and branch='" & branch & "'")
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



    'Remove button click
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        Dim ans As String
        ans = MsgBox("Confirm to delete register number" + vbCrLf + regcode + TextBox1.Text, vbExclamation + vbYesNo, "Confirm")
        If ans = vbYes Then
            regno = regcode + TextBox1.Text
            query = "delete from student where regno='" & regno & "'"
            str = exe(query)
            If str = "valid" Then
                MsgBox("Record removed successfully", vbInformation, "Successful")
                ProgressBar.Visible = False
                loader("regno,dob,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10", "student", "where year='" & year & "' and semester='" & sem & "' and branch='" & branch & "'")
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



    'Search button click
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        loader("regno,dob,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10", "student", " where regno='" & TextBox3.Text & "' and year='" & year & "' and semester='" & sem & "' and branch='" & branch & "'")
    End Sub



    'Move first button click
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



    'Move previous button click
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



    'Move next button click
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



    'Move last button click
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



    'Refresh button click
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        loader("regno,dob,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10", "student", "where year='" & year & "' and semester='" & sem & "' and branch='" & branch & "'")
    End Sub



    'Datagrid cell click
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        With DataGridView1
            If e.RowIndex >= 0 Then
                i = .CurrentRow.Index
                If .Rows(i).Cells("regno").Value.ToString = "" Then
                    TextBox1.Text = ""
                Else
                    Dim reg As String
                    reg = .Rows(i).Cells("regno").Value.ToString
                    TextBox1.Text = reg.Substring(9, 3)
                End If
                If .Rows(i).Cells("dob").Value.ToString = "" Then
                    Dim dob As DateTime = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", Nothing)
                    DatePicker.Value = dob
                Else
                    Dim dob As DateTime = DateTime.ParseExact(.Rows(i).Cells("dob").Value.ToString, "dd/MM/yyyy", Nothing)
                    DatePicker.Value = dob
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




    'Subject menu click
    Private Sub SubjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubjectToolStripMenuItem.Click
        GroupBox1.Visible = False
        GroupBox3.Visible = False

        ProgressBar.Visible = True
        ProgressBar.Value = 25

        loader("*", "advisor", "")
        loader("name,dept,hsub", "staff", "where hsem='" & sem & "' and hbrc='" & branch & "'")

        TextBox5.Text = sub1
        TextBox6.Text = sub2
        TextBox7.Text = sub3
        TextBox8.Text = sub4
        TextBox9.Text = sub5
        TextBox10.Text = sub6
        TextBox11.Text = sub7
        TextBox12.Text = sub8
        TextBox13.Text = sub9
        TextBox14.Text = sub10

        GroupBox2.Visible = True
    End Sub



    'Subject update button click 
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            ProgressBar.Visible = True
            con.Open()
            ProgressBar.Value = 25
            query = "select * from advisor where username='" & Form1.TextBox3.Text & "'"
            ProgressBar.Value = 50
            cmd = New MySqlCommand(query, con)
            reader = cmd.ExecuteReader
            ProgressBar.Value = 75
            If reader.HasRows = 0 Then
                con.Close()
                MsgBox("Can't update", vbCritical, "Error")
                ProgressBar.Visible = False
            Else
                ProgressBar.Value = 85
                con.Close()
                query = "update advisor set sub1= '" & TextBox5.Text & "',sub2= '" & TextBox6.Text & "',sub3= '" & TextBox7.Text & "',sub4= '" & TextBox8.Text & "',sub5= '" & TextBox9.Text & "',sub6= '" & TextBox10.Text & "',sub7= '" & TextBox11.Text & "',sub8= '" & TextBox12.Text & "',sub9= '" & TextBox13.Text & "',sub10= '" & TextBox14.Text & "' where username= '" & Form1.TextBox3.Text & "'"
                str = exe(query)
                If str = "valid" Then
                    ProgressBar.Value = 100
                    MsgBox("Subject updated successfully", vbInformation, "Successful")
                    ProgressBar.Visible = False
                ElseIf str = "invalid" Then
                    MsgBox("Subject update failed", vbCritical, "Failed")
                    ProgressBar.Visible = False
                ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                    MsgBox("Connection lost", vbCritical, "No internet")
                    ProgressBar.Visible = False
                Else
                    MsgBox(str, vbCritical, "Error")
                    ProgressBar.Visible = False
                End If
            End If
            con.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message, vbCritical, "Error")
            ProgressBar.Visible = False
        Finally
            con.Dispose()
        End Try
    End Sub



    'Change password menu click
    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = True

        TextBox15.Focus()
    End Sub



    'Change password button click
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If TextBox15.Text = "" Then
            MsgBox("Old password is empty", vbInformation, "Information")
            TextBox15.Focus()
        ElseIf TextBox16.Text = "" Then
            MsgBox("New password is empty", vbInformation, "Information")
            TextBox16.Focus()
        Else
            Try
                ProgressBar.Visible = True
                con.Open()
                ProgressBar.Value = 25
                query = "select * from advisor where username='" & Form1.TextBox3.Text & "' and password='" & TextBox15.Text & "' "
                ProgressBar.Value = 50
                cmd = New MySqlCommand(query, con)
                reader = cmd.ExecuteReader
                ProgressBar.Value = 75
                If reader.HasRows = 0 Then
                    con.Close()
                    MsgBox("Old password is wrong", vbCritical, "Try again")
                    TextBox15.Text = ""
                    TextBox16.Text = ""
                    TextBox15.Focus()
                    ProgressBar.Visible = False
                Else
                    ProgressBar.Value = 85
                    con.Close()
                    query = "update advisor set password = '" & TextBox16.Text & "' where username= '" & Form1.TextBox3.Text & "'"
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
                    TextBox15.Text = ""
                    TextBox16.Text = ""
                    TextBox15.Focus()
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
        Form1.TextBox3.Text = ""
        Form1.TextBox4.Text = ""
        Form1.Show()
        Form1.TextBox3.Focus()
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



    'Execute select query and load to datagrid function
    Sub loader(ByVal slt As String, tab As String, ext As String)
        ProgressBar.Value = 50
        query = "select " + slt + " from " + tab + " " + ext + ""
        Dim da As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            ProgressBar.Value = 75%
            da.Fill(ds, tab)
            ProgressBar.Value = 100
            If tab = "student" Then
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = tab
                DataGridView1.Columns(0).HeaderText = "Register no"
                DataGridView1.Columns(0).Width = 108
                DataGridView1.Columns(1).HeaderText = "DOB"
                DataGridView1.Columns(1).Width = 82
                DataGridView1.Columns(2).HeaderText = "S1"
                DataGridView1.Columns(2).Width = 28
                DataGridView1.Columns(3).HeaderText = "S2"
                DataGridView1.Columns(3).Width = 28
                DataGridView1.Columns(4).HeaderText = "S3"
                DataGridView1.Columns(4).Width = 28
                DataGridView1.Columns(5).HeaderText = "S4"
                DataGridView1.Columns(5).Width = 28
                DataGridView1.Columns(6).HeaderText = "S5"
                DataGridView1.Columns(6).Width = 28
                DataGridView1.Columns(7).HeaderText = "S6"
                DataGridView1.Columns(7).Width = 28
                DataGridView1.Columns(8).HeaderText = "S7"
                DataGridView1.Columns(8).Width = 28
                DataGridView1.Columns(9).HeaderText = "S8"
                DataGridView1.Columns(9).Width = 28
                DataGridView1.Columns(10).HeaderText = "S9"
                DataGridView1.Columns(10).Width = 28
                DataGridView1.Columns(11).HeaderText = "S10"
                DataGridView1.Columns(11).Width = 34
                ProgressBar.Visible = False
            ElseIf tab = "staff" Then
                DataGridView2.DataSource = ds
                DataGridView2.DataMember = tab
                DataGridView2.Columns(0).HeaderText = "Staff name"
                DataGridView2.Columns(0).Width = 150
                DataGridView2.Columns(1).HeaderText = "Dept"
                DataGridView2.Columns(1).Width = 100
                DataGridView2.Columns(2).HeaderText = "Subject"
                DataGridView2.Columns(2).Width = 100
                ProgressBar.Visible = False
            ElseIf tab = "advisor" Then
                cmd = New MySqlCommand("select * from advisor where username='" & Form1.TextBox3.Text & "'", con)
                reader = cmd.ExecuteReader()
                reader.Read()
                year = reader.Item(2).ToString
                sem = reader.Item(3).ToString
                branch = reader.Item(4).ToString
                regcode = reader.Item(5).ToString
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
                ProgressBar.Visible = False
            Else
                MsgBox("Error")
            End If
            con.Close()
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
        TextBox1.Text = ""
        DatePicker.Value = "01/01/2000"
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub



    'Key press
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox1.Text = "" Then
                MsgBox("Register number is empty", vbInformation, "Information")
                TextBox1.Focus()
            ElseIf IsNumeric(TextBox1.Text) = False Then
                MsgBox("Register number should be a number", vbInformation, "Information")
                TextBox1.Focus()
            ElseIf TextBox1.Text.Length <> 3 Then
                MsgBox("Register number should be a 3 digit number", vbInformation, "Information")
                TextBox1.Focus()
            Else
                DatePicker.Focus()
            End If
        End If
    End Sub
    Private Sub DatePicker_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DatePicker.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1.Focus()
        End If
    End Sub
    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox15.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox15.Text = "" Then
                MsgBox("Old password is empty", vbInformation, "Information")
                TextBox15.Focus()
            Else
                TextBox16.Focus()
            End If
        End If
    End Sub
    Private Sub TextBox16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox16.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox16.Text = "" Then
                MsgBox("New password is empty", vbInformation, "Information")
                TextBox16.Focus()
            Else
                Button11.PerformClick()
            End If
        End If
    End Sub



End Class