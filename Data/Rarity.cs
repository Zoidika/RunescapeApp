namespace RunescapeApp.Data
{
    public class Rarity
    {
        public int RarityId { get; set; }
        public string RarityName { get; set; }
        public int RarityLevel { get; set; }
        public Rarity(string rarityName, int rarityLevel)
        {
            RarityName = rarityName;
            RarityLevel = rarityLevel;
        }
    }
}
