using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunescapeApp.Data;
using RunescapeApp.Services;

namespace RunescapeApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EquipmentService service;
        private readonly RunescapeContext dbContext;

        public IndexModel(ILogger<IndexModel> logger, EquipmentService service)
        {
            _logger = logger;
            this.service = service;
        }

        public List<Position> Positions { get; set; }
        public List<Equipment> Equipment { get; set; }
        [BindProperty]
        public List<int> SelectedIds { get; set; } = new List<int>();
        public Stats Stats { get; set; }
        public async Task OnGet()
        {
            await GetData();
            Console.WriteLine("Get");
        }
        public async Task OnPost()
        {
            await GetData();
            Console.WriteLine("Post");
            Stats = new Stats();
            foreach (var item in SelectedIds) 
            {
                var newStab = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().Stab;
                Stats.Stab = Stats.Stab + newStab;
                var newSlash = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().Slash;
                Stats.Slash = Stats.Slash + newSlash;
                var newCrush = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().Crush;
                Stats.Crush = Stats.Crush + newCrush;
                var newMagic = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().Magic;
                Stats.Magic = Stats.Magic + newMagic;
                var newRanged = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().Ranged;
                Stats.Ranged = Stats.Ranged + newRanged;
                var newStabDef = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().StabDef;
                Stats.StabDef = Stats.StabDef + newStabDef;
                var newSlashDef = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().SlashDef;
                Stats.SlashDef = Stats.SlashDef + newSlashDef;
                var newCrushDef = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().CrushDef;
                Stats.CrushDef = Stats.CrushDef + newCrushDef;
                var newMagicDef = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().MagicDef;
                Stats.MagicDef = Stats.MagicDef + newMagicDef;
                var newRangedDef = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().RangedDef;
                Stats.RangedDef = Stats.RangedDef + newRangedDef;
                var newStrBonus = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().StrengthBonus;
                Stats.StrengthBonus = Stats.StrengthBonus + newStrBonus;
                var newRangedBonus = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().RangedBonus;
                Stats.RangedBonus = Stats.RangedBonus + newRangedBonus;
                var newMagicBonus = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().MagicBonus;
                Stats.MagicBonus = Stats.MagicBonus + newMagicBonus;
                var newPrayerBonus = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().PrayerBonus;
                Stats.PrayerBonus = Stats.PrayerBonus + newPrayerBonus;
                var HasSpecial = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().SpecialAttack;
                if (HasSpecial)
                {
                    Stats.SpecialAttack = true;
                }
            } 
        }
        public async Task GetData()
        {
           
            Positions = await service.ReturnPositionList();
            
            Equipment = await service.ReturnEquipmentList();
        }
    }
}
