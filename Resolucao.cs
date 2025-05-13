using System.Text;
using System.Text.Json;

namespace dt_target
{
    public static class Resolucao
    {
        public static void Soma()
        {
            Console.WriteLine("=== Questão 1 ===");

            int indice = 13;
            int k = 0;
            int soma = 0;

            while (k < indice)
            {
                k++;
                soma += k;
            }

            Console.WriteLine(soma);
            Console.WriteLine();
        }

        public static string Fibonacci(int numero)
        {
            Console.WriteLine("=== Questão 2 ===");

            List<int> fibbonacci = [0, 1];

            int f1 = 0, f2 = 1;
            while (f2 < numero)
            {
                int temp = f1;
                f1 = f2;
                f2 = f1 + temp;

                fibbonacci.Add(f1);
                fibbonacci.Add(f2);
            }

            bool numeroFibonacci = fibbonacci.Contains(numero);
            string mensagem = numeroFibonacci ?
                $"O número {numero} faz parte de Fibonacci" : $"O número {numero} NÃO faz parte de Fibonacci";

            Console.WriteLine(mensagem);
            Console.WriteLine();

            return mensagem;
        }

        public static (double menorValor, double maiorValor, int quantidadeDias) RelatorioFaturamento()
        {
            Console.WriteLine("=== Questão 3 ===");

            string dadosJsonEmString = File.ReadAllText("./dados.json");

            List<ValorDiario>? valoresDiarios = JsonSerializer.Deserialize<List<ValorDiario>>(
                dadosJsonEmString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var listaSemValoresZerados = valoresDiarios.Where(vd => vd.Valor != 0).ToList();
            
            double total = listaSemValoresZerados.Sum(v => v.Valor);
            double mediaMensal = total / listaSemValoresZerados.Count;

            var quantidadeDiasSuperioresMedia = listaSemValoresZerados.Where(v => v.Valor > mediaMensal).ToList().Count;

            double menorFaturamento = listaSemValoresZerados.MinBy(v => v.Valor).Valor;
            double maiorFaturamento = listaSemValoresZerados.MaxBy(v => v.Valor).Valor;


            Console.WriteLine($"Menor Valor: {menorFaturamento}");
            Console.WriteLine($"Maior Valor: {maiorFaturamento}");
            Console.WriteLine($"Qntd. dias superiores à média: {quantidadeDiasSuperioresMedia}");
            Console.WriteLine();

            return (menorFaturamento, maiorFaturamento, quantidadeDiasSuperioresMedia);
        }

        public static Dictionary<string, double> FaturamentoPercentual()
        {
            Console.WriteLine("=== Questão 4 ===");

            Dictionary<string, double> faturamentoPorEstado = new()
            {
                { "SP", 67836.43 },
                { "RJ", 36678.66 },
                { "MG", 29229.88 },
                { "ES", 27165.48 },
                { "Outros", 19849.53 }
            };

            double total = faturamentoPorEstado.Sum(v => v.Value);

            Dictionary<string, double> percentualPorEstado = [];

            foreach (var estado in faturamentoPorEstado)
            {
                double percentual = estado.Value / total * 100;
                percentualPorEstado.Add(estado.Key, percentual);
                
                Console.WriteLine($"{estado.Key} | Percentual: {percentual}%");
            }

            Console.WriteLine();
            return percentualPorEstado;
        }

        public static void InverterString(string s)
        {
            Console.WriteLine("=== Questão 5 ===");

            StringBuilder sb = new();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }

            Console.WriteLine(sb.ToString());
        }
    }

    class ValorDiario
    {
        public int Dia { get; set; }

        public double Valor { get; set; }
    }
}
