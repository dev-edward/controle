Imports System.Data.SqlClient
Public Class tabpages
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Dim label As New Label With {
        .Text = "Nenhum registro foi encontrado ",
        .Location = New Point(0, 60),
        .TextAlign = ContentAlignment.MiddleCenter
    }
    Dim dt As New DataTable
    Dim cs As New System.Windows.Forms.DataGridViewCellStyle With {
        .BackColor = Color.Azure
    }
    Dim WithEvents tabpg As New TabPage With {
        .BorderStyle = BorderStyle.Fixed3D,
        .Margin = New Padding(0, 0, 0, 0)
        }
    Dim dgv_tabpg As New DataGridView With {
        .Dock = DockStyle.Fill,
        .RowHeadersVisible = False,
        .AllowUserToAddRows = False,
        .AllowUserToDeleteRows = False,
        .AllowUserToOrderColumns = True,
        .AllowUserToResizeRows = False,
        .AlternatingRowsDefaultCellStyle = cs
    }
    'dgv_tabpg.EditMode = DataGridViewEditMode.EditProgrammatically
    'dgv_tabpg.Columns(0).ReadOnly = False
    'dgv_tabpg.Columns(1).ReadOnly = True


    Sub New(ByVal _tabela As String, ByVal _titulo As String)
        tabpg.Text = _titulo
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "select * from " & _tabela

            conexao.Open()

            myReader = consulta.ExecuteReader()

            If myReader.HasRows Then
                dt.Load(myReader)

                tabpg.Controls.Add(dgv_tabpg)

                dgv_tabpg.AutoGenerateColumns = True
                dgv_tabpg.DataSource = dt
                dgv_tabpg.Refresh()

                For Each dc As DataGridViewColumn In dgv_tabpg.Columns
                    If dc.Index > 0 Then
                        dc.ReadOnly = True
                    End If
                Next
            Else
                tabpg.Controls.Add(label)
            End If
            myReader.Close()
        Catch ex As Exception
            MessageBox.Show("Error while connecting to SQL Server." & ex.Message)
        Finally
            conexao.Close()
        End Try

        Principal.tabCentro.TabPages.Add(tabpg)

    End Sub
    Private Sub tabpg_alteralargura(sender As Object, e As EventArgs) Handles tabpg.SizeChanged
        label.Width = tabpg.Width
    End Sub

End Class
