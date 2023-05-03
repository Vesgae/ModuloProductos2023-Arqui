using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModuloProductos_v1.DTO;
using ModuloProductos_v1.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModuloProductos_v1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RepuestosController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;
        private List<Tbrepuestoenventum> _tbrepuestosenventa;
        private List<Tbrepuesto> _tbrepuestos;
        private List<Tbproducto> _tbproductos;
        private List<Tbdisponibilidad> _tbdisponibilidad;
        private List<Tbsucursal> _tbsucursales;
        private List<Tbmodelo> _tbmodelos;
        private List<Tbmarca> _tbmarcas;

        public RepuestosController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }
        // GET: api/<RepuestosController>
        [HttpGet]
        public IEnumerable<Repuesto> Get()
        {
            List<Repuesto> repuestosEnVenta = new List<Repuesto>();
            _tbrepuestosenventa = _context.Tbrepuestoenventa.ToList();
            _tbmodelos = _context.Tbmodelos.ToList();
            _tbmarcas = _context.Tbmarcas.ToList();
            _tbproductos = _context.Tbproductos.ToList();
            _tbsucursales = _context.Tbsucursals.ToList();
            _tbdisponibilidad = _context.Tbdisponibilidads.ToList();
            _tbrepuestos = _context.Tbrepuestos.ToList();
            foreach (Tbrepuestoenventum element in _tbrepuestosenventa)
            {
                Repuesto nuevoRepuesto = new Repuesto();
                nuevoRepuesto.id = element.Id;
                nuevoRepuesto.idRepuesto = element.IdRepuesto;
                nuevoRepuesto.idProducto = element.IdProducto;
                nuevoRepuesto.idModelo = _tbrepuestos.Find(x => x.Id == nuevoRepuesto.idRepuesto).IdModelo;
                nuevoRepuesto.nombre = _tbrepuestos.Find(x => x.Id == nuevoRepuesto.idRepuesto).Nombre;
                nuevoRepuesto.modelo = _tbmodelos.Find(x => x.Id == nuevoRepuesto.idModelo).Modelo;
                nuevoRepuesto.idMarca = _tbmodelos.Find(x => x.Id == nuevoRepuesto.idModelo).IdMarca;
                nuevoRepuesto.marca = _tbmarcas.Find(x => x.Id == nuevoRepuesto.idMarca).Marca;
                nuevoRepuesto.precio = ((double)_tbproductos.Find(x => x.Id == nuevoRepuesto.idProducto).PrecioUnitario);
                nuevoRepuesto.urlFoto = _tbproductos.Find(x => x.Id == nuevoRepuesto.idProducto).UrlFotografia;
                var disponibilidades = _tbdisponibilidad.FindAll(x => x.IdProducto == nuevoRepuesto.idProducto);
                foreach (Tbdisponibilidad i in disponibilidades)
                {
                    Disponibilidad nuevaDisponibilidad = new Disponibilidad();
                    nuevaDisponibilidad.id = i.Id;
                    nuevaDisponibilidad.idSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Id;
                    nuevaDisponibilidad.nombreSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Nombre;
                    nuevaDisponibilidad.ciudadSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Ciudad;
                    nuevaDisponibilidad.disponibilidad = i.Cantidad;
                    nuevoRepuesto.disponibilidad.Add(nuevaDisponibilidad);
                }
                repuestosEnVenta.Add(nuevoRepuesto);
            }
            return repuestosEnVenta;
        }

        // GET api/<RepuestosController>/5
        [HttpGet("{id}")]
        public Repuesto Get(int id)
        {
            Repuesto nuevoRepuesto = new Repuesto();
            _tbrepuestosenventa = _context.Tbrepuestoenventa.ToList();
            _tbmodelos = _context.Tbmodelos.ToList();
            _tbmarcas = _context.Tbmarcas.ToList();
            _tbproductos = _context.Tbproductos.ToList();
            _tbsucursales = _context.Tbsucursals.ToList();
            _tbdisponibilidad = _context.Tbdisponibilidads.ToList();
            var element = _tbrepuestosenventa.Find(x => x.Id == id);
            if (element != null)
            {
                nuevoRepuesto.id = element.Id;
                nuevoRepuesto.idRepuesto = element.IdRepuesto;
                nuevoRepuesto.idProducto = element.IdProducto;
                nuevoRepuesto.idModelo = _tbrepuestos.Find(x => x.Id == nuevoRepuesto.idRepuesto).IdModelo;
                nuevoRepuesto.nombre = _tbrepuestos.Find(x => x.Id == nuevoRepuesto.idRepuesto).Nombre;
                nuevoRepuesto.modelo = _tbmodelos.Find(x => x.Id == nuevoRepuesto.idModelo).Modelo;
                nuevoRepuesto.idMarca = _tbmodelos.Find(x => x.Id == nuevoRepuesto.idModelo).IdMarca;
                nuevoRepuesto.marca = _tbmarcas.Find(x => x.Id == nuevoRepuesto.idMarca).Marca;
                nuevoRepuesto.precio = ((double)_tbproductos.Find(x => x.Id == nuevoRepuesto.idProducto).PrecioUnitario);
                nuevoRepuesto.urlFoto = _tbproductos.Find(x => x.Id == nuevoRepuesto.idProducto).UrlFotografia;
                var disponibilidades = _tbdisponibilidad.FindAll(x => x.IdProducto == nuevoRepuesto.idProducto);
                foreach (Tbdisponibilidad i in disponibilidades)
                {
                    Disponibilidad nuevaDisponibilidad = new Disponibilidad();
                    nuevaDisponibilidad.id = i.Id;
                    nuevaDisponibilidad.idSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Id;
                    nuevaDisponibilidad.nombreSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Nombre;
                    nuevaDisponibilidad.ciudadSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Ciudad;
                    nuevaDisponibilidad.disponibilidad = i.Cantidad;
                    nuevoRepuesto.disponibilidad.Add(nuevaDisponibilidad);
                }
            }

            return nuevoRepuesto;
        }

        // POST api/<RepuestosController>
        [HttpPost]
        public void Post([FromBody] Repuesto nuevoRepuesto)
        {
            var nuevoRepuestoDB = new Tbrepuesto();
            nuevoRepuestoDB.IdModelo = (int)nuevoRepuesto.idModelo;
            nuevoRepuestoDB.Nombre = nuevoRepuesto.nombre;
            nuevoRepuestoDB = _context.Tbrepuestos.Add(nuevoRepuestoDB).Entity;
            _context.SaveChanges();
            var nuevoProducto = new Tbproducto();
            nuevoProducto.IdTipoProducto = 2;
            nuevoProducto.PrecioUnitario = ((decimal)nuevoRepuesto.precio);
            nuevoProducto.UrlFotografia = nuevoRepuesto.urlFoto;
            _context.Tbproductos.Add(nuevoProducto);
            _context.SaveChanges();
            if (nuevoRepuesto.disponibilidad.Count() > 0)
            {
                foreach(Disponibilidad element in nuevoRepuesto.disponibilidad){
                    var nuevaDisponibilidad = new Tbdisponibilidad();
                    nuevaDisponibilidad.Cantidad = (int)element.disponibilidad;
                    nuevaDisponibilidad.IdSucursal = (int)element.idSucursal;
                    nuevaDisponibilidad.IdProducto = nuevoProducto.Id;
                    nuevaDisponibilidad = _context.Tbdisponibilidads.Add(nuevaDisponibilidad).Entity;
                    _context.SaveChanges();
                }
                
            }
            else
            {
                var nuevaDisponibilidad = new Tbdisponibilidad();
                nuevaDisponibilidad.Cantidad = (int)nuevoRepuesto.unidadesDisponibles;
                nuevaDisponibilidad.IdSucursal = (int)nuevoRepuesto.idSucursal;
                nuevaDisponibilidad.IdProducto = nuevoProducto.Id;
                nuevaDisponibilidad = _context.Tbdisponibilidads.Add(nuevaDisponibilidad).Entity;
                _context.SaveChanges();
            }

            var tbAccesorioEnVenta = new Tbaccesorioenventum();
            tbAccesorioEnVenta.IdProducto = nuevoProducto.Id;
            tbAccesorioEnVenta.IdAccesorio = nuevoRepuestoDB.Id;
            tbAccesorioEnVenta = _context.Tbaccesorioenventa.Add(tbAccesorioEnVenta).Entity;
            _context.SaveChanges();
        }

        // PUT api/<RepuestosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Repuesto nuevoRepuesto)
        {
            _tbrepuestosenventa = _context.Tbrepuestoenventa.ToList();
            _tbproductos = _context.Tbproductos.ToList();
            var repuestoEnVenta = _tbrepuestosenventa.Find(x => x.Id == id);
            if (repuestoEnVenta != null)
            {
                var producto = _tbproductos.Find(x => x.Id == repuestoEnVenta.IdProducto);
                if (producto != null)
                {
                    if (nuevoRepuesto.precio != 0)
                    {
                        producto.PrecioUnitario = ((decimal)nuevoRepuesto.precio);
                        _context.Entry(producto).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                }

            }
        }

        // DELETE api/<RepuestosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tbrepuestosenventa = _context.Tbrepuestoenventa.ToList();
            _tbrepuestos = _context.Tbrepuestos.ToList();
            _tbproductos = _context.Tbproductos.ToList();
            _tbdisponibilidad = _context.Tbdisponibilidads.ToList();
            var repuestoEnVenta = _tbrepuestosenventa.Find(x => x.Id == id);
            if (repuestoEnVenta != null)
            {
                var repuesto = _tbrepuestos.Find(x => x.Id == repuestoEnVenta.IdRepuesto);
                var producto = _tbproductos.Find(x => x.Id == repuestoEnVenta.IdProducto);
                if (repuesto != null && producto != null)
                {
                    var disponibilidades = _tbdisponibilidad.FindAll(x => x.IdProducto == producto.Id);
                    foreach (Tbdisponibilidad i in disponibilidades)
                    {
                        _context.Tbdisponibilidads.Remove(i);
                        _context.SaveChanges();
                    }
                    _context.Tbrepuestoenventa.Remove(repuestoEnVenta);
                    _context.SaveChanges();
                    _context.Tbproductos.Remove(producto);
                    _context.SaveChanges();
                    _context.Tbrepuestos.Remove(repuesto);
                    _context.SaveChanges();
                }
            }
        }
    }
}
