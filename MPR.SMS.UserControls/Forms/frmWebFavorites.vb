'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Collections.ObjectModel
Imports System.Text
Imports Microsoft.VisualBasic.FileIO

Public Class frmWebFavorites

#Region "Private Variables"

    Private mstrSelectedFile As String = ""

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        FillTreeView()
    End Sub

#End Region

#Region "Public Properties"

    Public ReadOnly Property SelectedFile As String
        Get
            Return mstrSelectedFile
        End Get
    End Property

    Public ReadOnly Property SelectedURL As String
        Get
            Return GetINIValue("InternetShortcut", "URL", mstrSelectedFile)
        End Get
    End Property

#End Region

#Region "Private Methods"

    Private Sub FillTreeView()

        Cursor.Current = Cursors.WaitCursor
        TreeView.BeginUpdate()
        TreeView.Nodes.Clear()

        'create the root entry
        Dim nodX As New TreeNode("Favorites", 0, 0)
        nodX.Name = "Favorites"
        TreeView.Nodes.Add(nodX)

        'create children nodes for each URL or Folder
        Dim strPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Favorites)
        FillFavorites(nodX.Nodes, strPath)

        FillDirectories(nodX.Nodes, strPath)

        Cursor.Current = Cursors.Default
        TreeView.EndUpdate()

        nodX.Expand()
    End Sub

    Private Sub FillFavorites(nodes As TreeNodeCollection, strPath As String)

        Dim objFiles As ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(strPath,
                                                                                        SearchOption.SearchTopLevelOnly,
                                                                                        "*.url")

        For Each strFile As String In objFiles

            Dim nodX As New TreeNode(GetLinkName(strFile), 3, 3)
            nodX.Name = strFile
            nodX.Tag = strFile

            nodes.Add(nodX)

        Next
    End Sub

    Private Sub FillDirectories(nodes As TreeNodeCollection, strPath As String)

        Dim objDirs As ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetDirectories(strPath)

        For Each strFile As String In objDirs

            Dim nodX As New TreeNode(GetFolderName(strFile), 1, 2)
            nodX.Name = strFile
            nodX.Tag = ""

            nodes.Add(nodX)

            FillDirectories(nodX.Nodes, strFile)

            FillFavorites(nodX.Nodes, strFile)

        Next
    End Sub

    Private Function GetLinkName(strFile As String) As String

        Dim aSplit() As String
        aSplit = strFile.Split(CChar("\"))

        For Each sTmp As String In aSplit
            If sTmp.Length > 3 AndAlso sTmp.EndsWith("url") Then
                Return sTmp.Substring(0, sTmp.Length - 4)
            End If
        Next
        Return strFile
    End Function

    Private Function GetFolderName(strFile As String) As String

        Dim aSplit() As String
        aSplit = strFile.Split(CChar("\"))

        Return aSplit(aSplit.GetUpperBound(0))
    End Function

#End Region

#Region "INI Wrapper Class"

    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA"(
                                                                                                     lpApplicationName _
                                                                                                        As String,
                                                                                                     lpKeyName As String,
                                                                                                     lpDefault As String,
                                                                                                     lpReturnedString As _
                                                                                                        StringBuilder,
                                                                                                     nSize As Integer,
                                                                                                     lpFileName As _
                                                                                                        String) _
        As Integer
    Const MAX_ENTRY As Integer = 32768

    Public Function GetINIValue(sSection As String, sVariableName As String, sFilename As String) As String
        Try
            Dim sb As New StringBuilder(MAX_ENTRY)
            Return sb.ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function

#End Region

#Region "Event Handlers"

    Private Sub TreeView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TreeView.KeyPress

        If e.KeyChar = ChrW(Keys.Escape) Then
            DialogResult = DialogResult.Cancel
        ElseIf e.KeyChar = ChrW(Keys.Enter) Then
            If TreeView.SelectedNode IsNot Nothing AndAlso
               TreeView.SelectedNode.Tag IsNot Nothing Then
                mstrSelectedFile = TreeView.SelectedNode.Tag.ToString
            Else
                mstrSelectedFile = ""
            End If
            If Not mstrSelectedFile.Equals("") Then
                DialogResult = DialogResult.OK
            End If
        End If
    End Sub

    Private Sub TreeView_LostFocus(sender As Object, e As EventArgs) Handles TreeView.LostFocus

        'DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub TreeView_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) _
        Handles TreeView.NodeMouseClick

        If e.Node IsNot Nothing AndAlso
           e.Node.Tag IsNot Nothing Then
            mstrSelectedFile = e.Node.Tag.ToString
        Else
            mstrSelectedFile = ""
        End If
    End Sub

    Private Sub TreeView_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) _
        Handles TreeView.NodeMouseDoubleClick

        If Not mstrSelectedFile.Equals("") Then
            DialogResult = DialogResult.OK
        End If
    End Sub

#End Region
End Class