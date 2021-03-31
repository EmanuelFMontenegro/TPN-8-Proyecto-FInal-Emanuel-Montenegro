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
    public partial class NuevoEmpleado : Form
    {
        private Empleado empleado = null;
        public NuevoEmpleado()
        {
            InitializeComponent();
            empleado = new Empleado();

        }

        public NuevoEmpleado(Empleado a)
        {
            InitializeComponent();
            empleado = a;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void NuevoEmpleado_Load(object sender, EventArgs e)
        {

            if (empleado.Id!= 0)
            {
                TxtNombre.Text = empleado.NombreCompleto;
                TxtDni.Text = empleado.DNI.ToString();
                TxtEdad.Text = empleado.Edad.ToString();
                TxtCasado.Text = empleado.Casado;
                TxtSalario.Text = empleado.Salario.ToString();
                  
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                EmpleadoConexion conexion = new EmpleadoConexion();
                Empleado Empl = new Empleado();

                
                Empl.NombreCompleto = TxtNombre.Text;
                Empl.DNI =int.Parse(TxtDni.Text);
                Empl.Edad = int.Parse(TxtEdad.Text);
                Empl.Casado = TxtCasado.Text;
                Empl.Salario = decimal.Parse(TxtSalario.Text);
                

                if (Empl.Id == 0)
                {
                    conexion.agregar(Empl);
                    MessageBox.Show("Agregado Exitosamente.");
                }
                else
                {
                    conexion.modificar(Empl);
                }



                this.Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Revise los campos numericos, solo adminiten numeros.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error, contacte a su admin y no joda " + ex.ToString());
            }
        }
    }
}
