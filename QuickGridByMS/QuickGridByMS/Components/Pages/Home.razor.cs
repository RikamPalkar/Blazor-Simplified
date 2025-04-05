namespace QuickGridByMS.Components.Pages
{
    public partial class Home
    {

        private List<User> Users;
        private int _currentPage = 1;
        private int PageSize = 5;
        private IEnumerable<User> PagedUsers => Users
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize);

        private int TotalPages => (int)Math.Ceiling((double)Users.Count() / PageSize);

        private int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                StateHasChanged();
            }
        }

        private void PreviousPage()
        {
            if (_currentPage > 1)
            {
                _currentPage--;
            }
        }

        private void NextPage()
        {
            if (_currentPage < TotalPages)
            {
                _currentPage++;
            }
        }

        protected override void OnInitialized()
        {
            Users =
            [
                new User { Id = 1, Name = "Alex", Email = "alex@madagascar.com", Age = 15 },       // Alex the Lion
                new User { Id = 2, Name = "Marty", Email = "marty@madagascar.com", Age = 14 },     // Marty the Zebra
                new User { Id = 3, Name = "Gloria", Email = "gloria@madagascar.com", Age = 16 },   // Gloria the Hippo
                new User { Id = 4, Name = "Melman", Email = "melman@madagascar.com", Age = 17 },   // Melman the Giraffe
                new User { Id = 5, Name = "Skipper", Email = "skipper@madagascar.com", Age = 10 }, // Skipper the Penguin
                new User { Id = 6, Name = "Kowalski", Email = "kowalski@madagascar.com", Age = 9 }, // Kowalski the Penguin
                new User { Id = 7, Name = "Rico", Email = "rico@madagascar.com", Age = 9 },         // Rico the Penguin
                new User { Id = 8, Name = "Private", Email = "private@madagascar.com", Age = 8 },   // Private the Penguin
                new User { Id = 9, Name = "King Julien", Email = "julien@madagascar.com", Age = 13 }, // King Julien the Lemur
                new User { Id = 10, Name = "Maurice", Email = "maurice@madagascar.com", Age = 12 }, // Maurice the Aye-aye
                new User { Id = 11, Name = "Mort", Email = "mort@madagascar.com", Age = 7 },
            ];
            base.OnInitialized();
        }

        private void OnEdit(User user) => Console.WriteLine($"Editing user: {user.Name}");

        private void OnDelete(User user)
        {
            Console.WriteLine($"Deleting user: {user.Name}");
            Users.Remove(user);
        }

        private string GetRowClass(User user) => user.Age > 30 ? "highlight-row" : null;

        // Filter property
        private string NameFilter { get; set; } = "";


        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
        }
    }
}