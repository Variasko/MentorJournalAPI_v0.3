using Microsoft.EntityFrameworkCore;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<MentorJournalV02Context>(options =>
    options.UseSqlServer("Data Source=DESKTOP-J7F367J\\SQLEXPRESS;Initial Catalog=MentorJournal_v0.2;Integrated Security=True;Encrypt=False"));

// Add services
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IHobbieService, HobbieService>();
builder.Services.AddScoped<IHobbieTypeService, HobbieTypeService>();
builder.Services.AddScoped<IIndividualWordWithStudentService, IndividualWordWithStudentService>();
builder.Services.AddScoped<IIndividualWorkWithParentService, IndividualWorkWithParentService>();
builder.Services.AddScoped<IMentorService, MentorService>();
builder.Services.AddScoped<IObservationListService, ObservationListService>();
builder.Services.AddScoped<IParentService, ParentService>();
builder.Services.AddScoped<IParentConferenceService, ParentConferenceService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ISocialPassportService, SocialPassportService>();
builder.Services.AddScoped<ISocialStatusService, SocialStatusService>();
builder.Services.AddScoped<ISpecificationService, SpecificationService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentInGroupService, StudentInGroupService>();
builder.Services.AddScoped<IActivistService, ActivistService>();
builder.Services.AddScoped<IActivityTypeService, ActivityTypeService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAttendClassHourService, AttendClassHourService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IClassHourService, ClassHourService>();
builder.Services.AddScoped<IDegreeOfKinshipService, DegreeOfKinshipService>();
builder.Services.AddScoped<IDormitoryService, DormitoryService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
