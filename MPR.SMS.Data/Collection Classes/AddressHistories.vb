'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of AddressHistory objects.
''' </summary>

    Public Class AddressHistories
    Inherits CollectionBase

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistoryHistory</see> object at the specified index within
    '''     the collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> object at the specified index in the collection.
    ''' </value>

        Default Public ReadOnly Property Item(Index As Integer) As AddressHistory
        Get
            Return CType(List.Item(Index), AddressHistory)
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> object to the end of the AddressHistoryes
    '''     collection.
    ''' </summary>
    ''' <param name="objAddressHistory">
    '''     The <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> object has been
    '''     added.
    ''' </returns>

        Public Function Add(objAddressHistory As AddressHistory) As Integer

        Return List.Add(objAddressHistory)
    End Function

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the AddressHistories collection for a <see cref="T:MPR.SMS.Data.Case">Case</see>.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> that the AddressHistories collection belongs to.
    ''' </param>

        Friend Sub New(objCase As [Case])

        mobjCase = objCase

        If mobjCase.CaseID.IsNull Then
            Return
        End If

        ' Retrieve all AddressHistories for the case

        Dim objAddressHistory As New TblAddressHistory()

        objAddressHistory.CaseID = mobjCase.CaseID

        objAddressHistory.ConnectionString = mobjCase.Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If mobjCase.Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objAddressHistory.ConnectionProvider = mobjCase.Project.ConnectionProvider
        End If

        Dim objAddressHistories As DataTable = objAddressHistory.SelectAllWCaseIDLogic()

        objAddressHistory.ConnectionProvider = Nothing

        ' Add a new AddressHistory object to the collection for each LocatingHistory retrieved  

        Dim objDataRow As DataRow

        For Each objDataRow In objAddressHistories.Rows
            Add(New AddressHistory(mobjCase, objDataRow))
        Next
    End Sub

#End Region
End Class
