namespace TesteNetSpeed
{
    class Program
    {
        static void Main()
        {
            int totalCarrosAte2000 = 0;
            int totalGeral = 0;

            do
            {
                int anoVeiculo = ObterAnoVeiculo();
                double valorVeiculo = ObterValorVeiculo();

                double desconto = CalcularDesconto(anoVeiculo, valorVeiculo);

                double valorPago = valorVeiculo - desconto;

                ExibirResultado(desconto, valorPago);

                if (anoVeiculo <= 2000)
                {
                    totalCarrosAte2000++;
                }

                totalGeral++;

            } while (ContinuarCalculandoDesconto());

            ExibirTotais(totalCarrosAte2000, totalGeral); 
        }

        static int ObterAnoVeiculo()
        {
            Console.Write("Digite o ano do veículo: ");
            return int.Parse(Console.ReadLine());
        }

        static double ObterValorVeiculo()
        {
            Console.Write("Digite o valor do veículo: R$");
            return double.Parse(Console.ReadLine());
        }

        static double CalcularDesconto(int anoVeiculo, double valorVeiculo)
        {
            double desconto;

            if (anoVeiculo <= 2000)
            {
                desconto = valorVeiculo * 0.12;
            }
            else
            {
                desconto = valorVeiculo * 0.07;
            }

            return desconto;
        }

        static void ExibirResultado(double desconto, double valorPago)
        {
            Console.WriteLine("Desconto: R$" + desconto);
            Console.WriteLine("Valor a ser pago: R$" + valorPago);
        }

        static bool ContinuarCalculandoDesconto()
        {
            Console.Write("Deseja continuar calculando desconto? (S/N): ");
            char resposta = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            return resposta == 'S';
        }

        static void ExibirTotais(int totalCarrosAte2000, int totalGeral)
        {
            Console.WriteLine("Total de carros com ano até 2000: " + totalCarrosAte2000);
            Console.WriteLine("Total geral de carros: " + totalGeral);
        }
    }

}