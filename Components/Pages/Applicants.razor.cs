namespace BlazorAppServer;

public partial class Applicants
{
    Applicant? applicant = new();
    List<Applicant>? applicants = new List<Applicant>();
    public Modal? modalComponent;

    [Inject] public IApplicantsRepository? _applicantsRepository { get; set; }
    protected async override Task OnInitializedAsync()
    {
        Console.WriteLine("OnInitializedAsync invoked.");

        applicants = await GetApplicantsAsync();

        if (applicant is not null && applicants is not null && !applicants.Any())
        {
            applicant.Id = Guid.NewGuid();
            applicant.Name = "Selim Salem";
            applicant.Mobile = "012233344576";
            applicant.Age = 30;
            applicant.SecondarySchoolName = "Talaat Harb";
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

        ArgumentNullException.ThrowIfNull(applicant);

        string studentSerialized = applicant is null ? string.Empty : JsonSerializer.Serialize(applicant);
        Applicant? validApplicant = JsonSerializer.Deserialize<Applicant>(studentSerialized);

        if (validApplicant is null)
            throw new ArgumentNullException(nameof(validApplicant));

        Applicant? newApplicant = applicants?.FirstOrDefault(e => e.Name is not null && e.Name.Equals(validApplicant?.Name));

        if (newApplicant is null && _applicantsRepository is not null)
        {
            validApplicant.Id = Guid.NewGuid();

            await _applicantsRepository.Insert(validApplicant);
        }
        else if (_applicantsRepository is not null)
        {
            await _applicantsRepository.Update(validApplicant);
        }

        if (_applicantsRepository is null) throw new Exception();

        applicants = await GetApplicantsAsync();
    }
    private async Task<List<Applicant>> GetApplicantsAsync()
    {
        Console.WriteLine("GetApplicantsAsync invoked.");

        if (_applicantsRepository is not null)
            return (List<Applicant>) await _applicantsRepository.GetAll();
        else
            return new();
    }

    private void EditApplicant(Applicant toBeEditedApplicant)
    {
        Console.WriteLine("EditApplicant invoked.");

        string? studentSerialized = JsonSerializer.Serialize(toBeEditedApplicant);
        if (studentSerialized is not null)
            applicant = JsonSerializer.Deserialize<Applicant>(studentSerialized);

        StateHasChanged();
    }

    public async Task DeleteApplicant(Applicant item)
    {
        ArgumentNullException.ThrowIfNull(item);

        Console.WriteLine("DeleteApplicant invoked.");

        _applicantsRepository?.Delete(item);

        if (_applicantsRepository is null) throw new Exception();
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

        applicant = new Applicant();
    }
}