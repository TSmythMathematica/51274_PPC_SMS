' Generated by the MPR.Data.Access.Wizard on Friday, April 16, 2021, 11:56:41 AM

Imports System
Imports System.Data
Imports System.Reflection
Imports System.Configuration
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Namespace BaseClasses

	''' <summary>
	''' Data Access Error Enumerator
	''' </summary>

	Public Enum DataAccessError
		OK
	End Enum

	''' <summary>
	''' Common Database Access Interface for all derived data access classes.
	''' </summary>

	Public Interface ICommonDBAccess
		Function Insert() As Boolean
		Function Update() As Boolean
		Function Delete() As Boolean
		Function SelectOne() As DataTable
		Function SelectAll() As DataTable
	End Interface

	''' <summary>
	''' Abstract base class for Database Interaction classes.
	''' </summary>

	Public MustInherit Class DBInteractionBase
		Implements IDisposable
		Implements ICommonDBAccess

#Region "Private Fields"

		Private mblnDisposed As Boolean

		Private mstrConnectionString As String

        Private mintModifiedColumnCount As Integer = 0

#End Region

#Region "Protected Fields and Properties"

		Protected mErrorCode As SqlInt32

		Protected mobjSqlConnection As SqlConnection

		Protected mblnConnectionIsLocal As Boolean

		Protected mConnectionProvider As ConnectionProvider

		Protected Property ModifiedColumnCount() As Integer

			Get
				Return mintModifiedColumnCount
			End Get

			Set(ByVal Value As Integer)
				mintModifiedColumnCount =  Value
			End Set

		End Property

#End Region

#Region "Constructors"

		''' <summary>
		''' Creates a new instance of the DBInteractionBase class.
		''' </summary>

		Public Sub New()

			mblnDisposed = False
			mConnectionProvider = Nothing
			mobjSqlConnection = New SqlConnection()
			mblnConnectionIsLocal = True
			mErrorCode = New SqlInt32(DataAccessError.OK)

		End Sub

#End Region

#Region "Public Methods"

		''' <summary>
		''' Implements the IDisposable Dispose method.
		''' </summary>

		Public Overloads Sub Dispose() Implements IDisposable.Dispose

			Dispose(True)

			GC.SuppressFinalize(Me)

		End Sub

		''' <summary>
		''' Implements the Dispose method's functionality.
		''' </summary>

		Protected Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
			If Not mblnDisposed Then
				If isDisposing Then
					If mblnConnectionIsLocal Then
						' // Object is created in this class, so destroy it here.
						mobjSqlConnection.Close()
						mobjSqlConnection.Dispose()
						mblnConnectionIsLocal = True
					End If
					mobjSqlConnection = Nothing
					mConnectionProvider = Nothing
				End If
			End If
			mblnDisposed = True
		End Sub

		''' <summary>
		''' Implements the ICommonDBAccess.Insert() method.
		''' </summary>
		''' <remarks>
		''' Inheriting classes should override this method. If not overridden, an exception is thrown.   
		''' </remarks>

		Public Overridable Function Insert() As Boolean Implements ICommonDBAccess.Insert

			Throw New NotImplementedException()

		End Function

		''' <summary>
		''' Implements the ICommonDBAccess.Delete() method.
		''' </summary>
		''' <remarks>
		''' Inheriting classes should override this method. If not overridden, an exception is thrown.   
		''' </remarks>

		Public Overridable Function Delete() As Boolean Implements ICommonDBAccess.Delete

			Throw New NotImplementedException()

		End Function

		''' <summary>
		''' Implements the ICommonDBAccess.Update() method.
		''' </summary>
		''' <remarks>
		''' Inheriting classes should override this method. If not overridden, an exception is thrown.   
		''' </remarks>

		Public Overridable Function Update() As Boolean Implements ICommonDBAccess.Update

			Throw New NotImplementedException()

		End Function

		''' <summary>
		''' Implements the ICommonDBAccess.SelectOne() method.
		''' </summary>
		''' <remarks>
		''' Inheriting classes should override this method. If not overridden, an exception is thrown.   
		''' </remarks>

		Public Overridable Function SelectOne() As DataTable Implements ICommonDBAccess.SelectOne

			Throw New NotImplementedException()

		End Function

		''' <summary>
		''' Implements the ICommonDBAccess.SelectAll() method.
		''' </summary>
		''' <remarks>
		''' Inheriting classes should override this method. If not overridden, an exception is thrown.   
		''' </remarks>

		Public Overridable Function SelectAll() As DataTable Implements ICommonDBAccess.SelectAll

			Throw New NotImplementedException()

		End Function

#End Region

#Region "Public Properties"

		''' <summary>
		''' Gets or sets the SQL connection string used by the data access classes.
		''' </summary>
		''' <value>
		''' The SQL connection string used by the data access classes.
		''' </value>

		Public Property ConnectionString() As String

			Get
				Return mstrConnectionString
			End Get

			Set(ByVal Value As String)
				mstrConnectionString = Value
				mobjSqlConnection.ConnectionString = mstrConnectionString
			End Set

		End Property

		Public ReadOnly Property ErrorCode() As SqlInt32

			Get
				Return mErrorCode
			End Get

		End Property

		''' <summary>
		''' Sets the connection provider used by the data access classes.
		''' </summary>
		''' <value>
		''' The connection provider used by the data access classes.
		''' </value>

		Public Property ConnectionProvider() As ConnectionProvider
			Get
				Return mConnectionProvider
			End Get

			Set(ByVal Value As ConnectionProvider)

                If Value Is Nothing Then
                    mConnectionProvider = Nothing
                    mblnConnectionIsLocal = True
                    mobjSqlConnection = New SqlConnection()
                    Return
                    ' Throw New ArgumentNullException("MainConnectionProvider", "Nothing passed as value to this property which is not allowed.")
                End If

                ' Retrieve the SqlConnection object, if present and create a  reference to it.
                ' If there is already a MainConnection object referenced by the membervar, destroy
                ' or remove the reference, based on the flag.

                If Not (mobjSqlConnection Is Nothing) Then
                    If mblnConnectionIsLocal Then
                        mobjSqlConnection.Close()
                        mobjSqlConnection.Dispose()
                    End If
                    mobjSqlConnection = Nothing
                End If

                mConnectionProvider = Value
                mblnConnectionIsLocal = False
                mobjSqlConnection = mConnectionProvider.Connection

			End Set

		End Property

        Public ReadOnly Property IsModified() As Boolean
            Get
				Return mintModifiedColumnCount > 0
			End Get
        End Property

#End Region

    End Class

    <AttributeUsage(AttributeTargets.Property, Inherited:=True, _
        AllowMultiple:=False)> _
    Public Class DatabaseAttribute : Inherits System.Attribute

        Public Sub New()

        End Sub

        Private mHasUniqueConstraint As Boolean

        Property HasUniqueConstraint() As Boolean
            Get
                Return mHasUniqueConstraint
            End Get
            Set(ByVal Value As Boolean)
                mHasUniqueConstraint = Value
            End Set
        End Property

        Private mIsComputed As Boolean

        Property IsComputed() As Boolean
            Get
                Return mIsComputed
            End Get
            Set(ByVal Value As Boolean)
                mIsComputed = Value
            End Set
        End Property

        Private mIsForeignKey As Boolean

        Property IsForeignKey() As Boolean
            Get
                Return mIsForeignKey
            End Get
            Set(ByVal Value As Boolean)
                mIsForeignKey = Value
            End Set
        End Property
        
        Private mIsIdentity As Boolean

        Property IsIdentity() As Boolean
            Get
                Return mIsIdentity
            End Get
            Set(ByVal Value As Boolean)
                mIsIdentity = Value
            End Set
        End Property

        Private mIsNullable As Boolean

        Property IsNullable() As Boolean
            Get
                Return mIsNullable
            End Get
            Set(ByVal Value As Boolean)
                mIsNullable = Value
            End Set
        End Property

        Private mIsPrimaryKey As Boolean

        Property IsPrimaryKey() As Boolean
            Get
                Return mIsPrimaryKey
            End Get
            Set(ByVal Value As Boolean)
                mIsPrimaryKey = Value
            End Set
        End Property

        Private mIsRowGUIDColumn As Boolean

        Property IsRowGUIDColumn() As Boolean
            Get
                Return mIsRowGUIDColumn
            End Get
            Set(ByVal Value As Boolean)
                mIsRowGUIDColumn = Value
            End Set
        End Property

        Private mIsTimeStamp As Boolean

        Property IsTimeStamp() As Boolean
            Get
                Return mIsTimeStamp
            End Get
            Set(ByVal Value As Boolean)
                mIsTimeStamp = Value
            End Set
        End Property

        Private mDefaultValue As String

        Property DefaultValue() As String
            
            Get
                Return mDefaultValue
            End Get
            Set(ByVal Value As String)
                mDefaultValue = Value
            End Set

        End Property

    End Class

    Public Class NullValueException : Inherits ArgumentOutOfRangeException

        Public Sub New(ByVal paramName As String, ByVal message As String)

            MyBase.New(paramName, message)

        End Sub

    End Class

End Namespace
