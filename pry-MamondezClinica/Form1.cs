using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry_MamondezClinica
{
    public partial class frmPrincipal : Form
    {

        especialidades especialidades;
        medicos med;
        DataTable tabla;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                especialidades = new especialidades();
                //Hace que me muestre el nombre de la especialidad
                lstEspecialidad.DisplayMember = "nombre";
                //Hace que retorne el valor nominal de la especialidad
                lstEspecialidad.ValueMember = "especialidad";
                lstEspecialidad.DataSource = especialidades.getAll();
                med = new medicos();
                tabla = med.getAll();
                
            }

            catch ( Exception ex)
            {

                MessageBox.Show("Problemas con la base de datos" , "Error");
                this.Close();
            }


        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            grlMostrar.Rows.Clear();
            int especialidad = Convert.ToInt32(lstEspecialidad.SelectedValue);
            
            DataTable tabla = med.getAll();
            foreach (DataRow fila in tabla.Rows)
            {
                if (Convert.ToInt32(fila["especialidad"])==especialidad)
                {
                    grlMostrar.Rows.Add(fila["matricula"], fila["nombre"], fila["celular"]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2 obj2 = new frm2();
            obj2.ShowDialog();
        }
    }
}
