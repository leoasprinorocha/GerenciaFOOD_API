using GrerenciaFOOD_read_Infrastructure.Persistence.Funcionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrerenciaFOOD_read_Infrastructure.Persistence
{
    public interface IContext
    {
        IFuncionarioRepository Funcionario { get; set; }
    }
}
