namespace TesteNetSpeed_2
{
    class Program
    {
        const int PesoMaiorNota = 4;
        const int PesoOutrasNotas = 3;

        static void Main()
        {
            while (true)
            {
                int codigoAluno = ObterCodigoAluno();
                if (codigoAluno == 0)
                    break;

                double nota1 = ObterNota("primeira");
                double nota2 = ObterNota("segunda");
                double nota3 = ObterNota("terceira");
                  
                double media = CalcularMediaPonderada(nota1, nota2, nota3);

                ExibirResultado(codigoAluno, nota1, nota2, nota3, media);
            }
        }

        static int ObterCodigoAluno()
        {
            Console.Write("Digite o código do aluno (ou 0 para encerrar): ");
            return int.Parse(Console.ReadLine());
        }

        static double ObterNota(string ordem)
        {
            Console.Write($"Digite a {ordem} nota do aluno: ");
             return double.Parse(Console.ReadLine());
        }

        static double CalcularMediaPonderada(double nota1, double nota2, double nota3)
        {
            double maiorNota = Math.Max(Math.Max(nota1, nota2), nota3);
            double somaNotasMenores = (nota1 + nota2 + nota3) - maiorNota;

            double media = (maiorNota * PesoMaiorNota + somaNotasMenores * PesoOutrasNotas) / (PesoMaiorNota + PesoOutrasNotas * 2);

            return media;
        }

        static void ExibirResultado(int codigoAluno, double nota1, double nota2, double nota3, double media)
        {
            Console.WriteLine("Aluno código: " + codigoAluno);
            Console.WriteLine("Notas: " + nota1 + ", " + nota2 + ", " + nota3);
            Console.WriteLine("Média: " + media.ToString("0.00"));

            if (media >= 6)
            {
                Console.WriteLine("APROVADO");
            }
            else
            {
                Console.WriteLine("REPROVADO");
            }

            Console.WriteLine();
        }
    }

}