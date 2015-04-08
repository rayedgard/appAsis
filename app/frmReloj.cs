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
    public partial class frmReloj : Form
    {

        /// <summary>
        /// REFERENCIAS GLOBALES
        /// </summary>
        cReloj reloj = new cReloj();
        cRelojRepositorio relojr= new cRelojRepositorio();
        cValidacion validarDatos;


        public frmReloj()
        {
            validarDatos = new cValidacion();
            InitializeComponent();
        }


        /// <summary>
        /// Declaramos el repositorio de Area
        /// </summary>
        private void Actualizar()
        {
            dgvDatos.DataSource = relojr.consultar();
            tbIp.Text = "192.168.1.201";
            tbNombre.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            reloj.ipreloj = tbIp.Text;
            reloj.nombre = tbNombre.Text;

            try
            {
                relojr.insertar(reloj);
                MessageBox.Show("SE GUARDARON LOS DATOS SATISFACTORIAMENTE: ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GUARDAR LOS DATOS: " + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount > 0)
            {
                try
                {

                    cReloj temporal = relojr.retornarPorId(Convert.ToInt32(dgvDatos.CurrentRow.Cells[0].Value));
                    relojr.eliminar(temporal);
                    MessageBox.Show("SE ELIMINARON LOS DATOS CON EXITO: ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Actualizar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR LOS DATOS: " + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            reloj = relojr.retornarPorId(Convert.ToInt32(dgvDatos.CurrentRow.Cells[0].Value));
            reloj.ipreloj = tbIp.Text;
            reloj.nombre = tbNombre.Text;

            try
            {
                relojr.modificar(reloj);
                MessageBox.Show("SE MODIFICARON LOS DATOS SATISFACTORIAMENTE: ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL MODIFICAR LOS DATOS: " + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReloj_Load(object sender, EventArgs e)
        {
            Actualizar();
        }




        #region -----------validaciones-------------------



        private void validarIp(object sender, KeyPressEventArgs e)
        {
            validarDatos.texto_KeyPress(((TextBox)sender).Text, "TipoIP", sender, e);
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

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbIp.Text = dgvDatos.CurrentRow.Cells[1].Value.ToString();
            tbNombre.Text = dgvDatos.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
