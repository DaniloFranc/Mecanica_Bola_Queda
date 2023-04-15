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
                valor = 100;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            int seconds = (int)Math.Floor(elapsed.TotalSeconds);

            label1.Text = string.Format("Tempo decorrido: {0} segundos", seconds);

            
            double novaVelocidade = velocidade;
            if (picBola.Top >= 401)
            {

                novaVelocidade = novaVelocidade * 0.90;
            }
            else
            {
                novaVelocidade = novaVelocidade + (seconds * fatorReducao);
            }

            
            int novaPosicao = (int)(picBola.Top + (novaVelocidade * incremento));

            
            if (novaPosicao <= 0 || novaPosicao >= 401)
            {   
                novaVelocidade = -novaVelocidade;
            }

            
            velocidade = novaVelocidade;
            picBola.Top = novaPosicao;

            label3.Text = picBola.Top.ToString();
        }

        private void btn_re_Click(object sender, EventArgs e)
        {
            
            startTime = DateTime.Now;

            
            picBola.Top = 140;
            velocidade = 15.0;

            
            label1.Text = "Tempo decorrido: 0 segundos";

        }

        private void picRaquete_Click(object sender, EventArgs e)
        {

        }
    }
}


