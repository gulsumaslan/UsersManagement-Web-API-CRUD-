using Bogus;
using System;

using System.Collections.Generic;
using UsersManagement.API.Models;

namespace UsersManagement.API.Fake
{
    public static class FakeData // gerçek veriler olmayan bir fake data oluşturuldu.
    {
        private static List<User> _users; // User sınıfının özelliklerini alıp _users alanına depolamak için listelenecek
        public static List<User> GetUsers(int number) //dışarıdan alınan sayı kadar kullanıcı nesnesi oluşturur.
        {
            if (_users==null) // eğer _users boş ise 
            {//rulefor: her kullanıcı nesnesinin hangi özelliklere sahip olacağını tanımlamak için kullanılır.
                _users = new Faker<User>()// rastgale veya sahte database oluşturmak için kullanılır
                .RuleFor(u => u.Id, f => f.IndexFaker + 1) //her kullanıcı için ayrı bir ıd değeri oluşturulur.
                .RuleFor(u => u.FirsName, f => f.Name.FirstName())//firstname özelliğini rastgele bir isimle doldurur
                .RuleFor(u => u.LastName, f => f.Name.LastName())//lastname özelliğine rastgele bir soyad  ile doldurur.
                .RuleFor(u => u.Address, f => f.Address.FullAddress()) //adres özelliğine rastgeler bir adresle doldurur
                .Generate(number);//belirtilen sayıda kullanıcı nesne oluşturur
            }
            
            return _users; //users listesini döndürür.
        }
    }
}
