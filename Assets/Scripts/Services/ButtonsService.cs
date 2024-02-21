using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Models.Exceptions;
using Repository;
using UnityEngine;

namespace Services
{
    public class ButtonsService
    {
        private readonly IRepository<ButtonModel> _buttonsRepository;

        public ButtonsService(IRepository<ButtonModel> buttonsRepository)
        {
            _buttonsRepository = buttonsRepository ?? throw new ArgumentNullException(nameof(buttonsRepository));
        }

        public async Task<IEnumerable<ButtonModel>> GetAllButtons()
        {
            return await _buttonsRepository.GetAll();
        }

        public async Task<ButtonModel> GetButton(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException(BadRequestException.WrongIdMessage);
            }
            
            var result = await _buttonsRepository.Get(id);

            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }

        public async Task<ButtonModel> CreateButton(ButtonModel type)
        {
            if (type == null)
            {
                throw new BadRequestException();
            }

            var response = await _buttonsRepository.Create(type);

            return response;
        }

        public async Task RemoveButton(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException(BadRequestException.WrongIdMessage);
            }

            var type = _buttonsRepository.Get(id);

            if (type.Result == null)
            {
                throw new NotFoundException();
            }

            await _buttonsRepository.Remove(type.Result);
        }

        public Task<ButtonModel> UpdateButtonModel(ButtonModel type)
        {
            if (type == null)
            {
                throw new BadRequestException();
            }

            var response = _buttonsRepository.Update(type).Result;

            return Task.FromResult(response);
        }
    }
}
