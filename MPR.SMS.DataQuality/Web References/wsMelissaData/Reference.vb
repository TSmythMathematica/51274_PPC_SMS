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
Namespace wsMelissaData
    
    'CODEGEN: The optional WSDL extension element 'PolicyReference' from namespace 'http://schemas.xmlsoap.org/ws/2004/09/policy' was not handled.
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="BasicHttpBinding_IService", [Namespace]:="urn:MelissaDataAddressCheckService")>  _
    Partial Public Class Service
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private doAddressCheckOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.MPR.SMS.DataQuality.My.MySettings.Default.MPR_SMS_DataQuality_com_melissadata_ws_mdWebServices
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
        Public Event doAddressCheckCompleted As doAddressCheckCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:MelissaDataAddressCheckService/IService/doAddressCheck", RequestNamespace:="urn:MelissaDataAddressCheckService", ResponseNamespace:="urn:MelissaDataAddressCheckService", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function doAddressCheck(ByVal Request As RequestArray) As ResponseArray
            Dim results() As Object = Me.Invoke("doAddressCheck", New Object() {Request})
            Return CType(results(0),ResponseArray)
        End Function
        
        '''<remarks/>
        Public Overloads Sub doAddressCheckAsync(ByVal Request As RequestArray)
            Me.doAddressCheckAsync(Request, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub doAddressCheckAsync(ByVal Request As RequestArray, ByVal userState As Object)
            If (Me.doAddressCheckOperationCompleted Is Nothing) Then
                Me.doAddressCheckOperationCompleted = AddressOf Me.OndoAddressCheckOperationCompleted
            End If
            Me.InvokeAsync("doAddressCheck", New Object() {Request}, Me.doAddressCheckOperationCompleted, userState)
        End Sub
        
        Private Sub OndoAddressCheckOperationCompleted(ByVal arg As Object)
            If (Not (Me.doAddressCheckCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent doAddressCheckCompleted(Me, New doAddressCheckCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class RequestArray
        
        Private transmissionReferenceField As String
        
        Private customerIDField As String
        
        Private optAddressParsedField As String
        
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
        Public Property OptAddressParsed() As String
            Get
                Return Me.optAddressParsedField
            End Get
            Set
                Me.optAddressParsedField = value
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
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class RequestArrayRecord
        
        Private recordIDField As String
        
        Private companyField As String
        
        Private lastNameField As String
        
        Private urbanizationField As String
        
        Private addressLine1Field As String
        
        Private addressLine2Field As String
        
        Private suiteField As String
        
        Private cityField As String
        
        Private stateField As String
        
        Private zipField As String
        
        Private plus4Field As String
        
        Private countryField As String
        
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
        Public Property Company() As String
            Get
                Return Me.companyField
            End Get
            Set
                Me.companyField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property LastName() As String
            Get
                Return Me.lastNameField
            End Get
            Set
                Me.lastNameField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Urbanization() As String
            Get
                Return Me.urbanizationField
            End Get
            Set
                Me.urbanizationField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property AddressLine1() As String
            Get
                Return Me.addressLine1Field
            End Get
            Set
                Me.addressLine1Field = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property AddressLine2() As String
            Get
                Return Me.addressLine2Field
            End Get
            Set
                Me.addressLine2Field = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Suite() As String
            Get
                Return Me.suiteField
            End Get
            Set
                Me.suiteField = value
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
        Public Property Zip() As String
            Get
                Return Me.zipField
            End Get
            Set
                Me.zipField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Plus4() As String
            Get
                Return Me.plus4Field
            End Get
            Set
                Me.plus4Field = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Country() As String
            Get
                Return Me.countryField
            End Get
            Set
                Me.countryField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:mdWebServiceAddress")>  _
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
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecord
        
        Private recordIDField As String
        
        Private resultsField As String
        
        Private addressField As ResponseArrayRecordAddress
        
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
        Public Property Address() As ResponseArrayRecordAddress
            Get
                Return Me.addressField
            End Get
            Set
                Me.addressField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecordAddress
        
        Private companyField As String
        
        Private urbanizationField As ResponseArrayRecordAddressUrbanization
        
        Private address1Field As String
        
        Private address2Field As String
        
        Private suiteField As String
        
        Private privateMailBoxField As String
        
        Private cityField As ResponseArrayRecordAddressCity
        
        Private stateField As ResponseArrayRecordAddressState
        
        Private zipField As String
        
        Private plus4Field As String
        
        Private carrierRouteField As String
        
        Private deliveryPointCodeField As String
        
        Private deliveryPointCheckDigitField As String
        
        Private congressionalDistrictField As String
        
        Private typeField As ResponseArrayRecordAddressType
        
        Private countryField As ResponseArrayRecordAddressCountry
        
        Private addressKeyField As String
        
        Private parsedField As ResponseArrayRecordAddressParsed
        
        '''<remarks/>
        Public Property Company() As String
            Get
                Return Me.companyField
            End Get
            Set
                Me.companyField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Urbanization() As ResponseArrayRecordAddressUrbanization
            Get
                Return Me.urbanizationField
            End Get
            Set
                Me.urbanizationField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Address1() As String
            Get
                Return Me.address1Field
            End Get
            Set
                Me.address1Field = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Address2() As String
            Get
                Return Me.address2Field
            End Get
            Set
                Me.address2Field = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Suite() As String
            Get
                Return Me.suiteField
            End Get
            Set
                Me.suiteField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property PrivateMailBox() As String
            Get
                Return Me.privateMailBoxField
            End Get
            Set
                Me.privateMailBoxField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property City() As ResponseArrayRecordAddressCity
            Get
                Return Me.cityField
            End Get
            Set
                Me.cityField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property State() As ResponseArrayRecordAddressState
            Get
                Return Me.stateField
            End Get
            Set
                Me.stateField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Zip() As String
            Get
                Return Me.zipField
            End Get
            Set
                Me.zipField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Plus4() As String
            Get
                Return Me.plus4Field
            End Get
            Set
                Me.plus4Field = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property CarrierRoute() As String
            Get
                Return Me.carrierRouteField
            End Get
            Set
                Me.carrierRouteField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property DeliveryPointCode() As String
            Get
                Return Me.deliveryPointCodeField
            End Get
            Set
                Me.deliveryPointCodeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property DeliveryPointCheckDigit() As String
            Get
                Return Me.deliveryPointCheckDigitField
            End Get
            Set
                Me.deliveryPointCheckDigitField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property CongressionalDistrict() As String
            Get
                Return Me.congressionalDistrictField
            End Get
            Set
                Me.congressionalDistrictField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Type() As ResponseArrayRecordAddressType
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Country() As ResponseArrayRecordAddressCountry
            Get
                Return Me.countryField
            End Get
            Set
                Me.countryField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property AddressKey() As String
            Get
                Return Me.addressKeyField
            End Get
            Set
                Me.addressKeyField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Parsed() As ResponseArrayRecordAddressParsed
            Get
                Return Me.parsedField
            End Get
            Set
                Me.parsedField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecordAddressUrbanization
        
        Private nameField As String
        
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
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecordAddressCity
        
        Private nameField As String
        
        Private abbreviationField As String
        
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
        Public Property Abbreviation() As String
            Get
                Return Me.abbreviationField
            End Get
            Set
                Me.abbreviationField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecordAddressState
        
        Private nameField As String
        
        Private abbreviationField As String
        
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
        Public Property Abbreviation() As String
            Get
                Return Me.abbreviationField
            End Get
            Set
                Me.abbreviationField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecordAddressType
        
        Private addressField As ResponseArrayRecordAddressTypeAddress
        
        Private zipField As ResponseArrayRecordAddressTypeZip
        
        '''<remarks/>
        Public Property Address() As ResponseArrayRecordAddressTypeAddress
            Get
                Return Me.addressField
            End Get
            Set
                Me.addressField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Zip() As ResponseArrayRecordAddressTypeZip
            Get
                Return Me.zipField
            End Get
            Set
                Me.zipField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecordAddressTypeAddress
        
        Private codeField As String
        
        Private descriptionField As String
        
        '''<remarks/>
        Public Property Code() As String
            Get
                Return Me.codeField
            End Get
            Set
                Me.codeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Description() As String
            Get
                Return Me.descriptionField
            End Get
            Set
                Me.descriptionField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecordAddressTypeZip
        
        Private codeField As String
        
        Private descriptionField As String
        
        '''<remarks/>
        Public Property Code() As String
            Get
                Return Me.codeField
            End Get
            Set
                Me.codeField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Description() As String
            Get
                Return Me.descriptionField
            End Get
            Set
                Me.descriptionField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecordAddressCountry
        
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
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecordAddressParsed
        
        Private streetNameField As String
        
        Private addressRangeField As String
        
        Private suffixField As String
        
        Private directionField As ResponseArrayRecordAddressParsedDirection
        
        Private suiteField As ResponseArrayRecordAddressParsedSuite
        
        Private privateMailboxField As ResponseArrayRecordAddressParsedPrivateMailbox
        
        Private garbageField As String
        
        Private routeServiceField As String
        
        Private lockBoxField As String
        
        Private deliveryInstallationField As String
        
        '''<remarks/>
        Public Property StreetName() As String
            Get
                Return Me.streetNameField
            End Get
            Set
                Me.streetNameField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property AddressRange() As String
            Get
                Return Me.addressRangeField
            End Get
            Set
                Me.addressRangeField = value
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
        Public Property Direction() As ResponseArrayRecordAddressParsedDirection
            Get
                Return Me.directionField
            End Get
            Set
                Me.directionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Suite() As ResponseArrayRecordAddressParsedSuite
            Get
                Return Me.suiteField
            End Get
            Set
                Me.suiteField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property PrivateMailbox() As ResponseArrayRecordAddressParsedPrivateMailbox
            Get
                Return Me.privateMailboxField
            End Get
            Set
                Me.privateMailboxField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Garbage() As String
            Get
                Return Me.garbageField
            End Get
            Set
                Me.garbageField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property RouteService() As String
            Get
                Return Me.routeServiceField
            End Get
            Set
                Me.routeServiceField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property LockBox() As String
            Get
                Return Me.lockBoxField
            End Get
            Set
                Me.lockBoxField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property DeliveryInstallation() As String
            Get
                Return Me.deliveryInstallationField
            End Get
            Set
                Me.deliveryInstallationField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecordAddressParsedDirection
        
        Private postField As String
        
        Private preField As String
        
        '''<remarks/>
        Public Property Post() As String
            Get
                Return Me.postField
            End Get
            Set
                Me.postField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Pre() As String
            Get
                Return Me.preField
            End Get
            Set
                Me.preField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecordAddressParsedSuite
        
        Private rangeField As String
        
        Private nameField As String
        
        '''<remarks/>
        Public Property Range() As String
            Get
                Return Me.rangeField
            End Get
            Set
                Me.rangeField = value
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
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="urn:mdWebServiceAddress")>  _
    Partial Public Class ResponseArrayRecordAddressParsedPrivateMailbox
        
        Private nameField As String
        
        Private rangeField As String
        
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
        Public Property Range() As String
            Get
                Return Me.rangeField
            End Get
            Set
                Me.rangeField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")>  _
    Public Delegate Sub doAddressCheckCompletedEventHandler(ByVal sender As Object, ByVal e As doAddressCheckCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class doAddressCheckCompletedEventArgs
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
