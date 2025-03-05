Imports MySql.Data.MySqlClient
Imports MySqlConnector

Public Class Customerdetails
    ' Use modDB for database connection
    ' Dim conn As New MySqlConnection("your_connection_string_here")

    ' Your existing methods for handling customer details go here...

    Private Sub donebtn_Click(sender As Object, e As EventArgs) Handles donebtn.Click
        ' Get the customer details
        Dim firstName As String = CusFirstName.Text
        Dim lastName As String = CusLastName.Text
        Dim phone As String = CusPhone.Text
        Dim address As String = CusAddress.Text

        ' Get the order details (assuming these are obtained from Take_Order form)
        Dim orderTotal As Decimal = Take_Order.OrderTotal ' Access the order total from Take_Order
        Dim itemsOrdered As String = "Item1, Item2" ' Replace with actual items ordered
        Dim qty As Integer = 2 ' Replace with actual quantity
        Dim transactionType As String = "Sale" ' Or you can determine this dynamically
        Dim orderStatus As String = "Completed"
        Dim timeOrdered As String = DateTime.Now.ToString("HH:mm:ss")
        Dim dateOrdered As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim subTotal As Decimal = orderTotal ' Calculate this based on items and quantity
        Dim discountAmount As Decimal = 0 ' Or calculate any applicable discount
        Dim netAmount As Decimal = subTotal - discountAmount
        Dim paymentMethod As String = "Cash" ' Replace with actual payment method
        Dim receiptNumber As String = "R" & DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim processedBy As String = "Cashier" ' Or get from session
        Dim notes As String = "No additional notes" ' Or get from input

        ' Open connection using modDB
        modDB.openConn(modDB.db_name)

        ' Insert customer details into Customer table
        Dim insertCustomerQuery As String = "INSERT INTO Customer (FirstName, LastName, PhoneNumber, Address, TableNumber, ItemsOrdered, QTY, TransactionType, OrderStatus, TimeOrdered, DateOrdered, SubTotal, DiscountAmount, NetAmount, PaymentMethod, ReceiptNumber, RefundStatus, DateRecorded, ProcessedBy, Notes) " &
                                            "VALUES (@FirstName, @LastName, @PhoneNumber, @Address, @TableNumber, @ItemsOrdered, @QTY, @TransactionType, @OrderStatus, @TimeOrdered, @DateOrdered, @SubTotal, @DiscountAmount, @NetAmount, @PaymentMethod, @ReceiptNumber, @RefundStatus, @DateRecorded, @ProcessedBy, @Notes)"

        Using cmd As New MySqlCommand(insertCustomerQuery, modDB.conn)
            cmd.Parameters.AddWithValue("@FirstName", firstName)
            cmd.Parameters.AddWithValue("@LastName", lastName)
            cmd.Parameters.AddWithValue("@PhoneNumber", phone)
            cmd.Parameters.AddWithValue("@Address", address)
            cmd.Parameters.AddWithValue("@TableNumber", DBNull.Value) ' Set as needed
            cmd.Parameters.AddWithValue("@ItemsOrdered", itemsOrdered)
            cmd.Parameters.AddWithValue("@QTY", qty)
            cmd.Parameters.AddWithValue("@TransactionType", transactionType)
            cmd.Parameters.AddWithValue("@OrderStatus", orderStatus)
            cmd.Parameters.AddWithValue("@TimeOrdered", timeOrdered)
            cmd.Parameters.AddWithValue("@DateOrdered", dateOrdered)
            cmd.Parameters.AddWithValue("@SubTotal", subTotal)
            cmd.Parameters.AddWithValue("@DiscountAmount", discountAmount)
            cmd.Parameters.AddWithValue("@NetAmount", netAmount)
            cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
            cmd.Parameters.AddWithValue("@ReceiptNumber", receiptNumber)
            cmd.Parameters.AddWithValue("@RefundStatus", "Not Refunded") ' Or based on your logic
            cmd.Parameters.AddWithValue("@DateRecorded", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            cmd.Parameters.AddWithValue("@ProcessedBy", processedBy)
            cmd.Parameters.AddWithValue("@Notes", notes)

            cmd.ExecuteNonQuery()
        End Using

        ' Get the CID (Customer ID) of the newly inserted customer
        Dim customerID As Integer
        Dim getCIDQuery As String = "SELECT CID FROM Customer WHERE ReceiptNumber = @ReceiptNumber"

        Using cmd As New MySqlCommand(getCIDQuery, modDB.conn)
            cmd.Parameters.AddWithValue("@ReceiptNumber", receiptNumber)

            customerID = Convert.ToInt32(cmd.ExecuteScalar())
        End Using

        ' Insert into Sales table
        Dim insertSalesQuery As String = "INSERT INTO Sales (CID, ReceiptNumber, TimeOrdered, DateOrdered, ItemsOrdered, QTY, SubTotal, DiscountAmount, NetAmount, PaymentMethod, TransactionType, OrderStatus, RefundStatus, DateRecorded, ProcessedBy, Notes) " &
                                         "VALUES (@CID, @ReceiptNumber, @TimeOrdered, @DateOrdered, @ItemsOrdered, @QTY, @SubTotal, @DiscountAmount, @NetAmount, @PaymentMethod, @TransactionType, @OrderStatus, @RefundStatus, @DateRecorded, @ProcessedBy, @Notes)"

        Using cmd As New MySqlCommand(insertSalesQuery, modDB.conn)
            cmd.Parameters.AddWithValue("@CID", customerID)
            cmd.Parameters.AddWithValue("@ReceiptNumber", receiptNumber)
            cmd.Parameters.AddWithValue("@TimeOrdered", timeOrdered)
            cmd.Parameters.AddWithValue("@DateOrdered", dateOrdered)
            cmd.Parameters.AddWithValue("@ItemsOrdered", itemsOrdered)
            cmd.Parameters.AddWithValue("@QTY", qty)
            cmd.Parameters.AddWithValue("@SubTotal", subTotal)
            cmd.Parameters.AddWithValue("@DiscountAmount", discountAmount)
            cmd.Parameters.AddWithValue("@NetAmount", netAmount)
            cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
            cmd.Parameters.AddWithValue("@TransactionType", transactionType)
            cmd.Parameters.AddWithValue("@OrderStatus", orderStatus)
            cmd.Parameters.AddWithValue("@RefundStatus", "Not Refunded") ' Or based on your logic
            cmd.Parameters.AddWithValue("@DateRecorded", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            cmd.Parameters.AddWithValue("@ProcessedBy", processedBy)
            cmd.Parameters.AddWithValue("@Notes", notes)

            cmd.ExecuteNonQuery()
        End Using

        ' Create a receipt record
        Dim insertReceiptQuery As String = "INSERT INTO Receipt (ReceiptNumber, Purdate, ProcessedBy) VALUES (@ReceiptNumber, @Purdate, @ProcessedBy)"

        Using cmd As New MySqlCommand(insertReceiptQuery, modDB.conn)
            cmd.Parameters.AddWithValue("@ReceiptNumber", receiptNumber)
            cmd.Parameters.AddWithValue("@Purdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            cmd.Parameters.AddWithValue("@ProcessedBy", processedBy)

            cmd.ExecuteNonQuery()
        End Using

        ' Update inventory for each ordered item
        Dim updateInventoryQuery As String = "UPDATE Inventory SET Qty = Qty - @Qty WHERE ItemName = @ItemName"

        ' Loop through the ordered items and update inventory
        For Each item As OrderedItem In GetOrderItems()
            Using cmd As New MySqlCommand(updateInventoryQuery, modDB.conn)
                cmd.Parameters.AddWithValue("@Qty", item.Quantity)
                cmd.Parameters.AddWithValue("@ItemName", item.ItemName)  ' Assuming you're using ItemName as the key
                cmd.ExecuteNonQuery()
            End Using
        Next

        ' After updating the inventory, proceed to generate the receipt
        MessageBox.Show("Order completed! Inventory updated and receipt generated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Method to get the ordered items. Replace with your actual logic.
    Private Function GetOrderItems() As List(Of OrderedItem)
        ' This is a placeholder. Replace with actual code to get ordered items from your form
        Return New List(Of OrderedItem) From {
            New OrderedItem("Hita Inasal", 2, 150.0),  ' Example items
            New OrderedItem("Rice", 3, 50.0)
        }
    End Function

    ' Define the OrderedItem class
    Public Class OrderedItem
        Public Property ItemName As String
        Public Property Quantity As Decimal
        Public Property Price As Decimal

        Public Sub New(itemName As String, quantity As Decimal, price As Decimal)
            Me.ItemName = itemName
            Me.Quantity = quantity
            Me.Price = price
        End Sub
    End Class
End Class
