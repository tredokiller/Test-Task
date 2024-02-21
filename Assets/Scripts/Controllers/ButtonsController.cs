using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Models.Exceptions;
using Services;
using UnityEngine;

namespace Controllers
{
    public class ButtonsController
    {
        private readonly ButtonsService _buttonsService;
        
        public ButtonsController(ButtonsService service)
        {
            _buttonsService = service ?? throw new ArgumentNullException(nameof(service));
        }
        
        public async Task<ButtonModel> CreateButton(ButtonModel model)
        {
            return await _buttonsService.CreateButton(model);
        }
        
        public async Task<IEnumerable<ButtonModel>> GetAllButtons()
        {
            return await _buttonsService.GetAllButtons();
        }
        
        public async Task<ButtonModel> GetButton(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException(BadRequestException.WrongIdMessage);
            }

            return await _buttonsService.GetButton(id);
        }

        public async Task RemoveButton(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException(BadRequestException.WrongIdMessage);
            }

            await _buttonsService.RemoveButton(id);
        }
        
        public async Task<ButtonModel> UpdateButton(ButtonModel model)
        {
            return await _buttonsService.UpdateButtonModel(model);
        }
    }
}
