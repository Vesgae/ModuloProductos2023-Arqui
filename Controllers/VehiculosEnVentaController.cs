using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModuloProductos_v1.DTO;
using ModuloProductos_v1.Entities;
using NuGet.Versioning;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModuloProductos_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosEnVentaController : ControllerBase
    {
        private readonly DbserviciosproductosvehiculosContext _context;
        private List<Tbvehiculoenventum> _tbvehiculosenventa;
        private List<Tbpropietario> _tbpropietarios;
        private List<Tbvehiculo> _tbvehiculos;
        private List<Tbproducto> _tbproductos;
        private List<Tbdisponibilidad> _tbdisponibilidad;
        private List<Tbsucursal> _tbsucursales;
        private List<Tbmodelo> _tbmodelos;
        private List<Tbmarca> _tbmarcas;
        private List<Tbtipovehiculo> _tbtipovehiculo;
        private List<Tbtipocombustible> _tbtipocombustible;

        public VehiculosEnVentaController(DbserviciosproductosvehiculosContext context)
        {
            _context = context;
        }
        // GET: api/<VehiculosEnVentaController>
        [HttpGet]
        public IEnumerable<VehiculoEnVenta> GetAsync()
        {
            List<VehiculoEnVenta> listaVehiculos = new List<VehiculoEnVenta>();
            _tbvehiculosenventa = _context.Tbvehiculoenventa.ToList();
            _tbmodelos = _context.Tbmodelos.ToList();
            _tbmarcas = _context.Tbmarcas.ToList();
            _tbtipocombustible = _context.Tbtipocombustibles.ToList();
            _tbtipovehiculo = _context.Tbtipovehiculos.ToList();
            _tbvehiculos = _context.Tbvehiculos.ToList();
            _tbproductos = _context.Tbproductos.ToList();
            _tbsucursales = _context.Tbsucursals.ToList();
            _tbdisponibilidad = _context.Tbdisponibilidads.ToList();

            foreach (Tbvehiculoenventum element in _tbvehiculosenventa)
            {
                VehiculoEnVenta nuevoVehiculoEnVenta = new VehiculoEnVenta();
                nuevoVehiculoEnVenta.id = element.Id;
                nuevoVehiculoEnVenta.idProducto = element.IdProducto;
                nuevoVehiculoEnVenta.idVehiculo = element.IdVehiculo;
                nuevoVehiculoEnVenta.modelo.id = _tbvehiculos.Find(x => x.Id == element.IdVehiculo).IdModelo;
                nuevoVehiculoEnVenta.color = _tbvehiculos.Find(x => x.Id == element.IdVehiculo).Color;
                nuevoVehiculoEnVenta.placa = _tbvehiculos.Find(x => x.Id == element.IdVehiculo).Placa;
                nuevoVehiculoEnVenta.modelo.idMarca = _tbmodelos.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.id).IdMarca;
                nuevoVehiculoEnVenta.modelo.idTipoCombustible = _tbmodelos.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.id).IdTipoCombustible;
                nuevoVehiculoEnVenta.modelo.idTipoVehiculo = _tbmodelos.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.id).IdTipoVehiculo;
                nuevoVehiculoEnVenta.modelo.modelo = _tbmodelos.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.id).Modelo;
                nuevoVehiculoEnVenta.modelo.marca = _tbmarcas.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.idMarca).Marca;
                nuevoVehiculoEnVenta.modelo.tipoCombustible = _tbtipocombustible.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.idTipoCombustible).TipoCombustible;
                nuevoVehiculoEnVenta.modelo.tipoVehiculo = _tbtipovehiculo.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.idTipoVehiculo).TipoVehiculo;
                nuevoVehiculoEnVenta.precio = ((double)_tbproductos.Find(x => x.Id == nuevoVehiculoEnVenta.idProducto).PrecioUnitario);
                nuevoVehiculoEnVenta.urlFoto = _tbproductos.Find(x => x.Id == nuevoVehiculoEnVenta.idProducto).UrlFotografia;
                var disponibilidades = _tbdisponibilidad.FindAll(x => x.IdProducto == nuevoVehiculoEnVenta.idProducto);
                foreach (Tbdisponibilidad i in disponibilidades)
                {
                    Disponibilidad nuevaDisponibilidad = new Disponibilidad();
                    nuevaDisponibilidad.id = i.Id;
                    nuevaDisponibilidad.idSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Id;
                    nuevaDisponibilidad.nombreSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Nombre;
                    nuevaDisponibilidad.ciudadSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Ciudad;
                    nuevaDisponibilidad.disponibilidad = i.Cantidad;
                    nuevoVehiculoEnVenta.disponibilidad.Add(nuevaDisponibilidad);
                }

                listaVehiculos.Add(nuevoVehiculoEnVenta);
            }

            return listaVehiculos;
        }

        // GET api/<VehiculosEnVentaController>/5
        [HttpGet("{id}")]
        public VehiculoEnVenta Get(int id)
        {
            VehiculoEnVenta nuevoVehiculoEnVenta = new VehiculoEnVenta();
            _tbvehiculosenventa = _context.Tbvehiculoenventa.ToList();
            _tbmodelos = _context.Tbmodelos.ToList();
            _tbmarcas = _context.Tbmarcas.ToList();
            _tbtipocombustible = _context.Tbtipocombustibles.ToList();
            _tbtipovehiculo = _context.Tbtipovehiculos.ToList();
            _tbvehiculos = _context.Tbvehiculos.ToList();
            _tbproductos = _context.Tbproductos.ToList();
            _tbsucursales = _context.Tbsucursals.ToList();
            _tbdisponibilidad = _context.Tbdisponibilidads.ToList();
            var element = _tbvehiculosenventa.Find(x => x.Id == id);
            if (element != null)
            {
                nuevoVehiculoEnVenta.id = element.Id;
                nuevoVehiculoEnVenta.idProducto = element.IdProducto;
                nuevoVehiculoEnVenta.idVehiculo = element.IdVehiculo;
                nuevoVehiculoEnVenta.modelo.id = _tbvehiculos.Find(x => x.Id == element.IdVehiculo).IdModelo;
                nuevoVehiculoEnVenta.color = _tbvehiculos.Find(x => x.Id == element.IdVehiculo).Color;
                nuevoVehiculoEnVenta.placa = _tbvehiculos.Find(x => x.Id == element.IdVehiculo).Placa;
                nuevoVehiculoEnVenta.modelo.idMarca = _tbmodelos.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.id).IdMarca;
                nuevoVehiculoEnVenta.modelo.idTipoCombustible = _tbmodelos.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.id).IdTipoCombustible;
                nuevoVehiculoEnVenta.modelo.idTipoVehiculo = _tbmodelos.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.id).IdTipoVehiculo;
                nuevoVehiculoEnVenta.modelo.modelo = _tbmodelos.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.id).Modelo;
                nuevoVehiculoEnVenta.modelo.marca = _tbmarcas.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.idMarca).Marca;
                nuevoVehiculoEnVenta.modelo.tipoCombustible = _tbtipocombustible.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.idTipoCombustible).TipoCombustible;
                nuevoVehiculoEnVenta.modelo.tipoVehiculo = _tbtipovehiculo.Find(x => x.Id == nuevoVehiculoEnVenta.modelo.idTipoVehiculo).TipoVehiculo;
                nuevoVehiculoEnVenta.precio = ((double)_tbproductos.Find(x => x.Id == nuevoVehiculoEnVenta.idProducto).PrecioUnitario);
                nuevoVehiculoEnVenta.urlFoto = _tbproductos.Find(x => x.Id == nuevoVehiculoEnVenta.idProducto).UrlFotografia;
                var disponibilidades = _tbdisponibilidad.FindAll(x => x.IdProducto == nuevoVehiculoEnVenta.idProducto);
                foreach (Tbdisponibilidad i in disponibilidades)
                {
                    Disponibilidad nuevaDisponibilidad = new Disponibilidad();
                    nuevaDisponibilidad.id = i.Id;
                    nuevaDisponibilidad.idSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Id;
                    nuevaDisponibilidad.nombreSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Nombre;
                    nuevaDisponibilidad.ciudadSucursal = _tbsucursales.Find(x => x.Id == i.IdSucursal).Ciudad;
                    nuevaDisponibilidad.disponibilidad = i.Cantidad;
                    nuevoVehiculoEnVenta.disponibilidad.Add(nuevaDisponibilidad);
                }
            }

            return nuevoVehiculoEnVenta;
        }

        // POST api/<VehiculosEnVentaController>
        [HttpPost]
        public void Post([FromBody] VehiculoEnVenta nuevoVehiculoEnVenta)
        {
            _tbmodelos = _context.Tbmodelos.ToList();
            var nuevoVehiculo = new Tbvehiculo();
            var newModel = _tbmodelos.Find(x => x.IdMarca == nuevoVehiculoEnVenta.modelo.idMarca && x.IdTipoVehiculo == nuevoVehiculoEnVenta.modelo.idTipoVehiculo && x.IdTipoCombustible == nuevoVehiculoEnVenta.modelo.idTipoCombustible);
            if (newModel == null)
            {
                newModel = new Tbmodelo();
                newModel.IdMarca = (int)nuevoVehiculoEnVenta.modelo.idMarca;
                newModel.IdTipoCombustible = (int)nuevoVehiculoEnVenta.modelo.idTipoCombustible;
                newModel.IdTipoVehiculo = (int)nuevoVehiculoEnVenta.modelo.idTipoVehiculo;
                newModel = _context.Tbmodelos.Add(newModel).Entity;
                _context.SaveChanges();
            }
            nuevoVehiculo.Color = nuevoVehiculoEnVenta.color;
            nuevoVehiculo.Placa = nuevoVehiculoEnVenta.placa;
            nuevoVehiculo.IdPropietario = 1;
            nuevoVehiculo.IdModelo = newModel.Id;
            nuevoVehiculo = _context.Tbvehiculos.Add(nuevoVehiculo).Entity;
            _context.SaveChanges();
            var nuevoProducto = new Tbproducto();
            nuevoProducto.IdTipoProducto = 1;
            nuevoProducto.PrecioUnitario = ((decimal)nuevoVehiculoEnVenta.precio);
            nuevoProducto.UrlFotografia = nuevoVehiculoEnVenta.urlFoto;
            _context.Tbproductos.Add(nuevoProducto);
            _context.SaveChanges();
            Console.WriteLine("El nuevo producto es " + nuevoProducto.Id.ToString());
            var nuevaDisponibilidad = new Tbdisponibilidad();
            nuevaDisponibilidad.Cantidad = 1;
            nuevaDisponibilidad.IdSucursal = 1;
            nuevaDisponibilidad.IdProducto = nuevoProducto.Id;
            nuevaDisponibilidad = _context.Tbdisponibilidads.Add(nuevaDisponibilidad).Entity;
            _context.SaveChanges();
            var tbvehiculoEnVenta = new Tbvehiculoenventum();
            tbvehiculoEnVenta.IdProducto = nuevoProducto.Id;
            tbvehiculoEnVenta.IdVehiculo = nuevoVehiculo.Id;
            tbvehiculoEnVenta = _context.Tbvehiculoenventa.Add(tbvehiculoEnVenta).Entity;
            _context.SaveChanges();
        }

        // PUT api/<VehiculosEnVentaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] VehiculoEnVenta nuevoVehiculoEnVenta)
        {
            _tbvehiculosenventa = _context.Tbvehiculoenventa.ToList();
            _tbvehiculos = _context.Tbvehiculos.ToList();
            _tbproductos = _context.Tbproductos.ToList();
            var vehiculoEnVenta = _tbvehiculosenventa.Find(x => x.Id == id);
            if (vehiculoEnVenta != null)
            {
                var vehiculo = _tbvehiculos.Find(x => x.Id == vehiculoEnVenta.IdVehiculo);
                var producto = _tbproductos.Find(x => x.Id == vehiculoEnVenta.IdProducto);
                if (vehiculo != null && producto != null)
                {
                    if (nuevoVehiculoEnVenta.placa != "")
                    {
                        vehiculo.Placa = nuevoVehiculoEnVenta.placa;
                        _context.Entry(vehiculo).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    if (nuevoVehiculoEnVenta.color != "")
                    {
                        vehiculo.Color = nuevoVehiculoEnVenta.color;
                        _context.Entry(vehiculo).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    if (nuevoVehiculoEnVenta.precio != 0)
                    {
                        producto.PrecioUnitario = ((decimal)nuevoVehiculoEnVenta.precio);
                        _context.Entry(producto).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                }

            }
        }

        // DELETE api/<VehiculosEnVentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tbvehiculosenventa = _context.Tbvehiculoenventa.ToList();
            _tbvehiculos = _context.Tbvehiculos.ToList();
            _tbproductos = _context.Tbproductos.ToList();
            _tbdisponibilidad = _context.Tbdisponibilidads.ToList();
            var vehiculoEnVenta = _tbvehiculosenventa.Find(x=>x.Id==id);
            if(vehiculoEnVenta!=null){
                var vehiculo = _tbvehiculos.Find(x => x.Id == vehiculoEnVenta.IdVehiculo);
                var producto = _tbproductos.Find(x => x.Id == vehiculoEnVenta.IdProducto);
                if (vehiculo != null && producto != null)
                {
                    var disponibilidades = _tbdisponibilidad.FindAll(x => x.IdProducto == producto.Id);
                    foreach (Tbdisponibilidad i in disponibilidades)
                    {
                        _context.Tbdisponibilidads.Remove(i);
                        _context.SaveChanges();
                    }
                    _context.Tbvehiculoenventa.Remove(vehiculoEnVenta);
                    _context.SaveChanges();
                    _context.Tbproductos.Remove(producto);
                    _context.SaveChanges();
                    _context.Tbvehiculos.Remove(vehiculo);
                    _context.SaveChanges();
                }
            }
        }




    }
}
