'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Module GlobalUserControls
    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property
End Module
