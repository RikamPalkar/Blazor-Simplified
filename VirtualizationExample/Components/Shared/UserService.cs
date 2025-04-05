    public class UserService
    {
         public List<User> GetUsers(int count)
        {
            var users = new List<User>();
            for (int i = 0; i <= count; i++)
            {
                users.Add(new User
                {
                    Id = i,
                    Name = $"User {i+1}",
                    Description = $"This is a description for User {i+1}.",
                    IsEmployeeFTE = i % 2 == 0
                });
            }
            return users;
        }
    }