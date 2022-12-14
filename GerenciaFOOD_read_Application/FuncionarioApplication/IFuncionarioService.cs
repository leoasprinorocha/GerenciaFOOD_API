using GrerenciaFOOD_read_Infrastructure.Persistence.Funcionario;

namespace GerenciaFOOD_read_Application.FuncionarioApplication
{
    public interface IFuncionarioService : IApplicationService<Funcionario>
    {
        Funcionario Find(int id);
        IQueryable<Funcionario> GetByName(string nome);
        IQueryable<Funcionario> GetAll();
        void Insert(Funcionario funcionario);
        void Update(Funcionario funcionario);
        void Delete(int id);
    }
}
