'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************


''' <summary>
'''     Provides a strongly typed collection of Case objects.
''' </summary>

    Public Class Cases
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the Case object at the specified index within the collection.
    ''' </summary>
    ''' <value>
    '''     The Case object at the specified index.
    ''' </value>

        Default Public ReadOnly Property Item(Index As Integer) As [Case]
        Get
            Return CType(List.Item(Index), [Case])
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a Case object to the end of the collection.
    ''' </summary>
    ''' <param name="objCase">
    '''     The Case object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the Case object has been added.
    ''' </returns>

        Public Function Add(objCase As [Case]) As Integer

        Return List.Add(objCase)
    End Function

#End Region
End Class
