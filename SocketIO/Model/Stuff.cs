using System.Runtime.Serialization;
namespace SocketIO.Model
{
    [DataContract]
    class Stuff
    {

        //Stuff
        [DataMember]
        public int DeviceID { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public int Storage { get; set; }
        [DataMember]
        public int Ram { get; set; }
        [DataMember]
        public double Battery { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string Processor { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public string DateUpload { get; set; }
        [DataMember]
        public int Usage { get; set; }
        [DataMember]
        public string CoverImagePath { get; set; }
        [DataMember]
        public string SecondImagePath { get; set; }
        [DataMember]
        public string ThirdImagePath { get; set; }
        [DataMember]
        public string SellDescription { get; set; }
        [DataMember]
        public string Location { get; set; }
        

        //Format proflie
        public string DollarSignPrice { get => Price.ToString("####.00") + "$";}
        public string BatteryMah { get => Battery.ToString() + "mAh"; }
    }
}
