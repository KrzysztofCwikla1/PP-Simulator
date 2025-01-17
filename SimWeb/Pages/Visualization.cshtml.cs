using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;
using SimConsole;
namespace SimConsole.Pages;

public class VisualizationModel : PageModel
{
    public SimulationHistory SimulationHistory { get; private set; }
    public int CurrentTurn { get; private set; }
    public int MapWidth => SimulationHistory.SizeX;
    public int MapHeight => SimulationHistory.SizeY;
    public string FormatMoveInfo(SimulationTurnLog turnLog)
    {
        var mappableInfo = turnLog.Mappable;
        var direction = DirectionParser.FullDirectionName(DirectionParser.Parse(turnLog.Move)[0]);
        return $"{mappableInfo} goes {direction}";
    }
    public bool IsFirstTurn => CurrentTurn == 0;
    public bool IsLastTurn => CurrentTurn == SimulationHistory.TurnLogs.Count - 1;
    public string MoveInfo { get; private set; }


    public char GetSymbol(int x, int y)
    {
        var log = SimulationHistory.TurnLogs[CurrentTurn];
        var point = new Point(x, y);
        return log.Symbols.ContainsKey(point) ? log.Symbols[point] : ' ';
    }

    public VisualizationModel()
    {

        var map = new SmallTorusMap(8, 6);
        var mappables = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Rabbits", Size = 5 },
            new Birds { Description = "Eagles", CanFly = true, Size = 5 },
            new Birds { Description = "Ostriches", CanFly = false, Size = 3 }
        };

        var positions = new List<Point>
        {
            new(2, 2), new(3, 1), new(3, 3), new(4, 4), new(5, 5)
        };

        var simulation = new Simulation(map, mappables, positions, "dlrludllurdlurrr");
        SimulationHistory = new SimulationHistory(simulation);

        CurrentTurn = 0;
    }

    public void OnGet(int? turn)
    {
        CurrentTurn = turn ?? 0;


        SimulationTurnLog turnLog = SimulationHistory.TurnLogs[CurrentTurn];

        MoveInfo = FormatMoveInfo(turnLog);
    }
}
