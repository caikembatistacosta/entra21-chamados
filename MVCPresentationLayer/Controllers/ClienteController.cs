﻿using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using Common;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MVCPresentationLayer.Models.Cliente;

namespace MVCPresentationLayer.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clientesvc;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService svc, IMapper mapper)
        {
            this._clientesvc = svc;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {

            DataResponse<Cliente> responseClientes = await _clientesvc.GetAll();

            if (!responseClientes.HasSuccess)
            {
                ViewBag.Errors = responseClientes.Message;
                return View();
            }


            List<ClienteSelectViewModel> clientes = _mapper.Map<List<ClienteSelectViewModel>>(responseClientes.Data);
            return View(clientes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteInsertViewModel viewModel)
        {

            Cliente cliente = _mapper.Map<Cliente>(viewModel);

            Response response = await _clientesvc.Insert(cliente);

            if (response.HasSuccess)
                return RedirectToAction("Index");

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
