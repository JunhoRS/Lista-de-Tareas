using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lista_de_Tareas
{
    public partial class Form1 : Form
    {
        // Add these lines inside the Form1 class, after InitializeComponent();
        private ComboBox cmbBackgroundColor;
        private ComboBox cmbFontSize;
        private Button btnApplyConfig;


        public Form1()
        {

            InitializeComponent();

        }
        private void BtnApplyConfig_Click(object sender, EventArgs e)
        {
            // Get the selected background color and font size from the ComboBoxes
            string selectedColor = cmbBackgroundColor.SelectedItem.ToString();
            int selectedFontSize = int.Parse(cmbFontSize.SelectedItem.ToString());

            // Apply the selected background color to the DataGridView
            dataGridViewTareas.BackgroundColor = Color.FromName(selectedColor);

            // Apply the selected font size to the DataGridView's font
            dataGridViewTareas.Font = new Font(dataGridViewTareas.Font.FontFamily, selectedFontSize);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cmbBackgroundColor = new ComboBox();
            cmbBackgroundColor.Items.AddRange(new string[] { "White", "LightGray", "LightBlue", "Yellow" }); // Add color options
            cmbBackgroundColor.SelectedIndex = 0; // Set default background color

            cmbFontSize = new ComboBox();
            cmbFontSize.Items.AddRange(new string[] { "8", "10", "12", "14", "16", "18", "20" }); // Add font size options
            cmbFontSize.SelectedIndex = 2; // Set default font size

            btnApplyConfig = new Button();
            btnApplyConfig.Text = "Apply Configurations";
            btnApplyConfig.Click += BtnApplyConfig_Click; // Event handler for apply configurations button

            // Add the controls to your form's controls collection and set their positions
            // You can set the positions as per your form layout.
            cmbBackgroundColor.Location = new Point(10, 450);
            cmbFontSize.Location = new Point(150, 450);
            btnApplyConfig.Location = new Point(300, 450);

            this.Controls.Add(cmbBackgroundColor);
            this.Controls.Add(cmbFontSize);
            this.Controls.Add(btnApplyConfig);

            dataGridViewTareas.Columns.Add("Id", "ID");
            dataGridViewTareas.Columns.Add("Titulo", "Título");
            dataGridViewTareas.Columns.Add("Descripcion", "Descripción");
            dataGridViewTareas.Columns.Add("Completada", "Completada");


            CargarTareas();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
              GuardarTareas();
        }
        private void btnAgregarTarea_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Server=DESKTOP-7FTGLP1; database=dblistatareas; Integrated security = true");
            conexion.Open();
            string titulo = txtTitulo.Text;
            string descripcion = txtDescripcion.Text;
            bool completada = chkCompletada.Checked ? true : false;
            string cadena = "INSERT INTO Tareas (Titulo, Descripcion, Completada) VALUES (@Titulo, @Descripcion, @Completada)";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@Titulo", titulo);
            comando.Parameters.AddWithValue("@Descripcion", descripcion);
            comando.Parameters.AddWithValue("@Completada", completada);

            comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se ingresaron de forma satisfactoria");


            conexion.Close();
            CargarTareas();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void CargarTareas()
        {
            try
            {
                dataGridViewTareas.Rows.Clear();
                lstTareasCompletadas.Items.Clear();

                using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-7FTGLP1; database=dblistatareas; Integrated security=true"))
                {
                    conexion.Open();
                    string consulta = "SELECT Id, Titulo, Descripcion, Completada FROM Tareas";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                    DataTable tablaTareas = new DataTable();
                    adaptador.Fill(tablaTareas);

                    foreach (DataRow fila in tablaTareas.Rows)
                    {
                        int id = Convert.ToInt32(fila["Id"]);
                        string titulo = fila["Titulo"] != DBNull.Value ? fila["Titulo"].ToString() : string.Empty;
                        string descripcion = fila["Descripcion"] != DBNull.Value ? fila["Descripcion"].ToString() : string.Empty;
                        bool completada = fila["Completada"] != DBNull.Value && Convert.ToBoolean(fila["Completada"]);

                        int rowIndex = dataGridViewTareas.Rows.Add(id, titulo, descripcion, completada);

                        if (completada)
                        {
                            dataGridViewTareas.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                            lstTareasCompletadas.Items.Add(titulo);
                        }
                    }

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las tareas: " + ex.Message);
            }
        }


        private void dataGridViewTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.ColumnIndex == dataGridViewTareas.Columns["Completada"].Index && e.RowIndex >= 0)
                {

                    bool completada = (bool)dataGridViewTareas.Rows[e.RowIndex].Cells["Completada"].Value;

                    completada = !completada;

                    // Obtener el Id y el título de la tarea de la fila seleccionada
                    int idTarea = (int)dataGridViewTareas.Rows[e.RowIndex].Cells["Id"].Value;
                    string tituloTarea = dataGridViewTareas.Rows[e.RowIndex].Cells["Titulo"].Value.ToString();
                    using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-7FTGLP1; database=dblistatareas; Integrated security = true"))
                    {
                        string consulta = "UPDATE Tareas SET Completada = @Completada WHERE Id = @Id";
                        SqlCommand comando = new SqlCommand(consulta, conexion);
                        comando.Parameters.AddWithValue("@Completada", completada);
                        comando.Parameters.AddWithValue("@Id", idTarea);

                        try
                        {
                            conexion.Open();
                            int filasActualizadas = comando.ExecuteNonQuery();
                            if (filasActualizadas > 0)
                            {
                                if (completada)
                                {
                                    MessageBox.Show("Tarea marcada como completada correctamente.");
                                    // Mueve el título de la tarea completada al ListBox
                                    lstTareasCompletadas.Items.Add(tituloTarea);
                                }
                                else
                                {
                                    MessageBox.Show("Tarea marcada como pendiente correctamente.");
                                    lstTareasCompletadas.Items.Remove(tituloTarea);
                                    CargarTareas();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al marcar la tarea como completada: " + ex.Message);
                        }
                    }

                }
            }

        }

        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
            if (dataGridViewTareas.SelectedRows.Count > 0)
            {
                int idTarea = Convert.ToInt32(dataGridViewTareas.SelectedRows[0].Cells["Id"].Value);

                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar esta tarea?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    SqlConnection conexion = new SqlConnection("Server=DESKTOP-7FTGLP1; database=dblistatareas; Integrated security=true");
                    string consulta = "DELETE FROM Tareas WHERE Id = @Id";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@Id", idTarea);

                    try
                    {
                        conexion.Open();
                        int filasEliminadas = comando.ExecuteNonQuery();
                        if (filasEliminadas > 0)
                        {
                            MessageBox.Show("Tarea eliminada correctamente.");
                            CargarTareas();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la tarea: " + ex.Message);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una tarea para eliminar.", "Tarea no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMarcarCompletada_Click(object sender, EventArgs e)
        {
            if (dataGridViewTareas.SelectedRows.Count > 0)
            {
                int idTarea = Convert.ToInt32(dataGridViewTareas.SelectedRows[0].Cells["Id"].Value);

                using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-7FTGLP1; database=dblistatareas; Integrated security = true"))
                {
                    string consulta = "UPDATE Tareas SET Completada = 1 WHERE Id = @Id";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@Id", idTarea);

                    try
                    {
                        conexion.Open();
                        int filasActualizadas = comando.ExecuteNonQuery();
                        if (filasActualizadas > 0)
                        {
                            MessageBox.Show("Tarea marcada como completada correctamente.");
                            CargarTareas();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al marcar la tarea como completada: " + ex.Message);
                    }
                }
            }
        }

        private void GuardarTareas()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-7FTGLP1; database=dblistatareas; Integrated security=true"))
                {
                    conexion.Open();
                    foreach (DataGridViewRow row in dataGridViewTareas.Rows)
                    {
                        int id = Convert.ToInt32(row.Cells["Id"].Value);
                        string titulo = row.Cells["Titulo"].Value.ToString();
                        string descripcion = row.Cells["Descripcion"].Value.ToString();
                        bool completada = Convert.ToBoolean(row.Cells["Completada"].Value);

                        string existeConsulta = "SELECT COUNT(*) FROM Tareas WHERE Id = @Id";
                        SqlCommand existeComando = new SqlCommand(existeConsulta, conexion);
                        existeComando.Parameters.AddWithValue("@Id", id);
                        int existe = Convert.ToInt32(existeComando.ExecuteScalar());

                        if (existe > 0)
                        {
                            // If the task exists, update it in the database
                            string actualizarConsulta = "UPDATE Tareas SET Titulo = @Titulo, Descripcion = @Descripcion, Completada = @Completada WHERE Id = @Id";
                            SqlCommand actualizarComando = new SqlCommand(actualizarConsulta, conexion);
                            actualizarComando.Parameters.AddWithValue("@Id", id);
                            actualizarComando.Parameters.AddWithValue("@Titulo", titulo);
                            actualizarComando.Parameters.AddWithValue("@Descripcion", descripcion);
                            actualizarComando.Parameters.AddWithValue("@Completada", completada);
                            actualizarComando.ExecuteNonQuery();
                        }
                        else
                        {
                            string insertarConsulta = "INSERT INTO Tareas (Id, Titulo, Descripcion, Completada) VALUES (@Id, @Titulo, @Descripcion, @Completada)";
                            SqlCommand insertarComando = new SqlCommand(insertarConsulta, conexion);
                            insertarComando.Parameters.AddWithValue("@Id", id);
                            insertarComando.Parameters.AddWithValue("@Titulo", titulo);
                            insertarComando.Parameters.AddWithValue("@Descripcion", descripcion);
                            insertarComando.Parameters.AddWithValue("@Completada", completada);
                            insertarComando.ExecuteNonQuery();
                        }
                    }
                    conexion.Close();
                }
                MessageBox.Show("Tareas guardadas correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar las tareas: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
