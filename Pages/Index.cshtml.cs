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
            } 
        }
        public async Task GetData()
        {
           
            Positions = await service.ReturnPositionList();
            
            Equipment = await service.ReturnEquipmentList();
        }
    }
}
