using Microsoft.AspNetCore.Components;
using TreeAndDataGridComponents.Data;

namespace TreeAndDataGridComponents.Pages
{
    public partial class Tree
    {
        #region [Properties/Fields]
        List<Phone> phones = new();
        Dictionary<string, bool> expandedManufacturers = new();
        Dictionary<string, bool> expandedOS = new();

        [Parameter] 
        public EventCallback<List<Phone>> SelectedNodeChanged { get; set; }
        List<Phone> phonesToBeSent;
        #endregion

        #region [Methods]
        protected override void OnInitialized()
        {
            phones = phoneService.GetPhones();
        }

        List<string> GetDistinctManufacturers() =>
            phones.Select(p => p.Manufacturer).Distinct().ToList();

        List<string> GetDistinctOS(string manufacturer) =>
            phones.Where(p => p.Manufacturer == manufacturer).Select(p => p.OS).Distinct().ToList();

        List<Phone> GetPhonesByManufacturerAndOS(string manufacturer, string os) =>
            phones.Where(p => p.Manufacturer == manufacturer && p.OS == os).ToList();

        bool IsManufacturerExpanded(string manufacturer) =>
            expandedManufacturers.ContainsKey(manufacturer) && expandedManufacturers[manufacturer];

        bool IsOSExpanded(string osKey) =>
            expandedOS.ContainsKey(osKey) && expandedOS[osKey];

        void ToggleManufacturer(string manufacturer)
        {
            if (!expandedManufacturers.ContainsKey(manufacturer))
            {
                expandedManufacturers[manufacturer] = true;
            }
            else
            {
                expandedManufacturers[manufacturer] = !expandedManufacturers[manufacturer];
            }
            foreach (var os in GetDistinctOS(manufacturer))
            {
                expandedOS[$"{manufacturer}/{os}"] = false;
            }
        }

        void ToggleOS(string manufacturer, string os)
        {
            expandedOS[$"{manufacturer}/{os}"] = !expandedOS.ContainsKey($"{manufacturer}/{os}") || !expandedOS[$"{manufacturer}/{os}"];
        }

        void NodeClicked(string manufacturer = "", string os ="", Phone phone = null)
        {
            if (!string.IsNullOrEmpty(os))
            {
                phonesToBeSent = phones.Where(p => p.Manufacturer == manufacturer && p.OS == os).ToList();
            }
            else if (!string.IsNullOrEmpty(manufacturer))
            {
                phonesToBeSent = phones.Where(p => p.Manufacturer == manufacturer).ToList();
            }
              
            else if (phone != null)
            {
                phonesToBeSent = phones.Where(p => p.Name == phone.Name).ToList();
            }
            SelectedNodeChanged.InvokeAsync(phonesToBeSent);
        }
        #endregion
    }
}