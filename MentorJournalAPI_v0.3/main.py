import os

models = [
    "Group", "Hobbie", "HobbieType", "IndividualWordWithStudent", "IndividualWorkWithParent",
    "Mentor", "ObservationList", "Parent", "ParentConference", "Person", "SocialPassport",
    "SocialStatus", "Specification", "Student", "StudentInGroup", "Activist", "ActivityType",
    "Admin", "AttendClassHour", "Category", "ClassHour", "DegreeOfKinship", "Dormitory"
]

model_properties = {
    "Group": [
        "public int Id { get; set; }",
        "public int MentorId { get; set; }",
        "public int SpecificationId { get; set; }",
        "public bool IsBuget { get; set; }",
        "public DateOnly RecruitmentDate { get; set; }"
    ],
    "Hobbie": [
        "public int Id { get; set; }",
        "public int StudentId { get; set; }",
        "public int HobbieTypeId { get; set; }"
    ],
    "HobbieType": [
        "public int Id { get; set; }",
        "public string Name { get; set; } = null!;"
    ],
    "IndividualWordWithStudent": [
        "public int Id { get; set; }",
        "public string Title { get; set; } = null!;",
        "public string Result { get; set; } = null!;",
        "public DateOnly Date { get; set; }",
        "public int StudentId { get; set; }"
    ],
    "IndividualWorkWithParent": [
        "public int Id { get; set; }",
        "public string Title { get; set; } = null!;",
        "public string Result { get; set; } = null!;",
        "public DateOnly Date { get; set; }",
        "public int ParentId { get; set; }"
    ],
    "Mentor": [
        "public int PersonId { get; set; }",
        "public int CategoryId { get; set; }",
        "public string Login { get; set; } = null!;",
        "public string Password { get; set; } = null!;"
    ],
    "ObservationList": [
        "public int Id { get; set; }",
        "public int StudentId { get; set; }",
        "public string Characteristic { get; set; } = null!;",
        "public DateOnly Date { get; set; }"
    ],
    "Parent": [
        "public int Id { get; set; }",
        "public string Surname { get; set; } = null!;",
        "public string Name { get; set; } = null!;",
        "public string Patronymic { get; set; } = null!;",
        "public string PhoneNumber { get; set; } = null!;",
        "public string Email { get; set; } = null!;",
        "public int StudentId { get; set; }",
        "public int DegreeOfKinshipId { get; set; }"
    ],
    "ParentConference": [
        "public int Id { get; set; }",
        "public DateOnly Date { get; set; }",
        "public int AmountPresent { get; set; }",
        "public int AmountMiss { get; set; }",
        "public string Title { get; set; } = null!;",
        "public string Result { get; set; } = null!;",
        "public int GroupId { get; set; }"
    ],
    "Person": [
        "public int Id { get; set; }",
        "public byte[]? Photo { get; set; }",
        "public string Surname { get; set; } = null!;",
        "public string Name { get; set; } = null!;",
        "public string Patronymic { get; set; } = null!;",
        "public bool Gender { get; set; }",
        "public DateOnly Bithday { get; set; }",
        "public string PassportSeial { get; set; } = null!;",
        "public string PassportNumber { get; set; } = null!;",
        "public string Snils { get; set; } = null!;",
        "public string Inn { get; set; } = null!;",
        "public string PhoneNumber { get; set; } = null!;",
        "public string RegistrationAddress { get; set; } = null!;",
        "public string LivingAddress { get; set; } = null!;"
    ],
    "SocialPassport": [
        "public int Id { get; set; }",
        "public int StudentId { get; set; }",
        "public int SocialStatusId { get; set; }"
    ],
    "SocialStatus": [
        "public int Id { get; set; }",
        "public string Name { get; set; } = null!;"
    ],
    "Specification": [
        "public int Id { get; set; }",
        "public string Direction { get; set; } = null!;",
        "public string? Specialization { get; set; }",
        "public string ReductionDirection { get; set; } = null!;",
        "public string? ReductionSpecialization { get; set; }"
    ],
    "Student": [
        "public int PersonId { get; set; }",
        "public bool IsRemoved { get; set; }",
        "public DateOnly? RemovingDate { get; set; }"
    ],
    "StudentInGroup": [
        "public int Id { get; set; }",
        "public int StudentId { get; set; }",
        "public int GroupId { get; set; }",
        "public DateOnly Date { get; set; }"
    ],
    "Activist": [
        "public int Id { get; set; }",
        "public int StudentId { get; set; }",
        "public int ActivityTypeId { get; set; }"
    ],
    "ActivityType": [
        "public int Id { get; set; }",
        "public string Name { get; set; } = null!;"
    ],
    "Admin": [
        "public int PersonId { get; set; }",
        "public string Login { get; set; } = null!;",
        "public string Password { get; set; } = null!;"
    ],
    "AttendClassHour": [
        "public int Id { get; set; }",
        "public int StudentId { get; set; }",
        "public int ClassHourId { get; set; }",
        "public bool IsVisited { get; set; }"
    ],
    "Category": [
        "public int Id { get; set; }",
        "public string Name { get; set; } = null!;"
    ],
    "ClassHour": [
        "public int Id { get; set; }",
        "public DateOnly Date { get; set; }"
    ],
    "DegreeOfKinship": [
        "public int Id { get; set; }",
        "public string Name { get; set; } = null!;"
    ],
    "Dormitory": [
        "public int Id { get; set; }",
        "public int StudentId { get; set; }",
        "public int RoomNumber { get; set; }"
    ]
}

def create_dto(model_name):
    properties = "\n        ".join(model_properties[model_name])
    dto_template = f"""
namespace MentorJournalAPI_v0._3.DTOs
{{
    public class {model_name}Dto
    {{
        {properties}
    }}
}}
"""
    with open(f"DTOs/{model_name}Dto.cs", "w") as file:
        file.write(dto_template)

def create_interface(model_name):
    interface_template = f"""
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{{
    public interface I{model_name}Service
    {{
        Task<IEnumerable<{model_name}Dto>> GetAllAsync();
        Task<{model_name}Dto> GetByIdAsync(int id);
        Task<{model_name}Dto> CreateAsync({model_name}Dto {model_name.lower()}Dto);
        Task<{model_name}Dto> UpdateAsync(int id, {model_name}Dto {model_name.lower()}Dto);
        Task DeleteAsync(int id);
    }}
}}
"""
    with open(f"Interfaces/I{model_name}Service.cs", "w") as file:
        file.write(interface_template)

def create_controller(model_name):
    controller_template = f"""
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{{
    [ApiController]
    [Route("api/[controller]")]
    public class {model_name}sController : ControllerBase
    {{
        private readonly I{model_name}Service _{model_name.lower()}Service;

        public {model_name}sController(I{model_name}Service {model_name.lower()}Service)
        {{
            _{model_name.lower()}Service = {model_name.lower()}Service;
        }}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<{model_name}Dto>>> GetAll()
        {{
            try
            {{
                var {model_name.lower()}s = await _{model_name.lower()}Service.GetAllAsync();
                return Ok({model_name.lower()}s);
            }}
            catch (Exception ex)
            {{
                return StatusCode(500, $"Internal server error: {{ex.Message}}");
            }}
        }}

        [HttpGet("{{id}}")]
        public async Task<ActionResult<{model_name}Dto>> GetById(int id)
        {{
            try
            {{
                var {model_name.lower()} = await _{model_name.lower()}Service.GetByIdAsync(id);
                if ({model_name.lower()} == null)
                {{
                    return NotFound();
                }}
                return Ok({model_name.lower()});
            }}
            catch (Exception ex)
            {{
                return StatusCode(500, $"Internal server error: {{ex.Message}}");
            }}
        }}

        [HttpPost]
        public async Task<ActionResult<{model_name}Dto>> Post({model_name}Dto {model_name.lower()}Dto)
        {{
            try
            {{
                var created{model_name} = await _{model_name.lower()}Service.CreateAsync({model_name.lower()}Dto);
                return CreatedAtAction(nameof(GetById), new {{ id = created{model_name}.Id }}, created{model_name});
            }}
            catch (Exception ex)
            {{
                return StatusCode(500, $"Internal server error: {{ex.Message}}");
            }}
        }}

        [HttpPut("{{id}}")]
        public async Task<ActionResult<{model_name}Dto>> Put(int id, {model_name}Dto {model_name.lower()}Dto)
        {{
            try
            {{
                var updated{model_name} = await _{model_name.lower()}Service.UpdateAsync(id, {model_name.lower()}Dto);
                if (updated{model_name} == null)
                {{
                    return NotFound();
                }}
                return Ok(updated{model_name});
            }}
            catch (Exception ex)
            {{
                return StatusCode(500, $"Internal server error: {{ex.Message}}");
            }}
        }}

        [HttpDelete("{{id}}")]
        public async Task<ActionResult> Delete(int id)
        {{
            try
            {{
                await _{model_name.lower()}Service.DeleteAsync(id);
                return NoContent();
            }}
            catch (Exception ex)
            {{
                return StatusCode(500, $"Internal server error: {{ex.Message}}");
            }}
        }}
    }}
}}
"""
    with open(f"Controllers/{model_name}sController.cs", "w") as file:
        file.write(controller_template)

def create_servise(model_name):
    servise_template = f"""
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Services
{{
public class {model_name}Service : I{model_name}Service
    {{
        
    }}
}}
"""
    with open(f"Services/{model_name}Service.cs", "w") as file:
        file.write(servise_template)

def main():
    os.makedirs("DTOs", exist_ok=True)
    os.makedirs("Interfaces", exist_ok=True)
    os.makedirs("Controllers", exist_ok=True)
    os.makedirs("Services", exist_ok=True)

    for model in models:
        create_dto(model)
        create_interface(model)
        create_controller(model)
        create_servise(model)

if __name__ == "__main__":
    main()
