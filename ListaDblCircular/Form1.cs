using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDblCircular
{
    public partial class Form1 : Form
    {
        TLisAsig Lista;
        public Form1()
        {
            Lista = new TLisAsig();
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtNombreAsig.Text == "" || txtCantidadHoras.Text == "")
            {
                MessageBox.Show("ESCRIBA LOS DATOS");
                return;
            }
            else
            {
                Lista.crearLista(txtNombreAsig.Text, int.Parse(txtCantidadHoras.Text));
                txtNombreAsig.Clear(); txtCantidadHoras.Clear();
                txtNombreAsig.Focus();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Lista.vacia()) MessageBox.Show("Error: La lista esta VACIA");
            if (txtNombreAsig.Text == "" || txtCantidadHoras.Text == "")
                MessageBox.Show("No ha seleccionado ningun elemento");
            else
            {
                Lista.eliminarLista(txtNombreAsig.Text);
            }
            txtNombreAsig.Clear();
            txtCantidadHoras.Clear();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            TNodoAsig nodoPrimero;
            nodoPrimero = (TNodoAsig)Lista.getPrimero();
            if (Lista.getPrimero() == null)
            {
                MessageBox.Show("LA LISTA ESTA VACIA");
            }
            else
            {
                Lista.getPrimero();
                txtNombreAsig.Text = nodoPrimero.dameAsig();
                txtCantidadHoras.Text = nodoPrimero.dameHoras().ToString();
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            TNodoAsig nodoUltimo;
            nodoUltimo = (TNodoAsig)Lista.getUltimo();
            if (Lista.getUltimo() == null)
            {
                MessageBox.Show("LA LISTA ESTA VACIA");
            }
            else
            {
                Lista.getUltimo();
                txtNombreAsig.Text = nodoUltimo.dameAsig();
                txtCantidadHoras.Text = nodoUltimo.dameHoras().ToString();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (Lista.BuscarAsig(txtNombreAsig.Text) == true)
            {
                TNodoAsig nodoSiguiente;
                nodoSiguiente = (TNodoAsig)Lista.getProxCursor();
                Lista.getProxCursor();
                txtNombreAsig.Text = nodoSiguiente.dameAsig();
                txtCantidadHoras.Text = nodoSiguiente.dameHoras().ToString();
            }
            else
            {
                MessageBox.Show("NO EXISTE SUCESOR");
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (Lista.BuscarAsig(txtNombreAsig.Text) == true)
            {
                TNodoAsig nodoAnterior;
                nodoAnterior = (TNodoAsig)Lista.getAntCursor();
                Lista.getAntCursor();
                txtNombreAsig.Text = nodoAnterior.dameAsig();
                txtCantidadHoras.Text = nodoAnterior.dameHoras().ToString();
            }
            else
            {
                MessageBox.Show("NO EXISTE ANTECESOR");
            }
        }
    }
}
