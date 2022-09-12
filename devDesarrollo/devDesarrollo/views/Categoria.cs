using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using devDesarrollo.models.Database;
using devDesarrollo.cache;

namespace devDesarrollo.views
{
    public partial class Categoria : Form
    {
        categoria objCategoria;
        bool update = false;
        
        public Categoria()//Constuctor de la clase
        {
            InitializeComponent();
            btnGuardar.Click += guardarClick;
            btnNuevo.Click += nuevoClick;
            btnEditar.Click += editarClick;
            btnEliminar.Click += eliminarClick;
            this.Load += chargeTableCategoria;
           
          
            
        }
        private void chargeTableCategoria(object sender, EventArgs e)
        {
            tableCategoria.DataSource = sourceCategoria;
           
            tunTableCategoria();
        }

        private void eliminarClick(object sender, EventArgs e)
        {
            if(tableCategoria.SelectedRows.Count > 0)
            {
                objCategoria = (categoria)gridView1.GetFocusedRow();

                sessionWork.Delete(objCategoria);
                sessionWork.CommitChanges();
                MessageBox.Show("Datos Eliminados Correctamente!!");
            }
            else
            {
                MessageBox.Show("Elija el elemento a eliminar");
            }
        }

        private void editarClick(object sender, EventArgs e)
        {
           if(tableCategoria.SelectedRows.Count > 0)
            {
                txtNombre.Text = tableCategoria.CurrentRow.Cells[1].Value.ToString();
                txtDescripcion.Text = tableCategoria.CurrentRow.Cells[2].Value.ToString();
                update = true;
            }
            else
            {
                MessageBox.Show("Elija un elemento");
            }
        }

        private void nuevoClick(object sender, EventArgs e)
        {
            Ui.clearTextBoxs(this.Controls);
            update = false;
            txtNombre.Focus();
            tableCategoria.ClearSelection();
        }

        private void guardarClick(object sender, EventArgs e)
        {

            if (txtDescripcion.Text != "" && txtNombre.Text != "") {
                
                if (update)//aqui validamos que la variable update sea verdadera
                {
                    objCategoria = (categoria)gridView1.GetFocusedRow();
                }
                else
                {
                    objCategoria = new categoria(sessionWork);
                }

                objCategoria.nombre = txtNombre.Text.ToUpper();
                objCategoria.descripcion = txtDescripcion.Text.ToUpper();

                sessionWork.Save(objCategoria);
                sessionWork.CommitChanges();
                update = false;
                MessageBox.Show("Datos guardados correctamente!!");
                reloadTable();
                Ui.clearTextBoxs(this.Controls);
            }
            else
            {
                MessageBox.Show("Error campos vacios");
            }
          
        }

        private void reloadTable()
        {
            sourceCategoria.Reload();
        }
        private void tunTableCategoria()
        {
            tableCategoria.ClearSelection();
            tableCategoria.Columns[0].Width = 1;
            tableCategoria.Columns[1].Width = 10;
            tableCategoria.Columns[2].Width = 200;
        }

     
    }
}
