var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policity =>
    {
        policity
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
var app = builder.Build();
app.UseCors();
// Endpoint de prueba inicial
app.MapGet("/", () =>
{
    return "API Sistema de Gestión de Restaurante funcionando";
});
// Endpoint para la información general de la empresa (Inicio)
app.MapGet("/api/empresa", () =>
{
    return Results.Ok(new
    {
        Nombre = "Sabor & Tradición - Restaurante",
        Descripcion = "Las mejores especialidades gastronómicas, platos criollos, marinos y postres tradicionales.",
        Telefono = "+51 987 654 321",
        Ubicacion = "Av. Real 456, Huancayo",
        HorarioAtencion = "Lunes a Domingo de 11:00 AM a 10:00 PM"
    });
});
// Endpoint Recurso Principal: Catálogo de Productos (Restaurante)
app.MapGet("/api/ropa", () =>
{
    return Results.Ok(new[]
    {
        new
        {
            ID = 1,
            Nombre = "Lomo Saltado Tradicional",
            Categoria = "Platos de Fondo",
            Marca = "Cocina Criolla",
            Talla = "Personal",
            Precio = 42.90,
            Stock = 25,
            Descuento = 10,
            Imagen = "https://images.unsplash.com/photo-1544025162-d76694265947?w=500",
            Codigo = "PLA-001",
            Genero = "Caliente",
            Color = "Dorado / Flameado",
            Material = "Lomo de res, cebolla, tomate, papas",
            Temporada = "Atemporal",
            Descripcion = "Jugosos trozos de lomo de res salteados al wok con verduras frescas, acompañado de papas fritas y arroz."
        },
        new
        {
            ID = 2,
            Nombre = "Ceviche Mixto Especial",
            Categoria = "Marinos",
            Marca = "Cocina Marina",
            Talla = "Personal",
            Precio = 38.00,
            Stock = 18,
            Descuento = 0,
            Imagen = "https://images.unsplash.com/photo-1535399831218-d5bd36d1a6b3?w=500",
            Codigo = "CEV-002",
            Genero = "Frío",
            Color = "Blanco / Marino",
            Material = "Pescado fresco, mariscos, limón, cebolla",
            Temporada = "Verano",
            Descripcion = "Frescos trozos de pescado y mariscos marinados en zumo de limón de pica con ají limo y guarniciones."
        },
        new
        {
            ID = 3,
            Nombre = "Causa Rellena de Pollo",
            Categoria = "Entradas",
            Marca = "Cocina Criolla",
            Talla = "Entrada",
            Precio = 22.50,
            Stock = 20,
            Descuento = 15,
            Imagen = "https://images.unsplash.com/photo-1540420773420-3366772f4999?w=500",
            Codigo = "CAU-003",
            Genero = "Frío",
            Color = "Amarillo",
            Material = "Papa amarilla, pechuga de pollo, mayonesa, palta",
            Temporada = "Atemporal",
            Descripcion = "Suave masa de papa amarilla sazonada con limón y ají amarillo, rellena de pechuga de pollo deshilachada."
        },
        new
        {
            ID = 4,
            Nombre = "Pisco Sour Tradicional",
            Categoria = "Bebidas",
            Marca = "Barra & Coctelería",
            Talla = "Copa 300ml",
            Precio = 25.00,
            Stock = 30,
            Descuento = 5,
            Imagen = "https://images.unsplash.com/photo-1514362545857-3bc16c4c7d1b?w=500",
            Codigo = "BEB-004",
            Genero = "Coctel",
            Color = "Blanco Espumoso",
            Material = "Pisco Quebranta, zumo de limón, jarabe, clara de huevo",
            Temporada = "Atemporal",
            Descripcion = "Coctel emblemático a base de pisco peruano, batido a la perfección con un toque de amargo de angostura."
        }
    });
});
// Endpoint Recurso 2: Categorías de comida
app.MapGet("/api/categorias", () =>
{
    return Results.Ok(new[]
    {
        new { ID = 1, Nombre = "Entradas", Descripcion = "Causas, Papa a la Huancaína, Tamales y Anticuchos" },
        new { ID = 2, Nombre = "Platos de Fondo", Descripcion = "Lomo Saltado, Ají de Gallina, Arroz con Pato y Secos" },
        new { ID = 3, Nombre = "Marinos", Descripcion = "Ceviches, Tiraditos, Jaleas y Arroz con Mariscos" },
        new { ID = 4, Nombre = "Bebidas", Descripcion = "Refrescos naturales, Cocteles, Vinos y Cervezas" }
    });
});
// Endpoint Recurso 3: Marcas disponibles
app.MapGet("/api/marcas", () =>
{
    return Results.Ok(new[]
    {
        new { ID = 1, Nombre = "Cocina Criolla", PaisOrigen = "Perú" },
        new { ID = 2, Nombre = "Cocina Marina", PaisOrigen = "Perú" },
        new { ID = 3, Nombre = "Barra & Coctelería", PaisOrigen = "Perú" }
    });
});
// Endpoint Recurso 4: Promociones activas
app.MapGet("/api/promociones", () =>
{
    return Results.Ok(new[]
    {
        new
        {
            ID = 1,
            Titulo = "Descuento Ejecutivo",
            Descripcion = "Hasta 15% OFF en Platos de Fondo de lunes a viernes de 12:00 PM a 3:00 PM.",
            CodigoDescuento = "ALMUERZO15"
        },
        new
        {
            ID = 2,
            Titulo = "Delivery Gratis",
            Descripcion = "Por consumos superiores a S/ 100 a todo Huancayo.",
            CodigoDescuento = "DELIVERYGRATIS"
        }
    });
});
var port = Environment.GetEnvironmentVariable("Port") ?? "10000";
app.Run();