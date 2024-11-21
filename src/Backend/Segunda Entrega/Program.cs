using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using ProjetoPI.Data;
using ProjetoPI.Interface;
using ProjetoPI.Repository;
using ProjetoPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Configure a string de conexão MySQL
var mysqlConnectionBuilder = new MySqlConnectionStringBuilder
{
    Server = "sypbancodedados.mysql.database.azure.com",  // Substitua pelo seu servidor
    Database = "testeazure",  // Substitua pelo nome do seu banco de dados
    UserID = "admin_syp",  // Substitua pelo seu usuário
    Password = "Syp12345",  // Substitua pela sua senha
    SslMode = MySqlSslMode.Required,
    AllowPublicKeyRetrieval = true
};

// Adiciona CORS para permitir requisições de localhost
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod() // Inclui o método OPTIONS
              .SetPreflightMaxAge(TimeSpan.FromMinutes(10)); // Cacheia as respostas de preflight
    });
});


// Habilita suporte a sessão
builder.Services.AddDistributedMemoryCache();  // Usando memória para armazenar sessão
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tempo de expiração da sessão
    options.Cookie.HttpOnly = true;  // Só acessível via HTTP
});

// Configuração de autenticação, caso esteja usando cookies ou JWT
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Caminho da página de login
        options.AccessDeniedPath = "/AccessDenied"; // Caminho de acesso negado
    });

// Registra os serviços e repositórios no contêiner de DI
builder.Services.AddControllersWithViews(); // Suporte para Views além de Controllers 

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoPI", Version = "v1" });
});

// Registra o contexto do banco de dados com a string de conexão do MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(mysqlConnectionBuilder.ConnectionString));

// Registra os repositórios e serviços no contêiner de DI
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IDoadorRepository, DoadorRepository>();
builder.Services.AddScoped<IOngRepository, OngRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

// Adiciona o HttpContextAccessor para sessões
builder.Services.AddHttpContextAccessor();

// Configuração do Application Insights
builder.Services.AddApplicationInsightsTelemetry(options =>
{
    options.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];
});

// Adiciona logs
builder.Logging.AddConsole(); // Habilita logs no console

var app = builder.Build();

// Configure o pipeline de solicitação HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoPI v1"));
}
else
{
    // Para ambiente de produção
    app.UseExceptionHandler("/Home/Error"); // Tratamento de exceções
    app.UseHsts(); // Habilita HTTP Strict Transport Security
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoPI v1");
        c.RoutePrefix = string.Empty;  // Para exibir o Swagger na raiz
    });
}

// Ativa o CORS com a política configurada
app.UseCors("AllowLocalhost");
app.Use(async (context, next) =>
{
    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 200;
        await context.Response.CompleteAsync();
        return;
    }
    await next();
});

// Ativa o uso de sessão
app.UseSession();

// Ativa a autenticação
app.UseAuthentication();  
app.UseAuthorization();

// Mapear controladores
app.MapControllers();

app.Run();
