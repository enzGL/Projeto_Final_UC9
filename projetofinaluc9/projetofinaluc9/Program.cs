using System;

namespace estatisticas.de.genero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("==========================");
                    Console.WriteLine("= Estatísticas de Gênero =");
                    Console.WriteLine("==========================");
                    Console.ResetColor();

                    int alunos = 0;
                    while (true)
                    {
                        Console.Write("\nQuantos alunos há na turma? ");
                        try
                        {
                            alunos = int.Parse(Console.ReadLine());
                            if (alunos > 0)
                                break;
                            Console.WriteLine("Erro: O número de alunos deve ser maior que zero.");
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Erro: Digite um número inteiro válido.");
                            Console.ResetColor();
                        }
                    }

                    string[] nomes = new string[alunos];
                    int[] idades = new int[alunos];
                    char[] sexos = new char[alunos];

                    for (int i = 0; i < alunos; i++)
                    {
                        Console.Write($"\nDigite o nome do aluno {i + 1}: ");
                        nomes[i] = Console.ReadLine();

                        while (true)
                        {
                            Console.Write($"Digite a idade do aluno {i + 1}: ");
                            try
                            {
                                idades[i] = int.Parse(Console.ReadLine());
                                if (idades[i] > 0) break;
                                Console.WriteLine("Erro: A idade deve ser um número positivo.");
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Erro: Digite um número inteiro válido para a idade.");
                                Console.ResetColor();
                            }
                        }

                        while (true)
                        {
                            Console.Write($"Digite o sexo do aluno {i + 1} (M/F): ");
                            char sexoInput = char.ToUpper(Console.ReadLine()[0]);
                            if (sexoInput == 'M' || sexoInput == 'F')
                            {
                                sexos[i] = sexoInput;
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Erro: Sexo inválido. Use 'M' ou 'F'.");
                            Console.ResetColor();
                        }
                    }

                    int totalMulher = 0;
                    int mulheresAcima25 = 0;

                    for (int i = 0; i < alunos; i++)
                    {
                        if (sexos[i] == 'F')
                        {
                            totalMulher++;
                            if (idades[i] > 25)
                                mulheresAcima25++;
                        }
                    }

                    double porcMulher = (double)totalMulher / alunos * 100;
                    double porcMulherAcima25 = (double)mulheresAcima25 / totalMulher * 100;

                    Console.WriteLine("\nLista de Alunos: ");
                    for (int i = 0; i < alunos; i++)
                    {
                        Console.WriteLine($"{i + 1}. Nome: {nomes[i]}, Idade: {idades[i]}, Sexo: {sexos[i]}");
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nPorcentagem de mulheres na turma: {porcMulher:F2}%");
                    Console.WriteLine($"Porcentagem de mulheres acima de 25 anos: {porcMulherAcima25:F2}%");
                    Console.ResetColor();
                }
                finally
                {
                    Console.WriteLine("\nExecução finalizada.");
                    Console.ReadKey();
                }
                break;
            }
        }
    }
}
