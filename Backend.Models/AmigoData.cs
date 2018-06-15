using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Backend.Models
{
    
    [DataContract(Name = "amigo")]
    public class AmigoData
    {

        /// <summary>Armazena o ID do amigo.</summary>
        [DataMemberAttribute(Name = "id")]
        public virtual int IdAmigo
        {
            get; set;
        }
        /// <summary>Armazena o nome do amigo.</summary>
        [DataMemberAttribute(Name = "nome")]
        public virtual string Nome
        {
            get; set;
        }
        /// <summary>Armazena o local do amigo.</summary>
        [DataMemberAttribute(Name = "local")]
        public virtual string Local
        {
            get; set;
        }
        /// <summary>Armazena a latitude do amigo.</summary>
        [DataMemberAttribute(Name = "latitude")]
        public virtual decimal Latitude
        {
            get; set;
        }
        /// <summary>Armazena a longitude do amigo.</summary>
        [DataMemberAttribute(Name = "longitude")]
        public virtual decimal Longitude
        {
            get; set;
        }

    }

}
