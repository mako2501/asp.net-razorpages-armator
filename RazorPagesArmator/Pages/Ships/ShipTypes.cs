using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesArmator.Pages.Ships
{
    //klasa dziedziczy z listy i bedziue wykorzystywana do generowania selecta w formularzu dla okreslania typow statkow
    public class ShipTypes : List<SelectListItem>
    {
        //w konstruktorze predefiniowane elementy listy
        public ShipTypes()
        {
            this.Add(new SelectListItem() { Text = "Cargo Ship", Value = "Cargo Ship" });
            this.Add(new SelectListItem() { Text = "Container Ship", Value = "Container Ship" });
            this.Add(new SelectListItem() { Text = "Tanker", Value = "Tanker" });
            this.Add(new SelectListItem() { Text = "LPG Tanker", Value = "LPG Tanker" });
            this.Add(new SelectListItem() { Text = "Pilot", Value = "Pilot" });
            this.Add(new SelectListItem() { Text = "Bulk Carrier", Value = "Bulk Carrier" });
            this.Add(new SelectListItem() { Text = "Tug", Value = "Tug" });
            this.Add(new SelectListItem() { Text = "Sailing Vessel", Value = "Sailing Vessel" });
            this.Add(new SelectListItem() { Text = "Warship", Value = "Warship" });
        }
    }
}
