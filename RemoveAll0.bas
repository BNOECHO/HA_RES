Attribute VB_Name = "Module1"
Sub RemoveAll0()







For R = Range("A65535").End(xlUp).Row To 2 Step -1
    Debug.Print "A" & R
    Dim b As Boolean
    b = False
    For C = 2 To 66
        If Cells(R, C) = "" Or Cells(R, C) = 0 Then
            Cells(R, C) = "-"
        Else
            b = True
        End If
    Next
    If b = False Then
        Rows(R).Delete
    End If
    


Next





End Sub
