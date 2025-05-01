Imports MySql.Data.MySqlClient

Public Class Form1
    ' Database variables

    ' Form Load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        ' Set the initial visibility of the panels
        loginpanel.Visible = True
        registerpanel.Visible = False

        openConn(db_name) ' From modDB

        Dim sql As String = "SELECT COUNT(*) FROM users"
        Dim userCount As Integer = 0

        Try
            ' Check database connection
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                MessageBox.Show("Database connected successfully!") ' Debugging message

                cmd = New MySqlCommand(sql, conn)
                userCount = Convert.ToInt32(cmd.ExecuteScalar())

                ' Display user count for debugging
                MessageBox.Show("User count: " & userCount.ToString())

                If userCount = 0 Then
                    MessageBox.Show("No users found! Please register first.", "Registration Required", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Ensure this is executed correctly
                    loginpanel.Hide()  ' Hide login panel
                    registerpanel.Show() ' Show register panel

                    ' Force a UI update
                    registerpanel.Invalidate()  ' Invalidate the panel to force redraw
                    Me.Refresh()  ' Refresh the form to ensure UI is updated

                    ' Debugging: confirm visibility after setting
                    MessageBox.Show("registerpanel.Visible after update: " & registerpanel.Visible.ToString())

                    ' Initialize ComboBox items and select Admin as default role
                    Guna2ComboBox1.Items.Clear()
                    Guna2ComboBox1.Items.AddRange(New Object() {"Admin", "Cashier", "Staff"})
                    Guna2ComboBox1.SelectedIndex = 0

                    ' Attach event handler for ComboBox selection change
                    AddHandler Guna2ComboBox1.SelectedIndexChanged, AddressOf OnlyAdminSelectable
                End If
            Else
                MessageBox.Show("Database connection failed!") ' Debugging message
            End If
        Catch ex As Exception
            MessageBox.Show("Error checking users: " & ex.Message)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub



    Private Sub OnlyAdminSelectable(sender As Object, e As EventArgs)
        ' Check if ComboBox selected item is not Nothing
        If Guna2ComboBox1.SelectedItem Is Nothing OrElse Guna2ComboBox1.SelectedItem.ToString() <> "Admin" Then
            MessageBox.Show("You must register as Admin first!", "Role Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Guna2ComboBox1.SelectedIndex = 0 ' Force back to Admin
        End If
    End Sub

    ' Register button click handler
    Private Sub registerbtn_Click(sender As Object, e As EventArgs) Handles registerbtn.Click
        ' Validate fields
        If String.IsNullOrWhiteSpace(firstnametxtbx.Text) OrElse
           String.IsNullOrWhiteSpace(lastnametxtbx.Text) OrElse
           String.IsNullOrWhiteSpace(registerusernametxtbx.Text) OrElse
           String.IsNullOrWhiteSpace(registerpasswordtxtbx.Text) OrElse
           Guna2ComboBox1.SelectedItem Is Nothing Then

            MessageBox.Show("Please fill out all fields!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Prepare data
        Dim firstName As String = firstnametxtbx.Text.Trim()
        Dim lastName As String = lastnametxtbx.Text.Trim()
        Dim username As String = registerusernametxtbx.Text.Trim()
        Dim password As String = registerpasswordtxtbx.Text.Trim()
        Dim role As String = Guna2ComboBox1.SelectedItem.ToString()
        Dim dateCreated As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        ' Connect to DB
        openConn(db_name)

        ' Insert user
        Dim sql As String = "INSERT INTO users (FirstName, LastName, Username, Password, Role, DateCreated) VALUES (@FirstName, @LastName, @Username, @Password, @Role, @DateCreated)"

        Try
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                cmd = New MySqlCommand(sql, conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@FirstName", firstName)
                cmd.Parameters.AddWithValue("@LastName", lastName)
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", password)  ' Storing the password as it is, no hashing
                cmd.Parameters.AddWithValue("@Role", role)
                cmd.Parameters.AddWithValue("@DateCreated", dateCreated)

                Dim result As Integer = cmd.ExecuteNonQuery()

                If result > 0 Then
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' After registration, go back to login
                    registerpanel.Visible = False
                    loginpanel.Visible = True

                    ' Clear fields
                    firstnametxtbx.Clear()
                    lastnametxtbx.Clear()
                    registerusernametxtbx.Clear()
                    registerpasswordtxtbx.Clear()
                    Guna2ComboBox1.SelectedIndex = -1
                Else
                    MessageBox.Show("Registration failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Connection to database failed during registration!")
            End If

        Catch ex As Exception
            MessageBox.Show("Error during registration: " & ex.Message)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private loggedInFirstName As String
    Private loggedInLastName As String
    Private Sub Loginbtn_Click(sender As Object, e As EventArgs) Handles Loginbtn.Click
        ' Validate login fields
        If String.IsNullOrWhiteSpace(usernametxtbx.Text) OrElse String.IsNullOrWhiteSpace(passwordtxtbx.Text) Then
            MessageBox.Show("Please enter both username and password!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim username As String = usernametxtbx.Text.Trim()
        Dim password As String = passwordtxtbx.Text.Trim()

        ' Connect to DB
        openConn(db_name)

        Dim sql As String = "SELECT * FROM users WHERE Username = @Username AND Password = @Password"

        Try
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                cmd = New MySqlCommand(sql, conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", password)  ' No hashing, plain text check

                Dim dr As MySqlDataReader = cmd.ExecuteReader()

                If dr.Read() Then
                    ' Store logged-in user information
                    loggedInFirstName = dr("FirstName").ToString()
                    loggedInLastName = dr("LastName").ToString()

                    ' Call the UpdateUserLabel method in Dashboard to set the label text
                    Dim dashboardForm As New Dashboard(loggedInFirstName, loggedInLastName)


                    ' Successful login
                    MessageBox.Show("Login Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()  ' Hide the login form
                    dashboardForm.Show()  ' Show the dashboard form
                Else
                    ' Failed login
                    MessageBox.Show("Incorrect Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Connection to database failed during login!")
            End If

        Catch ex As Exception
            MessageBox.Show("Error during login: " & ex.Message)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub




End Class
