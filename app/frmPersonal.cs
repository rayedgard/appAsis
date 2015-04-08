using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clases.Entidades;
using clases.Repositorios;
using clases.configuraciones;

namespace app
{
    public partial class frmPersonal : Form
    {

        /// <summary>
        /// REFERENCIAS GLOBALES
        /// </summary>
        cEmpleado empleado = new cEmpleado();
        cEmpleadoRepositorio empleadoR = new cEmpleadoRepositorio();
        cPersona persona = new cPersona();
        cPersonaRepositorio personaR = new cPersonaRepositorio();
        cAgenciaRepositorio agenciar = new cAgenciaRepositorio();
        cModalidadRepositorio modalidadr = new cModalidadRepositorio();
        cAreaRepositorio arear = new cAreaRepositorio();
        cValidacion validarDatos;

        
       


        public frmPersonal()
        {
            
            InitializeComponent();
            validarDatos = new cValidacion();
        }

        private void pbGuardar_Click(object sender, EventArgs e)
        {
            
            

            persona.dni = Convert.ToInt32(tbDNI.Text);
            persona.nombre = tbNombres.Text.ToString();
            persona.paterno = tbPaterno.Text.ToString();
            persona.materno = tbMaterno.Text.ToString();
            if(rbMasculino.Checked)
                persona.sexo='M';
            else
                persona.sexo='F';

            persona.nacimiento = dtFechaNacimiento.Value;
            persona.ocupacion = tbProfesion.Text.ToString();
            persona.email = tbEmail.Text.ToString();
            persona.telefono = tbTelefono.Text.ToString();
            persona.direccion = tbDireccion.Text.ToString();

            empleado.dni = Convert.ToInt32(tbDNI.Text);
            empleado.idAgecia = (cAgencia)cbAgencia.SelectedValue;
            empleado.idArea= (cArea)cbAreasTrabajo.SelectedValue;
            empleado.idModalidad = (cModalidad)cbModalidadContrato.SelectedValue;
            empleado.fechaInicio= dtFechaInicio.Value;
            empleado.fechaFin= dtFechaFin.Value;

            try
            {
                personaR.insertar(persona);
                empleadoR.insertar(empleado);
                MessageBox.Show("Se agregaron los datos del personal con exito");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un Error al agregar los datos del personal " + ex.Message);

            }


        }

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            cargaCombos();
        }


        private void cargaCombos()
        {
            //CODIGO PARA CARGAR LOS DATOS DEL COMBO AREA DE TRABAJO
            cbAreasTrabajo.DisplayMember = "nombre";
            cbAreasTrabajo.ValueMember = "id";
            cbAreasTrabajo.DataSource = arear.consultar();

            //CODIGO PARA CARGAR LOS DATOS DEL COMBO AGENCIAS
            cbAgencia.DisplayMember = "nombre";
            cbAgencia.ValueMember = "id";
            cbAgencia.DataSource = agenciar.consultar();

            //CODIGO PARA CARGAR LOS DATOS DEL COMBO MODALIDADES
            cbModalidadContrato.DisplayMember = "nombre";
            cbModalidadContrato.ValueMember = "id";
            cbModalidadContrato.DataSource = modalidadr.consultar();
 
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
