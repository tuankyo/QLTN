Public Class frmLoginLog
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cbIP As System.Windows.Forms.ColumnHeader
    Friend WithEvents chDateTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdThucHien1 As System.Windows.Forms.Button
    Friend WithEvents chTenUser As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents chResult As System.Windows.Forms.ColumnHeader
    Friend WithEvents listLoginLog As System.Windows.Forms.ListView
    Friend WithEvents cboDateTime As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cbIP = New System.Windows.Forms.ColumnHeader
        Me.chDateTime = New System.Windows.Forms.ColumnHeader
        Me.cmdThucHien1 = New System.Windows.Forms.Button
        Me.chTenUser = New System.Windows.Forms.ColumnHeader
        Me.listLoginLog = New System.Windows.Forms.ListView
        Me.chResult = New System.Windows.Forms.ColumnHeader
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.cboDateTime = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'cbIP
        '
        Me.cbIP.Text = "Login IP"
        Me.cbIP.Width = 100
        '
        'chDateTime
        '
        Me.chDateTime.Text = "Login Date"
        Me.chDateTime.Width = 150
        '
        'cmdThucHien1
        '
        Me.cmdThucHien1.Location = New System.Drawing.Point(424, 8)
        Me.cmdThucHien1.Name = "cmdThucHien1"
        Me.cmdThucHien1.Size = New System.Drawing.Size(80, 23)
        Me.cmdThucHien1.TabIndex = 123
        Me.cmdThucHien1.Text = "Loc Du Lieu"
        '
        'chTenUser
        '
        Me.chTenUser.Text = "UserName"
        Me.chTenUser.Width = 110
        '
        'listLoginLog
        '
        Me.listLoginLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chTenUser, Me.cbIP, Me.chDateTime, Me.chResult})
        Me.listLoginLog.FullRowSelect = True
        Me.listLoginLog.GridLines = True
        Me.listLoginLog.Location = New System.Drawing.Point(8, 40)
        Me.listLoginLog.Name = "listLoginLog"
        Me.listLoginLog.Size = New System.Drawing.Size(496, 392)
        Me.listLoginLog.TabIndex = 116
        Me.listLoginLog.View = System.Windows.Forms.View.Details
        '
        'chResult
        '
        Me.chResult.Text = "Login Result"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 16)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "UserName"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(120, 8)
        Me.txtUser.MaxLength = 20
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(112, 20)
        Me.txtUser.TabIndex = 118
        Me.txtUser.Text = ""
        '
        'cboDateTime
        '
        Me.cboDateTime.Location = New System.Drawing.Point(240, 8)
        Me.cboDateTime.Name = "cboDateTime"
        Me.cboDateTime.Size = New System.Drawing.Size(176, 21)
        Me.cboDateTime.TabIndex = 124
        '
        'frmLoginLog
        '
        Me.Controls.Add(Me.cboDateTime)
        Me.Controls.Add(Me.cmdThucHien1)
        Me.Controls.Add(Me.listLoginLog)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUser)
        Me.Name = "frmLoginLog"
        Me.Size = New System.Drawing.Size(568, 456)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim IODatabase As New IODatabase
    Dim IOUnicode As New IOUnicode
    Dim whereString As String
    Dim sUserId As String

    Private Sub cmdThucHien1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThucHien1.Click
        Try
            Dim cmdSelect As String
            Dim dr As OracleClient.OracleDataReader
            Dim i As Integer
            Dim strWhere As String

            If (txtUser.Text <> "") Then
                strWhere = " And UserName like '%" + txtUser.Text + "%'"
            End If

            If (cboDateTime.Text <> "") Then
                strWhere = " And TO_CHAR(LoginTime,'DD-MM-YYYY hh:mm:ss') = TO_CHAR(TO_DATE('" + cboDateTime.Text + "','DD-MM-YYYY'),'DD-MM-YYYY') "
            End If

            listLoginLog.Items.Clear()

            IODatabase.connToDB()

            cmdSelect = "SELECT USERNAME,LOGINIP,TO_CHAR(LoginTime,'DD-MM-YYYY') LoginTime,LOGINRESULT from TTBC_LoginLog Where 1=1" + strWhere + "order by LoginTime"

            dr = IODatabase.selectDB(cmdSelect)

            i = 0
            While dr.Read()
                listLoginLog.Items.Add(New ListViewItem(IOUnicode.readUnicode(dr.GetValue(0) + "")))
                listLoginLog.Items(i).SubItems.Add(IOUnicode.readUnicode(dr.GetValue(1) + ""))
                listLoginLog.Items(i).SubItems.Add(IOUnicode.readUnicode(dr.GetValue(2) + ""))
                listLoginLog.Items(i).SubItems.Add(IOUnicode.readUnicode(dr.GetValue(3) + ""))
                i += 1
            End While

            dr.Close()
            IODatabase.disToDB()
        Catch ex As Exception
            MsgBox("Khong tim thay du lieu")
        End Try

    End Sub


    Private Sub frmLoginLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dr As OracleClient.OracleDataReader

        IODatabase.connToDB()
        cboDateTime.Items.Clear()
        dr = IODatabase.selectDB("select distinct TO_CHAR(LoginTime,'DD-MM-YYYY') from TTBC_LoginLog order by TO_CHAR(LoginTime,'DD-MM-YYYY') asc")
        While dr.Read
            cboDateTime.Items.Add(dr.GetValue(0))
        End While
        dr.Close()
        IODatabase.disToDB()

        datatolist()
    End Sub
    Public Sub datatolist()
        Try
            Dim cmdSelect As String
            Dim dr As OracleClient.OracleDataReader
            Dim i As Integer
            Dim strWhere As String

            If (txtUser.Text <> "") Then
                strWhere = " And UserName like '%" + txtUser.Text + "%'"
            End If

            If (cboDateTime.Text <> "") Then
                strWhere = " And TO_CHAR(LoginTime,'DD-MM-YYYY') = TO_CHAR(TO_DATE('" + cboDateTime.Text + "','DD-MM-YYYY'),'DD-MM-YYYY') "
            End If

            listLoginLog.Items.Clear()

            IODatabase.connToDB()

            cmdSelect = "SELECT USERNAME,LOGINIP,TO_CHAR(LoginTime,'DD-MM-YYYY hh:mm:ss') LoginTime, LOGINRESULT from TTBC_LoginLog Where 1=1" + strWhere + "order by LoginTime"

            dr = IODatabase.selectDB(cmdSelect)

            i = 0
            While dr.Read()
                listLoginLog.Items.Add(New ListViewItem(IOUnicode.readUnicode(dr.GetValue(0) + "")))
                listLoginLog.Items(i).SubItems.Add(IOUnicode.readUnicode(dr.GetValue(1) + ""))
                listLoginLog.Items(i).SubItems.Add(IOUnicode.readUnicode(dr.GetValue(2) + ""))
                listLoginLog.Items(i).SubItems.Add(dr.GetValue(3))
                i += 1
            End While

            dr.Close()
            IODatabase.disToDB()
        Catch ex As Exception
            MsgBox("Khong tim thay du lieu")
        End Try
    End Sub

    Private Sub listLoginLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listLoginLog.SelectedIndexChanged

    End Sub
End Class
