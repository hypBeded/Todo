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
        private static List<UserModel> registredUser = new List<UserModel>();

        public UserModel UserRegistration(string login, string password, string email, List<TaskModel>  tasks )
        {
            if (registredUser.Exists(l => l.Login == login))
            {

                throw new Exception("Пользователь с таким логином уже существует");
            }
            if (registredUser.Exists(l => l.Email == email))
            {
                
                throw new Exception("Пользователь с такой почтой уже существует");
            }

            var newUser = new UserModel(login, password, email);
            registredUser.Add(newUser);
            return newUser;
            
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
