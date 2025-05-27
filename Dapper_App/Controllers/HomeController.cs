using Dapper;
using Dapper_App.ContextApp;
using Dapper_App.DapperConfig;
using Dapper_App.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Dapper_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly DapperContext db;
        public HomeController(DapperContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public async Task<ActionResult> ReadAll()
        {
            using (var connection = db.CreateConnection())
            {
                var LstPerson = await connection.QueryAsync<Person>("sp_person_GetAll", commandType: CommandType.StoredProcedure);
                return Ok(LstPerson.ToList());
            }

            //ALTER proc[dbo].[sp_person_GetAll]
            //as
            //select id,name,family
            //from Person


        }


        [HttpPost]
        public async Task<ActionResult> Insert(Person person)
        {
            using (var connection = db.CreateConnection())
            {
                var Paramter = new DynamicParameters();
                Paramter.Add("@name", person.name);
                Paramter.Add("@family", person.family);
                int InsertID = await connection.ExecuteScalarAsync<int>("sp_person_Add", Paramter, commandType: CommandType.StoredProcedure);
                return Ok(InsertID);
            }

            //ALTER proc[dbo].[sp_person_Add]
            //@name nvarchar(50)= 'aa',
            //@family nvarchar(50)= 'bb'
            //as
            //begin
            //insert into Person(name, family)
            //output inserted.id
            //values(@name, @family)
            //end




        }


        [HttpPost]
        public async Task<ActionResult> Update(Person person)
        {
            using (var connection = db.CreateConnection())
            {
                var Paramter = new DynamicParameters();
                Paramter.Add("@id", person.id);
                Paramter.Add("@name", person.name);
                Paramter.Add("@family", person.family);
                int UpdateID = await connection.ExecuteScalarAsync<int>("sp_person_Update", Paramter, commandType: CommandType.StoredProcedure);
                return Ok(UpdateID);
            }
            //**************************************************

            //ALTER proc[dbo].[sp_person_Update]
            //@id int= 10,
            //@name nvarchar(50) = 'aa',
            //@family nvarchar(50)= 'bb'
            //as
            //begin
            //update Person
            //set name = @name,
            //family = @family
            // where id = @id
            //select @id
            //end


            //**************************************************
        }


        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {

            using (var connection = db.CreateConnection())
            {
                var Paramter = new DynamicParameters();
                Paramter.Add("@id", id);
                int DeletedId = await connection.ExecuteScalarAsync<int>("sp_person_Delete", Paramter, commandType: CommandType.StoredProcedure);
                return Ok(DeletedId);
            }

            //*******************************************************
            //ALTER proc[dbo].[sp_person_Delete]
            //@id int
            //as
            //begin
            //delete from Person where id = @id
            //select @id
            //end

            //*******************************************************
        }


    }
}
