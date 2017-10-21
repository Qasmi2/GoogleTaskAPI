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
    public class taskListController : ApiController
    {
        Authorization auth = new Authorization();

        [HttpGet]
        [Route("api/TaskListAll")]
        public List<MyTaskList> GetTaskList()

        {
            var response = auth.service.Tasklists.List();
            var result = response.Execute();
            var items = result.Items;
            if (items != null && items.Count > 0)
            {
                List<MyTaskList> myLists = new List<MyTaskList>();

                foreach (var i in items)
                {
                    MyTaskList a = new MyTaskList();
                    a.Id = i.Id;
                    a.title = i.Title;

                    myLists.Add(a);
                }


                return myLists;
            }
            else
            {
                return null;
            }



        }


        // the followoing function will be used as per requirement. 

        //function insert tasklist change into post 
        [HttpPost]
        [Route("api/taskList/insert")]
        public string InsertTaskList([FromBody]MyTaskList _list)
        {
            TaskList list = new TaskList { Title = _list.title};
            var response = auth.service.Tasklists.Insert(list);
            var result = response.Execute();
            var items = result.Id;
            return "Your Task is successfull inserted ";
        }

        //  delete function will be change httpDelete 
        [HttpGet]
        [Route("api/taskList/delete/{id}")]
        public string deletetasklist(string id)
        {

            var response = auth.service.Tasklists.Delete(id);
            var result = response.Execute();
            return "successful Deleted TaskList";
        }


        //Api for routing Page
        [HttpGet]
        [Route("api/taskList/{id}")]
        public MyTaskList SingleTaskList(string id)
        {

            var response = auth.service.Tasklists.Get(id);
            var result = response.Execute();
            MyTaskList list = new MyTaskList();
            list.title = result.Title;
            list.Id = result.Id;
            return list;
        }


        // get/show function of single tasklist 
        [HttpGet]
        [Route("api/defaultTasklist")]
        public List<MyTaskListGet> GetTaskListShow()
        {
            List<MyTaskListGet> myList = new List<MyTaskListGet>();
            var response = auth.service.Tasklists.Get("@default");
            if (response.Tasklist != "@default")
            {

                TaskList list = new TaskList { Title = "Default" };
                var response2 = auth.service.Tasklists.Insert(list);
                response2.Execute();


            }

            response = auth.service.Tasklists.Get("@default");
            var result = response.Execute();

            MyTaskListGet a = new MyTaskListGet();
            a.id = result.Id;
            a.title = result.Title;


            myList.Add(a);
            return myList;

        }

       


    }
}







