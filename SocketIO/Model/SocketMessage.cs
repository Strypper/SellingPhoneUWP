using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SocketIO.Model
{
    [DataContract]
    public class SocketMessage
    {
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string handle { get; set; }
    }
}
