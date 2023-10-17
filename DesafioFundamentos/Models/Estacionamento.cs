using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        string marca =  string.Empty;
        string modelo = string.Empty;
        string placa = string.Empty;

        public void AdicionarVeiculo()
        {
            //Pedir para o usuário digitar os dados do veículo (ReadLine) e adiciona na lista "veiculos"
            Console.WriteLine("Digite os dados do veículo para estacionar:");
            Console.Write("Marca: ");
            marca = Console.ReadLine();
            Console.Write("Modelo: ");
            modelo = Console.ReadLine();
            Console.Write("Placa: ");
            placa = Console.ReadLine().ToUpper();
            
            if(validarPlaca(placa))
            {
                Console.WriteLine("A placa é válida.");
            }
            else
            {
                Console.WriteLine("A placa inválida.");
                return;
            }

           Veiculo carro = new Veiculo(marca, modelo, placa); 
           veiculos.Add(carro);
        }

        private bool validarPlaca(string placa)
        {
            string pattern = @"^[A-Z]{3}\-\d{3,4}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            
            // Pedir para o usuário digitar a placa e armazena na variável placa
            placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.Placa.ToUpper().Equals(placa.ToUpper())))
            {
                
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                //Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                //Realiza o cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas; 

                //Remover o veiculo  da lista de veículos através da placa digitada
                veiculos.Remove(new Veiculo(){Placa = placa});

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
                //Realizar um laço de repetição, exibindo os veículos estacionados
                foreach(Veiculo veiculo in veiculos)
                {
                    Console.WriteLine(veiculo.ToString());
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}