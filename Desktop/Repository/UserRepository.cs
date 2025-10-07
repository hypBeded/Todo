using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Entities;

namespace Desktop.Repository
{
    public class UserRepository
    {
        private List<UserModel> registredUser = new List<UserModel>();
  
        public void UserRegistration(string login, string password, string email)
        {

            if (registredUser.Exists(l => l.Login == login && l.Email == email ))
            {
                throw new Exception("Пользователь с таким логином или почтой уже сущетсвует");
                
            }
            var newUser = new UserModel(login, password, email);
            registredUser.Add(newUser);
        }
        public UserModel UserAuthenticate(string email, string password)
        {
            var user = registredUser.Find(l => l.Email == email && l.Password == password );
            if (user == null)
            {
                throw new Exception("Неверная почта или пароль");
            }
            return user;
        }








    }

}
