//main.cs
//@techacess


/*

C# Win Console APP (.NET FrameWork)
Text To Speach Integrado Windows

Codigo exemplo de certas funcionalidades que pretendemos adicionar ao app de acessibilidade

Apresenta tela inicial em loop controlavel pelas <setas> do teclado
Utilize <setas> para destacar uma opcao
Utilize <enter> para selecionar a opcao desejada em destaque
 
Ao selecionar <falar> o codigo entra em loop 
Possibilita que o usuario digite uma frase para que o console reproduza em audio (TTS)
Ao digitar <sair> o loop finaliza

As funcoes de [entrar] e [registrar] ainda nao foram implementadas
O registro de usuario servira para salvar: 
-configuracoes pessoais
-falas especificas
-etc
 
[ALUNOS]:
Angela Akemi Hiroishi - Gabriel Miranda - Geovana da Costa Andrade
Guilherme Henrique Moura Neves - Guilherme Henrique Santos Rodrigues

*/


using System;
using System.Speech.Synthesis;
using System.Globalization;
using System.Threading;


namespace speachAcess {

    internal static class start {

        static int height = 14;
        static int width = 60;


        internal static void writec(string s, ConsoleColor fc, ConsoleColor bc, int x, int y) {
            int x1 = Console.CursorLeft; int y1 = Console.CursorTop;
            Console.SetCursorPosition(x,y);
            Console.ForegroundColor = fc;
            Console.BackgroundColor = bc;
            Console.Write(s);
            Console.ResetColor();
            Console.SetCursorPosition(x1,y1);
        }


        internal static void speak() {
            
            SpeechSynthesizer speak = new SpeechSynthesizer();

            speak.SetOutputToDefaultAudioDevice();

            speak.SelectVoiceByHints(VoiceGender.Female, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("pt-br"));
            speak.Rate = -2;
            speak.Volume = 100;

            string text = "";

            while ((text == "sair") == false) {
                Console.WriteLine("digite o texto para reproduzir: ou <sair>");
                text = Console.ReadLine();
                speak.SpeakAsync(text);
            }
               
            Console.WriteLine("..finalizado");
            Thread.Sleep(1000);
        }


        internal static void load() {

            Console.SetWindowSize(width, height);
            Console.BufferHeight = height;
            Console.BufferWidth = width;

            writec("..iniciado", ConsoleColor.DarkGray, ConsoleColor.Black, 0, 1);

            bool loop = true;
            int opt = 4, sel = 0;

            while (loop) {

                Console.Clear();
                Console.WriteLine();

                Console.Title = "techAcess Text2Speach";
                writec("techAcess Text2Speach", ConsoleColor.White, ConsoleColor.Black, 0, 0);

                for (int i = 0; i < opt; i++) {

                    if (sel == i) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(">");
                    } else {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }

                    if (i == 0) { Console.WriteLine("entrar"); }
                    if (i == 1) { Console.WriteLine("registrar"); }
                    if (i == 2) { Console.WriteLine("falar"); }
                    if (i == 3) { Console.WriteLine("sair"); }

                    Console.ResetColor();

                }

                switch (Console.ReadKey().Key) {
                    case ConsoleKey.UpArrow:
                        { sel = Math.Max(0, sel - 1); } break;
                    case ConsoleKey.DownArrow:
                        { sel = Math.Min(opt - 1, sel + 1); } break;
                    case ConsoleKey.Enter: {
                            Console.Beep(100, 1);
                            if (sel == 0) { Console.WriteLine("Ainda nao implementado.."); Thread.Sleep(1000); }
                            if (sel == 1) { Console.WriteLine("Ainda nao implementado.."); Thread.Sleep(1000); }
                            if (sel == 2) { speak(); }
                            if (sel == 3) { loop = false; } } break;
                } if (loop == true) { Console.CursorTop = Console.CursorTop - opt; }

            }

        }



    }


    internal class main {
        static void Main(string[] args) {

            Console.WriteLine("..inicializando..");
            start.load();

        }
    }

}
