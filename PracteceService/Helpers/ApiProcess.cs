using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracteceService.Helpers
{
    public class ApiProcess
    {
        public IRestResponse RequestApi(string url, RestRequest request)
        {
            try
            {
                var restClient = new RestClient(url);

                var response = restClient.Execute(request);

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
