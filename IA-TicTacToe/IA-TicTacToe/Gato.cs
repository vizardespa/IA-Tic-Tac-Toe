using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IA_TicTacToe
{
    public partial class Gato : Form
    {
        public Gato()
        {
            InitializeComponent();
        }
        public string TurnoActual;
        public int Nivel =1;
        public string[] Botones;
        public int[,] Matrix;
        private void Gato_Load(object sender, EventArgs e)
        {
            TurnoActual = "Jugador";
            lblTurno.Text = TurnoActual;
            Matrix = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Matrix[i, j] = 0;
                }
            }
            Botones = new string[9];
            Botones[0] = btn1.Name;
            Botones[1] = btn2.Name;
            Botones[2] = btn3.Name;
            Botones[3] = btn4.Name;
            Botones[4] = btn5.Name;
            Botones[5] = btn6.Name;
            Botones[6] = btn7.Name;
            Botones[7] = btn8.Name;
            Botones[8] = btn9.Name;
            btn1.Click += Click;
            btn2.Click += Click;
            btn3.Click += Click;
            btn4.Click += Click;
            btn5.Click += Click;
            btn6.Click += Click;
            btn7.Click += Click;
            btn8.Click += Click;
            btn9.Click += Click;
        }

        public void Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "")
            {
                btn.Text = TurnoActual=="Jugador"?"O":"X";
                switch(btn.Name)
                {
                    case "btn1":
                        Matrix[0,0]=TurnoActual=="Jugador"?1:2;
                    break;
                    case "btn2":
                        Matrix[0, 1] = TurnoActual == "Jugador" ? 1 : 2;
                    break;
                    case "btn3":
                        Matrix[0, 2] = TurnoActual == "Jugador" ? 1 : 2;
                    break;
                    case "btn4":
                        Matrix[1, 0] = TurnoActual == "Jugador" ? 1 : 2;
                    break;
                    case "btn5":
                        Matrix[1, 1] = TurnoActual == "Jugador" ? 1 : 2;
                    break;
                    case "btn6":
                        Matrix[1, 2] = TurnoActual == "Jugador" ? 1 : 2;
                    break;
                    case "btn7":
                        Matrix[2, 0] = TurnoActual == "Jugador" ? 1 : 2;
                    break;
                    case "btn8":
                        Matrix[2, 1] = TurnoActual == "Jugador" ? 1 : 2;
                    break;
                    case "btn9":
                        Matrix[2, 2] = TurnoActual == "Jugador" ? 1 : 2;
                    break;
                }
                RevisarEstados();
                TurnoActual =TurnoActual=="Jugador"?"Computadora":"Jugador";
                lblTurno.Text = TurnoActual;
                if(TurnoActual =="Computadora")
                {
                    TurnoComputadora();
                }
            }
        }
        public void TurnoComputadora()
        {
            /*btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;*/
            if(Nivel==1)
            {
                Random r = new Random();
                Button btn = this.Controls.Find(Botones[r.Next(0, 9)], true).FirstOrDefault() as Button;
                bool v = true;
                while(v)
                {
                    int l = r.Next(0, 9);
                    btn = this.Controls.Find(Botones[l], true).FirstOrDefault() as Button;
                    if(btn.Text=="")
                    {
                        v = false;
                    }
                }
                btn.PerformClick();
            }
           /* btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;*/
        }
        public void RevisarEstados()
        {

            bool Ganar = false;
            //Horizontales
            for (int i = 0; i < 3; i++)
            {
                if (Matrix[0, i] == 1 && Matrix[1, i] == 1 && Matrix[2, i] == 1)
                    Ganar = true;
                if (Matrix[0, i] == 2 && Matrix[1, i] == 2 && Matrix[2, i] == 2)
                    Ganar = true;
            }
            //Verticales
            for (int i = 0; i < 3; i++)
            {
                if (Matrix[i, 0] == 1 && Matrix[i, 1] == 1 && Matrix[i, 2] == 1)
                    Ganar = true;
                if (Matrix[i, 0] == 2 && Matrix[i, 1] == 2 && Matrix[i, 2] == 2)
                    Ganar = true;
            }
            //Diagonales
            if (Matrix[0, 0] == 1 && Matrix[1, 1] == 1 && Matrix[2, 2] == 1)
                Ganar = true;
            if (Matrix[0, 0] == 2 && Matrix[1, 1] == 2 && Matrix[2, 2] == 2)
                Ganar = true;
            if (Matrix[0, 2] == 1 && Matrix[1, 1] == 1 && Matrix[2, 0] == 1)
                Ganar = true;
            if (Matrix[0, 2] == 2 && Matrix[1, 1] == 2 && Matrix[2, 0] == 2)
                Ganar = true;

            if (Ganar)
                FinJuego(true);
            if (ContarVacios() == 0)
                FinJuego(false);
        }
        public void FinJuego(bool Estado)
        {
            if(Estado)
            {
                MessageBox.Show("Gana " + TurnoActual);
            }
            else
            {
                MessageBox.Show("Empate");
            }
            Reiniciar();
        }
        public void Reiniciar()
        {
            lblTurno.Text = TurnoActual;
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Matrix[i, j] = 0;
                }
            }

        }
        public int ContarVacios()
        {
            int res = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Matrix[i, j]==0)
                        res++;
                }
            }
            return res;
        }

    }
}
