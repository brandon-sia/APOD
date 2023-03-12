using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APOD
{
    class SelectedDateObject
    {
        public SelectedDateModel? Model { get; set; }
    }

    internal class SelectedDateProcessor
    {
        public static async Task<SelectedDateModel> LoadImage()
        {
            string url = $"https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date={MainWindow.Date}&concept_tags=True";        

            using (HttpResponseMessage? response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {

                    // Read the response into a string
                    string responseString = await response.Content.ReadAsStringAsync();

                    var jsonObject = JsonConvert.DeserializeObject<SelectedDateModel>(responseString);

                    return jsonObject;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }
    }
}
