using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_Final_de_Programacion_1
{
    public partial class Dormidos : Form
    {
        public Dormidos()
        {
            InitializeComponent();

            Bitmap img = new Bitmap(Application.StartupPath+@"/recursos/img.jpeg");

            this.BackgroundImage = img;

            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void boton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            lugar.Visible = true;
            lugar.Text = "Guatemala";
            nombre = "Guatemala";
            
            
        }
        private void boton2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            lugar.Visible = true;
            lugar.Text = "Progreso";
            nombre = "Progreso";
        }

        private void boton3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            lugar.Visible = true;
            lugar.Text = "Jalapa";
            nombre = "Jalapa";
              
        }
        private void Pedidos_Click(object sender, EventArgs e)
        {
            ordenes.Visible = true;
            panel2.Visible = true;
            parte.Text = nombre;
            parte.Visible = true;
            panel1.Visible = false;
            boton1.Visible = false;
            boton2.Visible = false;
            boton3.Visible = false;
            lugar.Visible = false;
            sucur.Visible = false;

            
            for (int i = 0; i < registro.Id + 1; i++)
            {
                final registro = sucursales[i];
                if (parte.Text==registro.sucursal)
                {
                    listBox1.Items.Add(registro.nombrepizza);
                }
                
            }

            if (jalapaConta > 0)
            {
                if (parte.Text == "Jalapa")
                {
                    int valor = pedidosP.Id;
                    for (int i = 0; i < valor + 1; i++)
                    {
                        final pedidosP = pedidosJalapa[i];

                        miex2 = dataGridView3.Rows.Add();
                        dataGridView3.Rows[miex2].Cells[0].Value = miex2 + 1;
                        dataGridView3.Rows[miex2].Cells[1].Value = pedidosP.nombrepizza;
                        dataGridView3.Rows[miex2].Cells[2].Value = pedidosP.preciopixa;
                        dataGridView3.Rows[miex2].Cells[3].Value = pedidosP.descripcion;
                    }
                }
            }
            if (progresoConta > 0)
            {
                if (parte.Text == "Progreso")
                {
                    int valor = pedidosP.Id;
                    for (int i = 0; i < valor + 1; i++)
                    {
                        final pedidosP = pedidosProgreso[i];

                        miex2 = dataGridView3.Rows.Add();
                        dataGridView3.Rows[miex2].Cells[0].Value = miex2 + 1;
                        dataGridView3.Rows[miex2].Cells[1].Value = pedidosP.nombrepizza;
                        dataGridView3.Rows[miex2].Cells[2].Value = pedidosP.preciopixa;
                        dataGridView3.Rows[miex2].Cells[3].Value = pedidosP.descripcion;
                    }
                }
            }
            if (guatemConta > 0)
            {
                if (parte.Text == "Guatemala")
                {
                    int valor = pedidosP.Id;
                    for (int i = 0; i < valor + 1; i++)
                    {
                        final pedidosP = pedidosGuatemala[i];

                        miex2 = dataGridView3.Rows.Add();
                        dataGridView3.Rows[miex2].Cells[0].Value = miex2 + 1;
                        dataGridView3.Rows[miex2].Cells[1].Value = pedidosP.nombrepizza;
                        dataGridView3.Rows[miex2].Cells[2].Value = pedidosP.preciopixa;
                        dataGridView3.Rows[miex2].Cells[3].Value = pedidosP.descripcion;
                    }
                }
            }
        }
        private void Regresar_Click_1(object sender, EventArgs e)
        {
            ordenes.Visible = false;
            panel2.Visible = false;
            boton1.Visible = true;
            boton2.Visible = true;
            boton3.Visible = true;
            lugar.Visible = true;
            sucur.Visible = true;
            lugar.Visible = false;
            listBox1.Items.Clear();

            dataGridView3.Rows.Clear();

        }

        private void Crear_Click(object sender, EventArgs e)
        {

            miex = dataGridView1.Rows.Add();
            registro = new final(miex, nombre_pizza.Text,precio.Text,descripcion.Text,nombre);
            dataGridView1.Rows[miex].Cells[0].Value = miex + 1;
            dataGridView1.Rows[miex].Cells[1].Value = nombre_pizza.Text;
            dataGridView1.Rows[miex].Cells[2].Value = precio.Text;
            dataGridView1.Rows[miex].Cells[3].Value = descripcion.Text;
            dataGridView1.Rows[miex].Cells[4].Value = nombre;
            sucursales[miex] = registro;
            

            nombre_pizza.Clear();
            precio.Clear();
            descripcion.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            pizzaNombre.Visible = true;
            pizzaNombre.Text = (string)listBox1.Items[listBox1.SelectedIndex];
            for (int i = 0; i < registro.Id + 1; i++)
            {
                final registro = sucursales[i];
                if (pizzaNombre.Text == registro.nombrepizza)
                {
                    descripcionV.Text = registro.descripcion;
                    precios.Text = registro.preciopixa;
                }
            }
        }

        private void ordenar_Click(object sender, EventArgs e)
        {
            string nombre = pizzaNombre.Text;
            string precio = precios.Text;
            string descripcion = descripcionV.Text;
            string ubicacion = parte.Text;

            pizzaNombre.Text = "Nombre de la pizza";
            descripcionV.Text = "Descripcion";
            precios.Text = "Q0.00";

            if (ubicacion == "Jalapa")
            {
                int valor = pedidosP.Id;
                
                pedidosP = new final(miex2, nombre, precio, descripcion, ubicacion);
                pedidosJalapa[miex2] = pedidosP;
                jalapaConta++;

                for (int i = 0; i < valor + 1; i++)
                {
                    final pedidosP = pedidosJalapa[i];

                    miex2 = dataGridView3.Rows.Add();
                    dataGridView3.Rows[miex2].Cells[0].Value = miex2 + 1;
                    dataGridView3.Rows[miex2].Cells[1].Value = pedidosP.nombrepizza;
                    dataGridView3.Rows[miex2].Cells[2].Value = pedidosP.preciopixa;
                    dataGridView3.Rows[miex2].Cells[3].Value = pedidosP.descripcion;
                }

            if (ubicacion == "Progreso")
            {
                
                pedidosP = new final(miex2, nombre, precio, descripcion, ubicacion);
                pedidosProgreso[miex2] = pedidosP;
                progresoConta++;
                for (int i = 0; i < valor + 1; i++)
                    {
                        final pedidosP = pedidosProgreso[i];

                        miex2 = dataGridView3.Rows.Add();
                        dataGridView3.Rows[miex2].Cells[0].Value = miex2 + 1;
                        dataGridView3.Rows[miex2].Cells[1].Value = pedidosP.nombrepizza;
                        dataGridView3.Rows[miex2].Cells[2].Value = pedidosP.preciopixa;
                        dataGridView3.Rows[miex2].Cells[3].Value = pedidosP.descripcion;
                    }
                }


            if (ubicacion == "Guatemala")
            {
                    
                pedidosP = new final(miex2, nombre, precio, descripcion, ubicacion);
                pedidosGuatemala[miex2] = pedidosP;
                guateConta++;

                for (int i = 0; i < valor + 1; i++)
                    {
                        final pedidosP = pedidosGuatemala[i];

                        miex2 = dataGridView3.Rows.Add();
                        dataGridView3.Rows[miex2].Cells[0].Value = miex2 + 1;
                        dataGridView3.Rows[miex2].Cells[1].Value = pedidosP.nombrepizza;
                        dataGridView3.Rows[miex2].Cells[2].Value = pedidosP.preciopixa;
                        dataGridView3.Rows[miex2].Cells[3].Value = pedidosP.descripcion;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alvaro Josue Perez Gomez 0907-20-22218");
                            
        }

        int miex;
        int miex2;
        final[] sucursales = new final[10];
        final registro = new final(0, null, null, null, null);
        final pedidosP = new final(0, null, null, null, null);
        final[] pedidosJalapa = new final[20];
        final[] pedidosProgreso = new final[20];
        final[] pedidosGuatemala = new final[20];

        public string nombrepizza;
        public int jalapaConta = 0;
        public int progresoConta = 0;
        public int guateConta = 0;

    }

    class final
    {

        public int Id = 0;
        public string nombrepizza;
        public string preciopixa;
        public string descripcion;
        public string sucursal;

        public final(int id, string nombrepixas, string preciopixas, string descripcionpixas, string sucursalpixas)
        {
            this.Id = id;
            this.nombrepizza = nombrepixas;
            this.preciopixa = preciopixas;
            this.descripcion = descripcionpixas;
            this.sucursal = sucursalpixas;

        }

    }
}
