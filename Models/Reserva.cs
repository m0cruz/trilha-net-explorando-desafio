namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {

            int _quantidadeHospedes = hospedes.Count;
            bool _hospedes = hospedes.Count <= Suite.Capacidade;

            if (_hospedes)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException($"A capacidade máxima da suíte {Suite.TipoSuite} é {Suite.Capacidade}.\r\n" +
                $"{hospedes.Count} hóspedes não podem se hospedar nesta suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
        
            decimal valor = DiasReservados * Suite.ValorDiaria;
            bool _diasReservados = DiasReservados >= 10;
            decimal desconto = 0.1M;

            if (_diasReservados)
            {
                valor -= valor * desconto;
            }

            return valor;
        }
    }
}