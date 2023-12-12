namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:\nExemplo: XXX-0000\nPlaca: ");
            string placaVeiculo = Console.ReadLine();

            if(VerificaPlacaValida(placaVeiculo) == false){
                Console.WriteLine("A placa inserida não está de acordo com o formato.");
            }
            else if(VerificaRepeticaoPlaca(placaVeiculo))
            {
                Console.WriteLine("Placa já cadastrada no sistema.");
            }
            else
            {
                veiculos.Add(placaVeiculo);
                Console.WriteLine("Veículo adicionado!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horasEstacionadas = int.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horasEstacionadas; 

                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        private bool VerificaPlacaValida(string placa)
        {
            if(placa.Length == 8)
            {
                bool verificacao = true;
                for(int i = 0; i < placa.Length; i++)
                {
                    verificacao = int.TryParse(placa[i].ToString(), out var resultado);

                    if((i <= 2 && verificacao != false) ||
                       (i == 3 && placa[i] != '-')      || 
                       (i >= 4 && verificacao != true))
                    {
                        verificacao = false;
                        break;
                    }
                }
                return verificacao;
            }
            else
            {
                return false;
            }
        }

        private bool VerificaRepeticaoPlaca(string placa)
        {
            bool jaExiste = false;
            foreach(string veiculo in veiculos)
            {
                if(placa == veiculo)
                {
                    jaExiste = true;
                }
            }
            return jaExiste;
        }
    }
}
