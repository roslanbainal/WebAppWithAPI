﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppWithAPI.Infrastructures.Interfaces;
using WebAppWithAPI.Models.ViewModels;

namespace WebAppWithAPI.Infrastructures.Services
{
    public class PoskodService : IPoskodService
    {
        private readonly ILogger<PoskodService> logger;

        public PoskodService(ILogger<PoskodService> logger)
        {
            this.logger = logger;
        }

        public async Task<FullPoskodViewModel> GetPoskod(string search, int pageNumber, int pageSize)
        {
            try
            {
                var apiResult = new FullPoskodViewModel();
                var API_URL = Constants.API.BaseURL;
                search = (string.IsNullOrEmpty(search)) ? "Johor" : search;

                using (var client = new HttpClient())
                {

                    string url = $"{API_URL}Poskod?PageNumber={pageNumber}&PageSize={pageSize}&Search={search}";
                    var response = client.GetAsync(url).Result;
                    string responseAsString = await response.Content.ReadAsStringAsync();
                    apiResult = JsonConvert.DeserializeObject<FullPoskodViewModel>(responseAsString);
                }

                logger.LogInformation($"Call poskod api for negeri {search}");
                return apiResult = (apiResult.data != null) ? apiResult : null;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error call poskod api");
                return null;
            }
           
        }
    }
}
