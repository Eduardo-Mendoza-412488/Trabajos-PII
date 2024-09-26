using Actividad01.Service;
using Actividad01.Dominio;

Console.WriteLine("*Recuperar Factura* \n");


var oServicio = new Servicio();
void MostrarFacturas()
{
    var lstFacturas = oServicio.ObtenerFacturas();
    foreach (Factura factura in lstFacturas)
    {
        Console.WriteLine(factura.ToString());
        var lstDetalles = oServicio.ObtenerDetalles(factura.Id);
        foreach (DetalleFactura Detalle in lstDetalles)
        {
            Console.WriteLine(Detalle.ToString());
        }
    }
}

MostrarFacturas();

Console.WriteLine("\nInsertar Facturas\nPresione un tecla para el siguiente paso\n");
Console.ReadLine();

var oFactura = new Factura();
oFactura.FormPago = new FormaPago();
oFactura.FormPago.Id = 1;
oFactura.Cliente = "Manuel";
oFactura.Activo = true;

//agrego 2 articulos del mismo tipo
oFactura.AgregarArticulo(1, oFactura.Detalle);
oFactura.AgregarArticulo(1, oFactura.Detalle);
//agrego 1 articulo de otro tipo
oFactura.AgregarArticulo(2, oFactura.Detalle);

if (oServicio.GuardarFactura(oFactura))
{
    MostrarFacturas();
}




Console.WriteLine("\nDar de baja \nPresione un tecla para el siguiente paso\n");
Console.ReadLine();

oServicio.DarBaja(1);

MostrarFacturas();



//foreach (DetalleFactura detail in oFactura.Detalle)
//{
//    Console.WriteLine(detail.ToString());
//}



//int UltimoId()
//{
//    var lstFacturas = oServicio.ObtenerFacturas();
//    int id = 0;
//    foreach (Factura factura in lstFacturas)
//    {
//        id = factura.Id;
//    }
//    id += 1;
//    return id;
//}

//Console.WriteLine("*Guardar Factura* \n");
//void InsertarFacturas(List<DetalleFactura> list, int FormaPago, string cliente)
//{
//    int id = UltimoId();
//    bool filas;
//    foreach (DetalleFactura detalle in list)
//    {
//        detalle.Id = id;
//        oServicio.GuardarDetalles(detalle);
//    }
//    var oFactura = new Factura();
//    oFactura.Id = 0;
//    oFactura.FormPago = new FormaPago();
//    oFactura.FormPago.Id = FormaPago;
//    oFactura.Cliente = cliente;
//    filas = oServicio.GuardarMaestro(oFactura);
//    if (filas == true)
//    {
//        Console.WriteLine("\nSe inserto con exito\n");
//    }
//    else
//        Console.WriteLine("\nNo se pudo insertar\n");
//}


//var ListaDetalles = new List<DetalleFactura>();

//var Detalle1 = new DetalleFactura(0, 3, 12);
//var Detalle2 = new DetalleFactura(0, 2, 3);
//ListaDetalles.Add(Detalle1);
//ListaDetalles.Add(Detalle2);

//InsertarFacturas(ListaDetalles, 2, "Tomi");

//MostrarFacturas();







