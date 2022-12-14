using GrerenciaFOOD_read_Infrastructure.Persistence.Funcionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaFOOD_read_Application.FuncionarioApplication
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
        public void Delete(int id)
        {
            _funcionarioRepository.Delete(id);
        }

        public Funcionario Find(int id)
        {
            return _funcionarioRepository.Find(id);
        }

        public IQueryable<Funcionario> GetAll()
        {
            return _funcionarioRepository.Get();
        }

        public IQueryable<Funcionario> GetByName(string nome)
        {
            return _funcionarioRepository.Get(c => c.Nome.ToUpper().Contains(nome.ToUpper()));
        }

        public void Insert(Funcionario funcionario)
        {
            _funcionarioRepository.Insert(funcionario);
        }

        public void Update(Funcionario funcionario)
        {
            _funcionarioRepository.Update(funcionario);
        }
    }
}
