using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ApiCRUDDepartamentos.Models {
    public class Departamento {

        [JsonProperty("idDepartamento")]
        public int IdDepartamento { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("localidad")]
        public string Localidad { get; set; }

        public Departamento (int idDepartamento, string nombre, string localidad) {
            IdDepartamento = idDepartamento;
            Nombre = nombre;
            Localidad = localidad;
        }

        public Departamento () {}
    }
}

