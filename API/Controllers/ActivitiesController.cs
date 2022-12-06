using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
     
        public ActivitiesController(DataContext context) //Kör så att vi får tillgång till vår databas i denna controller. 
        {
            _context = context;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivity() {
            return await _context.Activities.ToListAsync();

        }

        [HttpGet("{id}")] //activites/id. Gör så att användaren kan hämta data om en enskild activity. 
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {return await _context.Activities.FindAsync(id); }  //Skickar in ID:t för en aktivitet
    }
}