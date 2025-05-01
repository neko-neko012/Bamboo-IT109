Imports MySql.Data.MySqlClient

Public Class Dashboard

    Private WithEvents timer As New Timer()
    Public Property UserFirstName As String
    Public Property UserLastName As String

    Public Sub New(firstName As String, lastName As String)
        InitializeComponent() ' Required call

        ' Store the passed-in values
        Me.UserFirstName = firstName
        Me.UserLastName = lastName
    End Sub
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timer.Interval = 1000 ' 1000 milliseconds = 1 second


        timer.Start()  ' Start the timer

        ' Display the current time and date when the form loads
        Userlabelplchlder.Text = UserFirstName & " " & UserLastName


        LoadTotalCustomers()
        LoadTotalSales()
        LoadTotalEmployees()
        LoadTotalExpenses()


        dbsalescombobox.Items.AddRange({"This Day", "This Week", "This Month", "This Year"})
        dbsalescombobox.SelectedIndex = 0  ' Set default filter option to "This Day"

        ' Load all sales data by default
        LoadAllSalesData()
        SetupDataGridView()

        Me.WindowState = FormWindowState.Maximized
    End Sub

    ' In Dashboard form
    ' In Dashboard form
    Public Sub UpdateUserLabel(firstName As String, lastName As String)
        Userlabelplchlder.Text = firstName & " " & lastName
    End Sub

    Private Sub SetupDataGridView()
        With dbrecentsalestable
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnHeadersVisible = True
            .RowHeadersVisible = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .ReadOnly = True
        End With
    End Sub

    ' This method will be triggered when the ComboBox selection changes
    Private Sub dbsalescombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dbsalescombobox.SelectedIndexChanged
        FilterSalesData() ' Filter data based on ComboBox selection
    End Sub

    Private Sub LoadAllSalesData()
        Dim query As String = "
        SELECT 
            SID AS 'SaleID', 
            CID AS 'CustomerID',
            ReceiptNumber AS 'Receipt#',
            TimeOrdered AS 'Time',
            DateOrdered AS 'Date',
            ItemsOrdered AS 'Items',
            QTY AS 'Quantity',
            SubTotal AS 'Subtotal',
            DiscountAmount AS 'Discount',
            NetAmount AS 'Total',
            PaymentMethod AS 'Payment Method',
            TransactionType AS 'Transaction Type',
            OrderStatus AS 'Order Status',
            RefundStatus AS 'Refund',
            DateRecorded AS 'Date Recorded',
            ProcessedBy AS 'Processed By',
            Notes AS 'Notes'
        FROM sales 
        ORDER BY DateRecorded DESC"

        LoadToDGV(query, dbrecentsalestable)
    End Sub

    Private Sub FilterSalesData()
        ' Get the selected filter value
        Dim filter As String = dbsalescombobox.SelectedItem.ToString()
        Dim dateCondition As String = ""

        ' Determine the query condition based on the selected filter
        Select Case filter
            Case "This Day"
                dateCondition = "WHERE DATE(DateOrdered) = CURDATE()"
            Case "This Week"
                dateCondition = "WHERE YEARWEEK(DateOrdered, 1) = YEARWEEK(CURDATE(), 1)"
            Case "This Month"
                dateCondition = "WHERE MONTH(DateOrdered) = MONTH(CURDATE()) AND YEAR(DateOrdered) = YEAR(CURDATE())"
            Case "This Year"
                dateCondition = "WHERE YEAR(DateOrdered) = YEAR(CURDATE())"
            Case Else
                ' If filter is "Cancel" or any custom filter, load all data
                dateCondition = ""
        End Select

        ' Create the query with the selected filter
        Dim query As String = "
        SELECT 
            SID AS 'SaleID', 
            CID AS 'CustomerID',
            ReceiptNumber AS 'Receipt#',
            TimeOrdered AS 'Time',
            DateOrdered AS 'Date',
            ItemsOrdered AS 'Items',
            QTY AS 'Quantity',
            SubTotal AS 'Subtotal',
            DiscountAmount AS 'Discount',
            NetAmount AS 'Total',
            PaymentMethod AS 'Payment Method',
            TransactionType AS 'Transaction Type',
            OrderStatus AS 'Order Status',
            RefundStatus AS 'Refund',
            DateRecorded AS 'Date Recorded',
            ProcessedBy AS 'Processed By',
            Notes AS 'Notes'
        FROM sales " & dateCondition & "
        ORDER BY DateRecorded DESC"

        ' Load the filtered data into the DataGridView
        LoadToDGV(query, dbrecentsalestable)
    End Sub

    ' Method to update time and date


    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        UpdateTimeAndDate()
    End Sub

    ' Method to update time and date
    Private Sub UpdateTimeAndDate()
        ' Set the current time and date in the label
        timeanddate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ' Format: "2025-05-02 14:45:00"
    End Sub
    Private Sub LoadTotalCustomers()
        Try
            Using connection As New MySqlConnection(conn.ConnectionString)
                connection.Open()

                Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM customer", connection)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                totalcustomerplchldr.Text = count.ToString()

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading customer count: " & ex.Message)
        End Try
    End Sub
    Private Sub LoadTotalSales()
        Try
            Using connection As New MySqlConnection(conn.ConnectionString)
                connection.Open()

                Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM sales", connection)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                totalsalesplcholder.Text = count.ToString()

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading sales count: " & ex.Message)
        End Try
    End Sub
    Private Sub LoadTotalEmployees()
        Try
            Using connection As New MySqlConnection(conn.ConnectionString)
                connection.Open()

                Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM employee", connection)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                totalemployeesplcholder.Text = count.ToString()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading employee count: " & ex.Message)
        End Try
    End Sub


    Private Sub LoadTotalExpenses()
        Try
            Using connection As New MySqlConnection(conn.ConnectionString)
                connection.Open()

                Dim cmd As New MySqlCommand("SELECT IFNULL(SUM(total), 0) FROM expensesoverview", connection)
                Dim totalExpenses As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())

                totalexpensesplcholder.Text = "₱ " & totalExpenses.ToString("N2") ' Format as currency

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total expenses: " & ex.Message)
        End Try
    End Sub

End Class