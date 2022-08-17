using AutoMapper;
using Entities;
using MVCPresentationLayer.Models.Cliente;

namespace MVCPresentationLayer.Profiles
{
    public class ClienteProfile:Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteInsertViewModel, Cliente>();
            CreateMap<Cliente, ClienteSelectViewModel>();

        }
    }
}
