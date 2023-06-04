using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddJsonConsole();

// Connect to PostgreSQL Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NoteDb>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/", () => "Welcome to Notes API!");

await app.RunAsync();

record Note(int id){
    public string text {get;set;} = default!;
    public bool done {get;set;} = default!;
}


class NoteDb: DbContext {
    public NoteDb(DbContextOptions<NoteDb> options): base(options) {

    }
    public DbSet<Note> Notes => Set<Note>();
}