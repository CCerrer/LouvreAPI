using LouvreAPI.Data;
using LouvreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace LouvreAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PinturasController : ControllerBase
    {
        private readonly DataContext dataContext;

        public PinturasController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pintura>>> GetAll()
        {
            return Ok(await this.dataContext.Pinturas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pintura>> GetById(int id)
        {
            var pintura = await this.dataContext.Pinturas.FindAsync(id);
            if (pintura == null) return BadRequest($"ID:{id} invalido");
            return Ok(pintura);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pintura>>> CreatePintura(Pintura novaPintura)
        {
            this.dataContext.Add(novaPintura);
            await this.dataContext.SaveChangesAsync();
            return Ok(await this.dataContext.Pinturas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Pintura>> UpdatePintura(Pintura updatePintura)
        {
            var referenciada = await this.dataContext.Pinturas.FindAsync(updatePintura.Id);
            if (referenciada == null) return BadRequest($"ID:{updatePintura.Id} invalido");

            referenciada.Name = updatePintura.Name;
            referenciada.Autor = updatePintura.Autor;
            referenciada.Tecnica = updatePintura.Tecnica;
            referenciada.Descricao = updatePintura.Descricao;
            referenciada.YearMade = updatePintura.YearMade;

            await this.dataContext.SaveChangesAsync();
            return Ok(await dataContext.Pinturas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Pintura>>> DeletePintura(int id)
        {
            var referenciada = await this.dataContext.Pinturas.FindAsync(id);
            if (referenciada == null) return BadRequest($"ID:{id} invalido");

            this.dataContext.Pinturas.Remove(referenciada);
            await this.dataContext.SaveChangesAsync();
            return Ok(await this.dataContext.Pinturas.ToListAsync());
        }
    }
}
