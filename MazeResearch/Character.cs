using System;

namespace NSBattle
{
    public class Character
    {
        public long ID { get; set; }
        public int TeamID { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public long PrototypeID { get; set; }
        public int Hitpoint { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Appearance { get; set; }
        public long HeadEquipmentID { get; set; }
        public long BodyEquipmentID { get; set; }
        public long ArmEquipmentID { get; set; }
        public long LegEquipmentID { get; set; }
        public long FootEquipmentID { get; set; }
        public long Accessory1ID { get; set; }
        public long Accessory2ID { get; set; }
        public long Accessory3ID { get; set; }
        public long Accessory4ID { get; set; }
        public string Accessory5ID { get; set; }
        public long PrimeSoul { get; set; }
    }
}