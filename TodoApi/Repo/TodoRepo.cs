using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApi.Repo
{
    
    public class TodoRepo
    {
        private readonly TodoDbContext db;
        private readonly Response response = new Response();
        
        public TodoRepo(TodoDbContext _db){
            db = _db;
        }

        public Response GetAllTodo()
        {
            try
            {
                var TodoList = db.Todo.ToList();
                response.message = (TodoList.Count > 0)
                    ? $"Todo data Successfully fetched!"
                    : $"Todo data is not available!";
                response.entity = TodoList;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.message = "Error Get Data!" + e.Message;
            }
            return response;
        }

        public Response GetById(int Id)
        {
            try
            {
                var Todo = db.Todo.Find(Id);
                if (Todo == null)
                {
                    response.message = "Data Tidak Ditemukan!";
                }
                else
                {
                    response.message = "Todo data Successfully fetched!"; 
                    response.entity = Todo;
                }
            }
            catch(Exception e)
            {
                response.Success = false;
                response.message = "Error Get Data!" + e.Message;
            }
            return response;
        }

        public Response Add(Todo dataTodo)
        {
            try 
            {
                Todo dataModel = new Todo();

                dataModel.isCompleted = false;
                dataModel.Title = dataTodo.Title;

                db.Add(dataModel);
                db.SaveChanges();
                response.message = "Todo Berhasil Ditambahkan!";
                response.entity = dataTodo;
            }
            catch(Exception e)
            {
                response.Success = false;
                response.message = e.Message;
            }

            return response;
            
        }

        public Response Put(int Id,[FromBody] Todo dataTodo)
        {
            try
            {
            
                var Todo = db.Todo.Find(Id);
                if (Todo == null)
                {
                    response.message = "Data Tidak Ditemukan!";
                }
                else
                {
                    Todo.Title = dataTodo.Title;
                    Todo.isCompleted = dataTodo.isCompleted;
                    db.SaveChanges();
                    response.message = "Todo Berhasil diubah"; 
                }
            
            }
            catch(Exception e)
            {
                response.message = e.Message;
                response.Success = false;
            }
            return response;
        }

        public Response Delete(int Id)
        {
            try
            {
                var Todo = db.Todo.Find(Id);
                if (Todo == null)
                {
                    response.message = "Data Tidak Ditemukan!";
                }
                else
                {
                    db.Todo.Remove(Todo);
                    db.SaveChanges();
                    response.message = "Todo Berhasil didelete"; 
                }
            
            }
            catch(Exception e)
            {
                response.message = e.Message;
                response.Success = false;
            }
            return response;
        }

    }
}