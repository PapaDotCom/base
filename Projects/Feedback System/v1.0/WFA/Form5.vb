Imports MySql.Data.MySqlClient



'Administrator form
Public Class Form5
    Dim con As New MySqlConnection(My.Settings.Connection)
    Dim reader As MySqlDataReader
    Dim cmd As MySqlCommand
    Dim query As String
    Dim str As String
    Dim c As String
    Dim t As String



    'Account menu click
    Private Sub AccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountToolStripMenuItem.Click
        GroupBox2.Visible = False
        GroupBox3.Visible = False

        ProgressBar.Visible = True
        ProgressBar.Value = 25
        loader("*", "account", "")

        GroupBox1.Visible = True

        TextBox1.Focus()
    End Sub



    'Add button click
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox1.Text = "" Then
            MsgBox("Username is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf TextBox2.Text = "" Then
            MsgBox("Password is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            query = "insert into account values('" & TextBox1.Text & "', '" & TextBox2.Text & "')"
            str = exe(query)
            If str = "valid" Then
                MsgBox("Record added successfully", vbInformation, "Successful")
                ProgressBar.Visible = False
                loader("*", "account", "")
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
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox1.Text = "" Then
            MsgBox("Username is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        ElseIf TextBox2.Text = "" Then
            MsgBox("Password is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            query = "update account set password = '" & TextBox2.Text & "' where username= '" & TextBox1.Text & "'"
            str = exe(query)
            If str = "valid" Then
                MsgBox("Record updated successfully", vbInformation, "Successful")
                ProgressBar.Visible = False
                loader("*", "account", "")
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
        query = "delete from account where username='" & TextBox1.Text & "'"
        str = exe(query)
        If str = "valid" Then
            MsgBox("Record removed successfully", vbInformation, "Successful")
            ProgressBar.Visible = False
            loader("*", "account", "")
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
    End Sub



    'Search button click
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        loader("*", "account", " where username='" & TextBox3.Text & "'")
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
        loader("*", "account", "")
        clr()
    End Sub



    'Datagrid cell click
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        With DataGridView1
            If e.RowIndex >= 0 Then
                i = .CurrentRow.Index
                If IsNothing(.Rows(i).Cells(0).Value.ToString) Then
                    clr()
                Else
                    TextBox1.Text = .Rows(i).Cells("username").Value.ToString
                    TextBox2.Text = .Rows(i).Cells("password").Value.ToString
                End If
            End If
            c = .CurrentRow.Index + 1
            t = .RowCount - 1
            If c <= t Then
                TextBox4.Text = c + " of " + t
            Else
                TextBox4.Text = ""
            End If
        End With
    End Sub



    'Change password menu click
    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        GroupBox1.Visible = False
        GroupBox3.Visible = False
        GroupBox2.Visible = True

        TextBox5.Focus()
    End Sub



    'Change password button click
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If TextBox5.Text = "" Then
            MsgBox("Old password is empty", vbInformation, "Information")
            TextBox5.Focus()
        ElseIf TextBox6.Text = "" Then
            MsgBox("New password is empty", vbInformation, "Information")
            TextBox6.Focus()
        Else
            Try
                ProgressBar.Visible = True
                con.Open()
                ProgressBar.Value = 25
                query = "select * from account where username='" & Form1.TextBox7.Text & "' and password='" & TextBox5.Text & "'"
                ProgressBar.Value = 50
                cmd = New MySqlCommand(query, con)
                reader = cmd.ExecuteReader
                ProgressBar.Value = 75
                If reader.HasRows = 0 Then
                    con.Close()
                    MsgBox("Old password is wrong", vbCritical, "Try again")
                    TextBox5.Text = ""
                    TextBox6.Text = ""
                    TextBox5.Focus()
                    ProgressBar.Visible = False
                Else
                    ProgressBar.Value = 85
                    con.Close()
                    query = "update account set password = '" & TextBox6.Text & "' where username= '" & Form1.TextBox7.Text & "'"
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
                    TextBox5.Text = ""
                    TextBox6.Text = ""
                    TextBox5.Focus()
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



    'Database menu click
    Private Sub DatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseToolStripMenuItem.Click
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = True

        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("advisor")
        ComboBox1.Items.Add("feedback")
        ComboBox1.Items.Add("staff")
        ComboBox1.Items.Add("student")
        ComboBox1.Focus()
    End Sub



    'Show table button click
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If ComboBox1.Text = "" Then
            MsgBox("Please select table", vbInformation, "Information")
        Else
            loader("*", ComboBox1.Text, "")
        End If
    End Sub



    'Clear student button click
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim ans As String
        ans = MsgBox("Confirm to clear all student status", vbExclamation + vbYesNo, "Confirm")
        If ans = vbYes Then
            ProgressBar.Visible = True
            ProgressBar.Value = 25
            query = "update student set s1=default,s2=default,s3=default,s4=default,s5=default,s6=default,s7=default,s8=default,s9=default,s10=default"
            str = exe(query)
            ProgressBar.Value = 75
            If str = "valid" Then
                ProgressBar.Value = 100
                MsgBox(" Successfully clear all student status", vbInformation, "Successful")
                ProgressBar.Visible = False
                If ComboBox1.Text <> "" Then
                    loader("*", "student", "")
                End If
            ElseIf str = "invalid" Then
                ProgressBar.Value = 100
                MsgBox(" Successfully clear all student status", vbInformation, "Successful")
                ProgressBar.Visible = False
                If ComboBox1.Text <> "" Then
                    loader("*", "student", "")
                End If
            ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                MsgBox("Connection lost", vbCritical, "No internet")
                ProgressBar.Visible = False
            Else
                MsgBox(str, vbCritical, "Error")
                ProgressBar.Visible = False
            End If
        End If
    End Sub



    'Reset button click
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If ComboBox1.Text = "" Then
            MsgBox("Please select table", vbInformation, "Information")
        Else
            Dim ans As String
            ans = MsgBox("Confirm to destroy all data in the " & ComboBox1.Text & " table", vbExclamation + vbYesNo, "Caution")
            If ans = vbYes Then
                ProgressBar.Visible = True
                ProgressBar.Value = 25
                query = "truncate table " & ComboBox1.Text & ""
                str = exe(query)
                ProgressBar.Value = 75
                If str = "invalid" Then
                    ProgressBar.Value = 100
                    MsgBox("Successfully destroy all data in the " & ComboBox1.Text & " table", vbInformation, "Successful")
                    ProgressBar.Visible = False
                    If ComboBox1.Text <> "" Then
                        loader("*", ComboBox1.Text, "")
                    End If
                ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                    MsgBox("Connection lost", vbCritical, "No internet")
                    ProgressBar.Visible = False
                Else
                    MsgBox(str, vbCritical, "Error")
                    ProgressBar.Visible = False
                End If
            End If
        End If
    End Sub



    'Execute query button click
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        ProgressBar.Visible = True
        ProgressBar.Value = 25
        If TextBox7.Text = "" Then
            MsgBox("Query is empty", vbInformation, "Information")
            ProgressBar.Visible = False
        Else
            query = TextBox7.Text
            str = exe(query)
            If str = "valid" Then
                MsgBox("Query executed successfully" + vbCrLf + "1 row affected", vbInformation, "Successful")
                ProgressBar.Visible = False
                If ComboBox1.Text <> "" Then
                    loader("*", ComboBox1.Text, "")
                End If
                TextBox7.Text = ""
            ElseIf str = "invalid" Then
                MsgBox("Query execute successfully" + vbCrLf + "0 or more rows affected", vbInformation, "Successful")
                ProgressBar.Visible = False
                TextBox7.Text = ""
            ElseIf str = "Unable to connect to any of the specified MySQL hosts." Then
                MsgBox("Connection lost", vbCritical, "No internet")
                ProgressBar.Visible = False
                TextBox7.Text = ""
            Else
                MsgBox(str, vbCritical, "Error")
                ProgressBar.Visible = False
                TextBox7.Text = ""
            End If
        End If
    End Sub



    'Log out menu click
    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Close()
        Form1.TextBox7.Text = ""
        Form1.TextBox8.Text = ""
        Form1.Show()
        Form1.TextBox7.Focus()
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



    'Execute select query function and load datagrid
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
            con.Close()
            If tab = "account" Then
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = tab
                DataGridView1.Columns(0).HeaderText = "User"
                DataGridView1.Columns(0).Width = 150
                DataGridView1.Columns(1).HeaderText = "Password"
                DataGridView1.Columns(1).Width = 120
                ProgressBar.Visible = False
            ElseIf tab = "advisor" Then
                DataGridView2.DataSource = ds
                DataGridView2.DataMember = tab
                DataGridView2.Columns(0).Width = 120
                ProgressBar.Visible = False
            ElseIf tab = "feedback" Then
                DataGridView2.DataSource = ds
                DataGridView2.DataMember = tab
                DataGridView2.Columns(3).Width = 120
                ProgressBar.Visible = False
            ElseIf tab = "staff" Then
                DataGridView2.DataSource = ds
                DataGridView2.DataMember = tab
                DataGridView2.Columns(0).Width = 120
                ProgressBar.Visible = False
            ElseIf tab = "student" Then
                DataGridView2.DataSource = ds
                DataGridView2.DataMember = tab
                DataGridView2.Columns(0).Width = 120
                ProgressBar.Visible = False
            Else
                MsgBox("Error")
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
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub



    'Key press
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox1.Text = "" Then
                MsgBox("Username is empty", vbInformation, "Information")
                TextBox1.Focus()
            Else
                TextBox2.Focus()
            End If
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox2.Text = "" Then
                MsgBox("Password is empty", vbInformation, "Information")
                TextBox2.Focus()
            Else
                Button1.Focus()
            End If
        End If
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox5.Text = "" Then
                MsgBox("Old password is empty", vbInformation, "Information")
                TextBox5.Focus()
            Else
                TextBox6.Focus()
            End If
        End If
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox6.Text = "" Then
                MsgBox("New password is empty", vbInformation, "Information")
                TextBox6.Focus()
            Else
                Button10.PerformClick()
            End If
        End If
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox7.Text = "" Then
                MsgBox("Query is empty", vbInformation, "Information")
                TextBox7.Focus()
            Else
                Button14.PerformClick()
            End If
        End If
    End Sub
    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            If ComboBox1.Text = "" Then
                MsgBox("Please select table", vbInformation, "Information")
                ComboBox1.Focus()
            Else
                Button11.PerformClick()
            End If
        End If
    End Sub



End Class