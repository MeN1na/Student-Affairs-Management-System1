using BlazorAppServer.UnitOfWork;

namespace BlazorAppServer;

public partial class Students
{
    Student? student = new();
    List<Student>? students = new List<Student>();
    public Modal? modalComponent;

    [Inject] public IStudentsUnitOfWork? _studentsUnitOfWork { get; set; }
    protected async override Task OnInitializedAsync()
    {
        Console.WriteLine("OnInitializedAsync invoked.");

        students = await GetStudentsAsync();

        if (student is not null && students is not null && !students.Any())
        {
            student.Id = Guid.NewGuid();
            student.Name = "Menna Selim";
            student.Mobile = "01234567899";
            student.Email = "menna@innotech.com.eg";
            student.Age = 33;
            student.ScholarShipType="fully funded";
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

        ArgumentNullException.ThrowIfNull(student);

        string studentSerialized = student is null ? string.Empty : JsonSerializer.Serialize(student);
        Student? validStudent = JsonSerializer.Deserialize<Student>(studentSerialized);

        if (validStudent is null)
            throw new ArgumentNullException(nameof(validStudent));

        Student? newStudent = students?.FirstOrDefault(e => e.Name is not null && e.Name.Equals(validStudent?.Name));

        if (newStudent is null && _studentsUnitOfWork is not null)
        {
            validStudent.Id = Guid.NewGuid();

            await _studentsUnitOfWork.Create(validStudent);
        }
        else if (_studentsUnitOfWork is not null)
        {
            await _studentsUnitOfWork.Update(validStudent);
        }

        if (_studentsUnitOfWork is null) throw new Exception();

        students = await GetStudentsAsync();
    }
    private async Task<List<Student>> GetStudentsAsync()
    {
        Console.WriteLine("GetStudentsAsync invoked.");

        if (_studentsUnitOfWork is not null)
            return (List<Student>)await _studentsUnitOfWork.ReadAll();
        else
            return new();
    }

    private void EditStudent(Student toBeEditedStudent)
    {
        Console.WriteLine("EditStudent invoked.");

        string? studentSerialized = JsonSerializer.Serialize(toBeEditedStudent);
        if (studentSerialized is not null)
            student = JsonSerializer.Deserialize<Student>(studentSerialized);

        StateHasChanged();
    }

    public void DeleteStudent(Student item)
    {
        ArgumentNullException.ThrowIfNull(item);

        Console.WriteLine("DeleteStudent invoked.");

        _studentsUnitOfWork?.Delete(item);
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

        student = new Student();
    }
}