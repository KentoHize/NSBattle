using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSBattle
{
    public class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int TeamID { get; set; }
        public int? PrototypeID { get; set; }
        public int Hitpoint { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Appearance { get; set; }
        public int? HeadEquipmentID { get; set; }
        public int? BodyEquipmentID { get; set; }
        public int? ArmEquipmentID { get; set; }
        public int? LegEquipmentID { get; set; }
        public int? FootEquipmentID { get; set; }
        public int? Accessory1ID { get; set; }
        public int? Accessory2ID { get; set; }
        public int? Accessory3ID { get; set; }
        public int? Accessory4ID { get; set; }
        public int? Accessory5ID { get; set; }
        public int? PrimeSoul { get; set; }
    }
}
