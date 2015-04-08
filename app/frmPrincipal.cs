using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using clases.configuraciones;
using clases;

namespace app
{
    public partial class frmPrincipal : Form
    {
        
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void pbPersonal_Click(object sender, EventArgs e)
        {
            frmPersonal persona = new frmPersonal();
            persona.MdiParent = this;
            persona.Show();

        }

        private void lbAreas_Click(object sender, EventArgs e)
        {
            frmAreas area = new frmAreas();
            area.MdiParent = this;
            area.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lecturadeArchivo();
            cPublica.ArchivosGlovales.cadena=textos[0].ToString();
            cPublica.ArchivosGlovales.valorInicial= textos[1].ToString();

        }


        private object[] textos = new object[3];
        /// <summary>
        /// MTODO PARA LEER ARCHIVO DE TEXTO PLANO
        /// </summary>
        public void lecturadeArchivo()
        {
            int counter = 0;
            string line;
            try
            {
                // Read the file and display it line by line.
                StreamReader file = new System.IO.StreamReader(@"archivo.txt");
                while ((line = file.ReadLine()) != null)
                {
                    textos[counter] = line;
                    counter++;
                }

                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo de texto plano: "+ex.Message);
            }
           
        }

        private void agenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgencia agencia = new frmAgencia();
            agencia.MdiParent = this;
            agencia.Show();
        }

        private void lbModalidad_Click(object sender, EventArgs e)
        {
            frmModalidad modalidad = new frmModalidad();
            modalidad.MdiParent = this;
            modalidad.Show();
        }

        private void tiposDePermisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoPermiso tipopermiso = new frmTipoPermiso();
            tipopermiso.MdiParent = this;
            tipopermiso.Show();
        }

        private void dispositivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReloj reloj = new frmReloj();
            reloj.MdiParent = this;
            reloj.Show();
        } 



    }
}
