
using System.Web.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using Google.Apis.Tasks.v1;
using Google.Apis.Tasks.v1.Data;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class TaskController : ApiController
    {
        // authorization object
        Authorization auth = new Authorization();


        /// <summary>
        /// show/all the Task of default tasklist 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/task/AllTasks")]
        public List<GetTask> GetTask()
        {
            List<GetTask> myList = new List<GetTask>();

            var response = auth.service.Tasks.List("@default");
            var result = response.Execute();
            var tasks = result.Items;

            if (tasks != null && tasks.Count > 0)
            {
                foreach (Task t in tasks)
                {
                    GetTask a = new GetTask();
                    a.id = t.Id;
                    a.title = t.Title;
                    a.note = t.Notes;
                    a.duedate = t.Due;
                    myList.Add(a);
                }
               
            }
            else
            {
               //return prompt about NO Tasks 
            }
            return myList;
        }


        // insert task into default tasklist 
        // function 
        [HttpPost]
        [Route("api/task/InsertTask")]

        public string taskInsert([FromBody]GetTask _Task)
        {

            Task task = new Task { Title = _Task.title};
            task.Notes = _Task.note;
            task.Due = System.DateTime.Today;

            var response  =auth.service.Tasks.Insert(task, "@default");
            var result = response.Execute();
            return "successfull inserted task";
        }
        
        // Clear All the task into Default Task list 

        [HttpDelete]
        [Route("api/task/ClearAllTasks")]
        public string clearTask()
        {
            var response = auth.service.Tasks.List("@default");

            
            var result = response.Execute();
            var tasks = result.Items;

            if (tasks != null && tasks.Count > 0)
            {
                foreach (Task t in tasks)
                {
                    var responses = auth.service.Tasks.Delete("@default", t.Id);
                    responses.Execute();
                }

                //return prompt about NO Tasks 
                return "Successful Clear all the completed tasks of the default Tasklsit";

            }
            else
            {
                return "Unsuccessful";
            }
        }

        //delete the Specific task
        [HttpDelete]
        [Route("api/task/DeletedTask/{id}")]
        public string deleteTask(string id)
        { // condition that deleted task is selected or not 
            var response = auth.service.Tasks.Delete("@default",id);
            var result = response.Execute();
            return "successful deleted selected task ";
        }

    

        //get specifically selected task
        [HttpGet]
        [Route("api/task/showtask/{id}")]
        public GetTask GetTask(string id)
        {
            var response = auth.service.Tasks.Get("@default",id);
            var result = response.Execute();
            GetTask a = new GetTask();
           
            a.title = result.Title;
            a.note = result.Notes;
            

            return a;

        }




    }
}
