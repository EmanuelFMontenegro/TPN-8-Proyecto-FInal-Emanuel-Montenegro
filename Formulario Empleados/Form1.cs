using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario_Empleados
{
    public partial class FormEmpleados : Form
    {
       
        public FormEmpleados()
        {
            InitializeComponent();
            
        }

        
        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            
            cargar();
            dgvEmpleados.Columns[0].Visible = false;

        }
        private void cargar()
        {
            EmpleadoConexion conexion = new EmpleadoConexion();
            dgvEmpleados.DataSource = conexion.ListarEmpleados();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            NuevoEmpleado btnAgregar = new NuevoEmpleado();
            btnAgregar.Text = "Agregar Empleado";
            btnAgregar.ShowDialog();
            cargar();
        }

        public void btnModificar_Click(object sender, EventArgs e)
        {

            
            Empleado empleado;
            empleado = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;

            NuevoEmpleado modificar = new NuevoEmpleado(empleado);
            modificar.Text = "Modificar Empleado";
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea elimiar?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            EmpleadoConexion conexion = new EmpleadoConexion();
            Empleado empleado = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
            conexion.eliminar(empleado.Id);
            MessageBox.Show("Eliminado correctamente");
            cargar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Empleado empleado;
            empleado = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;

            NuevoEmpleado modificar = new NuevoEmpleado(empleado);
            if (empleado.NombreCompleto!=null) {
                
                TxtBuscar.Text = empleado.NombreCompleto;

            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
