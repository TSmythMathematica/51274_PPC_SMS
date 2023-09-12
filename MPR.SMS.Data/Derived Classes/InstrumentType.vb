'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a InstrumentType object.
''' </summary>

    Public Class InstrumentType
    Inherits TlkpInstrumentType

#Region "Private Vars"

#End Region

#Region "Public Methods"

#End Region

#Region "Public Properties"

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
    '''     The InstrumentType collection constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of the InstrumentType class.
    ''' </summary>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <overloads>
    '''     The InstrumentType collection constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of the InstrumentType class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the InstrumentType is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Public Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString
    End Sub

#End Region
End Class


