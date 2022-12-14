using GrerenciaFOOD_read_Infrastructure.Persistence.Funcionario;


namespace GrerenciaFOOD_read_Infrastructure.Persistence
{
    public class Context : IContext
    {
        public IFuncionarioRepository Funcionario { get; set; }
        public Context(IFuncionarioRepository funcionarioRepository)
        {
            this.Funcionario = funcionarioRepository;
        }


    }
}
