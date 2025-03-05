Public Class Peraform
    Private orderTotal As Decimal

    ' Set the order total when the form loads (or from Take_Order)
    Public Sub SetOrderTotal(total As Decimal)
        orderTotal = total
    End Sub

    Private Sub PFTotallbl_Click(sender As Object, e As EventArgs) Handles PFTotallbl.Click
        ' Assuming Take_Order is already open and you can access the instance
        Dim takeOrderForm As Take_Order = CType(Application.OpenForms("Take_Order"), Take_Order)

        ' Access the total from the Take_Order form and show it in the label
        PFTotallbl.Text = takeOrderForm.OrderTotal.ToString("₱#,##0.00")
    End Sub

    ' Removed the calculation logic from here.
    ' This event should no longer do the subtraction.

    Private Sub Moneyinputlbl_TextChanged(sender As Object, e As EventArgs) Handles Moneyinputlbl.TextChanged
        ' Do nothing here. Subtraction should only happen on Proceedbtn click
    End Sub

    Private Sub Proceedbtn_Click(sender As Object, e As EventArgs) Handles Proceedbtn.Click
        ' Get the payment amount from Moneyinputlbl
        Dim paymentAmount As Decimal
        If Decimal.TryParse(Moneyinputlbl.Text.Replace("₱", "").Trim(), paymentAmount) Then
            ' Perform the subtraction only when the button is clicked
            If paymentAmount >= orderTotal Then
                Dim change As Decimal = paymentAmount - orderTotal
                ' Now pass the change to ChangeForm
                Dim changeForm As New ChangeForm()
                changeForm.SetChangeAmount(change) ' Make sure ChangeForm has a SetChangeAmount method
                changeForm.Show()
            Else
                MessageBox.Show("Insufficient payment. Please enter a valid amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Invalid payment amount. Please enter a numeric value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub Moneyinputlbl_KeyDown(sender As Object, e As KeyEventArgs) Handles Moneyinputlbl.KeyDown
        If e.KeyCode = Keys.Enter Then
            Proceedbtn.PerformClick()
        End If
    End Sub

    Private Sub Cancelbtn_Click(sender As Object, e As EventArgs) Handles Cancelbtn.Click
        ' Close the current form and show Take_Order
        Me.Close()
        Dim takeOrderForm As New Take_Order()
        takeOrderForm.Show()
    End Sub

End Class
