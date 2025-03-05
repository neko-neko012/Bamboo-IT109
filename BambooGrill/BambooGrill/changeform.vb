Public Class ChangeForm
    ' This method will be used to set the change amount passed from Peraform
    Public Sub SetChangeAmount(change As Decimal)
        ' Assuming you have a label to display the change
        changelbl.Text = change.ToString("₱#,##0.00")
    End Sub

    Private Sub CFDonebtn_Click(sender As Object, e As EventArgs) Handles CFDonebtn.Click
        ' Create an instance of the Customerdetails form
        Dim customerDetailsForm As New Customerdetails()

        ' Show the Customerdetails form
        customerDetailsForm.Show()
    End Sub

End Class
