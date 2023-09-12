'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data


Public Class frmBatchInstrumentType

#Region "Private Fields"

    Dim mobjInstrumentType As InstrumentType
    Dim ReadOnly menmBatchType As Data.Enumerations.BatchType

#End Region

#Region "Public Properties"

    Public ReadOnly Property InstrumentType As InstrumentType
        Get
            Return mobjInstrumentType
        End Get
    End Property

#End Region

#Region "Constructors"

    Public Sub New(enmBatchType As Data.Enumerations.BatchType)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        menmBatchType = enmBatchType
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmBatchInstrumentType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtInstruments As DataTable = Nothing

        ' get InstrumentTypes 
        Try
            dtInstruments = Batch.InstrumentTypesDT(menmBatchType)
        Catch ex As Exception
            Dim strMsg As String = "Unable to retrieve InstrumentTypes from database." + Environment.NewLine +
                                   "If problem persists, please notify technical support." + Environment.NewLine +
                                   Environment.NewLine +
                                   "[Error Details]" + Environment.NewLine +
                                   ex.Message
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DialogResult = DialogResult.Cancel
            Me.Close() '>>>>
        End Try

        If (dtInstruments Is Nothing) OrElse (dtInstruments.Rows.Count = 0) Then
            MessageBox.Show("No instruments available for mail receipt.", Project.ShortName & " – Select Instrument",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.Cancel
            Me.Close() '>>>>
        Else
            ' bind
            BindingSource_InstrumentType.DataSource = dtInstruments
            With lstInstruments
                .DisplayMember = "Description"
                .ValueMember = "InstrumentTypeID"
                .SelectedIndex = 0
            End With
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim intInstrumentTypeID As Integer = CInt(lstInstruments.SelectedValue)
        ' instantiate the InstrumentType
        Dim objInstrumentTypes As InstrumentTypes = Project.InstrumentTypes
        mobjInstrumentType = objInstrumentTypes.GetByID(GetSafeValue(intInstrumentTypeID))
    End Sub

    Private Sub lstInstruments_DoubleClick(sender As Object, e As EventArgs) Handles lstInstruments.DoubleClick
        If lstInstruments.SelectedIndex >= 0 Then
            If btnOK.Enabled Then btnOK.PerformClick()
        End If
    End Sub


#End Region
End Class