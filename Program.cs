﻿using System;
using System.IO;


namespace TextEditor
{
    static class Program
    {


        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você gostaria fazer?");
            Console.WriteLine("1. Abrir arquivo");
            Console.WriteLine("2. Criar arquivo");
            Console.WriteLine("0. Sair");
            short option = short.Parse(Console.ReadLine() ?? "0");
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Console.WriteLine("Opção inválida"); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string path = Console.ReadLine() ?? "arquivo.txt";
            using (var file = new StreamReader(path))
            {

                string text = file.ReadToEnd();
                Console.WriteLine(text);
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadLine();
            }

            Console.WriteLine();
            Console.ReadLine();
            Menu();

        }

        static void Editar()

        {
            Console.Clear();
            Console.WriteLine("Digite o seu texto abaixo (ESC para sair)");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }

            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Salvar(text);

        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho deseja salvar?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path ?? "arquivo.txt"))
            {
                file.Write(Console.ReadLine());
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }





    }
}