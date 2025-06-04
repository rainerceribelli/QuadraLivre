using static QuadraManagementService.Crosscutting.Enum.AgendamentoStatus;

namespace QuadraManagementService.Entities
{
    public class Agendamentos
    {
        public Agendamentos(int id, int idQuadra, string clienteNome, string clienteEmail, DateTime dataAgendamento, TimeSpan horaInicio, TimeSpan horaFim)
        {
            if (horaInicio >= horaFim)
                throw new ArgumentException("Hora de início deve ser anterior à hora de término.");

            if (string.IsNullOrWhiteSpace(clienteNome))
                throw new ArgumentException("O nome do cliente é obrigatório.");

            if (!clienteEmail.Contains("@"))
                throw new ArgumentException("O e-mail do cliente é inválido.");

            Id = id;
            IdQuadra = idQuadra;
            ClienteNome = clienteNome;
            ClienteEmail = clienteEmail;
            DataAgendamento = dataAgendamento;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Status = AgendamentoStatusEnum.Ativo;
            DtCriacao = DateTime.Now;
        }

        public int Id { get; set; }

        public int IdQuadra { get; set; }

        public string ClienteNome { get; set; }

        public string ClienteEmail { get; set; }

        public DateTime DataAgendamento { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFim { get; set; }

        public AgendamentoStatusEnum Status { get; private set; }

        public DateTime DtCriacao { get; private set; }

        public void Cancelar()
        {
            Status = AgendamentoStatusEnum.Cancelado;
        }

        public void Reativar()
        {
            Status = AgendamentoStatusEnum.Ativo;
        }
    }
}
