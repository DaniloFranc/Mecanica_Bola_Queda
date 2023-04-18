using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste_bola
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private DateTime startTime;

        public Form1(int valor)
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;

            if (valor == 0)
            {
                valor = 10;
            }
            else
            {
                picRaquete.Height = valor;
            }

        }

        
        


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            startTime = DateTime.Now;
            timer.Start();
        }

        double velocidade = 10.0;
        double fatorReducao = 0.2; 
        double incremento = 1.0;

        private double velocidadeHorizontal = 0; // adicione esta linha no início da classe

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            int seconds = (int)Math.Floor(elapsed.TotalSeconds);

            label1.Text = string.Format("Tempo decorrido: {0} segundos", seconds);

            double novaVelocidadeVertical = velocidade;

            if (picBola.Top >= 401)
            {
                novaVelocidadeVertical = novaVelocidadeVertical * 0.80;
            }
            else
            {
                novaVelocidadeVertical = novaVelocidadeVertical + (seconds * fatorReducao);
            }

            int novaPosicaoVertical = (int)(picBola.Top + (novaVelocidadeVertical * incremento));

            if (novaPosicaoVertical <= 0 || novaPosicaoVertical >= 401)
            {
                novaVelocidadeVertical = -novaVelocidadeVertical;
            }

            velocidade = novaVelocidadeVertical;

            // Adicione as linhas abaixo para atualizar a velocidade horizontal e posição da bola
           // velocidadeHorizontal = -1.5; // ajuste a velocidade horizontal aqui
        //    int novaPosicaoHorizontal = (int)(picBola.Left + (velocidadeHorizontal * incremento));
          //  picBola.Left = novaPosicaoHorizontal;

            picBola.Top = novaPosicaoVertical;
            label3.Text = picBola.Top.ToString();
            label4.Text = picBola.Left.ToString();
        }

        private void btn_re_Click(object sender, EventArgs e)
        {
            
            startTime = DateTime.Now;

            
            picBola.Top = 140;
            picBola.Left = 398;
            velocidade = 15.0;

            
            label1.Text = "Tempo decorrido: 0 segundos";

        }

        private void picRaquete_Click(object sender, EventArgs e)
        {

        }
    }
}


