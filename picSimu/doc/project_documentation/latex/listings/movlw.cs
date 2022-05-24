public override int Execute()
{
    Pic.WRegister = k;
    Pic.IncreaseProgramCounter();
    return 0;
}