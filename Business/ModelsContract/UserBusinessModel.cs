using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Business.ModelsContract
{
    [DataContract]
    public class UserBusinessModel: RespuestaService
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }

    }
}