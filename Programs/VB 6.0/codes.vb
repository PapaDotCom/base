''' unload form '''
Unload Me


''' Check Numeric '''
If IsNumeric(Text1.Text) = False Then
MsgBox "Is number", vbInformation, " Information"
End If


''' Login without using database '''
If Text1.Text="ananth" and Text2.text="pass" Then
MsgBox "Correct", vbInformation, " Login successful"
Form2.show
Else
MsgBox "Wrong", vbCritical, " Login failed"
End If

''' Login using database '''
Adodc1.RecordSource = "select * from tablename where username='" + Text1.Text + "' and password='" + Text2.Text + "'"
Adodc1.Refresh
If Adodc1.Recordset.EOF Then
MsgBox "Wrong", vbCritical, " Login failed"
Text1.Text = ""
Text2.Text = ""
Else
MsgBox "Correct", vbInformation, " Login successful"
Form2.show
End If


''' add item
''' Add item to combo '''
For i = 0 To 10 Step 1
Combos1.AddItem (i)
Next i

''' clear item from combo '''
Combos1.Clear

''' enter key press '''
If KeyAscii = 13 Then
Text2.SetFocus
End If



''' yes no message box '''
Answer = MsgBox("Are you sure", vbYesNo, " Conformation")
If Answer = vbYes Then
    'Statements
End If


''' get specify value from record set '''
int = Val(Adodc1.Recordset.Fields(0).Value)     'Fields(index), index start with 0
str = Adodc1.Recordset.Fields(1).Value

''' put specify value to record set '''
Val(Adodc1.Recordset.Fields(0).Value) = int     'Fields(index), index start with 0
Adodc1.Recordset.Fields(1).Value = str


''' count records '''
c = 0
Do While Adodc1.Recordset.EOF <> True
c = c + 1
Adodc1.Recordset.MoveNext
Loop

''' data environment '''
If DataEnvironment1.Connection1.State <> 0 Then
DataEnvironment1.Connection1.Close
End If
DataEnvironment1.Connection1.Open
DataEnvironment1.Command1 Text1.Text, Text2.Text        'SQL statement : select * from feedback where name=? and age=?
DataReport1.Show


