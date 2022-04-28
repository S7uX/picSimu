using Microsoft.AspNetCore.Components.Forms;

namespace picSimu;

public class Port
{
    public bool Pin0 { get; set; }
    public bool Pin1 { get; set; }
    public bool Pin2 { get; set; }
    public bool Pin3 { get; set; }
    public bool Pin4 { get; set; }
    public bool Pin5 { get; set; }
    public bool Pin6 { get; set; }
    public bool Pin7 { get; set; }
}

public class Timing
{
    public uint QuartzFrequency { get; set; }
    public bool ReleaseWatchdog { get; set; }
}
