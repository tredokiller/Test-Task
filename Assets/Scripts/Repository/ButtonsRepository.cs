using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Managers;
using Models;
using Models.Exceptions;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Repository
{
    public class ButtonsRepository : IRepository<ButtonModel>
    {
        private readonly ButtonsManager _buttonsManager;
        private const string BaseUrl = "https://65d52f563f1ab8c634369e2d.mockapi.io/buttons";
        
        public ButtonsRepository(ButtonsManager buttonsManager)
        {
            _buttonsManager = buttonsManager ? buttonsManager : throw new ArgumentNullException(nameof(buttonsManager));
        }
        
        public async Task<IEnumerable<ButtonModel>> GetAll()
        {
            UnityWebRequest request = UnityWebRequest.Get(BaseUrl);
            await request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var response = request.downloadHandler.text;
                return JsonConvert.DeserializeObject<List<ButtonModel>>(response);
            }

            throw new BadRequestException(request.error);
        }

        public async Task<ButtonModel> Get(int id)
        {
            UnityWebRequest request = UnityWebRequest.Get($"{BaseUrl}/{id}");
            await request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var response = request.downloadHandler.text;
                return JsonUtility.FromJson<ButtonModel>(response);
            }

            throw new BadRequestException(request.error);
        }

        public async Task<ButtonModel> Create(ButtonModel button)
        {
            string json = JsonUtility.ToJson(button);
            var request = new UnityWebRequest(BaseUrl, "POST");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            
            request.SetRequestHeader("Content-Type", "application/json");

            await request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var response = request.downloadHandler.text;
                
                _buttonsManager.CreateButton(button);
                
                return JsonUtility.FromJson<ButtonModel>(response);
            }

            throw new BadRequestException(request.error);
        }
        public async Task<ButtonModel> Update(ButtonModel button)
        {
            string json = JsonUtility.ToJson(button);
            var request = new UnityWebRequest($"{BaseUrl}/{button.id}", "PUT");
            
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            
            request.SetRequestHeader("Content-Type", "application/json");

            await request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var response = request.downloadHandler.text;
                
                _buttonsManager.UpdateButton(button);
                
                return JsonUtility.FromJson<ButtonModel>(response);
            }

            throw new BadRequestException(request.error);
        }

        public async Task Remove(ButtonModel button)
        {
            UnityWebRequest request = UnityWebRequest.Delete($"{BaseUrl}/{button.id}");
            await request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                _buttonsManager.RemoveButton(button.id);
            }

            throw new BadRequestException(request.error);
        }
    }
}
