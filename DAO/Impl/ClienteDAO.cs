using Common;
using DAO.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class ClienteDAO : IClienteDAO
    {
        private readonly PetShopDbContext _db;
        public ClienteDAO(PetShopDbContext db)
        {
            this._db = db;
        }

        public async Task<DataResponse<Cliente>> GetAll()
        {
            DataResponse<Cliente> response = new DataResponse<Cliente>();

            try
            {
                List<Cliente> clientes = _db.Clientes.Where(c => c.EstaAtivo).ToList();
                response.HasSuccess = true;
                response.Message = "Clientes selecionados com sucesso!";
                response.Data = clientes;
                return response;
            }
            catch (Exception ex)
            {
                response.HasSuccess = false;
                response.Message = "Erro no banco, contate o administrador.";
                response.Exception = ex;
                return response;
            }
        }

        public async Task<Response> Insert(Cliente cliente)
        {
            _db.Clientes.Add(cliente);

            try
            {
                _db.SaveChanges();
                return new Response()
                {
                    HasSuccess = true,
                    Message = "Cliente cadastrado com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    HasSuccess = false,
                    Message = "Erro no banco de dados, contate o daministrador",
                    Exception = ex
                };
            }
        }
    }
}
