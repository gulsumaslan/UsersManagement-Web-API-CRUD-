using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UsersManagement.API.Fake;
using UsersManagement.API.Models;

namespace UsersManagement.API.Controllers
{
    [Route("api/[controller]")] //route şablonunu temsil eder.
    public class UsersController : ControllerBase //web uygulamalarını kolayca yönetebilmek için kullanılır 
    {
        private List<User> _users = FakeData.GetUsers(200);//200 tane sahte kullanıcı oluşturur. user da listeler
        [HttpGet]
        public List<User> Get() //user listesindeki kullanıcıları döndürmek için kullanılır.
        {
            return _users;
        }
        [HttpGet("{id}")] //url http isteğini belirtir.
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id); //belirli kullanıcı id değerine göre geri döndürür
            return user;
        }
        [HttpPost] //http post isteği
        public User Post([FromBody] User user) //stemci, HTTP isteğinin gövdesinde JSON veya XML gibi bir veri gönderir ve bu veri, user parametresine dönüştürülür.
        {
            _users.Add(user);//yeni bir kullanıcı nesnesi ekler
            return user;
        }
        [HttpPut]//mevcut bir kaydı güncellemek veya değiştirmek için kullanılır.
        public User Put([FromBody] User user)
        {
            var editeduser = _users.FirstOrDefault(x => x.Id == user.Id);//güncellenecek kullanıcıyı bulmak için kullanılır
            editeduser.FirsName = user.FirsName;//bu satır, belirli bir kullanıcının "FirstName" özelliğini, user parametresindeki veri ile günceller.
            editeduser.LastName = user.LastName;//lastname özelliğini günceller
            editeduser.Address = user.Address; //adres özelliğini günceller
            return user; //kullanıcıyı geri döndürür
        }
        [HttpDelete]
        public void Delete(int id)
        {//id numarasına göre kullanıcıyı siler
            var deleteuser= _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deleteuser);
        }


    }
}
