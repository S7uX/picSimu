using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using picSimu.Simulation;
using picSimu.Simulation.Registers;

namespace picSimu.Pages;

public partial class Index : ComponentBase
{
    private IJSObjectReference? module;
    private string _sourceCode = "";
    private string _parsedInstructionCodes = "";
    private HashSet<int> _instructionRows = new HashSet<int>();
    public string[]? InstructionCodes;

    private Pic pic;
    private Regsiter[] _regsiterBindings;
    
    public Index()
    {
        pic = new Pic();
        _regsiterBindings = new Regsiter[Pic.ProgramMemoryLength];
        _createRegisterBindings();
    }

    private void _createRegisterBindings()
    {
        for (uint i = 0; i < _regsiterBindings.Length; i++)
        {
            _regsiterBindings[i] = pic.Memory.GetRegister(i);
        }
    }
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>("import", "./js/parser.js");
        }
    }

    private async Task LoadFiles(InputFileChangeEventArgs e)
    {
        _sourceCode = await new StreamReader(e.File.OpenReadStream()).ReadToEndAsync();
        _instructionRows = await DisplayPicCode(_sourceCode) ?? new HashSet<int>();
        _parsedInstructionCodes = await GetInstructionCodes(_sourceCode);
        Console.WriteLine("parsed instruction codes: " + _parsedInstructionCodes);
        if (_parsedInstructionCodes != null)
        {
            _initializePic();
        }
    }


    private void _initializePic()
    {
        InstructionCodes = _parsedInstructionCodes.Split(",");
        pic = new Pic();

        if (InstructionCodes != null)
        {
            pic.LoadInstructionCodes(InstructionCodes);
        }

        _createRegisterBindings();
    }

    public async Task<HashSet<int>?> DisplayPicCode(string sourceCode)
    {
        if (module is not null)
        {
            var res = await module.InvokeAsync<string>("parsePic", sourceCode);
            return new HashSet<int>(res.Split(",").Select(n => Convert.ToInt32(n)).ToArray());
        }
        return null;
    }

    public async ValueTask<string?> GetInstructionCodes(string sourceCode)
    {
        if (module is not null)
            return await module.InvokeAsync<string>("getInstructionCodes", sourceCode);
        else
            return null;
    }

    public async Task<bool> RunSimulation()
    {
        if (InstructionCodes != null)
        {
            pic.Run();
        }
        return false;
    }

    public async Task<bool> StopSimulation()
    {
        if (InstructionCodes != null)
        {
            pic.Stop();
        }
        return false;
    }

    public async Task<bool> StepSimulation()
    {
        if (InstructionCodes != null)
        {
            pic.Step();
            await UpdateProgramCounter();
        }
        return false;
    }

    public async Task<bool> ResetSimulation()
    {
        if (InstructionCodes != null)
        {
            pic = new Pic();
        }
        return false;
    }

    // public async ValueTask DisposeAsync()
    // {
    //     if (module is not null)
    //     {
    //         await module.DisposeAsync();
    //     }
    // }

    private async ValueTask UpdateProgramCounter()
    {
        if (module != null)
        {
            await module.InvokeAsync<string>("highlightCodeLine", pic.Programmcounter.ToString());
        }
    }

    public Timing Timing { get; set; } = new Timing() {QuartzFrequency = 32, ReleaseWatchdog = false};
}