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
using clases.configuraciones;

namespace app
{
    public partial class frmTipoPermiso : Form
    {

        /// <summary>
        /// REFERENCIAS GLOBALES
        /// </summary>
        cTipoPermiso tipopermiso = new cTipoPermiso();
        cTipoPermisoRepositorio tipopermisor = new cTipoPermisoRepositorio();
        cValidacion validarDatos;


        public frmTipoPermiso()
        {
            validarDatos = new cValidacion();
            InitializeComponent();
        }

        private void frmTipoPermiso_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        /// <summary>
        /// ACTUALIZA TODOS LOS VALOES
        /// </summary>
        private void Actualizar()
        {
            DataSet datos;
            //agregamos la lista a un datagrid
            dgvDatos.DataSource = tipopermisor.consultar();
            //aqui la pasamos los datos de la lista a un dataset
            datos = cConversines.toDataSet(tipopermisor.consultar());

            tbDetalle.Text = "";
            chbConGoce.Checked = false;
            tbNombre.Text = "";
            rbtPermiso.Checked = true;
            tbPeriodo.Text = "0";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tipopermiso.nombre = tbNombre.Text;
            if (chbConGoce.Checked)
                tipopermiso.conGoce = "CON GOCE";
            else
                tipopermiso.conGoce = "SIN GOCE";
            tipopermiso.detalle = tbDetalle.Text;
            
            if(rbtPermiso.Checked)
                tipopermiso.tipo = "PERMISO";
            else
                tipopermiso.tipo = "LICENCIA";

            tipopermiso.limite =Convert.ToInt32(tbPeriodo.Text);
            
            
            try
            {
                tipopermisor.insertar(tipopermiso);
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
            tipopermiso = tipopermisor.retornarPorId(Convert.ToInt32(dgvDatos.CurrentRow.Cells[0].Value));
            tipopermiso.nombre = tbNombre.Text;
            if(chbConGoce.Checked)
                tipopermiso.conGoce = "CON GOCE";
            else
                tipopermiso.conGoce = "SIN GOCE";
            tipopermiso.detalle = tbDetalle.Text;

            if(rbtPermiso.Checked)
                tipopermiso.tipo = "PERMISO";
            else
                tipopermiso.tipo = "LICENCIA";

            tipopermiso.limite = Convert.ToInt32(tbPeriodo.Text);
            

            try
            {
                tipopermisor.modificar(tipopermiso);
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

                    cTipoPermiso temporal = tipopermisor.retornarPorId(Convert.ToInt32(dgvDatos.CurrentRow.Cells[0].Value));
                    tipopermisor.eliminar(temporal);
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
            if(dgvDatos.CurrentRow.Cells[2].Value.ToString() == "CON GOCE")
                chbConGoce.Checked = true;
            else
                chbConGoce.Checked = false;

            tbDetalle.Text = dgvDatos.CurrentRow.Cells[3].Value.ToString();
            
            if(dgvDatos.CurrentRow.Cells[4].Value.ToString() == "PERMISO")
                rbtPermiso.Checked = true;
            if(dgvDatos.CurrentRow.Cells[4].Value.ToString() == "LICENCIA")
                rbtLicencia.Checked = true;
            tbPeriodo.Text = dgvDatos.CurrentRow.Cells[5].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
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
