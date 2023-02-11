using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using picSimu.Simulation;
using picSimu.Simulation.Instructions;

namespace picSimu.Pages;

public partial class Index : ComponentBase
{
    private IJSObjectReference? _module;
    private int _rowCount = 0;

    /// <summary>
    /// Positioning of breakpoints
    /// </summary>
    private readonly HashSet<int> _instructionRows = new();

    private InstructionCode[]? _instructionCodes;
    private int _visualizedProgramCounter;
    private bool _autoStep = false;

    private bool _run = false;

    // private bool _isRunning => _autoStep || _pic.PicRun is not null;
    private bool _isRunning => _autoStep || _run;
    private bool _showEeprom = false;

    private Pic _pic;
    private readonly RegisterPair[] _registerBindings;

    public Index()
    {
        _pic = new Pic();
        _visualizedProgramCounter = -1;

        _registerBindings = new RegisterPair[Memory.MEMORY_LENGTH / 2];
        _createRegisterBindings();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _module = await Js.InvokeAsync<IJSObjectReference>("import", "/js/parser.js");

            DotNetObjectReference<Index> dotNetObjRef = DotNetObjectReference.Create(this);
            await _module.InvokeVoidAsync("setDotNetObjRef", dotNetObjRef);
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

    [JSInvokable("LoadProgram")]
    public void LoadProgram(LoadProgramParameters parameters)
    {
        _rowCount = parameters.RowCount;
        _instructionCodes = parameters.InstructionCodes;
        if (_instructionCodes != null)
        {
            _instructionRows.Clear();
            foreach (InstructionCode instructionCode in _instructionCodes)
            {
                _instructionRows.Add(instructionCode.RowNumber);
            }

            _initializePic();
        }

        InvokeAsync(StateHasChanged);
    }

    public class LoadProgramParameters
    {
        public int RowCount { get; set; }
        public InstructionCode[] InstructionCodes { get; set; }
    }

    private void _initializePic()
    {
        _pic = new Pic();
        _visualizedProgramCounter = -1;
        _createRegisterBindings();

        if (_instructionCodes != null)
        {
            _pic.LoadInstructionCodes(_instructionCodes);
        }
    }

    private void SimulationStep()
    {
        if (_instructionCodes != null)
        {
            _pic.Step();
        }
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
        else if (_run)
        {
            _run = false;
        }
    }

    private async void RunSimulation()
    {
        /* // implementation with extra thread
        Task simulationTask = _pic.Run();
        await simulationTask;
        await simulationTask.ContinueWith(_ =>
        {
            _pic.PicRun = null;
            return InvokeAsync(StateHasChanged);
        }, TaskContinuationOptions.NotOnCanceled);
        */

        if (_run)
        {
            return; // already running
        }

        _run = true;
        StateHasChanged(); // trigger gui update
        await Task.Delay(100); // only the state with the updated _run should be displayed

        while (_run)
        {
            SimulationStep(); // ignore first breakpoint
            for (int i = 0; i < 100 && _run; i++)
            {
                if (_pic.BreakPoints[_pic.ProgramCounter] && !_pic.IsSleeping)
                {
                    StopSimulation();
                    break;
                }

                SimulationStep();
            }

            await Task.Yield(); // give execution context back to gui - continue when gui awaits something
        }

        StopSimulation();
        StateHasChanged();
    }

    private async void AutoStepSimulation()
    {
        if (_autoStep)
        {
            return; // already auto stepping
        }

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
            try
            {
                await _module.DisposeAsync();
            }
            catch (JSDisconnectedException)
            {
                // ignore
            }
        }
    }
}