using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunescapeApp.Data;
using RunescapeApp.Services;

namespace RunescapeApp.Pages
{
    public class AddItemModel : PageModel
    {
        private readonly EquipmentService service;

        public AddItemModel(EquipmentService service)
        {
            this.service = service;
        }
        [BindProperty]
        public Equipment Equipment { get; set; }
        public List<Position> Positions { get; set; }
        public List<Rarity> Rarities { get; set; }
        public async Task OnGet()
        {
            await GetData();
        }
        public async Task<IActionResult> OnPost()
        {
            await GetData();
            await service.AddNewEquipment(Equipment);
            return RedirectToPage("./Index");
        }
        public async Task GetData()
        {
            Positions = await service.ReturnPositionList();
            Rarities = await service.ReturnRarityList();

        }
    }
}
