using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using Common;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MVCPresentationLayer.Models.Pet;

namespace MVCPresentationLayer.Controllers
{
    //DEVE HERDAR DE CONTROLLER!
    //DEVE TERMINAR COM A PALAVRA CONTROLLER
    public class PetController : Controller
    {
        private readonly IPetService _petsvc;
        private readonly IMapper _mapper;

        public PetController(IPetService svc, IMapper mapper)
        {
            this._petsvc = svc;
            this._mapper = mapper;
        }
        //meusite.com/Pet
        //meusite.com/Pet/Index
        public async Task<IActionResult> Index()
        {   

            DataResponse<Pet> responsePets = await _petsvc.GetAll();

            if (!responsePets.HasSuccess)
            {
                //Se o select falhou, retorne a mensagem de erro para o cliente
                ViewBag.Errors = responsePets.Message;
                return View();
            }
            //Se chegou aqui, o select funcionou, bora transformar a List<Pet> em uma List<PetSelectViewModel>

           // MapperConfiguration mapper = new MapperConfiguration(m =>
           //    m.CreateMap<Pet, PetSelectViewModel>()
           //);

            List<PetSelectViewModel> pets =
                _mapper.Map<List<PetSelectViewModel>>(responsePets.Data);

            return View(pets);
        }

        //IActionResult - O que queremos que o navegador retorne!

        //meusite.com/Pet/Create
        [HttpGet]
        //Get -> Enter na url do navegador
        //    -> Histórico do navegador
        //    -> Clica num hiperlink
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //Binding
        //Post -> É clicando em um botão (submit) dentro de um form do /Pet/Create
        public async Task<IActionResult> Create(PetInsertViewModel viewModel)
        {
            //Converter PetInsertViewModel para Pet e jogar para o BusinessLogicalLayer
            //AutoMapper
            //Cria uma configuração de mapeador que diz que o objeto PetInsertViewModel pode ser convertido em um Pet
            //MapperConfiguration mapper = new MapperConfiguration(m =>
            //    m.CreateMap<PetInsertViewModel, Pet>()
            //);

            //Faz a conversão.
            Pet pet = _mapper.Map<Pet>(viewModel);

            //Chama a camada de negócio para validar o pet e posteriormente inseri-lo no banco de dados
            Response response = await _petsvc.Insert(pet);

            //Pet cadastrado com sucesso
            if (response.HasSuccess)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Errors = response.Message;
            return View();
        }


        public IActionResult Edit(int valor)
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

    }
}
