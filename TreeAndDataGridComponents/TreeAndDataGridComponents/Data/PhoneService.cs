using TreeAndDataGridComponents.Data;

namespace TreeAndDataGridComponents.Data
{
    public class PhoneService : IPhoneService
    {
        public List<Phone> GetPhones()
        {
            return new List<Phone>
            {
                new Phone { Manufacturer = "Apple", Name = "iPhone 14", Cost = 699, Type = "Smartphone", OS = "iOS 15" },
                new Phone { Manufacturer = "Apple", Name = "iPhone 14 Pro", Cost = 999, Type = "Smartphone", OS = "iOS 15"  },
                new Phone { Manufacturer = "Apple", Name = "iPhone 14 Pro Max", Cost = 1599, Type = "Smartphone", OS = "iOS 16"  },
                new Phone { Manufacturer = "Samsung", Name = "Galaxy Z Fold", Cost = 1999, Type = "Smartphone", OS = "Android 11"  },
                new Phone { Manufacturer = "Samsung", Name = "Galazy S23", Cost = 1499, Type = "Smartphone", OS = "Android 12"  },
                new Phone { Manufacturer = "Google", Name = "Pixel 7", Cost = 699, Type = "Smartphone", OS = "Android 11"  },
                new Phone { Manufacturer = "Google", Name = "Pixel 7 Pro", Cost = 849, Type = "Smartphone", OS = "Android 12"  }
            };
        }
    }
}