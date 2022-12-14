using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GrerenciaFOOD_read_Infrastructure.Persistence.Funcionario
{
    [Flags]
    public enum FuncionarioClass
    {
        AtendenteMesa,
        AtendenteCozinha,
        Administrador
    }

    public class Funcionario
    {
        public Funcionario(int id, FuncionarioClass perfil, string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException("nome");
            this.Id = id;
            this.Perfil = perfil;
            this.Nome = nome;
        }

        public Funcionario(FuncionarioClass perfil, string nome)
        {
            
            this.Id = -1;
            this.Perfil = perfil;
            this.Nome = nome;
        }

        public int Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FuncionarioClass Perfil { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return $"[Perfil]{this.Perfil}, [Nome]{this.Nome}";
        }
    }
}
