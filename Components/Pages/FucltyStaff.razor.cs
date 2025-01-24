using BlazorAppServer.UnitOfWork;

namespace BlazorAppServer;

public partial class FucltyStaff
{
    Staff? facultyStaff = new();
    List<Staff>? FacultyStaff = new List<Staff>();
    public Modal? modalComponent;

    [Inject] public IFacultyStaffUnitOfWork? _facultyStaffUnitOfWork { get; set; }
    protected async override Task OnInitializedAsync()
    {
        Console.WriteLine("OnInitializedAsync invoked.");

        FacultyStaff = await GetStaffAsync();

        if (facultyStaff is not null && FacultyStaff is not null && !FacultyStaff.Any())
        {
            facultyStaff.Id = Guid.NewGuid();
            facultyStaff.Name = "Eman Selim";
            facultyStaff.Mobile = "0128887899";
            facultyStaff.Email = "emo@innotech.com.eg";
            facultyStaff.Age = 45;
            facultyStaff.Department = "Computer & automatic control";
        }

        await base.OnInitializedAsync();
    }
    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        Console.WriteLine($"OnAfterRenderAsync invoked. firstRender = {firstRender}");

        await base.OnAfterRenderAsync(firstRender);
    }
    private async Task HandleValidSubmit()
    {

        Console.WriteLine("HandleValidSubmit invoked.");

        ArgumentNullException.ThrowIfNull(facultyStaff);

        string facultyStaffSerialized = facultyStaff is null ? string.Empty : JsonSerializer.Serialize(facultyStaff);
        Staff? validFacultyStaff = JsonSerializer.Deserialize<Staff>(facultyStaffSerialized);

        if (validFacultyStaff is null)
            throw new ArgumentNullException(nameof(validFacultyStaff));

        Staff? newStudent = FacultyStaff?.FirstOrDefault(e => e.Name is not null && e.Name.Equals(validFacultyStaff?.Name));

        if (newStudent is null && _facultyStaffUnitOfWork is not null)
        {
            validFacultyStaff.Id = Guid.NewGuid();

            await _facultyStaffUnitOfWork.Create(validFacultyStaff);
        }
        else if (_facultyStaffUnitOfWork is not null)
        {
            await _facultyStaffUnitOfWork.Update(validFacultyStaff);
        }

        if (_facultyStaffUnitOfWork is null) throw new Exception();

        FacultyStaff = await GetStaffAsync();
    }
    private async Task<List<Staff>> GetStaffAsync()
    {
        Console.WriteLine("GetFacultyStaffAsync invoked.");

        if (_facultyStaffUnitOfWork is not null)
            return (List<Staff>)await _facultyStaffUnitOfWork.ReadAll();
        else
            return new();
    }

    private void EditStudent(Staff toBeEditedStudent)
    {
        Console.WriteLine("EditFacultyStaff invoked.");

        string? FacultyStaffSerialized = JsonSerializer.Serialize(toBeEditedStudent);
        if (FacultyStaffSerialized is not null)
            facultyStaff = JsonSerializer.Deserialize<Staff>(FacultyStaffSerialized);

        StateHasChanged();
    }

    public void DeleteStaff(Staff item)
    {
        ArgumentNullException.ThrowIfNull(item);

        Console.WriteLine("DeleteStaff invoked.");

        _facultyStaffUnitOfWork?.Delete(item);
    }

    private async void ShowModal()
    {
        Console.WriteLine("ShowModal invoked.");


        if (modalComponent is not null)
        {
            await modalComponent.ShowModal();
        }
        else
        {
            Console.WriteLine("modalComponent is null.");
        }
    }
    private void Clear()
    {
        Console.WriteLine("Clear invoked.");

        facultyStaff = new Staff();
    }
}