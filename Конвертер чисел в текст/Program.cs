using Конвертер_чисел_в_текст.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(); 
var app = builder.Build();
app.UseSession();

app.UseFromThousand();
app.UseFromHundredToThousand();
app.UseFromTwentyToHundred();
app.UseFromElevenToNineteen();
app.UseFromOneToTen();

app.Run();
