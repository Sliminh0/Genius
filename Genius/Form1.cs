using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genius
{
    public partial class Form1 : Form
    {

        //Lista que armazena a sequência de cores geradas pelo computador
        List<String> sequencialCores = new List<string>();

        //Lista que armazena a sequência de cores clicadas pelo jogador
        List<String> sequencialJogador = new List<string>();

        //variável listaindex usada para comparar passo a passo a sequência do jogador com a do computador
        int listaindex, ponto;

        //fator de brilho usado para "piscar" as cores (deixa mais claro temporariamente)
        const float brilho = 0.9f;

        //Variável que guarda a cor atualmente sendo processada (do computador ou do jogador)
        string atualCor;

        //Vetor com tags das cores R(Red), G(Green), B(Blue) e Y(Yellow).
        string[] cores = { "R", "G", "B", "Y" };

        //Variável que indica se o jogador pode clicar nos botões
        bool podejogar;

        //Som de erro (tocado quando o jogador erra)
        SoundPlayer erro = new SoundPlayer(Properties.Resources.error);

        //Gerador de números aleatorios
        Random rdn = new Random();

        //Vetor com os sons associados a cada cor
        SoundPlayer[] audios =
        {
            new SoundPlayer(Properties.Resources.beep_1),
            new SoundPlayer(Properties.Resources.beep_2),
            new SoundPlayer(Properties.Resources.beep_3),
            new SoundPlayer(Properties.Resources.beep_4)
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Mostrarcor(PictureBox pic, Color corClara, Color corEscura, SoundPlayer som)
        {
            //Muda de cor de fundo para versão mais clara
            pic.BackColor = corClara;

            //toca o som associado á cor
            som.Play();

            //Processa eventos pendentes da interface
            Application.DoEvents();

            //Mantém a cor acessa por 850 milisegundos
            Thread.Sleep(850);

            //volta a cor de fundo ao estado original
            pic.BackColor = corEscura;
        }

        //procura entre os controles do formularia a picturebox cuja tag corresponde a cor informada e chama Mostracor para fazer essa cor piscas com seu som
        private void ProcuraCor(string tagPic)
        {
            //percorre todos os picturebox existentes no formulário
            foreach (var corEncontrada in Controls.OfType<PictureBox>())
            {
                //verifica se a tag do picturebox é igual à cor que queremos piscar
                if(corEncontrada.Tag.ToString() == tagPic)
                {
                    //Guarda a tag (cor) do PictureBox encontrado
                    string tag = corEncontrada.Tag.ToString();

                    //Calcula uma versão mais clara da cor atual (para efeito de piscar)
                    Color piscar = ControlPaint.Light(corEncontrada.BackColor, brilho);

                    //seleciona o som correto de acordo com a tag (R -> beep_1, G -> beep_2, B -> beep_3, Y -> beep_4)
                    SoundPlayer som = tag == "R" ? audios[0] : (tag == "G" ? audios[1] : (tag == "B" ? audios[2] : audios[3]));
                    Mostrarcor(corEncontrada, piscar, corEncontrada.BackColor, som);

                }
            }
        }

        private void SortearCor()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
