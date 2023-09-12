'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of MobilityCode objects for the Project
''' </summary>

    Public Class MobilityCodes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default MobilityCode within the collection.
    ''' </summary>
    ''' <value>
    '''     The default MobilityCode within the MobilityCodees collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first MobilityCode in the collection or Nothing (null) is no MobilityCodees exist.
    ''' </remarks>

        Public ReadOnly Property DefaultMobilityCode As MobilityCode
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), MobilityCode)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the MobilityCode at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the MobilityCode to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The MobilityCode at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As MobilityCode

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), MobilityCode)
            End If
            Return Nothing
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Case objectbelongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Case object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the MobilityCodees collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The MobilityCodees collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's MobilityCodees

        Dim objMobilityCode As New TlkpMobilityCode

        objMobilityCode.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objMobilityCode.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objMobilityCodees As DataTable = objMobilityCode.SelectAll()

        objMobilityCode.ConnectionProvider = Nothing

        ' Add a new MobilityCode to the collection for each MobilityCode retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objMobilityCodees.Rows
            Add(New MobilityCode(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a MobilityCode to the MobilityCodees collection.
    ''' </summary>
    ''' <param name="objMobilityCode">
    '''     The MobilityCode to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the MobilityCode has been added.
    ''' </returns>
    ''' <remarks>
    '''     MobilityCodees are maintained in ascending order by MobilityCode Code.
    ''' </remarks>

        Public Function Add(objMobilityCode As MobilityCode) As Integer

        If objMobilityCode.MobilityCode.IsNull Then
            If Not objMobilityCode.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingMobilityCode As MobilityCode = CType(List.Item(i), MobilityCode)
            If objMobilityCode.MobilityCode.ToString.ToLower() < objExistingMobilityCode.MobilityCode.ToString.ToLower() _
                Then
                Exit For
            End If
        Next

        List.Insert(i, objMobilityCode)

        Return i
    End Function

    ''' <summary>
    '''     Updates a MobilityCode in the collection.
    ''' </summary>
    ''' <param name="objMobilityCode">
    '''     The MobilityCode object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     MobilityCodees are maintained in ascending order by MobilityCode Code.
    ''' </remarks>

        Public Function Update(objMobilityCode As MobilityCode) As Boolean

        If Not objMobilityCode.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingMobilityCode As MobilityCode = CType(List.Item(i), MobilityCode)
            If objExistingMobilityCode.MobilityCode.ToString = objMobilityCode.MobilityCode.ToString Then
                List.RemoveAt(i)
                Add(objMobilityCode)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the MobilityCode within the collection having a specific ID.
    ''' </summary>
    ''' <param name="strCode">
    '''     The Code of the MobilityCode whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the MobilityCode within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(strCode As String) As Integer


        If strCode > "" Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objMobilityCode As MobilityCode = CType(List.Item(i), MobilityCode)
                If objMobilityCode.MobilityCode.ToString = strCode Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
