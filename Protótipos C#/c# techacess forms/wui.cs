//wui.cs
//@techacess


/*

C# Win Forms APP (.NET FrameWork)
Text To Speach Integrado Windows

Codigo exemplo de certas funcionalidades que pretendemos adicionar ao app de acessibilidade

Apresenta forms inicial com opcoes em botoes para executar a fala
Possivel digitar algo na textbox para que seja falado

[ALUNOS]:
Angela Akemi Hiroishi - Gabriel Miranda - Geovana da Costa Andrade
Guilherme Henrique Moura Neves - Guilherme Henrique Santos Rodrigues
 
*/


using System;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Globalization;
using System.Runtime.InteropServices;


namespace speachAcessF
{

    internal partial class wui : Form {

        public bool debug = true; //opcao debug

        public int rate = -4; //velocidade de fala
        public int vol = 100; //volume de fala

        string[] txt = {"BOM DIA", "AJUDA", "EXEMPLO", "CALOR", "FRIO", "BARULHO", "SIM", "FOME", "SEDE", "DOR", "NAO"};

        SpeechSynthesizer speak = new SpeechSynthesizer();


        internal wui() { InitializeComponent(); }


        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;



        //inicia o form
        private void wui_Load(object sender, EventArgs e) {

            //integra ao console de que foi executado para debug se necessario
            //util para manejar as falas que foram executadas?
            if (debug == true) { AttachConsole(ATTACH_PARENT_PROCESS); }

            Console.WriteLine("..iniciando");

            benable();

            speak.SetOutputToDefaultAudioDevice();

            speak.SelectVoiceByHints(VoiceGender.Female, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));
            speak.Rate = rate;
            speak.Volume = vol;

            Console.WriteLine("..inicializado!");

        }



        //botoes e suas funcionalidades
        private void button1_Click(object sender, EventArgs e) {
            spk(0);
        }

        private void button2_Click(object sender, EventArgs e) {
            spk(1);
        }

        private void button3_Click(object sender, EventArgs e) {
            spk(2);
        }

        private void button5_Click(object sender, EventArgs e) {
            spk(3);
        }

        private void button6_Click(object sender, EventArgs e) {
            spk(4);
        }

        private void button7_Click(object sender, EventArgs e) {
            spk(5);
        }

        private void button8_Click(object sender, EventArgs e) {
            spk(6);
        }

        private void button9_Click(object sender, EventArgs e) {
            spk(7);
        }

        private void button10_Click(object sender, EventArgs e) {
            spk(8);
        }

        private void button11_Click(object sender, EventArgs e) {
            spk(9);
        }

        private void button12_Click(object sender, EventArgs e) {
            spk(10);
        }

        private void button4_Click(object sender, EventArgs e) {
            spk(50);
        }


        //..demais funcoes aqui..
        private void benable() {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
        }


        private void bdisable() {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
        }


        //uso: spk(id da fala na string[] txt);
        private void spk(int id) {

            bdisable();

            string t = string.Empty;

            switch (id) {
                case 50:
                    t = textBox1.Text; //reproduz o que foi inserido na textbox
                    break;
                default:
                    t = txt[id]; //reproduz o texto referente ao id na array
                    break;
            }

            Console.WriteLine("botao clicado > " + t); //informa a fala no console integrado
            speak.SpeakAsync(t); //fala
            benable();

        }


    }


}
