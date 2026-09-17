using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
