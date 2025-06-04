namespace QuadraManagementService.Entities
{
    public class Quadras
    {
        public Quadras(string nome, string localizacao, string tipo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da quadra é obrigatório.");

            if (string.IsNullOrWhiteSpace(localizacao))
                throw new ArgumentException("A localização da quadra é obrigatória.");

            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("O tipo da quadra é obrigatório.");

            Nome = nome;
            Localizacao = localizacao;
            Tipo = tipo;
            DtCriacao = DateTime.Now;
            DtUltimaAlteracao = DateTime.Now;
            BitAtivo = true;
        }

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Localizacao { get; private set; }

        public string Tipo { get; private set; }

        public DateTime DtCriacao { get; private set; }

        public DateTime DtUltimaAlteracao { get; private set; }

        public bool BitAtivo { get; private set; }

        public void AtualizarInformacoes(string nome, string localizacao, string tipo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da quadra é obrigatório.");

            if (string.IsNullOrWhiteSpace(localizacao))
                throw new ArgumentException("A localização da quadra é obrigatória.");

            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("O tipo da quadra é obrigatório.");

            Nome = nome;
            Localizacao = localizacao;
            Tipo = tipo;
            DtUltimaAlteracao = DateTime.Now;
        }

        public void Desativar()
        {
            BitAtivo = false;
            DtUltimaAlteracao = DateTime.Now;
        }

        public void Reativar()
        {
            BitAtivo = true;
            DtUltimaAlteracao = DateTime.Now;
        }
    }
}
