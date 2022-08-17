using BLL.Extensions;
using BLL.Interfaces;
using BLL.Validators.Cliente;
using Common;
using DAO.Impl;
using DAO.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteDAO clienteDao;
        public ClienteService(IClienteDAO clienteDao)
        {
            this.clienteDao = clienteDao;
        }
        public async Task<DataResponse<Cliente>> GetAll()
        {
            return await clienteDao.GetAll();
        }

        public async Task<Response> Insert(Cliente c)
        {
            Response response = new ClienteInsertValidator().Validate(c).ConvertToResponse();

            if (!response.HasSuccess)
            {
                return response;
            }

            c.EstaAtivo = true;

            response = await clienteDao.Insert(c);
            return response;
        }
    }
}
