using AutoMapper;
using Entities;
using MVCPresentationLayer.Models.Pet;

namespace MVCPresentationLayer.Profiles
{
    public class PetProfille : Profile
    {
        public PetProfille()
        {
            CreateMap<PetInsertViewModel, Pet>();
            CreateMap<Pet, PetSelectViewModel>();
        }
    }
}
