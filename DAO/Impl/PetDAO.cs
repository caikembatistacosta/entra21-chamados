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
    public class PetDAO : IPetDAO
    {
        private readonly PetShopDbContext _db;
        public PetDAO(PetShopDbContext db)
        {
            this._db = db;
        }
        public async Task<DataResponse<Pet>> GetAll()
        {
            DataResponse<Pet> response = new DataResponse<Pet>();

            try
            {
                List<Pet> pets = _db.Pets.Where(p => p.EstaAtivo).ToList();
                response.HasSuccess = true;
                response.Message = "Pets selecionados com sucesso!";
                response.Data = pets;
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

        public async Task<Response> Insert(Pet pet)
        {
            _db.Pets.Add(pet);
            try
            {
                _db.SaveChanges();
                return new Response()
                {
                    HasSuccess = true,
                    Message = "Neném cadastrado com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    HasSuccess = false,
                    Message = "Erro no banco de dados, contate o administrador.",
                    Exception = ex
                };
            }
        }
    }
}
