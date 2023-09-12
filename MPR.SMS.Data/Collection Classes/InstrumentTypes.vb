'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

Public Class InstrumentTypes
    Inherits CollectionBase

#Region "Public Properties"

    Default Public ReadOnly Property Item(Index As Integer) As InstrumentType
        Get
            If Not Index < Count Then
                Throw New Exception("InstrumentTypes::Item::Supplied index is out of range")
            Else
                Return CType(list.Item(Index), InstrumentType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see>.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see>.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The InstrumentTypes collection constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of the InstrumentTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The InstrumentTypes collection is initialized from the database. This form of the constructor
    '''     is used get all of the InstrumentTypes defined for the Project.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's InstrumentTypes

        Dim objInstrumentType As New TlkpInstrumentType

        objInstrumentType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objInstrumentType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objInstrumentTypes As DataTable = objInstrumentType.SelectAll()

        objInstrumentType.ConnectionProvider = Nothing

        ' Add a new InstrumentType to the collection for each InstrumentType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objInstrumentTypes.Rows
            Add(New InstrumentType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Functions"

    ''' <summary>
    '''     Adds an InstrumentType to the InstrumentTypess collection.
    ''' </summary>
    ''' <param name="objInstrumentType">
    '''     The InstrumentType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the InstrumentType has been added.
    ''' </returns>
    ''' <remarks>
    '''     InstrumentTypes are maintained in ascending order by Description.
    ''' </remarks>

        Public Function Add(objInstrumentType As InstrumentType) As Integer

        If objInstrumentType.InstrumentTypeID.IsNull Then
            If Not objInstrumentType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingInstrumentType As InstrumentType = CType(List.Item(i), InstrumentType)
            If objInstrumentType.InstrumentTypeID.Value() < objExistingInstrumentType.InstrumentTypeID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objInstrumentType)

        Return i
    End Function

    Public Function GetByID(iInstrumentType As Integer) As InstrumentType
        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objInstrumentType As InstrumentType = CType(List.Item(i), InstrumentType)
            If objInstrumentType.InstrumentTypeID.Value = iInstrumentType Then
                Return objInstrumentType
            End If
        Next

        Return Nothing
    End Function

    Public Function IndexOf(iInstrumentType As Integer) As Integer

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objInstrumentType As InstrumentType = CType(List.Item(i), InstrumentType)
            If objInstrumentType.InstrumentTypeID.Value = iInstrumentType Then
                Return i
            End If
        Next

        Return - 1
    End Function

#End Region
End Class