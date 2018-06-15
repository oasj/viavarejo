using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend;
using Backend.Services.Controllers;
using Backend.Models;
using System.Diagnostics;
using System.Configuration;

namespace Backend.Tests
{
    [TestClass]
    public class AmigosControllerTest
    {

        private static string token = ConfigurationManager.AppSettings["AccessToken"];

        [Priority(0), TestMethod]
        public void CreateAll()
        {

            this.CriarAmigo("Marcelo", "Nova York", 40.66162840m, -74.05498200m);
            this.CriarAmigo("Paulo", "Montauk", 41.03378650m, -72.08242110m);
            this.CriarAmigo("Josh", "Princeton", 40.34556260m, -74.61154540m);
            this.CriarAmigo("Audrey", "Montreal", 45.64088870m, -73.16964820m);
            this.CriarAmigo("Jamal", "Ottawa", 45.64376910m, -75.28571800m);
            this.CriarAmigo("Christine", "Quebec", 46.76787270m, -71.07313440m);
            this.CriarAmigo("John", "Toronto", 43.80185750m, -79.15680050m);
            this.CriarAmigo("Mathews", "Greenwood", 39.61753000m, -86.09537610m);
            this.CriarAmigo("Javene", "London", 51.51479610m, -0.10525320m);
            this.CriarAmigo("Morton", "Kent", 51.27567550m, 1.10406300m);
            this.CriarAmigo("Agatha", "Bruxels", 50.84819010m, 4.36015050m);
            this.CriarAmigo("Pierre", "Paris", 48.87774200m, 2.39946190m);
            this.CriarAmigo("Mariane", "Cartagena", 37.63543190m, -0.97890970m);
            this.CriarAmigo("Joane", "Gibraltar", 36.14471890m, -5.34995600m);
            this.CriarAmigo("Jacob", "Seviglia", 37.40585290m, -5.95745890m);
            this.CriarAmigo("João", "Porto", 41.16951560m, -8.61346010m);
            this.CriarAmigo("Mohamed", "Oujda", 34.68105660m, -1.90684130m);
        
        }

        [Priority(1), TestMethod]
        public void Create()
        {
        
            // inicializa o controlador
            AmigosController controller = new AmigosController();

            // cria o amigo
            controller.Put(token, new AmigoData()
            {
                Nome = "Cláudio",
                Local = "Santos",
                Latitude = -23.9862526m,
                Longitude = -46.308403m
            });

            Assert.IsTrue(this.ExisteAmigo(-23.9862526m, -46.308403m));

        }

        [Priority(2), TestMethod]
        public void Alter()
        {

            // inicializa o controlador
            AmigosController controller = new AmigosController();

            //retorna o id do amigo
            int id = new IdController().Post(token, -23.9862526m, -46.308403m);

            // altera o amigo
            controller.Put(token, new AmigoData()
            {
                IdAmigo = id,
                Nome = "Cláudio",
                Local = "Guarujá",
                Latitude = -23.9916395m,
                Longitude = -46.2615829m
            });

            Assert.IsTrue(this.ExisteAmigo(-23.9916395m, -46.2615829m));

        }

        [Priority(3), TestMethod]
        public void Get()
        {

            // inicializa o controlador
            AmigosController controller = new AmigosController();

            //retorna o id do amigo
            int id = new IdController().Post(token, -23.9916395m, -46.2615829m);

            // retorna o amigo
            AmigoData amigo = controller.Post(token, id);

            Assert.IsTrue((amigo != null));

        }

        [Priority(4), TestMethod]
        public void Near()
        {

            // inicializa o controlador
            ProximosController controller = new ProximosController();

            //retorna o amigo
            IEnumerable<AmigoData> near = controller.Post(token, 40.66162840m, -74.05498200m, 3);
            foreach (AmigoData entry in near)
            {
                Debug.Print(String.Format("Id: {0}, Nome: {1}, Local: {2}, Latitude: {3}, Longitude: {4}",
                    entry.IdAmigo, entry.Nome, entry.Local, entry.Latitude, entry.Longitude));
            }

        }


        [Priority(5), TestMethod]
        public void Delete()
        {

            // inicializa o controlador
            AmigosController controller = new AmigosController();

            //retorna o amigo
            AmigoData amigo = controller.Post(token, -23.9916395m, -46.2615829m);

            // verifica se o amigo existe
            if (amigo != null)
            {

                // apaga o amigo
                controller.Delete(token, amigo.IdAmigo);

            }

            Assert.IsFalse(this.ExisteAmigo(-23.9916395m, -46.2615829m));

        }

        private bool ExisteAmigo(decimal latitude, decimal longitude)
        {

            // inicializa o controlador
            AmigosController controller = new AmigosController();

            // verifica se o amigo existe
            return (controller.Post(token, latitude, longitude) != null);

        }

        private void CriarAmigo(string nome, string local, decimal latitude, decimal longitude)
        {

            // inicializa o controlador
            AmigosController controller = new AmigosController();

            // cria o amigo
            controller.Put(token, new AmigoData()
            {
                Nome = nome,
                Local = local,
                Latitude = latitude,
                Longitude = longitude
            });

        }
        
    }

}
