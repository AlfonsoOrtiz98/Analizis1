Public Class Form1
    'Variables de graficacion
    Dim pluma As New Pen(Brushes.Gray, 0.5)
    Dim grafico As Graphics
    Dim px, py, vx, vy As Integer
    Dim camino As Drawing2D.GraphicsPath
    Sub P1()

        Dim dibujo As New Bitmap(Me.pcbGrafico.Size.Width, Me.pcbGrafico.Size.Height)
        pcbGrafico.Image = dibujo
        grafico = Graphics.FromImage(Me.pcbGrafico.Image)
        grafico.FillRectangle(Brushes.White, 0, 0, 345, 306)
        px = pcbGrafico.Width / 2
        py = pcbGrafico.Height / 2
        'Linea x del plano cartesiano
        grafico.DrawLine(Pens.Black, 0, py, pcbGrafico.Width, py)
        'linea y del plano cartesiano
        grafico.DrawLine(Pens.Black, px, 0, px, pcbGrafico.Height)
        'Cuadricula
        For i = 0 To Int(pcbGrafico.Width) Step 7
            grafico.DrawLine(pluma, i, 0, i, pcbGrafico.Height)
        Next
        For i = 0 To Int(pcbGrafico.Height) Step 6
            grafico.DrawLine(pluma, 0, i, pcbGrafico.Width, i)
        Next



        Dim n, pol(,) As Integer
        MsgBox("1.- Ingrese los lados del poligono", 0, "Aviso de llenado")
        n = Val(InputBox("Ingrese la cantidad de lados del poligono: ", "Lados del poligono"))
        'n = n * 2
        n = n
        ReDim pol(n, 1)
        lblPuntos.Text = ""
        For i = 0 To n Step 1
            For j = 0 To 1 Step 1
                If (i = 0) Then
                    pol(i, j) = Val(InputBox("Ingrese valor X Para el punto: " & i + 1, "X " & i + 1))
                    pol(n, j) = pol(i, j)
                ElseIf(i<n)
                    pol(i, j) = Val(InputBox("Ingrese valor X Para el punto: " & i + 1, "X " & i + 1))
                End If
                If j = 0 Then
                    lblPuntos.Text = lblPuntos.Text & "P" & i + 1 & ": " & pol(i, j) & ", "
                Else
                    lblPuntos.Text = lblPuntos.Text & pol(i, j) & vbNewLine
                End If
               
            Next
            If i > 0 Then
                vx = py - pol(i - 1, 1) * 10
                vy = px + pol(i - 1, 0) * 10
                grafico.DrawLine(Pens.Red, vy, vx, px + pol(i, 0) * 10, py - pol(i, 1) * 10)
                pcbGrafico.Image = dibujo
            End If
        Next
        'Productos Cruzados
        Dim p1, p2, con As Integer
        p1 = pol(0, 0) * pol(1, 1)
        con = 1
        For i = 1 To n - 1 Step 1

            If con = 0 Then
                p1 = p1 * pol(i + 1, 1)
                con = 1
            ElseIf con = 1 Then
                p1 = p1 * pol(i + 1, 0)
                con = 0
            End If
        Next
        p2 = pol(n, 1) * pol(n - 1, 0)
        con = 0
        For i = n - 1 To 1 Step -1
            If con = 0 Then
                p2 = p2 * pol(i - 1, 1)
                con = 1
            ElseIf con = 1 Then
                p2 = p2 * pol(i - 1, 0)
                con = 0
            End If
        Next

        lblREsultados.Text = "Productos cruzados 1= " & p1 & vbNewLine & "Preductos cruzados 2 = " & p2
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        P1()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dibujo As New Bitmap(Me.pcbGrafico.Size.Width, Me.pcbGrafico.Size.Height)
        pcbGrafico.Image = dibujo
        grafico = Graphics.FromImage(Me.pcbGrafico.Image)
        grafico.FillRectangle(Brushes.White, 0, 0, 345, 306)
        px = pcbGrafico.Width / 2
        py = pcbGrafico.Height / 2
        'Linea x del plano cartesiano
        grafico.DrawLine(Pens.Black, 0, py, pcbGrafico.Width, py)
        'linea y del plano cartesiano
        grafico.DrawLine(Pens.Black, px, 0, px, pcbGrafico.Height)
        'Cuadricula
        For i = 0 To Int(pcbGrafico.Width) Step 7
            grafico.DrawLine(pluma, i, 0, i, pcbGrafico.Height)
        Next
        For i = 0 To Int(pcbGrafico.Height) Step 6
            grafico.DrawLine(pluma, 0, i, pcbGrafico.Width, i)
        Next
    End Sub
End Class
