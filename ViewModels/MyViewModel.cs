using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using dotnetClientDemo.Services;
using dotnetClientDemo.Models;


namespace dotnetClientDemo.ViewModels
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private MyModel _myModel;

        public MyModel MyModel
        {
            get => _myModel;
            set
            {
                _myModel = value;
                OnPropertyChanged();
            }
        }

        public MyViewModel()
        {
            _apiService = new ApiService();
        }

    

        // public async void LoadData()
        // {
        //     try
        //     {
        //         // Call the API to get the data
        //         var response = await _apiService.GetDataFromApi();

        //          // Deserialize the response string into a MyModel object
        //         // MyModel = Newtonsoft.Json.JsonConvert.DeserializeObject<MyModel>(response);

        //         MyModel.HttpResponse = response;
        //     }
        //     catch (Exception ex)
        //     {
        //         // handle error
        //     }
        // }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
