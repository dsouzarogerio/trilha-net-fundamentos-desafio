
namespace DesafioFundamentos.Models
{
    public class Veiculo
    {

        public int IdCarro { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }

        public Veiculo() { }
        public Veiculo(string marca, string modelo, string placa)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Placa = placa;
        }

        public override string ToString()
        {
            return "Marca: " + Marca + " - Modelo: " + Modelo + " - Placa: " + Placa;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Veiculo objAsPart = obj as Veiculo;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return IdCarro;
        }
        public bool Equals(Veiculo other)
        {
            if (other == null) return false;
            return (this.Placa.Equals(other.Placa));
        }
    }
}