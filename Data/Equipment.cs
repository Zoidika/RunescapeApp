namespace RunescapeApp.Data
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public int RarityId { get; set; }
        public int PositionId { get; set; }
        public string Name { get; set; }
        public int Stab {  get; set; }
        public int Slash { get; set; }
        public int Crush { get; set; }
        public int Magic { get; set; }
        public int Ranged { get; set; }
        public int StabDef { get; set; }
        public int SlashDef { get; set; }
        public int CrushDef { get; set; }
        public int MagicDef { get; set; }
        public int RangedDef { get; set; }
        public int StrengthBonus { get; set; }
        public int RangedBonus { get; set; }
        public int MagicBonus { get; set; }
        public int PrayerBonus { get; set; }
        public bool SpecialAttack { get; set; }

        public Equipment(int rarityId, int positionId, string name, int stab, int slash, int crush, int magic, int ranged, int stabDef, int slashDef, int crushDef, int magicDef, int rangedDef, int strengthBonus, int rangedBonus, int magicBonus, int prayerBonus, bool specialAttack)
        {
            RarityId = rarityId;
            PositionId = positionId;
            Name = name;
            Stab = stab;
            Slash = slash;
            Crush = crush;
            Magic = magic;
            Ranged = ranged;
            StabDef = stabDef;
            SlashDef = slashDef;
            CrushDef = crushDef;
            MagicDef = magicDef;
            RangedDef = rangedDef;
            StrengthBonus = strengthBonus;
            RangedBonus = rangedBonus;
            MagicBonus = magicBonus;
            PrayerBonus = prayerBonus;
            SpecialAttack = specialAttack;
        }
    }
}
