using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiCRUDDepartamentos.Models;
using Newtonsoft.Json;

namespace ApiCRUDDepartamentos.Services {
    public class ServiceDepartamentos {

        private String url;

        public ServiceDepartamentos () {
            this.url = "https://apicruddepartamentoscorepgs.azurewebsites.net/";
        }

        private async Task<T> CallApiAsync<T>(String request) {
            using(HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept
                    .Add(new System.Net.Http.Headers
                    .MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode) {
                    String json = await response.Content.ReadAsStringAsync();
                    T data = JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
                else {
                    return default(T);
                }
            }
        }

        public async Task<List<Departamento>> GetDepartamentosAsync () {
            String request = "api/departamentos";
            List<Departamento> departamentos =
                await this.CallApiAsync<List<Departamento>>(request);
            return departamentos;
        }

        public async Task<Departamento> GetDepartamentoAsync (int idDepartamento) {
            String request = "api/departamentos/" + idDepartamento;
            Departamento departamento = await this.CallApiAsync<Departamento>(request);
            return departamento;
        }

        public async Task InsertDepartamentoAsync (int idDepartamento, String nombre, String localidad) {
            Departamento departamento = new Departamento(idDepartamento, nombre, localidad);
            String json = JsonConvert.SerializeObject(departamento);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using(HttpClient client = new HttpClient()) {
                String request = "api/departamentos";
                Uri uri = new Uri(this.url + request);
                await client.PostAsync(uri, content);
            }
        }

        public async Task UpdateDepartamentoAsync (int idDepartamento, String nombre, String localidad) {
            Departamento departamento = await this.GetDepartamentoAsync(idDepartamento);
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            String json = JsonConvert.SerializeObject(departamento);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient()) {
                String request = "api/departamentos";
                Uri uri = new Uri(this.url + request);
                await client.PutAsync(uri, content);
            }
        }


        public async Task DeleteDepartamentoAsync (int idDepartamento) {
            String request = "api/departamentos" + idDepartamento;
            Uri uri = new Uri(this.url + request);

            using(HttpClient client = new HttpClient()) {
                await client.DeleteAsync(uri);
            }
        }
    }
}
