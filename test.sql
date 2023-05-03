tbvehiculoenventa AS vehiculoenveta,
tbvehiculo AS vehiculo,
tbtipovehiculo AS tipov,
tbtipocombustible AS tipoc,
tbmarca AS marca,
tbmodelo AS modelo,
tbproducto AS producto,
tbdisponibilidad as disponibilidad,
tbsucursal as sucursal
SELECT
    vehiculoenveta.id as id,
    vehiculoenveta.idVehiculo as idVehiculo,
    vehiculoenveta.idProducto as idProducto,
    producto.precioUnitario as precio,
    producto.urlFotografia as urlFoto
FROM
    tbvehiculoenventa AS vehiculoenveta,
    tbvehiculo AS vehiculo,
    tbproducto AS producto
WHERE
    vehiculoenveta.idProducto = producto.id
    AND vehiculo.id = vehiculoenveta.idVehiculo;

SELECT
    modelo.id as id,
    marca.id as idMarca,
    tipoc.id as idTipoCombustible,
    tipov.id as idTipoVehiculo,
    modelo.modelo as modelo,
    marca.marca as marca,
    tipoc.tipoCombustible as tipoCombustible,
    tipov.tipoVehiculo as tipoVehiculo
FROM
    tbvehiculo AS vehiculo,
    tbtipovehiculo AS tipov,
    tbtipocombustible AS tipoc,
    tbmarca AS marca,
    tbmodelo AS modelo
WHERE
    vehiculo.id = 1
    AND vehiculo.idModelo = modelo.id
    AND marca.id = modelo.idMarca
    AND tipov.id = modelo.idTipoVehiculo
    AND tipoc.id = modelo.idTipoCombustible;

SELECT
    disponibilidad.id as id,
    sucursal.id as idSucursal,
    disponibilidad.cantidad as disponibilidad,
    sucursal.ciudad as ciudadSucursal,
    sucursal.nombre as nombreSucursal
FROM
    tbvehiculoenventa AS vehiculoenveta,
    tbproducto AS producto,
    tbdisponibilidad as disponibilidad,
    tbsucursal as sucursal
WHERE
    vehiculoenveta.idProducto = producto.id
    AND disponibilidad.idProducto = producto.id
    AND sucursal.id = disponibilidad.idSucursal;