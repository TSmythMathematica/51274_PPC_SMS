'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************


Public Class frmPaymentConfirm

#Region "Public Properties"

    Public WriteOnly Property FullName As String
        Set
            lblName.Text = value
        End Set
    End Property

    Public WriteOnly Property FullAddress As String
        Set
            lblAddress.Text = value
        End Set
    End Property

    Public Property BankAccount As String
        Get
            Return txtAccount.Text
        End Get
        Set
            txtAccount.Text = value
        End Set
    End Property

    Public Property CheckAmount As Double
        Get
            Return CType(txtAmount.Text, Double)
        End Get
        Set
            txtAmount.Text = Format(value, "##0.00")
        End Set
    End Property

    Public Property ProjectCode As String
        Get
            Return txtProjectCode.Text
        End Get
        Set
            txtProjectCode.Text = value
        End Set
    End Property

    Public Property TaskCode As String
        Get
            Return txtTaskCode.Text
        End Get
        Set
            txtTaskCode.Text = value
        End Set
    End Property

    Public Property Mode As String
        Get
            Return cboMode.Text
        End Get
        Set
            cboMode.Text = value
        End Set
    End Property

    Public Property ProjectType As String
        Get
            Return txtProjectType.Text
        End Get
        Set
            txtProjectType.Text = value
        End Set
    End Property

    Public Property PaymentType As String
        Get
            Return cboPaymentType.Text
        End Get
        Set
            cboPaymentType.Text = value
        End Set
    End Property

    Public Property Notes As String
        Get
            Return txtNote.Text
        End Get
        Set
            txtNote.Text = value
        End Set
    End Property

#End Region

#Region "Event Handlers"

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

#End Region
End Class
