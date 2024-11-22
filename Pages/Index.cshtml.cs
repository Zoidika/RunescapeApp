using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunescapeApp.Data;

namespace RunescapeApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Position> Positions { get; set; }
        public List<Equipment> Equipment { get; set; }
        [BindProperty]
        public List<int> SelectedIds { get; set; } = new List<int>();
        public Stats Stats { get; set; }
        public void OnGet()
        {
            GetData();
            Console.WriteLine("Get");
        }
        public void OnPost()
        {
            GetData();
            Console.WriteLine("Post");
            Stats = new Stats();
            foreach (var item in SelectedIds) 
            {
                var newStab = Equipment.Where(e => e.EquipmentId == item).FirstOrDefault().Stab;
                Stats.Stab = Stats.Stab + newStab;
            } 
        }
        public void GetData()
        {
            Positions = new List<Position>()
            {
                 new Position() { PositionName="Head", PositionId=1 },
                 new Position() { PositionId=2, PositionName="Neck"},
                 new Position() { PositionName="Legs", PositionId =3},

            };
            Equipment = new List<Equipment>()
            {
                new Equipment() { EquipmentId=0, PositionId=Positions.Where(e => e.PositionName=="Head").FirstOrDefault().PositionId, Name="Dragon Med Helm", Stab=10},
                new Equipment() { EquipmentId=1, PositionId=Positions.Where(e => e.PositionName=="Neck").FirstOrDefault().PositionId, Name="Amulet Of Glory", Stab=18 },
                new Equipment() { EquipmentId=2, PositionId=Positions.Where(e => e.PositionName=="Legs").FirstOrDefault().PositionId, Name="Dharok's Platelegs", Stab=25}
            };
        }
    }
}
