
Module Module1

    Dim student As New Dictionary(Of String, List(Of Integer))

    Sub Main()
        Dim choice As Integer

        Console.WriteLine()
        Console.WriteLine(vbCrLf & " === student Grade Management")

        Do
            Console.WriteLine()
            Console.WriteLine("1 add student")
            Console.WriteLine("2 View All Students")
            Console.WriteLine("4 Show Class Average")
            Console.WriteLine("5 Exit")
            Console.WriteLine("Enter your choice:  ")
            Integer.TryParse(Console.ReadLine(), choice)

            Select Case choice
                Case 1
                    addstudent()
                Case 2
                    ViewStudents()
                Case 3
                    SearchStudents()
                Case 4
                    showclassaverage()
                Case 5
                    Console.WriteLine("exiting program...")
                Case Else
                    Console.WriteLine("Invalid choice.")
            End Select

        Loop While choice <> 5
    End Sub

    Sub addstudent()
        Console.Write("Enter student name:  ")
        Dim name As String = Console.ReadLine()
        Dim grades As New List(Of Integer)

        For i As Integer = 1 To 3
            Console.Write("Enter grade" & i & ": ")
            Dim grade As Integer
            Integer.TryParse(Console.ReadLine(), grade)
            grades.Add(grade)
        Next

        If student.ContainsKey(name) Then
            Console.WriteLine("student already exists. updating grades.")
            student(name) = grades
        Else
            student.Add(name, grades)
        End If

        Console.WriteLine("student added successfully!")
    End Sub

    Sub ViewStudents()
        If student.Count = 0 Then
            Console.WriteLine("No student records found.")
            Return
        End If

        For Each entry In student
            Dim name = entry.Key
            Dim grades = entry.Value
            Dim avg = CalculateAverage(grades)
            Dim status = If(avg >= 75, "PASS", "FAIL")

            Console.WriteLine(vbCrLf & "Name: " & name)
            Console.WriteLine("Grades:" & String.Join(",", grades))
            Console.WriteLine("Average: " & avg.ToString("F2" & " - status: " & status))
        Next
    End Sub

    Sub SearchStudents()
        Console.WriteLine("enter name to search: ")
        Dim name As String = Console.ReadLine()

        If student.ContainsKey(name) Then
            Dim grades = student(name)
            Dim avg = CalculateAverage(grades)
            Dim status = If(avg >= 75, "PASS", "FAIL")


            Console.WriteLine("grades:" & String.Join(",", grades))
            Console.WriteLine("Average:" & avg.ToString("F2") & "- status: " & status)
        Else
            Console.WriteLine("student not founded.")
        End If
    End Sub

    Sub showclassaverage()
        If student.Count = 0 Then
            Console.WriteLine("no student data to calculate average.")
            Return
        End If

        Dim totalAvg As Double = 0
        For Each entry In student.Values
            totalAvg += CalculateAverage(entry)
        Next

        Dim classAvg = totalAvg / student.Count
        Console.WriteLine("Class Average: " & classAvg.ToString("F2"))
    End Sub

    Function CalculateAverage(grades As List(Of Integer)) As Double
        Dim total As Integer = 0
        For Each score In grades
            total += score
        Next
        Return total / grades.Count
    End Function
End Module


