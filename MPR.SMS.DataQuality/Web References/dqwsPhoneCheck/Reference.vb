﻿'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
'
Namespace dqwsPhoneCheck
    
    'CODEGEN: The optional WSDL extension element 'PolicyReference' from namespace 'http://schemas.xmlsoap.org/ws/2004/09/policy' was not handled.
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="BasicHttpBinding_IService", [Namespace]:="urn:MelissaDataPhoneCheckService")>  _
    Partial Public Class Service
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private doPhoneCheckOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.MPR.SMS.DataQuality.My.MySettings.Default.MPR_SMS_DataQuality_dqwsPhoneCheck1_Service
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event doPhoneCheckCompleted As doPhoneCheckCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:MelissaDataPhoneCheckService/IService/doPhoneCheck", RequestNamespace:="urn:MelissaDataPhoneCheckService", ResponseNamespace:="urn:MelissaDataPhoneCheckService", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function doPhoneCheck(ByVal Request As RequestArray) As ResponseArray
            Dim results() As Object = Me.Invoke("doPhoneCheck", New Object() {Request})
            Return CType(results(0),ResponseArray)
        End Function
        
        '''<remarks/>
        Public Overloads Sub doPhoneCheckAsync(ByVal Request As RequestArray)
            Me.doPhoneCheckAsync(Request, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub doPhoneCheckAsync(ByVal Request As RequestArray, ByVal userState As Object)
            If (Me.doPhoneCheckOperationCompleted Is Nothing) Then
                Me.doPhoneCheckOperationCompleted = AddressOf Me.OndoPhoneCheckOperationCompleted
            End If
            Me.InvokeAsync("doPhoneCheck", New Object() {Request}, Me.doPhoneCheckOperationCompleted, userState)
        End Sub
        
        Private Sub OndoPhoneCheckOperationCompleted(ByVal arg As Object)
            If (Not (Me.doPhoneCheckCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent doPhoneCheckCompleted(Me, New doPhoneCheckCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:mdWebServicePhoneCheck")>  _
    Partial Public Class RequestArray
        
        Private transmissionReferenceField As String
        
        Private customerIDField As String
        
        Private recordField() As RequestArrayRecord
        
        '''<remarks/>
        Public Property TransmissionReference() As String
            Get
                Return Me.transmissionReferenceField
            End Get
            Set
                Me.transmissionReferenceField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property CustomerID() As String
            Get
                Return Me.customerIDField
            End Get
            Set
                Me.customerIDField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("Record")>  _
        Public Property Record() As RequestArrayRecord()
            Get
                Return Me.recordField
            End Get
            Set
                Me.recordField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServicePhoneCheck")>  _
    Partial Public Class RequestArrayRecord
        
        Private recordIDField As String
        
        Private phoneField As String
        
        '''<remarks/>
        Public Property RecordID() As String
            Get
                Return Me.recordIDField
            End Get
            Set
                Me.recordIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Phone() As String
            Get
                Return Me.phoneField
            End Get
            Set
                Me.phoneField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:mdWebServicePhoneCheck")>  _
    Partial Public Class ResponseArray
        
        Private versionField As String
        
        Private transmissionReferenceField As String
        
        Private resultsField As String
        
        Private totalRecordsField As String
        
        Private recordField() As ResponseArrayRecord
        
        '''<remarks/>
        Public Property Version() As String
            Get
                Return Me.versionField
            End Get
            Set
                Me.versionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property TransmissionReference() As String
            Get
                Return Me.transmissionReferenceField
            End Get
            Set
                Me.transmissionReferenceField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Results() As String
            Get
                Return Me.resultsField
            End Get
            Set
                Me.resultsField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property TotalRecords() As String
            Get
                Return Me.totalRecordsField
            End Get
            Set
                Me.totalRecordsField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("Record")>  _
        Public Property Record() As ResponseArrayRecord()
            Get
                Return Me.recordField
            End Get
            Set
                Me.recordField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServicePhoneCheck")>  _
    Partial Public Class ResponseArrayRecord
        
        Private recordIDField As String
        
        Private resultsField As String
        
        Private phoneField As ResponseArrayRecordPhone
        
        '''<remarks/>
        Public Property RecordID() As String
            Get
                Return Me.recordIDField
            End Get
            Set
                Me.recordIDField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Results() As String
            Get
                Return Me.resultsField
            End Get
            Set
                Me.resultsField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Phone() As ResponseArrayRecordPhone
            Get
                Return Me.phoneField
            End Get
            Set
                Me.phoneField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServicePhoneCheck")>  _
    Partial Public Class ResponseArrayRecordPhone
        
        Private areaCodeField As String
        
        Private prefixField As String
        
        Private suffixField As String
        
        Private extensionField As String
        
        Private newAreaCodeField As String
        
        Private latitudeField As String
        
        Private longitudeField As String
        
        Private cityField As String
        
        Private stateField As String
        
        Private countryField As ResponseArrayRecordPhoneCountry
        
        Private timeZoneField As ResponseArrayRecordPhoneTimeZone
        
        '''<remarks/>
        Public Property AreaCode() As String
            Get
                Return Me.areaCodeField
            End Get
            Set
                Me.areaCodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Prefix() As String
            Get
                Return Me.prefixField
            End Get
            Set
                Me.prefixField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Suffix() As String
            Get
                Return Me.suffixField
            End Get
            Set
                Me.suffixField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Extension() As String
            Get
                Return Me.extensionField
            End Get
            Set
                Me.extensionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property NewAreaCode() As String
            Get
                Return Me.newAreaCodeField
            End Get
            Set
                Me.newAreaCodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Latitude() As String
            Get
                Return Me.latitudeField
            End Get
            Set
                Me.latitudeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Longitude() As String
            Get
                Return Me.longitudeField
            End Get
            Set
                Me.longitudeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property City() As String
            Get
                Return Me.cityField
            End Get
            Set
                Me.cityField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property State() As String
            Get
                Return Me.stateField
            End Get
            Set
                Me.stateField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Country() As ResponseArrayRecordPhoneCountry
            Get
                Return Me.countryField
            End Get
            Set
                Me.countryField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property TimeZone() As ResponseArrayRecordPhoneTimeZone
            Get
                Return Me.timeZoneField
            End Get
            Set
                Me.timeZoneField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServicePhoneCheck")>  _
    Partial Public Class ResponseArrayRecordPhoneCountry
        
        Private abbreviationField As String
        
        Private nameField As String
        
        '''<remarks/>
        Public Property Abbreviation() As String
            Get
                Return Me.abbreviationField
            End Get
            Set
                Me.abbreviationField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServicePhoneCheck")>  _
    Partial Public Class ResponseArrayRecordPhoneTimeZone
        
        Private nameField As String
        
        Private codeField As String
        
        '''<remarks/>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Code() As String
            Get
                Return Me.codeField
            End Get
            Set
                Me.codeField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")>  _
    Public Delegate Sub doPhoneCheckCompletedEventHandler(ByVal sender As Object, ByVal e As doPhoneCheckCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class doPhoneCheckCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As ResponseArray
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),ResponseArray)
            End Get
        End Property
    End Class
End Namespace
