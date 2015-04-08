using clases;
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
    public partial class frmAreas : Form
    {
        /// <summary>
        /// REFERENCIAS GLOBALES
        /// </summary>
        cArea area = new cArea();
        cAreaRepositorio arear = new cAreaRepositorio();
        cValidacion validarDatos;

        public frmAreas()
        {
            
            InitializeComponent();
            validarDatos = new cValidacion();
        }


        /// <summary>
        /// Declaramos el repositorio de Area
        /// </summary>
        private void Actualizar()
        {
            dgvDatos.DataSource = arear.consultar();
            tbDetalle.Text = "";
            tbNombre.Text = "";
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
            area.nombre = tbNombre.Text;
            area.detalle = tbDetalle.Text;

            try
            {
                arear.insertar(area);
                MessageBox.Show("SE GUARDARON LOS DATOS SATISFACTORIAMENTE: ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GUARDAR LOS DATOS: " + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
         

            area = arear.retornarPorId(Convert.ToInt32(dgvDatos.CurrentRow.Cells[0].Value));
            area.nombre = tbNombre.Text;
            area.detalle = tbDetalle.Text;

            try
            {
                arear.modificar(area);
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
                   
                    cArea temporal = arear.retornarPorId(Convert.ToInt32(dgvDatos.CurrentRow.Cells[0].Value));
                    arear.eliminar(temporal);
                    MessageBox.Show("SE ELIMINARON LOS DATOS CON EXITO: ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Actualizar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR LOS DATOS: " + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmAreas_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbNombre.Text=dgvDatos.CurrentRow.Cells[1].Value.ToString();
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
