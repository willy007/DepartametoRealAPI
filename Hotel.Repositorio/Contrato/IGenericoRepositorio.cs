using Hotel.Repositorio.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repositorio.Contrato
{
    public interface IGenericoRepositorio<TModelo> where TModelo : class
    {
        IQueryable<TModelo> GetAll(Expression<Func<TModelo ,bool>>? query = null);
        Task<TModelo> Create(TModelo model);
        Task<bool> Update(TModelo model);
        Task<bool> Delete(TModelo model);
    }
}
