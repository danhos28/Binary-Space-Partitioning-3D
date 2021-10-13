Public Class Form1
    Public ListPolygon As New List(Of TPolygon)                 'for listing for each polygon
    Public Vinit As New List(Of Tpoint)                         'for saving all the initial points of the polygons
    Public V As New List(Of Tpoint)                             'for saving all the points of the polygons
    Public ListFrontFacePolygon As New List(Of TPolygon)        'for saving all the points of polygons that facing forward   

    Public DOP As Double() = {0, 0, -1}                         'for declaring the DOP
    Public bitMapImage As New Bitmap(560, 400)                  'for declaring bitmap image for drawing on the picture box
    Public draw As Graphics = Graphics.FromImage(bitMapImage)   'for drawing the image
    Public CenterX, CenterY As Double                           'for getting the center of the picturebox St

    Public verticalYM As Double = 0                             'Vertical move 1st object
    Public horizontalXM As Double = 0                           'X axis move 1st object
    Public horizontalZM As Double = 0                           'Z axis move 1st object
    Public verticalYM1 As Double = 0                            'Vertical move 2nd object
    Public horizontalXM1 As Double = 0                          'X axis move 2nd object
    Public horizontalZM1 As Double = 0                          'Z axis move 2nd object
    Dim degreeX As Double = 0                                   'degree for the first object's angle
    Dim degreeY As Double = 0
    Dim degreeZ As Double = 0
    Dim degreeX1 As Double = 0                                  'degree for the 2nd object's angle
    Dim degreeY1 As Double = 0
    Dim degreeZ1 As Double = 0
    Dim angleX As Double                                        'used for the first object's rotation
    Dim angleY As Double
    Dim angleZ As Double
    Dim angleX1 As Double                                       'used for the 2nd object's rotation
    Dim angleY1 As Double
    Dim angleZ1 As Double

    Public r As Double = -0.25                                  'for perspective View -1/Zc   
    Public CentX As Double = 0                                  'for storing the centroid values
    Public CentY As Double = 0
    Public CentZ As Double = 0

    Public abc(2) As Double                                     'storing abc values
    Public listPolyBSP As New List(Of TPolygon)

    Public IntersectPoly As New List(Of TPolygon)

    Public t As Double
    Public t2 As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        CenterX = PBDraw.Width / 2
        CenterY = PBDraw.Height / 2
        insertCoordinate()
        insertPolygon()
        CalcCentroid(0, 3, 4)
        calcVT(0, 3, 0, 0, 0, 0, 0, 0)
        setCentroid()
        CalcCentroid(4, 8, 5)
        calcVT(4, 8, 0, 0, 0, 0, 0, 0)
        backFaceCulling()
        GenerateBSP()
        process1()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        listPolyBSP.Clear()
        If e.KeyCode = Keys.A Then
            If prism.Checked = True Then
                Me.draw.Clear(Color.White)
                horizontalXM -= 0.1
                setCentroid()
                CalcCentroid(0, 3, 4)
                calcVT(0, 3, horizontalXM, verticalYM, horizontalZM, angleX, angleY, angleZ)
                backFaceCulling()
                GenerateBSP()
                process1()
            ElseIf pyr.Checked = True Then
                Me.draw.Clear(Color.White)
                horizontalXM1 -= 0.1
                setCentroid()
                CalcCentroid(4, 8, 5)
                calcVT(4, 8, horizontalXM1, verticalYM1, horizontalZM1, angleX1, angleY1, angleZ1)
                backFaceCulling()
                GenerateBSP()
                process1()
            End If
        ElseIf e.KeyCode = Keys.D Then
            If prism.Checked = True Then
                Me.draw.Clear(Color.White)
                horizontalXM += 0.1
                setCentroid()
                CalcCentroid(0, 3, 4)
                calcVT(0, 3, horizontalXM, verticalYM, horizontalZM, angleX, angleY, angleZ)
                backFaceCulling()
                GenerateBSP()
                process1()
            ElseIf pyr.Checked = True Then
                Me.draw.Clear(Color.White)
                horizontalXM1 += 0.1
                setCentroid()
                CalcCentroid(4, 8, 5)
                calcVT(4, 8, horizontalXM1, verticalYM1, horizontalZM1, angleX1, angleY1, angleZ1)
                backFaceCulling()
                GenerateBSP()
                process1()
            End If
        ElseIf e.KeyCode = Keys.W Then
            If prism.Checked = True Then
                Me.draw.Clear(Color.White)
                horizontalZM += 0.1
                setCentroid()
                CalcCentroid(0, 3, 4)
                calcVT(0, 3, horizontalXM, verticalYM, horizontalZM, angleX, angleY, angleZ)
                backFaceCulling()
                GenerateBSP()
                process1()
            ElseIf pyr.Checked = True Then
                Me.draw.Clear(Color.White)
                horizontalZM1 += 0.1
                setCentroid()
                CalcCentroid(4, 8, 5)
                calcVT(4, 8, horizontalXM1, verticalYM1, horizontalZM1, angleX1, angleY1, angleZ1)
                backFaceCulling()
                GenerateBSP()
                process1()
            End If
        ElseIf e.KeyCode = Keys.S Then
            If prism.Checked = True Then
                Me.draw.Clear(Color.White)
                horizontalZM -= 0.1
                setCentroid()
                CalcCentroid(0, 3, 4)
                calcVT(0, 3, horizontalXM, verticalYM, horizontalZM, angleX, angleY, angleZ)
                backFaceCulling()
                GenerateBSP()
                process1()
            ElseIf pyr.Checked = True Then
                Me.draw.Clear(Color.White)
                horizontalZM1 -= 0.1
                setCentroid()
                CalcCentroid(4, 8, 5)
                calcVT(4, 8, horizontalXM1, verticalYM1, horizontalZM1, angleX1, angleY1, angleZ1)
                backFaceCulling()
                GenerateBSP()
                process1()
            End If
        ElseIf e.KeyCode = Keys.Q Then
            If prism.Checked = True Then
                Me.draw.Clear(Color.White)
                verticalYM += 0.1
                setCentroid()
                CalcCentroid(0, 3, 4)
                calcVT(0, 3, horizontalXM, verticalYM, horizontalZM, angleX, angleY, angleZ)
                backFaceCulling()
                GenerateBSP()
                process1()
            ElseIf pyr.Checked = True Then
                Me.draw.Clear(Color.White)
                verticalYM1 += 0.1
                setCentroid()
                CalcCentroid(4, 8, 5)
                calcVT(4, 8, horizontalXM1, verticalYM1, horizontalZM1, angleX1, angleY1, angleZ1)
                backFaceCulling()
                GenerateBSP()
                process1()
            End If
        ElseIf e.KeyCode = Keys.E Then
            If prism.Checked = True Then
                Me.draw.Clear(Color.White)
                verticalYM -= 0.1
                setCentroid()
                CalcCentroid(0, 3, 4)
                calcVT(0, 3, horizontalXM, verticalYM, horizontalZM, angleX, angleY, angleZ)
                backFaceCulling()
                GenerateBSP()
                process1()
            ElseIf pyr.Checked = True Then
                Me.draw.Clear(Color.White)
                verticalYM1 -= 0.1
                setCentroid()
                CalcCentroid(4, 8, 5)
                calcVT(4, 8, horizontalXM1, verticalYM1, horizontalZM1, angleX1, angleY1, angleZ1)
                backFaceCulling()
                GenerateBSP()
                process1()
            End If
        ElseIf e.KeyCode = Keys.J Then
            If prism.Checked = True Then
                Me.draw.Clear(Color.White)
                degreeY += 3
                angleY = Math.PI * degreeY / 180
                setCentroid()
                CalcCentroid(0, 3, 4)
                calcVT(0, 3, horizontalXM, verticalYM, horizontalZM, angleX, angleY, angleZ)
                backFaceCulling()
                GenerateBSP()
                process1()
            ElseIf pyr.Checked = True Then
                Me.draw.Clear(Color.White)
                degreeY1 += 3
                angleY1 = Math.PI * degreeY1 / 180
                setCentroid()
                CalcCentroid(4, 8, 5)
                calcVT(4, 8, horizontalXM1, verticalYM1, horizontalZM1, angleX1, angleY1, angleZ1)
                backFaceCulling()
                GenerateBSP()
                process1()
            End If
        ElseIf e.KeyCode = Keys.L Then
            If prism.Checked = True Then
                Me.draw.Clear(Color.White)
                degreeY -= 3
                angleY = Math.PI * degreeY / 180
                setCentroid()
                CalcCentroid(0, 3, 4)
                calcVT(0, 3, horizontalXM, verticalYM, horizontalZM, angleX, angleY, angleZ)
                backFaceCulling()
                GenerateBSP()
                process1()
            ElseIf pyr.Checked = True Then
                Me.draw.Clear(Color.White)
                degreeY1 -= 3
                angleY1 = Math.PI * degreeY1 / 180
                setCentroid()
                CalcCentroid(4, 8, 5)
                calcVT(4, 8, horizontalXM1, verticalYM1, horizontalZM1, angleX1, angleY1, angleZ1)
                backFaceCulling()
                GenerateBSP()
                process1()
            End If
        ElseIf e.KeyCode = Keys.I Then
            If prism.Checked = True Then
                Me.draw.Clear(Color.White)
                degreeX -= 3
                angleX = Math.PI * degreeX / 180
                setCentroid()
                CalcCentroid(0, 3, 4)
                calcVT(0, 3, horizontalXM, verticalYM, horizontalZM, angleX, angleY, angleZ)
                backFaceCulling()
                GenerateBSP()
                process1()
            ElseIf pyr.Checked = True Then
                Me.draw.Clear(Color.White)
                degreeX1 -= 3
                angleX1 = Math.PI * degreeX1 / 180
                setCentroid()
                CalcCentroid(4, 8, 5)
                calcVT(4, 8, horizontalXM1, verticalYM1, horizontalZM1, angleX1, angleY1, angleZ1)
                backFaceCulling()
                GenerateBSP()
                process1()
            End If
        ElseIf e.KeyCode = Keys.K Then
            If prism.Checked = True Then
                Me.draw.Clear(Color.White)
                degreeX += 3
                angleX = Math.PI * degreeX / 180
                setCentroid()
                CalcCentroid(0, 3, 4)
                calcVT(0, 3, horizontalXM, verticalYM, horizontalZM, angleX, angleY, angleZ)
                backFaceCulling()
                GenerateBSP()
                process1()
            ElseIf pyr.Checked = True Then
                Me.draw.Clear(Color.White)
                degreeX1 += 3
                angleX1 = Math.PI * degreeX1 / 180
                setCentroid()
                CalcCentroid(4, 8, 5)
                calcVT(4, 8, horizontalXM1, verticalYM1, horizontalZM1, angleX1, angleY1, angleZ1)
                backFaceCulling()
                GenerateBSP()
                process1()
            End If
        ElseIf e.KeyCode = Keys.U Then
            If prism.Checked = True Then
                Me.draw.Clear(Color.White)
                degreeZ += 3
                angleZ = Math.PI * degreeZ / 180
                setCentroid()
                CalcCentroid(0, 3, 4)
                calcVT(0, 3, horizontalXM, verticalYM, horizontalZM, angleX, angleY, angleZ)
                backFaceCulling()
                GenerateBSP()
                process1()
            ElseIf pyr.Checked = True Then
                Me.draw.Clear(Color.White)
                degreeZ1 += 3
                angleZ1 = Math.PI * degreeZ1 / 180
                setCentroid()
                CalcCentroid(4, 8, 5)
                calcVT(4, 8, horizontalXM1, verticalYM1, horizontalZM1, angleX1, angleY1, angleZ1)
                backFaceCulling()
                GenerateBSP()
                process1()
            End If
        ElseIf e.KeyCode = Keys.O Then
            If prism.Checked = True Then
                Me.draw.Clear(Color.White)
                degreeZ -= 3
                angleZ = Math.PI * degreeZ / 180
                setCentroid()
                CalcCentroid(0, 3, 4)
                calcVT(0, 3, horizontalXM, verticalYM, horizontalZM, angleX, angleY, angleZ)
                backFaceCulling()
                GenerateBSP()
                process1()
            ElseIf pyr.Checked = True Then
                Me.draw.Clear(Color.White)
                degreeZ1 -= 3
                angleZ1 = Math.PI * degreeZ1 / 180
                setCentroid()
                CalcCentroid(4, 8, 5)
                calcVT(4, 8, horizontalXM1, verticalYM1, horizontalZM1, angleX1, angleY1, angleZ1)
                backFaceCulling()
                GenerateBSP()
                process1()
            End If
        End If
    End Sub

    '-----------------------------------Procedures and Functions--------------------------------------------

    'matrix multiplication for 3x3
    Public Function matrixMul3x3(ByVal a() As Double, ByVal b() As Double) As Double()
        Dim c(2) As Double
        For i = 0 To 2
            c(i) = b(i) - a(i)
        Next
        Return c
    End Function

    'matrix multiplucation 4x4 * 4x4
    Public Function matrixMul4x4(ByVal a()() As Double, b()() As Double) As Double()()
        Dim temp As Double
        Dim c(3)() As Double
        'create empty multidimension array 4x4
        For i = 0 To 3
            c(i) = New Double(4) {}
        Next
        'multiplying
        For i = 0 To 3
            For j = 0 To 3
                For k = 0 To 3
                    temp += a(i)(k) * b(k)(j)
                Next
                c(i)(j) = temp
                temp = 0
            Next
        Next
        Return c
    End Function

    'matrix multiplication for 1x4
    Public Function matrixMul1x4(ByVal a() As Double, b()() As Double) As Double()
        Dim temp As Double
        Dim c(3) As Double
        'multiplying
        For j = 0 To 3
            For k = 0 To 3
                temp += a(k) * b(k)(j)
            Next
            c(j) = temp
            temp = 0
        Next
        Return c
    End Function

    'calculating CrossProduct
    Public Function crossProd(ByVal a() As Double, ByVal b() As Double) As Double()
        Dim c(2) As Double
        c(0) = a(1) * b(2) - b(1) * a(2)
        c(1) = a(2) * b(0) - b(2) * a(0)
        c(2) = a(0) * b(1) - b(0) * a(1)
        Return c
    End Function

    'calculating DotProduct
    Public Function dotProduct(ByVal a() As Double, ByVal b() As Double) As Double
        Return a(0) * b(0) + a(1) * b(1) + a(2) * b(2)
    End Function

    'calculating Centroid
    Sub CalcCentroid(ByVal Min As Integer, ByVal Max As Integer, ByVal totalVertices As Double)
        For i = Min To Max
            CentX += Vinit(i).x
            CentY += Vinit(i).y
            CentZ += Vinit(i).z
        Next
        CentX = CentX / totalVertices
        CentY = CentY / totalVertices
        CentZ = CentZ / totalVertices
    End Sub

    'for set the Centroid variables back to 0 for another calculation
    Sub setCentroid()
        CentX = 0
        CentY = 0
        CentZ = 0
    End Sub

    'calculating normal vector
    Public Function calculateNormal(v1 As Tpoint, v2 As Tpoint, v3 As Tpoint) As Double()
        Dim vector1(2), vector2(2), normal(2) As Double

        Dim vertices1(2) As Double
        Dim vertices2(2) As Double
        Dim vertices3(2) As Double

        vertices1(0) = v1.x
        vertices1(1) = v1.y
        vertices1(2) = v1.z

        vertices2(0) = v2.x
        vertices2(1) = v2.y
        vertices2(2) = v2.z

        vertices3(0) = v3.x
        vertices3(1) = v3.y
        vertices3(2) = v3.z

        vector1 = matrixMul3x3(vertices1, vertices2)
        vector2 = matrixMul3x3(vertices2, vertices3)

        normal = crossProd(vector1, vector2)

        Return normal
    End Function

    'inserting all the coordinate needed for the polygons
    Sub insertCoordinate()
        'for initial Triangle Prism
        Vinit.Add(New Tpoint)
        Vinit(0).insertVertex(-2, -0.5, -1)
        Vinit.Add(New Tpoint)
        Vinit(1).insertVertex(-1, -0.5, -1)
        Vinit.Add(New Tpoint)
        Vinit(2).insertVertex(-1.5, -0.5, -2)
        Vinit.Add(New Tpoint)
        Vinit(3).insertVertex(-1.5, 0.5, -1.5)


        'for initial Pyramid
        Vinit.Add(New Tpoint)
        Vinit(4).insertVertex(1, -0.5, -1)
        Vinit.Add(New Tpoint)
        Vinit(5).insertVertex(2, -0.5, -1)
        Vinit.Add(New Tpoint)
        Vinit(6).insertVertex(2, -0.5, -2)
        Vinit.Add(New Tpoint)
        Vinit(7).insertVertex(1, -0.5, -2)
        Vinit.Add(New Tpoint)
        Vinit(8).insertVertex(1.5, 0.5, -1.5)

        'for Triangle Prism
        V.Add(New Tpoint)
        V(0).insertVertex(-2, -0.5, -1)
        V.Add(New Tpoint)
        V(1).insertVertex(-1, -0.5, -1)
        V.Add(New Tpoint)
        V(2).insertVertex(-1.5, -0.5, -2)
        V.Add(New Tpoint)
        V(3).insertVertex(-1.5, 0.5, -1.5)


        'for Pyramid
        V.Add(New Tpoint)
        V(4).insertVertex(1, -0.5, -1)
        V.Add(New Tpoint)
        V(5).insertVertex(2, -0.5, -1)
        V.Add(New Tpoint)
        V(6).insertVertex(2, -0.5, -2)
        V.Add(New Tpoint)
        V(7).insertVertex(1, -0.5, -2)
        V.Add(New Tpoint)
        V(8).insertVertex(1.5, 0.5, -1.5)
    End Sub

    'making the index for each polygons with the corresponding points, normal, and color
    Sub insertPolygon()
        'for initial Triangle prism
        ListPolygon.Add(New TPolygon)
        ListPolygon(0).insPoly(0, 1, 3, calculateNormal(Vinit(0), Vinit(1), Vinit(3)), Color.Yellow)
        ListPolygon.Add(New TPolygon)
        ListPolygon(1).insPoly(1, 2, 3, calculateNormal(Vinit(1), Vinit(2), Vinit(3)), Color.Blue)
        ListPolygon.Add(New TPolygon)
        ListPolygon(2).insPoly(3, 2, 0, calculateNormal(Vinit(3), Vinit(2), Vinit(0)), Color.Green)
        ListPolygon.Add(New TPolygon)
        ListPolygon(3).insPoly(0, 2, 1, calculateNormal(Vinit(0), Vinit(2), Vinit(1)), Color.DarkCyan)

        'for initial Pyramid
        ListPolygon.Add(New TPolygon)
        ListPolygon(4).insPoly(4, 5, 8, calculateNormal(Vinit(4), Vinit(5), Vinit(8)), Color.Crimson)
        ListPolygon.Add(New TPolygon)
        ListPolygon(5).insPoly(5, 6, 8, calculateNormal(Vinit(5), Vinit(6), Vinit(8)), Color.DarkSalmon)
        ListPolygon.Add(New TPolygon)
        ListPolygon(6).insPoly(4, 6, 5, calculateNormal(Vinit(4), Vinit(6), Vinit(5)), Color.Green)
        ListPolygon.Add(New TPolygon)
        ListPolygon(7).insPoly(4, 7, 6, calculateNormal(Vinit(4), Vinit(7), Vinit(6)), Color.Chocolate)
        ListPolygon.Add(New TPolygon)
        ListPolygon(8).insPoly(7, 8, 6, calculateNormal(Vinit(7), Vinit(8), Vinit(6)), Color.DarkSeaGreen)
        ListPolygon.Add(New TPolygon)
        ListPolygon(9).insPoly(8, 7, 4, calculateNormal(Vinit(8), Vinit(7), Vinit(4)), Color.Black)

        'for Triangle prism
        ListPolygon.Add(New TPolygon)
        ListPolygon(0).insPoly(0, 1, 3, calculateNormal(V(0), V(1), V(3)), Color.Yellow)
        ListPolygon.Add(New TPolygon)
        ListPolygon(1).insPoly(1, 2, 3, calculateNormal(V(1), V(2), V(3)), Color.Blue)
        ListPolygon.Add(New TPolygon)
        ListPolygon(2).insPoly(3, 2, 0, calculateNormal(V(3), V(2), V(0)), Color.Green)
        ListPolygon.Add(New TPolygon)
        ListPolygon(3).insPoly(0, 2, 1, calculateNormal(V(0), V(2), V(1)), Color.DarkCyan)

        'for Pyramid
        ListPolygon.Add(New TPolygon)
        ListPolygon(4).insPoly(4, 5, 8, calculateNormal(V(4), V(5), V(8)), Color.Crimson)
        ListPolygon.Add(New TPolygon)
        ListPolygon(5).insPoly(5, 6, 8, calculateNormal(V(5), V(6), V(8)), Color.DarkSalmon)
        ListPolygon.Add(New TPolygon)
        ListPolygon(6).insPoly(4, 6, 5, calculateNormal(V(4), V(6), V(5)), Color.Chocolate)
        ListPolygon.Add(New TPolygon)
        ListPolygon(7).insPoly(4, 7, 6, calculateNormal(V(4), V(7), V(6)), Color.Chocolate)
        ListPolygon.Add(New TPolygon)
        ListPolygon(8).insPoly(7, 8, 6, calculateNormal(V(7), V(8), V(6)), Color.DarkSeaGreen)
        ListPolygon.Add(New TPolygon)
        ListPolygon(9).insPoly(8, 7, 4, calculateNormal(V(8), V(7), V(4)), Color.Black)
    End Sub

    'performing back face culling
    Private Sub backFaceCulling()
        Dim dotProd As Double
        Dim n As Integer

        For Each polygon In ListPolygon
            polygon.N = calculateNormal(V(polygon.P1), V(polygon.P2), V(polygon.P3))
            dotProd = dotProduct(DOP, polygon.N)
            If (dotProd < 0) Then
                ListFrontFacePolygon.Add(New TPolygon)
                ListFrontFacePolygon(n) = polygon
                n = n + 1
            End If
        Next
    End Sub

    'transforming into view coordinate system
    Sub calcVT(ByVal Vermin As Integer, ByVal Vermax As Integer, ByVal objX As Double, ByVal objY As Double, ByVal objZ As Double, ByVal rotX As Double, ByVal rotY As Double, ByVal rotZ As Double)
        Dim p(3) As Double
        Dim vt(3)() As Double
        Dim RotateY(3)() As Double 'rotation y
        Dim RotateX(3)() As Double 'rotation x
        Dim RotateZ(3)() As Double 'rotation z
        Dim translateRot(3)() As Double 'for translate to (0,0,0)
        Dim translateBack(3)() As Double 'for translate back after rotation

        translateRot(0) = New Double() {1, 0, 0, 0}
        translateRot(1) = New Double() {0, 1, 0, 0}
        translateRot(2) = New Double() {0, 0, 1, 0}
        translateRot(3) = New Double() {-CentX, -CentY, -CentZ, 1}

        translateBack(0) = New Double() {1, 0, 0, 0}
        translateBack(1) = New Double() {0, 1, 0, 0}
        translateBack(2) = New Double() {0, 0, 1, 0}
        translateBack(3) = New Double() {CentX, CentY, CentZ, 1}

        RotateX(0) = New Double() {1, 0, 0, 0}
        RotateX(1) = New Double() {0, Math.Cos(rotX), Math.Sin(rotX), 0}
        RotateX(2) = New Double() {0, -1 * Math.Sin(rotX), Math.Cos(rotX), 0}
        RotateX(3) = New Double() {0, 0, 0, 1}

        RotateY(0) = New Double() {Math.Cos(rotY), 0, -1 * Math.Sin(rotY), 0}
        RotateY(1) = New Double() {0, 1, 0, 0}
        RotateY(2) = New Double() {Math.Sin(rotY), 0, Math.Cos(rotY), 0}
        RotateY(3) = New Double() {0, 0, 0, 1}

        RotateZ(0) = New Double() {Math.Cos(rotZ), Math.Sin(rotZ), 0, 0}
        RotateZ(1) = New Double() {-1 * Math.Sin(rotZ), Math.Cos(rotZ), 0, 0}
        RotateZ(2) = New Double() {0, 0, 1, 0}
        RotateZ(3) = New Double() {0, 0, 0, 1}

        vt(0) = New Double() {1, 0, 0, 0}
        vt(1) = New Double() {0, 1, 0, 0}
        vt(2) = New Double() {0, 0, 1, r}
        vt(3) = New Double() {objX, objY, objZ, 1 + (r * objZ)}

        For i = Vermin To Vermax
            p(0) = Vinit(i).x
            p(1) = Vinit(i).y
            p(2) = Vinit(i).z
            p(3) = 1

            p = matrixMul1x4(p, translateRot)
            p = matrixMul1x4(p, RotateX)
            p = matrixMul1x4(p, RotateY)
            p = matrixMul1x4(p, RotateZ)
            p = matrixMul1x4(p, translateBack)
            p = matrixMul1x4(p, vt)


            p(0) = p(0) / p(3)
            p(1) = p(1) / p(3)
            p(2) = p(2) / p(3)

            V(i).x = p(0)
            V(i).y = p(1)
            V(i).z = p(2)
        Next
    End Sub

    'drawing The Polygons
    Public Sub drawPolygons()
        Dim Dgraph As New Drawing2D.GraphicsPath

        For Each polygon In listPolyBSP

            Dim point1 As New PointF((V(polygon.P1).x * 75) + CenterX, (-V(polygon.P1).y * 75) + CenterY)
            Dim point2 As New PointF((V(polygon.P2).x * 75) + CenterX, (-V(polygon.P2).y * 75) + CenterY)
            Dim point3 As New PointF((V(polygon.P3).x * 75) + CenterX, (-V(polygon.P3).y * 75) + CenterY)

            Dim PolyPoints As PointF() = {point1, point2, point3}

            Dgraph.AddLine(point1, point2)
            Dgraph.AddLine(point2, point3)
            Dgraph.AddLine(point3, point1)
            'draw.DrawLine(Pens.Black, point1, point2)
            'draw.DrawLine(Pens.Black, point2, point3)
            'draw.DrawLine(Pens.Black, point3, point1)
            draw.FillPolygon(New SolidBrush(polygon.Color), PolyPoints)

        Next
    End Sub

    Sub process1()
        drawPolygons()
        PBDraw.Image = bitMapImage
        ListFrontFacePolygon.Clear()
    End Sub

    Public Function FindABC(ByVal pivot As TPolygon, ByVal Others As TPolygon)
        Dim tempP1(4) As Double
        Dim n(4) As Double
        tempP1(0) = V(pivot.P1).x
        tempP1(1) = V(pivot.P1).y
        tempP1(2) = V(pivot.P1).z
        n = pivot.N
        abc(0) = CSng(((V(Others.P1).x - tempP1(0)) * n(0)) + ((V(Others.P1).y - tempP1(1)) * n(1)) + ((V(Others.P1).z - tempP1(2)) * n(2)))
        abc(1) = CSng(((V(Others.P2).x - tempP1(0)) * n(0)) + ((V(Others.P2).y - tempP1(1)) * n(1)) + ((V(Others.P2).z - tempP1(2)) * n(2)))
        abc(2) = CSng(((V(Others.P3).x - tempP1(0)) * n(0)) + ((V(Others.P3).y - tempP1(1)) * n(1)) + ((V(Others.P3).z - tempP1(2)) * n(2)))
        If Math.Abs(abc(0) - 0) < 0.00001 Then
            abc(0) = 0
        End If
        If Math.Abs(abc(1) - 0) < 0.00001 Then
            abc(1) = 0
        End If
        If Math.Abs(abc(2) - 0) < 0.00001 Then
            abc(2) = 0
        End If
        Return abc
    End Function

    Public Sub cyrusBeck(ByVal surface As TPolygon, ByVal polygon As TPolygon)
        Dim Intersect1(2) As Double
        Dim Intersect2(2) As Double
        Dim last As Integer

        t = (V(surface.P2).x - V(polygon.P1).x) * surface.N(0)
        t += (V(surface.P2).y - V(polygon.P1).y) * surface.N(1)
        t += (V(surface.P2).z - V(polygon.P1).z) * surface.N(2)

        t2 = (V(polygon.P2).x - V(polygon.P1).x) * surface.N(0)
        t2 += (V(polygon.P2).y - V(polygon.P1).y) * surface.N(1)
        t2 += (V(polygon.P2).z - V(polygon.P1).z) * surface.N(2)

        t = t / t2

        Intersect1(0) = V(polygon.P1).x + t * (V(polygon.P2).x - V(polygon.P1).x)
        Intersect1(1) = V(polygon.P1).y + t * (V(polygon.P2).y - V(polygon.P1).y)
        Intersect1(2) = V(polygon.P1).z + t * (V(polygon.P2).z - V(polygon.P1).z)

        t = (V(surface.P2).x - V(polygon.P1).x) * surface.N(0)
        t += (V(surface.P2).y - V(polygon.P1).y) * surface.N(1)
        t += (V(surface.P2).z - V(polygon.P1).z) * surface.N(2)

        t2 = (V(polygon.P3).x - V(polygon.P1).x) * surface.N(0)
        t2 += (V(polygon.P3).y - V(polygon.P1).y) * surface.N(1)
        t2 += (V(polygon.P3).z - V(polygon.P1).z) * surface.N(2)

        t = t / t2

        Intersect2(0) = V(polygon.P1).x + t * (V(polygon.P3).x - V(polygon.P1).x)
        Intersect2(1) = V(polygon.P1).y + t * (V(polygon.P3).y - V(polygon.P1).y)
        Intersect2(2) = V(polygon.P1).z + t * (V(polygon.P3).z - V(polygon.P1).z)

        V.Add(New Tpoint With {.x = V(polygon.P1).x, .y = V(polygon.P1).y, .z = V(polygon.P1).z})
        V.Add(New Tpoint With {.x = Intersect1(0), .y = Intersect1(1), .z = Intersect1(2)})
        V.Add(New Tpoint With {.x = Intersect2(0), .y = Intersect2(1), .z = Intersect2(2)})
        V.Add(New Tpoint With {.x = V(polygon.P2).x, .y = V(polygon.P2).y, .z = V(polygon.P2).z})
        V.Add(New Tpoint With {.x = V(polygon.P3).x, .y = V(polygon.P3).y, .z = V(polygon.P3).z})

        last = V.Count - 1

        IntersectPoly.Add(New TPolygon With {.P1 = last - 4, .P2 = last - 3, .P3 = last - 2, .N = polygon.N, .Color = polygon.Color})
        IntersectPoly.Add(New TPolygon With {.P1 = last - 3, .P2 = last - 1, .P3 = last - 2, .N = polygon.N, .Color = polygon.Color})
        IntersectPoly.Add(New TPolygon With {.P1 = last - 2, .P2 = last - 1, .P3 = last, .N = polygon.N, .Color = polygon.Color})
    End Sub

    Public Sub cyrusBeck2(ByVal surface As TPolygon, ByVal polygon As TPolygon)
        Dim Intersect1(2) As Double
        Dim Intersect2(2) As Double
        Dim last As Integer

        t = (V(surface.P2).x - V(polygon.P2).x) * surface.N(0)
        t += (V(surface.P2).y - V(polygon.P2).y) * surface.N(1)
        t += (V(surface.P2).z - V(polygon.P2).z) * surface.N(2)

        t2 = (V(polygon.P1).x - V(polygon.P2).x) * surface.N(0)
        t2 += (V(polygon.P1).y - V(polygon.P2).y) * surface.N(1)
        t2 += (V(polygon.P1).z - V(polygon.P2).z) * surface.N(2)

        t = t / t2

        Intersect1(0) = V(polygon.P2).x + t * (V(polygon.P1).x - V(polygon.P2).x)
        Intersect1(1) = V(polygon.P2).y + t * (V(polygon.P1).y - V(polygon.P2).y)
        Intersect1(2) = V(polygon.P2).z + t * (V(polygon.P1).z - V(polygon.P2).z)

        t = (V(surface.P2).x - V(polygon.P2).x) * surface.N(0)
        t += (V(surface.P2).y - V(polygon.P2).y) * surface.N(1)
        t += (V(surface.P2).z - V(polygon.P2).z) * surface.N(2)

        t2 = (V(polygon.P3).x - V(polygon.P2).x) * surface.N(0)
        t2 += (V(polygon.P3).y - V(polygon.P2).y) * surface.N(1)
        t2 += (V(polygon.P3).z - V(polygon.P2).z) * surface.N(2)

        t = t / t2

        Intersect2(0) = V(polygon.P2).x + t * (V(polygon.P3).x - V(polygon.P2).x)
        Intersect2(1) = V(polygon.P2).y + t * (V(polygon.P3).y - V(polygon.P2).y)
        Intersect2(2) = V(polygon.P2).z + t * (V(polygon.P3).z - V(polygon.P2).z)

        V.Add(New Tpoint With {.x = V(polygon.P1).x, .y = V(polygon.P1).y, .z = V(polygon.P1).z})
        V.Add(New Tpoint With {.x = Intersect1(0), .y = Intersect1(1), .z = Intersect1(2)})
        V.Add(New Tpoint With {.x = Intersect2(0), .y = Intersect2(1), .z = Intersect2(2)})
        V.Add(New Tpoint With {.x = V(polygon.P2).x, .y = V(polygon.P2).y, .z = V(polygon.P2).z})
        V.Add(New Tpoint With {.x = V(polygon.P3).x, .y = V(polygon.P3).y, .z = V(polygon.P3).z})

        last = V.Count - 1

        IntersectPoly.Add(New TPolygon With {.P1 = last - 3, .P2 = last - 1, .P3 = last - 2, .N = polygon.N, .Color = polygon.Color})
        IntersectPoly.Add(New TPolygon With {.P1 = last - 4, .P2 = last - 3, .P3 = last - 2, .N = polygon.N, .Color = polygon.Color})
        IntersectPoly.Add(New TPolygon With {.P1 = last - 4, .P2 = last - 2, .P3 = last, .N = polygon.N, .Color = polygon.Color})
    End Sub

    Public Sub cyrusBeck3(ByVal surface As TPolygon, ByVal polygon As TPolygon)
        Dim Intersect1(2) As Double
        Dim Intersect2(2) As Double
        Dim last As Integer

        t = (V(surface.P2).x - V(polygon.P1).x) * surface.N(0)
        t += (V(surface.P2).y - V(polygon.P1).y) * surface.N(1)
        t += (V(surface.P2).z - V(polygon.P1).z) * surface.N(2)

        t2 = (V(polygon.P3).x - V(polygon.P1).x) * surface.N(0)
        t2 += (V(polygon.P3).y - V(polygon.P1).y) * surface.N(1)
        t2 += (V(polygon.P3).z - V(polygon.P1).z) * surface.N(2)

        t = t / t2

        Intersect1(0) = V(polygon.P1).x + t * (V(polygon.P3).x - V(polygon.P1).x)
        Intersect1(1) = V(polygon.P1).y + t * (V(polygon.P3).y - V(polygon.P1).y)
        Intersect1(2) = V(polygon.P1).z + t * (V(polygon.P3).z - V(polygon.P1).z)

        t = (V(surface.P2).x - V(polygon.P2).x) * surface.N(0)
        t += (V(surface.P2).y - V(polygon.P2).y) * surface.N(1)
        t += (V(surface.P2).z - V(polygon.P2).z) * surface.N(2)

        t2 = (V(polygon.P3).x - V(polygon.P2).x) * surface.N(0)
        t2 += (V(polygon.P3).y - V(polygon.P2).y) * surface.N(1)
        t2 += (V(polygon.P3).z - V(polygon.P2).z) * surface.N(2)

        t = t / t2

        Intersect2(0) = V(polygon.P2).x + t * (V(polygon.P3).x - V(polygon.P2).x)
        Intersect2(1) = V(polygon.P2).y + t * (V(polygon.P3).y - V(polygon.P2).y)
        Intersect2(2) = V(polygon.P2).z + t * (V(polygon.P3).z - V(polygon.P2).z)

        V.Add(New Tpoint With {.x = V(polygon.P1).x, .y = V(polygon.P1).y, .z = V(polygon.P1).z})
        V.Add(New Tpoint With {.x = Intersect1(0), .y = Intersect1(1), .z = Intersect1(2)})
        V.Add(New Tpoint With {.x = Intersect2(0), .y = Intersect2(1), .z = Intersect2(2)})
        V.Add(New Tpoint With {.x = V(polygon.P2).x, .y = V(polygon.P2).y, .z = V(polygon.P2).z})
        V.Add(New Tpoint With {.x = V(polygon.P3).x, .y = V(polygon.P3).y, .z = V(polygon.P3).z})

        last = V.Count - 1

        IntersectPoly.Add(New TPolygon With {.P1 = last - 3, .P2 = last - 2, .P3 = last, .N = polygon.N, .Color = polygon.Color})
        IntersectPoly.Add(New TPolygon With {.P1 = last - 3, .P2 = last - 2, .P3 = last - 1, .N = polygon.N, .Color = polygon.Color})
        IntersectPoly.Add(New TPolygon With {.P1 = last - 4, .P2 = last - 1, .P3 = last - 3, .N = polygon.N, .Color = polygon.Color})
    End Sub

    Public BSPTree As New TBSPTree
    Sub GenerateBSP()
        Dim p As New TPolygon
        p = ListFrontFacePolygon(0)
        BSPTree.root = New TBSPTree
        BSPTree.root.Partition = p
        For i = 1 To ListFrontFacePolygon.Count - 1
            BSPTree.root.LP.Add(ListFrontFacePolygon(i))
        Next
        DoIt(BSPTree.root)
        inOrder(BSPTree.root)
    End Sub

    Sub DoIt(ByVal T As TBSPTree)
        If T.Partition IsNot Nothing Then
            T.left = New TBSPTree
            T.right = New TBSPTree
            For i = 0 To T.LP.Count - 1
                FindABC(T.Partition, T.LP(i))
                If abc(0) <= 0 And abc(1) <= 0 And abc(2) <= 0 Then
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = T.LP(i)
                    Else
                        T.left.LP.Add(T.LP(i))
                    End If
                ElseIf abc(0) >= 0 And abc(1) >= 0 And abc(2) >= 0 Then
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = T.LP(i)
                    Else
                        T.right.LP.Add(T.LP(i))
                    End If
                    '-----------------------------------------------------
                ElseIf abc(0) > 0 And abc(1) = 0 And abc(2) = 0 Then
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = T.LP(i)
                    Else
                        T.right.LP.Add(T.LP(i))
                    End If
                ElseIf abc(0) > 0 And abc(1) < 0 And abc(2) = 0 Then
                    cyrusBeck(T.Partition, T.LP(i))
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(0)
                    Else
                        T.right.LP.Add(intersectPoly(0))
                    End If

                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(1)
                        T.left.LP.Add(intersectPoly(2))
                    Else
                        T.left.LP.Add(intersectPoly(1))
                        T.left.LP.Add(intersectPoly(2))
                    End If
                ElseIf abc(0) > 0 And abc(1) = 0 And abc(2) < 0 Then
                    cyrusBeck(T.Partition, T.LP(i))
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(0)
                    Else
                        T.right.LP.Add(intersectPoly(0))
                    End If

                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(2)
                        T.left.LP.Add(intersectPoly(1))
                    Else
                        T.left.LP.Add(intersectPoly(1))
                        T.left.LP.Add(intersectPoly(2))
                    End If
                ElseIf abc(0) > 0 And abc(1) < 0 And abc(2) < 0 Then
                    cyrusBeck(T.Partition, T.LP(i))
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(0)
                    Else
                        T.right.LP.Add(intersectPoly(0))
                    End If

                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(1)
                        T.left.LP.Add(intersectPoly(2))
                    Else
                        T.left.LP.Add(intersectPoly(1))
                        T.left.LP.Add(intersectPoly(2))
                    End If
                    '-----------------------------------------------------------------
                ElseIf abc(0) = 0 And abc(1) > 0 And abc(2) = 0 Then
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = T.LP(i)
                    Else
                        T.right.LP.Add(T.LP(i))
                    End If
                ElseIf abc(0) < 0 And abc(1) > 0 And abc(2) = 0 Then
                    cyrusBeck2(T.Partition, T.LP(i))
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(0)
                    Else
                        T.right.LP.Add(intersectPoly(0))
                    End If

                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(1)
                        T.left.LP.Add(intersectPoly(2))
                    Else
                        T.left.LP.Add(intersectPoly(1))
                        T.left.LP.Add(intersectPoly(2))
                    End If
                ElseIf abc(0) = 0 And abc(1) > 0 And abc(2) < 0 Then
                    cyrusBeck2(T.Partition, T.LP(i))
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(0)
                    Else
                        T.right.LP.Add(intersectPoly(0))
                    End If

                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(1)
                        T.left.LP.Add(intersectPoly(2))
                    Else
                        T.left.LP.Add(intersectPoly(1))
                        T.left.LP.Add(intersectPoly(2))
                    End If
                ElseIf abc(0) < 0 And abc(1) > 0 And abc(2) < 0 Then
                    cyrusBeck2(T.Partition, T.LP(i))
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(0)
                    Else
                        T.right.LP.Add(intersectPoly(0))
                    End If

                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(1)
                        T.left.LP.Add(intersectPoly(2))
                    Else
                        T.left.LP.Add(intersectPoly(1))
                        T.left.LP.Add(intersectPoly(2))
                    End If
                    '---------------------------------------------------------------------------
                ElseIf abc(0) = 0 And abc(1) = 0 And abc(2) > 0 Then
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = T.LP(i)
                    Else
                        T.right.LP.Add(T.LP(i))
                    End If
                ElseIf abc(0) < 0 And abc(1) = 0 And abc(2) > 0 Then
                    cyrusBeck3(T.Partition, T.LP(i))
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(0)
                    Else
                        T.right.LP.Add(intersectPoly(0))
                    End If

                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(1)
                        T.left.LP.Add(intersectPoly(2))
                    Else
                        T.left.LP.Add(intersectPoly(1))
                        T.left.LP.Add(intersectPoly(2))
                    End If
                ElseIf abc(0) = 0 And abc(1) < 0 And abc(2) > 0 Then
                    cyrusBeck3(T.Partition, T.LP(i))
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(0)
                    Else
                        T.right.LP.Add(intersectPoly(0))
                    End If

                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(1)
                        T.left.LP.Add(intersectPoly(2))
                    Else
                        T.left.LP.Add(intersectPoly(1))
                        T.left.LP.Add(intersectPoly(2))
                    End If
                ElseIf abc(0) < 0 And abc(1) < 0 And abc(2) > 0 Then
                    cyrusBeck3(T.Partition, T.LP(i))
                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(0)
                    Else
                        T.right.LP.Add(intersectPoly(0))
                    End If

                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(1)
                        T.left.LP.Add(intersectPoly(2))
                    Else
                        T.left.LP.Add(intersectPoly(1))
                        T.left.LP.Add(intersectPoly(2))
                    End If
                    '---------------------------------------------------------------------------
                    '---------------------------------------------------------------------------
                ElseIf abc(0) < 0 And abc(1) = 0 And abc(2) = 0 Then
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = T.LP(i)
                    Else
                        T.left.LP.Add(T.LP(i))
                    End If
                ElseIf abc(0) < 0 And abc(1) > 0 And abc(2) = 0 Then
                    cyrusBeck(T.Partition, T.LP(i))
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(0)
                    Else
                        T.left.LP.Add(intersectPoly(0))
                    End If

                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(1)
                        T.right.LP.Add(intersectPoly(2))
                    Else
                        T.right.LP.Add(intersectPoly(1))
                        T.right.LP.Add(intersectPoly(2))
                    End If
                ElseIf abc(0) < 0 And abc(1) = 0 And abc(2) > 0 Then
                    cyrusBeck(T.Partition, T.LP(i))
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(0)
                    Else
                        T.left.LP.Add(intersectPoly(0))
                    End If

                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(1)
                        T.right.LP.Add(intersectPoly(2))
                    Else
                        T.right.LP.Add(intersectPoly(1))
                        T.right.LP.Add(intersectPoly(2))
                    End If
                ElseIf abc(0) < 0 And abc(1) > 0 And abc(2) > 0 Then
                    cyrusBeck(T.Partition, T.LP(i))
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(0)
                    Else
                        T.left.LP.Add(intersectPoly(0))
                    End If

                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(1)
                        T.right.LP.Add(intersectPoly(2))
                    Else
                        T.right.LP.Add(intersectPoly(1))
                        T.right.LP.Add(intersectPoly(2))
                    End If
                    '-----------------------------------------------------------------
                ElseIf abc(0) = 0 And abc(1) < 0 And abc(2) = 0 Then
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = T.LP(i)
                    Else
                        T.left.LP.Add(T.LP(i))
                    End If
                ElseIf abc(0) > 0 And abc(1) < 0 And abc(2) = 0 Then
                    cyrusBeck2(T.Partition, T.LP(i))
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(0)
                    Else
                        T.left.LP.Add(intersectPoly(0))
                    End If

                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(1)
                        T.right.LP.Add(intersectPoly(2))
                    Else
                        T.right.LP.Add(intersectPoly(1))
                        T.right.LP.Add(intersectPoly(2))
                    End If
                ElseIf abc(0) = 0 And abc(1) < 0 And abc(2) > 0 Then
                    cyrusBeck2(T.Partition, T.LP(i))
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(0)
                    Else
                        T.left.LP.Add(intersectPoly(0))
                    End If

                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(1)
                        T.right.LP.Add(intersectPoly(2))
                    Else
                        T.right.LP.Add(intersectPoly(1))
                        T.right.LP.Add(intersectPoly(2))
                    End If
                ElseIf abc(0) > 0 And abc(1) < 0 And abc(2) > 0 Then
                    cyrusBeck2(T.Partition, T.LP(i))
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(0)
                    Else
                        T.left.LP.Add(intersectPoly(0))
                    End If

                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(1)
                        T.right.LP.Add(intersectPoly(2))
                    Else
                        T.right.LP.Add(intersectPoly(1))
                        T.right.LP.Add(intersectPoly(2))
                    End If
                    '-----------------------------------------------------------------
                ElseIf abc(0) = 0 And abc(1) = 0 And abc(2) < 0 Then
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = T.LP(i)
                    Else
                        T.left.LP.Add(T.LP(i))
                    End If
                ElseIf abc(0) > 0 And abc(1) = 0 And abc(2) < 0 Then
                    cyrusBeck3(T.Partition, T.LP(i))
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(0)
                    Else
                        T.left.LP.Add(intersectPoly(0))
                    End If

                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(1)
                        T.right.LP.Add(intersectPoly(2))
                    Else
                        T.right.LP.Add(intersectPoly(1))
                        T.right.LP.Add(intersectPoly(2))
                    End If
                ElseIf abc(0) = 0 And abc(1) > 0 And abc(2) < 0 Then
                    cyrusBeck3(T.Partition, T.LP(i))
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(0)
                    Else
                        T.left.LP.Add(intersectPoly(0))
                    End If

                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(1)
                        T.right.LP.Add(intersectPoly(2))
                    Else
                        T.right.LP.Add(intersectPoly(1))
                        T.right.LP.Add(intersectPoly(2))
                    End If
                ElseIf abc(0) > 0 And abc(1) > 0 And abc(2) < 0 Then
                    cyrusBeck3(T.Partition, T.LP(i))
                    If T.left.Partition Is Nothing Then
                        T.left.Partition = intersectPoly(0)
                    Else
                        T.left.LP.Add(intersectPoly(0))
                    End If

                    If T.right.Partition Is Nothing Then
                        T.right.Partition = intersectPoly(1)
                        T.right.LP.Add(intersectPoly(2))
                    Else
                        T.right.LP.Add(intersectPoly(1))
                        T.right.LP.Add(intersectPoly(2))
                    End If
                    '-----------------------------------------------------------------           
                End If
                IntersectPoly.Clear()
            Next

            DoIt(T.left)
            DoIt(T.right)
        End If
    End Sub

    Sub inOrder(ByVal part As TBSPTree)
        If part.Partition IsNot Nothing Then
            inOrder(part.left)
            listPolyBSP.Add(part.Partition)
            inOrder(part.right)
        End If
    End Sub
End Class

Public Class TPolygon
    Public P1, P2, P3 As Integer    'storing the points for each surface
    Public N(2) As Double           'storing the Normal for each surface
    Public Color As Color           'storing the color for each surface

    'inserting the surfaces value
    Sub insPoly(ByVal a, ByVal b, ByVal c, ByVal d, ByVal e)
        Me.P1 = a
        Me.P2 = b
        Me.P3 = c
        Me.N = d
        Me.Color = e
    End Sub
End Class

Public Class TBSPTree
    Public Partition As TPolygon
    Public LP As New List(Of TPolygon)
    Public root, left, right As TBSPTree
End Class

Public Class Tpoint
    Public x, y, z As Double    'to store the coordinates

    'inserting the coordinates of each vertex
    Sub insertVertex(ByVal a As Double, ByVal b As Double, ByVal c As Double)
        Me.x = a
        Me.y = b
        Me.z = c
    End Sub
End Class


