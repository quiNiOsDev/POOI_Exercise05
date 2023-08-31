using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio05
{
    public partial class Form1 : Form
    {
        List<Participante> lstParticipantes = new List<Participante>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Primeros entrar - primeros en salir
            Queue<int> numeros = new Queue<int>();
            numeros.Enqueue(1);
            numeros.Enqueue(2);
            numeros.Enqueue(3);
            numeros.Enqueue(4);
            numeros.Enqueue(5);

            Console.WriteLine("Queue-Cantidad de elementos en queue:" + numeros.Count());
            foreach (int item in numeros)
            {
                Console.WriteLine(item);
            }

            numeros.Dequeue();
            Console.WriteLine("Queue-Elementos despues de eliminar");
            foreach (int item in numeros)
            {
                Console.WriteLine(item);
            }

            Stack<int> numerosStack = new Stack<int>();
            numerosStack.Push(1);
            numerosStack.Push(2);
            numerosStack.Push(3);
            numerosStack.Push(4);
            numerosStack.Push(5);

            Console.WriteLine("Stack-Cantidad de elementos en stack:" + numerosStack.Count());
            foreach (int item in numerosStack)
            {
                Console.WriteLine(item);
            }
            numerosStack.Pop();
            Console.WriteLine("Stack-Elementos despues de eliminar");
            foreach (int item in numerosStack)
            {
                Console.WriteLine(item);
            }
            Dictionary<string,int> edades = new Dictionary<string,int>();
            edades.Add("Julio",25);
            edades.Add("Raul", 18);
            edades.Add("Jackelin", 32);
            edades.Add("Nilo", 31);

            foreach (KeyValuePair<string,int> item in edades)
            {
                Console.WriteLine("Nombre:"+item.Key+"-> Edad "+ item.Value+"");
               // Console.WriteLine("Nombre:{0} -> Edad:{1}", item.Key, item.Value);
            }

            List<string> lstQuintanilla = new List<string>();
            lstQuintanilla.Add("Rosa");
            lstQuintanilla.Add("Yohany");
            lstQuintanilla.Add("Ivette");
            lstQuintanilla.Add("Martha");
            lstQuintanilla.Add("Walther");
            lstQuintanilla.Add("Yohany");
            lstQuintanilla.Add("Pimpin");
            lstQuintanilla.Add("Yohany");



            lstQuintanilla.RemoveAt(0);

            mostrarElementos(lstQuintanilla);

            lstQuintanilla.Remove("Yohany");

            mostrarElementos(lstQuintanilla);


            lstQuintanilla.RemoveAll(item => item == "Yohany");
            mostrarElementos(lstQuintanilla);

        }
        private void mostrarElementos(List<string> lstQuintanilla)
        {
            Console.WriteLine("List-Cantidad de elementos en list: " + lstQuintanilla.Count());

            foreach (string item in lstQuintanilla)
            {
                Console.WriteLine(item);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validarFormulario()==true)
            {
                Participante participante = new Participante()
                {
                    DNI = txtDNI.Text,
                    Nombre = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    Email = txtEmail.Text,
                    fechaNacimiento = dtFechaNacimiento.Value,

                };

                lstParticipantes.Add(participante);
                dgParticipantes.DataSource = lstParticipantes.ToArray();

                btnLimpiar_Click(sender, e);
            }

           
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDNI.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtEmail.Clear();
            dtFechaNacimiento.Value = DateTime.Today;

            txtDNI.Focus();
            txtDNI.Enabled = true;
        }



        private void dgParticipantes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgParticipantes.CurrentRow;
            txtDNI.Text = fila.Cells[0].Value.ToString();
            txtNombres.Text = fila.Cells[1].Value.ToString();
            txtApellidos.Text = fila.Cells[2].Value.ToString();
            txtEmail.Text = fila.Cells[3].Value.ToString();
            dtFechaNacimiento.Value = DateTime.Parse(fila.Cells[4].Value.ToString());

            txtDNI.Enabled = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (validarFormulario()==true)
            {
                Participante participante = lstParticipantes.Find(item => item.DNI == txtDNI.Text);
                if (participante == null)
                {
                    MessageBox.Show("No existe un participante para el DNI ingresado");
                    return;
                }

                participante.Nombre = txtNombres.Text;
                participante.Apellidos = txtApellidos.Text;
                participante.Email = txtEmail.Text;
                participante.fechaNacimiento = dtFechaNacimiento.Value;

                dgParticipantes.DataSource = lstParticipantes.ToArray();

                btnLimpiar_Click(sender, e);
            }
            if (lstParticipantes.Find(item => item.DNI == txtDNI.Text) != null)
            {
                MessageBox.Show("Ya existe un participante con ese DNI. Sirvase a ingresar otro nuevo participante");
                return ;
            }

        }


        public Boolean validarFormulario()
        {
            if (txtDNI.Text == "")
            {
                MessageBox.Show("Ingrese un DNI");
                return false;
            }
            if (txtNombres.Text == "")
            {
                MessageBox.Show("Ingrese un Nombre");
                return false;
            }
            if (txtApellidos.Text == "")
            {
                MessageBox.Show("Ingrese sus apellidos");
                return false;
            }
            return true;
        }

}
}
