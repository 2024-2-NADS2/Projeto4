using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using ProjetoPI.Data;
using ProjetoPI.Interface;
using ProjetoPI.Repository;
using ProjetoPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Configure a string de conex�o MySQL
var mysqlConnectionBuilder = new MySqlConnectionStringBuilder
{
    Server = "sypbancodedados.mysql.database.azure.com",  // Substitua pelo seu servidor
    Database = "testeazure",  // Substitua pelo nome do seu banco de dados
    UserID = "admin_syp",  // Substitua pelo seu usu�rio
    Password = "Syp12345",  // Substitua pela sua senha
    SslMode = MySqlSslMode.Required,
    AllowPublicKeyRetrieval = true
};

// Adiciona CORS para permitir requisi��es de localhost
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod() // Inclui o m�todo OPTIONS
              .SetPreflightMaxAge(TimeSpan.FromMinutes(10)); // Cacheia as respostas de preflight
    });
});


// Habilita suporte a sess�o
builder.Services.AddDistributedMemoryCache();  // Usando mem�ria para armazenar sess�o
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tempo de expira��o da sess�o
    options.Cookie.HttpOnly = true;  // S� acess�vel via HTTP
});

// Configura��o de autentica��o, caso esteja usando cookies ou JWT
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Caminho da p�gina de login
        options.AccessDeniedPath = "/AccessDenied"; // Caminho de acesso negado
    });

// Registra os servi�os e reposit�rios no cont�iner de DI
builder.Services.AddControllersWithViews(); // Suporte para Views al�m de Controllers (se necess�rio)

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoPI", Version = "v1" });
});

// Registra o contexto do banco de dados com a string de conex�o do MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(mysqlConnectionBuilder.ConnectionString));

// Registra os reposit�rios e servi�os no cont�iner de DI
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IDoadorRepository, DoadorRepository>();
builder.Services.AddScoped<IOngRepository, OngRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

// Adiciona o HttpContextAccessor para sess�es
builder.Services.AddHttpContextAccessor();

// Configura��o do Application Insights (se necess�rio)
builder.Services.AddApplicationInsightsTelemetry(options =>
{
    options.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];
});

// Adiciona logs
builder.Logging.AddConsole(); // Habilita logs no console

var app = builder.Build();

// Configure o pipeline de solicita��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoPI v1"));
}
else
{
    // Para ambiente de produ��o
    app.UseExceptionHandler("/Home/Error"); // Tratamento de exce��es
    app.UseHsts(); // Habilita HTTP Strict Transport Security
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoPI v1");
        c.RoutePrefix = string.Empty;  // Para exibir o Swagger na raiz
    });
}

// Ativa o CORS com a pol�tica configurada
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

// Ativa o uso de sess�o
app.UseSession();

// Ativa a autentica��o
app.UseAuthentication();  // Certifique-se de adicionar autentica��o
app.UseAuthorization();

// Mapear controladores
app.MapControllers();

app.Run();