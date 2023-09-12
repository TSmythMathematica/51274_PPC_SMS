'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of PersonHistory objects.
''' </summary>

    Public Class PersonHistories
    Inherits CollectionBase

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> object at the specified index within the
    '''     collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> object at the specified index in the collection.
    ''' </value>

        Default Public ReadOnly Property Item(Index As Integer) As PersonHistory
        Get
            Return CType(List.Item(Index), PersonHistory)
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> object to the end of the PersonHistoryes
    '''     collection.
    ''' </summary>
    ''' <param name="objPersonHistory">
    '''     The <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> object has been
    '''     added.
    ''' </returns>

        Public Function Add(objPersonHistory As PersonHistory) As Integer

        Return List.Add(objPersonHistory)
    End Function

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the PersonHistories collection for a <see cref="T:MPR.SMS.Data.Person">Person</see>.
    ''' </summary>
    ''' <param name="objPerson">
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> that the PersonHistories collection belongs to.
    ''' </param>

        Friend Sub New(objPerson As Person)

        If objPerson.MPRID.IsNull Then
            Return
        End If

        mobjCase = objPerson.Case

        ' Retrieve all PersonHistories for the case

        Dim objPersonHistory As New TblPersonHistory()

        objPersonHistory.MPRID = objPerson.MPRID

        objPersonHistory.ConnectionString = mobjCase.Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If mobjCase.Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objPersonHistory.ConnectionProvider = mobjCase.Project.ConnectionProvider
        End If

        Dim objPersonHistories As DataTable = objPersonHistory.SelectAllWMPRIDLogic()

        objPersonHistory.ConnectionProvider = Nothing

        ' Add a new PersonHistory object to the collection for each LocatingHistory retrieved  

        Dim objDataRow As DataRow

        For Each objDataRow In objPersonHistories.Rows
            Add(New PersonHistory(mobjCase, objDataRow))
        Next
    End Sub

#End Region
End Class
