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
            if(Suite == null)
            {
                throw new Exception("Suite precisa ser cadastrada antes para verificar capacidade");
            }
            if (hospedes.Count > Suite.Capacidade)
            {
                throw new Exception("Capacidade maior que a permitida");
            }
                Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if (Hospedes == null)
            {
                return 0;
            }
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null) {
                throw new Exception("Nenhuma suite foi cadastrada");
            }
            return DiasReservados * Suite.ValorDiaria * (DiasReservados >= 10? 0.9M : 1);
        }
    }
}