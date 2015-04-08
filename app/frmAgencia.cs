using clases.configuraciones;
using clases.Entidades;
using clases.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
    public partial class frmAgencia : Form
    {
        /// <summary>
        /// REFERENCIAS GLOVALES
        /// </summary>
        private cAgencia agencia = new cAgencia();
        private cAgenciaRepositorio agenciar = new cAgenciaRepositorio();
        cValidacion validarDatos;


        public frmAgencia()
        {
            validarDatos = new cValidacion();
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
          
            agencia.nombre = tbNombre.Text;
            agencia.direccion= tbDireccion.Text;
            agencia.telefono =  tbTelefono.Text;
            try
            {
                agenciar.insertar(agencia);
                MessageBox.Show("SE GUARDARON LOS DATOS SATISFACTORIAMENTE: ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GUARDAR LOS DATOS: " + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }




        /// <summary>
        /// METODO PARA ACTUALIZAR LOS VALORES 
        /// </summary>
        private void Actualizar()
        {
            dgvDatos.DataSource = agenciar.consultar();
            tbNombre.Text = "";
            tbDireccion.Text = "";
            tbTelefono.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            agencia = agenciar.retornarPorId(Convert.ToInt32(dgvDatos.CurrentRow.Cells[0].Value));
            agencia.nombre = tbNombre.Text;
            agencia.direccion= tbDireccion.Text;
            agencia.telefono = tbTelefono.Text;
            try
            {
                agenciar.modificar(agencia);
                MessageBox.Show("SE MODIFICARON LOS DATOS SATISFACTORIAMENTE: ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL MODIFICAR LOS DATOS: " + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount > 0)
            {
                try
                {

                    cAgencia temporal = agenciar.retornarPorId(Convert.ToInt32(dgvDatos.CurrentRow.Cells[0].Value));
                    agenciar.eliminar(temporal);
                    MessageBox.Show("SE ELIMINARON LOS DATOS CON EXITO: ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Actualizar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR LOS DATOS: " + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbNombre.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
            tbDireccion.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();
            tbTelefono.Text = dgvDatos.CurrentRow.Cells[3].Value.ToString();

        }

        private void frmAgencia_Load(object sender, EventArgs e)
        {
            Actualizar();
        }




        #region -----------validaciones-------------------



        private void validaNumeros(object sender, KeyPressEventArgs e)
        {
            validarDatos.texto_KeyPress(((TextBox)sender).Text, "Numeros", sender, e);
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void validaMayuscula(object sender, KeyPressEventArgs e)
        {
            validarDatos.texto_KeyPress(((TextBox)sender).Text, "LetrasNumerosEspacio", sender, e);
            ((TextBox)sender).CharacterCasing = CharacterCasing.Upper;
        }


        #endregion


    }
}
