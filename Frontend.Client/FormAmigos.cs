using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend.Models;
using System.Configuration;

namespace Client
{

    public partial class FormAmigos : Form
    {

        private AmigoData[] amigos;

        public FormAmigos()
        {
            InitializeComponent();
        }

        private void FormAmigos_Load(object sender, EventArgs e)
        {

            // carrega amigos
            this.CarregarAmigos();

        }

        private void listaAmigos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            // exibe dados do amigo
            this.ExibeDadosAmigo(this.amigos[e.ItemIndex]);

        }

        private void CarregarAmigos()
        {

            // carrega amigos
            this.amigos = Web.HttpGet<AmigoData[]>("http://localhost:1501/api/amigos");

            // exibe amigos na lista
            listaAmigos.Items.Clear();
            foreach (AmigoData entry in amigos)
                listaAmigos.Items.Add(entry.Nome);

        }

        private void ExibeDadosAmigo(AmigoData amigo)
        {

            // exibe dados do amigo
            this.textId.Text = amigo.IdAmigo.ToString();
            this.textNome.Text = amigo.Nome;
            this.textLocal.Text = amigo.Local;
            this.textLatitude.Text = amigo.Latitude.ToString("N8");
            this.textLongitude.Text = amigo.Longitude.ToString("N8");

            // carrega amigos proximos
            this.CarregarProximos(amigo);

        }

        private void CarregarProximos(AmigoData amigo)
        {

            // carrega amigos
            AmigoData[] proximos = Web.HttpGet<AmigoData[]>(String.Format("http://localhost:1501/api/proximos/?idAmigo={0}&quantidade={1}", amigo.IdAmigo, 3));

            // exibe amigos na lista
            listaProximos.Items.Clear();
            foreach (AmigoData entry in proximos)
                listaProximos.Items.Add(new ListViewItem(new string[] { entry.Nome, entry.Local, entry.Latitude.ToString("N8"), entry.Longitude.ToString("N8") }));

        }

    }

}
