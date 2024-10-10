using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.Model.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace EngLabAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EngLabContext _context;

        private IDbContextTransaction _transaction;

        public UnitOfWork(EngLabContext context)
        {
            _context = context;
            _transaction = null!;
        }
        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                return;
            }

            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch
            {

                await _transaction.RollbackAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null!;
            }
        }

        private bool _isDisposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _isDisposed = true;
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();

        }


    }
}