
using Hotel.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repositorio.Implementaciones
{
    public class GenericoRepositorio<Tmodelo> : IGenericoRepositorio<Tmodelo> where Tmodelo : class
    {

        private readonly HotelContext _dbCtx;

        public GenericoRepositorio(HotelContext dbCtx)
        {
            _dbCtx = dbCtx;
        }
        public IQueryable<Tmodelo> GetAll(Expression<Func<Tmodelo, bool>>? query = null)
        {
            try
            {
                IQueryable<Tmodelo> Consulta = (query == null) ? _dbCtx.Set<Tmodelo>() : _dbCtx.Set<Tmodelo>().Where(query);
                return Consulta;
            }
            catch (Exception)
            {

                throw;
            };
        }

        public async Task<Tmodelo> Create(Tmodelo model)
        {
            try
            {
                _dbCtx.Set<Tmodelo>().Add(model);
                await _dbCtx.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(Tmodelo model)
        {
            try
            {
                _dbCtx.Set<Tmodelo>().Remove(model);
                await _dbCtx.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> Update(Tmodelo model)
        {
            _dbCtx.Entry(model).State = EntityState.Added;
            _dbCtx.Set<Tmodelo>().Update(model);
            await _dbCtx.SaveChangesAsync();
            return true;
        }

    }
}
