using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using picSimu.Simulation;

namespace picSimu.Pages;

public partial class Index : ComponentBase
{
    private IJSObjectReference? _module;
    private string _sourceCode = "";
    private HashSet<int> _instructionRows = new HashSet<int>();
    private string? _parsedInstructionCodes = "";
    private string[]? _instructionCodes;
    private int _visualizedProgramCounter;
    private bool _autoStep = false;
    private bool isRunning => _autoStep || _pic.PicRun is not null;
    private bool showEEPROM = false;

    private Pic _pic;
    private RegisterPair[] _registerBindings;

    public Index()
    {
        _pic = new Pic();
        _visualizedProgramCounter = -1;

        _registerBindings = new RegisterPair[Memory.MemoryLength / 2];
        _createRegisterBindings();
    }
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _module = await Js.InvokeAsync<IJSObjectReference>("import", "./js/parser.js");
        }

        uint pc = _pic.ProgramCounter;
        if (_pic.ProgramLoaded && pc != _visualizedProgramCounter)
        {
            await UpdateProgramCounter();
            _visualizedProgramCounter = (int) pc;
        }
    }

    private void _createRegisterBindings()
    {
        for (uint i = 0; i < _registerBindings.Length; i++)
        {
            uint y = 0x80 + i;
            _registerBindings[i] = new RegisterPair(_pic.Memory.GetRegister(i), _pic.Memory.GetRegister(y));
        }
    }

    private async Task LoadFiles(InputFileChangeEventArgs e)
    {
        _sourceCode = await new StreamReader(e.File.OpenReadStream()).ReadToEndAsync();
        _instructionRows = await DisplayPicCode(_sourceCode) ?? new HashSet<int>();
        _parsedInstructionCodes = await GetInstructionCodes(_sourceCode);
        if (_parsedInstructionCodes != null)
        {
            Console.WriteLine("parsed instruction codes: " + _parsedInstructionCodes);
            _initializePic();
        }
    }

    private void _initializePic()
    {
        _pic = new Pic();
        _visualizedProgramCounter = -1;
        _createRegisterBindings();

        if (_parsedInstructionCodes != null)
        {
            _instructionCodes = _parsedInstructionCodes.Split(",");

            if (!_instructionCodes[0].Equals(""))
            {
                _pic.LoadInstructionCodes(_instructionCodes);
            }
        }
    }

    private async Task<HashSet<int>?> DisplayPicCode(string sourceCode)
    {
        if (_module is not null)
        {
            var res = await _module.InvokeAsync<string>("parsePic", sourceCode);
            return new HashSet<int>(res.Split(",").Select(n => Convert.ToInt32(n)).ToArray());
        }

        return null;
    }

    private async ValueTask<string?> GetInstructionCodes(string sourceCode)
    {
        if (_module is not null)
        {
            return await _module.InvokeAsync<string>("getInstructionCodes", sourceCode);
        }

        return null;
    }

    private void RunSimulation()
    {
        Task simulationTask = _pic.Run();
        simulationTask.ContinueWith(_ =>
        {
            _pic.PicRun = null;
            return InvokeAsync(StateHasChanged);
        }, TaskContinuationOptions.NotOnCanceled);
    }

    private void StopSimulation()
    {
        if (_autoStep)
        {
            _autoStep = false;
        }
        else if (_pic.PicRun != null)
        {
            _pic.StopRun();
            ShouldRender();
        }
    }

    private void SimulationStep()
    {
        if (_instructionCodes != null)
        {
            _pic.Step();
        }
    }

    private async void AutoStepSimulation()
    {
        if (!_autoStep)
        {
            _autoStep = true;
            bool first = true;
            while (_autoStep)
            {
                if (_pic.BreakPoints[_pic.ProgramCounter] && !first)
                {
                    break;
                }

                first = false;

                SimulationStep();
                StateHasChanged();
                await Task.Delay(100);
            }

            StopSimulation();
            StateHasChanged();
        }
    }

    private void ResetSimulation()
    {
        _initializePic();
    }


    private async ValueTask UpdateProgramCounter()
    {
        if (_module != null)
        {
            await _module.InvokeAsync<string>("highlightCodeLine", _pic.ProgramCounter.ToString());
        }
    }

    public async ValueTask DisposeAsync()
    {
        StopSimulation();
        _pic.Dispose();
        if (_module is not null)
        {
            await _module.DisposeAsync();
        }
    }
}