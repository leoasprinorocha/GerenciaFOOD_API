using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GrerenciaFOOD_read_Infrastructure.Persistence.Funcionario
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private static List<Funcionario> ListaFake = new List<Funcionario>();
        public void Delete(Funcionario entity)
        {
            ListaFake.Remove(entity);
        }

        public void Delete(object id)
        {
            ListaFake.Remove(this.Find(id));
        }

        public Funcionario Find(object id)
        {
            return ListaFake.AsQueryable().FirstOrDefault(c => c.Id.Equals(id));
        }

        public IQueryable<Funcionario> Get(Expression<Func<Funcionario, bool>> predicate = null)
        {
            return predicate != null ? ListaFake.AsQueryable().Where(predicate) : ListaFake.AsQueryable();
        }

        public void Insert(Funcionario entity)
        {
            if (entity.Id == -1)
            {
                entity = new Funcionario(
                    ListaFake.Count + 1,
                    entity.Perfil,
                    entity.Nome
                    );
                ListaFake.Add(entity);
            }

        }

        public void Update(Funcionario entity)
        {
            var funcionario = this.Find(entity.Id);
            funcionario.Perfil = entity.Perfil;
            funcionario.Nome = entity.Nome;
        }
    }
}
