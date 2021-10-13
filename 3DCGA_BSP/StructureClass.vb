'Sub GenerateBSP()
'    Dim p As New TPolygon
'    p = ListFrontFacePolygon(0)
'    Dim BSPTree As New TBSPTree
'    BSPTree.partition = p
'    For i = 1 To ListFrontFacePolygon.Count - 1
'        BSPTree.LP(i) = p
'    Next
'    DoIt(BSPTree)
'End Sub

'Sub DoIt(ByVal T As TBSPTree)
'    If T.partition IsNot Nothing Then
'        T.left = New TBSPTree
'        T.right = New TBSPTree
'        For Each polygon In T.LP

'        Next
'    End If
'End Sub