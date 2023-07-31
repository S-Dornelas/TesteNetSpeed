namespace TesteNetSpeed_3
{
    class Program
    {
        static void Main()
        {
            DateTime vencimentoOriginal, dataPagamento;
            double valorBoleto, valorJuros = 0, valorMulta = 2;
            int numDias;

            Console.Write("Digite a data de vencimento original (dd/mm/aaaa): ");
            vencimentoOriginal = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite a data de pagamento (dd/mm/aaaa): ");
            dataPagamento = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o valor do boleto: R$");
            valorBoleto = double.Parse(Console.ReadLine());

            if (dataPagamento < vencimentoOriginal)
            {
                Console.WriteLine("Pagamento anterior ao vencimento. Nenhum cálculo necessário.");
            }
            else
            {
                numDias = (int)(dataPagamento - vencimentoOriginal).TotalDays;

                if (VerificaFinalDeSemana(vencimentoOriginal) || VerificaFeriado(vencimentoOriginal))
                {
                    if (VerificaDiaUtil(dataPagamento))
                    {
                        Console.WriteLine("Pagamento efetuado no próximo dia útil. Nenhum cálculo necessário.");
                    }
                    else
                    {
                        valorJuros = numDias * 0.03;
                    }
                }
                else 
                {
                    if (VerificaDiaUtil(vencimentoOriginal) && VerificaDiaUtil(dataPagamento) && dataPagamento > vencimentoOriginal)
                    {
                        valorJuros = 0.03;
                    }
                    else 
                    {
                        valorJuros = numDias * 0.03;
                    }
                }
            }

            double valorRecalculado = valorBoleto + valorJuros + valorMulta;

            Console.WriteLine("Valor do boleto recalculado: R$" + valorRecalculado.ToString("0.00"));
            Console.WriteLine("Valor total dos juros do período: R$" + valorJuros.ToString("0.00"));
        }

        static bool VerificaDiaUtil(DateTime data)
        {
            return data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday;
        }

        static bool VerificaFinalDeSemana(DateTime data)
        {
            return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;
        }

        static bool VerificaFeriado(DateTime data)
        {
            return data.Month == 1 && data.Day == 1; 
        }
    }
}