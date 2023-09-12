Imports System.Runtime.InteropServices
Imports System.Drawing

Public Class ucListViewEx
    Inherits System.Windows.Forms.ListView

    Public Delegate Function GetEmptyMessageDelegate() As String

    Public GetEmptyMessage As GetEmptyMessageDelegate
    Private _ColumnSorter As ListViewColumnSorter
    Private ColumnTypes(24) As SortType
    Private m_EmptyMessage As String = String.Empty

#Region "Public Properties"

    Public Property EmptyMessage() As String
        Get
            If Me.GetEmptyMessage Is Nothing Then
                Return m_EmptyMessage
            Else
                Return GetEmptyMessage().Trim()
            End If
        End Get
        Set(ByVal Value As String)
            If Value Is Nothing Then
                m_EmptyMessage = String.Empty
            Else
                m_EmptyMessage = Value.Trim()
            End If
            If Me.Items.Count = 0 Then
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Property ColumnSorter() As ListViewColumnSorter
        Get
            Return _ColumnSorter
        End Get
        Set(ByVal Value As ListViewColumnSorter)
            _ColumnSorter = Value
        End Set
    End Property

    Public Property ColumnType(ByVal ColumnIndex As Integer) As SortType
        Get
            Return ColumnTypes(ColumnIndex)
        End Get
        Set(ByVal Value As SortType)
            ColumnTypes(ColumnIndex) = Value
        End Set
    End Property

#End Region

#Region "Component Designer generated code"

    Public Sub New()

        MyBase.New()

        ' This call is required by the Component Designer.

        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        _ColumnSorter = New ListViewColumnSorter
    End Sub

    'Control overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Control Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

#Region "Drawing"

    Private Const WM_PAINT As Integer = &HF

    Private Const LVM_FIRST As Integer = &H1000
    Private Const LVM_INSERTITEMA As Integer = LVM_FIRST + 7
    Private Const LVM_INSERTITEMW As Integer = LVM_FIRST + 77
    Private Const LVM_GETHEADER As Integer = LVM_FIRST + 31

    Private Const WM_NOTIFY As Integer = &H4E
    Private Const HDN_FIRST As Integer = 0 - 300
    Private Const HDN_BEGINTRACKA As Integer = HDN_FIRST - 6
    Private Const HDN_BEGINTRACKW As Integer = HDN_FIRST - 26
    Private Const HDN_TRACKA As Integer = HDN_FIRST - 8
    Private Const HDN_TRACKW As Integer = HDN_FIRST - 28
    Private Const HDN_ENDTRACKA As Integer = HDN_FIRST - 7
    Private Const HDN_ENDTRACKW As Integer = HDN_FIRST - 27

    <StructLayout(LayoutKind.Sequential)>
    Public Structure NMHDR
        Public hwndFrom As IntPtr
        Public idFrom As Integer
        Public code As Integer
    End Structure

    Private Declare Auto Function SendMessage Lib "user32"(ByVal hWnd As IntPtr, ByVal wMsg As Integer,
                                                           ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr
    Private Declare Function GetWindowRect Lib "user32"(ByVal hwnd As IntPtr, ByRef rect As RECT) As Long

    <StructLayout(LayoutKind.Sequential)>
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    Private IsTracking As Boolean = False

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        If Me.Items.Count > 0 OrElse EmptyMessage.Length = 0 Then
            MyBase.WndProc(m)
            ' Invalidate after end track
            If m.Msg = WM_NOTIFY Then
                Dim hdr As NMHDR = CType(m.GetLParam(GetType(NMHDR)), NMHDR)
                If hdr.code = HDN_ENDTRACKA OrElse hdr.code = HDN_ENDTRACKW Then
                    Me.Invalidate()
                End If
            End If
            Return
        End If

        If Me.Items.Count = 0 Then
            If m.Msg = LVM_INSERTITEMA OrElse m.Msg = LVM_INSERTITEMW Then
                Me.Invalidate()
            ElseIf m.Msg = WM_NOTIFY Then
                Dim hdr As NMHDR = CType(m.GetLParam(GetType(NMHDR)), NMHDR)
                If hdr.code = HDN_BEGINTRACKA OrElse hdr.code = HDN_BEGINTRACKW Then
                    IsTracking = True
                ElseIf hdr.code = HDN_ENDTRACKA OrElse hdr.code = HDN_ENDTRACKW Then
                    IsTracking = False
                    Me.Invalidate()
                End If
            End If
        End If

        MyBase.WndProc(m)

        If Me.Items.Count = 0 AndAlso Not IsTracking Then
            If m.Msg = WM_PAINT Then
                Dim rc As New RectangleF
                rc.X = DisplayRectangle.X + 8
                rc.Y = DisplayRectangle.Y + (MyHeader.Height + 8)
                rc.Height = DisplayRectangle.Height - (MyHeader.Height + 8)
                rc.Width = DisplayRectangle.Width - 16
                Dim br As New SolidBrush(ForeColor)
                Dim sf As New StringFormat
                sf.Alignment = StringAlignment.Center
                Dim g As Graphics = Graphics.FromHwnd(Me.Handle)
                g.FillRectangle(SystemBrushes.Window, DisplayRectangle)
                g.DrawString(EmptyMessage, Me.Font, br, rc, sf)
                g.Dispose()
            End If
        End If
    End Sub

    Private Sub MyListView_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        If Me.Items.Count = 0 Then
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnColumnClick(ByVal e As System.Windows.Forms.ColumnClickEventArgs)

        If (e.Column = _ColumnSorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (_ColumnSorter.Order = SortOrder.Ascending) Then
                _ColumnSorter.Order = SortOrder.Descending
            Else
                _ColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            _ColumnSorter.SortColumn = e.Column
            _ColumnSorter.Order = SortOrder.Ascending
        End If

        ' Set the column sort type to date for selected names.
        If ColumnType(e.Column) = Nothing Then
            _ColumnSorter.ColumnType = SortType.StringCompare
        Else
            _ColumnSorter.ColumnType = ColumnType(e.Column)
        End If

        ' Perform the sort with these new sort options.

        Me.ListViewItemSorter = _ColumnSorter

        Me.Sort()

        Me.ListViewItemSorter = Nothing
    End Sub

    Private MyHeader As Header

    Private Sub ListViewEx_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.HandleCreated

        MyHeader = New Header(Me)
    End Sub

#End Region

#Region "Header"

    Private Class Header
        Inherits NativeWindow

        Private MyListView As ListView

        Public Sub New(ByVal ListView As ListView)

            MyListView = ListView

            Me.AssignHandle(SendMessage(MyListView.Handle, LVM_GETHEADER, 0, 0))
        End Sub

        Public ReadOnly Property Height() As Integer

            Get
                Dim rc As New RECT
                GetWindowRect(Me.Handle, rc)
                Return rc.bottom - rc.top
            End Get
        End Property
    End Class

#End Region
End Class

#Region "ListViewColumnSorter"

Public Enum SortType
    StringCompare = 1
    DateCompare = 2
    NumericCompare = 3
End Enum

Public Class ListViewColumnSorter
    Implements System.Collections.IComparer

    Protected ColumnToSort As Integer
    Protected OrderOfSort As SortOrder
    Protected TypeOfSort As SortType
    Protected ObjectCompare As CaseInsensitiveComparer


    Public Sub New()
        ' Initialize the column to '0'.
        ColumnToSort = 0

        ' Initialize the sort order to 'none'.
        OrderOfSort = SortOrder.None

        ' Initialize the sort type to 'string'.
        TypeOfSort = SortType.StringCompare

        ' Initialize the CaseInsensitiveComparer object.
        ObjectCompare = New CaseInsensitiveComparer
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim compareResult As Integer
        Dim listviewX As ListViewItem
        Dim listviewY As ListViewItem

        ' Cast the objects to be compared to ListViewItem objects.
        listviewX = CType(x, ListViewItem)
        listviewY = CType(y, ListViewItem)

        ' Compare the two items.
        Select Case TypeOfSort
            Case SortType.StringCompare
                compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text,
                                                      listviewY.SubItems(ColumnToSort).Text)
            Case SortType.DateCompare
                Dim itemx As String = listviewX.SubItems(ColumnToSort).Text
                Dim itemy As String = listviewY.SubItems(ColumnToSort).Text
                If itemx = "" Then itemx = Date.MinValue.ToShortDateString
                If itemy = "" Then itemy = Date.MinValue.ToShortDateString
                compareResult = ObjectCompare.Compare(CType(itemx, Date), CType(itemy, Date))
            Case SortType.NumericCompare
                compareResult = ObjectCompare.Compare(CType(listviewX.SubItems(ColumnToSort).Text, Double),
                                                      CType(listviewY.SubItems(ColumnToSort).Text, Double))
        End Select

        ' Calculate the correct return value based on the object 
        ' comparison.
        If (OrderOfSort = SortOrder.Ascending) Then
            ' Ascending sort is selected, return typical result of 
            ' compare operation.
            Return compareResult
        ElseIf (OrderOfSort = SortOrder.Descending) Then
            ' Descending sort is selected, return negative result of 
            ' compare operation.
            Return (- compareResult)
        Else
            ' Return '0' to indicate that they are equal.
            Return 0
        End If
    End Function

    Public Property SortColumn() As Integer
        Set(ByVal Value As Integer)
            ColumnToSort = Value
        End Set

        Get
            Return ColumnToSort
        End Get
    End Property

    Public Property Order() As SortOrder
        Set(ByVal Value As SortOrder)
            OrderOfSort = Value
        End Set

        Get
            Return OrderOfSort
        End Get
    End Property

    Public Property ColumnType() As SortType
        Get
            Return TypeOfSort
        End Get
        Set(ByVal Value As SortType)
            TypeOfSort = Value
        End Set
    End Property
End Class

#End Region
