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
    public partial class frmModalidad : Form
    {

        /// <summary>
        /// REFERENCIAS GLOBALES
        /// </summary>
        cModalidad modalidad = new cModalidad();
        cModalidadRepositorio modalidadr = new cModalidadRepositorio();
        cValidacion validarDatos;

        public frmModalidad()
        {
            InitializeComponent();
            validarDatos = new cValidacion();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            modalidad.nombre = tbNombre.Text;
            modalidad.detalle = tbDetalle.Text;

            try
            {
                modalidadr.insertar(modalidad);
                MessageBox.Show("SE GUARDARON LOS DATOS SATISFACTORIAMENTE: ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GUARDAR LOS DATOS: " + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }




        /// <summary>
        /// ACTUALIZA LOS DATOS DATAGRIVIEW
        /// </summary>
        private void Actualizar()
        {
            dgvDatos.DataSource = modalidadr.consultar();
            tbDetalle.Text = "";
            tbNombre.Text = "";
        }

        private void frmModalidad_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modalidad = modalidadr.retornarPorId(Convert.ToInt32(dgvDatos.CurrentRow.Cells[0].Value));
            modalidad.nombre = tbNombre.Text;
            modalidad.detalle = tbDetalle.Text;

            try
            {
                modalidadr.modificar(modalidad);
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

                    cModalidad temporal = modalidadr.retornarPorId(Convert.ToInt32(dgvDatos.CurrentRow.Cells[0].Value));
                    modalidadr.eliminar(temporal);
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
            tbDetalle.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();
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
