Imports System.Data.SqlClient
Public Class teste
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Dim cs As New System.Windows.Forms.DataGridViewCellStyle

    Dim dt = New DataTable()

    Dim id As Integer
    Dim x As Integer

    Private Sub teste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim bmpBG = Bitmap.FromFile("..\..\..\img\background\orig.jpg")
        'Dim newImage = New Bitmap(bmpBG.Width, bmpBG.Height)
        'Dim gr = Graphics.FromImage(newImage)
        'Dim rectBT1 As New RectangleF(0, 200, bmpBG.Width, 200)
        'Dim rectBT2 As New RectangleF(200, 600, bmpBG.Width - 400, 900)
        'recadoBT = ""
        'txt_mensagem.Text

        'gr.DrawImageUnscaled(bmpBG, 0, 0)
        'gr.DrawString("Aviso", fontBT, brushBT, rectBT1, Format)

        'gr.DrawString(recadoBT, fontBT, brushBT, rectBT2, Format)

        'newImage.Save("..\..\..\img\background\newImg.jpg")




        'cs.BackColor = Color.Azure
        'Try
        '    conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

        '    consulta = conexao.CreateCommand
        '    consulta.CommandText = "select * from tb_afazer"

        '    conexao.Open()

        '    myReader = consulta.ExecuteReader()

        '    If myReader.HasRows Then
        '        'myReader.Read()
        '        dt.Load(myReader)

        '    Else
        '        'nenhum registro encontrado
        '    End If
        '    myReader.Close()
        'Catch ex As Exception
        '    MessageBox.Show("Error while connecting to SQL Server." & ex.Message)
        'Finally
        '    conexao.Close()
        'End Try

        'DataGridView1.AutoGenerateColumns = True
        'DataGridView1.DataSource = dt
        'DataGridView1.Refresh()

        'For Each dc As DataGridViewColumn In DataGridView1.Columns
        '    If dc.Index > 0 Then
        '        dc.ReadOnly = True
        '    End If
        'Next

        'DataGridView1.RowHeadersVisible = False
        'DataGridView1.AllowUserToAddRows = False
        ''DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically
        'DataGridView1.AllowUserToDeleteRows = False
        'DataGridView1.AllowUserToOrderColumns = True
        'DataGridView1.AllowUserToResizeRows = False
        'DataGridView1.AlternatingRowsDefaultCellStyle = cs
        'DataGridView1.Columns(0).ReadOnly = False
        ''DataGridView1.Columns(1).ReadOnly = True

        '        e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
        'e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
        'e.DrawFocusRectangle();


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        x += 1
        If x = 1 Then
            TabControl1.TabPages(0).BorderStyle = BorderStyle.FixedSingle
        ElseIf x = 2 Then
            TabControl1.TabPages(0).BorderStyle = BorderStyle.Fixed3D
        ElseIf x = 3 Then
            TabControl1.TabPages(0).BorderStyle = BorderStyle.None
            x = 0
        End If
    End Sub

    'Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
    '    If e.RowIndex >= 0 And e.ColumnIndex > 0 Then
    '        id = DataGridView1(1, e.RowIndex).Value
    '        MsgBox(id)
    '    End If
    'End Sub
End Class