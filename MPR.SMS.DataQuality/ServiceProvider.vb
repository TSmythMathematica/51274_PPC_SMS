'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class ServiceProvider
    Public Function getDataCleaner() As DataQuality
        Return New DataQuality(False, True, GlobalData.Project.GeoCode)
    End Function
End Class
