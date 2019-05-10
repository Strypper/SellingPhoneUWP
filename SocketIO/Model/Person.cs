using System.Runtime.Serialization;
namespace SocketIO.Model
{
    class Person
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string IUID { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string ProfileImage { get; set; }
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public int PhoneNumber { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
