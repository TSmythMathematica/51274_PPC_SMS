'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

Public Interface IDataquality
    Function ProcessAddresses(Addresses As List(Of DQAddress)) As List(Of ProcessedAddress)
    Function ProcessPhones(Phones As List(Of DQPhone)) As List(Of ProcessedPhone)
    Function ProcessNames(Names As List(Of DQName)) As List(Of ProcessedName)
    Function ProcessNamesVB(ByRef Names As List(Of DQName)) As List(Of ProcessedName)

    Event BatchProgressUpdate As EventHandler(Of BatchProgressArgs)
    Event BatchCancelled()
End Interface
