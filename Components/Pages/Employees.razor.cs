using BlazorAppServer.UnitOfWork;

namespace BlazorAppServer;

public partial class Employees
{
    Employee? employee = new();
    List<Employee>? employees = new List<Employee>();
    public Modal? modalComponent;

    [Inject] public IEmployeesUnitOfWork? _employeesUnitOfWork { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Console.WriteLine("OnInitializedAsync invoked.");

        employees = await GetEmployeesAsync();

        if (employee is not null && employees is not null && !employees.Any())
        {
            employee.Id = Guid.NewGuid();
            employee.Name = "John Doe";
            employee.Mobile = "01234567890";
            employee.Email = "john@innotech.com";
            employee.Age = 30;
            employee.Role = "Developer";
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

        ArgumentNullException.ThrowIfNull(employee);

        string employeeSerialized = employee is null ? string.Empty : JsonSerializer.Serialize(employee);
        Employee? validEmployee = JsonSerializer.Deserialize<Employee>(employeeSerialized);

        if (validEmployee is null)
            throw new ArgumentNullException(nameof(validEmployee));

        Employee? newEmployee = employees?.FirstOrDefault(e => e.Name is not null && e.Name.Equals(validEmployee?.Name));

        if (newEmployee is null && _employeesUnitOfWork is not null)
        {
            validEmployee.Id = Guid.NewGuid();

            await _employeesUnitOfWork.Create(validEmployee);
        }
        else if (_employeesUnitOfWork is not null)
        {
            await _employeesUnitOfWork.Update(validEmployee);
        }

        if (_employeesUnitOfWork is null) throw new Exception();

        employees = await GetEmployeesAsync();
    }

    private async Task<List<Employee>> GetEmployeesAsync()
    {
        Console.WriteLine("GetEmployeesAsync invoked.");

        if (_employeesUnitOfWork is not null)
            return (List<Employee>)await _employeesUnitOfWork.ReadAll();
        else
            return new();
    }

    private void EditEmployee(Employee toBeEditedEmployee)
    {
        Console.WriteLine("EditEmployee invoked.");

        string? employeeSerialized = JsonSerializer.Serialize(toBeEditedEmployee);
        if (employeeSerialized is not null)
            employee = JsonSerializer.Deserialize<Employee>(employeeSerialized);

        StateHasChanged();
    }

    public void DeleteEmployee(Employee item)
    {
        ArgumentNullException.ThrowIfNull(item);

        Console.WriteLine("DeleteEmployee invoked.");

        _employeesUnitOfWork?.Delete(item);
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

        employee = new Employee();
    }
}