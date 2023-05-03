using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModuloProductos_v1.DTO;
using ModuloProductos_v1.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModuloProductos_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoriosController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;
        private List<Tbproducto> _tbproductos;
        private List<Tbdisponibilidad> _tbdisponibilidad;
        private List<Tbsucursal> _tbsucursales;
        private List<Tbaccesorioenventum> _tbaccesoriosenventa;
        private List<Tbproveedor> _tbproveedores;
        private List<Tbaccesorio> _tbaccesorios;

        public AccesoriosController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }
        // GET: api/<AccesoriosController>
        [HttpGet]
        public IEnumerable<Accesorio> Get()
        {
            List<Accesorio> accesoriosEnVenta = new List<Accesorio>();
            _tbaccesoriosenventa = _context.Tbaccesorioenventa.ToList();
            _tbproveedores = _context.Tbproveedors.ToList();
            _tbproductos = _context.Tbproductos.ToList();
            _tbsucursales = _context.Tbsucursals.ToList();
            _tbdisponibilidad = _context.Tbdisponibilidads.ToList();
            _tbaccesorios = _context.Tbaccesorios.ToList();
            foreach (Tbaccesorioenventum element in _tbaccesoriosenventa)
            {
                Accesorio accesorio = new Accesorio();
                accesorio.id = element.Id;
                accesorio.idProducto = element.IdProducto;
                accesorio.idAccesorio = element.IdAccesorio;
                accesorio.precio = ((double)_tbproductos.Find(x => x.Id == accesorio.idProducto).PrecioUnitario);
                accesorio.urlFoto = _tbproductos.Find(x => x.Id == accesorio.idProducto).UrlFotografia;
                accesorio.nombre = _tbaccesorios.Find(x => x.Id == accesorio.idAccesorio).Nombre;
                accesorio.idProveedor = _tbaccesorios.Find(x => x.Id == accesorio.idAccesorio).IdProveedor;
                accesorio.nombreProveedor = _tbproveedores.Find(x => x.Id == accesorio.idProveedor).Nombre;
                var disponibilidades = _tbdisponibilidad.FindAll(x => x.IdProducto == accesorio.idProducto);
                foreach (Tbdisponibilidad i in disponibilidades)
                {
                    Disponibilidad nuevaDisponibilidad = new Disponibilidad();
                    nuevaDisponibilidad.id = i.Id;
                    nuevaDisponibilidad.idSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Id;
                    nuevaDisponibilidad.nombreSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Nombre;
                    nuevaDisponibilidad.ciudadSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Ciudad;
                    nuevaDisponibilidad.disponibilidad = i.Cantidad;
                    accesorio.disponibilidad.Add(nuevaDisponibilidad);
                }
                accesoriosEnVenta.Add(accesorio);
            }
            return accesoriosEnVenta;
        }

        // GET api/<AccesoriosController>/5
        [HttpGet("{id}")]
        public Accesorio Get(int id)
        {
            Accesorio accesorioEnVenta = new Accesorio();
            _tbaccesoriosenventa = _context.Tbaccesorioenventa.ToList();
            _tbproveedores = _context.Tbproveedors.ToList();
            _tbproductos = _context.Tbproductos.ToList();
            _tbsucursales = _context.Tbsucursals.ToList();
            _tbdisponibilidad = _context.Tbdisponibilidads.ToList();
            _tbaccesorios = _context.Tbaccesorios.ToList();
            var element = _tbaccesoriosenventa.Find(x => x.Id == id);
            if (element != null)
            {
                Accesorio accesorio = new Accesorio();
                accesorio.id = element.Id;
                accesorio.idProducto = element.IdProducto;
                accesorio.idAccesorio = element.IdAccesorio;
                accesorio.precio = ((double)_tbproductos.Find(x => x.Id == accesorio.idProducto).PrecioUnitario);
                accesorio.urlFoto = _tbproductos.Find(x => x.Id == accesorio.idProducto).UrlFotografia;
                accesorio.nombre = _tbaccesorios.Find(x => x.Id == accesorio.idAccesorio).Nombre;
                accesorio.idProveedor = _tbaccesorios.Find(x => x.Id == accesorio.idAccesorio).IdProveedor;
                accesorio.nombreProveedor = _tbproveedores.Find(x => x.Id == accesorio.idProveedor).Nombre;
                var disponibilidades = _tbdisponibilidad.FindAll(x => x.IdProducto == accesorio.idProducto);
                foreach (Tbdisponibilidad i in disponibilidades)
                {
                    Disponibilidad nuevaDisponibilidad = new Disponibilidad();
                    nuevaDisponibilidad.id = i.Id;
                    nuevaDisponibilidad.idSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Id;
                    nuevaDisponibilidad.nombreSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Nombre;
                    nuevaDisponibilidad.ciudadSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Ciudad;
                    nuevaDisponibilidad.disponibilidad = i.Cantidad;
                    accesorio.disponibilidad.Add(nuevaDisponibilidad);
                }
            }


            return accesorioEnVenta;
        }

        // POST api/<AccesoriosController>
        [HttpPost]
        public void Post([FromBody] Accesorio nuevoAccesorio)
        {
            var nuevoAccesorioDB = new Tbaccesorio();
            nuevoAccesorioDB.IdProveedor = (int)nuevoAccesorio.idProveedor;
            nuevoAccesorioDB.Nombre = nuevoAccesorio.nombre;
            nuevoAccesorioDB = _context.Tbaccesorios.Add(nuevoAccesorioDB).Entity;
            _context.SaveChanges();
            var nuevoProducto = new Tbproducto();
            nuevoProducto.IdTipoProducto = 3;
            nuevoProducto.PrecioUnitario = ((decimal)nuevoAccesorio.precio);
            nuevoProducto.UrlFotografia = nuevoAccesorio.urlFoto;
            _context.Tbproductos.Add(nuevoProducto);
            _context.SaveChanges();
            if (nuevoAccesorio.disponibilidad.Count() > 0)
            {
                foreach(Disponibilidad element in nuevoAccesorio.disponibilidad){
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
                nuevaDisponibilidad.Cantidad = (int)nuevoAccesorio.unidadesDisponibles;
                nuevaDisponibilidad.IdSucursal = (int)nuevoAccesorio.idSucursal;
                nuevaDisponibilidad.IdProducto = nuevoProducto.Id;
                nuevaDisponibilidad = _context.Tbdisponibilidads.Add(nuevaDisponibilidad).Entity;
                _context.SaveChanges();
            }

            var tbAccesorioEnVenta = new Tbaccesorioenventum();
            tbAccesorioEnVenta.IdProducto = nuevoProducto.Id;
            tbAccesorioEnVenta.IdAccesorio = nuevoAccesorioDB.Id;
            tbAccesorioEnVenta = _context.Tbaccesorioenventa.Add(tbAccesorioEnVenta).Entity;
            _context.SaveChanges();

        }

        // PUT api/<AccesoriosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Accesorio nuevoAccesorio)
        {
            _tbaccesoriosenventa = _context.Tbaccesorioenventa.ToList();
            _tbproductos = _context.Tbproductos.ToList();
            var accesorioEnVenta = _tbaccesoriosenventa.Find(x => x.Id == id);
            if (accesorioEnVenta != null)
            {
                var producto = _tbproductos.Find(x => x.Id == accesorioEnVenta.IdProducto);
                if (producto != null)
                {
                    if (nuevoAccesorio.precio != 0)
                    {
                        producto.PrecioUnitario = ((decimal)nuevoAccesorio.precio);
                        _context.Entry(producto).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                }

            }
        }

        // DELETE api/<AccesoriosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tbaccesoriosenventa = _context.Tbaccesorioenventa.ToList();
            _tbaccesorios = _context.Tbaccesorios.ToList();
            _tbproductos = _context.Tbproductos.ToList();
            _tbdisponibilidad = _context.Tbdisponibilidads.ToList();
            var accesorioEnVenta = _tbaccesoriosenventa.Find(x => x.Id == id);
            if (accesorioEnVenta != null)
            {
                var accesorio = _tbaccesorios.Find(x => x.Id == accesorioEnVenta.IdAccesorio);
                var producto = _tbproductos.Find(x => x.Id == accesorioEnVenta.IdProducto);
                if (accesorio != null && producto != null)
                {
                    var disponibilidades = _tbdisponibilidad.FindAll(x => x.IdProducto == producto.Id);
                    foreach (Tbdisponibilidad i in disponibilidades)
                    {
                        _context.Tbdisponibilidads.Remove(i);
                        _context.SaveChanges();
                    }
                    _context.Tbaccesorioenventa.Remove(accesorioEnVenta);
                    _context.SaveChanges();
                    _context.Tbproductos.Remove(producto);
                    _context.SaveChanges();
                    _context.Tbaccesorios.Remove(accesorio);
                    _context.SaveChanges();
                }
            }
        }
    }
}
